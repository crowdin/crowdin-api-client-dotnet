
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Webhooks
{
    [PublicAPI]
    public enum EventType
    {
        [Description("file.added")]
        FileAdded,

        [Description("file.updated")]
        FileUpdated,

        [Description("file.reverted")]
        FileReverted,

        [Description("file.deleted")]
        FileDeleted,

        [Description("file.translated")]
        FileTranslated,

        [Description("file.approved")]
        FileApproved,

        [Description("file.qa.finished")]
        FileQaFinished,

        [Description("project.translated")]
        ProjectTranslated,

        [Description("project.approved")]
        ProjectApproved,

        [Description("project.qa.finished")]
        ProjectQaFinished,

        [Description("project.built")]
        ProjectBuilt,

        [Description("preTranslation.completed")]
        PreTranslationCompleted,

        [Description("translation.updated")]
        TranslationUpdated,

        [Description("string.added")]
        StringAdded,

        [Description("string.updated")]
        StringUpdated,

        [Description("string.deleted")]
        StringDeleted,

        [Description("stringComment.created")]
        StringCommentCreated,

        [Description("stringComment.updated")]
        StringCommentUpdated,

        [Description("stringComment.deleted")]
        StringCommentDeleted,

        [Description("stringComment.restored")]
        StringCommentRestored,

        [Description("suggestion.added")]
        SuggestionAdded,

        [Description("suggestion.updated")]
        SuggestionUpdated,

        [Description("suggestion.deleted")]
        SuggestionDeleted,

        [Description("suggestion.approved")]
        SuggestionApproved,

        [Description("suggestion.disapproved")]
        SuggestionDisapproved,

        [Description("task.added")]
        TaskAdded,

        [Description("task.statusChanged")]
        TaskStatusChanged,

        [Description("task.updated")]
        TaskUpdated,

        [Description("task.deleted")]
        TaskDeleted,

        [Description("group.created")]
        GroupCreated,

        [Description("group.deleted")]
        GroupDeleted,
    }
}
