
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.StringComments
{
    [PublicAPI]
    public class StringCommentPatch : PatchEntry
    {
        [JsonProperty("path")]
        public StringCommentPatchPath Path { get; set; }
    }

    [PublicAPI]
    public enum StringCommentPatchPath
    {
        [SerializedValue("/text")]
        Text,
        
        [SerializedValue("/issueStatus")]
        IssueStatus
    }
}