
using System;
using System.Collections.Generic;

using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public class LanguageServiceTaskCreateForm : AddTaskRequest
    {
        [JsonProperty("title")]
#pragma warning disable CS8618
        public string Title { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("languageId")]
#pragma warning disable CS8618
        public string LanguageId { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("branchIds")]
        public ICollection<long>? BranchIds { get; set; }
        
        [JsonProperty("fileIds")]
        public ICollection<long>? FileIds { get; set; }
        
        [JsonProperty("type")]
        public TaskType Type { get; set; }
        
        [JsonProperty("vendor")]
        public string Vendor => "crowdin_language_service";
        
        [JsonProperty("status")]
        public TaskStatus? Status { get; set; }
        
        [JsonProperty("description")]
        public string? Description { get; set; }
        
        [JsonProperty("labelIds")]
        public ICollection<long>? LabelIds { get; set; }
        
        [JsonProperty("skipUntranslatedStrings")]
        public bool? SkipUntranslatedStrings { get; set; }

        [JsonProperty("includePreTranslatedStringsOnly")]
        public bool? IncludePreTranslatedStringsOnly { get; set; }
        
        [JsonProperty("includeUntranslatedStringsOnly")]
        public bool? IncludeUntranslatedStringsOnly { get; set; }

        [JsonProperty("dateFrom")]
        public DateTimeOffset? DateFrom { get; set; }
        
        [JsonProperty("dateTo")]
        public DateTimeOffset? DateTo { get; set; }
    }
}