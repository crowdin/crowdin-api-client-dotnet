
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Crowdin.Api.Applications;
using Crowdin.Api.Bundles;
using Crowdin.Api.Core;
using Crowdin.Api.Core.Converters;
using Crowdin.Api.Core.RateLimiting;
using Crowdin.Api.Core.Resilience;
using Crowdin.Api.Dictionaries;
using Crowdin.Api.Distributions;
using Crowdin.Api.Fields;
using Crowdin.Api.Glossaries;
using Crowdin.Api.GraphQL;
using Crowdin.Api.Issues;
using Crowdin.Api.Labels;
using Crowdin.Api.Languages;
using Crowdin.Api.MachineTranslationEngines;
using Crowdin.Api.ProjectsGroups;
using Crowdin.Api.Reports;
using Crowdin.Api.Screenshots;
using Crowdin.Api.SecurityLogs;
using Crowdin.Api.SourceFiles;
using Crowdin.Api.SourceStrings;
using Crowdin.Api.Storage;
using Crowdin.Api.StringComments;
using Crowdin.Api.StringTranslations;
using Crowdin.Api.Tasks;
using Crowdin.Api.Teams;
using Crowdin.Api.TranslationMemory;
using Crowdin.Api.Translations;
using Crowdin.Api.TranslationStatus;
using Crowdin.Api.Users;
using Crowdin.Api.Vendors;
using Crowdin.Api.Webhooks;
using Crowdin.Api.Webhooks.Organization;
using Crowdin.Api.Workflows;

#nullable enable

namespace Crowdin.Api
{
    [PublicAPI]
    public class CrowdinApiClient : ICrowdinApiClient
    {
        public IBundlesApiExecutor Bundles { get; }
        
        public IDictionariesApiExecutor Dictionaries { get; }
        
        public IDistributionsApiExecutor Distributions { get; }
        
        public IGlossariesApiExecutor Glossaries { get; }
        
        public IIssuesApiExecutor Issues { get; }
        
        public ILabelsApiExecutor Labels { get; }
        
        public ILanguagesApiExecutor Languages { get; }
        
        public IMachineTranslationEnginesApiExecutor MachineTranslationEngines { get; }
        
        public IProjectsGroupsApiExecutor ProjectsGroups { get; }
        
        public IReportsApiExecutor Reports { get; }
        
        public IScreenshotsApiExecutor Screenshots { get; }
        
        public ISecurityLogsApiExecutor SecurityLogs { get; }
        
        public ISourceFilesApiExecutor SourceFiles { get; }
        
        public ISourceStringsApiExecutor SourceStrings { get; }
        
        public IStorageApiExecutor Storage { get; }
        
        public IStringCommentsApiExecutor StringComments { get; }
        
        public IStringTranslationsApiExecutor StringTranslations { get; }
        
        public ITasksApiExecutor Tasks { get; }
        
        public ITeamsApiExecutor Teams { get; }
        
        public ITranslationMemoryApiExecutor TranslationMemory { get; }
        
        public ITranslationsApiExecutor Translations { get; }
        
        public ITranslationStatusApiExecutor TranslationStatus { get; }
        
        public IUsersApiExecutor Users { get; }
        
        public IVendorsApiExecutor Vendors { get; }
        
        public IWebhooksApiExecutor Webhooks { get; }

        public IWorkflowsApiExecutor Workflows { get; }

        public IOrganizationWebhooksApiExecutor OrganizationWebhooks { get; }

        public IApplicationsApiExecutor Applications { get; }

        public IFieldsApiExecutor Fields { get; }
        
        public IGraphQLApiExecutor GraphQL { get; }

        private readonly string _baseUrl;
        private readonly string _graphBaseUrl;
        private readonly HttpClient _httpClient;
        private readonly IRateLimiter? _rateLimiter;
        private readonly IRetryService? _retryService;
        
        private static readonly MediaTypeHeaderValue DefaultContentType = MediaTypeHeaderValue.Parse("application/json");
        private static readonly JsonSerializerSettings DefaultJsonSerializerOptions = Utils.CreateJsonSerializerSettings();

        public IJsonParser DefaultJsonParser { get; }

