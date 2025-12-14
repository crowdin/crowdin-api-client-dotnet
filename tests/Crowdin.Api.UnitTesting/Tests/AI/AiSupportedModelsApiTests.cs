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
        #region Crowdin

        [Fact]
        public async Task ListSupportedAiProviderModels()
        {
            const int userId = 1;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/ai/providers/supported-models/crowdin";
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

        #endregion

        #region Enterprise

        [Fact]
        public async Task ListSupportedAiProviderModelsEnterprise()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            const string url = "/ai/providers/supported-models/enterprise";
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();

            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_Providers.ListSupportedAiProviderModels_Response)
                });

            var executor = new AiApiExecutor(mockClient.Object);
            ResponseList<AiSupportedProviderModel>? response = await executor.ListSupportedAiProviderModelsEnterprise(userId: null);

            Assert.NotNull(response);
            Assert.Single(response.Data);
        }

        #endregion
    }
}