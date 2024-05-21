
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.AI;
using Crowdin.Api.Core;
using Crowdin.Api.Tests.Core;

namespace Crowdin.Api.Tests.AI
{
    public class AiPromptsApiTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();
        
        [Fact]
        public async Task ListAiPrompts()
        {
            const int userId = 1;
            const int projectId = 2;
            const AiPromptAction action = AiPromptAction.PreTranslate;
            
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();
            queryParams.Add("projectId", projectId.ToString());
            queryParams.Add("action", action.ToDescriptionString());
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/users/{userId}/ai/prompts";
            
            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.AI_Prompts.CommonResponses_Multi)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            ResponseList<AiPromptResource>? response = await executor.ListAiPrompts(userId, projectId, action);
            
            Assert.NotNull(response);
            Assert.Single(response.Data);
            
            Assert_AiPrompt(response.Data[0]);
        }
        
        [Fact]
        public async Task ListAiPrompts_Enterprise()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();
            
            mockClient
                .Setup(client => client.SendGetRequest("/ai/prompts", queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.AI_Prompts.CommonResponses_Multi)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            var response = await executor.ListAiPrompts(userId: null);
            
            Assert_AiPrompt(response.Data[0]);
        }
        
        [Fact]
        public async Task AddAiPrompt()
        {
            const int userId = 1;
            
            var request = new AddAiPromptRequest
            {
                Name = "Pre-translate prompt",
                Action = AiPromptAction.PreTranslate,
                AiProviderId = 1,
                AiModelId = "gpt-3.5-turbo-instruct",
                IsEnabled = true,
                EnabledProjectIds = new[] { 23 },
                Configuration = new BasicModeAiPromptConfiguration
                {
                    CompanyDescription = "string",
                    ProjectDescription = "string",
                    AudienceDescription = "string",
                    OtherLanguageTranslations = new()
                    {
                        IsEnabled = true,
                        LanguageIds = new[] { "uk" }
                    },
                    GlossaryTerms = true,
                    TmSuggestions = true,
                    FileContent = true,
                    FileContext = true,
                    PublicProjectDescription = true
                }
            };
            
            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(Core.Resources.AI_Prompts.AddAiPrompt_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/users/{userId}/ai/prompts";
            
            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.AI_Prompts.CommonResponses_Single)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            AiPromptResource? response = await executor.AddAiPrompt(userId, request);
            
            Assert_AiPrompt(response);
        }
        
        [Fact]
        public async Task AddAiPrompt_Enterprise()
        {
            var request = new AddAiPromptRequest();
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            mockClient
                .Setup(client => client.SendPostRequest("/ai/prompts", request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.AI_Prompts.CommonResponses_Single)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            AiPromptResource? response = await executor.AddAiPrompt(userId: null, request);
            
            Assert_AiPrompt(response);
        }
        
        [Fact]
        public async Task GetAiPrompt()
        {
            const int userId = 1;
            const int aiPromptId = 2;
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/users/{userId}/ai/prompts/{aiPromptId}";
            
            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.AI_Prompts.CommonResponses_Single)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            AiPromptResource? response = await executor.GetAiPrompt(userId, aiPromptId);
            
            Assert_AiPrompt(response);
        }
        
        [Fact]
        public async Task GetAiPrompt_Enterprise()
        {
            const int aiPromptId = 1;
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/ai/prompts/{aiPromptId}";
            
            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.AI_Prompts.CommonResponses_Single)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            AiPromptResource? response = await executor.GetAiPrompt(userId: null, aiPromptId);
            
            Assert_AiPrompt(response);
        }
        
        [Fact]
        public async Task DeleteAiPrompt()
        {
            const int userId = 1;
            const int aiPromptId = 2;
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/users/{userId}/ai/prompts/{aiPromptId}";
            
            mockClient
                .Setup(client => client.SendDeleteRequest(url, null))
                .ReturnsAsync(HttpStatusCode.NoContent);
            
            var executor = new AiApiExecutor(mockClient.Object);
            await executor.DeleteAiPrompt(userId, aiPromptId);
        }
        
        [Fact]
        public async Task DeleteAiPrompt_Enterprise()
        {
            const int aiPromptId = 1;
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/ai/prompts/{aiPromptId}";
            
            mockClient
                .Setup(client => client.SendDeleteRequest(url, null))
                .ReturnsAsync(HttpStatusCode.NoContent);
            
            var executor = new AiApiExecutor(mockClient.Object);
            await executor.DeleteAiPrompt(userId: null, aiPromptId);
        }
        
        [Fact]
        public async Task EditAiPrompt()
        {
            const int userId = 1;
            const int aiPromptId = 2;
            
            var patches = new[]
            {
                new AiPromptPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = AiPromptPatchPath.Name,
                    Value = "new name"
                },
                new AiPromptPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = AiPromptPatchPath.AiProviderId,
                    Value = 1
                }
            };
            
            string actualRequestJson = JsonConvert.SerializeObject(patches, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(Core.Resources.AI_Prompts.EditAiPrompt_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/users/{userId}/ai/prompts/{aiPromptId}";
            
            mockClient
                .Setup(client => client.SendPatchRequest(url, patches, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.AI_Prompts.CommonResponses_Single)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            AiPromptResource? response = await executor.EditAiPrompt(userId, aiPromptId, patches);
            
            Assert_AiPrompt(response);
        }
        
        [Fact]
        public async Task EditAiPrompt_Enterprise()
        {
            const int aiPromptId = 1;
            
            AiPromptPatch[] patches = Array.Empty<AiPromptPatch>();
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/ai/prompts/{aiPromptId}";
            
            mockClient
                .Setup(client => client.SendPatchRequest(url, patches, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.AI_Prompts.CommonResponses_Single)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            AiPromptResource? response = await executor.EditAiPrompt(userId: null, aiPromptId, patches);
            
            Assert_AiPrompt(response);
        }
        
        private static void Assert_AiPrompt(AiPromptResource? prompt)
        {
            Assert.NotNull(prompt);
            ArgumentNullException.ThrowIfNull(prompt);
            
            Assert.Equal(2, prompt.Id);
            Assert.Equal("Pre-translate prompt", prompt.Name);
            Assert.Equal(AiPromptAction.PreTranslate, prompt.Action);
            Assert.Equal(2, prompt.AiProviderId);
            Assert.Equal("gpt-3.5-turbo-instruct", prompt.AiModelId);
            Assert.True(prompt.IsEnabled);
            Assert.Equal(new[] { 1 }, prompt.EnabledProjectIds);
            
            var config = prompt.Configuration as BasicModeAiPromptConfiguration;
            Assert.NotNull(config);
            ArgumentNullException.ThrowIfNull(config);
            Assert.Equal("string", config.CompanyDescription);
            Assert.Equal("string", config.ProjectDescription);
            Assert.Equal("string", config.AudienceDescription);
            Assert.True(config.GlossaryTerms);
            Assert.True(config.TmSuggestions);
            Assert.True(config.FileContent);
            Assert.True(config.PublicProjectDescription);
            
            BasicModeAiPromptConfiguration.OtherLanguageTranslationsConfig? otherLanguageTranslations = config.OtherLanguageTranslations;
            Assert.NotNull(otherLanguageTranslations);
            Assert.True(otherLanguageTranslations.IsEnabled);
            Assert.Equal(new[] { "uk" }, otherLanguageTranslations.LanguageIds);
            
            Assert.Equal(DateTimeOffset.Parse("2019-09-20T11:11:05+00:00"), prompt.CreatedAt);
            Assert.Equal(DateTimeOffset.Parse("2019-09-20T12:22:20+00:00"), prompt.UpdatedAt);
        }
    }
}