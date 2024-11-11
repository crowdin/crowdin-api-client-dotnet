
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.AI;
using Crowdin.Api.Core;
using Crowdin.Api.UnitTesting.Resources;

namespace Crowdin.Api.UnitTesting.Tests.AI
{
    public class AiSettingsApiTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task GetAiSettings()
        {
            const int userId = 1;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/ai/settings";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_Settings.CommonResponses_AiSettings)
                });

            var executor = new AiApiExecutor(mockClient.Object);
            AiSettings? response = await executor.GetAiSettings(userId);

            Assert_AiSettings(response);
        }

        [Fact]
        public async Task GetAiSettings_Enterprise()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendGetRequest("/ai/settings", null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_Settings.CommonResponses_AiSettings)
                });

            var executor = new AiApiExecutor(mockClient.Object);
            AiSettings? response = await executor.GetAiSettings(userId: null);

            Assert_AiSettings(response);
        }

        [Fact]
        public async Task EditAiSettings()
        {
            const int userId = 1;

            var request = new[]
            {
                new AiSettingsPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = AiSettingsPatchPath.AssistActionAiPromptId,
                    Value = true
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(AI_Settings.EditAiSettings_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/ai/settings";

            mockClient
                .Setup(client => client.SendPatchRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_Settings.CommonResponses_AiSettings)
                });

            var executor = new AiApiExecutor(mockClient.Object);
            AiSettings? response = await executor.EditAiSettings(userId, request);

            Assert_AiSettings(response);
        }

        [Fact]
        public async Task EditAiSettings_Enterprise()
        {
            var request = new[]
            {
                new AiSettingsPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = AiSettingsPatchPath.AssistActionAiPromptId,
                    Value = true
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(AI_Settings.EditAiSettings_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPatchRequest("/ai/settings", request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_Settings.CommonResponses_AiSettings)
                });

            var executor = new AiApiExecutor(mockClient.Object);
            AiSettings? response = await executor.EditAiSettings(userId: null, request);

            Assert_AiSettings(response);
        }

        private static void Assert_AiSettings(AiSettings? settings)
        {
            ArgumentNullException.ThrowIfNull(settings);

            Assert.Equal(2, settings.AssistActionAiPromptId);
            Assert.True(settings.ShowSuggestion);

            AiSettingsShortcuts? shortcut = settings.Shortcuts?.FirstOrDefault();
            ArgumentNullException.ThrowIfNull(shortcut);
            Assert.Equal("My first shortcut", shortcut.Name);
            Assert.Equal("Make translation shorter", shortcut.Prompt);
            Assert.True(shortcut.Enabled);
        }
    }
}