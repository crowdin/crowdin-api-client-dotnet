
using System.Threading.Tasks;

using JetBrains.Annotations;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.GraphQL
{
    [PublicAPI]
    public interface IGraphQLApiExecutor
    {
        Task<JObject> ExecuteQuery(GraphQLRequest request);
        
        Task<TResponse> ExecuteQuery<TResponse>(GraphQLRequest request);
    }
}