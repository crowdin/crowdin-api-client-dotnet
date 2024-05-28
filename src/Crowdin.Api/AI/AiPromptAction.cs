
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public enum AiPromptAction
    {
        [Description("pre_translate")]
        PreTranslate
    }
}