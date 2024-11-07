using Crowdin.Api.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace Crowdin.Api.UnitTesting.Tests.Tasks
{
    public class TasksApiTests
    {
        private static readonly JsonSerializerSettings Settings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public void AddTask_VendorGengo_RequestSerialization_ToneNotSet()
        {
            var request = new VendorGengoTaskCreateForm
            {
                Type = TaskType.TranslateByVendor,
                Tone = VendorGengoTaskCreateForm.TaskTone.NotSet
            };

            string requestJson = JsonConvert.SerializeObject(request, Settings);
            Assert.NotNull(requestJson);
            Assert.Equal(Resources.Tasks.AddTask_RightRequestJson_VendorGengo_ToneNotSet, requestJson);
        }

        [Fact]
        public void AddTask_VendorGengo_RequestSerialization_ToneInformal()
        {
            var request = new VendorGengoTaskCreateForm
            {
                Type = TaskType.TranslateByVendor,
                Tone = VendorGengoTaskCreateForm.TaskTone.Informal
            };

            string requestJson = JsonConvert.SerializeObject(request, Settings);
            Assert.NotNull(requestJson);
            Assert.Equal(Resources.Tasks.AddTask_RightRequestJson_VendorGengo_ToneInformal, requestJson);
        }

        [Fact]
        public void AddTask_VendorGengo_RequestSerialization_ToneOther()
        {
            var request = new VendorGengoTaskCreateForm
            {
                Type = TaskType.TranslateByVendor,
                Tone = VendorGengoTaskCreateForm.TaskTone.Other
            };

            string requestJson = JsonConvert.SerializeObject(request, Settings);
            Assert.NotNull(requestJson);
            Assert.Equal(Resources.Tasks.AddTask_RightRequestJson_VendorGengo_ToneOther, requestJson);
        }

        [Fact]
        public void AddTask_VendorManual_RequestSerialization()
        {
            var request = new VendorManualTaskCreateForm
            {
                Title = "My task",
                LanguageId = "es",
                FileIds = new[] { 1, 2, 3 },
                Type = TaskType.TranslateByVendor,
                Vendor = TaskVendor.Lingo24,
                Status = TaskStatus.InProgress,
                Description = "My amazing task",
                SkipAssignedStrings = true,
                SkipUntranslatedStrings = true,
                LabelIds = new[] { 1 },
                Assignees = new[]
                {
                    new TaskAssigneeForm { Id = 1, WordsCount = 20 },
                    new TaskAssigneeForm { Id = 2, WordsCount = 30 }
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, Settings);
            string expectedRequestJson = TestUtils.CompactJson(Resources.Tasks.AddTask_RightRequestJson_VendorManual);
            Assert.Equal(expectedRequestJson, actualRequestJson);
        }
    }
}