
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public enum MatchType
    {
        [Description("perfect")]
        Perfect,

        // ReSharper disable InconsistentNaming
        [Description("100")]
        Option_100,

        [Description("99-82")]
        Option_99_82,

        [Description("81-60")]
        Option_81_60
        // ReSharper restore InconsistentNaming
    }
}