
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.StringComments
{
    [PublicAPI]
    public enum IssueType
    {
        [Description("general_question")]
        GeneralQuestion,
        
        [Description("translation_mistake")]
        TranslationMistake,
        
        [Description("context_request")]
        ContextRequest,
        
        [Description("source_mistake")]
        SourceMistake
    }
}