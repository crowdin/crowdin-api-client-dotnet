using Crowdin.Api.Core;
using Crowdin.Api.SourceFiles;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Crowdin.Api.UnitTesting.Tests.SourceFiles
{
    public class AssetReferenceTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();
        private const int projectId = 1;
        private const int fileId = 1;
        private const int referenceId = 123;

        [Fact]
        public async Task ListAssetReferences()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();

            mockClient
                .Setup(client => client.SendGetRequest($"/projects/{projectId}/files/{fileId}/references", queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.SourceFiles.ListAssetReference_Response)
                });

            SourceFilesApiExecutor executor = new(mockClient.Object);
            var result = await executor.ListAssetReferences(projectId, fileId);

            Assert.NotNull(result);
            Assert.IsType<ResponseList<AssetReference>>(result);
            Assert.Single(result.Data);
        }

        [Fact]
        public async Task AddAssetReference()
        {
            var request = new AddAssetReferenceRequest()
            {
                StorageId = 67890,
                Name = "design_reference.png",
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(Resources.SourceFiles.AddAssetReference_Request, JsonSettings);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPostRequest($"/projects/{projectId}/files/{fileId}/references", request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(Resources.SourceFiles.AddAssetReference_Response)
                });

            SourceFilesApiExecutor executor = new(mockClient.Object);
            var result = await executor.AddAssetReference(projectId, fileId, request);

            Assert.NotNull(result);
            Assert.IsType<AssetReference>(result);
            Assert.Equal("design_reference.png", result.Name);
        }

        [Fact]
        public async Task GetAssetReference()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendGetRequest($"/projects/{projectId}/files/{fileId}/references/{referenceId}", null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.SourceFiles.GetAssetReference_Response)
                });

            SourceFilesApiExecutor executor = new(mockClient.Object);
            var result = await executor.GetAssetReference(projectId, fileId, referenceId);

            Assert.NotNull(result);
            Assert.IsType<AssetReference>(result);
            Assert.Equal("design_reference.png", result.Name);
        }

        [Fact]
        public async Task DeleteAssetReference()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendDeleteRequest($"/projects/{projectId}/files/{fileId}/references/{referenceId}", null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            SourceFilesApiExecutor executor = new(mockClient.Object);

            try
            {
                await executor.DeleteAssetReference(projectId, fileId, referenceId);
            }
            catch (CrowdinApiException e)
            {
                Assert.True(false, e.Message);
            }

            Assert.True(true);
        }

        [Fact]
        public async Task DeleteAssetReference_ShouldFail()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendDeleteRequest($"/projects/{projectId}/files/{fileId}/references/{referenceId}", null))
                .ReturnsAsync(HttpStatusCode.Unauthorized);

            SourceFilesApiExecutor executor = new(mockClient.Object);

            await Assert.ThrowsAsync<CrowdinApiException>(async () => await executor.DeleteAssetReference(projectId, fileId, referenceId));
        }
    }
}
