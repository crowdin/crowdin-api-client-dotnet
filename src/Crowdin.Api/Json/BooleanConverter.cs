using System;
using Newtonsoft.Json;

namespace Crowdin.Api.Json
{
    internal sealed class BooleanConverter : JsonConverter<Boolean>
    {
        public override void WriteJson(JsonWriter writer, Boolean value, JsonSerializer serializer)
        {
            writer.WriteValue(value ? 1L : 0L);
        }

        public override Boolean ReadJson(JsonReader reader, Type objectType, Boolean existingValue, Boolean hasExistingValue, JsonSerializer serializer)
        {
            return (Int64) reader.Value != 0;
        }
    }
}
