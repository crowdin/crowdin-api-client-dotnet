
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.MachineTranslationEngines
{
    [PublicAPI]
    public enum LanguageRecognitionProvider
    {
        [SerializedValue("crowdin")]
        Crowdin,
        
        [SerializedValue("engine")]
        Engine
    }
}