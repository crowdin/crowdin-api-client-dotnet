
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Core;
using Crowdin.Api.Teams;
using Crowdin.Api.UnitTesting.Resources;

namespace Crowdin.Api.UnitTesting.Tests.Teams
{
    public class GroupTeamsApiTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();
        
        [Fact]
        public async Task ListGroupTeams()
        {
            const int groupId = 1;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/groups/{groupId}/teams";

            var queryParams = new Dictionary<string, string>
            {
                ["orderBy"] = "createdAt desc,name"
            };

            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Teams_GroupTeams.CommonResponses_Multi)
                });

            var executor = new TeamsApiExecutor(mockClient.Object);
            
            ResponseList<GroupTeam> response = await executor.ListGroupTeams(
                groupId,
                orderBy:
                [
                    new SortingRule
                    {
                        Field = "createdAt",
                        Order = SortingOrder.Descending
                    },
                    new SortingRule
                    {
                        Field = "name"
                    }
                ]);
            
            Assert_GroupTeam(response.Data.First());
        }

        [Fact]
        public async Task UpdateGroupTeams()
        {
            const int groupId = 1;

            GroupTeamPatch[] patches =
            [
                GroupTeamPatch.Builder.CreateAddOperation(new
                {
                    teamId = 18
                }),
                GroupTeamPatch.Builder.CreateRemoveOperation(teamId: 24)
            ];
            
            string actualRequestJson = JsonConvert.SerializeObject(patches, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(Teams_GroupTeams.UpdateGroupTeams_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/groups/{groupId}/teams";

            mockClient
                .Setup(client => client.SendPatchRequest(url, patches, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Teams_GroupTeams.CommonResponses_Multi)
                });
            
            var executor = new TeamsApiExecutor(mockClient.Object);
            ResponseList<GroupTeam> response = await executor.UpdateGroupTeams(groupId, patches);
            
            Assert_GroupTeam(response.Data.First());
        }

        [Fact]
        public async Task GetGroupTeam()
        {
            const int groupId = 1;
            const int teamId = 2;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/groups/{groupId}/teams/{teamId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Teams_GroupTeams.CommonResponses_Single)
                });
            
            var executor = new TeamsApiExecutor(mockClient.Object);
            GroupTeam response = await executor.GetGroupTeam(groupId, teamId);
            
            Assert_GroupTeam(response);
        }

        private static void Assert_GroupTeam(GroupTeam? groupTeam)
        {
            ArgumentNullException.ThrowIfNull(groupTeam);
            ArgumentNullException.ThrowIfNull(groupTeam.Team);
            
            Assert.Equal(27, groupTeam.Id);
            
            Assert.Equal(2, groupTeam.Team.Id);
            Assert.Equal("Translators Team", groupTeam.Team.Name);
            Assert.Equal(8, groupTeam.Team.TotalMembers);
            Assert.Equal(DateTimeOffset.Parse("2019-09-23T09:04:29+00:00"), groupTeam.Team.CreatedAt);
            Assert.Equal(DateTimeOffset.Parse("2019-09-23T09:04:29+00:00"), groupTeam.Team.UpdatedAt);
        }
    }
}