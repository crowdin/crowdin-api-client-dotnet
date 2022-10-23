
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public enum TermType
    {
        [Description("full form")]
        FullForm,
        
        [Description("acronym")]
        Acronym,
        
        [Description("abbreviation")]
        Abbreviation,
        
        [Description("short form")]
        ShortForm,
        
        [Description("phrase")]
        Phrase,
        
        [Description("variant")]
        Variant
    }
}