
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api
{
    [PublicAPI]
    public enum TranslatorRoleName
    {
        [SerializedValue("translator")]
        Translator,
        
        [SerializedValue("proofreader")]
        Proofreader,
        
        [SerializedValue("owner")]
        Owner,
        
        [SerializedValue("manager")]
        Manager
    }
}