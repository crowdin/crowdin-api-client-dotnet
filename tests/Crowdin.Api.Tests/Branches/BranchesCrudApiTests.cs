
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Branches;
using Crowdin.Api.Core;
using Crowdin.Api.Tests.Core;

namespace Crowdin.Api.Tests.Branches
{
    public class BranchesApiTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();
        
        [Fact]
        public async Task ListBranches()
        {
            const int projectId = 1;
            const string branchName = "name";
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/projects/{projectId}/branches";
            
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();
            queryParams.Add("name", branchName);
            
            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.Branches.Response_Common_Multi)
                });
            
            var executor = new BranchesApiExecutor(mockClient.Object);
            ResponseList<Branch> response = await executor.ListBranches(projectId, branchName);
            
            Branch? branch = response.Data.FirstOrDefault();
            Assert_Branch(branch);
        }
        
        [Fact]
        public async Task AddBranch()
        {
            const int projectId = 1;
            
            var request = new AddBranchRequest
            {
                Name = "develop-master",
                Title = "Master branch"
            };
            
            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(Core.Resources.Branches.Request_AddBranch);
            Assert.Equal(expectedRequestJson, actualRequestJson);
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/projects/{projectId}/branches";
            
            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(Core.Resources.Branches.Response_Common_Single)
                });
            
            var executor = new BranchesApiExecutor(mockClient.Object);
            Branch response = await executor.AddBranch(projectId, request);
            
            Assert_Branch(response);
        }
        
        [Fact]
        public async Task GetBranch()
        {
            const int projectId = 1;
            const int branchId = 2;
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/projects/{projectId}/branches/{branchId}";
            
            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.Branches.Response_Common_Single)
                });
            
            var executor = new BranchesApiExecutor(mockClient.Object);
            Branch response = await executor.GetBranch(projectId, branchId);
            
            Assert_Branch(response);
        }
        
        [Fact]
        public async Task DeleteBranch()
        {
            const int projectId = 1;
            const int branchId = 2;
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/projects/{projectId}/branches/{branchId}";
            
            mockClient
                .Setup(client => client.SendDeleteRequest(url, null))
                .ReturnsAsync(HttpStatusCode.NoContent);
            
            var executor = new BranchesApiExecutor(mockClient.Object);
            await executor.DeleteBranch(projectId, branchId);
        }
        
        [Fact]
        public async Task EditBranch()
        {
            const int projectId = 1;
            const int branchId = 2;
            
            var patches = new[]
            {
                new BranchPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = BranchPatchPath.Name,
                    Value = "develop-master"
                },
                new BranchPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = BranchPatchPath.Title,
                    Value = "Master branch"
                }
            };
            
            string actualRequestJson = JsonConvert.SerializeObject(patches, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(Core.Resources.Branches.Request_EditBranch);
            Assert.Equal(expectedRequestJson, actualRequestJson);
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/projects/{projectId}/branches/{branchId}";
            
            mockClient
                .Setup(client => client.SendPatchRequest(url, patches, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.Branches.Response_Common_Single)
                });
            
            var executor = new BranchesApiExecutor(mockClient.Object);
            Branch response = await executor.EditBranch(projectId, branchId, patches);
            
            Assert_Branch(response);
        }
        
        private static void Assert_Branch(Branch? branch)
        {
            ArgumentNullException.ThrowIfNull(branch);
            
            Assert.Equal(34, branch.Id);
            Assert.Equal(2, branch.ProjectId);
            Assert.Equal("develop-master", branch.Name);
            Assert.Equal("Master branch", branch.Title);
            Assert.Equal(DateTimeOffset.Parse("2019-09-16T13:48:04+00:00"), branch.CreatedAt);
            Assert.Equal(DateTimeOffset.Parse("2019-09-19T13:25:27+00:00"), branch.UpdatedAt);
        }
    }
}