#nullable enable

using System.Collections.Generic;
using System.Linq;
using Crowdin.Api.Core;
using JetBrains.Annotations;

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public class OrganizationTasksListParams : IQueryParamsProvider
    {
        public IEnumerable<SortingRule>? OrderBy { get; set; }

        public int Limit { get; set; } = 25;

        public int Offset { get; set; }

        public IEnumerable<TaskStatus>? Statuses { get; set; }

        public IEnumerable<TaskType>? Types { get; set; }

        public IEnumerable<long>? ProjectIds { get; set; }

        public IEnumerable<long>? GroupIds { get; set; }

        public IEnumerable<long>? AssigneeIds { get; set; }

        public IEnumerable<long>? CreatorIds { get; set; }

        public IEnumerable<string>? TargetLanguageIds { get; set; }

        public IEnumerable<string>? SourceLanguageIds { get; set; }

        public string? CreatedAtFrom { get; set; }

        public string? CreatedAtTo { get; set; }

        public string? DeadlineFrom { get; set; }

        public string? DeadlineTo { get; set; }

        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> query = Utils.CreateQueryParamsFromPaging(Limit, Offset);
            query.AddSortingRulesIfPresent(OrderBy);
            if (Statuses != null && Statuses.Any())
                query.Add("status", string.Join(",", Statuses.Select(status => status.ToDescriptionString())));
            if (Types != null && Types.Any())
                query.Add("type", string.Join(",", Types.Select(type => ((int)type).ToString())));
            query.AddParamIfPresent("projectIds", ProjectIds);
            query.AddParamIfPresent("groupIds", GroupIds);
            query.AddParamIfPresent("assigneeIds", AssigneeIds);
            query.AddParamIfPresent("creatorIds", CreatorIds);
            query.AddParamIfPresent("targetLanguageIds", TargetLanguageIds);
            query.AddParamIfPresent("sourceLanguageIds", SourceLanguageIds);
            query.AddParamIfPresent("createdAtFrom", CreatedAtFrom);
            query.AddParamIfPresent("createdAtTo", CreatedAtTo);
            query.AddParamIfPresent("deadlineFrom", DeadlineFrom);
            query.AddParamIfPresent("deadlineTo", DeadlineTo);
            return query;
        }
    }
}
