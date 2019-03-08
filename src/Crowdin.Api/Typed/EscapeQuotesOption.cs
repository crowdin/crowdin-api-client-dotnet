using Crowdin.Api.Protocol;

namespace Crowdin.Api.Typed
{
    [AsNumber]
    public enum EscapeQuotesOption
    {
        DoNotEscape,
        Double,
        Backslash,
        DoubleOnVariables
    }
}