
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Core;
using Crowdin.Api.StyleGuides;

namespace Crowdin.Api.UnitTesting.Tests.StyleGuides
{
    public class StyleGuidesApiTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task ListStyleGuides()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();

            mockClient
                .Setup(client => client.SendGetRequest("/style-guides", queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.StyleGuides.StyleGuidesList)
                });

            var executor = new StyleGuidesApiExecutor(mockClient.Object);
            ResponseList<StyleGuide> response = await executor.ListStyleGuides();

            Assert.Single(response.Data);
            Assert_StyleGuide(response.Data[0]);
        }

        [Fact]
        public async Task AddStyleGuide()
        {
            var request = new AddStyleGuideRequest
            {
                Name = "My Style Guide",
                StorageId = 61
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(Resources.StyleGuides.AddStyleGuideRequest);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPostRequest("/style-guides", request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(Resources.StyleGuides.AddStyleGuideResponse)
                });

            var executor = new StyleGuidesApiExecutor(mockClient.Object);
            StyleGuide response = await executor.AddStyleGuide(request);

            Assert.NotNull(response);
            Assert.Equal(1, response.Id);
            Assert.Equal("My Style Guide", response.Name);
        }

        [Fact]
        public async Task GetStyleGuide()
        {
            const long styleGuideId = 1;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendGetRequest($"/style-guides/{styleGuideId}", null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.StyleGuides.StyleGuide)
                });

            var executor = new StyleGuidesApiExecutor(mockClient.Object);
            StyleGuide response = await executor.GetStyleGuide(styleGuideId);

            Assert_StyleGuide(response);
        }

        [Fact]
        public async Task EditStyleGuide()
        {
            const long styleGuideId = 1;

            var patches = new[]
            {
                new StyleGuidePatch
                {
                    Operation = PatchOperation.Replace,
                    Path = StyleGuidePatchPath.Name,
                    Value = "New Style Guide Name"
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(patches, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(Resources.StyleGuides.EditStyleGuideRequest);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPatchRequest($"/style-guides/{styleGuideId}", patches, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.StyleGuides.StyleGuide)
                });

            var executor = new StyleGuidesApiExecutor(mockClient.Object);
            StyleGuide response = await executor.EditStyleGuide(styleGuideId, patches);

            Assert_StyleGuide(response);
        }

        [Fact]
        public async Task DeleteStyleGuide()
        {
            const long styleGuideId = 1;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendDeleteRequest($"/style-guides/{styleGuideId}", null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            var executor = new StyleGuidesApiExecutor(mockClient.Object);
            await executor.DeleteStyleGuide(styleGuideId);

            mockClient.Verify(client => client.SendDeleteRequest($"/style-guides/{styleGuideId}", null), Times.Once);
        }

        private static void Assert_StyleGuide(StyleGuide styleGuide)
        {
            Assert.NotNull(styleGuide);
            Assert.Equal(1, styleGuide.Id);
            Assert.Equal("My Style Guide", styleGuide.Name);
            Assert.Equal("Use formal language", styleGuide.AiInstructions);
            Assert.Equal(6, styleGuide.UserId);
            Assert.Equal(new[] { "en", "uk" }, styleGuide.LanguageIds);
            Assert.Equal(new long[] { 1, 2 }, styleGuide.ProjectIds);
            Assert.False(styleGuide.IsShared);
            Assert.Equal("https://crowdin.com/style-guide/1", styleGuide.WebUrl);
            Assert.Equal("https://storage.crowdin.com/style-guide-1.pdf", styleGuide.DownloadLink);
            Assert.Equal(DateTimeOffset.Parse("2023-09-20T14:05:50+00:00"), styleGuide.CreatedAt);
            Assert.Equal(DateTimeOffset.Parse("2023-09-20T14:05:50+00:00"), styleGuide.UpdatedAt);
        }
    }
}
