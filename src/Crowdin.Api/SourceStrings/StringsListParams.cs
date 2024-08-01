
using System.Collections.Generic;
using System.ComponentModel;
using Crowdin.Api.Core;
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.SourceStrings
{
    [PublicAPI]
    public class StringsListParams : IQueryParamsProvider
    {
        public int? DenormalizePlaceholders { get; set; }
        
        public string? LabelIds { get; set; }
        
        public int? FileId { get; set; }
        
        public int? BranchId { get; set; }
        
        public int? DirectoryId { get; set; }
        
        // ReSharper disable once InconsistentNaming
        public string? CroQL { get; set; }
        
        public string? Filter { get; set; }
        
        public StringScope? Scope { get; set; }
        
        public IEnumerable<SortingRule>? OrderBy { get; set; }

        public int Limit { get; set; } = 25;
        
        public int Offset { get; set; }

        public StringsListParams()
        {
            
        }

        public StringsListParams(
            int? denormalizePlaceholders,
            string? labelIds,
            int? fileId,
            int? branchId,
            int? directoryId,
            string? croql,
            string? filter,
            StringScope? scope,
            IEnumerable<SortingRule>? orderBy,
            int limit,
            int offset)
        {
            DenormalizePlaceholders = denormalizePlaceholders;
            LabelIds = labelIds;
            FileId = fileId;
            BranchId = branchId;
            DirectoryId = directoryId;
            CroQL = croql;
            Filter = filter;
            Scope = scope;
            OrderBy = orderBy;
            Limit = limit;
            Offset = offset;
        }

        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> queryParams =
                Utils.CreateQueryParamsFromPaging(Limit, Offset);
            
            queryParams.AddParamIfPresent("denormalizePlaceholders", DenormalizePlaceholders);
            queryParams.AddParamIfPresent("labelIds", LabelIds);
            queryParams.AddParamIfPresent("fileId", FileId);
            queryParams.AddParamIfPresent("branchId", BranchId);
            queryParams.AddParamIfPresent("directoryId", DirectoryId);
            queryParams.AddParamIfPresent("croql", CroQL);
            queryParams.AddParamIfPresent("filter", Filter);
            queryParams.AddDescriptionEnumValueIfPresent("scope", Scope);
            queryParams.AddSortingRulesIfPresent(OrderBy);

            return queryParams;
        }
    }

    [PublicAPI]
    public enum StringScope
    {
        [Description("identifier")]
        Identifier,
        
        [Description("text")]
        Text,
        
        [Description("context")]
        Context
    }
}