
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api;
using Crowdin.Api.Core;
using Crowdin.Api.Tests.Core;
using Crowdin.Api.Translations;
using Moq;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Crowdin.Api.Tests.Translations
{
    public class TranslationsApiTests
    {
        [Fact]
        public async Task ApplyPreTranslationRequest()
        {
            const int projectId = 1;

            var body = new ApplyPreTranslationRequest
            {
                LanguageIds = new HashSet<string> { "uk" },
                FileIds = new HashSet<int> { 0 },
                Method = PreTranslationMethod.Mt,
                EngineId = 3434,
                AutoApproveOption = AutoApproveOption.ExceptAutoSubstituted,
                DuplicateTranslations = true,
                TranslateUntranslatedOnly = false,
                FallbackLanguages = new Dictionary<string, string[]>
                {
                    { "uk", new[] { "ru", "en" } }
                }
            };

            var mockClient = new Mock<ICrowdinApiClient>();
            
            mockClient
                .Setup(client => client.SendPostRequest(
                    $"/projects/{projectId}/pre-translations", body, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Accepted,
                    JsonObject = JObject.Parse(Core.Resources.Translations.ApplyPreTranslationResponse)
                });

            var executor = new TranslationsApiExecutor(mockClient.Object, TestUtils.CreateJsonParser());
            PreTranslation preTranslation = await executor.ApplyPreTranslation(projectId, body);
            Assert.NotNull(preTranslation);
        }

        [Fact]
        public async Task UploadTranslations()
        {
            const int projectId = 1;
            const string languageId = "es";

            var body = new UploadTranslationsRequest
            {
                FileId = 56,
                AutoApproveImported = false,
                ImportEqSuggestions = false,
                MarkAddedTranslationsAsDone = false,
                StorageId = 34,
                TranslateHidden = false
            };

            var mockClient = new Mock<ICrowdinApiClient>();
            mockClient
                .Setup(client => client.SendPostRequest(
                    $"/projects/{projectId}/translations/{languageId}", body, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.Translations.UploadTranslationsResponse)
                });

            var executor = new TranslationsApiExecutor(mockClient.Object, TestUtils.CreateJsonParser());

            UploadTranslationsResponse response = await executor.UploadTranslations(projectId, languageId, body);
            Assert.NotNull(response);
        }
    }
}