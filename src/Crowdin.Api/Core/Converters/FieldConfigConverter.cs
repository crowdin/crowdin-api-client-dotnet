using System;
using System.Linq;
using Crowdin.Api.Fields;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.Core.Converters
{
    internal class FieldConfigConverter : JsonConverter<Field>
    {
        public override void WriteJson(JsonWriter writer, Field value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override Field ReadJson(JsonReader reader, Type objectType, Field existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);

            existingValue ??= jObject.ToObject<Field>();
            if (existingValue is null) return null;

            var configRawObject = (JObject)jObject["config"]!;

            Type returnType;
            var configProperties = configRawObject.Properties();
            var properties = configProperties as JProperty[] ?? configProperties.ToArray();

            // Check if Options and Locations properties exist using reflection
            bool hasOptions = properties.Any(p => p.Name.Equals("Options", StringComparison.OrdinalIgnoreCase));
            bool hasLocations = properties.Any(p => p.Name.Equals("Locations", StringComparison.OrdinalIgnoreCase));

            // Check if Min, Max, and Units properties exist using reflection
            bool hasMin = properties.Any(p => p.Name.Equals("Min", StringComparison.OrdinalIgnoreCase));
            bool hasMax = properties.Any(p => p.Name.Equals("Max", StringComparison.OrdinalIgnoreCase));
            bool hasUnits = properties.Any(p => p.Name.Equals("Units", StringComparison.OrdinalIgnoreCase));

            if (hasOptions && hasLocations)
            {
                returnType = typeof(ListFieldConfig);
            }
            else if (hasMin && hasMax && hasUnits && hasLocations)
            {
                returnType = typeof(NumberFieldConfig);
            }
            else
            {
                returnType = typeof(FieldConfig);
            }


            var configRawObjectJson = configRawObject.ToString();
            existingValue.Config = (FieldConfig)JsonConvert.DeserializeObject(configRawObjectJson, returnType);

            return existingValue;
        }
    }
}