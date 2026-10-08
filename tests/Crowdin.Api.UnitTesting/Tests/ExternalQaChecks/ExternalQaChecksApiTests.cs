using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using Crowdin.Api.ExternalQaChecks;
using Crowdin.Api.UnitTesting.Resources;

using Moq;
using Newtonsoft.Json.Linq;
using Xunit;

using ExternalQaCheckFixtures = Crowdin.Api.UnitTesting.Resources.ExternalQaChecks;

namespace Crowdin.Api.UnitTesting.Tests.ExternalQaChecks
{
    public class ExternalQaChecksApiTests
    {
        [Fact]
        public async Task ListExternalQaChecks()
        {
            var @params = new ExternalQaChecksListParams { ProjectId = 7, Limit = 25, Offset = 0 };
            IDictionary<string, string> queryParams = @params.ToQueryParams();
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest("/external-qa-checks", queryParams))
                .ReturnsAsync(ApiResult("ListExternalQaChecks"));

            var executor = new ExternalQaChecksApiExecutor(mockClient.Object);
            ResponseList<ExternalQaCheck> response = await executor.ListExternalQaChecks(@params);

            Assert.Single(response.Data);
            Assert.Equal(12, response.Data[0].Id);
            Assert.Equal("Term validation", response.Data[0].Name);
            Assert.Equal("Checks terminology usage", response.Data[0].Description);
            Assert.Equal("https://qa.example.test", response.Data[0].Config["endpoint"]!.Value<string>());
            Assert.True(response.Data[0].Config["enabled"]!.Value<bool>());
        }

        [Fact]
        public async Task GetExternalQaCheck()
        {
            const long externalQaCheckId = 13;
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest($"/external-qa-checks/{externalQaCheckId}", null))
                .ReturnsAsync(ApiResult("GetExternalQaCheck"));

            var executor = new ExternalQaChecksApiExecutor(mockClient.Object);
            ExternalQaCheck response = await executor.GetExternalQaCheck(externalQaCheckId);

            Assert.Equal(externalQaCheckId, response.Id);
            Assert.Equal("Placeholder validation", response.Name);
            Assert.Equal("Checks placeholders", response.Description);
            Assert.Equal("https://qa.example.test/check", response.Config["endpoint"]!.Value<string>());
            Assert.Equal("placeholders", response.Config["rules"]![0]!.Value<string>());
        }

        private static CrowdinApiResult ApiResult(string key)
        {
            return new CrowdinApiResult
            {
                StatusCode = HttpStatusCode.OK,
                JsonObject = (JObject)JObject.Parse(ExternalQaCheckFixtures.ApiResponses)[key]!
            };
        }
    }
}
