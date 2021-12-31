
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public class TaskArchivedStatusPatch : PatchEntry
    {
        [JsonProperty("op")]
        public new PatchOperation Operation => PatchOperation.Replace;

        [JsonProperty("path")]
        public TaskArchivedStatusPatchPath Path => TaskArchivedStatusPatchPath.IsArchived;
        
        [JsonProperty("value")]
        public new bool Value { get; set; }
    }

    [PublicAPI]
    public enum TaskArchivedStatusPatchPath
    {
        [Description("/isArchived")]
        IsArchived
    }
}