﻿
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Screenshots
{
    [PublicAPI]
    public class TagPatch : PatchEntry
    {
        [JsonProperty("path")]
        public TagPatchPath Path { get; set; }
    }

    [PublicAPI]
    public enum TagPatchPath
    {
        [Description("/stringId")]
        StringId,
        
        [Description("/position")]
        Position
    }
}