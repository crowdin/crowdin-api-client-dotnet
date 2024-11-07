
using System.Collections.Generic;
using Crowdin.Api.Core;
using Xunit;

namespace Crowdin.Api.UnitTesting.Tests
{
    public class SortingTests
    {
        [Fact]
        public void Test()
        {
            const string expectedQueryString = "orderBy=createdAt desc,name,priority asc,title desc";

            var sortingParams = new[]
            {
                new SortingRule
                {
                    Field = "createdAt",
                    Order = SortingOrder.Descending
                },
                new SortingRule
                {
                    Field = "name"
                },
                new SortingRule
                {
                    Field = "priority",
                    Order = SortingOrder.Ascending
                },
                new SortingRule
                {
                    Field = "title",
                    Order = SortingOrder.Descending
                }
            };

            var queryParams = new Dictionary<string, string>();
            queryParams.AddSortingRulesIfPresent(sortingParams);

            string actualQueryString = queryParams.ToQueryString();
            Assert.Equal(expectedQueryString, actualQueryString);
        }
    }
}