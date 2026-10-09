using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using Crowdin.Api.CustomSpellcheckers;
using Crowdin.Api.UnitTesting.Resources;

using Moq;
using Newtonsoft.Json.Linq;
using Xunit;

using CustomSpellcheckerFixtures = Crowdin.Api.UnitTesting.Resources.CustomSpellcheckers;

namespace Crowdin.Api.UnitTesting.Tests.CustomSpellcheckers
{
    public class CustomSpellcheckersApiTests
    {
        [Fact]
        public async Task ListCustomSpellcheckers()
        {
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest("/custom-spellcheckers", queryParams))
                .ReturnsAsync(ApiResult("ListCustomSpellcheckers"));

            var executor = new CustomSpellcheckersApiExecutor(mockClient.Object);
            ResponseList<CustomSpellchecker> response = await executor.ListCustomSpellcheckers();

            Assert.Single(response.Data);
            Assert.Equal(5, response.Data[0].Id);
            Assert.Equal("English spellchecker", response.Data[0].Name);
            Assert.Equal("english", response.Data[0].Config.Identifier);
            Assert.True(response.Data[0].Config.RealTimeCheckEnabled);
            Assert.Equal(new[] { "en", "en-GB" }, response.Data[0].Config.EnabledLanguageIds);
        }

        [Fact]
        public async Task GetCustomSpellchecker()
        {
            const long customSpellcheckerId = 6;
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest($"/custom-spellcheckers/{customSpellcheckerId}", null))
                .ReturnsAsync(ApiResult("GetCustomSpellchecker"));

            var executor = new CustomSpellcheckersApiExecutor(mockClient.Object);
            CustomSpellchecker response = await executor.GetCustomSpellchecker(customSpellcheckerId);

            Assert.Equal(customSpellcheckerId, response.Id);
            Assert.Equal("Ukrainian spellchecker", response.Name);
            Assert.Equal("ukrainian", response.Config.Identifier);
            Assert.False(response.Config.RealTimeCheckEnabled);
            Assert.Equal("uk", response.Config.EnabledLanguageIds[0]);
        }

        private static CrowdinApiResult ApiResult(string key)
        {
            return new CrowdinApiResult
            {
                StatusCode = HttpStatusCode.OK,
                JsonObject = (JObject)JObject.Parse(CustomSpellcheckerFixtures.ApiResponses)[key]!
            };
        }
    }
}
