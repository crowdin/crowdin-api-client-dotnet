
using System.Collections.Generic;
using Crowdin.Api.Core;
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.SourceFiles
{
    [PublicAPI]
    public class FilesListParams : IQueryParamsProvider
    {
        public int? BranchId { get; set; }
        
        public int? DirectoryId { get; set; }
        
        public string? Filter { get; set; }
        
        public object? Recursion { get; set; }

        public int Limit { get; set; } = 25;

        public int Offset { get; set; } = 0;

        public FilesListParams()
        {
            
        }

        public FilesListParams(
            int? branchId,
            int? directoryId,
            string? filter,
            object? recursion,
            int limit,
            int offset)
        {
            BranchId = branchId;
            DirectoryId = directoryId;
            Filter = filter;
            Recursion = recursion;
            Limit = limit;
            Offset = offset;
        }

        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> queryParams =
                Utils.CreateQueryParamsFromPaging(Limit, Offset);
            
            queryParams.AddParamIfPresent("branchId", BranchId);
            queryParams.AddParamIfPresent("directoryId", DirectoryId);
            queryParams.AddParamIfPresent("filter", Filter);
            queryParams.AddParamIfPresent("recursion", Recursion);

            return queryParams;
        }
    }
}