
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using Crowdin.Api.Screenshots;
using Crowdin.Api.Tests.Core;
using Crowdin.Api.Tests.Core.Resources;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Crowdin.Api.Tests.Screenshots
{
    public class TagsApiTests
    {
        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task AddTag()
        {
            const int projectId = 1;
            const int screenshotId = 2;
            
            var requests = new[]
            {
                new AddTagRequest
                {
                    StringId = 328525,
                    Position = new Position
                    {
                        X = 10,
                        Y = 20,
                        Height = 10,
                        Width = 10
                    }
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(requests, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Screenshots_Tags.AddTag_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/screenshots/{screenshotId}/tags";

            mockClient
                .Setup(client => client.SendPostRequest(url, requests, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Screenshots_Tags.AddTag_Response)
                });

            var executor = new ScreenshotsApiExecutor(mockClient.Object);
            ResponseList<Tag> response = await executor.AddTag(projectId, screenshotId, requests);
            
            Assert.NotNull(response);

            Tag? tag = response.Data?.FirstOrDefault();
            Assert.NotNull(tag);
            Assert.Equal(98, tag!.Id);
            Assert.Equal(2, tag.ScreenshotId);
            Assert.Equal(2822, tag.StringId);
            Assert.Equal(DateTimeOffset.Parse("2019-09-23T09:35:31+00:00"), tag.CreatedAt);

            Position? position = tag.Position;
            Assert.NotNull(position);
            Assert.Equal(474, position.X);
            Assert.Equal(147, position.Y);
            Assert.Equal(99, position.Height);
            Assert.Equal(490, position.Width);
        }
        
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