
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class ReportArchive
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("scopeType")]
        public ScopeType ScopeType { get; set; }
        
        [JsonProperty("scopeId")]
        public long ScopeId { get; set; }
        
        [JsonProperty("userId")]
        public long UserId { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("webUrl")]
        public string WebUrl { get; set; }
        
        [JsonProperty("scheme")]
        public object Scheme { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}