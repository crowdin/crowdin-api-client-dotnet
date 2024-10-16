
using System;

using Newtonsoft.Json;
using Xunit;

using Crowdin.Api.AI;
using Crowdin.Api.Tests.Testing;
using Crowdin.Api.Tests.Testing.Resources;

namespace Crowdin.Api.Tests.AI
{
    public class AiProvidersSerializationTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();
        
        [Fact]
        public void DeserializeAiProviderCredentials_OpenAi()
        {
            var @object = DeserializeAndAssert<OpenAiProviderCredentials>(
                json: AI_Providers.Serialization_AiProvider_Credentials_OpenAi);
            
            Assert.Equal("key", @object.ApiKey);
        }
        
        [Fact]
        public void DeserializeAiProviderCredentials_AzureOpenAi()
        {
            var @object = DeserializeAndAssert<AzureOpenAiProviderCredentials>(
                json: AI_Providers.Serialization_AiProvider_Credentials_AzureOpenAi);
            
            Assert.Equal("resource", @object.ResourceName);
            Assert.Equal("key", @object.ApiKey);
            Assert.Equal("deployment", @object.DeploymentName);
            Assert.Equal("1.0.0", @object.ApiVersion);
        }
        
        [Fact]
        public void DeserializeAiProviderCredentials_GoogleGemini()
        {
            var @object = DeserializeAndAssert<GoogleGeminiAiProviderCredentials>(
                json: AI_Providers.Serialization_AiProvider_Credentials_GoogleGemini);
            
            Assert.Equal("project", @object.Project);
            Assert.Equal("region", @object.Region);
            Assert.Equal("serviceAccountKey", @object.ServiceAccountKey);
        }
        
        [Fact]
        public void DeserializeAiProviderCredentials_MistralAi()
        {
            var @object = DeserializeAndAssert<MistralAiProviderCredentials>(
                json: AI_Providers.Serialization_AiProvider_Credentials_MistralAi);
            
            Assert.Equal("key", @object.ApiKey);
        }
        
        [Fact]
        public void DeserializeAiProviderCredentials_Anthropic()
        {
            var @object = DeserializeAndAssert<AnthropicAiProviderCredentials>(
                json: AI_Providers.Serialization_AiProvider_Credentials_Anthropic);
            
            Assert.Equal("key", @object.ApiKey);
        }
        
        [Fact]
        public void DeserializeAiProviderCredentials_CustomAi()
        {
            var @object = DeserializeAndAssert<CustomAiProviderCredentials>(
                json: AI_Providers.Serialization_AiProvider_Credentials_CustomAi);
            
            Assert.Equal("id", @object.Identifier);
            Assert.Equal("key", @object.Key);
        }
        
        private static TType DeserializeAndAssert<TType>(string json) where TType : AiProviderCredentials
        {
            var aiProvider = JsonConvert.DeserializeObject<AiProviderResource>(json, JsonSettings);
            
            ArgumentNullException.ThrowIfNull(aiProvider);
            ArgumentNullException.ThrowIfNull(aiProvider.Credentials);
            Assert.IsType<TType>(aiProvider.Credentials);
            
            return (TType) aiProvider.Credentials;
        }
    }
}