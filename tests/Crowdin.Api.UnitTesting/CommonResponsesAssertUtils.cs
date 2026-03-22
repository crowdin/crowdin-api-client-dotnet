
using System;
using Xunit;

namespace Crowdin.Api.UnitTesting
{
    public static class CommonResponsesAssertUtils
    {
        public static void Assert_DownloadLink(DownloadLink? expectedDownloadLink)
        {
            ArgumentNullException.ThrowIfNull(expectedDownloadLink);
            
            Assert.Equal("https://test.com", expectedDownloadLink.Url);
            Assert.Equal(DateTimeOffset.Parse("2019-09-20T10:31:21+00:00"), expectedDownloadLink.ExpireIn);
        }
    }
}