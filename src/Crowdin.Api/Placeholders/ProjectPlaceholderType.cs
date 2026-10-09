#nullable enable

using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Placeholders
{
    [PublicAPI]
    public enum ProjectPlaceholderType
    {
        [Description("high")]
        High,

        [Description("low")]
        Low
    }
}
