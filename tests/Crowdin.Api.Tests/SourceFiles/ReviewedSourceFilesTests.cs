using Crowdin.Api.Core;
using Crowdin.Api.SourceFiles;
using Crowdin.Api.Tests.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net;
using Xunit;
using Moq;

namespace Crowdin.Api.Tests.SourceFiles {
    public class ReviewedSourceFilesTests {
        private const int projectId = 1;
        private const int buildId = 2;

        [Fact]
        public async Task ListReviewedSourceFilesBuilds() {
            var mockResponseObject = JObject.Parse(@"
                {
                  ""data"": [
                    {
                      ""data"": {
                        ""id"": 2,
                        ""projectId"": 1,
                        ""status"": ""finished"",
                        ""progress"": 100,
                        ""attributes"": {
                          ""branchId"": 1,
                          ""targetLanguageId"": ""en""
                        }
                      }
                    }
                  ],
                  ""pagination"": {
                    ""offset"": 0,
                    ""limit"": 25
                  }
                }
            ");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();

            mockClient
                .Setup(client => client.SendGetRequest($"/projects/{projectId}/strings/reviewed-builds", queryParams))
                .ReturnsAsync(new CrowdinApiResult {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = mockResponseObject
                });

            SourceFilesApiExecutor executor = new(mockClient.Object);
            var result = await executor.ListReviewedSourceFilesBuilds(projectId, null);

            Assert.NotNull(result);
            Assert.IsType<ResponseList<ReviewedStringBuild>>(result);
            Assert.Single(result.Data);
            Assert.Equal(BuildStatus.Finished, result.Data[0].Status);
        }

        [Fact]
        public async Task BuildReviewedSourceFiles() {
            var mockResponseObject = JObject.Parse(@"
                {
                  ""data"": {
                    ""id"": 2,
                    ""projectId"": 1,
                    ""status"": ""finished"",
                    ""progress"": 100,
                    ""attributes"": {
                      ""branchId"": 1,
                      ""targetLanguageId"": ""en""
                    }
                  }
                }
            ");

            var request = new BuildReviewedSourceFilesRequest() {
                BranchId = 2
            };

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPostRequest($"/projects/{projectId}/strings/reviewed-builds", request, null))
                .ReturnsAsync(new CrowdinApiResult {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = mockResponseObject
                });

            SourceFilesApiExecutor executor = new(mockClient.Object);
            var result = await executor.BuildReviewedSourceFiles(projectId, request);

            Assert.NotNull(result);
            Assert.IsType<ReviewedStringBuild>(result);
            Assert.Equal(BuildStatus.Finished, result.Status);
        }

        [Fact]
        public async Task CheckReviewedSourceFilesBuildStatus() {
            var mockResponseObject = JObject.Parse(@"
                {
                  ""data"": {
                    ""id"": 2,
                    ""projectId"": 1,
                    ""status"": ""finished"",
                    ""progress"": 100,
                    ""attributes"": {
                      ""branchId"": 1,
                      ""targetLanguageId"": ""en""
                    }
                  }
                }
            ");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendGetRequest($"/projects/{projectId}/strings/reviewed-builds/{buildId}", null))
                .ReturnsAsync(new CrowdinApiResult {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = mockResponseObject
                });

            SourceFilesApiExecutor executor = new(mockClient.Object);
            var result = await executor.CheckReviewedSourceFilesBuildStatus(projectId, buildId);

            Assert.NotNull(result);
            Assert.IsType<ReviewedStringBuild>(result);
            Assert.Equal(BuildStatus.Finished, result.Status);
        }

        [Fact]
        public async Task DownloadReviewedSourceFiles() {
            var mockResponseObject = JObject.Parse(@"
                {
                  ""data"": {
                    ""url"": ""https://production-enterprise-importer.downloads.crowdin.com/992000002/2/14.xliff?response-content-disposition=attachment%3B%20filename%3D%22APP.xliff%22&X-Amz-Content-Sha256=UNSIGNED-PAYLOAD&X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAIGJKLQV66ZXPMMEA%2F20190920%2Fus-east-1%2Fs3%2Faws4_request&X-Amz-Date=20190920T093121Z&X-Amz-SignedHeaders=host&X-Amz-Expires=3600&X-Amz-Signature=439ebd69a1b7e4c23e6d17891a491c94f832e0c82e4692dedb35a6cd1e624b62"",
                    ""expireIn"": ""2019-09-20T10:31:21+00:00""
                  }
                }
            ");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendGetRequest($"/projects/{projectId}/strings/reviewed-builds/{buildId}/download", null))
                .ReturnsAsync(new CrowdinApiResult {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = mockResponseObject
                });

            SourceFilesApiExecutor executor = new(mockClient.Object);
            var result = await executor.DownloadReviewedSourceFiles(projectId, buildId);

            Assert.NotNull(result);
            Assert.IsType<DownloadLink>(result);
            Assert.Contains("992000002", result.Url);
        }
    }
}
