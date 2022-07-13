
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using Crowdin.Api.Distributions;
using Crowdin.Api.Tests.Core;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Crowdin.Api.Tests.Distributions
{
    public class DistributionsApiTests
    {
        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();
        
        [Fact]
        public async Task AddDistribution()
        {
            const int projectId = 1;
            
            var request = new AddDistributionRequest
            {
                ExportMode = DistributionExportMode.Bundle,
                Name = "distribution 1",
                FileIds = new[] { 0 },
                Format = "crowdin-resx",
                ExportPattern = "strings-%two_letter_code%.resx",
                LabelIds = new[] { 0 }
            };
            
            string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Core.Resources.Distributions.AddDistribution_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

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
        
        [Fact]
        public void EditDistribution_RequestSerialization()
        {
            var patches = new[]
            {
                new DistributionPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = DistributionPatchPath.ExportMode,
                    Value = DistributionExportMode.Bundle
                },
                new DistributionPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = DistributionPatchPath.Name,
                    Value = "distribution 2"
                },
                new DistributionPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = DistributionPatchPath.FileIds,
                    Value = new[] { 123 }
                },
                new DistributionPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = DistributionPatchPath.Format,
                    Value = "crowdin-resx"
                },
                new DistributionPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = DistributionPatchPath.ExportPattern,
                    Value = "strings-%two_letters_code%.resx"
                },
                new DistributionPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = DistributionPatchPath.LabelIds,
                    Value = new[] { 321 }
                }
            };
            
            string actualRequestJson = JsonConvert.SerializeObject(patches, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Core.Resources.Distributions.EditDistribution_Request_AllPaths);
            
            Assert.Equal(expectedRequestJson, actualRequestJson);
        }
    }
}