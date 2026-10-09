#nullable enable

using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiSnippetPatch : PatchEntry
    {
        [JsonProperty("path")]
        public AiSnippetPatchPath Path { get; set; }
    }
}
