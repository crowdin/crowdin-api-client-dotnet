using Crowdin.Api.Protocol;

namespace Crowdin.Api
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
