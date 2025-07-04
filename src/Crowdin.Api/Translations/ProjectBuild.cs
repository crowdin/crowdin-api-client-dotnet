
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public class ProjectBuild
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("projectId")]
        public long ProjectId { get; set; }
        
        [JsonProperty("status")]
        public BuildStatus Status { get; set; }
        
        [JsonProperty("progress")]
        public int Progress { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
        
        [JsonProperty("finishedAt")]
        public DateTimeOffset? FinishedAt { get; set; }
        
        [JsonProperty("attributes")]
        public AttributesBase Attributes { get; set; }

        [PublicAPI]
        public class AttributesBase
        {
            
        }

        [PublicAPI]
        public class BuildAttributes : AttributesBase
        {
            [JsonProperty("branchId")]
            public long? BranchId { get; set; }
            
            // only regular API
            [JsonProperty("directoryId")]
            public long? DirectoryId { get; set; }
            
            [JsonProperty("targetLanguageIds")]
            public string[] TargetLanguageIds { get; set; }
            
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

        [PublicAPI]
        public class PseudoBuildAttributes : AttributesBase
        {
            [JsonProperty("pseudo")]
            public bool Pseudo { get; set; }
            
            [JsonProperty("prefix")]
            public string Prefix { get; set; }
            
            [JsonProperty("suffix")]
            public string Suffix { get; set; }
            
            [JsonProperty("lengthTransformation")]
            public int LengthTransformation { get; set; }
            
            [JsonProperty("charTransformation")]
            public string CharTransformation { get; set; }
        }
    }
}