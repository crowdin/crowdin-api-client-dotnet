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
        [SerializedValue("owner")]
        Owner,

        [SerializedValue("managers")]
        Managers,

        [SerializedValue("all")]
        All,

        [SerializedValue("guests")]
        Guests,

        [SerializedValue("restricted")]
        Restricted
    }
}
