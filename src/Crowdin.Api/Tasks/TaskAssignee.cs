
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public class TaskAssignee
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("username")]
        public string UserName { get; set; }
        
        [JsonProperty("fullName")]
        public string FullName { get; set; }
        
        [JsonProperty("avatarUrl")]
        public string AvatarUrl { get; set; }
        
        [JsonProperty("wordsCount")]
        public int WordsCount { get; set; }
        
        [JsonProperty("wordsLeft")]
        public int WordsLeft { get; set; }
    }
}