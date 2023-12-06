
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using Crowdin.Api.Screenshots;
using Crowdin.Api.Tests.Core;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Crowdin.Api.Tests.Screenshots
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
            string expectedRequestJson = TestUtils.CompactJson(Core.Resources.Screenshots.AddScreenshot_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            var url = $"/projects/{projectId}/screenshots";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(Core.Resources.Screenshots.AddScreenshot_Response)
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
                    JsonObject = JObject.Parse(Core.Resources.Screenshots.EditScreenshot_Response)
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
                    JsonObject = JObject.Parse(Core.Resources.Screenshots.AddScreenshot_Response)
                });

            var executor = new ScreenshotsApiExecutor(mockClient.Object);
            Screenshot response = await executor.GetScreenshot(projectId, screenshotId);
            Assert.NotNull(response);
            Assert.Equal(2, response.LabelIds.Length);
            Assert.Contains(0, response.LabelIds);
            Assert.Contains(1, response.LabelIds);
        }        
    }
}