
using System;
using System.Collections.Generic;

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
        public void DeserializeAiPromptConfiguration_Basic_WithProjectContext()
        {
            const string json = "{\"mode\": \"basic\", \"projectContext\": true, \"organizationContext\": true}";
            var config = DeserializeAndAssert<BasicModeAiPromptConfiguration>(json);

            Assert.True(config.ProjectContext);
            Assert.True(config.OrganizationContext);
        }

        [Fact]
        public void DeserializeAiPromptConfiguration_Basic_WithEvaluationSteps()
        {
            const string json = "{\"mode\": \"basic\", \"evaluationSteps\": [\"step1\", \"step2\"]}";
            var config = DeserializeAndAssert<BasicModeAiPromptConfiguration>(json);

            Assert.NotNull(config.EvaluationSteps);
            Assert.Equal(new[] { "step1", "step2" }, config.EvaluationSteps);
        }

        [Fact]
        public void DeserializeAiPromptConfiguration_Advanced()
        {
            const string json = "{\"mode\": \"advanced\", \"prompt\": \"test\"}";
            var @object = DeserializeAndAssert<AdvancedModeAiPromptConfiguration>(json);

            Assert.Equal(AiPromptMode.Advanced, @object.Mode);
            Assert.Equal("test", @object.Prompt);
        }

        [Fact]
        public void SerializeBasicModeConfig_WithNewFields()
        {
            var config = new BasicModeAiPromptConfiguration
            {
                GlossaryTerms = true,
                ProjectContext = true,
                OrganizationContext = true,
                EvaluationSteps = new List<string> { "Check grammar", "Check terminology" }
            };

            string json = JsonConvert.SerializeObject(config, JsonSettings);

            Assert.Contains("\"projectContext\":true", json);
            Assert.Contains("\"organizationContext\":true", json);
            Assert.Contains("\"evaluationSteps\"", json);
            Assert.Contains("Check grammar", json);
        }

        [Fact]
        public void SerializePreTranslateOverridePromptValues()
        {
            var overrideValues = new PreTranslateOverridePromptValues
            {
                ProjectName = "My project",
                ProjectDescription = "My project description",
                OrganizationName = "My org",
                OrganizationDescription = "My org description"
            };

            string json = JsonConvert.SerializeObject(overrideValues, JsonSettings);

            Assert.Contains("\"projectName\":\"My project\"", json);
            Assert.Contains("\"projectDescription\":\"My project description\"", json);
            Assert.Contains("\"organizationName\":\"My org\"", json);
            Assert.Contains("\"organizationDescription\":\"My org description\"", json);
        }

        [Fact]
        public void SerializeQaCheckOverridePromptValues()
        {
            var overrideValues = new QaCheckOverridePromptValues
            {
                ProjectName = "My project",
                ProjectDescription = "My description",
                OrganizationName = "My org",
                OrganizationDescription = "My org desc"
            };

            string json = JsonConvert.SerializeObject(overrideValues, JsonSettings);

            Assert.Contains("\"projectDescription\":\"My description\"", json);
            Assert.Contains("\"organizationName\":\"My org\"", json);
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
