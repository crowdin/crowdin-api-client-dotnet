
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using Crowdin.Api.Labels;
using Crowdin.Api.Screenshots;
using Crowdin.Api.SourceStrings;
using Crowdin.Api.Tests.Testing;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Crowdin.Api.Tests.Labels
{
    public class LabelsApiTests
    {
        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();
        
        [Theory]
        [InlineData(null)]
        [InlineData(true)]
        [InlineData(false)]
        public async Task ListLabels(bool? isSystem)
        {
            const int projectId = 1;
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/labels";

            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();

            if (isSystem.HasValue)
            {
                queryParams.Add("isSystem", isSystem.Value.ToString().ToLower());
            }

            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Testing.Resources.Labels.ListLabels_Response)
                });
            
            var executor = new LabelsApiExecutor(mockClient.Object);
            ResponseList<Label>? response = await executor.ListLabels(projectId, isSystem: isSystem);
            
            Assert.NotNull(response);
            Assert.Single(response.Data);
            
            Assert.Equal(34, response.Data.First().Id);
            Assert.Equal("main", response.Data.First().Title);
        }
        
        [Fact]
        public async Task AddLabel()
        {
            const int projectId = 1;
            const string newTitle = "main";

            var request = new AddLabelRequest
            {
                Title = newTitle
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Testing.Resources.Labels.AddLabel_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            var url = $"/projects/{projectId}/labels";
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(Testing.Resources.Labels.AddLabel_Response)
                });

            var executor = new LabelsApiExecutor(mockClient.Object);
            Label response = await executor.AddLabel(projectId, request);
            
            Assert.NotNull(response);
            Assert.Equal(newTitle, response.Title);
        }

        [Fact]
        public async Task AssignLabelToStrings()
        {
            const int projectId = 2;
            const int labelId = 3;

            var stringIds = new[] { 1, 2, 3, 4, 5 };
            var request = new AssignLabelToStringsRequest
            {
                StringIds = stringIds
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Testing.Resources.Labels.AssignLabelToStrings_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            var url = $"/projects/{projectId}/labels/{labelId}/strings";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Testing.Resources.Labels.AssignLabelToStrings_Response)
                });

            var executor = new LabelsApiExecutor(mockClient.Object);
            ResponseList<SourceString> response = await executor.AssignLabelToStrings(projectId, labelId, request);
            
            Assert.NotNull(response);
            Assert.Single(response.Data);
            Assert.Equal(labelId, response.Data[0].LabelIds[0]);
        }

        [Fact]
        public async Task AssignLabelToScreenshots()
        {
            const int projectId = 1;
            const int labelId = 2;

            var request = new AssignLabelToScreenshotsRequest
            {
                ScreenshotIds = new[] { 1, 2, 3 }
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Testing.Resources.Labels.AssignLabelToScreenshots_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/labels/{labelId}/screenshots";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Testing.Resources.Labels.CommonResponses_LabelToScreenshots)
                });

            var executor = new LabelsApiExecutor(mockClient.Object);
            ResponseList<Screenshot>? response = await executor.AssignLabelToScreenshots(projectId, labelId, request);

            Assert_Screenshots(response);
        }

        [Fact]
        public async Task UnassignLabelFromScreenshots()
        {
            const int projectId = 1;
            const int labelId = 2;

            var screenshotIds = new[] { 1, 2, 3 };

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/labels/{labelId}/screenshots";
            
            var queryParams = new Dictionary<string, string>
            {
                { "screenshotIds", string.Join(",", screenshotIds) }
            };

            mockClient
                .Setup(client => client.SendDeleteRequest_FullResult(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Testing.Resources.Labels.CommonResponses_LabelToScreenshots)
                });

            var executor = new LabelsApiExecutor(mockClient.Object);
            ResponseList<Screenshot>? response =
                await executor.UnassignLabelFromScreenshots(projectId, labelId, screenshotIds);
            
            Assert_Screenshots(response);
        }

        private static void Assert_Screenshots(ResponseList<Screenshot>? response)
        {
            Assert.NotNull(response);
            
            Screenshot? screenshot = response!.Data?.Single();
            Assert.NotNull(screenshot);
            Assert.Equal(2, screenshot!.Id);
            Assert.StartsWith("https", screenshot.Url);
            Assert.Equal(0, screenshot.TagsCount);
            Assert.Equal(DateTimeOffset.Parse("2019-09-23T09:29:19+00:00"), screenshot.CreatedAt);
            Assert.Equal(DateTimeOffset.Parse("2019-09-23T09:29:19+00:00"), screenshot.UpdatedAt);

            Size? size = screenshot.Size;
            Assert.NotNull(size);
            Assert.Equal(267, size.Width);
            Assert.Equal(176, size.Height);

            Tag? tag = screenshot.Tags?.Single();
            Assert.NotNull(tag);
            Assert.Equal(98, tag!.Id);
            Assert.Equal(2, tag.ScreenshotId);
            Assert.Equal(2822, tag.StringId);
            Assert.Equal(DateTimeOffset.Parse("2019-09-23T09:35:31+00:00"), tag.CreatedAt);

            Position? tagPosition = tag.Position;
            Assert.NotNull(tagPosition);
            Assert.Equal(474, tagPosition.X);
            Assert.Equal(147, tagPosition.Y);
            Assert.Equal(490, tagPosition.Width);
            Assert.Equal(99, tagPosition.Height);
        }
    }
}