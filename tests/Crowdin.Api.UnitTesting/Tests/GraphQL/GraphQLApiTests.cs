
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Core;
using Crowdin.Api.GraphQL;

namespace Crowdin.Api.UnitTesting.Tests.GraphQL
{
    public class GraphQLApiTests
    {
        [Fact]
        public async Task SimpleQuery()
        {
            var request = new GraphQLRequest
            {
                Query = Resources.GraphQL.Request
            };
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendGraphQLRequest(request))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.GraphQL.Response)
                });

            var executor = new GraphQLApiExecutor(mockClient.Object);
            JObject? response = await executor.ExecuteQuery(request);
            
            Assert.NotNull(response);
            
            IEnumerable<string?>? actualProjectNames =
                response["data"]?["viewer"]?["projects"]?["edges"]?
                    .Select(edge => edge["node"]?["name"]?.Value<string>());
            ArgumentNullException.ThrowIfNull(actualProjectNames);
            
            Assert.Equal(
                expected:
                [
                    "TestProject-1",
                    "TestProject-2",
                    "TestProject-3"
                ],
                actual: actualProjectNames);
        }
    }
}