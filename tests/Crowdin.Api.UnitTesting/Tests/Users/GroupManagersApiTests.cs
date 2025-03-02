
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
using Crowdin.Api.Users;

namespace Crowdin.Api.UnitTesting.Tests.Users
{
    public class GroupManagersApiTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task ListGroupManagers()
        {
            const int groupId = 1;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/groups/{groupId}/managers";

            var queryParams = new Dictionary<string, string>
            {
                ["teamIds"] = "1,2,18",
                ["orderBy"] = "createdAt desc,username"
            };

            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Users_GroupManagers.CommonResponses_Multi)
                });

            var executor = new UsersApiExecutor(mockClient.Object);
            
            ResponseList<GroupManager> response = await executor.ListGroupManagers(
                groupId,
                teamIds: [ 1, 2, 18 ],
                orderBy:
                [
                    new SortingRule
                    {
                        Field = "createdAt",
                        Order = SortingOrder.Descending
                    },
                    new SortingRule
                    {
                        Field = "username"
                    }
                ]);
            
            Assert_GroupManager(response.Data.First());
        }

        [Fact]
        public async Task UpdateGroupManagers()
        {
            const int groupId = 1;

            GroupManagerPatch[] patches =
            [
                GroupManagerPatch.Builder.CreateAddOperation(new
                {
                    userId = 18
                }),
                GroupManagerPatch.Builder.CreateRemoveOperation(userId: 24)
            ];
            
            string actualRequestJson = JsonConvert.SerializeObject(patches, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(Users_GroupManagers.UpdateGroupManagers_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/groups/{groupId}/managers";

            mockClient
                .Setup(client => client.SendPatchRequest(url, patches, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Users_GroupManagers.CommonResponses_Multi)
                });
            
            var executor = new UsersApiExecutor(mockClient.Object);
            ResponseList<GroupManager> response = await executor.UpdateGroupManagers(groupId, patches);
            
            Assert_GroupManager(response.Data.First());
        }

        [Fact]
        public async Task GetGroupManager()
        {
            const int groupId = 1;
            const int userId = 2;
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/groups/{groupId}/managers/{userId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Users_GroupManagers.CommonResponses_Single)
                });
            
            var executor = new UsersApiExecutor(mockClient.Object);
            GroupManager response = await executor.GetGroupManager(groupId, userId);
            
            Assert_GroupManager(response);
        }

        private static void Assert_GroupManager(GroupManager? manager)
        {
            ArgumentNullException.ThrowIfNull(manager);
            
            Assert.Equal(27, manager.Id);
            
            ArgumentNullException.ThrowIfNull(manager.User);
            ArgumentNullException.ThrowIfNull(manager.Teams);
            Array.ForEach(manager.Teams, team => ArgumentNullException.ThrowIfNull(team));
            
            Assert.Equal(12, manager.User.Id);
            Assert.Equal("john_smith", manager.User.Username);
            Assert.Equal("jsmith@example.com", manager.User.Email);
            Assert.Equal("John", manager.User.FirstName);
            Assert.Equal("Smith", manager.User.LastName);
            Assert.Equal(UserStatus.Active, manager.User.Status);
            Assert.Equal(string.Empty, manager.User.AvatarUrl);
            Assert.Equal(DateTimeOffset.Parse("2019-07-11T07:40:22+00:00"), manager.User.CreatedAt);
            Assert.Equal(DateTimeOffset.Parse("2019-10-23T11:44:02+00:00"), manager.User.LastSeen);
            Assert.Equal(UserTwoFactorStatus.Enabled, manager.User.TwoFactor);
            Assert.True(manager.User.IsAdmin);
            Assert.Equal("Europe/Kyiv", manager.User.TimeZone);
            
            Team team = manager.Teams.First();
            Assert.Equal(2, team.Id);
            Assert.Equal("Translators Team", team.Name);
            Assert.Equal(8, team.TotalMembers);
            Assert.Equal(DateTimeOffset.Parse("2019-09-23T09:04:29+00:00"), team.CreatedAt);
            Assert.Equal(DateTimeOffset.Parse("2019-09-23T09:04:29+00:00"), team.UpdatedAt);
        }
    }
}