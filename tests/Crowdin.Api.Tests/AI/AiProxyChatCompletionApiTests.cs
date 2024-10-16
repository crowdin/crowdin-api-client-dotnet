
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using Xunit;

using Crowdin.Api.AI;
using Crowdin.Api.Core;
using Crowdin.Api.Tests.Testing;
using Crowdin.Api.Tests.Testing.Resources;

namespace Crowdin.Api.Tests.AI
{
    public class AiProxyChatCompletionApiTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();
        
        [Fact]
        public async Task CreateAiProxyChatCompletion()
        {
            const int userId = 1;
            const int aiProviderId = 2;
            
            var request = new Dictionary<string, object>
            {
                ["model"] = "string"
            };
            
            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(AI_Misc.CreateAiProxyChatCompletion_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/users/{userId}/ai/providers/{aiProviderId}/chat/completions";
            
            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = new()
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            AiProxyChatCompletion? response =
                await executor.CreateAiProxyChatCompletion(userId, aiProviderId, request);
            
            Assert.NotNull(response);
        }
        
        [Fact]
        public async Task CreateAiProxyChatCompletionEnterprise()
        {
            const int aiProviderId = 1;
            
            var request = new Dictionary<string, object>
            {
                ["model"] = "string"
            };
            
            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(AI_Misc.CreateAiProxyChatCompletion_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/ai/providers/{aiProviderId}/chat/completions";
            
            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = new()
                });
            
            var executor = new AiApiExecutor(mockClient.Object);
            AiProxyChatCompletion? response =
                await executor.CreateAiProxyChatCompletion(userId: null, aiProviderId, request);
            
            Assert.NotNull(response);
        }
    }
}