
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Crowdin.Api.Bundles;
using Crowdin.Api.Core;
using Crowdin.Api.Core.Converters;
using Crowdin.Api.Core.RateLimiting;
using Crowdin.Api.Core.Resilience;
using Crowdin.Api.Dictionaries;
using Crowdin.Api.Distributions;
using Crowdin.Api.Glossaries;
using Crowdin.Api.Issues;
using Crowdin.Api.Labels;
using Crowdin.Api.Languages;
using Crowdin.Api.MachineTranslationEngines;
using Crowdin.Api.ProjectsGroups;
using Crowdin.Api.Reports;
using Crowdin.Api.Screenshots;
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

using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

#nullable enable

namespace Crowdin.Api
{
    [PublicAPI]
    public class CrowdinApiClient : ICrowdinApiClient
    {
        public BundlesApiExecutor Bundles { get; }
        
        public DictionariesApiExecutor Dictionaries { get; }
        
        public DistributionsApiExecutor Distributions { get; }
        
        public GlossariesApiExecutor Glossaries { get; }
        
        public IssuesApiExecutor Issues { get; }
        
        public LabelsApiExecutor Labels { get; }
        
        public LanguagesApiExecutor Languages { get; }
        
        public MachineTranslationEnginesApiExecutor MachineTranslationEngines { get; }
        
        public ProjectsGroupsApiExecutor ProjectsGroups { get; }
        
        public ReportsApiExecutor Reports { get; }
        
        public ScreenshotsApiExecutor Screenshots { get; }
        
        public SourceFilesApiExecutor SourceFiles { get; }
        
        public SourceStringsApiExecutor SourceStrings { get; }
        
        public StorageApiExecutor Storage { get; }
        
        public StringCommentsApiExecutor StringComments { get; }
        
        public StringTranslationsApiExecutor StringTranslations { get; }
        
        public TasksApiExecutor Tasks { get; }
        
        public TeamsApiExecutor Teams { get; }
        
        public TranslationMemoryApiExecutor TranslationMemory { get; }
        
        public TranslationsApiExecutor Translations { get; }
        
        public TranslationStatusApiExecutor TranslationStatus { get; }
        
        public UsersApiExecutor Users { get; }
        
        public VendorsApiExecutor Vendors { get; }
        
        public WebhooksApiExecutor Webhooks { get; }

        private readonly string _baseUrl;
        private readonly string _accessToken;
        private readonly HttpClient _httpClient;
        private readonly IRateLimiter? _rateLimiter;
        private readonly IRetryService? _retryService;
        
        private static readonly MediaTypeHeaderValue DefaultContentType = MediaTypeHeaderValue.Parse("application/json");
        private static readonly JsonSerializerSettings DefaultJsonSerializerOptions =
            new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Converters =
                {
                    new DescriptionEnumConverter(),
                    new FileExportOptionsConverter(),
                    new FileImportOptionsConverter(),
                    new FileInfoConverter(),
                    new LanguageTranslationsConverter(),
                    new ToStringConverter(),
                    new ProjectFileFormatSettingsConverter(),
                    new ReportSettingsTemplateConverter(),
                    new WorkflowStepConverter()
                }
            };

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
            
            _accessToken = credentials.AccessToken;
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", credentials.AccessToken);
            
            // pass base url full
            if (!string.IsNullOrWhiteSpace(credentials.BaseUrl))
            {
                _baseUrl = credentials.BaseUrl!;
            }
            // pass org name -> from base url
            else if (!string.IsNullOrWhiteSpace(credentials.Organization))
            {
                _baseUrl = $"https://{credentials.Organization!}.api.crowdin.com/api/v2";
            }
            // || -> use regular url (no org, no baseurl passed)
            else
            {
                _baseUrl = "https://api.crowdin.com/api/v2";
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
        }

        public Task<CrowdinApiResult> SendGetRequest(string subUrl, IDictionary<string, string>? queryParams = null)
        {
            Func<HttpRequestMessage> requestFn = () => new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(FormRequestUrl(subUrl, queryParams))
            };

            return SendRequest(requestFn);
        }

        public Task<CrowdinApiResult> SendPostRequest(
            string subUrl, object? body = null,
            IDictionary<string, string>? extraHeaders = null)
        {
            Func<HttpRequestMessage> requestFn = () =>
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(FormRequestUrl(subUrl))
                };

                if (body != null)
                {
                    request.Content = CreateJsonContent(body);
                }

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

        public Task<CrowdinApiResult> SendPutRequest(string subUrl, object? body = null)
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

        public Task<CrowdinApiResult> SendPatchRequest(
            string subUrl, IEnumerable<PatchEntry> body,
            IDictionary<string, string>? queryParams = null)
        {
            Func<HttpRequestMessage> requestFn = () => new HttpRequestMessage
            {
                Method = new HttpMethod("PATCH"),
                Content = CreateJsonContent(body),
                RequestUri = new Uri(FormRequestUrl(subUrl, queryParams))
            };

            return SendRequest(requestFn);
        }

        public Task<HttpStatusCode> SendDeleteRequest(string subUrl, IDictionary<string, string>? queryParams = null)
        {
            return SendDeleteRequest_FullResult(subUrl, queryParams).ContinueWith(task => task.Result.StatusCode);
        }
        
        public Task<CrowdinApiResult> SendDeleteRequest_FullResult(string subUrl, IDictionary<string, string>? queryParams = null)
        {
            Func<HttpRequestMessage> requestFn = () => new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(FormRequestUrl(subUrl, queryParams))
            };

            return SendRequest(requestFn);
        }

        public Task<CrowdinApiResult> UploadFile(string subUrl, string filename, Stream fileStream)
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

        private static async Task CheckDefaultPreconditionsAndErrors(HttpResponseMessage response)
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