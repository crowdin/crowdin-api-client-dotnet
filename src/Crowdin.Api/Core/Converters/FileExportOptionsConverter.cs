
using System;
using Crowdin.Api.SourceFiles;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

#nullable enable

namespace Crowdin.Api.Core.Converters
{
    public class FileExportOptionsConverter : JsonConverter<FileExportOptions>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, FileExportOptions? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override FileExportOptions? ReadJson(
            JsonReader reader, Type objectType, FileExportOptions? existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);

            Type returnType =
                obj.TryGetValue("escapeSpecialCharacters", out _) ||
                obj.TryGetValue("escapeQuotes", out _)
                    ? typeof(PropertyFileExportOptions)
                    : typeof(GeneralFileExportOptions);
            
            return (FileExportOptions?) JsonConvert.DeserializeObject(obj.ToString(), returnType);
        }
    }
}