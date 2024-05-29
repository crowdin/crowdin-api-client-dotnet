
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public enum GlossaryFormat
    {
        [SerializedValue("tbx")]
        Tbx,
        
        [SerializedValue("tbx_v3")]
        TbxV3,
        
        [SerializedValue("csv")]
        Csv,
        
        [SerializedValue("xlsx")]
        Xlsx
    }
}