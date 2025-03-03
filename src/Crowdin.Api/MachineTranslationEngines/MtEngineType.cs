
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.MachineTranslationEngines
{
    [PublicAPI]
    public enum MtEngineType
    {
        [Description("google")]
        Google,
        
        [Description("google_automl")]
        // ReSharper disable once InconsistentNaming
        GoogleAutoML,
        
        [Description("microsoft")]
        Microsoft,
        
        [Description("yandex")]
        Yandex,
        
        [Description("deepl")]
        DeepL,
        
        [Description("amazon")]
        Amazon,
        
        [Description("modernmt")]
        // ReSharper disable once InconsistentNaming
        ModernMT,
        
        [Description("custom_mt")]
        // ReSharper disable once InconsistentNaming
        CustomMT
    }
}