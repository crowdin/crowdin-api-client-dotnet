
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<TaskStatus>? Statuses { get; set; }

        public long? AssigneeId { get; set; }
        
        public IEnumerable<SortingRule>? OrderBy { get; set; }

        public TasksListParams()
        {
            
        }

        public TasksListParams(
            int limit,
            int offset,
            TaskStatus? status,
            long? assigneeId,
            IEnumerable<SortingRule>? orderBy)
        {
            Limit = limit;
            Offset = offset;
            Statuses = status.HasValue ? new[] { status.Value } : null;
            AssigneeId = assigneeId;
            OrderBy = orderBy;
        }

        public TasksListParams(
            int limit,
            int offset,
            IEnumerable<TaskStatus>? statuses,
            long? assigneeId,
            IEnumerable<SortingRule>? orderBy)
        {
            Limit = limit;
            Offset = offset;
            Statuses = statuses;
            AssigneeId = assigneeId;
            OrderBy = orderBy;
        }

        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> queryParams =
                Utils.CreateQueryParamsFromPaging(Limit, Offset);

            if (Statuses != null && Statuses.Any())
            {
                queryParams.Add("status", string.Join(",", Statuses.Select(status => status.ToDescriptionString())));
            }
            
            queryParams.AddParamIfPresent("assigneeId", AssigneeId);
            queryParams.AddSortingRulesIfPresent(OrderBy);
            return queryParams;
        }
    }
}