
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public enum AiProviderType
    {
        [Description("open_ai")]
        OpenAi,
        
        [Description("azure_open_ai")]
        AzureOpenAi,
        
        [Description("google_gemini")]
        GoogleGemini,
        
        [Description("mistral_ai")]
        MistralAi,
        
        [Description("anthropic")]
        Anthropic,
        
        [Description("custom_ai")]
        CustomAi
    }
}