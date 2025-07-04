
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Workflows
{
    [PublicAPI]
    public class WorkflowTranslationByVendorConfig : WorkflowConfig
    {
        [JsonProperty("vendorId")]
        public long VendorId { get; set; }
    }
}