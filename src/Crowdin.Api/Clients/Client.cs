using JetBrains.Annotations;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Crowdin.Api.Clients
{
    [PublicAPI]
    public class Client
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("status")]
        public ClientStatus Status { get; set; }
    }

    [PublicAPI]
    public enum ClientStatus
    {
        [Description("pending")]
        Pending,

        [Description("confirmed")]
        Confirmed,

        [Description("rejected")]
        Rejected,

        [Description("deleted")]
        Deleted
    }
}