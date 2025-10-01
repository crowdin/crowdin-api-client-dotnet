
using System;
using System.Collections.Generic;

using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Tasks;

#nullable enable

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class GroupTaskUsageGenerateGroupReportRequest : GenerateGroupReportRequest
    {
        [JsonProperty("name")]
        public string Name => "group-task-usage";

        [JsonProperty("schema")]
        public SchemaBase Schema { get; set; } = null!;

        [PublicAPI]
        public abstract class SchemaBase
        {
            [JsonProperty("format")]
            public ReportFormat Format { get; set; }
            
            [JsonProperty("projectIds")]
            public ICollection<long>? ProjectIds { get; set; }
            
            [JsonProperty("dateFrom")]
            public DateTimeOffset? DateFrom { get; set; }
            
            [JsonProperty("dateTo")]
            public DateTimeOffset? DateTo { get; set; }
            
            [JsonProperty("groupBy")]
            public GroupingParameter? GroupBy { get; set; }
            
            [JsonProperty("typeTasks")]
            public TaskType? TypeTasks { get; set; }
            
            [JsonProperty("languageId")]
            public string? LanguageId { get; set; }
            
            [JsonProperty("creatorId")]
            public long? CreatorId { get; set; }
        }

        [PublicAPI]
        public class WorkloadSchema : SchemaBase
        {
            [JsonProperty("type")]
            public string Type => "workload";
            
            [JsonProperty("assigneeId")]
            public long? AssigneeId { get; set; }
        }

        [PublicAPI]
        public class CreatedVsResolvedSchema : SchemaBase
        {
            [JsonProperty("type")]
            public string Type => "created-vs-resolved";
        }

        [PublicAPI]
        public class PerformanceSchema : SchemaBase
        {
            [JsonProperty("type")]
            public string Type => "performance";
            
            [JsonProperty("assigneeId")]
            public long? AssigneeId { get; set; }
        }

        [PublicAPI]
        public class TimeSchema : SchemaBase
        {
            [JsonProperty("type")]
            public string Type => "time";
            
            [JsonProperty("assigneeId")]
            public long? AssigneeId { get; set; }
            
            [JsonProperty("wordsCountFrom")]
            public int? WordsCountFrom { get; set; }
            
            [JsonProperty("wordsCountTo")]
            public int? WordsCountTo { get; set; }
        }

        [PublicAPI]
        public class CostSchema : SchemaBase
        {
            [JsonProperty("type")]
            public string Type => "cost";
            
            [JsonProperty("statuses")]
            public ICollection<TaskStatus>? Statuses { get; set; }
        }
    }
}