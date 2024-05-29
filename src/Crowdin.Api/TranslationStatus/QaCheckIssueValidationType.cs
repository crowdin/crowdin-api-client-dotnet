
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.TranslationStatus
{
    [PublicAPI]
    public enum QaCheckIssueValidationType
    {
        [SerializedValue("empty_string_check")]
        EmptyStringCheck,
        
        [SerializedValue("empty_suggestion_check")]
        EmptySuggestionCheck,
        
        [SerializedValue("max_length_check")]
        MaxLengthCheck,
        
        [SerializedValue("tags_check")]
        TagsCheck,
        
        [SerializedValue("mismatch_ids_check")]
        MismatchIdsCheck,
        
        [SerializedValue("cdata_check")]
        CdataCheck,
        
        [SerializedValue("specials_symbols_check")]
        SpecialSymbolsCheck,
        
        [SerializedValue("leading_newlines_check")]
        LeadingNewlinesCheck,
        
        [SerializedValue("trailing_newlines_check")]
        TrailingNewlinesCheck,
        
        [SerializedValue("leading_spaces_check")]
        LeadingSpacesCheck,
        
        [SerializedValue("trailing_spaces_check")]
        TrailingSpacesCheck,
        
        [SerializedValue("multiple_spaces_check")]
        MultipleSpacesCheck,
        
        [SerializedValue("custom_blocked_variables_check")]
        CustomBlockedVariablesCheck,
        
        [SerializedValue("highest_priority_custom_variables_check")]
        HighestPriorityCustomBlockedVariablesCheck,
        
        [SerializedValue("highest_priority_variables_check")]
        HighestPriorityVariablesCheck,
        
        [SerializedValue("c_variables_check")]
        CVariablesCheck,
        
        [SerializedValue("python_variables_check")]
        PythonVariablesCheck,
        
        [SerializedValue("rails_variables_check")]
        RailsVariablesCheck,
        
        [SerializedValue("java_variables_check")]
        JavaVariablesCheck,
        
        [SerializedValue("dot_net_variables_check")]
        DotNetVariablesCheck,
        
        [SerializedValue("twig_variables_check")]
        TwigVariablesCheck,
        
        [SerializedValue("php_variables_check")]
        PhpVariablesCheck,
        
        [SerializedValue("freemarker_variables_check")]
        FreeMakerVariablesCheck,
        
        [SerializedValue("lowest_priority_variable_check")]
        LowestPriorityVariableCheck,
        
        [SerializedValue("lowest_priority_custom_variables_check")]
        LowestPriorityCustomVariablesCheck,
        
        [SerializedValue("punctuation_check")]
        PunctuationCheck,
        
        [SerializedValue("spaces_before_punctuation_check")]
        SpacesBeforePunctuationCheck,
        
        [SerializedValue("spaces_after_punctuation_check")]
        SpacesAfterPunctuationCheck,
        
        [SerializedValue("non_breaking_spaces_check")]
        NonBreakingSpacesCheck,
        
        [SerializedValue("capitalize_check")]
        CapitalizeCheck,
        
        [SerializedValue("multiple_uppercase_check")]
        MultipleUppercaseCheck,
        
        [SerializedValue("parentheses_check")]
        ParenthesesCheck,
        
        [SerializedValue("entities_check")]
        EntitiesCheck,
        
        [SerializedValue("escaped_quotes_check")]
        EscapedQuotesCheck,
        
        [SerializedValue("wrong_translation_issue_check")]
        WrongTranslationIssueCheck,
        
        [SerializedValue("spellcheck")]
        SpellCheck,
        
        [SerializedValue("icu_check")]
        IcuCheck
    }
}