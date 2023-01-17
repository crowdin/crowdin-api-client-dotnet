
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Crowdin.Api.ProjectsGroups;
using Crowdin.Api.SourceFiles;

#nullable enable

namespace Crowdin.Api.Core.Converters
{
    public class ProjectFileFormatSettingsConverter : JsonConverter<FileFormatSettingsResource>
    {
        public override bool CanWrite => false;
        
        public override void WriteJson(JsonWriter writer, FileFormatSettingsResource? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        
        public override FileFormatSettingsResource? ReadJson(
            JsonReader reader, Type objectType, FileFormatSettingsResource? existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            
            existingValue ??= jObject.ToObject<FileFormatSettingsResource>();
            if (existingValue is null) return null;
            
            Type returnType = existingValue.Format switch
            {
                ProjectFileType.Properties =>
                    typeof(PropertyFileFormatSettings),
                
                ProjectFileType.Xml =>
                    typeof(XmlFileFormatSettings),
                
                ProjectFileType.WebXml =>
                    typeof(WebXmlFileFormatSettings),
                
                ProjectFileType.Html =>
                    typeof(HtmlFileFormatSettings),
                
                ProjectFileType.Adoc =>
                    typeof(AdocFileFormatSettings),
                
                ProjectFileType.Md =>
                    typeof(MdFileFormatSettings),
                
                ProjectFileType.FmMd =>
                    typeof(FmMdFileFormatSettings),
                
                ProjectFileType.FmHtml =>
                    typeof(FmHtmlFileFormatSettings),
                
                ProjectFileType.Flsnp =>
                    typeof(MadcapFlsnpFileFormatSettings),
                
                ProjectFileType.DocX =>
                    typeof(DocxFileFormatSettings),
                
                ProjectFileType.Idml =>
                    typeof(IdmlFileFormatSettings),
                
                ProjectFileType.Mif =>
                    typeof(MifFileFormatSettings),
                
                ProjectFileType.Dita =>
                    typeof(DitaFileFormatSettings),
                
                ProjectFileType.MediaWiki =>
                    typeof(MediaWikiFileFormatSettings),
                
                ProjectFileType.Txt =>
                    typeof(TxtFileFormatSettings),
                
                _ =>
                    typeof(OtherFileFormatSettings)
            };
            
            var settingsRawObject = (JObject) jObject["settings"]!;
            var settingsRawObjectJson = settingsRawObject.ToString();
            existingValue.Settings = (FileFormatSettings?) JsonConvert.DeserializeObject(settingsRawObjectJson, returnType);
            
            return existingValue;
        }
    }
}