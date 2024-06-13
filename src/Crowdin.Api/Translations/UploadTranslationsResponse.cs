
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public class UploadTranslationsResponse
    {
        [JsonProperty("projectId")]
        public int ProjectId { get; set; }
        
        [JsonProperty("storageId")]
        public long StorageId { get; set; }
        
        [JsonProperty("languageId")]
        public string LanguageId { get; set; }
        
        [JsonProperty("fileId")]
        public int? FileId { get; set; }
        
        [JsonProperty("branchId")]
        public int? BranchId { get; set; }
    }
}