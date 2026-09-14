#nullable enable

using System.ComponentModel;

using JetBrains.Annotations;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public enum AiRequestLogSourceAction
    {
        [Description("ai_proxy")]
        AiProxy,

        [Description("ai_gateway")]
        AiGateway,

        [Description("ai_translate_strings")]
        AiTranslateStrings,

        [Description("ai_file_translate")]
        AiFileTranslate,

        [Description("ai_prompt_completion")]
        AiPromptCompletion,

        [Description("pre_translate:manual")]
        PreTranslateManual,

        [Description("pre_translate:workflow")]
        PreTranslateWorkflow,

        [Description("ai_alignment")]
        AiAlignment,

        [Description("qa_check")]
        QaCheck,

        [Description("ai_suggestion")]
        AiSuggestion,

        [Description("advisor")]
        Advisor
    }
}
