
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

using Newtonsoft.Json;

using Crowdin.Api.Reports;

#nullable enable

namespace Crowdin.Api.Core.Converters
{
    internal class ReportMatchTypeObjectConverter : JsonConverter<MatchTypeObject>
    {
        public override MatchTypeObject? ReadJson(
            JsonReader reader, Type objectType, MatchTypeObject? existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.String)
            {
                reader.Read();
                return null;
            }

            if (!(reader.Value is string value)) return null;
            
            MemberInfo? field = typeof(MatchType)
                .GetMembers(BindingFlags.Public | BindingFlags.Static)
                .FirstOrDefault(member =>
                    member.IsDefined(typeof(DescriptionAttribute)) &&
                    member.GetCustomAttribute<DescriptionAttribute>().Description.Equals(value));

            if (field != null)
            {
                var matchType = (MatchType) Enum.Parse(typeof(MatchType), field.Name);
                return MatchTypeObject.FromStaticRange(matchType);
            }

            // ReSharper disable once InvertIf
            if (value.Contains('-'))
            {
                int[] values = value
                    .Split('-')
                    .Select(int.Parse)
                    .ToArray();
                
                return MatchTypeObject.FromCustomRange(values[0], values[1]);
            }
            
            throw new ArgumentOutOfRangeException("No support for value: " + value);
        }
        
        public override void WriteJson(JsonWriter writer, MatchTypeObject? @object, JsonSerializer serializer)
        {
            writer.WriteValue(@object?.Value);
        }
    }
}