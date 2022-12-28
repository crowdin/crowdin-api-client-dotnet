
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Workflows
{
    [PublicAPI]
    public class WorkflowProofreadingByVendorConfig : WorkflowConfig
    {
        [JsonProperty("vendorId")]
        public int VendorId { get; set; }
    }
}