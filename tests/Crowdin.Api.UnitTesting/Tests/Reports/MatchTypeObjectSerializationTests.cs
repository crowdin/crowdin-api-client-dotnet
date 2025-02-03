
using System;

using Newtonsoft.Json;
using Xunit;

using Crowdin.Api.Reports;

namespace Crowdin.Api.UnitTesting.Tests.Reports
{
    public class MatchTypeObjectSerializationTests
    {
        private static JsonSerializerSettings JsonOptions => TestUtils.CreateJsonSerializerOptions();
        
        [Fact]
        public void SerializeStaticValue()
        {
            MatchTypeObject @object = MatchTypeObject.FromStaticRange(MatchType.Perfect);
            
            SerializeAndAssert(@object, "perfect");
        }

        [Fact]
        public void SerializeCustomRange()
        {
            MatchTypeObject? @object = MatchTypeObject.FromCustomRange(78, 95);

            SerializeAndAssert(@object, "78-95");
        }
        
        [Fact]
        public void DeserializeStaticValue()
        {
            const string input = """ { "matchType": "perfect", "price": 0.1 } """;
            const string value = "perfect";
            
            DeserializeAndAssert(input, value);
        }

        [Fact]
        public void DeserializeCustomRange()
        {
            const string input = """ { "matchType": "78-90", "price": 0.1 } """;
            const string value = "78-90";
            
            DeserializeAndAssert(input, value);
        }

        private static void SerializeAndAssert(MatchTypeObject @object, string expectedValue)
        {
            string serialized = JsonConvert.SerializeObject(@object, JsonOptions);
            Assert.Equal($"\"{expectedValue}\"", serialized);
        }
        
        private static void DeserializeAndAssert(string input, string expectedValue)
        {
            var match = JsonConvert.DeserializeObject<Match>(input, JsonOptions);
            ArgumentNullException.ThrowIfNull(match);
            
            Assert.Equal(expectedValue, match.MatchType.Value);
        }
    }
}