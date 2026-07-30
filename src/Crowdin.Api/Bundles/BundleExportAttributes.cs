
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Bundles
{
    [PublicAPI]
    public class BundleExportAttributes
    {
        [JsonProperty("bundleId")]
        public long BundleId { get; set; }

        [JsonProperty("targetLanguageIds")]
        public string[]? TargetLanguageIds { get; set; }

        [JsonProperty("skipUntranslatedStrings")]
        public bool SkipUntranslatedStrings { get; set; }

        [JsonProperty("skipUntranslatedFiles")]
        public bool SkipUntranslatedFiles { get; set; }

        [JsonProperty("exportApprovedOnly")]
        public bool? ExportApprovedOnly { get; set; }

        [JsonProperty("exportWithMinApprovalsCount")]
        public int? ExportWithMinApprovalsCount { get; set; }

        [JsonProperty("exportStringsThatPassedWorkflow")]
        public bool? ExportStringsThatPassedWorkflow { get; set; }
    }
}
