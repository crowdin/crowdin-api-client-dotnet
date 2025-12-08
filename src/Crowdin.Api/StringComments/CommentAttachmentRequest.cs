using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.StringComments
{
    [PublicAPI]
    public class CommentAttachmentRequest
    {
        [JsonProperty("id")]
        public long Id { get; set; }
    }
}