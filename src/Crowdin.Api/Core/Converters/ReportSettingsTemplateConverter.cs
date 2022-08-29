
using System;
using System.Linq;
using Crowdin.Api.Reports;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.Core.Converters
{
    public class ReportSettingsTemplateConverter : JsonConverter<ReportSettingsTemplateBase>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, ReportSettingsTemplateBase value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override ReportSettingsTemplateBase ReadJson(
            JsonReader reader, Type objectType, ReportSettingsTemplateBase existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);

            Type returnType = obj.GetValue("mode")?.Value<string>() switch
            {
                "simple" => typeof(ReportSettingsTemplateSimple),
                "fuzzy" => typeof(ReportSettingsTemplateFuzzy),
                _ => throw new ArgumentOutOfRangeException(null, "Property Mode not found or has unsupported value")
            };

            return (ReportSettingsTemplateBase) JsonConvert.DeserializeObject(obj.ToString(), returnType,
                serializer.Converters.Where(converter => converter.GetType() != GetType()).ToArray());
        }
    }
}
