
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.MachineTranslationEngines
{
    [PublicAPI]
    public enum MtEngineType
    {
        [SerializedValue("google")]
        Google,
        
        [SerializedValue("google_automl")]
        // ReSharper disable once InconsistentNaming
        GoogleAutoML,
        
        [SerializedValue("microsoft")]
        Microsoft,
        
        [SerializedValue("yandex")]
        Yandex,
        
        [SerializedValue("deepl")]
        DeepL,
        
        [SerializedValue("amazon")]
        Amazon,
        
        [SerializedValue("watson")]
        Watson,
        
        [SerializedValue("modernmt")]
        // ReSharper disable once InconsistentNaming
        ModernMT,
        
        [SerializedValue("custom_mt")]
        // ReSharper disable once InconsistentNaming
        CustomMT
    }
}