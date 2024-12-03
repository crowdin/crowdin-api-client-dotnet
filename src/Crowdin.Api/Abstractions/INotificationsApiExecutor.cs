
using System.Threading.Tasks;
using JetBrains.Annotations;
using Crowdin.Api.Notifications;

namespace Crowdin.Api.Abstractions
{
    [PublicAPI]
    public interface INotificationsApiExecutor
    {
        Task SendNotificationToAuthenticatedUser(SendNotificationToAuthenticatedUserRequest request);

        Task SendNotificationToOrganizationMembers(SendNotificationToOrganizationMembersRequest request);

        Task SendNotificationToProjectMembers(int projectId, SendNotificationToProjectMembersRequest request);
    }
}