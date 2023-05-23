
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Core;
using Crowdin.Api.Tests.Core;
using Crowdin.Api.Tests.Core.Resources;
using Crowdin.Api.Webhooks;
using Crowdin.Api.Webhooks.Organization;

using AddOrgWebhookRequest = Crowdin.Api.Webhooks.Organization.AddWebhookRequest;

namespace Crowdin.Api.Tests.Webhooks.Organization
{
    public class OrganizationWebhooksApiTests
    {
        private const string BaseUrl = "/webhooks";
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();
        
        [Fact]
        public async Task ListWebhooks()
        {
            const int limit = 20;
            const int offset = 10;
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging(limit, offset);

            mockClient
                .Setup(client => client.SendGetRequest(BaseUrl, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Webhooks_Organization.ListWebhooks_Response)
                });

            var executor = new OrganizationWebhooksApiExecutor(mockClient.Object);
            ResponseList<OrganizationWebhookResource>? response = await executor.ListWebhooks(limit, offset);
            
            Assert.NotNull(response);
            Assert_SingleWebhook(response.Data?.Single());
        }

        [Fact]
        public async Task AddWebhook()
        {
            var request = new AddOrgWebhookRequest
            {
                Name = "Proofread",
                Url = "https://webhook.site/1c20d9b5-6e6a-4522-974d-9da7ea7595c9",
                Events = new[]
                {
                    OrganizationEventType.ProjectCreated
                },
                RequestType = RequestType.POST,
                IsActive = true,
                BatchingEnabled = true,
                ContentType = ContentType.ApplicationJson,
                Headers = new Dictionary<string, string>()
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(Webhooks_Organization.AddWebhook_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPostRequest(BaseUrl, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(Webhooks_Organization.CommonResponses_SingleWebhook)
                });

            var executor = new OrganizationWebhooksApiExecutor(mockClient.Object);
            OrganizationWebhookResource? response = await executor.AddWebhook(request);
            
            Assert_SingleWebhook(response);
        }

        [Fact]
        public async Task GetWebhook()
        {
            const int organizationWebhookId = 1;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/webhooks/{organizationWebhookId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Webhooks_Organization.CommonResponses_SingleWebhook)
                });

            var executor = new OrganizationWebhooksApiExecutor(mockClient.Object);
            OrganizationWebhookResource? response = await executor.GetWebhook(organizationWebhookId);
            
            Assert_SingleWebhook(response);
        }

        [Fact]
        public async Task DeleteWebhook()
        {
            const int organizationWebhookId = 1;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/webhooks/{organizationWebhookId}";

            mockClient
                .Setup(client => client.SendDeleteRequest(url, null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            var executor = new OrganizationWebhooksApiExecutor(mockClient.Object);
            await executor.DeleteWebhook(organizationWebhookId);
        }

        [Fact]
        public async Task EditWebhook()
        {
            const int organizationWebhookId = 1;

            var patches = new[]
            {
                new OrganizationWebhookPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = OrganizationWebhookPatchPath.Name,
                    Value = "Proofread"
                },
                new OrganizationWebhookPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = OrganizationWebhookPatchPath.Events,
                    Value = new[]
                    {
                        OrganizationEventType.ProjectCreated,
                        OrganizationEventType.ProjectDeleted
                    }
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(patches, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(Webhooks_Organization.EditWebhook_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/webhooks/{organizationWebhookId}";

            mockClient
                .Setup(client => client.SendPatchRequest(url, patches, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Webhooks_Organization.CommonResponses_SingleWebhook)
                });

            var executor = new OrganizationWebhooksApiExecutor(mockClient.Object);
            OrganizationWebhookResource? response = await executor.EditWebhook(organizationWebhookId, patches);
            
            Assert_SingleWebhook(response);
        }

        private static void Assert_SingleWebhook(OrganizationWebhookResource? webhook)
        {
            Assert.NotNull(webhook);
            
            Assert.Equal(4, webhook!.Id);
            Assert.Equal("Proofread", webhook.Name);
            Assert.StartsWith("https://", webhook.Url!);

            OrganizationEventType? singleEvent = webhook.Events.Single();
            Assert.Equal(OrganizationEventType.ProjectCreated, singleEvent);
            
            Assert.True(webhook.IsActive);
            Assert.True(webhook.BatchingEnabled);
            Assert.Equal(RequestType.GET, webhook.RequestType);
            Assert.Equal(ContentType.ApplicationJson, webhook.ContentType);
            Assert.Equal(DateTimeOffset.Parse("2019-09-23T09:19:07+00:00"), webhook.CreatedAt);
            Assert.Equal(DateTimeOffset.Parse("2019-09-23T09:19:07+00:00"), webhook.UpdatedAt);
        }
    }
}