
using System;
using Crowdin.Api.StringTranslations;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Issues
{
    [PublicAPI]
    public class Issue
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("text")]
        public string Text { get; set; }
        
        [JsonProperty("userId")]
        public int UserId { get; set; }
        
        [JsonProperty("stringId")]
        public int StringId { get; set; }
        
        [JsonProperty("user")]
        public User User { get; set; }
        
        [JsonProperty("string")]
        public StringObject String { get; set; }
        
        [JsonProperty("languageId")]
        public string LanguageId { get; set; }
        
        [JsonProperty("type")]
        public IssueType Type { get; set; }
        
        [JsonProperty("status")]
        public IssueStatus Status { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [PublicAPI]
        public class StringObject
        {
            [JsonProperty("id")]
            public int Id { get; set; }
            
            [JsonProperty("text")]
            public string Text { get; set; }
            
            [JsonProperty("type")]
            public string Type { get; set; }
            
            [JsonProperty("hasPlurals")]
            public bool HasPlurals { get; set; }
            
            [JsonProperty("isIcu")]
            public bool IsIcu { get; set; }
            
            [JsonProperty("context")]
            public string Context { get; set; }
            
            [JsonProperty("fileId")]
            public int FileId { get; set; }
        }
    }
}