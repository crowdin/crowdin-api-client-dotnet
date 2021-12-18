
using System;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Core.Converters
{
    public class ToStringConverter : JsonConverter
    {
        public override bool CanRead => false;

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsDefined(typeof(CallToStringForSerializationAttribute), false);
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value != null)
            {
                writer.WriteValue(value.ToString());
            }
        }

        public override object? ReadJson(
            JsonReader reader, Type objectType,
            object? existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class CallToStringForSerializationAttribute : Attribute
    {
        
    }
}