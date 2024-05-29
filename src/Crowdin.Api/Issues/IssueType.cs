
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Issues
{
    [PublicAPI]
    public enum IssueType
    {
        [SerializedValue("all")]
        All,
        
        [SerializedValue("general_question")]
        GeneralQuestion,
        
        [SerializedValue("translation_mistake")]
        TranslationMistake,
        
        [SerializedValue("context_request")]
        ContextRequest,
        
        [SerializedValue("source_mistake")]
        SourceMistake
    }
}