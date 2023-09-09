#nullable enable

using System;
using Crowdin.Api.ProjectsGroups;
using Crowdin.Api.SourceFiles;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.Core.Converters
{
    internal class ProjectStringsExporterSettingsConverter : JsonConverter<StringsExporterSettingsResource>
    {
        public override bool CanWrite => false;
        
        public override void WriteJson(JsonWriter writer, StringsExporterSettingsResource? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override StringsExporterSettingsResource? ReadJson(JsonReader reader, Type objectType,
            StringsExporterSettingsResource? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);

            existingValue ??= jObject.ToObject<StringsExporterSettingsResource>();
            if (existingValue is null) return null;

            Type returnType = existingValue.Format switch
            {
                ProjectFileType.Android =>
                    typeof(AndroidStringsExporterSettings),
                ProjectFileType.MacOsX =>
                    typeof(MacOsxStringsExporterSettings)
            };
            
            var settingsRawObject = (JObject) jObject["settings"]!;
            var settingsRawObjectJson = settingsRawObject.ToString();
            existingValue.Settings = (StringsExporterSettings?) JsonConvert.DeserializeObject(settingsRawObjectJson, returnType);
            
            return existingValue;
        }
    }
}