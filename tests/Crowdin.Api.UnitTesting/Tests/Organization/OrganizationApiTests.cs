using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using Crowdin.Api.Organization;
using Crowdin.Api.UnitTesting.Resources;

using Moq;
using Newtonsoft.Json.Linq;
using Xunit;

using OrganizationFixtures = Crowdin.Api.UnitTesting.Resources.Organization;

namespace Crowdin.Api.UnitTesting.Tests.Organization
{
    public class OrganizationApiTests
    {
        [Fact]
        public async Task GetOrganizationInfo()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest("/organization", null))
                .ReturnsAsync(ApiResult("GetOrganizationInfo"));

            var executor = new OrganizationApiExecutor(mockClient.Object);
            OrganizationInfo response = await executor.GetOrganizationInfo();

            Assert.Equal(3, response.Id);
            Assert.Equal("example", response.Domain);
            Assert.Equal("Example Organization", response.Name);
            Assert.Equal(OrganizationProjectsView.Grid, response.DefaultPublicProjectsView);
            Assert.Equal("Enterprise", response.Plan.Name);
            Assert.Equal(1000000, response.Plan.WordsLimit);
            Assert.Equal("sourceLanguageId", response.Defaults[0].Name);
            Assert.True(response.Defaults[0].IsLocked);
            Assert.Equal("en", response.Defaults[0].DefaultValue);
        }

        [Fact]
        public async Task GetOrganizationAuthSettings()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest("/organization/auth-settings", null))
                .ReturnsAsync(ApiResult("GetOrganizationAuthSettings"));

            var executor = new OrganizationApiExecutor(mockClient.Object);
            OrganizationAuthSettings response = await executor.GetOrganizationAuthSettings();

            Assert.False(response.AllowSignUp);
            Assert.True(response.TwoFactorAuthentication);
            Assert.Equal(2, response.AuthMethods.Length);
            Assert.Equal("saml", response.AuthMethods[0].Name);
            Assert.True(response.AuthMethods[0].IsEnabled);
            Assert.True(response.AuthMethods[0].IsDefault);
        }

        private static CrowdinApiResult ApiResult(string key)
        {
            return new CrowdinApiResult
            {
                StatusCode = HttpStatusCode.OK,
                JsonObject = (JObject)JObject.Parse(OrganizationFixtures.ApiResponses)[key]!
            };
        }
    }
}
