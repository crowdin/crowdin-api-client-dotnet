
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiProviderCredentials
    {
        
    }
    
    [PublicAPI]
    public class OpenAiProviderCredentials : AiProviderCredentials
    {
        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }
    }
    
    [PublicAPI]
    public class AzureOpenAiProviderCredentials : AiProviderCredentials
    {
        [JsonProperty("resourceName")]
        public string ResourceName { get; set; }
        
        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }
        
        [JsonProperty("deploymentName")]
        public string DeploymentName { get; set; }
        
        [JsonProperty("apiVersion")]
        public string ApiVersion { get; set; }
    }
    
    [PublicAPI]
    public class GoogleGeminiAiProviderCredentials : AiProviderCredentials
    {
        [JsonProperty("project")]
        public string Project { get; set; }
        
        [JsonProperty("region")]
        public string Region { get; set; }
        
        [JsonProperty("serviceAccountKey")]
        public string ServiceAccountKey { get; set; }
    }
    
    [PublicAPI]
    public class MistralAiProviderCredentials : AiProviderCredentials
    {
        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }
    }
    
    [PublicAPI]
    public class AnthropicAiProviderCredentials : AiProviderCredentials
    {
        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }
    }
    
    [PublicAPI]
    public class CustomAiProviderCredentials : AiProviderCredentials
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
        
        [JsonProperty("key")]
        public string Key { get; set; }
    }
}