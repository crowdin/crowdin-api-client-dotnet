﻿
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.TranslationMemory
{
    [PublicAPI]
    public class TmSegmentResource
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("records")]
        public TmSegmentRecord[] Records { get; set; }
    }
}