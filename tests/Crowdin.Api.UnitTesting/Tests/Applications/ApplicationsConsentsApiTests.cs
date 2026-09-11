
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Applications;
using Crowdin.Api.Core;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Crowdin.Api.UnitTesting.Tests.Applications
{
    public class ApplicationsConsentsApiTests
    {
        private const long consentId = 12;
        private const string applicationIdentifier = "example-application";

        [Fact]
        public async Task ListApplicationConsents()
        {
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging(10, 2);
            queryParams.Add("identifier", applicationIdentifier);
            queryParams.Add("orderBy", "createdAt desc");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest("/applications/consents", queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.Applications.ListApplicationConsent_Response)
                });

            var executor = new ApplicationsApiExecutor(mockClient.Object);
            ResponseList<ApplicationConsent> response = await executor.ListApplicationConsents(
                applicationIdentifier,
                10,
                2,
                new[]
                {
                    new SortingRule
                    {
                        Field = "createdAt",
                        Order = SortingOrder.Descending
                    }
                });

            Assert.NotNull(response);
            Assert.Single(response.Data);
            Assert_ApplicationConsent(response.Data[0]);
            Assert.Equal(10, response.Pagination!.Limit);
            Assert.Equal(2, response.Pagination.Offset);
        }

        [Fact]
        public async Task AddApplicationConsent()
        {
            var request = new AddApplicationConsentRequest
            {
                Identifier = applicationIdentifier,
                InstalledBy = consentId,
                Status = ApplicationConsentStatus.Granted,
                Scopes = new[] { "project", "tm" }
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, TestUtils.CreateJsonSerializerOptions());
            string expectedRequestJson = TestUtils.CompactJson(Resources.Applications.AddApplicationConsent_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendPostRequest("/applications/consents", request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(Resources.Applications.GetApplicationConsent_Response)
                });

            var executor = new ApplicationsApiExecutor(mockClient.Object);
            ApplicationConsent response = await executor.AddApplicationConsent(request);

            Assert_ApplicationConsent(response);
        }

        [Fact]
        public async Task EditApplicationConsent()
        {
            var patches = new[]
            {
                new ApplicationConsentPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = ApplicationConsentPatchPath.Status,
                    Value = ApplicationConsentStatus.Denied
                },
                new ApplicationConsentPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = ApplicationConsentPatchPath.Scopes,
                    Value = new[] { "project" }
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(patches, TestUtils.CreateJsonSerializerOptions());
            string expectedRequestJson = TestUtils.CompactJson(Resources.Applications.EditApplicationConsent_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            string url = $"/applications/consents/{consentId}";
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendPatchRequest(url, patches, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.Applications.GetApplicationConsent_Response)
                });

            var executor = new ApplicationsApiExecutor(mockClient.Object);
            ApplicationConsent response = await executor.EditApplicationConsent(consentId, patches);

            Assert_ApplicationConsent(response);
        }

        [Fact]
        public async Task DeleteApplicationConsent()
        {
            string url = $"/applications/consents/{consentId}";
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendDeleteRequest(url, null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            var executor = new ApplicationsApiExecutor(mockClient.Object);
            await executor.DeleteApplicationConsent(consentId);
        }

        private static void Assert_ApplicationConsent(ApplicationConsent? consent)
        {
            Assert.NotNull(consent);
            Assert.Equal(consentId, consent!.Id);
            Assert.Equal(applicationIdentifier, consent.Identifier);
            Assert.Equal("My App", consent.Name);
            Assert.Equal(ApplicationConsentStatus.Granted, consent.Status);
            Assert.Equal(new[] { "project", "tm" }, consent.Scopes);
            Assert.Equal(DateTimeOffset.Parse("2026-07-24T10:00:00+00:00"), consent.CreatedAt);
            Assert.Equal(DateTimeOffset.Parse("2026-07-24T10:00:00+00:00"), consent.UpdatedAt);

            Assert.NotNull(consent.InstalledBy);
            Assert.Equal(12, consent.InstalledBy!.Id);
            Assert.Equal("john_smith", consent.InstalledBy.Username);
            Assert.Equal("John Smith", consent.InstalledBy.FullName);
            Assert.Equal(string.Empty, consent.InstalledBy.AvatarUrl);
        }
    }
}
