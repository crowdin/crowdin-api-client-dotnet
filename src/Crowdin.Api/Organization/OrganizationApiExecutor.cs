#nullable enable

using System.Threading.Tasks;

using Crowdin.Api.Core;
using JetBrains.Annotations;

namespace Crowdin.Api.Organization
{
    public class OrganizationApiExecutor : IOrganizationApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public OrganizationApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public OrganizationApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        /// <summary>
        /// Get organization information. Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#operation/api.organization.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<OrganizationInfo> GetOrganizationInfo()
        {
            CrowdinApiResult result = await _apiClient.SendGetRequest("/organization");
            return _jsonParser.ParseResponseObject<OrganizationInfo>(result.JsonObject);
        }

        /// <summary>
        /// Get organization authentication settings. Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#operation/api.organization.auth-settings.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<OrganizationAuthSettings> GetOrganizationAuthSettings()
        {
            CrowdinApiResult result = await _apiClient.SendGetRequest("/organization/auth-settings");
            return _jsonParser.ParseResponseObject<OrganizationAuthSettings>(result.JsonObject);
        }
    }
}
