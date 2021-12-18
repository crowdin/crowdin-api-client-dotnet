
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public enum CharTransformationMode
    {
        [Description("asian")]
        Asian,
        
        [Description("cyrillic")]
        Cyrillic,
        
        [Description("european")]
        European,
        
        [Description("arabic")]
        Arabic
    }
}