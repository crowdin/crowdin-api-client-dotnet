
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
                AutoTag = true
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
        }
    }
}