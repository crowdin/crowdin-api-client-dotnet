
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public class GroupPatch : PatchEntry
    {
        [JsonProperty("path")]
        public GroupPatchPath Path { get; set; }
    }

    [PublicAPI]
    public enum GroupPatchPath
    {
        [Description("/name")]
        Name,
        
        [Description("/description")]
        Description,
        
        [Description("/parentId")]
        ParentId
    }
}