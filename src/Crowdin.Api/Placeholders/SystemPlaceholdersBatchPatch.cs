#nullable enable

using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Core;

namespace Crowdin.Api.Placeholders
{
    [PublicAPI]
    public class SystemPlaceholdersBatchPatch
    {
        [JsonProperty("op")]
        public PatchOperation Op { get; set; } = PatchOperation.Replace;

        [JsonProperty("path")]
        public string Path { get; set; } = null!;

        [JsonProperty("value")]
        public bool Value { get; set; }

        public static SystemPlaceholdersBatchPatch ForKey(SystemPlaceholderKey key, bool isEnabled)
        {
            string wireKey = key.ToDescriptionString();
            return new SystemPlaceholdersBatchPatch { Path = $"/{wireKey}/isEnabled", Value = isEnabled };
        }
    }
}
