
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public class ImportGlossaryRequest
    {
        [JsonProperty("storageId")]
        public int StorageId { get; set; }
        
        [JsonProperty("scheme")]
        public IDictionary<string, int>? Scheme { get; set; }
        
        [JsonProperty("firstLineContainsHeader")]
        public bool? FirstLineContainsHeader { get; set; }
    }
}