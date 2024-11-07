
using System;

using Newtonsoft.Json;
using Xunit;

using Crowdin.Api.Tasks;

namespace Crowdin.Api.UnitTesting.Tests.Tasks
{
    public class TasksPendingSerializationTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();

        private static void SerializeAndCompare<T>(T actualRequest, string expectedJson)
        {
            Assert.Equal(
                expected: TestUtils.CompactJson(expectedJson),
                actual: JsonConvert.SerializeObject(actualRequest, JsonSettings));
        }

        [Fact]
        public void PendingTaskCreateForm()
        {
            var actualRequest = new PendingTaskCreateForm
            {
                PrecedingTaskId = 1,
                Type = TaskType.Proofread,
                Title = "string",
                Description = "string",
                Assignees = new[]
                {
                    new TaskAssigneeForm
                    {
                        Id = 2,
                        WordsCount = 3
                    }
                },
                DeadLine = DateTimeOffset.Parse("2019-09-27T07:00:14+00:00").ToLocalTime()
            };

            SerializeAndCompare(actualRequest, Resources.Tasks.Request_PendingTaskCreateForm);
        }

        [Fact]
        public void CrowdinLanguageServicePendingTaskCreateForm()
        {
            var actualRequest = new LanguageServicePendingTaskCreateForm
            {
                PrecedingTaskId = 1,
                Type = TaskType.Proofread,
                Vendor = TaskVendor.Alconost,
                Title = "string",
                Description = "string",
                DeadLine = DateTimeOffset.Parse("2019-09-27T07:00:14+00:00").ToLocalTime()
            };

            SerializeAndCompare(actualRequest, Resources.Tasks.Request_CrowdinLanguageServicePendingTaskCreateForm);
        }

        [Fact]
        public void CrowdinVendorManualPendingTaskCreateForm()
        {
            var actualRequest = new VendorManualPendingTaskCreateForm
            {
                PrecedingTaskId = 1,
                Type = TaskType.Proofread,
                Vendor = TaskVendor.Acclaro,
                Title = "string",
                Description = "string",
                Assignees = new[]
                {
                    new TaskAssigneeForm
                    {
                        Id = 1,
                        WordsCount = 3
                    }
                },
                DeadLine = DateTimeOffset.Parse("2019-09-27T07:00:14+00:00").ToLocalTime()
            };

            SerializeAndCompare(actualRequest, Resources.Tasks.Request_VendorManualPendingTaskCreateForm);
        }

        [Fact]
        public void EnterprisePendingTaskCreateForm()
        {
            var actualRequest = new EnterprisePendingTaskCreateForm
            {
                PrecedingTaskId = 1,
                Type = TaskType.Proofread,
                Title = "string",
                Description = "string",
                Assignees = new[]
                {
                    new TaskAssigneeForm
                    {
                        Id = 1,
                        WordsCount = 5
                    }
                },
                AssignedTeams = new[]
                {
                    new TaskAssignedTeam
                    {
                        Id = 1,
                        WordsCount = 5
                    }
                },
                DeadLine = DateTimeOffset.Parse("2019-09-27T07:00:14+00:00").ToLocalTime()
            };

            SerializeAndCompare(actualRequest, Resources.Tasks.Request_EnterprisePendingTaskCreateForm);
        }
    }
}