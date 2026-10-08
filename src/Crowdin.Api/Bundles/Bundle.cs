
using JetBrains.Annotations;
using Newtonsoft.Json;
using System;
using Crowdin.Api.Labels;

namespace Crowdin.Api.Bundles
{
    [PublicAPI]
    public class Bundle
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("sourcePatterns")]
        public string[] SourcePatterns { get; set; }

        [JsonProperty("ignorePatterns")]
        public string[] IgnorePatterns { get; set; }

        [JsonProperty("exportPattern")]
        public string ExportPattern { get; set; }

        [JsonProperty("isMultilingual")]
        public bool IsMultilingual { get; set; }

        [JsonProperty("includeProjectSourceLanguage")]
        public bool IncludeProjectSourceLanguage { get; set; }

        [JsonProperty("includeInContextPseudoLanguage")]
        public bool IncludeInContextPseudoLanguage { get; set; }

        [JsonProperty("sourceLanguageExportPattern")]
        public string SourceLanguageExportPattern { get; set; }

        [JsonProperty("labelIds")]
        public long[] LabelIds { get; set; }

        [JsonProperty("excludeLabelIds")]
        public long[] ExcludeLabelIds { get; set; }

        [JsonProperty("labelMatchRule")]
        public LabelMatchRule? LabelMatchRule { get; set; }

        [JsonProperty("excludeLabelMatchRule")]
        public LabelMatchRule? ExcludeLabelMatchRule { get; set; }

        [JsonProperty("languageIds")]
        public string[] LanguageIds { get; set; }
        
        [JsonProperty("webUrl")]
        public string WebUrl { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
