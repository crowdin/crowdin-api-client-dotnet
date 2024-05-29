
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public enum TermType
    {
        [SerializedValue("full form")]
        FullForm,
        
        [SerializedValue("acronym")]
        Acronym,
        
        [SerializedValue("abbreviation")]
        Abbreviation,
        
        [SerializedValue("short form")]
        ShortForm,
        
        [SerializedValue("phrase")]
        Phrase,
        
        [SerializedValue("variant")]
        Variant
    }
}