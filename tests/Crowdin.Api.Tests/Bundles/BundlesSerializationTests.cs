
using Newtonsoft.Json;
using Xunit;

using Crowdin.Api.Bundles;
using Crowdin.Api.Tests.Core;

namespace Crowdin.Api.Tests.Bundles
{
    public class BundlesSerializationTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public void PatchPaths()
        {
            SerializeAndAssert(BundlePatchPath.Name, "/name");
            SerializeAndAssert(BundlePatchPath.Format, "/format");
            SerializeAndAssert(BundlePatchPath.SourcePatterns, "/sourcePatterns");
            SerializeAndAssert(BundlePatchPath.IgnorePatterns, "/ignorePatterns");
            SerializeAndAssert(BundlePatchPath.ExportPattern, "/exportPattern");
            SerializeAndAssert(BundlePatchPath.IsMultilingual, "/isMultilingual");
            SerializeAndAssert(BundlePatchPath.LabelIds, "/labelIds");
        }

        private static void SerializeAndAssert(BundlePatchPath actualPath, string expectedPathString)
        {
            string actualPathString = TestUtils.SerializeValue(actualPath, JsonSettings);
            
            Assert.Equal(expectedPathString, actualPathString);
        }
    }
}