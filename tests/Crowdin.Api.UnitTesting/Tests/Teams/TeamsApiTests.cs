
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Core;
using Crowdin.Api.ProjectsGroups;
using Crowdin.Api.Teams;
using Crowdin.Api.Users;

namespace Crowdin.Api.UnitTesting.Tests.Teams
{
    public class TeamsApiTests
    {
        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task ListTeams()
        {
            var @params = new TeamsListParams
            {
                Search = "MyTeam",
                GroupIds = [ 1, 2, 30 ],
                ProjectIds = [ 4, 5, 60 ],
                LanguageIds = [ "uk", "it", "es" ],
                ProjectRoles =
                [
                    ProjectRole.Member,
                    ProjectRole.Translator,
                    ProjectRole.Proofreader
                ],
                OrderBy =
                [
                    new SortingRule
                    {
                        Field = "createdAt",
                        Order = SortingOrder.Ascending
                    },
                    new SortingRule
                    {
                        Field = "name",
                        Order = SortingOrder.Descending
                    }
                ]
            };

            IDictionary<string, string> paramsDict = @params.ToQueryParams();
            
            Assert.Equal("25", paramsDict["limit"]);
            Assert.Equal("MyTeam", paramsDict["search"]);
            Assert.Equal("1,2,30", paramsDict["groupIds"]);
            Assert.Equal("4,5,60", paramsDict["projectIds"]);
            Assert.Equal("uk,it,es", paramsDict["languageIds"]);
            Assert.Equal("member,translator,proofreader", paramsDict["projectRoles"]);
            Assert.Equal("createdAt asc,name desc", paramsDict["orderBy"]);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendGetRequest("/teams", paramsDict))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.Teams.ListTeams_Response)
                });
            
            var executor = new TeamsApiExecutor(mockClient.Object);
            ResponseList<Team> response = await executor.ListTeams(@params);
            
            Assert.NotNull(response);
        }

        [Fact]
        public async Task AddTeamToProject()
        {
            const int projectId = 1;

            var request = new AddTeamToProjectRequest
            {
                TeamId = 1,
                AccessToAllWorkflowSteps = false,
                ManagerAccess = false,
                Permissions = new Dictionary<string, LanguagePermission>
                {
                    {
                        "it",
                        new LanguagePermission
                        {
                            WorkflowStepIds = new[] { 313 }
                        }
                    },
                    {
                        "de",
                        new LanguagePermission
                        {
                            WorkflowStepIds = "all"
                        }
                    }
                },
                Roles = new[]
                {
                    new TranslatorRole
                    {
                        Name = TranslatorRoleName.Translator,
                        Permissions = new TranslatorRolePermissions
                        {
                            AllLanguages = false,
                            LanguagesAccess = new Dictionary<string, LanguageAccessRule>
                            {
                                ["uk"] = new LanguageAccessRule
                                {
                                    AllContent = false,
                                    WorkflowStepIds = new[] { 882 }
                                },
                                ["it"] = new LanguageAccessRule
                                {
                                    AllContent = true
                                }
                            }
                        }
                    },
                    new TranslatorRole
                    {
                        Name = TranslatorRoleName.Proofreader,
                        Permissions = new TranslatorRolePermissions
                        {
                            AllLanguages = true,
                            LanguagesAccess = Array.Empty<object>()
                        }
                    }
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Resources.Teams.AddTeamToProject_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/teams";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(Resources.Teams.AddTeamToProject_Response)
                });

            var executor = new TeamsApiExecutor(mockClient.Object);
            ProjectTeamResources response = await executor.AddTeamToProject(projectId, request);

            Assert.NotNull(response.Skipped?.Permissions);
            Assert.Contains("it", response.Skipped!.Permissions);

            int[]? workflowStepIds = JArray.FromObject(response.Skipped!.Permissions["it"].WorkflowStepIds).ToObject<int[]>();
            Assert.NotNull(workflowStepIds);
            Assert.Equal(313, workflowStepIds![0]);
        }
    }
}