﻿
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Core;
using Crowdin.Api.Tests.Testing;
using Crowdin.Api.Users;

namespace Crowdin.Api.Tests.Users
{
    public class UsersApiTests
    {
        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task InviteUser()
        {
            var request = new EnterpriseInviteUserRequest
            {
                Email = "john@example.com",
                FirstName = "Jon",
                LastName = "Doe",
                TimeZone = "America/New_York",
                AdminAccess = true
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Testing.Resources.Users.InviteUser_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPostRequest("/users", request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Testing.Resources.Users.InviteUser_Response)
                });

            var executor = new UsersApiExecutor(mockClient.Object);
            UserEnterprise response = await executor.InviteUser(request);
            
            ExecuteAssertionsFor(response);
        }

        [Fact]
        public async Task DeleteUser()
        {
            const int userId = 1;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}";

            mockClient
                .Setup(client => client.SendDeleteRequest(url, null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            var executor = new UsersApiExecutor(mockClient.Object);
            await executor.DeleteUser(userId);
        }

        [Fact]
        public async Task EditUser()
        {
            const int userId = 1;
            
            var patches = new[]
            {
                new EnterpriseUserPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = EnterpriseUserPatchPath.FirstName,
                    Value = "Jonny"
                },
                new EnterpriseUserPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = EnterpriseUserPatchPath.Status,
                    Value = UserStatus.Active
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(patches, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Testing.Resources.Users.EditUser_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}";

            mockClient
                .Setup(client => client.SendPatchRequest(url, patches, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Testing.Resources.Users.EditUser_Response)
                });

            var executor = new UsersApiExecutor(mockClient.Object);
            UserEnterprise response = await executor.EditUser(userId, patches);
            
            ExecuteAssertionsFor(response);
        }
        
        private static void ExecuteAssertionsFor(UserEnterprise user)
        {
            Assert.Equal(UserStatus.Active, user.Status);
            Assert.Equal(DateTimeOffset.Parse("2019-07-11T07:40:22+00:00"), user.CreatedAt);
            Assert.Equal(DateTimeOffset.Parse("2019-10-23T11:44:02+00:00"), user.LastSeen);
            Assert.Equal(UserTwoFactorStatus.Enabled, user.TwoFactor);
            Assert.True(user.IsAdmin);
        }

        [Fact]
        public async Task AddProjectMember()
        {
            const int projectId = 1;

            var request = new AddProjectMemberRequest
            {
                UserIds = new[] { 1 },
                AccessToAllWorkflowSteps = false,
                ManagerAccess = false,
                Permissions = new Dictionary<string, LanguagePermission>
                {
                    ["it"] = new LanguagePermission
                    {
                        WorkflowStepIds = new[] { 313 }
                    },
                    ["de"] = new LanguagePermission
                    {
                        WorkflowStepIds = "all"
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
                                    WorkflowStepIds = new [] { 882 }
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
            string expectedRequestJson = TestUtils.CompactJson(Testing.Resources.Users.AddProjectMember_Request, DefaultSettings);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/members";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(Testing.Resources.Users.AddProjectMember_Response)
                });

            var executor = new UsersApiExecutor(mockClient.Object);
            ProjectMembersResponse response = await executor.AddProjectMember(projectId, request);
            
            Assert.NotNull(response);
            Assert.Single(response.Skipped);
            Assert.Single(response.Added);

            TranslatorRole? selector = response.Skipped[0].Roles?[0];
            Assert.NotNull(selector);
            Assert.Equal(TranslatorRoleName.Translator, selector!.Name);

            var rawLangAccess = ((JObject?) selector.Permissions?.LanguagesAccess)!;
            var langAccessDict = rawLangAccess?.ToObject<Dictionary<string, LanguageAccessRule>>();
            
            Assert.NotNull(langAccessDict);
            Assert.IsType<Dictionary<string, LanguageAccessRule>>(langAccessDict);
            Assert.Equal(new[] { "uk", "it" }, langAccessDict!.Keys);
        }
        
        [Fact]
        public async Task ReplaceProjectMemberPermissions()
        {
            const int projectId = 1, memberId = 2;

            var request = new ReplaceProjectMemberPermissionsRequest
            {
                AccessToAllWorkflowSteps = false,
                ManagerAccess = false,
                Permissions = new Dictionary<string, LanguagePermission>
                {
                    ["it"] = new LanguagePermission
                    {
                        WorkflowStepIds = new[] { 313 }
                    },
                    ["de"] = new LanguagePermission
                    {
                        WorkflowStepIds = "all"
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
            string expectedRequestJson = TestUtils.CompactJson(Testing.Resources.Users.ReplaceProjectMemberPermissions_Request, DefaultSettings);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/members/{memberId}";

            mockClient
                .Setup(client => client.SendPutRequest(url, request))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Testing.Resources.Users.ReplaceProjectMemberPermissions_Response)
                });

            var executor = new UsersApiExecutor(mockClient.Object);
            ProjectMember response = await executor.ReplaceProjectMemberPermissions(projectId, memberId, request);
            
            Assert.NotNull(response);
        }
        
        [Fact]
        public async Task ListProjectMembers()
        {
            const int projectId = 1;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/members";

            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();

            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Testing.Resources.Users.ListProjectMembers_Response)
                });

            var executor = new UsersApiExecutor(mockClient.Object);
            ResponseList<ProjectMember> response = await executor.ListProjectMembersEnterprise(projectId);
            
            Assert.NotNull(response);
        }
        
        [Fact]
        public async Task GetProjectMemberPermissions()
        {
            const int projectId = 1, memberId = 2;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/members/{memberId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Testing.Resources.Users.GetProjectMemberPermissions_Response)
                });

            var executor = new UsersApiExecutor(mockClient.Object);
            ProjectMember response = await executor.GetProjectMemberPermissions(projectId, memberId);
            
            Assert.NotNull(response);
        }
    }
}