using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using Crowdin.Api.UnitTesting.Resources;
using Crowdin.Api.Users;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using UserFixtures = Crowdin.Api.UnitTesting.Resources.Users;

namespace Crowdin.Api.UnitTesting.Tests.Users
{
    public class UserProjectApiTests
    {
        [Fact]
        public async Task ListUserProjectPermissionsParsesRolesProjectAndTeams()
        {
            IDictionary<string, string> queryParams = new Dictionary<string, string>
            {
                ["limit"] = "25",
                ["offset"] = "0"
            };
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient.Setup(client => client.SendGetRequest("/users/4/projects/permissions", queryParams))
                .ReturnsAsync(ApiResult("ListUserProjectPermissions"));

            var executor = new UsersApiExecutor(mockClient.Object);
            ResponseList<UserProjectPermissions> response = await executor.ListUserProjectPermissions(4);

            Assert.Single(response.Data);
            UserProjectPermissions permission = response.Data[0];
            Assert.Equal(27, permission.Id);
            Assert.Equal("manager", permission.Roles[0].Name);
            Assert.Equal(new long[] { 3 }, permission.Roles[0].Permissions.LanguagesAccess["uk"].WorkflowStepIds);
            Assert.Equal("Project Seven", permission.Project.Name);
            Assert.Equal(13, permission.Teams[0].Id);
            Assert.Equal("Review Team", permission.Teams[0].Name);
            Assert.Equal(4, permission.Teams[0].TotalMembers);
        }

        [Fact]
        public async Task EditUserProjectPermissionsUsesPatchBodyWithoutPaginationQuery()
        {
            ProjectPermissionsMassOperation[] operations =
            {
                ProjectPermissionsMassOperation.Remove(7)
            };
            AssertRequest(operations, "EditUserProjectPermissions");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient.Setup(client => client.SendPatchRequest("/users/4/projects/permissions", operations, null))
                .ReturnsAsync(ApiResult("EditUserProjectPermissions"));

            var executor = new UsersApiExecutor(mockClient.Object);
            ResponseList<UserProjectPermissions> response = await executor.EditUserProjectPermissions(4, operations);

            Assert.Single(response.Data);
            Assert.Equal(27, response.Data[0].Id);
            Assert.Equal("manager", response.Data[0].Roles[0].Name);
            Assert.Empty(response.Data[0].Teams);
        }

        [Fact]
        public async Task ListUserProjectContributionsParsesContributionCounts()
        {
            IDictionary<string, string> queryParams = new Dictionary<string, string>
            {
                ["limit"] = "25",
                ["offset"] = "0"
            };
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient.Setup(client => client.SendGetRequest("/users/4/projects/contributions", queryParams))
                .ReturnsAsync(ApiResult("ListUserProjectContributions"));

            var executor = new UsersApiExecutor(mockClient.Object);
            ResponseList<UserProjectContribution> response = await executor.ListUserProjectContributions(4);

            Assert.Single(response.Data);
            Assert.Equal(7, response.Data[0].Project.Id);
            Assert.Equal(12, response.Data[0].Translated.Strings);
            Assert.Equal(340, response.Data[0].Translated.Words);
            Assert.Equal(8, response.Data[0].Approved.Strings);
            Assert.Equal(5, response.Data[0].Voted.Strings);
            Assert.Equal(2, response.Data[0].Commented.Strings);
        }

        private static CrowdinApiResult ApiResult(string key)
        {
            return new CrowdinApiResult
            {
                StatusCode = HttpStatusCode.OK,
                JsonObject = (JObject)JObject.Parse(UserFixtures.ApiResponses)[key]!
            };
        }

        private static void AssertRequest(object request, string key)
        {
            JToken expected = JObject.Parse(UserFixtures.ApiRequests)[key]!;
            JToken actual = JToken.Parse(JsonConvert.SerializeObject(request, TestUtils.CreateJsonSerializerOptions()));
            Assert.True(JToken.DeepEquals(expected, actual), $"Request {key} did not match its fixture.");
        }
    }
}
