
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Core.Converters
{
    public class DescriptionEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsEnum ||
                   Nullable.GetUnderlyingType(objectType)?.IsEnum == true;
        }
        
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value != null)
            {
                if (value
                    .GetType()
                    .GetMember(value.ToString())
                    .First()
                    .IsDefined(typeof(DescriptionAttribute), false))
                {
                    writer.WriteValue((value as Enum).ToDescriptionString());
                }
                else
                {
                    writer.WriteValue(Convert.ToInt32(value));
                }
            }
        }

        public override object? ReadJson(
            JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                reader.Read();
                return null;
            }

            Type? underNullableType = Nullable.GetUnderlyingType(objectType);
            objectType = underNullableType ?? objectType;

            object? value = reader.Value;
            if (value is null) return null;

            if (value is string descriptionValue)
            {
                MemberInfo field = objectType
                    .GetMembers(BindingFlags.Public | BindingFlags.Static)
                    .First(member =>
                        member.IsDefined(typeof(DescriptionAttribute)) &&
                        member.GetCustomAttribute<DescriptionAttribute>().Description.Equals(descriptionValue));
                
                return Enum.Parse(objectType, field.Name);
            }

            if (int.TryParse(value.ToString(), out int intValue) &&
                Enum.IsDefined(objectType, intValue))
            {
                return Enum.ToObject(objectType, intValue);
            }

            throw new ArgumentException();
        }
    }
}