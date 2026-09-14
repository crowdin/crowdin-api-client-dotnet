#nullable enable

using System;
using System.Collections.Generic;

using JetBrains.Annotations;

using Crowdin.Api.Core;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiRequestLogsListParams : IQueryParamsProvider
    {
        public int Limit { get; set; } = 25;

        public int Offset { get; set; }

        public string? RequestId { get; set; }

        public long? ProjectId { get; set; }

        public long? UserId { get; set; }

        public long? AiProviderId { get; set; }

        public string? Model { get; set; }

        public AiRequestLogSourceAction? SourceAction { get; set; }

        public string? PromptAction { get; set; }

        public IEnumerable<AiRequestLogStatus>? Statuses { get; set; }

        public bool? SystemCredentials { get; set; }

        public bool? IsAutoTriggered { get; set; }

        public string? TokenName { get; set; }

        public string? OauthClientId { get; set; }

        public DateTimeOffset? CreatedAfter { get; set; }

        public DateTimeOffset? CreatedBefore { get; set; }

        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(Limit, Offset);

            queryParams.AddParamIfPresent("requestId", RequestId);
            queryParams.AddParamIfPresent("projectId", ProjectId);
            queryParams.AddParamIfPresent("userId", UserId);
            queryParams.AddParamIfPresent("aiProviderId", AiProviderId);
            queryParams.AddParamIfPresent("model", Model);
            queryParams.AddDescriptionEnumValueIfPresent("sourceAction", SourceAction);
            queryParams.AddParamIfPresent("promptAction", PromptAction);
            queryParams.AddDescriptionEnumValueCollectionIfPresent("statuses", Statuses);
            queryParams.AddParamIfPresent("systemCredentials", SystemCredentials);
            queryParams.AddParamIfPresent("isAutoTriggered", IsAutoTriggered);
            queryParams.AddParamIfPresent("tokenName", TokenName);
            queryParams.AddParamIfPresent("oauthClientId", OauthClientId);
            queryParams.AddParamIfPresent("createdAfter", CreatedAfter);
            queryParams.AddParamIfPresent("createdBefore", CreatedBefore);

            return queryParams;
        }
    }
}
