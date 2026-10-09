using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using Crowdin.Api.Teams;
using Crowdin.Api.UnitTesting.Resources;
using Crowdin.Api.Users;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using TeamFixtures = Crowdin.Api.UnitTesting.Resources.Teams;

namespace Crowdin.Api.UnitTesting.Tests.Teams
{
    public class TeamProjectPermissionsApiTests
    {
        [Fact]
        public async Task ListTeamProjectPermissionsParsesNestedRolesAndProject()
        {
            IDictionary<string, string> queryParams = new Dictionary<string, string>
            {
                ["limit"] = "25",
                ["offset"] = "0"
            };
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient.Setup(client => client.SendGetRequest("/teams/9/projects/permissions", queryParams))
                .ReturnsAsync(ApiResult("ListTeamProjectPermissions"));

            var executor = new TeamsApiExecutor(mockClient.Object);
            ResponseList<TeamProjectPermissions> response = await executor.ListTeamProjectPermissions(9);

            Assert.Single(response.Data);
            TeamProjectPermissions permission = response.Data[0];
            Assert.Equal(27, permission.Id);
            Assert.Equal("manager", permission.Roles[0].Name);
            Assert.False(permission.Roles[0].Permissions.AllLanguages);
            Assert.Equal(new long[] { 3 }, permission.Roles[0].Permissions.LanguagesAccess["uk"].WorkflowStepIds);
            Assert.Equal(7, permission.Project.Id);
            Assert.Equal("Project Seven", permission.Project.Name);
            Assert.Equal(new[] { "uk" }, permission.Project.TargetLanguageIds);
        }

        [Fact]
        public async Task EditTeamProjectPermissionsUsesPatchBodyWithoutPaginationQuery()
        {
            ProjectPermissionsMassOperation[] operations =
            {
                ProjectPermissionsMassOperation.Remove(7)
            };
            AssertRequest(operations, "EditTeamProjectPermissions");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient.Setup(client => client.SendPatchRequest("/teams/9/projects/permissions", operations, null))
                .ReturnsAsync(ApiResult("EditTeamProjectPermissions"));

            var executor = new TeamsApiExecutor(mockClient.Object);
            ResponseList<TeamProjectPermissions> response = await executor.EditTeamProjectPermissions(9, operations);

            Assert.Single(response.Data);
            Assert.Equal(27, response.Data[0].Id);
            Assert.Equal("manager", response.Data[0].Roles[0].Name);
            Assert.Equal("project-seven", response.Data[0].Project.Identifier);
        }

        private static CrowdinApiResult ApiResult(string key)
        {
            return new CrowdinApiResult
            {
                StatusCode = HttpStatusCode.OK,
                JsonObject = (JObject)JObject.Parse(TeamFixtures.ApiResponses)[key]!
            };
        }

        private static void AssertRequest(object request, string key)
        {
            JToken expected = JObject.Parse(TeamFixtures.ApiRequests)[key]!;
            JToken actual = JToken.Parse(JsonConvert.SerializeObject(request, TestUtils.CreateJsonSerializerOptions()));
            Assert.True(JToken.DeepEquals(expected, actual), $"Request {key} did not match its fixture.");
        }
    }
}
