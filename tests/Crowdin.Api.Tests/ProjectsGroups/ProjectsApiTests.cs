
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using Crowdin.Api.ProjectsGroups;
using Crowdin.Api.Tests.Core;
using Crowdin.Api.Tests.Core.Resources;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Crowdin.Api.Tests.ProjectsGroups
{
    public class ProjectsApiTests
    {
        [Fact]
        public async Task ListProjects()
        {
            const int userId = 6;
            const int groupId = 4;
            const bool hasManagerAccess = true;

            var queryParams = new Dictionary<string, string>
            {
                { "limit", "25" },
                { "offset", "0" },
                { "userId", userId.ToString() },
                { "groupId", groupId.ToString() },
                { "hasManagerAccess", hasManagerAccess ? "1" : "0" },
                { "orderBy", "createdAt desc,name asc" }
            };

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendGetRequest($"/projects", queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Projects.ListProjects_RightResponseJson)
                });

            var executor = new ProjectsGroupsApiExecutor(mockClient.Object);
            ResponseList<EnterpriseProject> projectsList =
                await executor.ListProjects<EnterpriseProject>(
                    userId, groupId, hasManagerAccess,
                    orderBy: new[]
                    {
                        new SortingRule
                        {
                            Field = "createdAt",
                            Order = SortingOrder.Descending
                        },
                        new SortingRule
                        {
                            Field = "name",
                            Order = SortingOrder.Ascending
                        }
                    });
            
            Assert.NotNull(projectsList);
            Assert.Equal(25, projectsList.Pagination?.Limit);
            Assert.Single(projectsList.Data);
            Assert.NotNull(projectsList.Data[0].TargetLanguages);
            Assert.Single(projectsList.Data[0].TargetLanguages);
        }

        [Fact]
        public async Task GetProjectSettings()
        {
            const int projectId = 1;
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendGetRequest($"/projects/{projectId}", null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Projects.GetProject_RightResponseJson_ProjectSettings)
                });

            var executor = new ProjectsGroupsApiExecutor(mockClient.Object);
            var projectSettings = await executor.GetProject<ProjectSettings>(projectId);
            
            Assert.NotNull(projectSettings);
            Assert.Equal(DupTranslateAction.Hide, projectSettings.TranslateDuplicates);
            Assert.Equal(TagsDetectionAction.Auto, projectSettings.TagsDetection);

            IDictionary<int, AssignedTm>? assignedTms = projectSettings.AssignedTms;
            Assert.NotNull(assignedTms);
            Assert.Equal(1, assignedTms.Keys.Single());
            Assert.NotNull(assignedTms[1]);
            Assert.Equal(1, assignedTms[1].Priority);

            TmPenalties? tmPenalties = projectSettings.TmPenalties;
            Assert.NotNull(tmPenalties);
            Assert.Equal(1, tmPenalties.AutoSubstitution);
            Assert.Equal(1, tmPenalties.MultipleTranslations);

            TmPriority? tmPriority = tmPenalties.TmPriority;
            Assert.NotNull(tmPriority);
            Assert.Equal(2, tmPriority.Priority);
            Assert.Equal(1, tmPriority.Penalty);

            TmTimeElapsed? timeSinceLastUsage = tmPenalties.TimeSinceLastUsage;
            Assert.NotNull(timeSinceLastUsage);
            Assert.Equal(2, timeSinceLastUsage.Months);
            Assert.Equal(1, timeSinceLastUsage.Penalty);

            TmTimeElapsed? timeSinceLastModified = tmPenalties.TimeSinceLastModified;
            Assert.NotNull(timeSinceLastModified);
            Assert.Equal(2, timeSinceLastModified.Months);
            Assert.Equal(1, timeSinceLastModified.Penalty);
        }

        [Fact]
        public async Task AddProject_TestEnumsConversion()
        {
            var request = new FileBasedProjectForm
            {
                // nullable enum -> value assigned
                TranslateDuplicates = DupTranslateAction.HideStrict,

                // nullable enum TagsDetectionAction -> value not assigned

                // non-nullable enum -> value assigned
                LanguageAccessPolicy = LanguageAccessPolicy.Open
            };

            JsonSerializerSettings options = TestUtils.CreateJsonSerializerOptions();
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            string requestJson = JsonConvert.SerializeObject(request, options);
            string rightRequestJson = Projects.AddProject_RightRequestJson_EnumsTest;
            Assert.Equal(rightRequestJson, requestJson);

            mockClient
                .Setup(client => client.SendPostRequest("/projects", request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(Projects.AddProject_RightResponseJson_ProjectInfo)
                });

            var executor = new ProjectsGroupsApiExecutor(mockClient.Object);
            var projectResponse = await executor.AddProject<Project>(request);
            
            Assert.NotNull(projectResponse);
        }
    }
}