using Crowdin.Api.Protocol;

namespace Crowdin.Api.Typed
{
    public enum UpdateFileOption
    {
        [Property("update_as_unapproved")]
        UpdateAsUnapproved,

        [Property("update_without_changes")]
        UpdateWithoutChanges
    }
}