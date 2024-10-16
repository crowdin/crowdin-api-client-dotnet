
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using Xunit;

using Crowdin.Api.Core;
using Crowdin.Api.Notifications;
using Crowdin.Api.Tests.Testing;
using Crowdin.Api.Users;

namespace Crowdin.Api.Tests.Notifications
{
    public class NotificationsApiTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task SendNotificationToAuthenticatedUser()
        {
            var request = new SendNotificationToAuthenticatedUserRequest
            {
                Message = "New notification message"
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(Testing.Resources.Notifications.SendNotificationToAuthenticatedUser_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPostRequest("/notify", request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.NoContent
                });

            var executor = new NotificationsApiExecutor(mockClient.Object);
            await executor.SendNotificationToAuthenticatedUser(request);
        }

        [Fact]
        public async Task SendNotificationToProjectMembers_ByUserIds()
        {
            const int projectId = 1;
            
            var request = new SendNotificationToProjectMembersRequest
            {
                UserIds = new[] { 1, 2, 3 },
                Message = "New notification message"
            };
            
            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(Testing.Resources.Notifications.SendNotificationToProjectMembers_Request_ByUserIds);
            Assert.Equal(expectedRequestJson, actualRequestJson);
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/notify";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.NoContent
                });

            var executor = new NotificationsApiExecutor(mockClient.Object);
            await executor.SendNotificationToProjectMembers(projectId, request);
        }

        [Fact]
        public async Task SendNotificationToProjectMembers_ByRole()
        {
            const int projectId = 1;
            
            var request = new SendNotificationToProjectMembersRequest
            {
                Role = UserRole.Owner,
                Message = "New notification message"
            };
            
            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(Testing.Resources.Notifications.SendNotificationToProjectMembers_Request_ByRole);
            Assert.Equal(expectedRequestJson, actualRequestJson);
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/notify";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.NoContent
                });

            var executor = new NotificationsApiExecutor(mockClient.Object);
            await executor.SendNotificationToProjectMembers(projectId, request);
        }

        [Fact]
        public async Task SendNotificationToOrganizationMembers_ByRole()
        {
            var request = new SendNotificationToOrganizationMembersRequest
            {
                Role = UserRole.Owner,
                Message = "New notification message"
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(Testing.Resources.Notifications.SendNotificationToOrganizationMembers_Request_ByRole);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPostRequest("/notify", request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.NoContent
                });

            var executor = new NotificationsApiExecutor(mockClient.Object);
            await executor.SendNotificationToOrganizationMembers(request);
        }

        [Fact]
        public async Task SendNotificationToOrganizationMembers_ByUserIds()
        {
            var request = new SendNotificationToOrganizationMembersRequest
            {
                UserIds = new[] { 2 },
                Message = "New notification message"
            };
            
            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(Testing.Resources.Notifications.SendNotificationToOrganizationMembers_Request_ByUserIds);
            Assert.Equal(expectedRequestJson, actualRequestJson);
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPostRequest("/notify", request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.NoContent
                });

            var executor = new NotificationsApiExecutor(mockClient.Object);
            await executor.SendNotificationToOrganizationMembers(request);
        }
    }
}