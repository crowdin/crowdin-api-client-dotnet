
using System;
using Crowdin.Api.Languages;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public class ProjectBase
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("type")]
        public ProjectType Type { get; set; }
        
        [JsonProperty("userId")]
        public long UserId { get; set; }
        
        [JsonProperty("sourceLanguageId")]
        public string SourceLanguageId { get; set; }
        
        [JsonProperty("targetLanguageIds")]
        public string[] TargetLanguageIds { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("logo")]
        public string Logo { get; set; }
        
        [JsonProperty("publicDownloads")]
        public bool PublicDownloads { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
        
        [JsonProperty("lastActivity")]
        public DateTimeOffset? LastActivity { get; set; }
        
        [JsonProperty("sourceLanguage")]
        public Language SourceLanguage { get; set; }
        
        [JsonProperty("targetLanguages")]
        public Language[] TargetLanguages { get; set; }
    }
}