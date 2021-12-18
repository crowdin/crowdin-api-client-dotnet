
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.SourceFiles
{
    [PublicAPI]
    public class RestoreFileRequest : UpdateOrRestoreFileRequest
    {
        [JsonProperty("revisionId")]
        public int RevisionId { get; set; }
    }
}