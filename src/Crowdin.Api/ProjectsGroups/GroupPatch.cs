
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
        [SerializedValue("/name")]
        Name,
        
        [SerializedValue("/description")]
        Description,
        
        [SerializedValue("/parentId")]
        ParentId
    }
}