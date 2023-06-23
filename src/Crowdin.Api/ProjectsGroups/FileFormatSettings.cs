
using System.Collections.Generic;
using Crowdin.Api.SourceFiles;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public class FileFormatSettings
    {
        [JsonProperty("exportPattern")]
        public string? ExportPattern { get; set; }
    }

    [PublicAPI]
    public class PropertyFileFormatSettings : FileFormatSettings
    {
        [JsonProperty("escapeQuotes")]
        public EscapeQuotesMode? EscapeQuotes { get; set; }
        
        [JsonProperty("escapeSpecialCharacters")]
        public EscapeSpecialCharsMode? EscapeSpecialCharacters { get; set; }
    }

    [PublicAPI]
    public class XmlFileFormatSettings : FileFormatSettings
    {
        [JsonProperty("translateContent")]
        public bool? TranslateContent { get; set; }
        
        [JsonProperty("translateAttributes")]
        public bool? TranslateAttributes { get; set; }
        
        [JsonProperty("translatableElements")]
        public List<string>? TranslatableElements { get; set; }
        
        [JsonProperty("contentSegmentation")]
        public bool? ContentSegmentation { get; set; }
        
        [JsonProperty("srxStorageId")]
        public int? SrxStorageId { get; set; }
    }

    [PublicAPI]
    public class WebXmlFileFormatSettings : FileFormatSettings
    {
        [JsonProperty("contentSegmentation")]
        public bool? ContentSegmentation { get; set; }
        
        [JsonProperty("srxStorageId")]
        public int? SrxStorageId { get; set; }
    }

    [PublicAPI]
    public class HtmlFileFormatSettings : FileFormatSettings
    {
        [JsonProperty("contentSegmentation")]
        public bool? ContentSegmentation { get; set; }
        
        [JsonProperty("srxStorageId")]
        public int? SrxStorageId { get; set; }
    }

    [PublicAPI]
    public class AdocFileFormatSettings : FileFormatSettings
    {
        [JsonProperty("contentSegmentation")]
        public bool? ContentSegmentation { get; set; }
        
        [JsonProperty("srxStorageId")]
        public int? SrxStorageId { get; set; }
    }

    [PublicAPI]
    public class AndroidFileFormatSettings : FileFormatSettings
    {
        [JsonProperty("contentSegmentation")]
        public bool? ContentSegmentation { get; set; }
        
        [JsonProperty("srxStorageId")]
        public int? SrxStorageId { get; set; }
    }

    [PublicAPI]
    public class MdFileFormatSettings : FileFormatSettings
    {
        [JsonProperty("contentSegmentation")]
        public bool? ContentSegmentation { get; set; }
        
        [JsonProperty("srxStorageId")]
        public int? SrxStorageId { get; set; }
    }

    [PublicAPI]
    public class MdxV1FileFormatSettings : FileFormatSettings
    {
        [JsonProperty("contentSegmentation")]
        public bool? ContentSegmentation { get; set; }
        
        [JsonProperty("srxStorageId")]
        public int? SrxStorageId { get; set; }
        
        [JsonProperty("excludedFrontMatterElements")]
        public List<string>? ExcludedFrontMatterElements { get; set; }
        
        [JsonProperty("excludeCodeBlocks")]
        public bool? ExcludeCodeBlocks { get; set; }
    }

    [PublicAPI]
    public class FmMdFileFormatSettings : FileFormatSettings
    {
        [JsonProperty("contentSegmentation")]
        public bool? ContentSegmentation { get; set; }
        
        [JsonProperty("srxStorageId")]
        public int? SrxStorageId { get; set; }
    }

    [PublicAPI]
    public class FmHtmlFileFormatSettings : FileFormatSettings
    {
        [JsonProperty("contentSegmentation")]
        public bool? ContentSegmentation { get; set; }
        
        [JsonProperty("srxStorageId")]
        public int? SrxStorageId { get; set; }
    }

    [PublicAPI]
    public class MadcapFlsnpFileFormatSettings : FileFormatSettings
    {
        [JsonProperty("contentSegmentation")]
        public bool? ContentSegmentation { get; set; }
        
        [JsonProperty("srxStorageId")]
        public int? SrxStorageId { get; set; }
    }

    [PublicAPI]
    public class DocxFileFormatSettings : FileFormatSettings
    {
        [JsonProperty("cleanTagsAggressively")]
        public bool? CleanTagsAggressively { get; set; }
        
        [JsonProperty("translateHiddenText")]
        public bool? TranslateHiddenText { get; set; }
        
        [JsonProperty("translateHyperlinkUrls")]
        public bool? TranslateHyperlinkUrls { get; set; }
        
        [JsonProperty("translateHiddenRowsAndColumns")]
        public bool? TranslateHiddenRowsAndColumns { get; set; }
        
        [JsonProperty("importNotes")]
        public bool? ImportNotes { get; set; }
        
        [JsonProperty("importHiddenSlides")]
        public bool? ImportHiddenSlides { get; set; }
        
        [JsonProperty("contentSegmentation")]
        public bool? ContentSegmentation { get; set; }
        
        [JsonProperty("srxStorageId")]
        public int? SrxStorageId { get; set; }
    }

    [PublicAPI]
    public class IdmlFileFormatSettings : FileFormatSettings
    {
        [JsonProperty("contentSegmentation")]
        public bool? ContentSegmentation { get; set; }
        
        [JsonProperty("srxStorageId")]
        public int? SrxStorageId { get; set; }
    }

    [PublicAPI]
    public class MifFileFormatSettings : FileFormatSettings
    {
        [JsonProperty("contentSegmentation")]
        public bool? ContentSegmentation { get; set; }
        
        [JsonProperty("srxStorageId")]
        public int? SrxStorageId { get; set; }
    }

    [PublicAPI]
    public class DitaFileFormatSettings : FileFormatSettings
    {
        [JsonProperty("contentSegmentation")]
        public bool? ContentSegmentation { get; set; }
        
        [JsonProperty("srxStorageId")]
        public int? SrxStorageId { get; set; }
    }

    [PublicAPI]
    public class MediaWikiFileFormatSettings : FileFormatSettings
    {
        [JsonProperty("srxStorageId")]
        public int? SrxStorageId { get; set; }
    }

    [PublicAPI]
    public class ArbFileFormatSettings : FileFormatSettings
    {
        [JsonProperty("contentSegmentation")]
        public bool? ContentSegmentation { get; set; }
        
        [JsonProperty("srxStorageId")]
        public int? SrxStorageId { get; set; }
    }

    [PublicAPI]
    public class JsonFileFormatSettings : FileFormatSettings
    {
        [JsonProperty("contentSegmentation")]
        public bool? ContentSegmentation { get; set; }
        
        [JsonProperty("srxStorageId")]
        public int? SrxStorageId { get; set; }
        
        [JsonProperty("type")]
        public JsonFileType? Type { get; set; }
    }

    [PublicAPI]
    public class FJsFileFormatSettings : FileFormatSettings
    {
        [JsonProperty("contentSegmentation")]
        public bool? ContentSegmentation { get; set; }
        
        [JsonProperty("srxStorageId")]
        public int? SrxStorageId { get; set; }
    }

    [PublicAPI]
    public class MacOsXFileFormatSettings : FileFormatSettings
    {
        [JsonProperty("contentSegmentation")]
        public bool? ContentSegmentation { get; set; }
        
        [JsonProperty("srxStorageId")]
        public int? SrxStorageId { get; set; }
    }

    [PublicAPI]
    public class ChromeFileFormatSettings : FileFormatSettings
    {
        [JsonProperty("contentSegmentation")]
        public bool? ContentSegmentation { get; set; }
        
        [JsonProperty("srxStorageId")]
        public int? SrxStorageId { get; set; }
    }

    [PublicAPI]
    public class ReactIntlFileFormatSettings : FileFormatSettings
    {
        [JsonProperty("contentSegmentation")]
        public bool? ContentSegmentation { get; set; }
        
        [JsonProperty("srxStorageId")]
        public int? SrxStorageId { get; set; }
    }

    [PublicAPI]
    public class TxtFileFormatSettings : FileFormatSettings
    {
        [JsonProperty("srxStorageId")]
        public int? SrxStorageId { get; set; }
    }

    [PublicAPI]
    public class OtherFileFormatSettings : FileFormatSettings
    {
        
    }
}