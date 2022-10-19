using System.Collections.Generic;
using Crowdin.Api.SourceFiles;
using Crowdin.Api.Tests.Core;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Crowdin.Api.Core;
using System.Net;
using Xunit;
using Moq;

namespace Crowdin.Api.Tests.SourceFiles {
    public class BranchesTests {
        private const int projectId = 1;
        private const int branchId = 2;

        [Fact]
        public async Task ListBranches() {
            var mockResponseObject = JObject.Parse(@"
                {
                  ""data"": [
                    {
                      ""data"": {
                        ""id"": 34,
                        ""projectId"": 2,
                        ""name"": ""develop-master"",
                        ""title"": ""Master branch"",
                        ""exportPattern"": ""%three_letters_code%"",
                        ""priority"": ""normal"",
                        ""createdAt"": ""2019-09-16T13:48:04+00:00"",
                        ""updatedAt"": ""2019-09-19T13:25:27+00:00""
                      }
                    }
                  ],
                  ""pagination"": {
                    ""offset"": 0,
                    ""limit"": 25
                  }
                }");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();

            mockClient
                .Setup(client => client.SendGetRequest($"/projects/{projectId}/branches", queryParams))
                .ReturnsAsync(new CrowdinApiResult {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = mockResponseObject
                });

            SourceFilesApiExecutor executor = new(mockClient.Object);
            var result = await executor.ListBranches(projectId);

            Assert.NotNull(result);
            Assert.IsType<ResponseList<Branch>>(result);
            Assert.Single(result.Data);
        }

        [Fact]
        public async Task AddBranch() {
            var mockResponseObject = JObject.Parse(@"
                {
                  ""data"": {
                    ""id"": 34,
                    ""projectId"": 2,
                    ""name"": ""develop-master"",
                    ""title"": ""Master branch"",
                    ""exportPattern"": ""%three_letters_code%"",
                    ""priority"": ""normal"",
                    ""createdAt"": ""2019-09-16T13:48:04+00:00"",
                    ""updatedAt"": ""2019-09-19T13:25:27+00:00""
                  }
                }
            ");

            var request = new AddBranchRequest() {
                Name = "develop-master",
                Title = "Master branch",
                ExportPattern = "%three_letters_code%",
                Priority = Priority.Normal
            };

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPostRequest($"/projects/{projectId}/branches", request, null))
                .ReturnsAsync(new CrowdinApiResult {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = mockResponseObject
                });

            SourceFilesApiExecutor executor = new(mockClient.Object);
            var result = await executor.AddBranch(projectId, request);

            Assert.NotNull(result);
            Assert.IsType<Branch>(result);
            Assert.Equal("develop-master", result.Name);
        }

        [Fact]
        public async Task GetBranch() {
            var mockResponseObject = JObject.Parse(@"
                {
                  ""data"": {
                    ""id"": 34,
                    ""projectId"": 2,
                    ""name"": ""develop-master"",
                    ""title"": ""Master branch"",
                    ""exportPattern"": ""%three_letters_code%"",
                    ""priority"": ""normal"",
                    ""createdAt"": ""2019-09-16T13:48:04+00:00"",
                    ""updatedAt"": ""2019-09-19T13:25:27+00:00""
                  }
                }
            ");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendGetRequest($"/projects/{projectId}/branches/{branchId}", null))
                .ReturnsAsync(new CrowdinApiResult {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = mockResponseObject
                });

            SourceFilesApiExecutor executor = new(mockClient.Object);
            var result = await executor.GetBranch(projectId, branchId);

            Assert.NotNull(result);
            Assert.IsType<Branch>(result);
            Assert.Equal("develop-master", result.Name);
        }

        [Fact]
        public async Task DeleteBranch_ShouldFail() {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendDeleteRequest($"/projects/{projectId}/branches/{branchId}", null))
                .ReturnsAsync(HttpStatusCode.Unauthorized);

            SourceFilesApiExecutor executor = new(mockClient.Object);

            await Assert.ThrowsAsync<CrowdinApiException>(async () => await executor.DeleteBranch(projectId, branchId));
        }

        [Fact]
        public async Task DeleteBranch() {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendDeleteRequest($"/projects/{projectId}/branches/{branchId}", null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            SourceFilesApiExecutor executor = new(mockClient.Object);

            try {
                await executor.DeleteBranch(projectId, branchId);
            } catch (CrowdinApiException e) {
                Assert.True(false, e.Message);
            }

            Assert.True(true);
        }

        [Fact]
        public async Task EditBranch() {
            var mockResponseObject = JObject.Parse(@"
                {
                    ""data"": {
                        ""id"": 34,
                        ""projectId"": 2,
                        ""name"": ""develop-master"",
                        ""title"": ""Master branch"",
                        ""exportPattern"": ""%three_letters_code%"",
                        ""priority"": ""normal"",
                        ""createdAt"": ""2019-09-16T13:48:04+00:00"",
                        ""updatedAt"": ""2019-09-19T13:25:27+00:00""
                    }
                }
            ");

            var patch = new List<BranchPatch> {
                new BranchPatch() {
                    Operation = PatchOperation.Replace,
                    Path = BranchPatchPath.Name,
                    Value = "develop-master"
                }
            };

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPatchRequest($"/projects/{projectId}/branches/{branchId}", patch, null))
                .ReturnsAsync(new CrowdinApiResult {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = mockResponseObject
                });

            SourceFilesApiExecutor executor = new(mockClient.Object);
            var result = await executor.EditBranch(projectId, branchId, patch);

            Assert.NotNull(result);
            Assert.IsType<Branch>(result);
            Assert.Equal("develop-master", result.Name);
        }

    }
}
