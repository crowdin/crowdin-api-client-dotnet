
using System.Collections.Generic;
using Crowdin.Api.Core;
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public class TasksListParams : IQueryParamsProvider
    {
        public int Limit { get; set; } = 25;
        
        public int Offset { get; set; }
        
        public TaskStatus? Status { get; set; }
        
        public int? AssigneeId { get; set; }
        
        public IEnumerable<SortingRule>? OrderBy { get; set; }

        public TasksListParams()
        {
            
        }

        public TasksListParams(
            int limit,
            int offset,
            TaskStatus? status,
            int? assigneeId,
            IEnumerable<SortingRule>? orderBy)
        {
            Limit = limit;
            Offset = offset;
            Status = status;
            AssigneeId = assigneeId;
            OrderBy = orderBy;
        }

        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> queryParams =
                Utils.CreateQueryParamsFromPaging(Limit, Offset);

            if (Status.HasValue)
            {
                queryParams.Add("status", Status.Value.ToDescriptionString());
            }
            
            queryParams.AddParamIfPresent("assigneeId", AssigneeId);
            queryParams.AddSortingRulesIfPresent(OrderBy);
            return queryParams;
        }
    }
}