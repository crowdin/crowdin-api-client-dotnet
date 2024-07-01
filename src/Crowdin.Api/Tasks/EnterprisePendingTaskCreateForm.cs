
using System;
using System.Collections.Generic;

using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public class EnterprisePendingTaskCreateForm : AddTaskRequest
    {
        [JsonProperty("precedingTaskId")]
        public int PrecedingTaskId { get; set; }
        
        [JsonProperty("type")]
        public TaskType Type { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; } = null!;
        
        [JsonProperty("description")]
        public string? Description { get; set; }
        
        [JsonProperty("assignees")]
        public ICollection<TaskAssigneeForm>? Assignees { get; set; }
        
        [JsonProperty("assignedTeams")]
        public ICollection<TaskAssignedTeam>? AssignedTeams { get; set; }
        
        [JsonProperty("deadline")]
        public DateTimeOffset? DeadLine { get; set; }
    }
}