
using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Core.Converters;

namespace Crowdin.Api.StringTranslations
{
    [PublicAPI]
    public class ApprovalBatchOpPatch : PatchEntry
    {
        [JsonProperty("path")]
        public ApprovalBatchOpPatchPath Path { get; set; }
    }

    [PublicAPI]
    [CallToStringForSerialization]
    public class ApprovalBatchOpPatchPath
    {
        private readonly string _approvalId;

        public ApprovalBatchOpPatchPath(int? approvalId = null)
        {
            _approvalId = approvalId?.ToString() ?? "-";
        }

        public override string ToString()
        {
            return $"/{_approvalId}";
        }
        
        public static ApprovalBatchOpPatchPath Empty => new ApprovalBatchOpPatchPath();
    }
}