
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.TranslationStatus
{
    [PublicAPI]
    public enum QaCheckIssueCategory
    {
        [SerializedValue("empty")]
        Empty,
        
        [SerializedValue("variables")]
        Variables,
        
        [SerializedValue("tags")]
        Tags,
        
        [SerializedValue("punctuation")]
        Punctuation,
        
        [SerializedValue("symbol_register")]
        SymbolRegister,
        
        [SerializedValue("spaces")]
        Spaces,
        
        [SerializedValue("size")]
        Size,
        
        [SerializedValue("special_symbols")]
        SpecialSymbols,
        
        [SerializedValue("wrong_translation")]
        WrongTranslation,
        
        [SerializedValue("spellcheck")]
        SpellCheck,
        
        [SerializedValue("icu")]
        Icu
    }
}