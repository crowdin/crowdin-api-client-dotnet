
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public enum MatchType
    {
        [SerializedValue("perfect")]
        Perfect,

        // ReSharper disable InconsistentNaming
        [SerializedValue("100")]
        Option_100,

        [SerializedValue("99-82")]
        Option_99_82,

        [SerializedValue("81-60")]
        Option_81_60
        // ReSharper restore InconsistentNaming
    }
}