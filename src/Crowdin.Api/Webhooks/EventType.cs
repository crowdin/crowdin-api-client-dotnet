
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Webhooks
{
    [PublicAPI]
    public enum EventType
    {
        [SerializedValue("file.added")]
        FileAdded,

        [SerializedValue("file.updated")]
        FileUpdated,

        [SerializedValue("file.reverted")]
        FileReverted,

        [SerializedValue("file.deleted")]
        FileDeleted,

        [SerializedValue("file.translated")]
        FileTranslated,

        [SerializedValue("file.approved")]
        FileApproved,

        [SerializedValue("project.translated")]
        ProjectTranslated,

        [SerializedValue("project.approved")]
        ProjectApproved,

        [SerializedValue("project.built")]
        ProjectBuilt,

        [SerializedValue("translation.updated")]
        TranslationUpdated,

        [SerializedValue("string.added")]
        StringAdded,

        [SerializedValue("string.updated")]
        StringUpdated,

        [SerializedValue("string.deleted")]
        StringDeleted,

        [SerializedValue("stringComment.created")]
        StringCommentCreated,

        [SerializedValue("stringComment.updated")]
        StringCommentUpdated,

        [SerializedValue("stringComment.deleted")]
        StringCommentDeleted,

        [SerializedValue("stringComment.restored")]
        StringCommentRestored,

        [SerializedValue("suggestion.added")]
        SuggestionAdded,

        [SerializedValue("suggestion.updated")]
        SuggestionUpdated,

        [SerializedValue("suggestion.deleted")]
        SuggestionDeleted,

        [SerializedValue("suggestion.approved")]
        SuggestionApproved,

        [SerializedValue("suggestion.disapproved")]
        SuggestionDisapproved,

        [SerializedValue("task.added")]
        TaskAdded,

        [SerializedValue("task.statusChanged")]
        TaskStatusChanged,

        [SerializedValue("task.deleted")]
        TaskDeleted,
    }
}