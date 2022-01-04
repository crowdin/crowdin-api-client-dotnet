
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.StringComments
{
    [PublicAPI]
    public enum StringCommentType
    {
        [Description("comment")]
        Comment,
        
        [Description("issue")]
        Issue
    }
}