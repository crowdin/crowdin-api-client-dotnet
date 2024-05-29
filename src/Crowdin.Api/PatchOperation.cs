
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api
{
    [PublicAPI]
    public enum PatchOperation
    {
        [SerializedValue("add")]
        Add,
        
        [SerializedValue("copy")]
        Copy,
        
        [SerializedValue("move")]
        Move,

        [SerializedValue("remove")]
        Remove,
        
        [SerializedValue("replace")]
        Replace,
        
        [SerializedValue("test")]
        Test
    }
}