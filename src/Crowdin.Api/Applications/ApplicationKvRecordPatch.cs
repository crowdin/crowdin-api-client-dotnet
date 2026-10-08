#nullable enable

using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.Applications
{
    [PublicAPI]
    public class ApplicationKvRecordPatch
    {
        [JsonProperty("op")]
        public PatchOperation Op { get; set; } = PatchOperation.Replace;

        [JsonProperty("path")]
        public ApplicationKvRecordPatchPath Path { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Include)]
        public JToken? Value { get; set; }
    }
}
