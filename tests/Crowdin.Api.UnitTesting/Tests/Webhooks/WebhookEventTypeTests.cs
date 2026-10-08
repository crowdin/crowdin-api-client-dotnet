
using System;
using System.Linq;
using Crowdin.Api.Webhooks;

using Newtonsoft.Json;
using Xunit;

namespace Crowdin.Api.UnitTesting.Tests.Webhooks
{
    public class WebhookEventTypeTests
    {
        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public void ShouldAllEventsBeUnique()
        {
            var serializedEvents = Enum.GetValues<EventType>()
                .Select(e => JsonConvert.SerializeObject(e, DefaultSettings))
                .ToArray();

            Assert.Equal(serializedEvents.Length, serializedEvents.Distinct().Count());
        }

        [Fact]
        public void ShouldSerializeCandidateEventsToTheirApiValues()
        {
            SerializeAndAssert(EventType.FileAdded, "file.added");
            SerializeAndAssert(EventType.FileUpdated, "file.updated");
            SerializeAndAssert(EventType.FileReverted, "file.reverted");
            SerializeAndAssert(EventType.FileDeleted, "file.deleted");
            SerializeAndAssert(EventType.FileQaFinished, "file.qa.finished");
            SerializeAndAssert(EventType.ProjectQaFinished, "project.qa.finished");
            SerializeAndAssert(EventType.PreTranslationCompleted, "preTranslation.completed");
            SerializeAndAssert(EventType.TaskAdded, "task.added");
            SerializeAndAssert(EventType.TaskUpdated, "task.updated");
            SerializeAndAssert(EventType.TaskStatusChanged, "task.statusChanged");
            SerializeAndAssert(EventType.TaskDeleted, "task.deleted");
            SerializeAndAssert(EventType.GroupCreated, "group.created");
            SerializeAndAssert(EventType.GroupDeleted, "group.deleted");
            SerializeAndAssert(EventType.StringCommentCreated, "stringComment.created");
            SerializeAndAssert(EventType.StringCommentUpdated, "stringComment.updated");
            SerializeAndAssert(EventType.StringCommentDeleted, "stringComment.deleted");
            SerializeAndAssert(EventType.StringCommentRestored, "stringComment.restored");
            SerializeAndAssert(EventType.ProjectBuilt, "project.built");
        }

        private static void SerializeAndAssert(EventType eventType, string expected)
        {
            Assert.Equal($"\"{expected}\"", JsonConvert.SerializeObject(eventType, DefaultSettings));
        }
    }
}
