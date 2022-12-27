
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Workflows
{
    [PublicAPI]
    public class WorkflowTranslationByVendorConfig : WorkflowConfig
    {
        [JsonProperty("vendorId")]
        public int VendorId { get; set; }
    }
}