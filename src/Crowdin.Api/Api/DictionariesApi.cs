/*
 * Crowdin API v2
 *
 *  # Introduction Welcome to Crowdin API v2 documentation.  Our API is a full-featured RESTful API that helps you to integrate localization into your development process. The endpoints that we use allow you to easily make calls to retrieve information and to execute actions needed.  Most of the functionality of Crowdin is available through the API. It allows you to create projects for translations, add and update files, download translations, and much more. In this way, you can script the complex actions that your situation requires.  Documentation starts with a general overview of the design and technology that was implemented and is followed by detailed information on specific methods and endpoints.  ## Asynchronous Operations Methods such as report generation, project build, and file download need some time to be completed and are finalized in several steps. It is what we call asynchronous operations. This  approach allows the application to work without interruptions while the method is running at the background.  To run asynchronous operations, 3 subsequent API methods are used:  *     Method to start operation – returns the status __Found__ if the resource you’re requesting is already generated. Typically, __201 Accepted__ status is returned along with the operation identifier. The operation status is then checked with the help of this identifier.  *     Method to check the status of operation – returns  the completion percentage.  *     Method to get the temporary link for resource download – mostly used for export operations. When the operation is completed, you can run this method to get a temporary link for resource download.  __Note:__ Download link is active for a few minutes.  For example, to download a Translation Memory (TM), you need to run following sequence of API methods:  *     [_Export TM_](#operation/api.tms.exports.post)  *     [_Check TM Export Status_](#operation/api.tms.exports.get)  *     [_Download TM_](#operation/api.tms.exports.getMany)  ## File Upload With Crowdin API v2 all files such as files for localization, screenshots, Glossaries, and Translation Memories should be first uploaded to the [Storage](#tag/Storage). After you upload file to the Storage it will have a unique storage id using which you can then add the file to the project.  For example, to upload a localization file to your project, you need to run the following sequence of API methods:  *     [_Add Storage_](#operation/api.storages.post) – upload localization file body to storage at Crowdin server  *     [_Add File_](#operation/api.projects.files.post) – define where to add the localization file with specific _storage id_  ## Authorization To work with Crowdin API v2 generate the personal access token by going to __Crowdin Account Settings > API & SSO > New Token__  Make sure to use the following __header__ in your requests:  `Authorization: Bearer ACCESS_TOKEN`  Responses in case authorization fail:  __401 Unauthorized__ ``` {   \"error\": {     \"message\": \"Unauthorized\",     \"code\": 401   } } ```  __403 Forbidden__ ``` {   \"error\": {     \"message\": \"Not allowed endpoint for token scopes\",     \"code\": 403   } } ``` ``` {   \"error\": {     \"message\": \"Not allowed space for your token\",     \"code\": 403   } } ```  ## Requests All requests should be made using the HTTPS protocol so that traffic is encrypted. The interface responds to different methods depending on the action required.  When a request is successful, a response will typically be sent back in the form of a JSON object. If you specify `Accept` header response will be `application/json`. It’s not required to specify `Accept` header so you can leave it empty.  The API expects all writing requests (_POST_, _PUT_, _PATCH_) in JSON format with the `Content-Type: application/json` header. This ensures that your request is interpreted correctly.  __Note:__ `Content-Type` header can be different (e.g. `image/jpeg`, `text/csv`) if you upload the file using _POST_ methods with a specified content type.  RESTful APIs enable you to call individual API endpoints to perform the following requests:  *     <span class='http-method method-list get'>GET</span> - for simple retrieval of information about source files, translations, or projects. The information you request will be returned to you as a JSON object. The attributes defined by the JSON object can be used to form additional requests.  *     <span class='http-method method-list post'>POST</span> - to create or add a new element. This request includes all of the attributes necessary to create a new object.  *     <span class='http-method method-list put'>PUT</span> - to update or replace the specific element. This request sets the state of the target using the provided values, regardless of their current values.  *     <span class='http-method method-list patch'>PATCH</span> - to edit some specific fields of an entity. With these requests, you only need to provide the data you want to change.  *     <span class='http-method method-list delete'>DELETE</span> - to remove element from your account. Request works if specified object is found. If it is not found, the operation will return a response indicating that the object was not found.  For example, to edit the name and description of a project, where the requested resource is the project with `id` = 1, the request is the following:  __Example Endpoint__ <div class='well well-sm'> <span class='http-method patch'>PATCH</span> https://api.crowdin.com/api/v2/<span class='api-section-block-highlighted'>projects/1</span> </div>  where <span class='api-section-block-highlighted'>projects/1</span> is the requested resource.  __Content-Type header:__ `application/json`  __Request body__ ``` [   {\"op\":\"replace\", \"path\":\"/name\", \"value\":\"Project new name\"},   {\"op\":\"replace\", \"path\":\"/description\", \"value\":\"New description for the project\"} ] ```  ## Rate Limits The number of simultaneous API requests per account is 20 requests. Response code __429 Too Many Requests__ is returned when the limit is exceeded.  ## Crowdin API Clients The Crowdin API clients are the lightweight interfaces developed for the Crowdin API v2. They provide common services for making API requests.  You may find detailed information on each client in its respective GitHub repository:  [_Crowdin JavaScript client_](https://github.com/crowdin/crowdin-api-client-js)\\ [_Crowdin PHP client_](https://github.com/crowdin/crowdin-api-client-php)\\ [_Crowdin Java client_](https://github.com/crowdin/crowdin-api-client-java)\\ [_Crowdin Python client_](https://github.com/crowdin/crowdin-api-client-python)\\ _Crowdin .NET client_ _(Coming soon)_  
 *
 * The version of the OpenAPI document: 2.0
 * Contact: support@crowdin.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using Crowdin.Api.Client;
using Crowdin.Api.Model;

namespace Crowdin.Api.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDictionariesApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// List Dictionaries
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageIds">Filter progress by Language Identifiers. Get via [List Supported Languages](#operation/api.languages.getMany) (optional)</param>
        /// <returns>DictionaryCollectionResource</returns>
        DictionaryCollectionResource ApiProjectsDictionariesGetMany(int projectId, string languageIds = default(string));

        /// <summary>
        /// List Dictionaries
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageIds">Filter progress by Language Identifiers. Get via [List Supported Languages](#operation/api.languages.getMany) (optional)</param>
        /// <returns>ApiResponse of DictionaryCollectionResource</returns>
        ApiResponse<DictionaryCollectionResource> ApiProjectsDictionariesGetManyWithHttpInfo(int projectId, string languageIds = default(string));
        /// <summary>
        /// Edit Dictionary
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany)</param>
        /// <param name="dictionaryOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>DictionaryResource</returns>
        DictionaryResource ApiProjectsDictionariesPatch(int projectId, string languageId, List<DictionaryOperation> dictionaryOperation = default(List<DictionaryOperation>));

        /// <summary>
        /// Edit Dictionary
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany)</param>
        /// <param name="dictionaryOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>ApiResponse of DictionaryResource</returns>
        ApiResponse<DictionaryResource> ApiProjectsDictionariesPatchWithHttpInfo(int projectId, string languageId, List<DictionaryOperation> dictionaryOperation = default(List<DictionaryOperation>));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDictionariesApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// List Dictionaries
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageIds">Filter progress by Language Identifiers. Get via [List Supported Languages](#operation/api.languages.getMany) (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DictionaryCollectionResource</returns>
        System.Threading.Tasks.Task<DictionaryCollectionResource> ApiProjectsDictionariesGetManyAsync(int projectId, string languageIds = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List Dictionaries
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageIds">Filter progress by Language Identifiers. Get via [List Supported Languages](#operation/api.languages.getMany) (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DictionaryCollectionResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<DictionaryCollectionResource>> ApiProjectsDictionariesGetManyWithHttpInfoAsync(int projectId, string languageIds = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Edit Dictionary
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany)</param>
        /// <param name="dictionaryOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DictionaryResource</returns>
        System.Threading.Tasks.Task<DictionaryResource> ApiProjectsDictionariesPatchAsync(int projectId, string languageId, List<DictionaryOperation> dictionaryOperation = default(List<DictionaryOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Edit Dictionary
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany)</param>
        /// <param name="dictionaryOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DictionaryResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<DictionaryResource>> ApiProjectsDictionariesPatchWithHttpInfoAsync(int projectId, string languageId, List<DictionaryOperation> dictionaryOperation = default(List<DictionaryOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDictionariesApi : IDictionariesApiSync, IDictionariesApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class DictionariesApi : IDictionariesApi
    {
        private Crowdin.Api.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="DictionariesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DictionariesApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DictionariesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DictionariesApi(string basePath)
        {
            this.Configuration = Crowdin.Api.Client.Configuration.MergeConfigurations(
                Crowdin.Api.Client.GlobalConfiguration.Instance,
                new Crowdin.Api.Client.Configuration { BasePath = basePath }
            );
            this.Client = new Crowdin.Api.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Crowdin.Api.Client.ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = Crowdin.Api.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DictionariesApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public DictionariesApi(Crowdin.Api.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = Crowdin.Api.Client.Configuration.MergeConfigurations(
                Crowdin.Api.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.Client = new Crowdin.Api.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Crowdin.Api.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = Crowdin.Api.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DictionariesApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public DictionariesApi(Crowdin.Api.Client.ISynchronousClient client, Crowdin.Api.Client.IAsynchronousClient asyncClient, Crowdin.Api.Client.IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = Crowdin.Api.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public Crowdin.Api.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public Crowdin.Api.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Crowdin.Api.Client.IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public Crowdin.Api.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// List Dictionaries 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageIds">Filter progress by Language Identifiers. Get via [List Supported Languages](#operation/api.languages.getMany) (optional)</param>
        /// <returns>DictionaryCollectionResource</returns>
        public DictionaryCollectionResource ApiProjectsDictionariesGetMany(int projectId, string languageIds = default(string))
        {
            Crowdin.Api.Client.ApiResponse<DictionaryCollectionResource> localVarResponse = ApiProjectsDictionariesGetManyWithHttpInfo(projectId, languageIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Dictionaries 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageIds">Filter progress by Language Identifiers. Get via [List Supported Languages](#operation/api.languages.getMany) (optional)</param>
        /// <returns>ApiResponse of DictionaryCollectionResource</returns>
        public Crowdin.Api.Client.ApiResponse<DictionaryCollectionResource> ApiProjectsDictionariesGetManyWithHttpInfo(int projectId, string languageIds = default(string))
        {
            Crowdin.Api.Client.RequestOptions localVarRequestOptions = new Crowdin.Api.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Crowdin.Api.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Crowdin.Api.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("projectId", Crowdin.Api.Client.ClientUtils.ParameterToString(projectId)); // path parameter
            if (languageIds != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "languageIds", languageIds));
            }


            // make the HTTP request
            var localVarResponse = this.Client.Get<DictionaryCollectionResource>("/projects/{projectId}/dictionaries", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsDictionariesGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Dictionaries 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageIds">Filter progress by Language Identifiers. Get via [List Supported Languages](#operation/api.languages.getMany) (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DictionaryCollectionResource</returns>
        public async System.Threading.Tasks.Task<DictionaryCollectionResource> ApiProjectsDictionariesGetManyAsync(int projectId, string languageIds = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<DictionaryCollectionResource> localVarResponse = await ApiProjectsDictionariesGetManyWithHttpInfoAsync(projectId, languageIds, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Dictionaries 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageIds">Filter progress by Language Identifiers. Get via [List Supported Languages](#operation/api.languages.getMany) (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DictionaryCollectionResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<DictionaryCollectionResource>> ApiProjectsDictionariesGetManyWithHttpInfoAsync(int projectId, string languageIds = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            Crowdin.Api.Client.RequestOptions localVarRequestOptions = new Crowdin.Api.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };


            var localVarContentType = Crowdin.Api.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Crowdin.Api.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("projectId", Crowdin.Api.Client.ClientUtils.ParameterToString(projectId)); // path parameter
            if (languageIds != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "languageIds", languageIds));
            }


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<DictionaryCollectionResource>("/projects/{projectId}/dictionaries", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsDictionariesGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Edit Dictionary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany)</param>
        /// <param name="dictionaryOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>DictionaryResource</returns>
        public DictionaryResource ApiProjectsDictionariesPatch(int projectId, string languageId, List<DictionaryOperation> dictionaryOperation = default(List<DictionaryOperation>))
        {
            Crowdin.Api.Client.ApiResponse<DictionaryResource> localVarResponse = ApiProjectsDictionariesPatchWithHttpInfo(projectId, languageId, dictionaryOperation);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Edit Dictionary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany)</param>
        /// <param name="dictionaryOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>ApiResponse of DictionaryResource</returns>
        public Crowdin.Api.Client.ApiResponse<DictionaryResource> ApiProjectsDictionariesPatchWithHttpInfo(int projectId, string languageId, List<DictionaryOperation> dictionaryOperation = default(List<DictionaryOperation>))
        {
            // verify the required parameter 'languageId' is set
            if (languageId == null)
                throw new Crowdin.Api.Client.ApiException(400, "Missing required parameter 'languageId' when calling DictionariesApi->ApiProjectsDictionariesPatch");

            Crowdin.Api.Client.RequestOptions localVarRequestOptions = new Crowdin.Api.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Crowdin.Api.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Crowdin.Api.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("projectId", Crowdin.Api.Client.ClientUtils.ParameterToString(projectId)); // path parameter
            localVarRequestOptions.PathParameters.Add("languageId", Crowdin.Api.Client.ClientUtils.ParameterToString(languageId)); // path parameter
            localVarRequestOptions.Data = dictionaryOperation;


            // make the HTTP request
            var localVarResponse = this.Client.Patch<DictionaryResource>("/projects/{projectId}/dictionaries/{languageId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsDictionariesPatch", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Edit Dictionary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany)</param>
        /// <param name="dictionaryOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DictionaryResource</returns>
        public async System.Threading.Tasks.Task<DictionaryResource> ApiProjectsDictionariesPatchAsync(int projectId, string languageId, List<DictionaryOperation> dictionaryOperation = default(List<DictionaryOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<DictionaryResource> localVarResponse = await ApiProjectsDictionariesPatchWithHttpInfoAsync(projectId, languageId, dictionaryOperation, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Edit Dictionary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany)</param>
        /// <param name="dictionaryOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DictionaryResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<DictionaryResource>> ApiProjectsDictionariesPatchWithHttpInfoAsync(int projectId, string languageId, List<DictionaryOperation> dictionaryOperation = default(List<DictionaryOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'languageId' is set
            if (languageId == null)
                throw new Crowdin.Api.Client.ApiException(400, "Missing required parameter 'languageId' when calling DictionariesApi->ApiProjectsDictionariesPatch");


            Crowdin.Api.Client.RequestOptions localVarRequestOptions = new Crowdin.Api.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };


            var localVarContentType = Crowdin.Api.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Crowdin.Api.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("projectId", Crowdin.Api.Client.ClientUtils.ParameterToString(projectId)); // path parameter
            localVarRequestOptions.PathParameters.Add("languageId", Crowdin.Api.Client.ClientUtils.ParameterToString(languageId)); // path parameter
            localVarRequestOptions.Data = dictionaryOperation;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PatchAsync<DictionaryResource>("/projects/{projectId}/dictionaries/{languageId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsDictionariesPatch", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
