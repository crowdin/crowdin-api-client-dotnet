
using System;
using System.ComponentModel;

using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Core;

namespace Crowdin.Api.SourceFiles
{
    [PublicAPI]
    [Obsolete(MessageTexts.UseBranchesNamespace)]
    public class BranchPatch : PatchEntry
    {
        [JsonProperty("path")]
        public BranchPatchPath Path { get; set; }
    }

    [PublicAPI]
    [Obsolete(MessageTexts.UseBranchesNamespace)]
    public enum BranchPatchPath
    {
        [Description("/name")]
        Name,
        
        [Description("/title")]
        Title,
        
        [Description("/exportPattern")]
        ExportPattern,
        
        [Description("/priority")]
        Priority
    }
}