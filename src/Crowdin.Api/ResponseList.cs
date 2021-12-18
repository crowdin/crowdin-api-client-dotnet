
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Crowdin.Api
{
    [PublicAPI]
    public class ResponseList<TData>
    {
        public List<TData> Data { get; set; }
        
        public Pagination Pagination { get; set; }
    }
}