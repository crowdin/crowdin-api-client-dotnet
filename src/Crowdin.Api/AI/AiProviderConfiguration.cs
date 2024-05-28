
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiProviderConfiguration
    {
        [JsonProperty("actionRules")]
        public List<ActionRule> ActionRules { get; set; }
    }
}