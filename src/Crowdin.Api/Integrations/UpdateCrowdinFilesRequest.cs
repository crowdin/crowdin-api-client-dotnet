#nullable enable

using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.Integrations
{
    [PublicAPI]
    public class UpdateCrowdinFilesRequest
    {
        [JsonProperty("projectId")]
        public long ProjectId { get; set; }

        [JsonProperty("files")]
        public JArray Files { get; set; } = new JArray();

        [JsonProperty("uploadTranslations")]
        public bool? UploadTranslations { get; set; } = false;
    }
}