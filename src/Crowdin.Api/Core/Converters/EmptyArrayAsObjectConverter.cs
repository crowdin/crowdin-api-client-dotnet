
using System;
using System.Collections;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Core.Converters
{
    public class EmptyArrayAsObjectConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => !objectType.IsPrimitive;

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            // ReSharper disable once ConvertIfStatementToSwitchStatement
            if (reader.TokenType is JsonToken.Null)
            {
                reader.Read();
                return null;
            }

            // ReSharper disable once InvertIf
            if (reader.TokenType is JsonToken.StartArray &&
                objectType.GetInterface(nameof(ICollection)) is null)
            {
                reader.Read();
                return JsonConvert.DeserializeObject("{}", objectType);
            }

            return serializer.Deserialize(reader, objectType);
        }
        
        public override bool CanWrite => false;
        
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}