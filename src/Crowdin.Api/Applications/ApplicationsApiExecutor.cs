
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using JetBrains.Annotations;
using Newtonsoft.Json.Linq;

using Crowdin.Api.Core;

namespace Crowdin.Api.Applications
{
    public class ApplicationsApiExecutor : IApplicationsApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;
        private const string ApplicationsInstallationsUrl = "/applications/installations";

        public ApplicationsApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public ApplicationsApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        /// <summary>
        /// Get Application Installations List. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.applications.installations.getMany">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/#operation/api.applications.installations.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<Application>> ListApplicationInstallations(int limit = 25, int offset = 0)
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            CrowdinApiResult result = await _apiClient.SendGetRequest(ApplicationsInstallationsUrl, queryParams);
            return _jsonParser.ParseResponseList<Application>(result.JsonObject);
        }

        /// <summary>
        /// Get Application Installation. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.applications.installations.get">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/#operation/api.applications.installations.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Application> GetApplicationInstallation(string applicationIdentifier)
        {
            string url = FormUrl_ApplicationsInstallations(applicationIdentifier);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<Application>(result.JsonObject);
        }

        /// <summary>
        /// Install Application. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.applications.installations.post">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/#operation/api.applications.installations.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Application> InstallApplication(InstallApplicationRequest request)
        {
            CrowdinApiResult result = await _apiClient.SendPostRequest(ApplicationsInstallationsUrl, request);
            return _jsonParser.ParseResponseObject<Application>(result.JsonObject);
        }

        /// <summary>
        /// Delete Application Installation. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.applications.installations.delete">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/#operation/api.applications.installations.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteApplicationInstallation(string applicationIdentifier, bool force = false)
        {
            string url = FormUrl_ApplicationsInstallations(applicationIdentifier);

            IDictionary<string, string> queryParams = new Dictionary<string, string> { { "force", force.ToString() } };
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url, queryParams);
            Utils.ThrowIfStatusNot204(statusCode, $"Application {applicationIdentifier} installation removal failed");
        }

        /// <summary>
        /// Edit Application Installation. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.applications.installations.patch">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.applications.installations.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Application> EditApplicationInstallation(string applicationIdentifier, IEnumerable<InstallationPatch> patches)
        {
            string url = FormUrl_ApplicationsInstallations(applicationIdentifier);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<Application>(result.JsonObject);
        }

        /// <summary>
        /// Get Application Data. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.applications.api.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.applications.api.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<JObject> GetApplicationData(string applicationIdentifier, string path)
        {
            string url = FormUrl_Applications(applicationIdentifier, path);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return result.JsonObject;
        }

        /// <summary>
        /// Update or Restore Application Data. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.applications.api.put">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.applications.api.put">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<JObject> UpdateOrRestoreApplicationData(string applicationIdentifier, string path, object request)
        {
            string url = FormUrl_Applications(applicationIdentifier, path);
            CrowdinApiResult result = await _apiClient.SendPutRequest(url, request);
            return result.JsonObject;
        }

        /// <summary>
        /// Add Application Data. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.applications.api.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.applications.api.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<JObject> AddApplicationData(string applicationIdentifier, string path, object request)
        {
            string url = FormUrl_Applications(applicationIdentifier, path);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return result.JsonObject;
        }

        /// <summary>
        /// Delete Application Data. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.applications.api.delete">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.applications.api.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteApplicationData(string applicationIdentifier, string path)
        {
            string url = FormUrl_Applications(applicationIdentifier, path);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Application {applicationIdentifier} data removal failed");
        }

        /// <summary>
        /// Edit Application Data. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.applications.api.patch">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.applications.api.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<JObject> EditApplicationData(string applicationIdentifier, string path, object patches)
        {
            string url = FormUrl_Applications(applicationIdentifier, path);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return result.JsonObject;
        }

        private string FormUrl_Applications(string applicationIdentifier, string path)
        {
            return $"/applications/{applicationIdentifier}/api/{path}";
        }
        private string FormUrl_ApplicationsInstallations(string applicationIdentifier)
        {
            return $"{ApplicationsInstallationsUrl}/{applicationIdentifier}";
        }
    }
}