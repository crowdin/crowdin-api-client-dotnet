
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
        [SerializedValue("/status")]
        Status,
        
        [SerializedValue("/title")]
        Title,
        
        [SerializedValue("/description")]
        Description,
        
        [SerializedValue("/deadline")]
        DeadLine,
        
        [SerializedValue("/splitFiles")]
        SplitFiles,
        
        [SerializedValue("/fileIds")]
        FileIds,
        
        [SerializedValue("/assignees")]
        Assignees,
        
        [SerializedValue("/dateFrom")]
        DateFrom,
        
        [SerializedValue("/dateTo")]
        DateTo,
        
        [SerializedValue("labelIds")]
        LabelIds
    }
}