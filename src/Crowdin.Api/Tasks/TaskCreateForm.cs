
using System;
using System.Collections.Generic;

using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public class TaskCreateForm : AddTaskRequest
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
        public ICollection<int>? BranchIds { get; set; }
        
        [JsonProperty("fileIds")]
        public ICollection<int>? FileIds { get; set; }
        
        [JsonProperty("stringIds")]
        public ICollection<int>? StringIds { get; set; }
        
        [JsonProperty("type")]
        public TaskType Type { get; set; }
        
        [JsonProperty("status")]
        public TaskStatus? Status { get; set; }
        
        [JsonProperty("description")]
        public string? Description { get; set; }
        
        [JsonProperty("splitFiles")]
        [Obsolete("Use splitContent instead")]
        public bool? SplitFiles { get; set; }
        
        [JsonProperty("skipAssignedStrings")]
        public bool? SkipAssignedStrings { get; set; }
        
        [JsonProperty("skipUntranslatedStrings")]
        [Obsolete(MessageTexts.DeprecatedProperty)]
        public bool? SkipUntranslatedStrings { get; set; }

        [JsonProperty("includePreTranslatedStringsOnly")]
        public bool? IncludePreTranslatedStringsOnly { get; set; }
        
        [JsonProperty("labelIds")]
        public ICollection<int>? LabelIds { get; set; }
        
        [JsonProperty("excludeLabelIds")]
        public ICollection<int>? ExcludeLabelIds { get; set; }
        
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