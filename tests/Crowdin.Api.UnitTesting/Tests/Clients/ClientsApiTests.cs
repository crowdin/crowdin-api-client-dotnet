using Crowdin.Api.Clients;
using Crowdin.Api.Core;
using Moq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Crowdin.Api.UnitTesting.Tests.Clients
{
    public class ClientsApiTests
    {
        [Fact]
        public async Task ListClients()
        {
            const int clientId = 1;
            const string description = "John Smith Organization";


            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/clients";
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();

            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.Clients.ListClientsResponse)
                });

            var executor = new ClientsApiExecutor(mockClient.Object);
            ResponseList<Client>? response = await executor.ListClients();

            Assert.NotNull(response);
            Assert.Single(response.Data);
            Assert.IsType<Client>(response.Data[0]);
            Assert.Equal(response.Data[0].Id, clientId);
            Assert.Equal(response.Data[0].Description, description);
        }
    }
}
