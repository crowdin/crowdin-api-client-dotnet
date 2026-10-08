#nullable enable

using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiUsageMember
    {
        [JsonProperty("user")]
        public AiUsageMemberUser User { get; set; } = null!;

        [JsonProperty("dailyCostLimit")]
        public double? DailyCostLimit { get; set; }

        [JsonProperty("dailyCostSpent")]
        public double DailyCostSpent { get; set; }

        [JsonProperty("dailyResetAt")]
        public DateTimeOffset DailyResetAt { get; set; }

        [JsonProperty("monthlyCostLimit")]
        public double? MonthlyCostLimit { get; set; }

        [JsonProperty("monthlyCostSpent")]
        public double MonthlyCostSpent { get; set; }

        [JsonProperty("monthlyResetAt")]
        public DateTimeOffset MonthlyResetAt { get; set; }
    }
}
