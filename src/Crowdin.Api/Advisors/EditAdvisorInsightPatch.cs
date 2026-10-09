#nullable enable

using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Advisors
{
    [PublicAPI]
    public class EditAdvisorInsightPatch : PatchEntry
    {
        [JsonProperty("path")]
        public EditAdvisorInsightPatchPath Path { get; set; }
    }
}
