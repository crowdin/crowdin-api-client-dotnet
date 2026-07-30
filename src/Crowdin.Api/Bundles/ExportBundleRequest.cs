
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Bundles
{
    [PublicAPI]
    public class ExportBundleRequest
    {
    }

    [PublicAPI]
    public class CrowdinExportBundleRequest : ExportBundleRequest
    {
        [JsonProperty("targetLanguageIds")]
        public ICollection<string>? TargetLanguageIds { get; set; }

        [JsonProperty("skipUntranslatedStrings")]
        public bool? SkipUntranslatedStrings { get; set; }

        [JsonProperty("skipUntranslatedFiles")]
        public bool? SkipUntranslatedFiles { get; set; }

        [JsonProperty("exportApprovedOnly")]
        public bool? ExportApprovedOnly { get; set; }
    }

    [PublicAPI]
    public class EnterpriseExportBundleRequest : ExportBundleRequest
    {
        [JsonProperty("targetLanguageIds")]
        public ICollection<string>? TargetLanguageIds { get; set; }

        [JsonProperty("skipUntranslatedStrings")]
        public bool? SkipUntranslatedStrings { get; set; }

        [JsonProperty("skipUntranslatedFiles")]
        public bool? SkipUntranslatedFiles { get; set; }

        [JsonProperty("exportWithMinApprovalsCount")]
        public int? ExportWithMinApprovalsCount { get; set; }

        [JsonProperty("exportStringsThatPassedWorkflow")]
        public bool? ExportStringsThatPassedWorkflow { get; set; }
    }
}
