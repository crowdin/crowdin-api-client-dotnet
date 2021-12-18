
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api
{
    [PublicAPI]
    public enum PatchOperation
    {
        [Description("add")]
        Add,
        
        [Description("copy")]
        Copy,
        
        [Description("move")]
        Move,

        [Description("remove")]
        Remove,
        
        [Description("replace")]
        Replace,
        
        [Description("test")]
        Test
    }
}