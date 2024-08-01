
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api
{
    [PublicAPI]
    public enum SortingOrder
    {
        [Description("asc")]
        Ascending,
        
        [Description("desc")]
        Descending
    }
}