
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.StyleGuides
{
    [PublicAPI]
    public class StyleGuide
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("aiInstructions")]
        public string? AiInstructions { get; set; }

        [JsonProperty("userId")]
        public long UserId { get; set; }

        [JsonProperty("languageIds")]
        public string[]? LanguageIds { get; set; }

        [JsonProperty("projectIds")]
        public long[]? ProjectIds { get; set; }

        [JsonProperty("isShared")]
        public bool IsShared { get; set; }

        [JsonProperty("webUrl")]
        public string WebUrl { get; set; } = null!;

        [JsonProperty("downloadLink")]
        public string DownloadLink { get; set; } = null!;

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
