
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public class ExportGlossaryRequest
    {
        [JsonProperty("format")]
        public GlossaryFormat Format { get; set; }

        [JsonProperty("exportFields")]
        public ICollection<GlossaryExportFieldId>? ExportFields { get; set; }

        [JsonProperty("exportType")]
        public GlossaryExportType? ExportType { get; set; }

        [JsonProperty("statuses")]
        public ICollection<TermStatus>? Statuses { get; set; }

        [JsonProperty("partsOfSpeech")]
        public ICollection<PartOfSpeech>? PartsOfSpeech { get; set; }

        [JsonProperty("types")]
        public ICollection<TermType>? Types { get; set; }

        [JsonProperty("genders")]
        public ICollection<TermGender>? Genders { get; set; }

        [JsonProperty("authorIds")]
        public ICollection<long>? AuthorIds { get; set; }

        [JsonProperty("languageIds")]
        public ICollection<string>? LanguageIds { get; set; }
    }
}
