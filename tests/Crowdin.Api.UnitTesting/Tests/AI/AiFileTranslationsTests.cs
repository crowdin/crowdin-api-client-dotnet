
using System;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.AI;
using Crowdin.Api.Core;
using Crowdin.Api.SourceFiles;
using Crowdin.Api.UnitTesting.Resources;

namespace Crowdin.Api.UnitTesting.Tests.AI
{
    public class AiFileTranslationsTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task AiFileTranslations()
        {
            const int userId = 1;

            var request = new AiFileTranslationsRequest
            {
                StorageId = 123,
                SourceLanguageId = "en",
                TargetLanguageId = "uk",
                Type = ProjectFileType.Xliff,
                ParserVersion = 1,
                TmIds = [123],
                GlossaryIds = [456],
                AiPromptId = 789,
                AiProviderId = 12,
                AiModelId = "gpt-4.1",
                Instructions = [
                    "Keep a formal tone"
                ],
                AttachmentIds = [123]
            };
            
            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(AI_FileTranslations.AiFileTranslations_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/ai/file-translations";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(AI_FileTranslations.AiFileTranslations_Response)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            AiFileTranslationsStatus? response = await executor.AiFileTranslations(userId, request);
            Assert_AiFileTranslationsStatus(response);
        }

        [Fact]
        public async Task GetFileTranslationsStatus()
        {
            const int userId = 1;
            const string jobIdentifier = "50fb3506-4127-4ba8-8296-f97dc7e3e0c3";
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/ai/file-translations/{jobIdentifier}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_FileTranslations.AiFileTranslations_Response)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            AiFileTranslationsStatus? response = await executor.GetFileTranslationsStatus(userId, jobIdentifier);
            Assert_AiFileTranslationsStatus(response);
        }

        [Fact]
        public async Task CancelFileTranslations()
        {
            const string jobIdentifier = "50fb3506-4127-4ba8-8296-f97dc7e3e0c3";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            const string url = $"/ai/file-translations/{jobIdentifier}";

            mockClient
                .Setup(client => client.SendDeleteRequest(url, null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            var executor = new AiApiExecutor(mockClient.Object);
            await executor.CancelFileTranslations(null, jobIdentifier); // Enterprise Mode
        }

        [Fact]
        public async Task DownloadTranslatedFile()
        {
            const int userId = 1;
            const string jobIdentifier = "50fb3506-4127-4ba8-8296-f97dc7e3e0c3";
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/ai/file-translations/{jobIdentifier}/download";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Common.Responses_DownloadLink)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            DownloadLink? response = await executor.DownloadTranslatedFile(userId, jobIdentifier);
            CommonResponsesAssertUtils.Assert_DownloadLink(response);
        }

        [Fact]
        public async Task DownloadTranslatedFileStrings()
        {
            const int userId = 1;
            const string jobIdentifier = "50fb3506-4127-4ba8-8296-f97dc7e3e0c3";
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/users/{userId}/ai/file-translations/{jobIdentifier}/translations";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Common.Responses_DownloadLink)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            DownloadLink? response = await executor.DownloadTranslatedFileStrings(userId, jobIdentifier);
            CommonResponsesAssertUtils.Assert_DownloadLink(response);
        }

        private static void Assert_AiFileTranslationsStatus(AiFileTranslationsStatus? response)
        {
            ArgumentNullException.ThrowIfNull(response);
            
            Assert.Equal("50fb3506-4127-4ba8-8296-f97dc7e3e0c3", response.Identifier);
            Assert.Equal(OperationStatus.Finished, response.Status);
            Assert.Equal(100, response.Progress);

            AiFileTranslationsStatus.AttributesObject attributes = response.Attributes;
            ArgumentNullException.ThrowIfNull(attributes);
            Assert.Equal(AiFileTranslationsStage.Translate, attributes.Stage);
            Assert.Equal("file.pdf", attributes.DownloadName);
            Assert.Equal("en", attributes.SourceLanguageId);
            Assert.Equal("uk", attributes.TargetLanguageId);
            Assert.Equal("Sample_Chrome.json", attributes.OriginalFileName);
            Assert.Equal(ProjectFileType.Chrome, attributes.DetectedType);
            Assert.Equal(2, attributes.ParserVersion);

            AiFileTranslationsStatus.AttributesObject.ErrorObject? error = attributes.Error;
            ArgumentNullException.ThrowIfNull(error);
            Assert.Equal(AiFileTranslationsStage.Import, error.Stage);
            Assert.Equal("Failed to parse file", error.Message);

            DateTimeOffset date = DateTimeOffset.Parse("2026-01-23T11:26:54+00:00");
            Assert.Equal(date, response.CreatedAt);
            Assert.Equal(date, response.UpdatedAt);
            Assert.Equal(date, response.StartedAt);
            Assert.Equal(date, response.FinishedAt);
        }
    }
}