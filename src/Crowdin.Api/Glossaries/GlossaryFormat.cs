
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public enum GlossaryFormat
    {
        [Description("tbx")]
        Tbx,
        
        [Description("tbx_v3")]
        TbxV3,
        
        [Description("csv")]
        Csv,
        
        [Description("xlsx")]
        Xlsx
    }
}