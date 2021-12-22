
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Screenshots
{
    public class ReplaceTagsRequest
    {
        
    }

    public class AddTagRequest : ReplaceTagsRequest
    {
        [JsonProperty("stringId")]
        public int StringId { get; set; }
        
        [JsonProperty("position")]
        public Position? Position { get; set; }
    }

    public class AutoTagReplaceTagsRequest : ReplaceTagsRequest
    {
        [JsonProperty("autoTag")]
        public bool AutoTag { get; set; }
    }
}