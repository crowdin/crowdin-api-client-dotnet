
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using Crowdin.Api.Tests.Core;
using Crowdin.Api.Webhooks;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Crowdin.Api.Tests.Webhooks
{
    public class WebhooksApiTests
    {
        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task AddWebhook()
        {
            const int projectId = 2;

            var request = new AddWebhookRequest
            {
                Name = "Proofread",
                Url = "https://webhook.site/1c20d9b5-6e6a-4522-974d-9da7ea7595c9",
                Events = new[]
                {
                    EventType.FileApproved,
                    EventType.TranslationUpdated,
                    EventType.SuggestionDeleted
                },
                RequestType = RequestType.POST,
                IsActive = true,
                BatchingEnabled = true,
                ContentType = ContentType.ApplicationJson
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Core.Resources.Webhooks.AddWebhook_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/webhooks";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(Core.Resources.Webhooks.AddWebhook_Response)
                });

            var executor = new WebhooksApiExecutor(mockClient.Object);
            Webhook response = await executor.AddWebhook(projectId, request);
            
            Assert.NotNull(response);
            Assert.Equal(request.Events, response.Events);
            Assert.Equal(RequestType.GET, response.RequestType);
            Assert.Equal(ContentType.ApplicationJson, response.ContentType);
        }

        [Fact]
        public async Task EditWebhook()
        {
            const int projectId = 2;
            const int webhookId = 4;

            const string newName = "Proofread";
            const RequestType newRequestType = RequestType.GET;

            var patches = new[]
            {
                new WebhookPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = WebhookPatchPath.Name,
                    Value = newName
                },
                new WebhookPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = WebhookPatchPath.RequestType,
                    Value = newRequestType
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(patches, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Core.Resources.Webhooks.EditWebhook_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/webhooks/{webhookId}";

            mockClient
                .Setup(client => client.SendPatchRequest(url, patches, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.Webhooks.EditWebhook_Response)
                });

            var executor = new WebhooksApiExecutor(mockClient.Object);
            Webhook response = await executor.EditWebhook(projectId, webhookId, patches);
            
            Assert.NotNull(response);
            Assert.Equal(newName, response.Name);
            Assert.Equal(newRequestType, response.RequestType);
        }
    }
}