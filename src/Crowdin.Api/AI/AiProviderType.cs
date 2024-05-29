
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public enum AiProviderType
    {
        [SerializedValue("open_ai")]
        OpenAi,
        
        [SerializedValue("azure_open_ai")]
        AzureOpenAi,
        
        [SerializedValue("google_gemini")]
        GoogleGemini,
        
        [SerializedValue("mistral_ai")]
        MistralAi,
        
        [SerializedValue("anthropic")]
        Anthropic,
        
        [SerializedValue("custom_ai")]
        CustomAi
    }
}