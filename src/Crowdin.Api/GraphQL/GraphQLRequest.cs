
using System.Collections.Generic;

using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.GraphQL
{
    [PublicAPI]
    public class GraphQLRequest
    {
        [JsonProperty("query")]
        public string Query { get; set; } = null!;
        
        [JsonProperty("operationName")]
        public string? OperationName { get; set; }

        [JsonProperty("variables")]
        public IDictionary<string, object> Variables { get; set; } = new Dictionary<string, object>(0);
    }
}