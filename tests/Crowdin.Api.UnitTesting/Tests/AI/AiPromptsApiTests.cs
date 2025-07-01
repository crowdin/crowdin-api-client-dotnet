
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
using Crowdin.Api.UnitTesting.Resources;

namespace Crowdin.Api.UnitTesting.Tests.AI
{
    public class AiPromptsApiTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task CloneAiPrompt()
        {
            const int userId = 1;
            const int aiPromptId = 2;

            var request = new CloneAiPromptRequest
            {
                Name = "clone"
            };

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/ai/prompts/{aiPromptId}/clones";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(AI_Prompts.CommonResponses_Single)
                });

            var executor = new AiApiExecutor(mockClient.Object);
            AiPromptResource? response = await executor.CloneAiPrompt(userId, aiPromptId, request);

            Assert_AiPrompt(response);
        }

        [Fact]
        public async Task CloneAiPrompt_Enterprise()
        {
            const int aiPromptId = 1;

            var request = new CloneAiPromptRequest
            {
                Name = "clone"
            };

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/ai/prompts/{aiPromptId}/clones";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(AI_Prompts.CommonResponses_Single)
                });

            var executor = new AiApiExecutor(mockClient.Object);
            AiPromptResource? response = await executor.CloneAiPrompt(userId: null, aiPromptId, request);

            Assert_AiPrompt(response);
        }

        [Fact]
        public async Task GenerateAiPromptCompletion()
        {
            const int userId = 1;
            const int aiPromptId = 2;

            var request = new GenerateAiPromptCompletionRequest
            {
                Resources = new PreTranslateActionAiPromptContextResources
                {
                    ProjectId = 1,
                    TargetLanguageId = "uk",
                    StringIds = [1, 2, 3]
                },
                Tools = new[]
                {
                    new AiToolObject
                    {
                        Tool = new AiTool
                        {
                            Type = AiToolType.Function,
                            Function = new AiToolFunction
                            {
                                Name = "func",
                                Description = "func desc"
                            }
                        }
                    }
                },
                ToolChoice = "string"
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(AI_Prompts.GenerateAiPromptCompletion_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/ai/prompts/{aiPromptId}/completions";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(AI_Prompts.CommonResponses_AiPromptCompletion)
                });

            var executor = new AiApiExecutor(mockClient.Object);
            AiPromptCompletion? response = await executor.GenerateAiPromptCompletion(userId, aiPromptId, request);

            Assert_AiPromptCompletion(response);
        }

        [Fact]
        public async Task GenerateAiPromptCompletion_Enterprise()
        {
            const int aiPromptId = 1;

            var request = new GenerateAiPromptCompletionRequest
            {
                Resources = new PreTranslateActionAiPromptContextResources
                {
                    ProjectId = 1,
                    TargetLanguageId = "uk",
                    StringIds = [1, 2, 3]
                },
                Tools = new[]
                {
                    new AiToolObject
                    {
                        Tool = new AiTool
                        {
                            Type = AiToolType.Function,
                            Function = new AiToolFunction
                            {
                                Name = "func",
                                Description = "func desc"
                            }
                        }
                    }
                },
                ToolChoice = "string"
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(AI_Prompts.GenerateAiPromptCompletion_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/ai/prompts/{aiPromptId}/completions";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(AI_Prompts.CommonResponses_AiPromptCompletion)
                });

            var executor = new AiApiExecutor(mockClient.Object);
            AiPromptCompletion? response = await executor.GenerateAiPromptCompletion(userId: null, aiPromptId, request);

            Assert_AiPromptCompletion(response);
        }

        [Fact]
        public async Task GetAiPromptCompletionStatus()
        {
            const int userId = 1;
            const int aiPromptId = 2;
            const string completionId = "123";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/ai/prompts/{aiPromptId}/completions/{completionId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_Prompts.CommonResponses_AiPromptCompletion)
                });

            var executor = new AiApiExecutor(mockClient.Object);
            AiPromptCompletion? response = await executor.GetAiPromptCompletionStatus(userId, aiPromptId, completionId);

            Assert_AiPromptCompletion(response);
        }

        [Fact]
        public async Task GetAiPromptCompletionStatus_Enterprise()
        {
            const int aiPromptId = 1;
            const string completionId = "123";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/ai/prompts/{aiPromptId}/completions/{completionId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_Prompts.CommonResponses_AiPromptCompletion)
                });

            var executor = new AiApiExecutor(mockClient.Object);
            AiPromptCompletion? response = await executor.GetAiPromptCompletionStatus(userId: null, aiPromptId, completionId);

            Assert_AiPromptCompletion(response);
        }

        [Fact]
        public async Task CancelAiPromptCompletion()
        {
            const int userId = 1;
            const int aiPromptId = 2;
            const string completionId = "123";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/ai/prompts/{aiPromptId}/completions/{completionId}";

            mockClient
                .Setup(client => client.SendDeleteRequest(url, null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            var executor = new AiApiExecutor(mockClient.Object);
            await executor.CancelAiPromptCompletion(userId, aiPromptId, completionId);
        }

        [Fact]
        public async Task CancelAiPromptCompletion_Enterprise()
        {
            const int aiPromptId = 1;
            const string completionId = "123";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/ai/prompts/{aiPromptId}/completions/{completionId}";

            mockClient
                .Setup(client => client.SendDeleteRequest(url, null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            var executor = new AiApiExecutor(mockClient.Object);
            await executor.CancelAiPromptCompletion(userId: null, aiPromptId, completionId);
        }

        [Fact]
        public async Task DownloadAiPromptCompletion()
        {
            const int userId = 1;
            const int aiPromptId = 2;
            const string completionId = "123";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/ai/prompts/{aiPromptId}/completions/{completionId}/download";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_Prompts.DownloadAiPromptCompletion_Response)
                });

            var executor = new AiApiExecutor(mockClient.Object);
            DownloadLink? response = await executor.DownloadAiPromptCompletion(userId, aiPromptId, completionId);

            Assert.NotNull(response);
        }

        [Fact]
        public async Task DownloadAiPromptCompletion_Enterprise()
        {
            const int aiPromptId = 1;
            const string completionId = "123";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/ai/prompts/{aiPromptId}/completions/{completionId}/download";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_Prompts.DownloadAiPromptCompletion_Response)
                });

            var executor = new AiApiExecutor(mockClient.Object);
            DownloadLink? response = await executor.DownloadAiPromptCompletion(userId: null, aiPromptId, completionId);

            Assert.NotNull(response);
        }

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
                    JsonObject = JObject.Parse(AI_Prompts.CommonResponses_Multi)
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
                    JsonObject = JObject.Parse(AI_Prompts.CommonResponses_Multi)
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
                EnabledProjectIds = [23],
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
            string expectedRequestJson = TestUtils.CompactJson(AI_Prompts.AddAiPrompt_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/ai/prompts";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_Prompts.CommonResponses_Single)
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
                    JsonObject = JObject.Parse(AI_Prompts.CommonResponses_Single)
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
                    JsonObject = JObject.Parse(AI_Prompts.CommonResponses_Single)
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
                    JsonObject = JObject.Parse(AI_Prompts.CommonResponses_Single)
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
            string expectedRequestJson = TestUtils.CompactJson(AI_Prompts.EditAiPrompt_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/ai/prompts/{aiPromptId}";

            mockClient
                .Setup(client => client.SendPatchRequest(url, patches, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_Prompts.CommonResponses_Single)
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
                    JsonObject = JObject.Parse(AI_Prompts.CommonResponses_Single)
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
            Assert.Equal([ 1 ], prompt.EnabledProjectIds);

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

            OtherLanguageTranslationsConfig? otherLanguageTranslations = config.OtherLanguageTranslations;
            ArgumentNullException.ThrowIfNull(otherLanguageTranslations);
            Assert.True(otherLanguageTranslations.IsEnabled);
            Assert.Equal(new[] { "uk" }, otherLanguageTranslations.LanguageIds);

            Assert.Equal(DateTimeOffset.Parse("2019-09-20T11:11:05+00:00"), prompt.CreatedAt);
            Assert.Equal(DateTimeOffset.Parse("2019-09-20T12:22:20+00:00"), prompt.UpdatedAt);
        }

        private static void Assert_AiPromptCompletion(AiPromptCompletion? completion)
        {
            ArgumentNullException.ThrowIfNull(completion);

            Assert.Equal("50fb3506-4127-4ba8-8296-f97dc7e3e0c3", completion.Identifier);
            Assert.Equal(OperationStatus.Finished, completion.Status);
            Assert.Equal(100, completion.Progress);

            AiPromptCompletion.AttributesObject? attributes = completion.Attributes;
            ArgumentNullException.ThrowIfNull(attributes);
            Assert.Equal(38, attributes.AiPromptId);

            DateTimeOffset date = DateTimeOffset.Parse("2019-09-23T11:26:54+00:00");
            Assert.Equal(date, completion.CreatedAt);
            Assert.Equal(date, completion.UpdatedAt);
            Assert.Equal(date, completion.StartedAt);
            Assert.Equal(date, completion.FinishedAt);
        }
    }
}