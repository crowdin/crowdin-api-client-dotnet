using Crowdin.Api.Protocol;

namespace Crowdin.Api
{
    [AsNumber]
    public enum AutoApproveOption
    {
        All,
        PerfectMatch,
        SkipAutoSubstituted
    }
}