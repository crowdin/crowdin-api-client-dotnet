
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using Crowdin.Api.Screenshots;
using Crowdin.Api.Tests.Core;
using Crowdin.Api.Tests.Core.Resources;

using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Crowdin.Api.Tests.Screenshots
{
    public class TagsApiTests
    {
        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();
        
        [Fact]
        public async Task ReplaceTags()
        {
            const int projectId = 1;
            const int screenshotId = 2;

            var request = new []
            {
                new AddTagRequest
                {
                    StringId = 1,
                    Position = new Position
                    {
                        X = 1,
                        Y = 2,
                        Width = 3,
                        Height = 4
                    }
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Screenshots_Tags.ReplaceTags_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            var url = $"/projects/{projectId}/screenshots/{screenshotId}/tags";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPutRequest(url, request))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = null
                });

            var executor = new ScreenshotsApiExecutor(mockClient.Object);
            await executor.ReplaceTags(projectId, screenshotId, request);
        }

        [Fact]
        public async Task ReplaceTags_AutoTag()
        {
            const int projectId = 1;
            const int screenshotId = 2;

            var request = new AutoTagReplaceTagsRequest
            {
                AutoTag = true
            };
            
            string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Screenshots_Tags.ReplaceTags_AutoTag_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);
            
            var url = $"/projects/{projectId}/screenshots/{screenshotId}/tags";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPutRequest(url, request))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = null
                });

            var executor = new ScreenshotsApiExecutor(mockClient.Object);
            await executor.ReplaceTags(projectId, screenshotId, request);
        }
    }
}