
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Core;
using Crowdin.Api.StringTranslations;

namespace Crowdin.Api.UnitTesting.Tests.StringTranslations
{
    public class ApprovalsApiTests
    {
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
    }
}