        public CrowdinApiClient(
            CrowdinCredentials credentials,
            HttpClient? httpClient = null,
            IJsonParser? jsonParser = null,
            IRateLimiter? rateLimiter = null,
            IRetryService? retryService = null)
        {
            _httpClient = httpClient ?? new HttpClient();
            DefaultJsonParser = jsonParser ?? new JsonParser(DefaultJsonSerializerOptions);
            _rateLimiter = rateLimiter;
            _retryService = retryService;
            
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", credentials.AccessToken);
            
            // pass base url full
            if (!string.IsNullOrWhiteSpace(credentials.BaseUrl))
            {
                _baseUrl = credentials.BaseUrl!.TrimEnd('/');
                _graphBaseUrl = $"{_baseUrl}/graphql";
            }
            // pass org name -> from base url
            else if (!string.IsNullOrWhiteSpace(credentials.Organization))
            {
                _baseUrl = $"https://{credentials.Organization!}.api.crowdin.com/api/v2";
                _graphBaseUrl = $"https://{credentials.Organization!}.api.crowdin.com/api/graphql";
            }
            // || -> use regular url (no org, no baseurl passed)
            else
            {
                _baseUrl = "https://api.crowdin.com/api/v2";
                _graphBaseUrl = "https://api.crowdin.com/api/graphql";
            }

            Bundles = new BundlesApiExecutor(this);
            Dictionaries = new DictionariesApiExecutor(this);
            Distributions = new DistributionsApiExecutor(this);
            Glossaries = new GlossariesApiExecutor(this);
            Issues = new IssuesApiExecutor(this);
            Labels = new LabelsApiExecutor(this);
            Languages = new LanguagesApiExecutor(this);
            MachineTranslationEngines = new MachineTranslationEnginesApiExecutor(this);
            ProjectsGroups = new ProjectsGroupsApiExecutor(this);
            Reports = new ReportsApiExecutor(this);
            Screenshots = new ScreenshotsApiExecutor(this);
            SecurityLogs = new SecurityLogsApiExecutor(this);
            SourceFiles = new SourceFilesApiExecutor(this);
            SourceStrings = new SourceStringsApiExecutor(this);
            Storage = new StorageApiExecutor(this);
            StringComments = new StringCommentsApiExecutor(this);
            StringTranslations = new StringTranslationsApiExecutor(this);
            Tasks = new TasksApiExecutor(this);
            Teams = new TeamsApiExecutor(this);
            TranslationMemory = new TranslationMemoryApiExecutor(this);
            Translations = new TranslationsApiExecutor(this);
            TranslationStatus = new TranslationStatusApiExecutor(this);
            Users = new UsersApiExecutor(this);
            Vendors = new VendorsApiExecutor(this);
            Webhooks = new WebhooksApiExecutor(this);
            Workflows = new WorkflowsApiExecutor(this);
            OrganizationWebhooks = new OrganizationWebhooksApiExecutor(this);
            Applications = new ApplicationsApiExecutor(this);
            Fields = new FieldsApiExecutor(this);
            GraphQL = new GraphQLApiExecutor(this);
        }

        Task<CrowdinApiResult> ICrowdinApiClient.SendGetRequest(string subUrl, IDictionary<string, string>? queryParams)
        {
            Func<HttpRequestMessage> requestFn = () => new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(FormRequestUrl(subUrl, queryParams))
            };

            return SendRequest(requestFn);
        }

        Task<CrowdinApiResult> ICrowdinApiClient.SendPostRequest(
            string subUrl, object? body,
            IDictionary<string, string>? extraHeaders)
        {
            Func<HttpRequestMessage> requestFn = () =>
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(FormRequestUrl(subUrl))
                };

                request.Content = body != null ? CreateJsonContent(body) : CreateEmptyJsonContent();

                if (extraHeaders != null && extraHeaders.Count > 0)
                {
                    foreach (KeyValuePair<string, string> kvp in extraHeaders)
                    {
                        request.Headers.Add(kvp.Key, kvp.Value);
                    }
                }

