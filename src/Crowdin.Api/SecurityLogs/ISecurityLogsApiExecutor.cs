
using System.Threading.Tasks;
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.SecurityLogs
{
    [PublicAPI]
    public interface ISecurityLogsApiExecutor
    {
        Task<ResponseList<SecurityLog>> ListUserSecurityLogs(
            long userId,
            int limit = 25,
            int offset = 0,
            SecurityLogEventType? eventType = null,
            string? ipAddress = null);

        Task<SecurityLog> GetUserSecurityLog(long userId, long securityLogId);

        #region Enterprise API

        Task<ResponseList<SecurityLog>> ListOrganizationSecurityLogs(
            int limit = 25,
            int offset = 0,
            SecurityLogEventType? eventType = null,
            string? ipAddress = null,
            long? userId = null);

        Task<SecurityLog> GetOrganizationSecurityLog(long securityLogId);

        #endregion
    }
}