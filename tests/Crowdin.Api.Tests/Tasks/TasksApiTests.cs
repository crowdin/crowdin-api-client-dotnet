
using Crowdin.Api.Tasks;
using Crowdin.Api.Tests.Core;
using Newtonsoft.Json;
using Xunit;

namespace Crowdin.Api.Tests.Tasks
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
            Assert.Equal(Core.Resources.Tasks.AddTask_RightRequestJson_VendorGengo_ToneNotSet, requestJson);
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
            Assert.Equal(Core.Resources.Tasks.AddTask_RightRequestJson_VendorGengo_ToneInformal, requestJson);
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
            Assert.Equal(Core.Resources.Tasks.AddTask_RightRequestJson_VendorGengo_ToneOther, requestJson);
        }
    }
}