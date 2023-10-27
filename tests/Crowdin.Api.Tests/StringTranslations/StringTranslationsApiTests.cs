
using System.Collections.Generic;
using System.Linq;
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
        public async Task ListLanguageTranslations()
        {
            const int projectId = 1;
            const string languageId = "en";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/languages/{languageId}/translations";

            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();

            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.StringTranslations.ListLanguageTranslations_Response)
                });

            var executor = new StringTranslationsApiExecutor(mockClient.Object);
            ResponseList<LanguageTranslations> response = await executor.ListLanguageTranslations(projectId, languageId);
            
            Assert.NotNull(response);
            Assert.IsType<PlainLanguageTranslations>(response.Data[0]);
            Assert.IsType<PluralLanguageTranslations>(response.Data[1]);
            Assert.IsType<IcuLanguageTranslations>(response.Data[2]);
        }
        
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

        [Fact]
        public async Task TranslationAlignment()
        {
            const int projectId = 1;

            var request = new TranslationAlignmentRequest
            {
                SourceLanguageId = "en",
                TargetLanguageId = "de",
                Text = "Your password has been reset successfully!"
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Core.Resources.StringTranslations.TranslationAlignment_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/translations/alignment";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.StringTranslations.TranslationAlignment_Response)
                });

            var executor = new StringTranslationsApiExecutor(mockClient.Object);
            TranslationAlignment response = await executor.TranslationAlignment(projectId, request);
            
            Assert.NotNull(response);
            
            WordAlignment? wordAlignment = response.Words?.Single();
            Assert.NotNull(wordAlignment);
            Assert.Equal("password", wordAlignment!.Text);

            Alignment? alignment = wordAlignment.Alignments?.Single();
            Assert.NotNull(alignment);
            Assert.Equal("Password", alignment!.SourceWord);
            Assert.Equal("password", alignment.SourceLemma);
            Assert.Equal("Пароль", alignment.TargetWord);
            Assert.Equal("пароль", alignment.TargetLemma);
            Assert.Equal(2, alignment.Match);
            Assert.Equal(2, alignment.Probability);
        }

        [Fact]
        public async Task ListTranslationApprovals()
        {
            const int projectId = 1;
            var url = $"/projects/{projectId}/approvals";
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var queryParams = TestUtils.CreateQueryParamsFromPaging();
            
            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.StringTranslations.ListTranslationsApproval_Response)
                });

            var executor = new StringTranslationsApiExecutor(mockClient.Object);
            ResponseList<TranslationApproval> response = await executor.ListTranslationApprovals(projectId);
            Assert.NotNull(response);
            var data = response.Data[1];
            Assert.Equal(200695, data.TranslationId);
            Assert.Equal(1234, data.StringId);
            Assert.IsType<User>(data.User);
        }
        
        [Fact]
        public async Task ListTranslationVotes()
        {
            const int projectId = 1;
            var url = $"/projects/{projectId}/votes";
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var queryParams = TestUtils.CreateQueryParamsFromPaging();
            
            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.StringTranslations.ListTranslationVotes_Response)
                });

            var executor = new StringTranslationsApiExecutor(mockClient.Object);
            ResponseList<TranslationVote> response = await executor.ListTranslationVotes(projectId);
            Assert.NotNull(response);
            var data = response.Data[0];
            Assert.Equal(19069345, data.TranslationId);
            Assert.Equal(TranslationVoteMark.Up, data.Mark);
            Assert.IsType<User>(data.User);
        }
    }
}