using Crowdin.Api.Protocol;

namespace Crowdin.Api.Typed
{
    [AsNumber]
    public enum AutoApproveOption
    {
        All,
        PerfectMatch,
        SkipAutoSubstituted
    }
}