
using Crowdin.Api.SourceStrings;
using Crowdin.Api.Tests.Core;
using Xunit;

namespace Crowdin.Api.Tests.SourceStrings
{
    public class SourceStringsApiTests
    {
        [Fact]
        public void ListStrings_QueryStringConstruction()
        {
            const string expectedQueryString = "limit=25&offset=0&scope=context";

            var @params = new StringsListParams
            {
                Scope = StringScope.Context
            };
            
            Assert.Equal(expectedQueryString, @params.ToQueryParams().ToQueryString());
        }
    }
}