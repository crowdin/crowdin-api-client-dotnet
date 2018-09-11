namespace Crowdin.Api
{
    public enum UpdateFileOption
    {
        [Property("update_as_unapproved")]
        UpdateAsUnapproved,

        [Property("update_without_changes")]
        UpdateWithoutChanges
    }
}