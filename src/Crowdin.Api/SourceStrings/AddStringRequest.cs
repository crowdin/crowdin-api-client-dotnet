
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.SourceStrings
{
    [PublicAPI]
    public class AddStringRequest
    {
        [JsonProperty("text")]
#pragma warning disable CS8618
        public string Text { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("identifier")]
        public string? Identifier { get; set; }
        
        [JsonProperty("fileId")]
        public long? FileId { get; set; }
        
        [JsonProperty("branchId")]
        public long? BranchId { get; set; }
        
        [JsonProperty("context")]
        public string? Context { get; set; }
        
        [JsonProperty("isHidden")]
        public bool? IsHidden { get; set; }
        
        [JsonProperty("maxLength")]
        public int? MaxLength { get; set; }
        
        [JsonProperty("labelIds")]
        public ICollection<int>? LabelIds { get; set; }
    }
}