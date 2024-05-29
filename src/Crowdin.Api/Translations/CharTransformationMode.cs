
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public enum CharTransformationMode
    {
        [SerializedValue("asian")]
        Asian,
        
        [SerializedValue("cyrillic")]
        Cyrillic,
        
        [SerializedValue("european")]
        European,
        
        [SerializedValue("arabic")]
        Arabic
    }
}