
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public class TaskArchivedStatusPatch : PatchEntry
    {
        [JsonProperty("path")]
        public TaskArchivedStatusPatchPath Path { get; set; }
    }

    [PublicAPI]
    public enum TaskArchivedStatusPatchPath
    {
        [SerializedValue("/isArchived")]
        IsArchived
    }
}