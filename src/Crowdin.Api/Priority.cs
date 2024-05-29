
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api
{
    [PublicAPI]
    public enum Priority
    {
        [SerializedValue("low")]
        Low,
        
        [SerializedValue("normal")]
        Normal,
        
        [SerializedValue("high")]
        High
    }
}