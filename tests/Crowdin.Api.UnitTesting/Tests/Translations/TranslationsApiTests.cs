
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
using Crowdin.Api.Translations;
using Crowdin.Api.TranslationStatus;

namespace Crowdin.Api.UnitTesting.Tests.Translations
{
    public class TranslationsApiTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task ListPreTranslations()
        {
            const int projectId = 1;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/pre-translations";
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();

            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.Translations.CommonResources_PreTranslations_List)
                });

            var executor = new TranslationsApiExecutor(mockClient.Object);
            ResponseList<PreTranslation> response = await executor.ListPreTranslations(projectId);

            Assert_PreTranslation(response.Data.FirstOrDefault());
        }

        [Fact]
        public async Task EditPreTranslation()
        {
            const int projectId = 1;
            const string preTranslationId = "pre-translation-id";

            var patches = new[]
            {
                new PreTranslationPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = PreTranslationPatchPath.Status,
                    Value = "status"
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(patches, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(Resources.Translations.EditPreTranslation_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/pre-translations/{preTranslationId}";

            mockClient
                .Setup(client => client.SendPatchRequest(url, patches, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.Translations.CommonResources_PreTranslation)
                });

            var executor = new TranslationsApiExecutor(mockClient.Object);
            PreTranslation response = await executor.EditPreTranslation(projectId, preTranslationId, patches);

            Assert_PreTranslation(response);
        }

        [Fact]
        public async Task ApplyPreTranslationRequest()
        {
            const int projectId = 1;

            var body = new ApplyPreTranslationRequest
            {
                LanguageIds = new HashSet<string> { "uk" },
                FileIds = new HashSet<long> { 0 },
                Method = PreTranslationMethod.Ai,
                EngineId = 3434,
                AiPromptId = 123,
                AutoApproveOption = AutoApproveOption.ExceptAutoSubstituted,
                DuplicateTranslations = true,
                TranslateUntranslatedOnly = false,
                FallbackLanguages = new Dictionary<string, string[]>
                {
                    { "uk", new[] { "ru", "en" } }
                },
                LabelIds = new HashSet<long> { 2, 3 },
                ExcludeLabelIds = new HashSet<long> { 4 }
            };

            var mockClient = new Mock<ICrowdinApiClient>();

            mockClient
                .Setup(client => client.SendPostRequest(
                    $"/projects/{projectId}/pre-translations", body, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Accepted,
                    JsonObject = JObject.Parse(Resources.Translations.ApplyPreTranslationResponse)
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
                StorageId = 34,
                TranslateHidden = false,
                AddToTm = true
            };

            var mockClient = new Mock<ICrowdinApiClient>();
            mockClient
                .Setup(client => client.SendPostRequest(
                    $"/projects/{projectId}/translations/{languageId}", body, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.Translations.UploadTranslationsResponse)
                });

            var executor = new TranslationsApiExecutor(mockClient.Object, TestUtils.CreateJsonParser());

            UploadTranslationsResponse response = await executor.UploadTranslations(projectId, languageId, body);
            Assert.NotNull(response);
        }

        [Fact]
        public async Task ListProjectBuilds()
        {
            const int projectId = 12345;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/translations/builds";
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();

            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.Translations.ListProjectBuildsResponse)
                });

            var executor = new TranslationsApiExecutor(mockClient.Object);
            ResponseList<TranslationProjectBuild> response = await executor.ListProjectBuilds(projectId);

            Assert.Single(response.Data);
            Assert.Equal(projectId, response.Data[0].ProjectId);
            Assert.Null(response.Data[0].Attributes.BranchId);
            Assert.Null(response.Data[0].Attributes.DirectoryId);

            Assert.NotNull(response.Data[0].Attributes.TargetLanguageIds);
            Assert.Empty(response.Data[0].Attributes.TargetLanguageIds);
        }

        [Fact]
        public async Task GetPreTranslationStatus()
        {
            const int projectId = 1;
            const string preTranslationId = "9e7de270-4f83-41cb-b606-2f90631f26e2";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/pre-translations/{preTranslationId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.Translations.GetPreTranslationStatus_Response)
                });

            var executor = new TranslationsApiExecutor(mockClient.Object);
            PreTranslation response = await executor.GetPreTranslationStatus(projectId, preTranslationId);

            Assert.NotNull(response);

            Assert.Equal(preTranslationId, response.Identifier);
            Assert.Equal(BuildStatus.Created, response.Status);
            Assert.Equal(90, response.Progress);
            Assert.Equal(DateTimeOffset.Parse("2019-09-20T14:05:50+00:00"), response.CreatedAt);
            Assert.Equal(DateTimeOffset.Parse("2019-09-20T14:05:50+00:00"), response.UpdatedAt);
            Assert.Equal(DateTimeOffset.Parse("2019-08-24T14:15:22Z"), response.StartedAt);
            Assert.Equal(DateTimeOffset.Parse("2019-08-24T14:15:22Z"), response.FinishedAt);

            PreTranslateAttributes? attributes = response.Attributes;
            Assert.NotNull(response.Attributes);
            Assert.Equal("uk", attributes.LanguageIds.Single());
            Assert.Equal(0, attributes.FileIds?.Single());
            Assert.Equal(PreTranslationMethod.Tm, attributes.Method);
            Assert.Equal(AutoApproveOption.All, attributes.AutoApproveOption);

            Assert.True(attributes.DuplicateTranslations);
            Assert.True(attributes.SkipApprovedTranslations);
            Assert.True(attributes.TranslateUntranslatedOnly);
            Assert.True(attributes.TranslateWithPerfectMatchOnly);

            Assert.Equal(2, attributes.LabelIds.Length);
            Assert.Contains(2, attributes.LabelIds);
            Assert.Contains(3, attributes.LabelIds);
            Assert.Equal(4, attributes.ExcludeLabelIds.Single());
        }

        [Fact]
        public async Task PreTranslationReport()
        {
            const int projectId = 1;
            const string preTranslationId = "123";
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/projects/{projectId}/pre-translations/{preTranslationId}/report";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.Translations.PreTranslationReport_Response)
                });
            
            var executor = new TranslationsApiExecutor(mockClient.Object);
            PreTranslationReport response = await executor.PreTranslationReport(projectId, preTranslationId);
            
            Assert_PreTranslationReport(response);
        }

        private static void Assert_PreTranslation(PreTranslation? preTranslation)
        {
            ArgumentNullException.ThrowIfNull(preTranslation);

            Assert.Equal("9e7de270-4f83-41cb-b606-2f90631f26e2", preTranslation.Identifier);
            Assert.Equal(BuildStatus.Created, preTranslation.Status);
            Assert.Equal(90, preTranslation.Progress);

            PreTranslateAttributes? attributes = preTranslation.Attributes;
            ArgumentNullException.ThrowIfNull(attributes);
            Assert.Equal(["uk"], attributes.LanguageIds);
            Assert.Equal([742], attributes.FileIds);
            Assert.Equal(PreTranslationMethod.Tm, attributes.Method);
            Assert.Equal(AutoApproveOption.All, attributes.AutoApproveOption);
            Assert.True(attributes.DuplicateTranslations);
            Assert.True(attributes.SkipApprovedTranslations);
            Assert.True(attributes.TranslateUntranslatedOnly);
            Assert.True(attributes.TranslateWithPerfectMatchOnly);

            DateTimeOffset date = DateTimeOffset.Parse("2019-09-20T14:05:50+00:00");
            Assert.Equal(date, preTranslation.CreatedAt);
            Assert.Equal(date, preTranslation.UpdatedAt);
            Assert.Equal(date, preTranslation.StartedAt);
            Assert.Equal(date, preTranslation.FinishedAt);
        }

        private static void Assert_PreTranslationReport(PreTranslationReport? preTranslationReport)
        {
            ArgumentNullException.ThrowIfNull(preTranslationReport);
            
            Assert.Equal(PreTranslationMethod.Ai, preTranslationReport.PreTranslateType);
            
            TargetLanguage? language = preTranslationReport.Languages.Single();
            ArgumentNullException.ThrowIfNull(language);
            Assert.Equal("es", language.Id);
            Assert.Equal(6, language.Skipped.AiError);
            Assert.Equal(QaCheckIssueCategory.SpellCheck, language.SkippedQaCheckCategories.Single());
            
            TargetLanguage.File? file = language.Files.Single();
            ArgumentNullException.ThrowIfNull(file);
            Assert.Equal("10191", file.Id);
            
            TargetLanguage.File.FileStatistics? statistics = file.Statistics;
            ArgumentNullException.ThrowIfNull(statistics);
            Assert.Equal(6, statistics.Phrases);
            Assert.Equal(13, statistics.Words);
        }
        
        [Fact]
        public async Task GetTranslationImportReport()
        {
            const int projectId = 1;
            const string importId = "b5215a34-1305-4b21-8054-fc2eb252842f";

            var mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/translations/imports/{importId}/report";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.Translations.GetTranslationImportReport_Response)
                });

            var executor = new TranslationsApiExecutor(mockClient.Object);
            TranslationImportReport response = await executor.DownloadTranslationImportReport(projectId, importId);

            Assert_TranslationImportReport(response);
        }

        private static void Assert_TranslationImportReport(TranslationImportReport? report)
        {
            ArgumentNullException.ThrowIfNull(report);
            ArgumentNullException.ThrowIfNull(report.Languages);

            var language = report.Languages.FirstOrDefault();
            ArgumentNullException.ThrowIfNull(language);

            Assert.Equal("fr", language.Id);

            var file = language.Files?.FirstOrDefault();
            ArgumentNullException.ThrowIfNull(file);
            Assert.Equal(6, file.Statistics?.Phrases);
            Assert.Equal(45, file.Statistics?.Words);

            Assert.Equal(0, language.Skipped?.TranslationEqSource);
            Assert.Equal(647, language.Skipped?.QaCheck);
            Assert.Equal(1, language.SkippedQaCheckCategories?.Size);
            Assert.Equal(648, language.SkippedQaCheckCategories?.Duplicate);
        }
        
        [Fact]
        public async Task ImportTranslations()
        {
            const int projectId = 1;

            var request = new ImportTranslationsRequest
            {
                StorageId = 13,
                LanguageIds = new[] { "en", "uk" },
                FileId = 2,
                ImportEqSuggestions = true,
                AutoApproveImported = false,
                TranslateHidden = false,
                AddToTm = false
            };

            var mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/translations/imports";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(Resources.Translations.ImportTranslations_Response)
                });

            var executor = new TranslationsApiExecutor(mockClient.Object);
            TranslationImportResponse response = await executor.ImportTranslations(projectId, request);

            Assert_ImportTranslationResponse(response);
        }

        [Fact]
        public async Task GetImportStatus()
        {
            const int projectId = 1;
            const string importTranslationId = "b5215a34-1305-4b21-8054-fc2eb252842f";

            var mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/translations/imports/{importTranslationId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.Translations.GetImportStatus_Response)
                });

            var executor = new TranslationsApiExecutor(mockClient.Object);
            TranslationImportResponse response = await executor.GetImportStatus(projectId, importTranslationId);

            Assert_ImportTranslationResponse(response);
        }

        private static void Assert_ImportTranslationResponse(TranslationImportResponse? response)
        {
            ArgumentNullException.ThrowIfNull(response);

            Assert.Equal("b5215a34-1305-4b21-8054-fc2eb252842f", response.Identifier);
            Assert.Equal("created", response.Status);
            Assert.Equal(0, response.Progress);

            Assert.Equal(DateTimeOffset.Parse("2025-09-23T11:51:08+00:00"), response.CreatedAt);
            Assert.Equal(DateTimeOffset.Parse("2025-09-23T11:51:08+00:00"), response.UpdatedAt);
            Assert.Equal(DateTimeOffset.Parse("2025-09-23T11:51:08+00:00"), response.StartedAt);

            TranslationImportAttributes? attributes = response.Attributes;
            ArgumentNullException.ThrowIfNull(attributes);

            Assert.Equal(13, attributes.StorageId);
            Assert.Equal(2, attributes.FileId);
            Assert.True(attributes.ImportEqSuggestions);
            Assert.False(attributes.AutoApproveImported);
            Assert.False(attributes.TranslateHidden);
            Assert.False(attributes.AddToTm);

            ArgumentNullException.ThrowIfNull(attributes.LanguageIds);
            Assert.Contains("en", attributes.LanguageIds);
        }

    }
}