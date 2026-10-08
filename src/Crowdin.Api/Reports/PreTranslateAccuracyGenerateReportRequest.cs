
using System;
using System.Collections.Generic;

using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class PreTranslateAccuracyGenerateReportRequest : GenerateReportRequest
    {
        [JsonProperty("name")]
        public string Name => "pre-translate-accuracy";

        [JsonProperty("schema")]
        public SchemaBase Schema { get; set; } = null!;

        [PublicAPI]
        public abstract class SchemaBase
        {
            [JsonProperty("unit")]
            public ReportUnit? Unit { get; set; }
            
            [JsonProperty("format")]
            public ReportFormat? Format { get; set; }
            
            [JsonProperty("postEditingCategories")]
            [Obsolete(MessageTexts.UseMatchScoreCategoriesInstead, false)]
            public ICollection<string>? PostEditingCategories { get; set; }

            [JsonProperty("matchScoreCategories")]
            public ICollection<string>? MatchScoreCategories { get; set; }
        }

        [PublicAPI]
        public class GeneralSchema : SchemaBase
        {
            [JsonProperty("languageId")]
            public string? LanguageId { get; set; }
            
            [JsonProperty("dateFrom")]
            public DateTimeOffset? DateFrom { get; set; }
            
            [JsonProperty("dateTo")]
            public DateTimeOffset? DateTo { get; set; }
        }

        [PublicAPI]
        public class ByTaskSchema : SchemaBase
        {
            [JsonProperty("taskId")]
            public long? TaskId { get; set; }
        }
    }
}
