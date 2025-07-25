﻿
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public class UploadTranslationsResponse
    {
        [JsonProperty("projectId")]
        public long ProjectId { get; set; }
        
        [JsonProperty("storageId")]
        public long StorageId { get; set; }
        
        [JsonProperty("languageId")]
        public string LanguageId { get; set; }
        
        [JsonProperty("fileId")]
        public long? FileId { get; set; }
        
        [JsonProperty("branchId")]
        public long? BranchId { get; set; }
    }
}