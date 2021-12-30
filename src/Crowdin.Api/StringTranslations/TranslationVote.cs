
using System;
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.StringTranslations
{
    [PublicAPI]
    public class TranslationVote
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("user")]
        public User User { get; set; }
        
        [JsonProperty("translationId")]
        public int TranslationId { get; set; }
        
        [JsonProperty("votedAt")]
        public DateTimeOffset VotedAt { get; set; }
        
        [JsonProperty("mark")]
        public TranslationVoteMark Mark { get; set; }
    }

    [PublicAPI]
    public enum TranslationVoteMark
    {
        [Description("up")]
        Up,
        
        [Description("down")]
        Down
    }
}