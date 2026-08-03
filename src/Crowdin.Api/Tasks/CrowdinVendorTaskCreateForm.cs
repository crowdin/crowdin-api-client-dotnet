
using System;
using System.Collections.Generic;

using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Labels;

#nullable enable

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public class CrowdinVendorTaskCreateForm : AddTaskRequest
    {
        [JsonProperty("title")]
#pragma warning disable CS8618
        public string Title { get; set; }
#pragma warning restore CS8618

        [JsonProperty("languageId")]
#pragma warning disable CS8618
        public string LanguageId { get; set; }
#pragma warning restore CS8618

        [JsonProperty("type")]
        public TaskType Type { get; set; }

        [JsonProperty("vendor")]
#pragma warning disable CS8618
        public string Vendor { get; set; }
#pragma warning restore CS8618

        [JsonProperty("branchIds")]
        public ICollection<long>? BranchIds { get; set; }

        [JsonProperty("directoryIds")]
        public ICollection<long>? DirectoryIds { get; set; }

        [JsonProperty("fileIds")]
        public ICollection<long>? FileIds { get; set; }

        [JsonProperty("stringIds")]
        public ICollection<long>? StringIds { get; set; }

        [JsonProperty("status")]
        public TaskStatus? Status { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("labelIds")]
        public ICollection<long>? LabelIds { get; set; }

        [JsonProperty("labelMatchRule")]
        public LabelMatchRule? LabelMatchRule { get; set; }

        [JsonProperty("excludeLabelIds")]
        public ICollection<long>? ExcludeLabelIds { get; set; }

        [JsonProperty("excludeLabelMatchRule")]
        public LabelMatchRule? ExcludeLabelMatchRule { get; set; }

        [JsonProperty("skipAssignedStrings")]
        public bool? SkipAssignedStrings { get; set; }

        [JsonProperty("includePreTranslatedStringsOnly")]
        public bool? IncludePreTranslatedStringsOnly { get; set; }

        [JsonProperty("deadline")]
        public DateTimeOffset? DeadLine { get; set; }

        [JsonProperty("dateFrom")]
        public DateTimeOffset? DateFrom { get; set; }

        [JsonProperty("dateTo")]
        public DateTimeOffset? DateTo { get; set; }

        [JsonProperty("translationsUpdatedDateFrom")]
        public DateTimeOffset? TranslationsUpdatedDateFrom { get; set; }

        [JsonProperty("translationsUpdatedDateTo")]
        public DateTimeOffset? TranslationsUpdatedDateTo { get; set; }

        [JsonProperty("generateCostEstimate")]
        public bool? GenerateCostEstimate { get; set; }

        [JsonProperty("generateTranslationCost")]
        public bool? GenerateTranslationCost { get; set; }

        [JsonProperty("reportSettingsTemplateId")]
        public long? ReportSettingsTemplateId { get; set; }

        [JsonProperty("batchId")]
        public long? BatchId { get; set; }
    }
}
