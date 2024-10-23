
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Crowdin.Api.Core;
using Crowdin.Api.Screenshots;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Crowdin.Api.UnitTesting.Tests.Screenshots
{
    public class ScreenshotsApiTests
    {
        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task AddScreenshot()
        {
            const int projectId = 1;

            var request = new AddScreenshotRequest
            {
                StorageId = 71,
                Name = "translate_with_siri.jpg",
                AutoTag = true,
                LabelIds = new[]
                {
                    0, 1
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Resources.Screenshots.AddScreenshot_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            var url = $"/projects/{projectId}/screenshots";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(Resources.Screenshots.AddScreenshot_Response)
                });

            var executor = new ScreenshotsApiExecutor(mockClient.Object);
            Screenshot response = await executor.AddScreenshot(projectId, request);

            Assert.NotNull(response);
            Assert.Single(response.Tags);
            Assert.Equal(2, response.LabelIds.Length);
            Assert.Contains(0, response.LabelIds);
            Assert.Contains(1, response.LabelIds);
        }

        [Fact]
        public async Task EditScreenshot()
        {
            const int projectId = 1;
            const int screenshotId = 2;

            var patches = new[]
            {
                new ScreenshotPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = ScreenshotPatchPath.LabelIds,
                    Value = new[] { 2, 3, 4 }
                },
            };

            var url = $"/projects/{projectId}/screenshots/{screenshotId}";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPatchRequest(url, patches, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.Screenshots.EditScreenshot_Response)
                });

            var executor = new ScreenshotsApiExecutor(mockClient.Object);
            Screenshot? response = await executor.EditScreenshot(projectId, screenshotId, patches);
            Assert.NotNull(response);
            Assert.Equal(3, response.LabelIds.Length);
            Assert.Contains(2, response.LabelIds);
            Assert.Contains(3, response.LabelIds);
            Assert.Contains(4, response.LabelIds);
        }

        [Fact]
        public async Task GetScreenshot()
        {
            int projectId = 1;
            int screenshotId = 2;

            var url = $"/projects/{projectId}/screenshots/{screenshotId}";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.Screenshots.GetScreenshot_Response)
                });

            var executor = new ScreenshotsApiExecutor(mockClient.Object);
            Screenshot response = await executor.GetScreenshot(projectId, screenshotId);
            Assert.NotNull(response);
            Assert.Equal(2, response.LabelIds.Length);
            Assert.Contains(0, response.LabelIds);
            Assert.Contains(1, response.LabelIds);
        }

        [Fact]
        public async Task ListScreenshots()
        {
            const int projectId = 1;

            var url = $"/projects/{projectId}/screenshots";
            var queryParams = new Dictionary<string, string>
            {
                { "limit", "25" },
                { "offset", "0" },
                { "orderBy", "createdAt desc,name asc" },
                { "stringIds", "1,2,3,2822" }
            };

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.Screenshots.ListScreenshots_Response)
                });

            var executor = new ScreenshotsApiExecutor(mockClient.Object);
            var sortingRules = new SortingRule[] {
                new SortingRule() { Field = "createdAt", Order = SortingOrder.Descending },
                new SortingRule() { Field = "name", Order = SortingOrder.Ascending }
            };
            var stringIds = new int[] { 1, 2, 3, 2822 };
            var response = await executor.ListScreenshots(projectId, 25, 0, sortingRules, stringIds);

            Assert.NotNull(response);

            Assert.Equal(25, response.Pagination?.Limit);
            Assert.Equal(0, response.Pagination?.Offset);

            Assert.Single(response.Data);

            Assert.Single(response.Data[0].Tags);
            Assert.Equal(2822, response.Data[0].Tags[0].StringId);
        }
    }
}