
using System;
using Newtonsoft.Json;
using Xunit;
using Crowdin.Api.Webhooks.Organization;

namespace Crowdin.Api.UnitTesting.Tests.Webhooks.Organization
{
    public class OrganizationWebhookEnumsTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public void EventTypes()
        {
            SerializeAndAssert(OrganizationEventType.ProjectCreated, "project.created");
            SerializeAndAssert(OrganizationEventType.ProjectDeleted, "project.deleted");
        }

        [Fact]
        public void EnterpriseEventTypes()
        {
            SerializeAndAssert(EnterpriseOrgEventType.GroupCreated, "group.created");
            SerializeAndAssert(EnterpriseOrgEventType.GroupDeleted, "group.deleted");
            SerializeAndAssert(EnterpriseOrgEventType.ProjectCreated, "project.created");
            SerializeAndAssert(EnterpriseOrgEventType.ProjectDeleted, "project.deleted");
        }

        [Fact]
        public void PathPaths()
        {
            SerializeAndAssert(OrganizationWebhookPatchPath.Name, "/name");
            SerializeAndAssert(OrganizationWebhookPatchPath.Url, "/url");
            SerializeAndAssert(OrganizationWebhookPatchPath.IsActive, "/isActive");
            SerializeAndAssert(OrganizationWebhookPatchPath.BatchingEnabled, "/batchingEnabled");
            SerializeAndAssert(OrganizationWebhookPatchPath.ContentType, "/contentType");
            SerializeAndAssert(OrganizationWebhookPatchPath.Events, "/events");
            SerializeAndAssert(OrganizationWebhookPatchPath.Headers, "/headers");
            SerializeAndAssert(OrganizationWebhookPatchPath.RequestType, "/requestType");
            SerializeAndAssert(OrganizationWebhookPatchPath.Payload, "/payload");
        }

        private static void SerializeAndAssert(Enum enumValue, string expectedValueString)
        {
            string actualValueString = TestUtils.SerializeValue(enumValue, JsonSettings);
            Assert.Equal(expectedValueString, actualValueString);
        }
    }
}