
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public enum AiPromptMode
    {
        [SerializedValue("basic")]
        Basic,
        
        [SerializedValue("advanced")]
        Advanced
    }
}