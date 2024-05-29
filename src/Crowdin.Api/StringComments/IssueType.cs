
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.StringComments
{
    [PublicAPI]
    public enum IssueType
    {
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