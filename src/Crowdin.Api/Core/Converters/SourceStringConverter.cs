
using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Crowdin.Api.SourceStrings;

namespace Crowdin.Api.Core.Converters
{
    internal class SourceStringConverter : JsonConverter<SourceString>
    {
        public override bool CanWrite => false;
        
        public override void WriteJson(JsonWriter writer, SourceString value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override SourceString ReadJson(
            JsonReader reader, Type objectType, SourceString existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            
            var constructedObject = JsonConvert.DeserializeObject<SourceString>(obj.ToString());

            if (!obj.TryGetValue("text", out JToken textToken))
            {
                return constructedObject;
            }
            
            // ReSharper disable once SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault
            object textObject = textToken.Type switch
            {
                JTokenType.String => textToken.Value<string>(),
                JTokenType.Object => JsonConvert.DeserializeObject<SourceTextForms>(textToken.ToString()),
                _ => throw new ArgumentOutOfRangeException(null, "Unknown Text property type")
            };

            constructedObject.Text = textObject;
            
            return constructedObject;
        }
    }
}