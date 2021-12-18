
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.SourceFiles
{
    public class FileImportOptions
    {
        
    }
    
    [PublicAPI]
    public class XmlFileImportOptions : FileImportOptions
    {
        [JsonProperty("translateContent")]
        public bool? TranslateContent { get; set; }
        
        [JsonProperty("translateAttributes")]
        public bool? TranslateAttributes { get; set; }
        
        [JsonProperty("contentSegmentation")]
        public bool? ContentSegmentation { get; set; }

        [JsonProperty("translatableElements")]
        public List<string>? TranslatableElements { get; set; }
    }
    
    [PublicAPI]
    public class SpreadsheetFileImportOptions : FileImportOptions
    {
        [JsonProperty("firstLineContainsHeader")]
        public bool? FirstLineContainsHeader { get; set; }
        
        [JsonProperty("importTranslations")]
        public bool? ImportTranslations { get; set; }
        
        [JsonProperty("scheme")]
        public IDictionary<string, int>? Scheme { get; set; }
    }

    [PublicAPI]
    public class OtherFilesImportOptions : FileImportOptions
    {
        [JsonProperty("contentSegmentation")]
        public bool? ContentSegmentation { get; set; }
        
        [JsonProperty("srxStorageId")]
        public int? SrxStorageId { get; set; }
    }
}