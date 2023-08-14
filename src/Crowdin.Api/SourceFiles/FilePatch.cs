
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
        [Description("/branchId")]
        BranchId,
        
        [Description("/directoryId")]
        DirectoryId,
        
        [Description("/name")]
        Name,
        
        [Description("/title")]
        Title,
        
        [Description("/priority")]
        Priority,
        
        [Description("/importOptions/cleanTagsAggressively")]
        CleanTagsAggressively,
        
        [Description("/importOptions/translateHiddenText")]
        TranslateHiddenText,
        
        [Description("/importOptions/translateHyperlinkUrls")]
        TranslateHyperlinkUrls,
        
        [Description("/importOptions/translateHiddenRowsAndColumns")]
        TranslateHiddenRowsAndColumns,
        
        [Description("/importOptions/importNotes")]
        ImportNotes,
        
        [Description("/importOptions/importHiddenSlides")]
        ImportHiddenSlides,
        
        [Description("/importOptions/firstLineContainsHeader")]
        FirstLineContainsHeader,
        
        [Description("/importOptions/importTranslations")]
        ImportTranslations,
        
        [Description("/importOptions/scheme")]
        Scheme,
        
        [Description("/importOptions/translateContent")]
        TranslateContent,
        
        [Description("/importOptions/translateAttributes")]
        TranslateAttributes,
        
        [Description("/importOptions/contentSegmentation")]
        ContentSegmentation,
        
        [Description("/importOptions/translatableElements")]
        TranslatableElements,

        [Description("/importOptions/srxStorageId")]
        SrxStorageId,
        
        [Description("/importOptions/customSegmentation")]
        CustomSegmentation,
        
        [Description("/exportOptions/exportPattern")]
        ExportPattern,
        
        [Description("/exportOptions/exportQuotes")]
        ExportQuotes,
        
        [Description("/exportOptions/escapeQuotes")]
        EscapeQuotes,
        
        [Description("/excludedTargetLanguages")]
        ExcludedTargetLanguages,
        
        [Description("/attachLabelIds")]
        AttachLabelIds,
        
        [Description("/detachLabelIds")]
        DetachLabelIds
    }
}