
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.StringComments
{
    [PublicAPI]
    public class StringComment
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
        public UserObject User { get; set; }

        [JsonProperty("string")]
        public StringObject String { get; set; }
        
        [JsonProperty("languageId")]
        public string LanguageId { get; set; }
        
        [JsonProperty("type")]
        public StringCommentType Type { get; set; }
        
        [JsonProperty("issueType")]
        public IssueType? IssueType { get; set; }
        
        [JsonProperty("issueStatus")]
        public IssueStatus IssueStatus { get; set; }
        
        [JsonProperty("resolverId")]
        public int ResolverId { get; set; }
        
        [JsonProperty("resolver")]
        public UserObject Resolver { get; set; }
        
        [JsonProperty("resolvedAt")]
        public DateTimeOffset ResolvedAt { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [PublicAPI]
        public class UserObject
        {
            [JsonProperty("id")]
            public int Id { get; set; }
        
            [JsonProperty("username")]
            public string Username { get; set; }
        
            [JsonProperty("fullName")]
            public string FullName { get; set; }
        
            [JsonProperty("avatarUrl")]
            public string AvatarUrl { get; set; }
        }

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