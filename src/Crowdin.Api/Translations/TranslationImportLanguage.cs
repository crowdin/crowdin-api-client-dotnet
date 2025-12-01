using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public class TranslationImportLanguage
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("files")]
        public List<TranslationImportFile> Files { get; set; }

        [JsonProperty("skipped")]
        public TranslationImportSkipped Skipped { get; set; }

        [JsonProperty("skippedQaCheckCategories")]
        public ImportSkippedQaCheckCategories SkippedQaCheckCategories { get; set; }
    }
}