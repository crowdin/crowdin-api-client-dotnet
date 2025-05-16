
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Core;
using Crowdin.Api.StringTranslations;
using Crowdin.Api.UnitTesting.Resources;

namespace Crowdin.Api.UnitTesting.Tests.StringTranslations
{
    public class ApprovalsApiTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();
        
        [Fact]
        public async Task ListTranslationApprovals()
        {
            const int ProjectId = 1;
            var url = $"/projects/{ProjectId}/approvals";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();

            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.StringTranslations.ListTranslationsApproval_Response)
                });

            var executor = new StringTranslationsApiExecutor(mockClient.Object);
            ResponseList<TranslationApproval> response = await executor.ListTranslationApprovals(ProjectId);
            
            Assert.NotNull(response);
            
            TranslationApproval data = response.Data[1];
            Assert.Equal(200695, data.TranslationId);
            Assert.Equal(1234, data.StringId);
            Assert.IsType<User>(data.User);
        }
        
        [Fact]
        public async Task RemoveStringApprovals()
        {
            const int ProjectId = 1;
            const int StringId = 2;
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{ProjectId}/approvals";

            var queryParams = new Dictionary<string, string>
            {
                ["stringId"] = StringId.ToString()
            };

            mockClient
                .Setup(client => client.SendDeleteRequest(url, queryParams))
                .ReturnsAsync(HttpStatusCode.NoContent);

            var executor = new StringTranslationsApiExecutor(mockClient.Object);
            await executor.RemoveStringApprovals(ProjectId, StringId);
        }

        [Fact]
        public async Task ApprovalBatchOperations()
        {
            const int projectId = 1;

            var patches = new[]
            {
                new ApprovalBatchOpPatch
                {
                    Operation = PatchOperation.Add,
                    Path = ApprovalBatchOpPatchPath.Empty,
                    Value = new
                    {
                        translationId = 200
                    }
                },
                new ApprovalBatchOpPatch
                {
                    Operation = PatchOperation.Remove,
                    Path = new ApprovalBatchOpPatchPath(approvalId: 2815)
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(patches, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(StringTranslations_Approvals.ApprovalBatchOperations_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/projects/{projectId}/approvals";

            mockClient
                .Setup(client => client.SendPatchRequest(url, patches, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(StringTranslations_Approvals.ApprovalBatchOperations_Response)
                });
            
            var executor = new StringTranslationsApiExecutor(mockClient.Object);
            ResponseList<TranslationApproval> response = await executor.ApprovalBatchOperations(projectId, patches);
            
            Assert_TranslationApproval(response.Data.First());
        }
        
        private static void Assert_TranslationApproval(TranslationApproval? approval)
        {
            ArgumentNullException.ThrowIfNull(approval);
            
            Assert.Equal(190695, approval.Id);

            User? user = approval.User;
            ArgumentNullException.ThrowIfNull(user);
            Assert.Equal(19, user.Id);
            Assert.Equal("john_doe", user.Username);
            Assert.Equal("John Smith", user.FullName);
            
            Assert.Equal(190695, approval.TranslationId);
            Assert.Equal(2345, approval.StringId);
        }
    }
}