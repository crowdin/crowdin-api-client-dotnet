
using System.Collections.Generic;
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api
{
    [PublicAPI]
    public class ResponseList<TData>
    {
        public List<TData> Data { get; set; } = new List<TData>();
        
        public Pagination? Pagination { get; set; }
    }
}