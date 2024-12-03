
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Abstractions;
using Crowdin.Api.Core;

namespace Crowdin.Api.Vendors
{
    public class VendorsApiExecutor : IVendorsApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public VendorsApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public VendorsApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        /// <summary>
        /// List vendors. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.vendors.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<Vendor>> ListVendors(int limit = 25, int offset = 0)
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            CrowdinApiResult result = await _apiClient.SendGetRequest("/vendors", queryParams);
            return _jsonParser.ParseResponseList<Vendor>(result.JsonObject);
        }
    }
}