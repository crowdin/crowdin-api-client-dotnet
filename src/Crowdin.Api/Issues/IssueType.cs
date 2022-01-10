
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Issues
{
    [PublicAPI]
    public enum IssueType
    {
        [Description("all")]
        All,
        
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