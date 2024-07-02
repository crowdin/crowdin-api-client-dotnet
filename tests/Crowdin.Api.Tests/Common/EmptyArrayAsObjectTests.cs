
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Core;
using Crowdin.Api.ProjectsGroups;
using Crowdin.Api.Tests.Core;
using Crowdin.Api.Tests.Core.Resources;
using Crowdin.Api.Webhooks.Organization;

namespace Crowdin.Api.Tests.Common
{
    public class EmptyArrayAsObjectTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public void OrganizationWebhookResource()
        {
            string actualResponseJson = Core_BugCases.Response_OrgWebhook_HeadersArray;

            var parser = new JsonParser(JsonSettings);
            var obj = parser.ParseResponseObject<OrganizationWebhookResource>(JObject.Parse(actualResponseJson));
            
            Assert.NotNull(obj);
            Assert.NotNull(obj.Headers);
            Assert.Empty(obj.Headers);
        }
        
        [Fact]
        public void ProjectSettings()
        {
            string actualResponseJson = Core_BugCases.Response_ProjectSettings_TmPenalties;
            
            var parser = new JsonParser(JsonSettings);
            var response = parser.ParseResponseObject<ProjectSettings>(JObject.Parse(actualResponseJson));
            
            Assert.NotNull(response);
            Assert.NotNull(response.TmPenalties);
        }
    }
}