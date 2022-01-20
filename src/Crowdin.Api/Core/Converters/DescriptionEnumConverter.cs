
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
            if (value is null) return;
            Type valueType = value.GetType();
            
            if (valueType
                     .GetMember(value.ToString())
                     .First()
                     .IsDefined(typeof(DescriptionAttribute), false))
            {
                writer.WriteValue((value as Enum).ToDescriptionString());
            }
            else if (valueType.IsDefined(typeof(StrictStringRepresentation)))
            {
                string? memberName = Enum.GetName(valueType, value);

                if (memberName is null)
                {
                    throw new Exception($"Value {value} not found on enum type {valueType.Name}");
                }
                
                writer.WriteValue(memberName);
            }
            else
            {
                writer.WriteValue(Convert.ToInt32(value));
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

            // String enum
            if (value is string descriptionValue)
            {
                // Check if value has own string representation in [Description] attribute
                MemberInfo? field = objectType
                    .GetMembers(BindingFlags.Public | BindingFlags.Static)
                    .FirstOrDefault(member =>
                        member.IsDefined(typeof(DescriptionAttribute)) &&
                        member.GetCustomAttribute<DescriptionAttribute>().Description.Equals(descriptionValue));

                if (field != null)
                {
                    return Enum.Parse(objectType, field.Name);
                }

                // Check if enum has strict string representation for all members
                if (objectType.IsDefined(typeof(StrictStringRepresentation)))
                {
                    return Enum.Parse(objectType, descriptionValue);
                }

                throw new ArgumentException("Error occurred during deserialization from JSON String");
            }

            // Numeric value -> simple int-to-enum conversion
            if (int.TryParse(value.ToString(), out int intValue) &&
                Enum.IsDefined(objectType, intValue))
            {
                return Enum.ToObject(objectType, intValue);
            }

            throw new ArgumentException("Error occurred during deserialization from JSON Number");
        }
    }

    [AttributeUsage(AttributeTargets.Enum)]
    public class StrictStringRepresentation : Attribute
    {
        
    }
}