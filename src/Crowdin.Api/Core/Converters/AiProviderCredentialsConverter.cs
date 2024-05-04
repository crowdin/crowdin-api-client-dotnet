
using System;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Crowdin.Api.AI;

namespace Crowdin.Api.Core.Converters
{
    internal class AiProviderCredentialsConverter : JsonConverter<AiProviderResource>
    {
        public override bool CanWrite => false;
        
        public override void WriteJson(JsonWriter writer, AiProviderResource value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        
        public override AiProviderResource ReadJson(
            JsonReader reader, Type objectType, AiProviderResource existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            
            existingValue ??= JsonConvert.DeserializeObject<AiProviderResource>( // TODO: optimize
                jObject.ToString(),
                serializer.Converters.Where(converter => converter.GetType() != GetType()).ToArray());
            if (existingValue is null) return null;
            
            Type returnType = existingValue.Type switch
            {
                AiProviderType.OpenAi => typeof (OpenAiProviderCredentials),
                AiProviderType.AzureOpenAi => typeof(AzureOpenAiProviderCredentials),
                AiProviderType.GoogleGemini => typeof(GoogleGeminiAiProviderCredentials),
                AiProviderType.MistralAi => typeof(MistralAiProviderCredentials),
                AiProviderType.Anthropic => typeof(AnthropicAiProviderCredentials),
                AiProviderType.CustomAi => typeof(CustomAiProviderCredentials),
                _ => throw new ArgumentOutOfRangeException(null, "Property Type not found or has unsupported value")
            };
            
            var credentialsRawObject = (JObject) jObject["credentials"]!;
            var credentialsRawObjectJson = credentialsRawObject.ToString();
            existingValue.Credentials = (AiProviderCredentials) JsonConvert.DeserializeObject(credentialsRawObjectJson, returnType);
            
            return existingValue;
        }
    }
}