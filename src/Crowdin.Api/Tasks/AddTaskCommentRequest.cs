
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public class AddTaskCommentRequest
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        
        [JsonProperty("timeSpent")]
        public long? TimeSpent { get; set; }
    }
}