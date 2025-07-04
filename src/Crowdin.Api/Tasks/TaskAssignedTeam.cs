
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public class TaskAssignedTeam
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("wordsCount")]
        public int WordsCount { get; set; }
    }
}