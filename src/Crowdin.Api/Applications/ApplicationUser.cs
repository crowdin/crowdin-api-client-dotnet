using JetBrains.Annotations;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace Crowdin.Api.Applications
{
    [PublicAPI]
    public class ApplicationUser
    {
        [JsonProperty("value")]
        public ApplicationUserValue Value { get; set; }

        [JsonProperty("ids")]
        public ICollection<int> Ids { get; set; }
    }

    [PublicAPI]
    public enum ApplicationUserValue
    {
        [Description("owner")]
        Owner,

        [Description("managers")]
        Managers,

        [Description("all")]
        All,

        [Description("guests")]
        Guests,

        [Description("restricted")]
        Restricted
    }
}
