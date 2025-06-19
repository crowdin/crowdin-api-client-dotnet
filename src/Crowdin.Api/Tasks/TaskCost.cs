
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public class TaskCost
    {
        [JsonProperty("cost")]
        public float Cost { get; set; }
        
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }
        
        [JsonProperty("currency")]
        public Currency Currency { get; set; }
    }
}