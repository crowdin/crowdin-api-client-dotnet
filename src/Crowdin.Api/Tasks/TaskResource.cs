
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Languages;

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
        
        [JsonProperty("vendor")]
        public string Vendor { get; set; }
        
        [JsonProperty("status")]
        public TaskStatus Status { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("batchId")]
        public int BatchId { get; set; }
        
        [JsonProperty("assignees")]
        public TaskAssignee[] Assignees { get; set; }
        
        [JsonProperty("assignedTeams")]
        public TaskAssignedTeam[] AssignedTeams { get; set; }
        
        [JsonProperty("fileIds")]
        public int[] FileIds { get; set; }
        
        [JsonProperty("progress")]
        public TaskProgress Progress { get; set; }
        
        [JsonProperty("translateProgress")]
        public TaskProgress TranslateProgress { get; set; }
        
        [JsonProperty("sourceLanguageId")]
        public string SourceLanguageId { get; set; }
        
        [JsonProperty("targetLanguageId")]
        public string TargetLanguageId { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("hash")]
        public string Hash { get; set; }
        
        [JsonProperty("translationUrl")]
        public string TranslationUrl { get; set; }
        
        [JsonProperty("wordsCount")]
        public int WordsCount { get; set; }
        
        [JsonProperty("filesCount")]
        public int FilesCount { get; set; }
        
        [JsonProperty("commentsCount")]
        public int CommentsCount { get; set; }
        
        [JsonProperty("deadline")]
        public DateTimeOffset DeadLine { get; set; }
        
        [JsonProperty("timeRange")]
        public string TimeRange { get; set; }
        
        [JsonProperty("workflowStepId")]
        public int WorkFlowStepId { get; set; }
        
        [JsonProperty("buyUrl")]
        public string BuyUrl { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
        
        [JsonProperty("isArchived")]
        public bool? IsArchived { get; set; }
        
        [JsonProperty("sourceLanguage")]
        public Language SourceLanguage { get; set; }
        
        [JsonProperty("targetLanguages")]
        public Language[] TargetLanguages { get; set; }
        
        [JsonProperty("labelIds")]
        public int[] LabelIds { get; set; }
        
        [JsonProperty("excludeLabelIds")]
        public int[] ExcludeLabelIds { get; set; }
        
        [JsonProperty("labelMatchRule")]
        public string LabelMatchRule { get; set; }
        
        [JsonProperty("precedingTaskId")]
        public int PrecedingTaskId { get; set; }
    }
}