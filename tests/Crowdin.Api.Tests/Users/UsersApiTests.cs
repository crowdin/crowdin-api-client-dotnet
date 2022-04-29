
using System;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Core;
using Crowdin.Api.Tests.Core;
using Crowdin.Api.Users;

namespace Crowdin.Api.Tests.Users
{
    public class UsersApiTests
    {
        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task InviteUser()
        {
            var request = new EnterpriseInviteUserRequest
            {
                Email = "john@example.com",
                FirstName = "Jon",
                LastName = "Doe",
                TimeZone = "America/New_York"
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Core.Resources.Users.InviteUser_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPostRequest("/users", request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.Users.InviteUser_Response)
                });

            var executor = new UsersApiExecutor(mockClient.Object);
            UserEnterprise response = await executor.InviteUser(request);
            
            ExecuteAssertionsFor(response);
        }

        [Fact]
        public async Task DeleteUser()
        {
            const int userId = 1;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}";

            mockClient
                .Setup(client => client.SendDeleteRequest(url, null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            var executor = new UsersApiExecutor(mockClient.Object);
            await executor.DeleteUser(userId);
        }

        [Fact]
        public async Task EditUser()
        {
            const int userId = 1;
            
            var patches = new[]
            {
                new EnterpriseUserPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = EnterpriseUserPatchPath.FirstName,
                    Value = "Jonny"
                },
                new EnterpriseUserPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = EnterpriseUserPatchPath.Status,
                    Value = UserStatus.Active
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(patches, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Core.Resources.Users.EditUser_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}";

            mockClient
                .Setup(client => client.SendPatchRequest(url, patches, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.Users.EditUser_Response)
                });

            var executor = new UsersApiExecutor(mockClient.Object);
            UserEnterprise response = await executor.EditUser(userId, patches);
            
            ExecuteAssertionsFor(response);
        }
        
        private static void ExecuteAssertionsFor(UserEnterprise user)
        {
            Assert.Equal(UserStatus.Active, user.Status);
            Assert.Equal(DateTimeOffset.Parse("2019-07-11T07:40:22+00:00"), user.CreatedAt);
            Assert.Equal(DateTimeOffset.Parse("2019-10-23T11:44:02+00:00"), user.LastSeen);
            Assert.Equal(UserTwoFactorStatus.Enabled, user.TwoFactor);
        }
    }
}