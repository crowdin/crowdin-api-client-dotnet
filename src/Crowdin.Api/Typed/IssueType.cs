using Crowdin.Api.Protocol;

namespace Crowdin.Api.Typed
{
    public enum IssueType
    {
        All,

        [Property("source_mistake")]
        SourceMistake,

        [Property("context_request")]
        ContextRequest,

        [Property("translation_mistake")]
        TranslationMistake,

        [Property("general_question")]
        GeneralQuestion
    }
}
