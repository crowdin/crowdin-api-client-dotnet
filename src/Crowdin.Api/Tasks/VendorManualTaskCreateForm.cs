
using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public class VendorManualTaskCreateForm : AddTaskRequest
    {
#pragma warning disable CS8618
        
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("languageId")]
        public string LanguageId { get; set; }
        
        [JsonProperty("type")]
        public TaskType Type { get; set; }
        
        [JsonProperty("vendor")]
        public TaskVendor Vendor { get; set; }
        
#pragma warning restore CS8618
        
        [JsonProperty("status")]
        public TaskStatus? Status { get; set; }
        
        [JsonProperty("description")]
        public string? Description { get; set; }
        
        [JsonProperty("branchIds")]
        public ICollection<int>? BranchIds { get; set; }
        
        [JsonProperty("fileIds")]
        public ICollection<int>? FileIds { get; set; }
        
        [JsonProperty("skipAssignedStrings")]
        public bool? SkipAssignedStrings { get; set; }
        
        [JsonProperty("skipUntranslatedStrings")]
        public bool? SkipUntranslatedStrings { get; set; }
        
        [JsonProperty("includePreTranslatedStringsOnly")]
        public bool? IncludePreTranslatedStringsOnly { get; set; }
        
        [JsonProperty("labelIds")]
        public ICollection<int>? LabelIds { get; set; }
        
        [JsonProperty("assignees")]
        public ICollection<TaskAssigneeForm>? Assignees { get; set; }
        
        [JsonProperty("deadline")]
        public DateTimeOffset? DeadLine { get; set; }
        
        [JsonProperty("dateFrom")]
        public DateTimeOffset? DateFrom { get; set; }
        
        [JsonProperty("dateTo")]
        public DateTimeOffset? DateTo { get; set; }
    }
}