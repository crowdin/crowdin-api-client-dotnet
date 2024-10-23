
using System.Collections.Generic;

using Newtonsoft.Json;
using Xunit;

using Crowdin.Api.ProjectsGroups;

namespace Crowdin.Api.UnitTesting.Tests.ProjectsGroups
{
    public class EditProjectTests
    {
        [Fact]
        public void EditProject_RequestSerialization_ProjectInfo()
        {
            var patches = new List<ProjectInfoPatch>
            {
                new ProjectInfoPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = ProjectInfoPathCode.Name,
                    Value = "Another project name"
                },
                new ProjectInfoPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = new ProjectInfoPath
                    {
                        Code = ProjectInfoPathCode.LanguageMapping,
                        SubCodes = new[] { "languageId", "mappingKey" }
                    },
                    Value = new HashSet<string> { "set", "of", "values" }
                }
            };

            JsonSerializerSettings options = TestUtils.CreateJsonSerializerOptions();
            string requestJson = JsonConvert.SerializeObject(patches, options);
            string rightRequestJson = Resources.Projects.EditProject_RightRequestJson_ProjectInfoPatches;
            Assert.Equal(rightRequestJson, requestJson);
        }

        [Fact]
        public void EditProject_RequestSerialization_ProjectSetting()
        {
            var patches = new List<ProjectSettingPatch>
            {
                new ProjectSettingPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = ProjectSettingPathCode.IsMtAllowed,
                    Value = false
                },
                new ProjectSettingPatch
                {
                    Operation = PatchOperation.Add,
                    Path = new ProjectSettingPath
                    {
                        Code = ProjectSettingPathCode.QaCheckCategories,
                        SubCodes = new HashSet<string> { "category" }
                    },
                    Value = "another category"
                },
                new ProjectSettingPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = new ProjectSettingPath
                    {
                        Code = ProjectSettingPathCode.TmPenalties,
                        SubCodes = new[] { "multipleTranslations" }
                    },
                    Value = 1
                }
            };

            JsonSerializerSettings options = TestUtils.CreateJsonSerializerOptions();
            string requestJson = JsonConvert.SerializeObject(patches, options);
            string rightRequestJson = TestUtils.CompactJson(Resources.Projects.EditProject_RightRequestJson_ProjectSettingPatches);
            Assert.Equal(rightRequestJson, requestJson);
        }

        [Fact]
        public void EditProject_RequestSerialization_Polymorphic()
        {
            var patches = new List<ProjectPatch>
            {
                new ProjectInfoPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = ProjectInfoPathCode.Name,
                    Value = "Another project name"
                },
                new ProjectInfoPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = new ProjectInfoPath
                    {
                        Code = ProjectInfoPathCode.LanguageMapping,
                        SubCodes = new[] { "languageId", "mappingKey" }
                    },
                    Value = new HashSet<string> { "set", "of", "values" }
                },

                new ProjectSettingPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = ProjectSettingPathCode.IsMtAllowed,
                    Value = false
                },
                new ProjectSettingPatch
                {
                    Operation = PatchOperation.Add,
                    Path = new ProjectSettingPath
                    {
                        Code = ProjectSettingPathCode.QaCheckCategories,
                        SubCodes = new HashSet<string> { "category" }
                    },
                    Value = "another category"
                },

                new EnterpriseProjectPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = EnterpriseProjectPathCode.IsMtAllowed,
                    Value = true
                },
                new EnterpriseProjectPatch
                {
                    Operation = PatchOperation.Add,
                    Path = new EnterpriseProjectPath
                    {
                        Code = EnterpriseProjectPathCode.LanguageMapping,
                        SubCodes = new HashSet<string> { "languageId" }
                    },
                    Value = "new language"
                }
            };

            JsonSerializerSettings options = TestUtils.CreateJsonSerializerOptions();
            string requestJson = JsonConvert.SerializeObject(patches, options);
            string rightRequestJson = Resources.Projects.EditProject_RightRequestJson_PolymorphicPatches;
            Assert.Equal(rightRequestJson, requestJson);
        }
    }
}