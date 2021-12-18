
using System;
using Crowdin.Api.SourceFiles;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

#nullable enable

namespace Crowdin.Api.Core.Converters
{
    public class FileImportOptionsConverter : JsonConverter<FileImportOptions>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, FileImportOptions? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override FileImportOptions? ReadJson(
            JsonReader reader, Type objectType, FileImportOptions? existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);

            FileImportOptions? options;
            if (jObject.TryGetValue("scheme", out _))
            {
                options = JsonConvert.DeserializeObject<SpreadsheetFileImportOptions>(jObject.ToString());
            }
            else if (jObject.TryGetValue("translateContent", out _))
            {
                options = JsonConvert.DeserializeObject<XmlFileImportOptions>(jObject.ToString());
            }
            else
            {
                options = JsonConvert.DeserializeObject<OtherFilesImportOptions>(jObject.ToString());
            }
            
            return options;
        }
    }
}