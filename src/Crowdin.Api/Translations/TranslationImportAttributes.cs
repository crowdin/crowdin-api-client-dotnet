using System.Collections.Generic;
using Newtonsoft.Json;

namespace Crowdin.Api.Translations
{
    public class TranslationImportAttributes
    {
        [JsonProperty("storageId")]
        public long StorageId { get; set; }

        [JsonProperty("fileId")]
        public long FileId { get; set; }

        [JsonProperty("importEqSuggestions")]
        public bool ImportEqSuggestions { get; set; }

        [JsonProperty("autoApproveImported")]
        public bool AutoApproveImported { get; set; }

        [JsonProperty("translateHidden")]
        public bool TranslateHidden { get; set; }

        [JsonProperty("addToTm")]
        public bool AddToTm { get; set; }

        [JsonProperty("languageIds")]
        public List<string> LanguageIds { get; set; }
    }
}