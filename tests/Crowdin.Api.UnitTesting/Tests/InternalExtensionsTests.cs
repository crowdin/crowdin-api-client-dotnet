
using System.Collections.Generic;
using Crowdin.Api.Core;
using Moq;
using Xunit;

namespace Crowdin.Api.UnitTesting.Tests
{
    public class InternalExtensionsTests
    {
        [Fact]
        public void ToQueryString()
        {
            var queryParams = new Dictionary<string, string>
            {
                { "limit", "25" },
                { "offset", "0" }
            };

            var queryString = InternalExtensions.ToQueryString(queryParams);

            Assert.Equal("limit=25&offset=0", queryString);
        }

        [Fact]
        public void AddParamIfPresentInt()
        {
            var queryParams = new Dictionary<string, string>();

            queryParams.AddParamIfPresent("param", 1);
            queryParams.AddParamIfPresent("other", (int?)null);

            Assert.Single(queryParams.Keys);
            Assert.True(queryParams.TryGetValue("param", out string? value));
            Assert.Equal("1", value);
        }

        [Fact]
        public void AddParamIfPresentLong()
        {
            var queryParams = new Dictionary<string, string>();

            queryParams.AddParamIfPresent("param", 1L);
            queryParams.AddParamIfPresent("other", (long?)null);

            Assert.Single(queryParams.Keys);
            Assert.True(queryParams.TryGetValue("param", out string? value));
            Assert.Equal("1", value);
        }

        [Fact]
        public void AddParamIfPresentBool()
        {
            var queryParams = new Dictionary<string, string>();

            queryParams.AddParamIfPresent("param", true);
            queryParams.AddParamIfPresent("other", (bool?)null);

            Assert.Single(queryParams.Keys);
            Assert.True(queryParams.TryGetValue("param", out string? value));
            Assert.Equal("true", value);
        }

        [Fact]
        public void AddParamIfPresentObject()
        {
            Mock<object> mockObject = new Mock<object>();
            mockObject.Setup(o => o.ToString()).Returns("test");

            var queryParams = new Dictionary<string, string>();

            queryParams.AddParamIfPresent("param", mockObject.Object);
            queryParams.AddParamIfPresent("other", null as object);

            Assert.Single(queryParams.Keys);
            Assert.True(queryParams.TryGetValue("param", out string? value));
            Assert.Equal("test", value);
        }

        [Fact]
        public void AddParamIfPresentString()
        {
            var queryParams = new Dictionary<string, string>();

            queryParams.AddParamIfPresent("param", "test");
            queryParams.AddParamIfPresent("other1", null as string);
            queryParams.AddParamIfPresent("other2", "");
            queryParams.AddParamIfPresent("other3", " ");

            Assert.Single(queryParams.Keys);
            Assert.True(queryParams.TryGetValue("param", out string? value));
            Assert.Equal("test", value);
        }

        [Fact]
        public void AddParamListIfPresentInt()
        {
            var queryParams = new Dictionary<string, string>();

            queryParams.AddParamIfPresent("param", new int[] { 1, 2, 3 });
            queryParams.AddParamIfPresent("other1", new int[] { });
            queryParams.AddParamIfPresent("other2", null as int[]);

            Assert.Single(queryParams.Keys);
            Assert.True(queryParams.TryGetValue("param", out string? value));
            Assert.Equal("1,2,3", value);
        }

        [Fact]
        public void AddParamListIfPresentLong()
        {
            var queryParams = new Dictionary<string, string>();

            queryParams.AddParamIfPresent("param", new long[] { 1, 2, 3 });
            queryParams.AddParamIfPresent("other1", new long[] { });
            queryParams.AddParamIfPresent("other2", null as long[]);

            Assert.Single(queryParams.Keys);
            Assert.True(queryParams.TryGetValue("param", out string? value));
            Assert.Equal("1,2,3", value);
        }

        [Fact]
        public void AddParamListIfPresentBool()
        {
            var queryParams = new Dictionary<string, string>();

            queryParams.AddParamIfPresent("param", new bool[] { true, false, true });
            queryParams.AddParamIfPresent("other1", new bool[] { });
            queryParams.AddParamIfPresent("other2", null as bool[]);

            Assert.Single(queryParams.Keys);
            Assert.True(queryParams.TryGetValue("param", out string? value));
            Assert.Equal("true,false,true", value);
        }

        [Fact]
        public void AddParamListIfPresentObject()
        {
            Mock<object> mockObject1 = new Mock<object>();
            Mock<object> mockObject2 = new Mock<object>();
            Mock<object> mockObject3 = new Mock<object>();

            mockObject1.Setup(o => o.ToString()).Returns("test1");
            mockObject2.Setup(o => o.ToString()).Returns("test2");
            mockObject3.Setup(o => o.ToString()).Returns("test3");

            var queryParams = new Dictionary<string, string>();

            queryParams.AddParamIfPresent("param", new object[] {
                mockObject1.Object,
                mockObject2.Object,
                mockObject3.Object
            });
            queryParams.AddParamIfPresent("other1", new object[] { });
            queryParams.AddParamIfPresent("other2", null as object[]);

            Assert.Single(queryParams.Keys);
            Assert.True(queryParams.TryGetValue("param", out string? value));
            Assert.Equal("test1,test2,test3", value);
        }

        [Fact]
        public void AddParamListIfPresentString()
        {
            var queryParams = new Dictionary<string, string>();

            queryParams.AddParamIfPresent("param", new string[] { "test1", "test2", "test3" });
            queryParams.AddParamIfPresent("other1", new string[] { });
            queryParams.AddParamIfPresent("other2", null as string[]);

            Assert.Single(queryParams.Keys);
            Assert.True(queryParams.TryGetValue("param", out string? value));
            Assert.Equal("test1,test2,test3", value);
        }

        [Fact]
        public void AddSortingRulesIfPresent()
        {
            var sortingRules1 = new SortingRule[]
            {
                new SortingRule() { Field = "createdAt", Order = SortingOrder.Descending },
                new SortingRule() { Field = "name", Order = SortingOrder.Ascending },
            };

            var sortingRules2 = new SortingRule[] { };
            var sortingRules3 = null as SortingRule[];

            var queryParams = new Dictionary<string, string>();

            queryParams.AddSortingRulesIfPresent(sortingRules1);
            queryParams.AddSortingRulesIfPresent(sortingRules2);
            queryParams.AddSortingRulesIfPresent(sortingRules3);

            Assert.Single(queryParams.Keys);
            Assert.True(queryParams.TryGetValue("orderBy", out string? value));
            Assert.Equal("createdAt desc,name asc", value);
        }
    }
}