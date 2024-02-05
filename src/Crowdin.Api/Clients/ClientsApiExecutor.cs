using Crowdin.Api.Core;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crowdin.Api.Clients
{
    internal class ClientsApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public ClientsApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public ClientsApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        /// <summary>
        /// List Clients. Documentation:
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.clients.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<Client>> ListClients(int limit = 25, int offset = 0)
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            CrowdinApiResult result = await _apiClient.SendGetRequest("/clients", queryParams);
            return _jsonParser.ParseResponseList<Client>(result.JsonObject);
        }
    }
}
