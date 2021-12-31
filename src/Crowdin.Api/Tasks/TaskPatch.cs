
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public class TaskPatch : TaskPatchBase
    {
        [JsonProperty("path")]
        public TaskPatchPath Path { get; set; }
    }

    [PublicAPI]
    public enum TaskPatchPath
    {
        [Description("/status")]
        Status,
        
        [Description("/title")]
        Title,
        
        [Description("/description")]
        Description,
        
        [Description("/deadline")]
        DeadLine,
        
        [Description("/splitFiles")]
        SplitFiles,
        
        [Description("/fileIds")]
        FileIds,
        
        [Description("/assignees")]
        Assignees,
        
        [Description("/dateFrom")]
        DateFrom,
        
        [Description("/dateTo")]
        DateTo,
        
        [Description("labelIds")]
        LabelIds
    }
}