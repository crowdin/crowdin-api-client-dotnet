
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.MachineTranslationEngines
{
    [PublicAPI]
    public class MtEngine
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("groupId")]
        public long GroupId { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("credentials")]
        public IDictionary<string, object> Credentials { get; set; }
        
        [JsonProperty("projectIds")]
        public long[] ProjectIds { get; set; }

        [JsonProperty("supportedLanguageIds")]
        public string[] SupportedLanguageIds { get; set; }

        [JsonProperty("supportedLanguagePairs")]
        public IDictionary<string, string[]> SupportedLanguagePairs { get; set; }

        [JsonProperty("enabledProjectIds")]
        public long[] EnabledProjectIds { get; set; }

        [JsonProperty("enabledLanguageIds")]
        public string[] EnabledLanguageIds { get; set; }

        [JsonProperty("isEnabled")]
        public bool IsEnabled { get; set; }
    }
}