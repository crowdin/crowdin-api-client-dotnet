
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Crowdin.Api.Core;
using Crowdin.Api.Storage;
using Moq;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Crowdin.Api.UnitTesting.Tests.Storage
{
    public class StorageApiTests
    {
        [Fact]
        public async Task ListStorages()
        {
            string responseJson = Resources.Storage.ListStorages;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();

            mockClient
                .Setup(client => client.SendGetRequest("/storages", queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(responseJson)
                });

            var storageApi = new StorageApiExecutor(mockClient.Object);
            ResponseList<StorageResource> response = await storageApi.ListStorages();

            Assert.NotEmpty(response.Data);
            Assert.Equal(0, response.Pagination?.Offset);
        }

        [Fact]
        public async Task DeleteStorage_Success()
        {
            const long storageId = 1;
            var mockClient = new Mock<ICrowdinApiClient>();

            mockClient
                .Setup(client => client.SendDeleteRequest($"/storages/{storageId}", null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            var storageApi = new StorageApiExecutor(mockClient.Object);
            await storageApi.DeleteStorage(storageId);
        }

        [Fact]
        public async Task DeleteStorage_Fail()
        {
            const long storageId = 1;
            var mockClient = new Mock<ICrowdinApiClient>();

            mockClient
                .Setup(client => client.SendDeleteRequest($"/storages/{storageId}", null))
                .ReturnsAsync(HttpStatusCode.OK);

            var storageApi = new StorageApiExecutor(mockClient.Object);
            await Assert.ThrowsAsync<CrowdinApiException>(() => storageApi.DeleteStorage(storageId));
        }

        [Fact]
        public async Task AddStorage_Success()
        {
            const long storageId = 2149231454;
            string fileName = @"umbrella_app.xliff";
            string responseJson = Resources.Storage.AddStorageResponse;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.UploadFile("/storages", fileName, It.IsAny<Stream>()))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(responseJson)
                });

            var storageApi = new StorageApiExecutor(mockClient.Object);
            using var stream = new MemoryStream();
            StorageResource response = await storageApi.AddStorage(stream, fileName);

            Assert.NotNull(response);
            Assert.Equal(storageId, response.Id);
            Assert.Equal(fileName, response.FileName);
        }
    }
}