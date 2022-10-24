
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public enum TermGender
    {
        [Description("masculine")]
        Masculine,
        
        [Description("feminine")]
        Feminine,
        
        [Description("neuter")]
        Neuter,
        
        [Description("other")]
        Other
    }
}