
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public class Glossary
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("groupId")]
        public int? GroupId { get; set; }
        
        [JsonProperty("userId")]
        public long UserId { get; set; }
        
        [JsonProperty("terms")]
        public long Terms { get; set; }
        
        [JsonProperty("languageId")]
        public string LanguageId { get; set; }
        
        [JsonProperty("languageIds")]
        public string[] LanguageIds { get; set; }
        
        [JsonProperty("defaultProjectIds")]
        public int[] DefaultProjectIds { get; set; }
        
        [JsonProperty("projectIds")]
        public int[] ProjectIds { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}