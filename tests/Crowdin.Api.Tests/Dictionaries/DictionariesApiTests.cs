
using Crowdin.Api.Dictionaries;
using Crowdin.Api.Tests.Core;
using Newtonsoft.Json;
using Xunit;

namespace Crowdin.Api.Tests.Dictionaries
{
    public class DictionariesApiTests
    {
        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public void EditDictionary_Add_PatchesSerialization()
        {
            var patches = new[]
            {
                new DictionaryPatch
                {
                    Operation = PatchOperation.Add,
                    Path = DictionaryPatchPath.Words,
                    Value = "word 1"
                },
                new DictionaryPatch
                {
                    Operation = PatchOperation.Add,
                    Path = DictionaryPatchPath.Words,
                    Value = "word 2"
                }
            };

            string actualPatchesListJson = JsonConvert.SerializeObject(patches, DefaultSettings);
            string rightPatchesListJson = Core.Resources.Dictionaries.EditDictionary_OpAdd_RightPatchesListJson;
            
            Assert.NotEmpty(actualPatchesListJson);
            Assert.Equal(rightPatchesListJson, actualPatchesListJson);
        }

        [Fact]
        public void EditDictionary_Remove_PatchesSerialization_SingleIndex()
        {
            var patches = new[]
            {
                new DictionaryPatch
                {
                    Operation = PatchOperation.Remove,
                    Path = new DictionaryPatchPath(new[] { 3 })
                }
            };

            string actualPatchesListJson = JsonConvert.SerializeObject(patches, DefaultSettings);
            string rightPatchesListJson = Core.Resources.Dictionaries.EditDictionary_OpRemove_RightPatchesListJson_SingleIndex;
            
            Assert.NotEmpty(actualPatchesListJson);
            Assert.Equal(rightPatchesListJson, actualPatchesListJson);
        }
        
        [Fact]
        public void EditDictionary_Remove_PatchesSerialization_MultiIndexesWithDuplicates()
        {
            var patches = new[]
            {
                new DictionaryPatch
                {
                    Operation = PatchOperation.Remove,
                    Path = new DictionaryPatchPath(new []{ 0, 1, 2, 0, 3, 3 })
                },
            };
            
            string actualPatchesListJson = JsonConvert.SerializeObject(patches, DefaultSettings);
            string rightPatchesListJson = Core.Resources.Dictionaries.EditDictionary_OpRemove_RightPatchesListJson_MultiIndexesWithDuplicates;
            
            Assert.NotEmpty(actualPatchesListJson);
            Assert.Equal(rightPatchesListJson, actualPatchesListJson);
        }
    }
}