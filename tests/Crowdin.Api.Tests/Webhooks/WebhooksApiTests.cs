
using System;
using System.Collections.Generic;
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
                ContentType = ContentType.ApplicationJson,
                Headers = new Dictionary<string, string>
                {
                    ["apiKey"] = "key"
                },
                Payload = new JObject
                {
                    {
                        "file.approved",
                        new JObject
                        {
                            new JProperty("eventType", "{{event}}")
                        }
                    }
                },
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

        [Fact]
        public async Task GetWebhook()
        {
            const int projectId = 7;
            const int webhookId = 9;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/webhooks/{webhookId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.Webhooks.GetWebhook_Response)
                });

            var executor = new WebhooksApiExecutor(mockClient.Object);
            Webhook? response = await executor.GetWebhook(projectId, webhookId);
            
            Assert.NotNull(response);
            
            Assert.Single(response.Events);
            Assert.Equal(EventType.ProjectApproved, response.Events[0]);
            
            Assert.Single(response.Headers);
            Assert.Equal("secret", response.Headers["x-api-key"]);

            var payload = response.Payload as JObject;
            Assert.NotNull(payload);
            Assert.NotNull(payload!["project.approved"]);
            
            Assert.Equal(ContentType.ApplicationJson, response.ContentType);
            Assert.Equal(RequestType.POST, response.RequestType);
            Assert.Equal(DateTimeOffset.Parse("2023-05-05T10:22:40+02:00"), response.CreatedAt);
            Assert.Equal(DateTimeOffset.Parse("2023-05-05T10:22:40+02:00"), response.UpdatedAt);
        }
    }
}