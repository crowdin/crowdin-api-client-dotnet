
using System.Collections.Generic;
using Crowdin.Api.Core;
using JetBrains.Annotations;

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public class UserTasksListParams : IQueryParamsProvider
    {
        public int Limit { get; set; } = 25;
        
        public int Offset { get; set; }
        
        public TaskStatus? Status { get; set; }
        
        public bool? IsArchived { get; set; }

        public UserTasksListParams()
        {
            
        }

        public UserTasksListParams(int limit, int offset, TaskStatus? status, bool? isArchived)
        {
            Limit = limit;
            Offset = offset;
            Status = status;
            IsArchived = isArchived;
        }

        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> queryParams =
                Utils.CreateQueryParamsFromPaging(Limit, Offset);

            if (Status.HasValue)
            {
                queryParams.Add("status", Status.Value.ToDescriptionString());
            }

            if (IsArchived.HasValue)
            {
                queryParams.Add("isArchived", IsArchived.Value ? "1" : "0");
            }

            return queryParams;
        }
    }
}