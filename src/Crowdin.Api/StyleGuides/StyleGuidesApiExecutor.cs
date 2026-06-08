
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Core;

namespace Crowdin.Api.StyleGuides
{
    public class StyleGuidesApiExecutor : IStyleGuidesApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public StyleGuidesApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public StyleGuidesApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        /// <summary>
        /// List Style Guides. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/Style-Guides/operation/api.style-guides.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/developer/api/v2/string-based/#tag/Style-Guides/operation/api.style-guides.getMany">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Style-Guides/operation/api.style-guides.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<StyleGuide>> ListStyleGuides(int limit = 25, int offset = 0)
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            CrowdinApiResult result = await _apiClient.SendGetRequest("/style-guides", queryParams);
            return _jsonParser.ParseResponseList<StyleGuide>(result.JsonObject);
        }

        /// <summary>
        /// Add Style Guide. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/Style-Guides/operation/api.style-guides.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/developer/api/v2/string-based/#tag/Style-Guides/operation/api.style-guides.post">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Style-Guides/operation/api.style-guides.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<StyleGuide> AddStyleGuide(AddStyleGuideRequest request)
        {
            CrowdinApiResult result = await _apiClient.SendPostRequest("/style-guides", request);
            return _jsonParser.ParseResponseObject<StyleGuide>(result.JsonObject);
        }

        /// <summary>
        /// Get Style Guide. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/Style-Guides/operation/api.style-guides.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/developer/api/v2/string-based/#tag/Style-Guides/operation/api.style-guides.get">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Style-Guides/operation/api.style-guides.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<StyleGuide> GetStyleGuide(long styleGuideId)
        {
            CrowdinApiResult result = await _apiClient.SendGetRequest($"/style-guides/{styleGuideId}");
            return _jsonParser.ParseResponseObject<StyleGuide>(result.JsonObject);
        }

        /// <summary>
        /// Edit Style Guide. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/Style-Guides/operation/api.style-guides.patch">Crowdin API</a>
        /// <a href="https://support.crowdin.com/developer/api/v2/string-based/#tag/Style-Guides/operation/api.style-guides.patch">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Style-Guides/operation/api.style-guides.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<StyleGuide> EditStyleGuide(long styleGuideId, IEnumerable<StyleGuidePatch> patches)
        {
            CrowdinApiResult result = await _apiClient.SendPatchRequest($"/style-guides/{styleGuideId}", patches);
            return _jsonParser.ParseResponseObject<StyleGuide>(result.JsonObject);
        }

        /// <summary>
        /// Delete Style Guide. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/Style-Guides/operation/api.style-guides.delete">Crowdin API</a>
        /// <a href="https://support.crowdin.com/developer/api/v2/string-based/#tag/Style-Guides/operation/api.style-guides.delete">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Style-Guides/operation/api.style-guides.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteStyleGuide(long styleGuideId)
        {
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest($"/style-guides/{styleGuideId}");
            Utils.ThrowIfStatusNot204(statusCode, $"Style guide {styleGuideId} removal failed");
        }
    }
}