                return request;
            };

            return SendRequest(requestFn);
        }

        Task<CrowdinApiResult> ICrowdinApiClient.SendPutRequest(string subUrl, object? body)
        {
            Func<HttpRequestMessage> requestFn = () =>
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri(FormRequestUrl(subUrl))
                };

                if (body != null)
                {
                    request.Content = CreateJsonContent(body);
                }

                return request;
            };
            
            return SendRequest(requestFn);
        }

        Task<CrowdinApiResult> ICrowdinApiClient.SendPatchRequest(
            string subUrl, IEnumerable<PatchEntry> body,
            IDictionary<string, string>? queryParams)
        {
            Func<HttpRequestMessage> requestFn = () => new HttpRequestMessage
            {
                Method = new HttpMethod("PATCH"),
                Content = CreateJsonContent(body),
                RequestUri = new Uri(FormRequestUrl(subUrl, queryParams))
            };

            return SendRequest(requestFn);
        }
        
        Task<CrowdinApiResult> ICrowdinApiClient.SendPatchRequest(
            string subUrl, object body,
            IDictionary<string, string>? queryParams)
        {
            Func<HttpRequestMessage> requestFn = () => new HttpRequestMessage
            {
                Method = new HttpMethod("PATCH"),
                Content = CreateJsonContent(body),
                RequestUri = new Uri(FormRequestUrl(subUrl, queryParams))
            };
            return SendRequest(requestFn);
        }

        async Task<HttpStatusCode> ICrowdinApiClient.SendDeleteRequest(string subUrl, IDictionary<string, string>? queryParams)
        {
            var result = await ((ICrowdinApiClient) this).SendDeleteRequest_FullResult(subUrl, queryParams);
            return result.StatusCode;
        }
        
        Task<CrowdinApiResult> ICrowdinApiClient.SendDeleteRequest_FullResult(string subUrl, IDictionary<string, string>? queryParams)
        {
            Func<HttpRequestMessage> requestFn = () => new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(FormRequestUrl(subUrl, queryParams))
            };

            return SendRequest(requestFn);
        }
        
        Task<CrowdinApiResult> ICrowdinApiClient.SendGraphQLRequest(GraphQLRequest body)
        {
            return SendRequest(() =>
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    Content = CreateJsonContent(body),
                    RequestUri = new Uri(_graphBaseUrl)
                };

                return request;
            });
        }

        Task<CrowdinApiResult> ICrowdinApiClient.UploadFile(string subUrl, string filename, Stream fileStream)
        {
            Func<HttpRequestMessage> requestFn = () =>
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    Content = new StreamContent(fileStream),
                    RequestUri = new Uri(FormRequestUrl(subUrl)),
                };

                request.Headers.Add("Crowdin-API-FileName", filename);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                return request;
            };
            

            return SendRequest(requestFn);
        }

        public static async Task<T[]> WithFetchAll<T>(
            Func<int, int, Task<ResponseList<T>>> runRequest,
            int? maxAmountOfItems = null,
            int amountPerRequest = 25)
        {
            int limit = maxAmountOfItems < amountPerRequest ? maxAmountOfItems.Value : amountPerRequest;
            
            var offset = 0;
            var outResultList = new List<T>();

            while (true)
            {
                ResponseList<T> response = await runRequest(limit, offset);
                outResultList.AddRange(response.Data);
                
                if (response.Data.Count < limit) break;
                
                offset += limit;
                
                if (maxAmountOfItems.HasValue)
                {
                    if (outResultList.Count == maxAmountOfItems.Value) break;
                    
                    if (maxAmountOfItems.Value - outResultList.Count < limit)
                    {
                        limit = maxAmountOfItems.Value - outResultList.Count;
                    }
                }
            }

            return outResultList.ToArray();
        }

        private async Task<CrowdinApiResult> SendRequest(Func<HttpRequestMessage> createRequestMessage)
        {
            Task<HttpResponseMessage> SendHttpRequest(int _ = default)
            {
                return _httpClient.SendAsync(createRequestMessage());
            }

            Task<HttpResponseMessage> SendRequestViaRateLimiterIfAvailable()
            {
                return _rateLimiter != null
                    ? _rateLimiter.ExecuteRequest(SendHttpRequest)
                    : SendHttpRequest();
            }
            
            var result = new CrowdinApiResult();

            HttpResponseMessage response = _retryService != null
                ? await _retryService.ExecuteRequestAsync(SendRequestViaRateLimiterIfAvailable)
                : await SendRequestViaRateLimiterIfAvailable();

            await CheckDefaultPreconditionsAndErrors(response);
            result.StatusCode = response.StatusCode;
            
            if (response.Content.Headers.ContentType.MediaType.Contains(DefaultContentType.MediaType))
            {
                result.JsonObject = await response.Content.ParseJsonBodyAsync();
            }

            result.Headers = response.Headers;
            return result;
        }

        private HttpContent CreateEmptyJsonContent()
        {
            MediaTypeHeaderValue contentType = DefaultContentType;

            return new StringContent("{}", Encoding.UTF8, contentType.MediaType);
        }

        private HttpContent CreateJsonContent(object body)
        {
            string bodyJson = JsonConvert.SerializeObject(body, DefaultJsonSerializerOptions);

            MediaTypeHeaderValue contentType = DefaultContentType;
            
            return new StringContent(bodyJson, Encoding.UTF8, contentType.MediaType);
        }

        private string FormRequestUrl(string relativeUrlPart)
        {
            return $"{_baseUrl}{relativeUrlPart}";
        }

        private string FormRequestUrl(string relativeUrlPart, IDictionary<string, string>? queryParams)
        {
            return queryParams is null
                ? FormRequestUrl(relativeUrlPart)
                : FormRequestUrl(relativeUrlPart) + '?' + queryParams.ToQueryString();
        }

        internal static async Task CheckDefaultPreconditionsAndErrors(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode) return;
            
            JObject doc = await response.Content.ParseJsonBodyAsync();

            if (response.StatusCode is HttpStatusCode.BadRequest)
            {
                ErrorResource[] errorResources = doc["errors"]!
                    .Select(subObject => JsonConvert.DeserializeObject<ErrorResource>(subObject["error"]!.ToString()))
                    .ToArray()!;

                var messageBuilder = new StringBuilder("Invalid Request Parameters: ");
                messageBuilder.Append($"Key [{errorResources[0].Key}]: {errorResources[0].Errors[0].Message}");

                if (errorResources.Length > 1 ||
                    errorResources[0].Errors.Length > 1)
                {
                    messageBuilder.Append(". More errors see in Related property");
                }

                throw new CrowdinApiException(messageBuilder.ToString(), errorResources);
            }
            
            JToken error = doc["error"]!;

            var code = error["code"]!.Value<int>();
            var message = error["message"]!.Value<string>();

            throw new CrowdinApiException(code, message ?? "Unknown error occurred");
        }
    }
}