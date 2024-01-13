
using Crowdin.Api.Applications;
using Crowdin.Api.Bundles;
using Crowdin.Api.Core;
using Crowdin.Api.Tests.Core;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Crowdin.Api.Tests.Applications
{
    public class ApplicationsInstallationsApiTests
    {
        private const string applicationIdentifier = "test-application";
        private static readonly Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

        [Fact]
        public async Task GetApplicationInstallation()
        {
            var url = $"/applications/installations/{applicationIdentifier}";
            mockClient.Setup(client => client.SendGetRequest(url,null))
                      .ReturnsAsync(new CrowdinApiResult
                        {
                            StatusCode = HttpStatusCode.OK,
                            JsonObject = JObject.Parse(Core.Resources.Applications.GetApplicationInstallation_Response)
                        }); 
            var executor = new ApplicationsApiExecutor(mockClient.Object);
            Application? response = await executor.GetApplicationInstallation(applicationIdentifier);
            Assert_ApplicationInstallation(response);

        }

        [Fact]
        public async Task GetApplicationInstallations()
        {
            var url = "/applications/installations";
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();
            mockClient.Setup(client => client.SendGetRequest(url, queryParams))
                      .ReturnsAsync(new CrowdinApiResult
                      {
                          StatusCode = HttpStatusCode.OK,
                          JsonObject = JObject.Parse(Core.Resources.Applications.ListApplicationInstallation_Response)
                      });
            var executor = new ApplicationsApiExecutor(mockClient.Object);
            var response = await executor.ListApplicationInstallations();
            Assert.NotNull(response);
            Assert.Single(response.Data);
            Assert_ApplicationInstallation(response.Data[0]);
        }

        [Fact]
        public async Task InstallApplication()
        {
            var url = "/applications/installations";
            var permissions = new ApplicationPermissions()
            {
                User = new()
                {
                    Value = ApplicationUserValue.Restricted,
                    Ids = new int[] { 1 }
                },
                Project = new()
                {
                    Value = ApplicationProjectValue.Restricted,
                    Ids = new int[] { 1 }

                }
            };
            var request = new InstallApplicationRequest { Url="https://localhost.dev", Permissions = permissions };
            mockClient.Setup(client => client.SendPostRequest(url, request, null))
                      .ReturnsAsync(new CrowdinApiResult
                      {
                          StatusCode = HttpStatusCode.OK,
                          JsonObject = JObject.Parse(Core.Resources.Applications.GetApplicationInstallation_Response)
                      });
            var executor = new ApplicationsApiExecutor(mockClient.Object);
            var response = await executor.InstallApplication(request);
            Assert.NotNull(response);
            Assert_ApplicationInstallation(response);

        }

        [Fact]
        public async Task EditApplicationInstallation()
        {
            var permissions = new ApplicationPermissions()
            {
                User = new()
                {
                    Value = ApplicationUserValue.Restricted,
                    Ids = new int[] { 1 }
                },
                Project = new()
                {
                    Value = ApplicationProjectValue.Restricted,
                    Ids = new int[] { 1 }

                }
            };

            var patches = new[]
            {
                new InstallationPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = InstallationPatchPath.Permissions,
                    Value = permissions
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(patches, TestUtils.CreateJsonSerializerOptions());
            string expectedRequestJson = TestUtils.CompactJson(Core.Resources.Applications.EditInstallation_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            var url = $"/applications/installations/{applicationIdentifier}";

            mockClient
                .Setup(client => client.SendPatchRequest(url, patches, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.Applications.GetApplicationInstallation_Response)
                });

            var executor = new ApplicationsApiExecutor(mockClient.Object);
            Application? response = await executor.EditApplicationInstallation(applicationIdentifier, patches);

            Assert_ApplicationInstallation(response);
        }

        [Fact]
        public async Task DeleteApplicationInstallation()
        {
            var url = $"/applications/installations/{applicationIdentifier}";
            IDictionary<string, string> queryParams = new Dictionary<string, string> { { "force", "False" } };
            mockClient.Setup(client => client.SendDeleteRequest(url, queryParams))
                      .ReturnsAsync(HttpStatusCode.NoContent);
            var executor = new ApplicationsApiExecutor(mockClient.Object);
            await executor.DeleteApplicationInstallation(applicationIdentifier);
        }

        private void Assert_ApplicationInstallation(Application? application)
        {
            Assert.NotNull(application);
            Assert.Equal("Test Application", application!.Name);
            Assert.Equal(applicationIdentifier, application.Identifier);
            Assert.Equal("Test Description", application.Description);
            Assert.True(application.LimitReached);
            Assert.Equal("/logo.png", application.Logo);
            Assert.Equal("https://localhost.dev", application.BaseUrl);
            Assert.Equal("https://localhost.dev", application.ManifestUrl);

            DateTimeOffset date = DateTimeOffset.Parse("2024-01-13T11:34:40+00:00");
            Assert.Equal(date, application.CreatedAt);

            Assert.NotNull(application.Scopes);
            Assert.Single(application.Scopes);
            Assert.Equal("project", application.Scopes[0]);
            Assert.NotNull(application.Modules);
            Assert.Single(application.Modules);
            Assert.Equal("test-application", application.Modules[0].Key);
        }
    }
}
