
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.StyleGuides
{
    [PublicAPI]
    public class AddStyleGuideRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("storageId")]
        public long StorageId { get; set; }

        [JsonProperty("aiInstructions")]
        public string? AiInstructions { get; set; }

        [JsonProperty("languageIds")]
        public ICollection<string>? LanguageIds { get; set; }

        [JsonProperty("projectIds")]
        public ICollection<long>? ProjectIds { get; set; }

        [JsonProperty("isShared")]
        public bool? IsShared { get; set; }
    }
}
