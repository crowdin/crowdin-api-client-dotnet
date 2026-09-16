using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public class TaskSyncScope
    {
        [JsonProperty("syncedWords")]
        public int SyncedWords { get; set; }
        
        [JsonProperty("pendingWords")]
        public int PendingWords { get; set; }
        
        [JsonProperty("skippedWords")]
        public int SkippedWords { get; set; }
    }
}