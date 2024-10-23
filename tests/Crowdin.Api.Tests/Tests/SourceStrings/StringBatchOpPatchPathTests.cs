
using Newtonsoft.Json;
using Xunit;

using Crowdin.Api.SourceStrings;

namespace Crowdin.Api.UnitTesting.Tests.SourceStrings
{
    public class StringBatchOpPatchPathTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public static void StringBatchOpPatch_Serialization_TwoArgsExist_ObjectInitializer()
        {
            var path = new StringBatchOpPatchPath
            {
                StringId = 1,
                Property = StringBatchOpPatchPathEntry.IsHidden
            };

            SerializeAndAssert(path, "/1/isHidden");
        }

        [Fact]
        public static void StringBatchOpPatch_Serialization_TwoArgsExist_Constructor()
        {
            var path = new StringBatchOpPatchPath(1, StringBatchOpPatchPathEntry.IsHidden);
            SerializeAndAssert(path, "/1/isHidden");
        }

        [Fact]
        public static void StringBatchOpPatch_Serialization_OnlyStringId_Constructor()
        {
            var path = new StringBatchOpPatchPath(1);
            SerializeAndAssert(path, "/1");
        }

        // OnlyProperty case not needed for now

        [Fact]
        public static void StringBatchOpPatch_Serialization_NoArgs_Constructor()
        {
            var path = new StringBatchOpPatchPath();
            SerializeAndAssert(path, "/-");
        }

        private static void SerializeAndAssert(StringBatchOpPatchPath actualPath, string expectedPathString)
        {
            string actualPathString = TestUtils.SerializeValue(actualPath, JsonSettings);
            Assert.Equal(expectedPathString, actualPathString);
        }
    }
}