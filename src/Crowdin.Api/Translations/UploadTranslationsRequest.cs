
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public class UploadTranslationsRequest
    {
        [JsonProperty("storageId")]
        public long StorageId { get; set; }
        
        [JsonProperty("branchId")]
        public int? BranchId { get; set; }
        
        [JsonProperty("fileId")]
        public int? FileId { get; set; }
        
        [JsonProperty("importEqSuggestions")]
        public bool? ImportEqSuggestions { get; set; }
        
        [JsonProperty("autoApproveImported")]
        public bool? AutoApproveImported { get; set; }
        
        [JsonProperty("translateHidden")]
        public bool? TranslateHidden { get; set; }
        
        [JsonProperty("addToTm")]
        public bool? AddToTm { get; set; }
    }
}