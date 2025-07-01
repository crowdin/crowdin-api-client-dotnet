
using System.Collections.Generic;

using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.SourceFiles;

#nullable enable

namespace Crowdin.Api.SourceStrings
{
    [PublicAPI]
    public class UploadStringsRequest
    {
        [JsonProperty("storageId")]
        public long StorageId { get; set; }
        
        [JsonProperty("branchId")]
        public long BranchId { get; set; }
        
        [JsonProperty("type")]
        public StringBasedProjectFileType? Type { get; set; }
        
        [JsonProperty("parserVersion")]
        public int? ParserVersion { get; set; }
        
        [JsonProperty("labelIds")]
        public ICollection<int>? LabelIds { get; set; }
        
        [JsonProperty("updateStrings")]
        public bool? UpdateStrings { get; set; }
        
        [JsonProperty("cleanupMode")]
        public bool? CleanupMode { get; set; }
        
        [JsonProperty("importOptions")]
        public SpreadsheetFileImportOptions? ImportOptions { get; set; }
        
        [JsonProperty("updateOption")]
        public UpdateOption? UpdateOption { get; set; }
    }
}