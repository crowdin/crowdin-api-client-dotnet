
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.TranslationMemory
{
    [PublicAPI]
    public class ImportTmRequest
    {
        [JsonProperty("storageId")]
        public long StorageId { get; set; }
        
        [JsonProperty("firstLineContainsHeader")]
        public bool? FirstLineContainsHeader { get; set; }
        
        [JsonProperty("scheme")]
        public IDictionary<string, int>? Scheme { get; set; }
    }
}