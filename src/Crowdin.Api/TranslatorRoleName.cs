
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api
{
    [PublicAPI]
    public enum TranslatorRoleName
    {
        [Description("translator")]
        Translator,
        
        [Description("proofreader")]
        Proofreader,
        
        [Description("owner")]
        Owner,
        
        [Description("manager")]
        Manager
    }
}