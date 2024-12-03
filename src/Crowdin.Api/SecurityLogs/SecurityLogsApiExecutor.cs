
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Abstractions;
using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.SecurityLogs
{
    public class SecurityLogsApiExecutor : ISecurityLogsApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public SecurityLogsApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }
        
        public SecurityLogsApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        /// <summary>
        /// List User Security Logs. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.users.security-logs.getMany">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.users.security-logs.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<SecurityLog>> ListUserSecurityLogs(
            long userId,
            int limit = 25,
            int offset = 0,
            SecurityLogEventType? eventType = null,
            string? ipAddress = null)
        {
            string url = FormUrl_Logs(userId);
            
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            queryParams.AddDescriptionEnumValueIfPresent("event", eventType);
            queryParams.AddParamIfPresent("ipAddress", ipAddress);

            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<SecurityLog>(result.JsonObject);
        }

        /// <summary>
        /// Get User Security Log. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.users.security-logs.get">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.users.security-logs.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<SecurityLog> GetUserSecurityLog(long userId, long securityLogId)
        {
            string url = FormUrl_LogId(userId, securityLogId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<SecurityLog>(result.JsonObject);
        }

        #region Helper methods

        private static string FormUrl_Logs(long userId)
        {
            return $"/users/{userId}/security-logs";
        }

        private static string FormUrl_LogId(long userId, long securityLogId)
        {
            return $"/users/{userId}/security-logs/{securityLogId}";
        }

        #endregion

        #region Enterprise API

        /// <summary>
        /// List Organization Security Logs. Documentation:
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.security-logs.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<SecurityLog>> ListOrganizationSecurityLogs(
            int limit = 25,
            int offset = 0,
            SecurityLogEventType? eventType = null,
            string? ipAddress = null,
            long? userId = null)
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            queryParams.AddDescriptionEnumValueIfPresent("event", eventType);
            queryParams.AddParamIfPresent("ipAddress", ipAddress);
            queryParams.AddParamIfPresent("userId", userId);

            CrowdinApiResult result = await _apiClient.SendGetRequest("/security-logs", queryParams);
            return _jsonParser.ParseResponseList<SecurityLog>(result.JsonObject);
        }

        /// <summary>
        /// Get Organization Security Log. Documentation:
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.security-logs.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<SecurityLog> GetOrganizationSecurityLog(long securityLogId)
        {
            var url = $"/security-logs/{securityLogId}";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<SecurityLog>(result.JsonObject);
        }

        #endregion
    }
}