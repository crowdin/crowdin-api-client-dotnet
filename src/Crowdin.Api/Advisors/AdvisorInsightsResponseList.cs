#nullable enable

using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Advisors
{
    [PublicAPI]
    public class AdvisorInsightsResponseList
    {
        [JsonProperty("data")]
        public List<AdvisorInsight> Data { get; set; } = new List<AdvisorInsight>();

        [JsonProperty("pagination")]
        public AdvisorInsightsPagination? Pagination { get; set; }
    }
}
