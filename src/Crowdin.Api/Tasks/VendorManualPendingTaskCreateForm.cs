
using System;
using System.Collections.Generic;

using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    [Obsolete(MessageTexts.DeprecatedModel)]
    public class VendorManualPendingTaskCreateForm : AddTaskRequest
    {
        [JsonProperty("precedingTaskId")]
        public long PrecedingTaskId { get; set; }
        
        [JsonProperty("type")]
        public TaskType Type { get; set; }
        
        [JsonProperty("vendor")]
        public TaskVendor Vendor { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; } = null!;
        
        [JsonProperty("description")]
        public string? Description { get; set; }
        
        [JsonProperty("assignees")]
        public ICollection<TaskAssigneeForm>? Assignees { get; set; }
        
        [JsonProperty("deadline")]
        public DateTimeOffset? DeadLine { get; set; }
    }
}