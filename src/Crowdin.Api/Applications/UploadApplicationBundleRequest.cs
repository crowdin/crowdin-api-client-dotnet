#nullable enable

using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.Applications
{
    [PublicAPI]
    public class UploadApplicationBundleRequest
    {
        [JsonProperty("storageId")]
        public long StorageId { get; set; }
    }
}
