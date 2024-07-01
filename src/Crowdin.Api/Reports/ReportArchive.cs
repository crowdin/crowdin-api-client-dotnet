
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class ReportArchive
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("scopeType")]
        public ScopeType ScopeType { get; set; }
        
        [JsonProperty("scopeId")]
        public int ScopeId { get; set; }
        
        [JsonProperty("userId")]
        public int UserId { get; set; }
        
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