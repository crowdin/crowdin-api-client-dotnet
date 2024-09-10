
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public enum AiPromptMode
    {
        [Description("basic")]
        Basic,
        
        [Description("advanced")]
        Advanced,
        
        [Description("external")]
        External
    }
}