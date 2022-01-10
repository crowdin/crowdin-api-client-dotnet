
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using Crowdin.Api.Core.Converters;
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
        
        public TranslationStatusApiExecutor TranslationStatus { get; set; }
        
        public UsersApiExecutor Users { get; }
        
        public VendorsApiExecutor Vendors { get; }
        
        public WebhooksApiExecutor Webhooks { get; }

        private readonly string _baseUrl;
        private readonly string _accessToken;
        private readonly HttpClient _httpClient = new HttpClient();
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
                    new ToStringConverter()
                }
            };

        public IJsonParser DefaultJsonParser { get; } = new JsonParser(DefaultJsonSerializerOptions);

        public CrowdinApiClient(CrowdinCredentials credentials)
        {
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

        public CrowdinApiClient(CrowdinCredentials credentials, IJsonParser defaultJsonParser)
            : this(credentials)
        {
            DefaultJsonParser = defaultJsonParser;
        }

        public Task<CrowdinApiResult> SendGetRequest(string subUrl, IDictionary<string, string>? queryParams = null)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(FormRequestUrl(subUrl, queryParams))
            };

            return SendRequest(request);
        }

        public Task<CrowdinApiResult> SendPostRequest(
            string subUrl, object? body = null,
            IDictionary<string, string>? extraHeaders = null)
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

            return SendRequest(request);
        }

        public Task<CrowdinApiResult> SendPutRequest(string subUrl, object? body = null)
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

            return SendRequest(request);
        }

        public Task<CrowdinApiResult> SendPatchRequest(
            string subUrl, IEnumerable<PatchEntry> body,
            IDictionary<string, string>? queryParams = null)
        {
            var request = new HttpRequestMessage
            {
                Method = new HttpMethod("PATCH"),
                Content = CreateJsonContent(body, true),
                RequestUri = new Uri(FormRequestUrl(subUrl, queryParams))
            };

            return SendRequest(request);
        }

        public Task<HttpStatusCode> SendDeleteRequest(string subUrl, IDictionary<string, string>? queryParams = null)
        {
            return SendDeleteRequest_FullResult(subUrl, queryParams).ContinueWith(task => task.Result.StatusCode);
        }
        
        public Task<CrowdinApiResult> SendDeleteRequest_FullResult(string subUrl, IDictionary<string, string>? queryParams = null)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(FormRequestUrl(subUrl, queryParams))
            };

            return SendRequest(request);
        }

        public Task<CrowdinApiResult> UploadFile(string subUrl, string filename, Stream fileStream)
        {
            using Stream stream = fileStream;

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                Content = new StreamContent(stream),
                RequestUri = new Uri(FormRequestUrl(subUrl)),
            };
            request.Headers.Add("Crowdin-API-FileName", filename);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            return SendRequest(request);
        }

        private async Task<CrowdinApiResult> SendRequest(HttpRequestMessage request)
        {
            var result = new CrowdinApiResult();
            
            HttpResponseMessage response = await _httpClient.SendAsync(request);
            await CheckDefaultPreconditionsAndErrors(response);
            result.StatusCode = response.StatusCode;
            
            if (response.Content.Headers.ContentType.Equals(DefaultContentType))
            {
                result.JsonObject = await response.Content.ParseJsonBodyAsync();
            }

            result.Headers = response.Headers;
            return result;
        }

        private HttpContent CreateJsonContent(object body, bool isPatch = false)
        {
            string bodyJson = JsonConvert.SerializeObject(body, DefaultJsonSerializerOptions);

            MediaTypeHeaderValue contentType = isPatch
                ? MediaTypeHeaderValue.Parse("application/json-patch+json")
                : DefaultContentType;
            
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
                ErrorResource[]? errorResources =
                    JsonConvert.DeserializeObject<ErrorResource[]>(doc["errors"]!.ToString());

                throw new CrowdinApiException("Invalid Request Parameters", errorResources);
            }
            
            JToken error = doc["error"]!;

            var code = error["code"]!.Value<int>();
            var message = error["message"]!.Value<string>();

            throw new CrowdinApiException(code, message ?? "Unknown error occurred");
        }
    }
}