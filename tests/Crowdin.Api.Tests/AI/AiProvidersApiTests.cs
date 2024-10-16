
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.AI;
using Crowdin.Api.Core;
using Crowdin.Api.Tests.Testing;
using Crowdin.Api.Tests.Testing.Resources;

namespace Crowdin.Api.Tests.AI
{
    public class AiProvidersApiTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();
        
        #region Crowdin
        
        [Fact]
        public async Task ListAiProviders()
        {
            const int userId = 1;
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/users/{userId}/ai/providers";
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();
            
            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_Providers.CommonResponses_Multi)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            ResponseList<AiProviderResource>? response = await executor.ListAiProviders(userId);
            
            Assert.NotNull(response);
            Assert.Single(response.Data);
            Assert_AiProvider(response.Data[0]);
        }
        
        [Fact]
        public async Task AddAiProvider()
        {
            const int userId = 1;
            
            var request = new AddAiProviderRequest()
            {
                Name = "OpenAI",
                Type = AiProviderType.OpenAi,
                Credentials = new OpenAiProviderCredentials
                {
                    ApiKey = "string"
                },
                Configuration = new AiProviderConfiguration
                {
                    ActionRules = new List<ActionRule>
                    {
                        new ActionRule
                        {
                            Action = AiPromptAction.PreTranslate,
                            AvailableAiModelIds = new List<string>
                            {
                                "gpt-3.5-turbo-instruct"
                            }
                        }
                    }
                },
                IsEnabled = true,
                UseSystemCredentials = false
            };
            
            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(AI_Providers.AddAiProvider_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/users/{userId}/ai/providers";
            
            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_Providers.CommonResponses_Single)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            AiProviderResource? response = await executor.AddAiProvider(userId, request);
            
            Assert_AiProvider(response);
        }
        
        [Fact]
        public async Task GetAiProvider()
        {
            const int userId = 1;
            const int aiProviderId = 2;
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/users/{userId}/ai/providers/{aiProviderId}";
            
            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_Providers.CommonResponses_Single)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            AiProviderResource? response = await executor.GetAiProvider(userId, aiProviderId);
            
            Assert_AiProvider(response);
        }
        
        [Fact]
        public async Task DeleteAiProvider()
        {
            const int userId = 1;
            const int aiProviderId = 2;
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/users/{userId}/ai/providers/{aiProviderId}";
            
            mockClient
                .Setup(client => client.SendDeleteRequest(url, null))
                .ReturnsAsync(HttpStatusCode.NoContent);
            
            var executor = new AiApiExecutor(mockClient.Object);
            await executor.DeleteAiProvider(userId, aiProviderId);
        }
        
        [Fact]
        public async Task EditAiProvider()
        {
            const int userId = 1;
            const int aiProviderId = 2;
            
            var request = new[]
            {
                new AiProviderPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = AiProviderPatchPath.Name,
                    Value = "OpenAI"
                },
                new AiProviderPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = AiProviderPatchPath.Type,
                    Value = AiProviderType.OpenAi
                }
            };
            
            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(AI_Providers.EditAiProvider_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);
            
            var mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/users/{userId}/ai/providers/{aiProviderId}";
            
            mockClient
                .Setup(client => client.SendPatchRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_Providers.CommonResponses_Single)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            AiProviderResource? response = await executor.EditAiProvider(userId, aiProviderId, request);
            
            Assert_AiProvider(response);
        }
        
        [Fact]
        public async Task ListAiProviderModels()
        {
            const int userId = 1;
            const int aiProviderId = 2;
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/users/{userId}/ai/providers/{aiProviderId}/models";
            
            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_Providers.ListAiProviderModels_Response)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            ResponseList<AiProviderModelResource>? response = await executor.ListAiProviderModels(userId, aiProviderId);
            
            AiProviderModelResource? model = response?.Data?.FirstOrDefault();
            ArgumentNullException.ThrowIfNull(model);
            
            Assert.Equal("gpt-3.5-turbo-instruct", model.Id);
        }
        
        #endregion
        
        #region Enterprise
        
        [Fact]
        public async Task ListAiProvidersEnterprise()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            const string url = "/ai/providers";
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();
            
            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_Providers.CommonResponses_Multi)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            ResponseList<AiProviderResource>? response = await executor.ListAiProviders(userId: null);
            
            Assert_AiProvider(response?.Data?.FirstOrDefault());
        }
        
        [Fact]
        public async Task AddAiProviderEnterprise()
        {
            var request = new AddAiProviderRequest()
            {
                Name = "OpenAI",
                Type = AiProviderType.OpenAi,
                Credentials = new OpenAiProviderCredentials
                {
                    ApiKey = "string"
                },
                Configuration = new AiProviderConfiguration
                {
                    ActionRules = new List<ActionRule>
                    {
                        new ActionRule
                        {
                            Action = AiPromptAction.PreTranslate,
                            AvailableAiModelIds = new List<string>
                            {
                                "gpt-3.5-turbo-instruct"
                            }
                        }
                    }
                },
                IsEnabled = true,
                UseSystemCredentials = false
            };
            
            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(AI_Providers.AddAiProvider_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            const string url = "/ai/providers";
            
            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_Providers.CommonResponses_Single)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            AiProviderResource? response = await executor.AddAiProvider(userId: null, request);
            
            Assert_AiProvider(response);
        }
        
        [Fact]
        public async Task GetAiProviderEnterprise()
        {
            const int aiProviderId = 1;
            
            var mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/ai/providers/{aiProviderId}";
            
            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_Providers.CommonResponses_Single)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            AiProviderResource? response = await executor.GetAiProvider(userId: null, aiProviderId);
            
            Assert_AiProvider(response);
        }
        
        [Fact]
        public async Task DeleteAiProviderEnterprise()
        {
            const int aiProviderId = 1;
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/ai/providers/{aiProviderId}";
            
            mockClient
                .Setup(client => client.SendDeleteRequest(url, null))
                .ReturnsAsync(HttpStatusCode.NoContent);
            
            var executor = new AiApiExecutor(mockClient.Object);
            await executor.DeleteAiProvider(userId: null, aiProviderId);
        }
        
        [Fact]
        public async Task EditAiProviderEnterprise()
        {
            const int aiProviderId = 1;
            
            AiProviderPatch[] request = Array.Empty<AiProviderPatch>();
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/ai/providers/{aiProviderId}";
            
            mockClient
                .Setup(client => client.SendPatchRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_Providers.CommonResponses_Single)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            AiProviderResource? response = await executor.EditAiProvider(userId: null, aiProviderId, request);
            
            Assert_AiProvider(response);
        }
        
        [Fact]
        public async Task ListAiProviderModelsEnterprise()
        {
            const int aiProviderId = 1;
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/ai/providers/{aiProviderId}/models";
            
            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_Providers.ListAiProviderModels_Response)
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            ResponseList<AiProviderModelResource>? response =
                await executor.ListAiProviderModels(userId: null, aiProviderId);
            
            AiProviderModelResource? model = response?.Data.FirstOrDefault();
            ArgumentNullException.ThrowIfNull(model);
            
            Assert.Equal("gpt-3.5-turbo-instruct", model.Id);
        }
        
        #endregion
        
        private static void Assert_AiProvider(AiProviderResource? aiProvider)
        {
            Assert.NotNull(aiProvider);
            ArgumentNullException.ThrowIfNull(aiProvider);
            
            Assert.Equal(2, aiProvider.Id);
            Assert.Equal("OpenAI", aiProvider.Name);
            Assert.Equal(AiProviderType.OpenAi, aiProvider.Type);
            Assert.True(aiProvider.IsEnabled);
            Assert.False(aiProvider.UseSystemCredentials);
            Assert.Equal(DateTimeOffset.Parse("2019-09-20T11:11:05+00:00"), aiProvider.CreatedAt);
            Assert.Equal(DateTimeOffset.Parse("2019-09-20T12:22:20+00:00"), aiProvider.UpdatedAt);
            
            ActionRule? actionRule = aiProvider.Config?.ActionRules?.FirstOrDefault();
            ArgumentNullException.ThrowIfNull(actionRule);
            
            Assert.Equal(AiPromptAction.PreTranslate, actionRule.Action);
            Assert.Equal(new[]
            {
                "gpt-3.5-turbo-instruct"
            }, actionRule.AvailableAiModelIds);
        }
    }
}