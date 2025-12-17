using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.AI;
using Crowdin.Api.Core;
using Crowdin.Api.UnitTesting.Resources;

namespace Crowdin.Api.UnitTesting.Tests.AI
{
    public class AiSupportedModelsApiTests
    {
        [Fact]
        public async Task ListSupportedAiProviderModels()
        {
            const int userId = 1;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/ai/providers/supported-models";
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();

            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_Providers.ListSupportedAiProviderModels_Response)
                });

            var executor = new AiApiExecutor(mockClient.Object);
            ResponseList<AiSupportedProviderModel>? response = await executor.ListSupportedAiProviderModels(userId);

            Assert.NotNull(response);
            Assert.Single(response.Data);
        }
        
    }
}