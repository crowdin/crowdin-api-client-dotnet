
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using Crowdin.Api.Distributions;
using Crowdin.Api.Tests.Core;

using Moq;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Crowdin.Api.Tests.Distributions
{
    public class DistributionsApiTests
    {
        [Fact]
        public async Task AddDistribution()
        {
            const int projectId = 1;
            
            var request = new AddDistributionRequest
            {
                Name = "distribution 1",
                FileIds = new[] { 0 }
            };

            var url = $"/projects/{projectId}/distributions";
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(Core.Resources.Distributions.AddDistribution_Response)
                });

            var executor = new DistributionsApiExecutor(mockClient.Object);
            Distribution response = await executor.AddDistribution(projectId, request);
            
            Assert.NotNull(response);
            Assert.Contains(0, response.FileIds);
        }

        [Fact]
        public async Task EditDistribution()
        {
            const int projectId = 1;
            const string hash = "someHash";
            const string newName = "some name";
            
            var patches = new[]
            {
                new DistributionPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = DistributionPatchPath.Name,
                    Value = newName
                }
            };

            var url = $"/projects/{projectId}/distributions/{hash}";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPatchRequest(url, patches, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.Distributions.EditDistribution_Response)
                });

            var executor = new DistributionsApiExecutor(mockClient.Object);
            Distribution response = await executor.EditDistribution(projectId, hash, patches);
            
            Assert.NotNull(response);
            Assert.Equal(newName, response.Name);
        }
    }
}