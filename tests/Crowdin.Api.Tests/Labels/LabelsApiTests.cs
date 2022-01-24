
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using Crowdin.Api.Labels;
using Crowdin.Api.SourceStrings;
using Crowdin.Api.Tests.Core;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Crowdin.Api.Tests.Labels
{
    public class LabelsApiTests
    {
        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();
        
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
            string expectedRequestJson = TestUtils.CompactJson(Core.Resources.Labels.AddLabel_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            var url = $"/projects/{projectId}/labels";
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(Core.Resources.Labels.AddLabel_Response)
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
            string expectedRequestJson = TestUtils.CompactJson(Core.Resources.Labels.AssignLabelToStrings_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            var url = $"/projects/{projectId}/labels/{labelId}/strings";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.Labels.AssignLabelToStrings_Response)
                });

            var executor = new LabelsApiExecutor(mockClient.Object);
            ResponseList<SourceString> response = await executor.AssignLabelToStrings(projectId, labelId, request);
            
            Assert.NotNull(response);
            Assert.Single(response.Data);
            Assert.Equal(labelId, response.Data[0].LabelIds[0]);
        }
    }
}