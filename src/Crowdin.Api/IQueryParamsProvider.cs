
using System.Collections.Generic;

namespace Crowdin.Api
{
    public interface IQueryParamsProvider
    {
        IDictionary<string, string> ToQueryParams();
    }
}