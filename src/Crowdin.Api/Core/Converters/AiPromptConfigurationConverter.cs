
using System;
using Crowdin.Api.AI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.Core.Converters
{
    internal class AiPromptConfigurationConverter : JsonConverter<AiPromptConfiguration>
    {
        public override bool CanWrite => false;
        
        public override void WriteJson(JsonWriter writer, AiPromptConfiguration value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        
        public override AiPromptConfiguration ReadJson(
            JsonReader reader, Type objectType, AiPromptConfiguration existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            
            Type returnType = obj.GetValue("mode")?.Value<string>() switch
            {
                "basic" => typeof(BasicModeAiPromptConfiguration),
                "advanced" => typeof(AdvancedModeAiPromptConfiguration),
                _ => throw new ArgumentOutOfRangeException(null, "Property Mode not found or has unsupported value")
            };
            
            return (AiPromptConfiguration)JsonConvert.DeserializeObject(obj.ToString(), returnType);
        }
    }
}