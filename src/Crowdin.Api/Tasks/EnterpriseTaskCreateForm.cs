
using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public class EnterpriseTaskCreateForm : AddTaskRequest
    {
        [JsonProperty("workflowStepId")]
        public long WorkflowStepId { get; set; }
        
        [JsonProperty("title")]
#pragma warning disable CS8618
        public string Title { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("languageId")]
#pragma warning disable CS8618
        public string LanguageId { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("fileIds")]
#pragma warning disable CS8618
        public ICollection<long> FileIds { get; set; }
#pragma warning restore CS8618

        [JsonProperty("status")]
        public TaskStatus? Status { get; set; }
        
        [JsonProperty("description")]
        public string? Description { get; set; }
        
        [JsonProperty("splitFiles")]
        public bool? SplitFiles { get; set; }
        
        [JsonProperty("skipAssignedStrings")]
        public bool? SkipAssignedStrings { get; set; }
        
        [JsonProperty("assignees")]
        public ICollection<TaskAssigneeForm>? Assignees { get; set; }
        
        [JsonProperty("deadline")]
        public DateTimeOffset? DeadLine { get; set; }
        
        [JsonProperty("labelIds")]
        public ICollection<long>? LabelIds { get; set; }
        
        [JsonProperty("dateFrom")]
        public DateTimeOffset? DateFrom { get; set; }
        
        [JsonProperty("dateTo")]
        public DateTimeOffset? DateTo { get; set; }
    }
}