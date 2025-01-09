
using System.Threading.Tasks;

using JetBrains.Annotations;
using Newtonsoft.Json.Linq;

using Crowdin.Api.Core;

namespace Crowdin.Api.GraphQL
{
    public class GraphQLApiExecutor : IGraphQLApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public GraphQLApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public GraphQLApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }
        
        /// <summary>
        /// GraphQL API. Returns raw response object. Documentation:
        /// <a href="https://support.crowdin.com/developer/graphql-api">Crowdin API</a>
        /// </summary>
        [PublicAPI]
        public async Task<JObject> ExecuteQuery(GraphQLRequest request)
        {
            CrowdinApiResult result = await _apiClient.SendGraphQLRequest(request);
            return result.JsonObject;
        }
        
        /// <summary>
        /// GraphQL API. Returns typed response object. Documentation:
        /// <a href="https://support.crowdin.com/developer/graphql-api">Crowdin API</a>
        /// </summary>
        [PublicAPI]
        public async Task<TResponse> ExecuteQuery<TResponse>(GraphQLRequest request)
        {
            CrowdinApiResult result = await _apiClient.SendGraphQLRequest(request);
            return _jsonParser.ParseResponseObject<TResponse>(result.JsonObject);
        }
    }
}