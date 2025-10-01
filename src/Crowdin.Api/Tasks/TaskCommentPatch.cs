
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public class TaskCommentPatch : PatchEntry
    {
        [JsonProperty("path")]
        public TaskCommentPatchPath Path { get; set; }
    }

    [PublicAPI]
    public enum TaskCommentPatchPath
    {
        [Description("/text")]
        Text,
        
        [Description("/timeSpent")]
        TimeSpent
    }
}