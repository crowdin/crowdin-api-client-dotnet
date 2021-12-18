
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.TranslationStatus
{
    [PublicAPI]
    public enum QaCheckIssueValidationType
    {
        [Description("empty_string_check")]
        EmptyStringCheck,
        
        [Description("empty_suggestion_check")]
        EmptySuggestionCheck,
        
        [Description("max_length_check")]
        MaxLengthCheck,
        
        [Description("tags_check")]
        TagsCheck,
        
        [Description("mismatch_ids_check")]
        MismatchIdsCheck,
        
        [Description("cdata_check")]
        CdataCheck,
        
        [Description("specials_symbols_check")]
        SpecialSymbolsCheck,
        
        [Description("leading_newlines_check")]
        LeadingNewlinesCheck,
        
        [Description("trailing_newlines_check")]
        TrailingNewlinesCheck,
        
        [Description("leading_spaces_check")]
        LeadingSpacesCheck,
        
        [Description("trailing_spaces_check")]
        TrailingSpacesCheck,
        
        [Description("multiple_spaces_check")]
        MultipleSpacesCheck,
        
        [Description("custom_blocked_variables_check")]
        CustomBlockedVariablesCheck,
        
        [Description("highest_priority_custom_variables_check")]
        HighestPriorityCustomBlockedVariablesCheck,
        
        [Description("highest_priority_variables_check")]
        HighestPriorityVariablesCheck,
        
        [Description("c_variables_check")]
        CVariablesCheck,
        
        [Description("python_variables_check")]
        PythonVariablesCheck,
        
        [Description("rails_variables_check")]
        RailsVariablesCheck,
        
        [Description("java_variables_check")]
        JavaVariablesCheck,
        
        [Description("dot_net_variables_check")]
        DotNetVariablesCheck,
        
        [Description("twig_variables_check")]
        TwigVariablesCheck,
        
        [Description("php_variables_check")]
        PhpVariablesCheck,
        
        [Description("freemarker_variables_check")]
        FreeMakerVariablesCheck,
        
        [Description("lowest_priority_variable_check")]
        LowestPriorityVariableCheck,
        
        [Description("lowest_priority_custom_variables_check")]
        LowestPriorityCustomVariablesCheck,
        
        [Description("punctuation_check")]
        PunctuationCheck,
        
        [Description("spaces_before_punctuation_check")]
        SpacesBeforePunctuationCheck,
        
        [Description("spaces_after_punctuation_check")]
        SpacesAfterPunctuationCheck,
        
        [Description("non_breaking_spaces_check")]
        NonBreakingSpacesCheck,
        
        [Description("capitalize_check")]
        CapitalizeCheck,
        
        [Description("multiple_uppercase_check")]
        MultipleUppercaseCheck,
        
        [Description("parentheses_check")]
        ParenthesesCheck,
        
        [Description("entities_check")]
        EntitiesCheck,
        
        [Description("escaped_quotes_check")]
        EscapedQuotesCheck,
        
        [Description("wrong_translation_issue_check")]
        WrongTranslationIssueCheck,
        
        [Description("spellcheck")]
        SpellCheck,
        
        [Description("icu_check")]
        IcuCheck
    }
}