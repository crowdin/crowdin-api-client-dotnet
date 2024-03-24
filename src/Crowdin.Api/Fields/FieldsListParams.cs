using System.Collections.Generic;
using Crowdin.Api.Core;
using JetBrains.Annotations;

namespace Crowdin.Api.Fields
{
    [PublicAPI]
    public class FieldsListParams : IQueryParamsProvider
    {
        public int Limit { get; set; } = 25;

        public int Offset { get; set; }
        
        public string? Search { get; set; }
        
        public FieldEntity? Entity { get; set; }
        
        public FieldType? Type { get; set; }

        public FieldsListParams(int limit, int offset, string? search, FieldEntity? entity, FieldType? type)
        {
            Limit = limit;
            Offset = offset;
            Search = search;
            Entity = entity;
            Type = type;
        }

        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(Limit, Offset);
            
            queryParams.AddParamIfPresent("search", Search);
            //TODO: Entity and type might need some special handling, as toString() might not work for them. In that case see TasksListParams.cs for ref
            queryParams.AddParamIfPresent("entity", Entity);
            queryParams.AddParamIfPresent("type", Type);

            return queryParams;
        }
    }
}