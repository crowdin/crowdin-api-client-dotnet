
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Abstractions;
using Crowdin.Api.Core;

namespace Crowdin.Api.Notifications
{
    public class NotificationsApiExecutor : INotificationsApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;

        public NotificationsApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        /// <summary>
        /// Send Notification to Authenticated User. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.notify.post">Crowdin API</a>
        /// </summary>
        [PublicAPI]
        public async Task SendNotificationToAuthenticatedUser(SendNotificationToAuthenticatedUserRequest request)
        {
            CrowdinApiResult result = await _apiClient.SendPostRequest("/notify", request);
            Utils.ThrowIfStatusNot204(result.StatusCode, "Failed to send notification");
        }

        /// <summary>
        /// Send Notification To Project Members. Documentation:
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.notify.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task SendNotificationToOrganizationMembers(SendNotificationToOrganizationMembersRequest request)
        {
            CrowdinApiResult result = await _apiClient.SendPostRequest("/notify", request);
            Utils.ThrowIfStatusNot204(result.StatusCode, "Failed to send notification");
        }

        /// <summary>
        /// Send Notification To Project Members. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.projects.notify.post">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.notify.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task SendNotificationToProjectMembers(int projectId, SendNotificationToProjectMembersRequest request)
        {
            var url = $"/projects/{projectId}/notify";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            Utils.ThrowIfStatusNot204(result.StatusCode, "Failed to send notification");
        }
    }
}