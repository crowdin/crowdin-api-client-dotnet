
using Newtonsoft.Json;
using Xunit;

using Crowdin.Api.Tests.Testing;
using Crowdin.Api.TranslationMemory;

namespace Crowdin.Api.Tests.TranslationMemory
{
    public class TranslationMemorySerializationTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public void PatchPaths()
        {
            SerializeAndAssert(TmPatchPath.Name, "/name");
            SerializeAndAssert(TmPatchPath.GroupId, "/groupId");
            SerializeAndAssert(TmPatchPath.LanguageId, "/languageId");
        }

        private static void SerializeAndAssert(TmPatchPath actualPath, string expectedPathString)
        {
            string actualPathString = TestUtils.SerializeValue(actualPath, JsonSettings);
            
            Assert.Equal(expectedPathString, actualPathString);
        }
    }
}