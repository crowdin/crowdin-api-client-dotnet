﻿
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public class LanguageReference
    {
        [JsonProperty("languageId")]
#pragma warning disable CS8618
        public string LanguageId { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("userIds")]
        public long[]? UserIds { get; set; }
        
        [JsonProperty("teamIds")]
        public long[]? TeamIds { get; set; }
    }
}