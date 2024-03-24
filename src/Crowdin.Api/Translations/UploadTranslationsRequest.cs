
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public class UploadTranslationsRequest
    {
        [JsonProperty("storageId")]
        public int StorageId { get; set; }
        
        [JsonProperty("fileId")]
        public int FileId { get; set; }
        
        [JsonProperty("importEqSuggestions")]
        public bool? ImportEqSuggestions { get; set; }
        
        [JsonProperty("autoApproveImported")]
        public bool? AutoApproveImported { get; set; }
        
        [JsonProperty("translateHidden")]
        public bool? TranslateHidden { get; set; }
    }
}