using System.Collections.Generic;
using Crowdin.Api.SourceFiles;
using Crowdin.Api.Tests.Core;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Crowdin.Api.Core;
using System.Net.Http;
using System.Net;
using Xunit;
using Moq;

namespace Crowdin.Api.Tests.SourceFiles {
    public class DirectoriesTests {
        private const int projectId = 1;
        private const int directoryId = 2;
        private const int branchId = 3;

        [Fact]
        public async Task ListDirectories() {
            var mockResponseObject = JObject.Parse(@"
                {
                  ""data"": [
                    {
                      ""data"": {
                        ""id"": 4,
                        ""projectId"": 2,
                        ""branchId"": 34,
                        ""directoryId"": null,
                        ""name"": ""main"",
                        ""title"": ""<Description materials>"",
                        ""exportPattern"": ""/localization/%locale%/%file_name%"",
                        ""priority"": ""normal"",
                        ""createdAt"": ""2019-09-19T14:14:00+00:00"",
                        ""updatedAt"": ""2019-09-19T14:14:00+00:00""
                      }
                    }
                  ],
                  ""pagination"": {
                    ""offset"": 0,
                    ""limit"": 25
                  }
                }
            ");

            var message = new HttpResponseMessage();
            var headers = message.Headers;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            DirectoriesListParams directoriesListParams = new();
            IDictionary<string, string> queryParams = directoriesListParams.ToQueryParams();

            mockClient
                .Setup(client => client.SendGetRequest($"/projects/{projectId}/directories", queryParams))
                .ReturnsAsync(new CrowdinApiResult {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = mockResponseObject,
                    Headers = headers
                });

            SourceFilesApiExecutor executor = new(mockClient.Object);
            var result = await executor.ListDirectories(projectId);

            Assert.NotNull(result);
            Assert.IsType<ResponseList<Directory>>(result);
            Assert.Single(result.Data);
            Assert.Equal("main", result.Data[0].Name);
        }

        [Fact]
        public async Task AddDirectory() {
            var mockResponseObject = JObject.Parse(@"
                {
                  ""data"": {
                    ""id"": 4,
                    ""projectId"": 2,
                    ""branchId"": 34,
                    ""directoryId"": null,
                    ""name"": ""main"",
                    ""title"": ""<Description materials>"",
                    ""exportPattern"": ""/localization/%locale%/%file_name%"",
                    ""priority"": ""normal"",
                    ""createdAt"": ""2019-09-19T14:14:00+00:00"",
                    ""updatedAt"": ""2019-09-19T14:14:00+00:00""
                  }
                }
            ");

            var request = new AddDirectoryRequest() {
                Name = "main",
                BranchId = 34,
                DirectoryId = 2,
                Title = "<Description materials>",
                ExportPattern = "/localization/%locale%/%file_name%",
                Priority = Priority.Normal
            };

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPostRequest($"/projects/{projectId}/directories", request, null))
                .ReturnsAsync(new CrowdinApiResult {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = mockResponseObject
                });

            SourceFilesApiExecutor executor = new(mockClient.Object);
            var result = await executor.AddDirectory(projectId, request);

            Assert.NotNull(result);
            Assert.IsType<Directory>(result);
            Assert.Equal("main", result.Name);
        }

        [Fact]
        public async Task GetDirectory() {
            var mockResponseObject = JObject.Parse(@"
                {
                  ""data"": {
                    ""id"": 4,
                    ""projectId"": 2,
                    ""branchId"": 34,
                    ""directoryId"": null,
                    ""name"": ""main"",
                    ""title"": ""<Description materials>"",
                    ""exportPattern"": ""/localization/%locale%/%file_name%"",
                    ""priority"": ""normal"",
                    ""createdAt"": ""2019-09-19T14:14:00+00:00"",
                    ""updatedAt"": ""2019-09-19T14:14:00+00:00""
                  }
                }
            ");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendGetRequest($"/projects/{projectId}/directories/{directoryId}", null))
                .ReturnsAsync(new CrowdinApiResult {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = mockResponseObject
                });

            SourceFilesApiExecutor executor = new(mockClient.Object);
            var result = await executor.GetDirectory(projectId, directoryId);

            Assert.NotNull(result);
            Assert.IsType<Directory>(result);
            Assert.Equal("main", result.Name);
        }

        [Fact]
        public async Task DeleteDirectory_ShouldFail() {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendDeleteRequest($"/projects/{projectId}/directories/{directoryId}", null))
                .ReturnsAsync(HttpStatusCode.Unauthorized);

            SourceFilesApiExecutor executor = new(mockClient.Object);

            await Assert.ThrowsAsync<CrowdinApiException>(async () => await executor.DeleteDirectory(projectId, branchId));
        }

        [Fact]
        public async Task DeleteDirectory() {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendDeleteRequest($"/projects/{projectId}/directories/{directoryId}", null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            SourceFilesApiExecutor executor = new(mockClient.Object);

            try {
                await executor.DeleteDirectory(projectId, directoryId);
            } catch (CrowdinApiException e) {
                Assert.True(false, e.Message);
            }

            Assert.True(true);
        }

        [Fact]
        public async Task EditDirectory() {
            var mockResponseObject = JObject.Parse(@"
                {
                  ""data"": {
                    ""id"": 4,
                    ""projectId"": 2,
                    ""branchId"": 34,
                    ""directoryId"": null,
                    ""name"": ""main"",
                    ""title"": ""<Description materials>"",
                    ""exportPattern"": ""/localization/%locale%/%file_name%"",
                    ""priority"": ""normal"",
                    ""createdAt"": ""2019-09-19T14:14:00+00:00"",
                    ""updatedAt"": ""2019-09-19T14:14:00+00:00""
                  }
                }
            ");

            var patch = new List<DirectoryPatch> {
                new DirectoryPatch() {
                    Operation = PatchOperation.Replace,
                    Path = DirectoryPatchPath.BranchId,
                    Value = 34
                }
            };

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPatchRequest($"/projects/{projectId}/directories/{directoryId}", patch, null))
                .ReturnsAsync(new CrowdinApiResult {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = mockResponseObject
                });

            SourceFilesApiExecutor executor = new(mockClient.Object);
            var result = await executor.EditDirectory(projectId, directoryId, patch);

            Assert.NotNull(result);
            Assert.IsType<Directory>(result);
            Assert.Equal(34, result.BranchId);
        }
    }
}
