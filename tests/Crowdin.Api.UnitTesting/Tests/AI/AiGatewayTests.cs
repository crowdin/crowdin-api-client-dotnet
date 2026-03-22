
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.AI.Gateway;
using Crowdin.Api.Core;

namespace Crowdin.Api.UnitTesting.Tests.AI
{
    public class AiGatewayTests
    {
        [Fact]
        public async Task ExecuteGet()
        {
            const int userId = 1;
            const int aiProviderId = 2;
            const string path = "chat/completions";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/ai/providers/{aiProviderId}/gateway/{path}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse("{}")
                });
            
            var executor = new AiGatewayApiExecutor(mockClient.Object);
            JObject? response = await executor.ExecuteGet(userId, aiProviderId, path);
            Assert.NotNull(response);
        }
        
        [Fact]
        public async Task ExecutePost()
        {
            const int userId = 1;
            const int aiProviderId = 2;
            const string path = "chat/completions";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/ai/providers/{aiProviderId}/gateway/{path}";

            var request = new object();

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse("{}")
                });
            
            var executor = new AiGatewayApiExecutor(mockClient.Object);
            JObject? response = await executor.ExecutePost(userId, aiProviderId, path, request);
            Assert.NotNull(response);
        }
        
        [Fact]
        public async Task ExecutePut()
        {
            const int userId = 1;
            const int aiProviderId = 2;
            const string path = "chat/completions";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/ai/providers/{aiProviderId}/gateway/{path}";

            var request = new object();

            mockClient
                .Setup(client => client.SendPutRequest(url, request))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse("{}")
                });
            
            var executor = new AiGatewayApiExecutor(mockClient.Object);
            JObject? response = await executor.ExecutePut(userId, aiProviderId, path, request);
            Assert.NotNull(response);
        }
        
        [Fact]
        public async Task ExecuteDelete()
        {
            const int userId = 1;
            const int aiProviderId = 2;
            const string path = "chat/completions";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/ai/providers/{aiProviderId}/gateway/{path}";

            mockClient
                .Setup(client => client.SendDeleteRequest_FullResult(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse("{}")
                });
            
            var executor = new AiGatewayApiExecutor(mockClient.Object);
            JObject? response = await executor.ExecuteDelete(userId, aiProviderId, path);
            Assert.NotNull(response);
        }
        
        [Fact]
        public async Task ExecutePatch()
        {
            const int userId = 1;
            const int aiProviderId = 2;
            const string path = "chat/completions";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/ai/providers/{aiProviderId}/gateway/{path}";

            var request = new object();

            mockClient
                .Setup(client => client.SendPatchRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse("{}")
                });
            
            var executor = new AiGatewayApiExecutor(mockClient.Object);
            JObject? response = await executor.ExecutePatch(userId, aiProviderId, path, request);
            Assert.NotNull(response);
        }
    }
}