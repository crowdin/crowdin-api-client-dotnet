
using System;

using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Core;
using Crowdin.Api.Labels;
using Crowdin.Api.Languages;

#nullable enable

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public class TaskResource
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("projectId")]
        public int ProjectId { get; set; }
        
        [JsonProperty("creatorId")]
        public int CreatorId { get; set; }
        
        [JsonProperty("type")]
        public int Type { get; set; }
        
        [JsonProperty("status")]
        public TaskStatus Status { get; set; }
        
        [JsonProperty("batchId")]
        public int BatchId { get; set; }
        
        [JsonProperty("wordsCount")]
        public int WordsCount { get; set; }
        
        [JsonProperty("filesCount")]
        public int FilesCount { get; set; }
        
        [JsonProperty("commentsCount")]
        public int CommentsCount { get; set; }
        
        [JsonProperty("deadline")]
        public DateTimeOffset DeadLine { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
        
        [JsonProperty("startedAt")]
        public DateTimeOffset StartedAt { get; set; }
        
        [JsonProperty("resolvedAt")]
        public DateTimeOffset ResolvedAt { get; set; }
        
        [JsonProperty("workflowStepId")]
        public int WorkFlowStepId { get; set; }
        
        [JsonProperty("precedingTaskId")]
        public int PrecedingTaskId { get; set; }

#pragma warning disable CS8618
        [JsonProperty("vendor")]
        public string Vendor { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("assignees")]
        public TaskAssignee[] Assignees { get; set; }
        
        [JsonProperty("assignedTeams")]
        public TaskAssignedTeam[] AssignedTeams { get; set; }

        [JsonProperty("fileIds")]
        public int[] FileIds { get; set; }

        [JsonProperty("progress")]
        public TaskProgress Progress { get; set; }

        [JsonProperty("translateProgress")]
        [Obsolete(MessageTexts.DeprecatedProperty)]
        public TaskProgress TranslateProgress { get; set; }

        [JsonProperty("sourceLanguageId")]
        public string SourceLanguageId { get; set; }

        [JsonProperty("targetLanguageId")]
        public string TargetLanguageId { get; set; }
        
        [JsonProperty("translationUrl")]
        public string TranslationUrl { get; set; }

        [JsonProperty("webUrl")]
        public string WebUrl { get; set; }
        
        [JsonProperty("sourceLanguage")]
        public Language SourceLanguage { get; set; }
        
        [JsonProperty("targetLanguages")]
        public Language[] TargetLanguages { get; set; }
        
        [JsonProperty("labelIds")]
        public int[] LabelIds { get; set; }
        
        [JsonProperty("excludeLabelIds")]
        public int[] ExcludeLabelIds { get; set; }
        
        [JsonProperty("timeRange")]
        public string TimeRange { get; set; }

        [JsonProperty("buyUrl")]
        public string BuyUrl { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("hash")]
        public string? Hash { get; set; }
        
        [JsonProperty("isArchived")]
        public bool? IsArchived { get; set; }
        
        [JsonProperty("labelMatchRule")]
        public LabelMatchRule? LabelMatchRule { get; set; }
        
        [JsonProperty("excludeLabelMatchRule")]
        public LabelMatchRule? ExcludeLabelMatchRule { get; set; }
        
        [JsonProperty("estimatedCost")]
        public TaskCost? EstimatedCost { get; set; }
        
        [JsonProperty("actualCost")]
        public TaskCost? ActualCost { get; set; }
    }
}