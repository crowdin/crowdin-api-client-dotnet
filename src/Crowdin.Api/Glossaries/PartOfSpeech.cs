
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public enum PartOfSpeech
    {
        [Description("adjective")]
        Adjective,
        
        [Description("adposition")]
        AdPosition,
        
        [Description("adverb")]
        AdVerb,
        
        [Description("auxiliary")]
        Auxiliary,
        
        [Description("coordinating conjunction")]
        CoordinatingConjunction,
        
        [Description("determiner")]
        Determiner,
        
        [Description("interjection")]
        Interjection,
        
        [Description("noun")]
        Noun,
        
        [Description("numeral")]
        Numeral,
        
        [Description("particle")]
        Particle,
        
        [Description("pronoun")]
        Pronoun,
        
        [Description("proper noun")]
        ProperNoun,
        
        [Description("subordinating conjunction")]
        SubordinatingConjunction,
        
        [Description("verb")]
        Verb,
        
        [Description("other")]
        Other
    }
}