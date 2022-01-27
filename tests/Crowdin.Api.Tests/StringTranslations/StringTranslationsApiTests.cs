
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using Crowdin.Api.StringTranslations;
using Crowdin.Api.Tests.Core;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Crowdin.Api.Tests.StringTranslations
{
    public class StringTranslationsApiTests
    {
        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();
        
        [Fact]
        public async Task AddTranslation()
        {
            const int projectId = 1;
            
            var request = new AddTranslationRequest
            {
                StringId = 35434,
                LanguageId = "uk",
                Text = "Цю стрічку перекладено",
                PluralCategoryName = PluralCategoryName.Few
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Core.Resources.StringTranslations.AddTranslation_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/translations";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(Core.Resources.StringTranslations.AddTranslation_Response)
                });

            var executor = new StringTranslationsApiExecutor(mockClient.Object);
            StringTranslation response = await executor.AddTranslation(projectId, request);
            
            Assert.NotNull(response);
            Assert.Equal(19, response.User.Id);
            Assert.Equal(PluralCategoryName.Few, response.PluralCategoryName);
        }

        [Fact]
        public async Task RestoreTranslation()
        {
            const int projectId = 1;
            const int translationId = 2;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/translations/{translationId}";

            mockClient
                .Setup(client => client.SendPutRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(Core.Resources.StringTranslations.RestoreTranslation_Response)
                });

            var executor = new StringTranslationsApiExecutor(mockClient.Object);
            StringTranslation response = await executor.RestoreTranslation(projectId, translationId);
            
            Assert.NotNull(response);
            Assert.Equal(19, response.User.Id);
            Assert.Equal(PluralCategoryName.Few, response.PluralCategoryName);
        }
    }
}