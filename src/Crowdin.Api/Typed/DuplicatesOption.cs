using Crowdin.Api.Protocol;

namespace Crowdin.Api.Typed
{
    [AsNumber]
    public enum DuplicatesOption
    {
        Visible,
        Hidden,
        VisibleButAutoTranslated,
        HiddenBetweenBranches
    }
}
