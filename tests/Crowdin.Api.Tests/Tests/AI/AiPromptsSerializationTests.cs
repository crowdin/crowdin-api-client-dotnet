
using System;

using Newtonsoft.Json;
using Xunit;

using Crowdin.Api.AI;

namespace Crowdin.Api.UnitTesting.Tests.AI
{
    public class AiPromptsSerializationTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public void DeserializeAiPromptConfiguration_Basic()
        {
            const string json = "{\"mode\": \"basic\"}";
            DeserializeAndAssert<BasicModeAiPromptConfiguration>(json);
        }

        [Fact]
        public void DeserializeAiPromptConfiguration_Advanced()
        {
            const string json = "{\"mode\": \"advanced\", \"prompt\": \"test\"}";
            var @object = DeserializeAndAssert<AdvancedModeAiPromptConfiguration>(json);

            Assert.Equal(AiPromptMode.Advanced, @object.Mode);
            Assert.Equal("test", @object.Prompt);
        }

        private static TType DeserializeAndAssert<TType>(string json) where TType : AiPromptConfiguration
        {
            var config = JsonConvert.DeserializeObject<AiPromptConfiguration>(json, JsonSettings);

            ArgumentNullException.ThrowIfNull(config);
            Assert.IsType<TType>(config);

            return (TType)config;
        }
    }
}