using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Applications;
using Crowdin.Api.Core;
using Crowdin.Api.UnitTesting.Resources;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using ApplicationFixtures = Crowdin.Api.UnitTesting.Resources.Applications;

namespace Crowdin.Api.UnitTesting.Tests.Applications
{
    public class ApplicationsStorageApiTests
    {
        private const string ApplicationIdentifier = "example-app";

        [Fact]
        public async Task GetApplicationInstallationUpdate()
        {
            const string url = "/applications/installations/example-app/update";
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient.Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(ApiResult("GetApplicationInstallationUpdate"));

            var executor = new ApplicationsApiExecutor(mockClient.Object);
            ApplicationInstallationUpdate response = await executor.GetApplicationInstallationUpdate(ApplicationIdentifier);

            Assert.Equal("old-hash", response.ManifestHash);
            Assert.Equal("2.0.0", response.LatestManifest!["version"]!.Value<string>());
            Assert.True(response.HasChanges);
            Assert.Equal("ai", response.AddedScopes![0]);
            Assert.Equal("project", response.RemovedScopes![0]);
            Assert.Equal("sync", response.ChangedModules![0]["key"]!.Value<string>());
            Assert.False(response.ChangedModules[0]["from"]!["enabled"]!.Value<bool>());
            Assert.True(response.ChangedModules[0]["to"]!["enabled"]!.Value<bool>());
            Assert.Equal("true", response.ChangedEvents!["file.updated"]!.To);
        }

        [Fact]
        public async Task ApplyApplicationInstallationUpdate()
        {
            var request = new ApplyApplicationInstallationUpdateRequest { ManifestHash = "hash" };
            AssertRequest(request, "ApplyApplicationInstallationUpdate");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient.Setup(client => client.SendPostRequest("/applications/installations/example-app/update", request, null))
                .ReturnsAsync(ApiResult("ApplyApplicationInstallationUpdate"));

            var executor = new ApplicationsApiExecutor(mockClient.Object);
            Application response = await executor.ApplyApplicationInstallationUpdate(ApplicationIdentifier, request);

            Assert.Equal(ApplicationIdentifier, response.Identifier);
            Assert.Equal("Updated Application", response.Name);
            Assert.False(response.LimitReached);
        }

        [Fact]
        public async Task UploadApplicationBundle()
        {
            var request = new UploadApplicationBundleRequest { StorageId = 1 };
            AssertRequest(request, "UploadApplicationBundle");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient.Setup(client => client.SendPostRequest("/applications/installations/example-app/bundles", request, null))
                .ReturnsAsync(ApiResult("UploadApplicationBundle"));

            var executor = new ApplicationsApiExecutor(mockClient.Object);
            Application response = await executor.UploadApplicationBundle(ApplicationIdentifier, request);

            Assert.Equal("Bundled Application", response.Name);
            Assert.Equal("https://example.test/manifest.json", response.ManifestUrl);
        }

        [Fact]
        public async Task ListApplicationKvRecords()
        {
            IDictionary<string, string> queryParams = new Dictionary<string, string>
            {
                ["limit"] = "25",
                ["offset"] = "0",
                ["prefix"] = "a:"
            };
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient.Setup(client => client.SendGetRequest("/applications/example-app/storage/kv/records", queryParams))
                .ReturnsAsync(ApiResult("ListApplicationKvRecords"));

            var executor = new ApplicationsApiExecutor(mockClient.Object);
            ResponseList<ApplicationKvRecord> response = await executor.ListApplicationKvRecords(ApplicationIdentifier, "a:");

            Assert.Single(response.Data);
            Assert.Equal("a:b", response.Data[0].Key);
            Assert.Equal("list-value", response.Data[0].Value!.Value<string>());
            Assert.False(response.Data[0].Secret);
        }

        [Fact]
        public async Task AddApplicationKvRecord()
        {
            var request = new AddApplicationKvRecordRequest
            {
                Key = "a:b",
                Value = JValue.CreateString("value"),
                Secret = false
            };
            AssertRequest(request, "AddApplicationKvRecord");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient.Setup(client => client.SendPostRequest("/applications/example-app/storage/kv/records", request, null))
                .ReturnsAsync(ApiResult("AddApplicationKvRecord"));

            var executor = new ApplicationsApiExecutor(mockClient.Object);
            ApplicationKvRecord response = await executor.AddApplicationKvRecord(ApplicationIdentifier, request);

            Assert.Equal("a:b", response.Key);
            Assert.Equal("value", response.Value!.Value<string>());
            Assert.False(response.Secret);
        }

        [Fact]
        public async Task GetApplicationKvRecordEscapesTheKey()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient.Setup(client => client.SendGetRequest("/applications/example-app/storage/kv/records/a%3Ab", null))
                .ReturnsAsync(ApiResult("GetApplicationKvRecord"));

            var executor = new ApplicationsApiExecutor(mockClient.Object);
            ApplicationKvRecord response = await executor.GetApplicationKvRecord(ApplicationIdentifier, "a:b");

            Assert.Equal("a:b", response.Key);
            Assert.True(response.Secret);
            Assert.True(response.Value!["nested"]!.Value<bool>());
        }

        [Fact]
        public async Task EditApplicationKvRecordEscapesTheKeyAndSerializesPatch()
        {
            var patches = new[]
            {
                new ApplicationKvRecordPatch
                {
                    Op = PatchOperation.Replace,
                    Path = ApplicationKvRecordPatchPath.Value,
                    Value = JValue.CreateString("updated")
                }
            };
            AssertRequest(patches, "EditApplicationKvRecord");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient.Setup(client => client.SendPatchRequest("/applications/example-app/storage/kv/records/a%3Ab", patches, null))
                .ReturnsAsync(ApiResult("EditApplicationKvRecord"));

            var executor = new ApplicationsApiExecutor(mockClient.Object);
            ApplicationKvRecord response = await executor.EditApplicationKvRecord(ApplicationIdentifier, "a:b", patches);

            Assert.Equal("updated", response.Value!.Value<string>());
            Assert.True(response.Secret);
        }

        [Fact]
        public async Task DeleteApplicationKvRecordEscapesTheKey()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient.Setup(client => client.SendDeleteRequest("/applications/example-app/storage/kv/records/a%3Ab", null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            var executor = new ApplicationsApiExecutor(mockClient.Object);
            await executor.DeleteApplicationKvRecord(ApplicationIdentifier, "a:b");

            mockClient.Verify(client => client.SendDeleteRequest("/applications/example-app/storage/kv/records/a%3Ab", null), Times.Once);
        }

        private static CrowdinApiResult ApiResult(string key)
        {
            return new CrowdinApiResult
            {
                StatusCode = HttpStatusCode.OK,
                JsonObject = (JObject)JObject.Parse(ApplicationFixtures.ApiResponses)[key]!
            };
        }

        private static void AssertRequest(object request, string key)
        {
            JToken expected = JObject.Parse(ApplicationFixtures.ApiRequests)[key]!;
            JToken actual = JToken.Parse(JsonConvert.SerializeObject(request, TestUtils.CreateJsonSerializerOptions()));
            Assert.True(JToken.DeepEquals(expected, actual), $"Request {key} did not match its fixture.");
        }
    }
}
