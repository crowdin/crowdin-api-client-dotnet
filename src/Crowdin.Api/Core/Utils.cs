
using System.Collections.Generic;
using System.Net;

#nullable enable

namespace Crowdin.Api.Core
{
    internal static class Utils
    {
        internal static IDictionary<string, string> CreateQueryParamsFromPaging(int limit, int offset)
        {
            return new Dictionary<string, string>
            {
                { "limit", limit.ToString() },
                { "offset", offset.ToString() }
            };
        }

        internal static void ThrowIfStatusNot204(HttpStatusCode statusCode, string message)
        {
            if (statusCode != HttpStatusCode.NoContent)
            {
                throw new CrowdinApiException(message);
            }
        }
    }
}