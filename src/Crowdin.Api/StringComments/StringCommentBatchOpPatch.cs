
using System.ComponentModel;

using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Core;
using Crowdin.Api.Core.Converters;

namespace Crowdin.Api.StringComments
{
    [PublicAPI]
    public class StringCommentBatchOpPatch : PatchEntry
    {
        [JsonProperty("path")]
        public StringCommentBatchOpPatchPath Path { get; set; }
    }

    [PublicAPI]
    [CallToStringForSerialization]
    public class StringCommentBatchOpPatchPath
    {
        private readonly string _commentId;
        private readonly string _pathCode;

        public StringCommentBatchOpPatchPath(int? commentId = null, Code? pathCode = null)
        {
            _commentId = commentId?.ToString() ?? "-";
            _pathCode = pathCode.HasValue ? pathCode.ToDescriptionString() : "";
        }

        public override string ToString()
        {
            return $"/{_commentId}{_pathCode}";
        }
        
        public static StringCommentBatchOpPatchPath Empty => new StringCommentBatchOpPatchPath();

        [PublicAPI]
        public enum Code
        {
            [Description("/text")]
            Text,
            
            [Description("/issueStatus")]
            IssueStatus
        }
    }
}