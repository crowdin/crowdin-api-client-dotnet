
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public enum TermGender
    {
        [SerializedValue("masculine")]
        Masculine,
        
        [SerializedValue("feminine")]
        Feminine,
        
        [SerializedValue("neuter")]
        Neuter,
        
        [SerializedValue("other")]
        Other
    }
}