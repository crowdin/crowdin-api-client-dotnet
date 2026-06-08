
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.StyleGuides
{
    [PublicAPI]
    public class StyleGuidePatch : PatchEntry
    {
        [JsonProperty("path")]
        public StyleGuidePatchPath Path { get; set; }
    }

    [PublicAPI]
    public enum StyleGuidePatchPath
    {
        [Description("/name")]
        Name,

        [Description("/aiInstructions")]
        AiInstructions,

        [Description("/languageIds")]
        LanguageIds,

        [Description("/projectIds")]
        ProjectIds,

        [Description("/isShared")]
        IsShared,

        [Description("/storageId")]
        StorageId
    }
}
