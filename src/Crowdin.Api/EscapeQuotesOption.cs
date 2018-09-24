using Crowdin.Api.Protocol;

namespace Crowdin.Api
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