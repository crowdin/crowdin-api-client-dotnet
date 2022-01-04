
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.StringComments
{
    [PublicAPI]
    public class AddStringCommentRequest
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        
        [JsonProperty("stringId")]
        public int StringId { get; set; }
        
        [JsonProperty("targetLanguageId")]
        public string TargetLanguageId { get; set; }
        
        [JsonProperty("type")]
        public StringCommentType Type { get; set; }
        
        [JsonProperty("issueType")]
        public IssueType? IssueType { get; set; }
    }
}