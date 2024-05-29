
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.SourceFiles
{
    [PublicAPI]
    public class FilePatch : PatchEntry
    {
        [JsonProperty("path")]
        public FilePatchPath Path { get; set; }
    }

    [PublicAPI]
    public enum FilePatchPath
    {
        [SerializedValue("/branchId")]
        BranchId,
        
        [SerializedValue("/directoryId")]
        DirectoryId,
        
        [SerializedValue("/name")]
        Name,
        
        [SerializedValue("/title")]
        Title,
        
        [SerializedValue("/priority")]
        Priority,
        
        [SerializedValue("/importOptions/cleanTagsAggressively")]
        CleanTagsAggressively,
        
        [SerializedValue("/importOptions/translateHiddenText")]
        TranslateHiddenText,
        
        [SerializedValue("/importOptions/translateHyperlinkUrls")]
        TranslateHyperlinkUrls,
        
        [SerializedValue("/importOptions/translateHiddenRowsAndColumns")]
        TranslateHiddenRowsAndColumns,
        
        [SerializedValue("/importOptions/importNotes")]
        ImportNotes,
        
        [SerializedValue("/importOptions/importHiddenSlides")]
        ImportHiddenSlides,
        
        [SerializedValue("/importOptions/firstLineContainsHeader")]
        FirstLineContainsHeader,
        
        [SerializedValue("/importOptions/importTranslations")]
        ImportTranslations,
        
        [SerializedValue("/importOptions/scheme")]
        Scheme,
        
        [SerializedValue("/importOptions/translateContent")]
        TranslateContent,
        
        [SerializedValue("/importOptions/translateAttributes")]
        TranslateAttributes,
        
        [SerializedValue("/importOptions/contentSegmentation")]
        ContentSegmentation,
        
        [SerializedValue("/importOptions/translatableElements")]
        TranslatableElements,

        [SerializedValue("/importOptions/srxStorageId")]
        SrxStorageId,
        
        [SerializedValue("/importOptions/customSegmentation")]
        CustomSegmentation,
        
        [SerializedValue("/exportOptions/exportPattern")]
        ExportPattern,
        
        [SerializedValue("/exportOptions/exportQuotes")]
        ExportQuotes,
        
        [SerializedValue("/exportOptions/escapeQuotes")]
        EscapeQuotes,
        
        [SerializedValue("/excludedTargetLanguages")]
        ExcludedTargetLanguages,
        
        [SerializedValue("/attachLabelIds")]
        AttachLabelIds,
        
        [SerializedValue("/detachLabelIds")]
        DetachLabelIds
    }
}