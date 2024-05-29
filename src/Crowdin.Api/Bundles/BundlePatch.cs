
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
        [SerializedValue("/name")]
        Name,
        
        [SerializedValue("/format")]
        Format,
        
        [SerializedValue("/sourcePatterns")]
        SourcePatterns,
        
        [SerializedValue("/ignorePatterns")]
        IgnorePatterns,
        
        [SerializedValue("/exportPattern")]
        ExportPattern,
        
        [SerializedValue("/isMultilingual")]
        IsMultilingual,
        
        [SerializedValue("/includeProjectSourceLanguage")]
        IncludeProjectSourceLanguage,

        [SerializedValue("/labelIds")]
        LabelIds,

        [SerializedValue("/excludeLabelIds")]
        ExcludeLabelIds
            
    }
}