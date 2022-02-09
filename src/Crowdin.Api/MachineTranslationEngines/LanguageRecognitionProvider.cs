
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.MachineTranslationEngines
{
    [PublicAPI]
    public enum LanguageRecognitionProvider
    {
        [Description("crowdin")]
        Crowdin,
        
        [Description("engine")]
        Engine
    }
}