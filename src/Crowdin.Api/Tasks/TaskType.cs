
using JetBrains.Annotations;

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public enum TaskType
    {
        Translate = 0,
        Proofread = 1,
        TranslateByVendor = 2,
        ProofreadByVendor = 3
    }
}