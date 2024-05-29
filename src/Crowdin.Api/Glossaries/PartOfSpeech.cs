
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public enum PartOfSpeech
    {
        [SerializedValue("adjective")]
        Adjective,
        
        [SerializedValue("adposition")]
        AdPosition,
        
        [SerializedValue("adverb")]
        AdVerb,
        
        [SerializedValue("auxiliary")]
        Auxiliary,
        
        [SerializedValue("coordinating conjunction")]
        CoordinatingConjunction,
        
        [SerializedValue("determiner")]
        Determiner,
        
        [SerializedValue("interjection")]
        Interjection,
        
        [SerializedValue("noun")]
        Noun,
        
        [SerializedValue("numeral")]
        Numeral,
        
        [SerializedValue("particle")]
        Particle,
        
        [SerializedValue("pronoun")]
        Pronoun,
        
        [SerializedValue("proper noun")]
        ProperNoun,
        
        [SerializedValue("subordinating conjunction")]
        SubordinatingConjunction,
        
        [SerializedValue("verb")]
        Verb,
        
        [SerializedValue("other")]
        Other
    }
}