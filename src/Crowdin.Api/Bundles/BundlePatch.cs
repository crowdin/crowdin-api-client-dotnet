
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Bundles
{
    [PublicAPI]
    public class BundlePatch : PatchEntry
    {
        [JsonProperty("path")]
        public BundlePatchPath Path { get; set; }
    }

    [PublicAPI]
    public enum BundlePatchPath
    {
        [Description("/name")]
        Name,
        
        [Description("/format")]
        Format,
        
        [Description("/sourcePatterns")]
        SourcePatterns,
        
        [Description("/ignorePatterns")]
        IgnorePatterns,
        
        [Description("/exportPattern")]
        ExportPattern,
        
        [Description("/isMultilingual")]
        IsMultilingual,
        
        [Description("/includeProjectSourceLanguage")]
        IncludeProjectSourceLanguage,

        [Description("/labelIds")]
        LabelIds,

        [Description("/excludeLabelIds")]
        ExcludeLabelIds
            
    }
}