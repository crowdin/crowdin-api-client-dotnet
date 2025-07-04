
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Crowdin.Api.Notifications
{
    [PublicAPI]
    public interface INotificationsApiExecutor
    {
        Task SendNotificationToAuthenticatedUser(SendNotificationToAuthenticatedUserRequest request);

        Task SendNotificationToOrganizationMembers(SendNotificationToOrganizationMembersRequest request);

        Task SendNotificationToProjectMembers(long projectId, SendNotificationToProjectMembersRequest request);
    }
}