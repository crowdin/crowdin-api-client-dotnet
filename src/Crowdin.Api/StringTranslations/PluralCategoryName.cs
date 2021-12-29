
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.StringTranslations
{
    [PublicAPI]
    public enum PluralCategoryName
    {
        [Description("zero")]
        Zero,
        
        [Description("one")]
        One,
        
        [Description("two")]
        Two,
        
        [Description("few")]
        Few,
        
        [Description("many")]
        Many,
        
        [Description("other")]
        Other
    }
}