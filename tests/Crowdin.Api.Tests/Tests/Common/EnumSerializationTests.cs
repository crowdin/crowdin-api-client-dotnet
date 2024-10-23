
using System;
using Crowdin.Api.Distributions;
using Crowdin.Api.Reports;
using Crowdin.Api.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace Crowdin.Api.UnitTesting.Tests.Common
{
    public class EnumSerializationTests
    {
        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public void DescriptionEnums()
        {
            var enumValue = DistributionReleaseStatus.InProgress;
            string serializedEnumValue = JsonConvert.SerializeObject(enumValue, DefaultSettings);
            Assert.Equal("inProgress", StripQuotes(serializedEnumValue));

            var deserializedEnumValue = JsonConvert.DeserializeObject<DistributionReleaseStatus>(serializedEnumValue, DefaultSettings);
            Assert.Equal(enumValue, deserializedEnumValue);
        }

        [Fact]
        public void StrictStringEnums()
        {
            var enumValue = ReportCurrency.UAH;
            string serializedEnumValue = JsonConvert.SerializeObject(enumValue, DefaultSettings);
            Assert.Equal(nameof(ReportCurrency.UAH), StripQuotes(serializedEnumValue));

            var deserializedEnumValue = JsonConvert.DeserializeObject<ReportCurrency>(serializedEnumValue, DefaultSettings);
            Assert.Equal(enumValue, deserializedEnumValue);
        }

        [Fact]
        public void NumericEnums()
        {
            var enumValue = TaskType.Proofread;
            string serializedEnumValue = JsonConvert.SerializeObject(enumValue, DefaultSettings);
            Assert.Equal((int)enumValue, Convert.ToInt32(serializedEnumValue));

            var deserializedEnumValue = JsonConvert.DeserializeObject<TaskType>(serializedEnumValue, DefaultSettings);
            Assert.Equal(enumValue, deserializedEnumValue);
        }

        private static string StripQuotes(string valueWithQuotes) => valueWithQuotes.Replace("\"", "");
    }
}