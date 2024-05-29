
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.StringTranslations
{
    [PublicAPI]
    public enum PluralCategoryName
    {
        [SerializedValue("zero")]
        Zero,
        
        [SerializedValue("one")]
        One,
        
        [SerializedValue("two")]
        Two,
        
        [SerializedValue("few")]
        Few,
        
        [SerializedValue("many")]
        Many,
        
        [SerializedValue("other")]
        Other
    }
}