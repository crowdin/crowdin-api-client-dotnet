
using System.Collections.Generic;
using Crowdin.Api.Core;
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.SourceFiles
{
    [PublicAPI]
    public class FilesListParams : IQueryParamsProvider
    {
        public long? BranchId { get; set; }
        
        public long? DirectoryId { get; set; }
        
        public string? Filter { get; set; }
        
        public object? Recursion { get; set; }

        public int Limit { get; set; } = 25;

        public int Offset { get; set; } = 0;
        
        public IEnumerable<SortingRule>? OrderBy { get; set; }

        public FilesListParams()
        {
            
        }

        public FilesListParams(
            long? branchId,
            long? directoryId,
            string? filter,
            object? recursion,
            int limit,
            int offset,
            IEnumerable<SortingRule>? orderBy = null)
        {
            BranchId = branchId;
            DirectoryId = directoryId;
            Filter = filter;
            Recursion = recursion;
            Limit = limit;
            Offset = offset;
            OrderBy = orderBy;
        }

        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> queryParams =
                Utils.CreateQueryParamsFromPaging(Limit, Offset);
            
            queryParams.AddParamIfPresent("branchId", BranchId);
            queryParams.AddParamIfPresent("directoryId", DirectoryId);
            queryParams.AddParamIfPresent("filter", Filter);
            queryParams.AddParamIfPresent("recursion", Recursion);
            queryParams.AddSortingRulesIfPresent(OrderBy);

            return queryParams;
        }
    }
}