
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.StringComments
{
    [PublicAPI]
    public enum StringCommentType
    {
        [SerializedValue("comment")]
        Comment,
        
        [SerializedValue("issue")]
        Issue
    }
}