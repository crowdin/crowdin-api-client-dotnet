
using System;
using Xunit;

namespace Crowdin.Api.UnitTesting
{
    public static class CommonResponsesAssertUtils
    {
        public static void Assert_DownloadLink(DownloadLink? downloadLink)
        {
            ArgumentNullException.ThrowIfNull(downloadLink);
            
            Assert.Equal("https://test.com", downloadLink.Url);
            Assert.Equal(DateTimeOffset.Parse("2019-09-20T10:31:21+00:00"), downloadLink.ExpireIn);
        }
    }
}