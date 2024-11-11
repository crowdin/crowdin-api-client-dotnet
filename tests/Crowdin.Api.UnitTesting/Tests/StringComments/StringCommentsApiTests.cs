using Crowdin.Api.StringComments;
using Xunit;

namespace Crowdin.Api.UnitTesting.Tests.StringComments
{
    public class StringCommentsApiTests
    {
        [Fact]
        public void ListStringComments_QueryStringConstruction()
        {
            const string expectedQueryString = "limit=25&offset=0&stringId=123&type=comment&issueType=general_question,translation_mistake&issueStatus=resolved";

            var @params = new StringCommentsListParams
            {
                StringId = 123,
                Type = StringCommentType.Comment,
                IssueStatus = IssueStatus.Resolved
            };

            @params.IssueTypes.Add(IssueType.GeneralQuestion);
            @params.IssueTypes.Add(IssueType.TranslationMistake);

            Assert.Equal(expectedQueryString, @params.ToQueryParams().ToQueryString());
        }
    }
}