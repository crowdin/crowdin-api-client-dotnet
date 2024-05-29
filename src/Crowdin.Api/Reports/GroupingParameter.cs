
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public enum GroupingParameter
    {
        [SerializedValue("user")]
        User,
                
        [SerializedValue("language")]
        Language
    }
}