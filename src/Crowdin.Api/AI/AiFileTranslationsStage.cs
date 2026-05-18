
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public enum AiFileTranslationsStage
    {
        [Description("start")]
        Start,
        
        [Description("import")]
        Import,
        
        [Description("translate")]
        Translate,
        
        [Description("export")]
        Export,
        
        [Description("done")]
        Done
    }
}