#nullable enable

using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Advisors
{
    [PublicAPI]
    public class AdvisorInsightsPagination
    {
        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
