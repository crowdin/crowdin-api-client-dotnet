
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using Crowdin.Api.Languages;
using Crowdin.Api.Tests.Testing;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Crowdin.Api.Tests.Languages
{
    public class LanguagesApiTests
    {
        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();
        
        [Fact]
        public async Task ListSupportedLanguages()
        {
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendGetRequest("/languages", queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Testing.Resources.Languages.ListSupportedLanguages_Response)
                });

            var executor = new LanguagesApiExecutor(mockClient.Object);
            ResponseList<Language> response = await executor.ListSupportedLanguages();
            
            Assert.NotNull(response);
            Assert.Single(response.Data);
            Assert.Single(response.Data[0].PluralCategoryNames);
            Assert.Single(response.Data[0].PluralExamples);
            Assert.Equal(TextDirection.LeftToRight, response.Data[0].TextDirection);
        }

        [Fact]
        public async Task AddCustomLanguage()
        {
            var request = new AddCustomLanguageRequest
            {
                Name = "CustomLanguage",
                Code = "custom",
                LocaleCode = "custom-Uk",
                TextDirection = TextDirection.LeftToRight,
                PluralCategoryNames = new[]
                {
                    "one",
                    "other"
                },
                ThreeLettersCode = "cus",
                TwoLettersCode = "cu",
                DialectOf = "uk"
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Testing.Resources.Languages.AddCustomLanguage_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPostRequest("/languages", request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(Testing.Resources.Languages.AddCustomLanguage_Response)
                });

            var executor = new LanguagesApiExecutor(mockClient.Object);
            Language response = await executor.AddCustomLanguage(request);
            
            Assert.NotNull(response);
            Assert.Single(response.PluralCategoryNames);
            Assert.Single(response.PluralExamples);
            Assert.Equal(TextDirection.LeftToRight, response.TextDirection);
        }
    }
}