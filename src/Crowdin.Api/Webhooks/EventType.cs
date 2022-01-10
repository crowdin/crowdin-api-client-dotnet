
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Webhooks
{
    [PublicAPI]
    public enum EventType
    {
        [Description("file.translated")]
        FileTranslated,
        
        [Description("file.approved")]
        FileApproved,
        
        [Description("project.translated")]
        ProjectTranslated,
        
        [Description("project.approved")]
        ProjectApproved,
        
        [Description("translation.updated")]
        TranslationUpdated,
        
        [Description("string.added")]
        StringAdded,
        
        [Description("string.updated")]
        StringUpdated,
        
        [Description("string.deleted")]
        StringDeleted,

        [Description("suggestion.added")]
        SuggestionAdded,
        
        [Description("suggestion.updated")]
        SuggestionUpdated,
        
        [Description("suggestion.deleted")]
        SuggestionDeleted,
        
        [Description("suggestion.approved")]
        SuggestionApproved,
        
        [Description("suggestion.disapproved")]
        SuggestionDisapproved
    }
}