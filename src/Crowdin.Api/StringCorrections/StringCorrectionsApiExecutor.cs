using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Crowdin.Api.Core;
using JetBrains.Annotations;

namespace Crowdin.Api.StringCorrections
{
    public class StringCorrectionsApiExecutor : IStringCorrectionsApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public StringCorrectionsApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }
        
        public StringCorrectionsApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }
        
        /// <summary>  
        /// List string corrections. Documentation:  
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/String-Corrections/operation/api.projects.corrections.getMany">Crowdin Enterprise API</a>  
        /// </summary>  
        [PublicAPI]
        public async Task<ResponseList<Correction>> ListCorrections(
            int projectId,
            int stringId,
            IEnumerable<SortingRule>? orderBy = null,
            int denormalizePlaceholders = 0,
            int limit = 25,
            int offset = 0)
        {
            var url = FormUrl_Corrections(projectId);
            
            var queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            queryParams.AddSortingRulesIfPresent(orderBy);
            queryParams.Add("denormalizePlaceholders", denormalizePlaceholders.ToString());
            queryParams.Add("stringId", stringId.ToString());
         
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<Correction>(result.JsonObject);
        }
        
        /// <summary>  
        /// Add string correction. Documentation:  
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/String-Corrections/operation/api.projects.corrections.post">Crowdin Enterprise API</a>  
        /// </summary>  
        [PublicAPI]
        public async Task<Correction> AddCorrection(int projectId, AddCorrectionRequest request)
        {
            var url = FormUrl_Corrections(projectId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<Correction>(result.JsonObject);
        }
        
        /// <summary>  
        /// Get string correction. Documentation:  
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/String-Corrections/operation/api.projects.corrections.get">Crowdin Enterprise API</a>  
        /// </summary> 
        [PublicAPI]
        public async Task<Correction> GetCorrection(int projectId, int correctionId)
        {
            var url = FormUrl_CorrectionId(projectId, correctionId);
            
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<Correction>(result.JsonObject);
        }
        
        /// <summary>  
        /// Delete string correction. Documentation:  
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/String-Corrections/operation/api.projects.corrections.delete">Crowdin Enterprise API</a>  
        /// </summary>  
        [PublicAPI]
        public async Task DeleteCorrection(int projectId, int correctionId)
        {
            var url = FormUrl_CorrectionId(projectId, correctionId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Correction {correctionId} removal failed");
        }
        
        /// <summary>  
        /// Delete string corrections. Documentation:  
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/String-Corrections/operation/api.projects.corrections.deleteMany">Crowdin Enterprise API</a>  
        /// </summary> 
        [PublicAPI]
        public async Task DeleteCorrections(int projectId, int stringId)
        {
            var url = FormUrl_Corrections(projectId);
            IDictionary<string, string> queryParams = new Dictionary<string, string> { { "stringId", stringId.ToString() } };

            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url, queryParams);
            Utils.ThrowIfStatusNot204(statusCode, $"Failed to delete correction with string ID {stringId}");
        }
        
        /// <summary>  
        /// Restore string correction. Documentation:  
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/String-Corrections/operation/api.projects.corrections.put">Crowdin Enterprise API</a>  
        /// </summary>
        [PublicAPI]
        public async Task<Correction> RestoreCorrection(int projectId, int correctionId)
        {
            var url = FormUrl_CorrectionId(projectId, correctionId);
            CrowdinApiResult result = await _apiClient.SendPutRequest(url);
            return _jsonParser.ParseResponseObject<Correction>(result.JsonObject);
        }
        
        private static string FormUrl_Corrections(int projectId) => $"/projects/{projectId}/corrections";
        
        private static string FormUrl_CorrectionId(int projectId, int correctionId) => $"/projects/{projectId}/corrections/{correctionId}";
    }
}