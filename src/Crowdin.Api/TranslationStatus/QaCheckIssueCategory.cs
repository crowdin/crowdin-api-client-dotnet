
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.TranslationStatus
{
    [PublicAPI]
    public enum QaCheckIssueCategory
    {
        [Description("empty")]
        Empty,
        
        [Description("variables")]
        Variables,
        
        [Description("tags")]
        Tags,
        
        [Description("punctuation")]
        Punctuation,
        
        [Description("symbol_register")]
        SymbolRegister,
        
        [Description("spaces")]
        Spaces,
        
        [Description("size")]
        Size,
        
        [Description("special_symbols")]
        SpecialSymbols,
        
        [Description("wrong_translation")]
        WrongTranslation,
        
        [Description("spellcheck")]
        SpellCheck,
        
        [Description("icu")]
        Icu
    }
}