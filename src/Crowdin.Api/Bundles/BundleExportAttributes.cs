
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Bundles
{
    [PublicAPI]
    public class BundleExportAttributes
    {
        [JsonProperty("bundleId")]
        public long BundleId { get; set; }
    }
}