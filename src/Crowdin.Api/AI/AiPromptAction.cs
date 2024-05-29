
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public enum AiPromptAction
    {
        [SerializedValue("pre_translate")]
        PreTranslate
    }
}