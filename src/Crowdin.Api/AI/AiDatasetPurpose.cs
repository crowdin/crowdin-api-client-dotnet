
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public enum AiDatasetPurpose
    {
        [Description("training")]
        Training,
        
        [Description("validation")]
        Validation
    }
}