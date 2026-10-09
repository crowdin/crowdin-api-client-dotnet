using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using Crowdin.Api.Placeholders;
using Crowdin.Api.UnitTesting.Resources;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using PlaceholderFixtures = Crowdin.Api.UnitTesting.Resources.Placeholders;

namespace Crowdin.Api.UnitTesting.Tests.Placeholders
{
    public class PlaceholdersApiTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task ListSystemPlaceholders()
        {
            const long projectId = 7;
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest($"/projects/{projectId}/system-placeholders", queryParams))
                .ReturnsAsync(ApiResult("ListSystemPlaceholders"));

            var executor = new PlaceholdersApiExecutor(mockClient.Object);
            ResponseList<SystemPlaceholder> response = await executor.ListSystemPlaceholders(projectId);

            Assert.Single(response.Data);
            Assert.Equal(SystemPlaceholderKey.WrappedAmpersand, response.Data[0].Id);
            Assert.True(response.Data[0].IsEnabled);
            Assert.Equal("Wrapped ampersand", response.Data[0].Label);
            Assert.Equal("&name&", response.Data[0].Examples[0]);
        }

        [Fact]
        public async Task SystemPlaceholdersBatchOperations()
        {
            const long projectId = 7;
            var patches = new[] { SystemPlaceholdersBatchPatch.ForKey(SystemPlaceholderKey.WrappedAmpersand, false) };
            AssertRequest(patches, "SystemPlaceholdersBatchOperations");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendPatchRequest($"/projects/{projectId}/system-placeholders", patches, null))
                .ReturnsAsync(ApiResult("SystemPlaceholdersBatchOperations"));

            var executor = new PlaceholdersApiExecutor(mockClient.Object);
            SystemPlaceholder[] response = await executor.SystemPlaceholdersBatchOperations(projectId, patches);

            Assert.Single(response);
            Assert.Equal(SystemPlaceholderKey.WrappedAmpersand, response[0].Id);
            Assert.False(response[0].IsEnabled);
        }

        [Fact]
        public async Task ListCustomPlaceholders()
        {
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest("/custom-placeholders", queryParams))
                .ReturnsAsync(ApiResult("ListCustomPlaceholders"));

            var executor = new PlaceholdersApiExecutor(mockClient.Object);
            ResponseList<CustomPlaceholder> response = await executor.ListCustomPlaceholders();

            Assert.Single(response.Data);
            Assert.Equal(2, response.Data[0].Id);
            Assert.Equal("%name%", response.Data[0].Definition);
            Assert.Equal("Name placeholder", response.Data[0].Description);
            Assert.Equal("\"", response.Data[0].ArgumentDelimiter);
        }

        [Fact]
        public async Task AddCustomPlaceholder()
        {
            var request = new AddCustomPlaceholderRequest
            {
                Definition = "%name%",
                Description = "Name placeholder",
                ArgumentDelimiter = "\""
            };
            AssertRequest(request, "AddCustomPlaceholder");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendPostRequest("/custom-placeholders", request, null))
                .ReturnsAsync(ApiResult("AddCustomPlaceholder"));

            var executor = new PlaceholdersApiExecutor(mockClient.Object);
            CustomPlaceholder response = await executor.AddCustomPlaceholder(request);

            Assert.Equal(2, response.Id);
            Assert.Equal("%name%", response.Definition);
            Assert.Equal("Name placeholder", response.Description);
        }

        [Fact]
        public async Task GetCustomPlaceholder()
        {
            const long customPlaceholderId = 3;
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest($"/custom-placeholders/{customPlaceholderId}", null))
                .ReturnsAsync(ApiResult("GetCustomPlaceholder"));

            var executor = new PlaceholdersApiExecutor(mockClient.Object);
            CustomPlaceholder response = await executor.GetCustomPlaceholder(customPlaceholderId);

            Assert.Equal(customPlaceholderId, response.Id);
            Assert.Equal("%email%", response.Definition);
            Assert.Equal("Email placeholder", response.Description);
        }

        [Fact]
        public async Task EditCustomPlaceholder()
        {
            const long customPlaceholderId = 2;
            var patches = new[]
            {
                new CustomPlaceholderPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = CustomPlaceholderPatchPath.Description,
                    Value = "Updated name placeholder"
                }
            };
            AssertRequest(patches, "EditCustomPlaceholder");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendPatchRequest($"/custom-placeholders/{customPlaceholderId}", patches, null))
                .ReturnsAsync(ApiResult("EditCustomPlaceholder"));

            var executor = new PlaceholdersApiExecutor(mockClient.Object);
            CustomPlaceholder response = await executor.EditCustomPlaceholder(customPlaceholderId, patches);

            Assert.Equal(customPlaceholderId, response.Id);
            Assert.Equal("Updated name placeholder", response.Description);
        }

        [Fact]
        public async Task DeleteCustomPlaceholder()
        {
            const long customPlaceholderId = 2;
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendDeleteRequest($"/custom-placeholders/{customPlaceholderId}", null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            var executor = new PlaceholdersApiExecutor(mockClient.Object);
            await executor.DeleteCustomPlaceholder(customPlaceholderId);

            mockClient.Verify(client => client.SendDeleteRequest($"/custom-placeholders/{customPlaceholderId}", null), Times.Once);
        }

        [Fact]
        public async Task ListProjectPlaceholders()
        {
            const long projectId = 7;
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest($"/projects/{projectId}/placeholders", queryParams))
                .ReturnsAsync(ApiResult("ListProjectPlaceholders"));

            var executor = new PlaceholdersApiExecutor(mockClient.Object);
            ResponseList<ProjectPlaceholder> response = await executor.ListProjectPlaceholders(projectId);

            Assert.Single(response.Data);
            Assert.Equal(3, response.Data[0].Id);
            Assert.Equal(2, response.Data[0].CustomPlaceholderId);
            Assert.Equal(ProjectPlaceholderType.Low, response.Data[0].Type);
            Assert.Equal(new[] { "json", "yaml" }, response.Data[0].Formats);
        }

        [Fact]
        public async Task AddProjectPlaceholder()
        {
            const long projectId = 7;
            var request = new AddProjectPlaceholderRequest
            {
                CustomPlaceholderId = 2,
                Type = ProjectPlaceholderType.Low,
                Index = 1,
                IsBlocking = false,
                Formats = new[] { "json", "yaml" }
            };
            AssertRequest(request, "AddProjectPlaceholder");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendPostRequest($"/projects/{projectId}/placeholders", request, null))
                .ReturnsAsync(ApiResult("AddProjectPlaceholder"));

            var executor = new PlaceholdersApiExecutor(mockClient.Object);
            ProjectPlaceholder response = await executor.AddProjectPlaceholder(projectId, request);

            Assert.Equal(3, response.Id);
            Assert.Equal(2, response.CustomPlaceholderId);
            Assert.Equal(ProjectPlaceholderType.Low, response.Type);
            Assert.False(response.IsBlocking);
        }

        [Fact]
        public async Task GetProjectPlaceholder()
        {
            const long projectId = 7;
            const long projectPlaceholderId = 3;
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest($"/projects/{projectId}/placeholders/{projectPlaceholderId}", null))
                .ReturnsAsync(ApiResult("GetProjectPlaceholder"));

            var executor = new PlaceholdersApiExecutor(mockClient.Object);
            ProjectPlaceholder response = await executor.GetProjectPlaceholder(projectId, projectPlaceholderId);

            Assert.Equal(projectPlaceholderId, response.Id);
            Assert.Equal(2, response.CustomPlaceholderId);
            Assert.Equal(ProjectPlaceholderType.High, response.Type);
            Assert.Equal(2, response.Index);
            Assert.True(response.IsBlocking);
        }

        [Fact]
        public async Task EditProjectPlaceholder()
        {
            const long projectId = 7;
            const long projectPlaceholderId = 3;
            var patches = new[]
            {
                new ProjectPlaceholderPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = ProjectPlaceholderPatchPath.Index,
                    Value = 4
                }
            };
            AssertRequest(patches, "EditProjectPlaceholder");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendPatchRequest($"/projects/{projectId}/placeholders/{projectPlaceholderId}", patches, null))
                .ReturnsAsync(ApiResult("EditProjectPlaceholder"));

            var executor = new PlaceholdersApiExecutor(mockClient.Object);
            ProjectPlaceholder response = await executor.EditProjectPlaceholder(projectId, projectPlaceholderId, patches);

            Assert.Equal(projectPlaceholderId, response.Id);
            Assert.Equal(4, response.Index);
            Assert.True(response.IsBlocking);
            Assert.Equal(new[] { "json", "yaml" }, response.Formats);
        }

        [Fact]
        public async Task DeleteProjectPlaceholder()
        {
            const long projectId = 7;
            const long projectPlaceholderId = 3;
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendDeleteRequest($"/projects/{projectId}/placeholders/{projectPlaceholderId}", null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            var executor = new PlaceholdersApiExecutor(mockClient.Object);
            await executor.DeleteProjectPlaceholder(projectId, projectPlaceholderId);

            mockClient.Verify(client => client.SendDeleteRequest($"/projects/{projectId}/placeholders/{projectPlaceholderId}", null), Times.Once);
        }

        private static CrowdinApiResult ApiResult(string key)
        {
            return new CrowdinApiResult
            {
                StatusCode = HttpStatusCode.OK,
                JsonObject = (JObject)JObject.Parse(PlaceholderFixtures.ApiResponses)[key]!
            };
        }

        private static void AssertRequest(object request, string key)
        {
            JToken expected = JObject.Parse(PlaceholderFixtures.ApiRequests)[key]!;
            JToken actual = JToken.Parse(JsonConvert.SerializeObject(request, JsonSettings));
            Assert.True(JToken.DeepEquals(expected, actual), $"Request {key} did not match its fixture.");
        }
    }
}
