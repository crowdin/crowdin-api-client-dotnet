
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using JetBrains.Annotations;
using Newtonsoft.Json.Linq;

using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.Applications
{
    public class ApplicationsApiExecutor : IApplicationsApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;
        private const string ApplicationsConsentsUrl = "/applications/consents";
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
        /// List Application Consent Decisions. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#operation/api.applications.consents.getMany">Crowdin API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<ApplicationConsent>> ListApplicationConsents(
            string? identifier = null,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null)
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            queryParams.AddParamIfPresent("identifier", identifier);
            queryParams.AddSortingRulesIfPresent(orderBy);

            CrowdinApiResult result = await _apiClient.SendGetRequest(ApplicationsConsentsUrl, queryParams);
            return _jsonParser.ParseResponseList<ApplicationConsent>(result.JsonObject);
        }

        /// <summary>
        /// Add Application Consent Decision. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#operation/api.applications.consents.post">Crowdin API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ApplicationConsent> AddApplicationConsent(AddApplicationConsentRequest request)
        {
            CrowdinApiResult result = await _apiClient.SendPostRequest(ApplicationsConsentsUrl, request);
            return _jsonParser.ParseResponseObject<ApplicationConsent>(result.JsonObject);
        }

        /// <summary>
        /// Edit Application Consent Decision. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#operation/api.applications.consents.patch">Crowdin API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ApplicationConsent> EditApplicationConsent(
            long consentId,
            IEnumerable<ApplicationConsentPatch> patches)
        {
            string url = FormUrl_ApplicationConsent(consentId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<ApplicationConsent>(result.JsonObject);
        }

        /// <summary>
        /// Delete Application Consent Decision. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#operation/api.applications.consents.delete">Crowdin API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteApplicationConsent(long consentId)
        {
            string url = FormUrl_ApplicationConsent(consentId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Application consent {consentId} removal failed");
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
        /// Get an application installation update.
        /// Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Applications/operation/api.applications.installations.update.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ApplicationInstallationUpdate> GetApplicationInstallationUpdate(string identifier)
        {
            CrowdinApiResult result = await _apiClient.SendGetRequest($"/applications/installations/{identifier}/update");
            return _jsonParser.ParseResponseObject<ApplicationInstallationUpdate>(result.JsonObject);
        }

        /// <summary>
        /// Apply an application installation update.
        /// Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Applications/operation/api.applications.installations.update.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Application> ApplyApplicationInstallationUpdate(string identifier, ApplyApplicationInstallationUpdateRequest request)
        {
            CrowdinApiResult result = await _apiClient.SendPostRequest($"/applications/installations/{identifier}/update", request);
            return _jsonParser.ParseResponseObject<Application>(result.JsonObject);
        }

        /// <summary>
        /// Upload an application bundle.
        /// Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Applications/operation/api.applications.installations.bundles.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Application> UploadApplicationBundle(string identifier, UploadApplicationBundleRequest request)
        {
            CrowdinApiResult result = await _apiClient.SendPostRequest($"/applications/installations/{identifier}/bundles", request);
            return _jsonParser.ParseResponseObject<Application>(result.JsonObject);
        }

        /// <summary>
        /// List application key-value records. Application access tokens are required; personal access tokens are not supported.
        /// Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Applications/operation/api.applications.storage.kv.records.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<ApplicationKvRecord>> ListApplicationKvRecords(
            string applicationIdentifier, string? prefix = null, int limit = 25, int offset = 0,
            IEnumerable<SortingRule>? orderBy = null)
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            queryParams.AddParamIfPresent("prefix", prefix);
            queryParams.AddSortingRulesIfPresent(orderBy);
            CrowdinApiResult result = await _apiClient.SendGetRequest($"/applications/{applicationIdentifier}/storage/kv/records", queryParams);
            return _jsonParser.ParseResponseList<ApplicationKvRecord>(result.JsonObject);
        }

        /// <summary>
        /// Add an application key-value record. Application access tokens are required; personal access tokens are not supported.
        /// Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Applications/operation/api.applications.storage.kv.records.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ApplicationKvRecord> AddApplicationKvRecord(string applicationIdentifier, AddApplicationKvRecordRequest request)
        {
            CrowdinApiResult result = await _apiClient.SendPostRequest($"/applications/{applicationIdentifier}/storage/kv/records", request);
            return _jsonParser.ParseResponseObject<ApplicationKvRecord>(result.JsonObject);
        }

        /// <summary>
        /// Get an application key-value record. Application access tokens are required; personal access tokens are not supported.
        /// Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Applications/operation/api.applications.storage.kv.records.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ApplicationKvRecord> GetApplicationKvRecord(string applicationIdentifier, string key)
        {
            string encodedKey = Uri.EscapeDataString(key);
            CrowdinApiResult result = await _apiClient.SendGetRequest($"/applications/{applicationIdentifier}/storage/kv/records/{encodedKey}");
            return _jsonParser.ParseResponseObject<ApplicationKvRecord>(result.JsonObject);
        }

        /// <summary>
        /// Edit an application key-value record. Application access tokens are required; personal access tokens are not supported.
        /// Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Applications/operation/api.applications.storage.kv.records.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ApplicationKvRecord> EditApplicationKvRecord(string applicationIdentifier, string key, IEnumerable<ApplicationKvRecordPatch> patches)
        {
            string encodedKey = Uri.EscapeDataString(key);
            CrowdinApiResult result = await _apiClient.SendPatchRequest($"/applications/{applicationIdentifier}/storage/kv/records/{encodedKey}", patches);
            return _jsonParser.ParseResponseObject<ApplicationKvRecord>(result.JsonObject);
        }

        /// <summary>
        /// Delete an application key-value record. Application access tokens are required; personal access tokens are not supported.
        /// Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Applications/operation/api.applications.storage.kv.records.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteApplicationKvRecord(string applicationIdentifier, string key)
        {
            string encodedKey = Uri.EscapeDataString(key);
            HttpStatusCode code = await _apiClient.SendDeleteRequest($"/applications/{applicationIdentifier}/storage/kv/records/{encodedKey}");
            Utils.ThrowIfStatusNot204(code, $"Application key-value record {key} removal failed");
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

        private string FormUrl_ApplicationConsent(long consentId)
        {
            return $"{ApplicationsConsentsUrl}/{consentId}";
        }
    }
}
