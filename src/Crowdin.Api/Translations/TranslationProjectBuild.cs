
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public class TranslationProjectBuild
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("projectId")]
        public int ProjectId { get; set; }
        
        [JsonProperty("status")]
        public BuildStatus Status { get; set; }
        
        [JsonProperty("progress")]
        public int Progress { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("finishedAt")]
        public DateTimeOffset FinishedAt { get; set; }
        
        [JsonProperty("attributes")]
        public AttributesHolder Attributes { get; set; }
        
        [PublicAPI]
        public class AttributesHolder
        {
            [JsonProperty("branchId")]
            public int? BranchId { get; set; }
        
            [JsonProperty("directoryId")]
            public int? DirectoryId { get; set; }
            
            [JsonProperty("targetLanguagesId")]
            public string[] TargetLanguagesId { get; set; }
        
            [JsonProperty("skipUntranslatedStrings")]
            public bool SkipUntranslatedStrings { get; set; }
        
            [JsonProperty("skipUntranslatedFiles")]
            public bool SkipUntranslatedFiles { get; set; }
        
            // only regular API
            [JsonProperty("exportApprovedOnly")]
            public bool? ExportApprovedOnly { get; set; }
            
            // only enterprise API
            [JsonProperty("exportWithMinApprovalsCount")]
            public int? ExportWithMinApprovalsCount { get; set; }
        }
    }
}