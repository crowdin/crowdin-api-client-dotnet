using JetBrains.Annotations;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace Crowdin.Api.Applications
{
    [PublicAPI]
    public class ApplicationProject
    {
        [JsonProperty("value")]
        public ApplicationProjectValue Value { get; set; }

        [JsonProperty("ids")]
        public ICollection<int> Ids { get; set; }
    }

    [PublicAPI]
    public enum ApplicationProjectValue
    {
        [Description("own")]
        Own,
        [Description("restricted")]
        Restricted
    }
}
