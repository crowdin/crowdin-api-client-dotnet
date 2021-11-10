/*
 * Crowdin API v2
 *
 *  # Introduction Welcome to Crowdin Enterprise API v2 documentation.  Our API is a full-featured RESTful API that helps you to integrate localization into your development process. The endpoints that we use allow you to easily make calls to retrieve information and to execute actions needed.  Most of the functionality of Crowdin Enterprise is available through the API. It allows you to create projects for translations, add and update files, download translations, and much more. In this way, you can script the complex actions that your situation requires.  Documentation starts with a general overview of the design and technology that was implemented and is followed by detailed information on specific methods and endpoints.  ## Asynchronous Operations Methods such as report generation, project build, and file download need some time to be completed and are finalized in several steps. It is what we call asynchronous operations. This  approach allows the application to work without interruptions while the method is running at the background.  To run asynchronous operations, 3 subsequent API methods are used:  *     Method to start operation – returns the status __Found__ if the resource you’re requesting is already generated. Typically, __201 Accepted__ status is returned along with the operation identifier. The operation status is then checked with the help of this identifier.  *     Method to check the status of operation – returns  the completion percentage.  *     Method to get the temporary link for resource download – mostly used for export operations. When the operation is completed, you can run this method to get a temporary link for resource download.  __Note:__ Download link is active for a few minutes.  For example, to download a Translation Memory (TM), you need to run following sequence of API methods:  *     [_Export TM_](#operation/api.tms.exports.post)  *     [_Check TM Export Status_](#operation/api.tms.exports.get)  *     [_Download TM_](#operation/api.tms.exports.getMany)  ## File Upload With Crowdin Enterprise API v2 all files such as files for localization, screenshots, Glossaries, and Translation Memories should be first uploaded to the [Storage](#tag/Storage). After you upload file to the Storage it will have a unique storage id using which you can then add the file to the project.  For example, to upload a localization file to your project, you need to run the following sequence of API methods:  *     [_Add Storage_](#operation/api.storages.post) – upload localization file body to storage at Crowdin server  *     [_Add File_](#operation/api.projects.files.post) – define where to add the localization file with specific _storage id_  ## Authorization To work with Crowdin Enterprise API v2 use one of the following access tokens:   *     [_Personal Access Token_](/enterprise/personal-access-tokens/#creating-a-personal-access-token)  *     [_OAuth Access Token_](/enterprise/authorizing-oauth-apps/#make-requests-to-the-api-with-the-access-token-returned)  Make sure to use the following __header__ in your requests:  `Authorization: Bearer ACCESS_TOKEN`  Responses in case authorization fail:  __401 Unauthorized__ ``` {   \"error\": {     \"message\": \"Unauthorized\",     \"code\": 401   } } ```  __403 Forbidden__ ``` {   \"error\": {     \"message\": \"Not allowed endpoint for token scopes\",     \"code\": 403   } } ``` ``` {   \"error\": {     \"message\": \"Not allowed space for your token\",     \"code\": 403   } } ```  ## Requests All requests should be made using the HTTPS protocol so that traffic is encrypted. The interface responds to different methods depending on the action required.  When a request is successful, a response will typically be sent back in the form of a JSON object. If you specify `Accept` header response will be `application/json`. It’s not required to specify `Accept` header so you can leave it empty.  The API expects all writing requests (_POST_, _PUT_, _PATCH_) in JSON format with the `Content-Type: application/json` header. This ensures that your request is interpreted correctly.  __Note:__ `Content-Type` header can be different (e.g. `image/jpeg`, `text/csv`) if you upload the file using _POST_ methods with a specified content type.  RESTful APIs enable you to call individual API endpoints to perform the following requests:  *     <span class='http-method method-list get'>GET</span> - for simple retrieval of information about source files, translations, or projects. The information you request will be returned to you as a JSON object. The attributes defined by the JSON object can be used to form additional requests.  *     <span class='http-method method-list post'>POST</span> - to create or add a new element. This request includes all of the attributes necessary to create a new object.  *     <span class='http-method method-list put'>PUT</span> - to update or replace the specific element. This request sets the state of the target using the provided values, regardless of their current values.  *     <span class='http-method method-list patch'>PATCH</span> - to edit some specific fields of an entity. With these requests, you only need to provide the data you want to change.  *     <span class='http-method method-list delete'>DELETE</span> - to remove element from your account. Request works if specified object is found. If it is not found, the operation will return a response indicating that the object was not found.  For example, to edit the name and description of a project, where the requested resource is the project with `id` = 1, the request is the following:  __Example Endpoint__ <div class='well well-sm'> <span class='http-method patch'>PATCH</span> https://{organization_domain}.api.crowdin.com/api/v2/<span class='api-section-block-highlighted'>projects/1</span> </div>  where <span class='api-section-block-highlighted'>projects/1</span> is the requested resource.  __Content-Type header:__ `application/json`  __Request body__ ``` [   {\"op\":\"replace\", \"path\":\"/name\", \"value\":\"Project new name\"},   {\"op\":\"replace\", \"path\":\"/description\", \"value\":\"New description for the project\"} ] ```  ## Rate Limits The number of simultaneous API requests per account is 20 requests. Response code __429 Too Many Requests__ is returned when the limit is exceeded.  ## Crowdin API Clients The Crowdin API clients are the lightweight interfaces developed for the Crowdin API v2. They provide common services for making API requests.  You may find detailed information on each client in its respective GitHub repository:  [_Crowdin JavaScript client_](https://github.com/crowdin/crowdin-api-client-js)\\ [_Crowdin PHP client_](https://github.com/crowdin/crowdin-api-client-php)\\ [_Crowdin Java client_](https://github.com/crowdin/crowdin-api-client-java)\\ [_Crowdin Python client_](https://github.com/crowdin/crowdin-api-client-python)\\ _Crowdin .NET client_ _(Coming soon)_  
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
    public interface IMachineTranslationEnginesApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Delete MT
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mtId">Machine Translation engine identifier</param>
        /// <returns></returns>
        void ApiMtsDelete(int mtId);

        /// <summary>
        /// Delete MT
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mtId">Machine Translation engine identifier</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiMtsDeleteWithHttpInfo(int mtId);
        /// <summary>
        /// Get MT
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mtId">Machine Translation engine identifier</param>
        /// <returns>MtResource</returns>
        MtResource ApiMtsGet(int mtId);

        /// <summary>
        /// Get MT
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mtId">Machine Translation engine identifier</param>
        /// <returns>ApiResponse of MtResource</returns>
        ApiResponse<MtResource> ApiMtsGetWithHttpInfo(int mtId);
        /// <summary>
        /// List MTs
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)  __Note__: Set 0 to see MTs of root group (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>MtCollectionResource</returns>
        MtCollectionResource ApiMtsGetMany(int? groupId = default(int?), int? limit = default(int?), int? offset = default(int?));

        /// <summary>
        /// List MTs
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)  __Note__: Set 0 to see MTs of root group (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of MtCollectionResource</returns>
        ApiResponse<MtCollectionResource> ApiMtsGetManyWithHttpInfo(int? groupId = default(int?), int? limit = default(int?), int? offset = default(int?));
        /// <summary>
        /// Edit MT
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mtId">Machine Translation engine identifier</param>
        /// <param name="mtOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>MtResource</returns>
        MtResource ApiMtsPatch(int mtId, List<MtOperation> mtOperation = default(List<MtOperation>));

        /// <summary>
        /// Edit MT
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mtId">Machine Translation engine identifier</param>
        /// <param name="mtOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>ApiResponse of MtResource</returns>
        ApiResponse<MtResource> ApiMtsPatchWithHttpInfo(int mtId, List<MtOperation> mtOperation = default(List<MtOperation>));
        /// <summary>
        /// Add MT
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enterpriseMtCreateForm"> (optional)</param>
        /// <returns>MtResource</returns>
        MtResource ApiMtsPost(EnterpriseMtCreateForm enterpriseMtCreateForm = default(EnterpriseMtCreateForm));

        /// <summary>
        /// Add MT
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enterpriseMtCreateForm"> (optional)</param>
        /// <returns>ApiResponse of MtResource</returns>
        ApiResponse<MtResource> ApiMtsPostWithHttpInfo(EnterpriseMtCreateForm enterpriseMtCreateForm = default(EnterpriseMtCreateForm));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IMachineTranslationEnginesApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Delete MT
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mtId">Machine Translation engine identifier</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiMtsDeleteAsync(int mtId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete MT
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mtId">Machine Translation engine identifier</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiMtsDeleteWithHttpInfoAsync(int mtId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get MT
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mtId">Machine Translation engine identifier</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of MtResource</returns>
        System.Threading.Tasks.Task<MtResource> ApiMtsGetAsync(int mtId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get MT
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mtId">Machine Translation engine identifier</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (MtResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<MtResource>> ApiMtsGetWithHttpInfoAsync(int mtId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List MTs
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)  __Note__: Set 0 to see MTs of root group (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of MtCollectionResource</returns>
        System.Threading.Tasks.Task<MtCollectionResource> ApiMtsGetManyAsync(int? groupId = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List MTs
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)  __Note__: Set 0 to see MTs of root group (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (MtCollectionResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<MtCollectionResource>> ApiMtsGetManyWithHttpInfoAsync(int? groupId = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Edit MT
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mtId">Machine Translation engine identifier</param>
        /// <param name="mtOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of MtResource</returns>
        System.Threading.Tasks.Task<MtResource> ApiMtsPatchAsync(int mtId, List<MtOperation> mtOperation = default(List<MtOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Edit MT
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mtId">Machine Translation engine identifier</param>
        /// <param name="mtOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (MtResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<MtResource>> ApiMtsPatchWithHttpInfoAsync(int mtId, List<MtOperation> mtOperation = default(List<MtOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Add MT
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enterpriseMtCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of MtResource</returns>
        System.Threading.Tasks.Task<MtResource> ApiMtsPostAsync(EnterpriseMtCreateForm enterpriseMtCreateForm = default(EnterpriseMtCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Add MT
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enterpriseMtCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (MtResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<MtResource>> ApiMtsPostWithHttpInfoAsync(EnterpriseMtCreateForm enterpriseMtCreateForm = default(EnterpriseMtCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IMachineTranslationEnginesApi : IMachineTranslationEnginesApiSync, IMachineTranslationEnginesApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class MachineTranslationEnginesApi : IMachineTranslationEnginesApi
    {
        private Crowdin.Api.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="MachineTranslationEnginesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public MachineTranslationEnginesApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MachineTranslationEnginesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public MachineTranslationEnginesApi(string basePath)
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
        /// Initializes a new instance of the <see cref="MachineTranslationEnginesApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public MachineTranslationEnginesApi(Crowdin.Api.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="MachineTranslationEnginesApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public MachineTranslationEnginesApi(Crowdin.Api.Client.ISynchronousClient client, Crowdin.Api.Client.IAsynchronousClient asyncClient, Crowdin.Api.Client.IReadableConfiguration configuration)
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
        /// Delete MT 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mtId">Machine Translation engine identifier</param>
        /// <returns></returns>
        public void ApiMtsDelete(int mtId)
        {
            ApiMtsDeleteWithHttpInfo(mtId);
        }

        /// <summary>
        /// Delete MT 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mtId">Machine Translation engine identifier</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Crowdin.Api.Client.ApiResponse<Object> ApiMtsDeleteWithHttpInfo(int mtId)
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

            localVarRequestOptions.PathParameters.Add("mtId", Crowdin.Api.Client.ClientUtils.ParameterToString(mtId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/mts/{mtId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiMtsDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete MT 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mtId">Machine Translation engine identifier</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiMtsDeleteAsync(int mtId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiMtsDeleteWithHttpInfoAsync(mtId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete MT 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mtId">Machine Translation engine identifier</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<Object>> ApiMtsDeleteWithHttpInfoAsync(int mtId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("mtId", Crowdin.Api.Client.ClientUtils.ParameterToString(mtId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/mts/{mtId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiMtsDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get MT 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mtId">Machine Translation engine identifier</param>
        /// <returns>MtResource</returns>
        public MtResource ApiMtsGet(int mtId)
        {
            Crowdin.Api.Client.ApiResponse<MtResource> localVarResponse = ApiMtsGetWithHttpInfo(mtId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get MT 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mtId">Machine Translation engine identifier</param>
        /// <returns>ApiResponse of MtResource</returns>
        public Crowdin.Api.Client.ApiResponse<MtResource> ApiMtsGetWithHttpInfo(int mtId)
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

            localVarRequestOptions.PathParameters.Add("mtId", Crowdin.Api.Client.ClientUtils.ParameterToString(mtId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<MtResource>("/mts/{mtId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiMtsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get MT 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mtId">Machine Translation engine identifier</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of MtResource</returns>
        public async System.Threading.Tasks.Task<MtResource> ApiMtsGetAsync(int mtId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<MtResource> localVarResponse = await ApiMtsGetWithHttpInfoAsync(mtId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get MT 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mtId">Machine Translation engine identifier</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (MtResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<MtResource>> ApiMtsGetWithHttpInfoAsync(int mtId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("mtId", Crowdin.Api.Client.ClientUtils.ParameterToString(mtId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<MtResource>("/mts/{mtId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiMtsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List MTs 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)  __Note__: Set 0 to see MTs of root group (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>MtCollectionResource</returns>
        public MtCollectionResource ApiMtsGetMany(int? groupId = default(int?), int? limit = default(int?), int? offset = default(int?))
        {
            Crowdin.Api.Client.ApiResponse<MtCollectionResource> localVarResponse = ApiMtsGetManyWithHttpInfo(groupId, limit, offset);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List MTs 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)  __Note__: Set 0 to see MTs of root group (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of MtCollectionResource</returns>
        public Crowdin.Api.Client.ApiResponse<MtCollectionResource> ApiMtsGetManyWithHttpInfo(int? groupId = default(int?), int? limit = default(int?), int? offset = default(int?))
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

            if (groupId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "groupId", groupId));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (offset != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "offset", offset));
            }


            // make the HTTP request
            var localVarResponse = this.Client.Get<MtCollectionResource>("/mts", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiMtsGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List MTs 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)  __Note__: Set 0 to see MTs of root group (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of MtCollectionResource</returns>
        public async System.Threading.Tasks.Task<MtCollectionResource> ApiMtsGetManyAsync(int? groupId = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<MtCollectionResource> localVarResponse = await ApiMtsGetManyWithHttpInfoAsync(groupId, limit, offset, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List MTs 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)  __Note__: Set 0 to see MTs of root group (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (MtCollectionResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<MtCollectionResource>> ApiMtsGetManyWithHttpInfoAsync(int? groupId = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            if (groupId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "groupId", groupId));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (offset != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "offset", offset));
            }


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<MtCollectionResource>("/mts", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiMtsGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Edit MT 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mtId">Machine Translation engine identifier</param>
        /// <param name="mtOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>MtResource</returns>
        public MtResource ApiMtsPatch(int mtId, List<MtOperation> mtOperation = default(List<MtOperation>))
        {
            Crowdin.Api.Client.ApiResponse<MtResource> localVarResponse = ApiMtsPatchWithHttpInfo(mtId, mtOperation);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Edit MT 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mtId">Machine Translation engine identifier</param>
        /// <param name="mtOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>ApiResponse of MtResource</returns>
        public Crowdin.Api.Client.ApiResponse<MtResource> ApiMtsPatchWithHttpInfo(int mtId, List<MtOperation> mtOperation = default(List<MtOperation>))
        {
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

            localVarRequestOptions.PathParameters.Add("mtId", Crowdin.Api.Client.ClientUtils.ParameterToString(mtId)); // path parameter
            localVarRequestOptions.Data = mtOperation;


            // make the HTTP request
            var localVarResponse = this.Client.Patch<MtResource>("/mts/{mtId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiMtsPatch", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Edit MT 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mtId">Machine Translation engine identifier</param>
        /// <param name="mtOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of MtResource</returns>
        public async System.Threading.Tasks.Task<MtResource> ApiMtsPatchAsync(int mtId, List<MtOperation> mtOperation = default(List<MtOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<MtResource> localVarResponse = await ApiMtsPatchWithHttpInfoAsync(mtId, mtOperation, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Edit MT 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="mtId">Machine Translation engine identifier</param>
        /// <param name="mtOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (MtResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<MtResource>> ApiMtsPatchWithHttpInfoAsync(int mtId, List<MtOperation> mtOperation = default(List<MtOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

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

            localVarRequestOptions.PathParameters.Add("mtId", Crowdin.Api.Client.ClientUtils.ParameterToString(mtId)); // path parameter
            localVarRequestOptions.Data = mtOperation;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PatchAsync<MtResource>("/mts/{mtId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiMtsPatch", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add MT 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enterpriseMtCreateForm"> (optional)</param>
        /// <returns>MtResource</returns>
        public MtResource ApiMtsPost(EnterpriseMtCreateForm enterpriseMtCreateForm = default(EnterpriseMtCreateForm))
        {
            Crowdin.Api.Client.ApiResponse<MtResource> localVarResponse = ApiMtsPostWithHttpInfo(enterpriseMtCreateForm);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add MT 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enterpriseMtCreateForm"> (optional)</param>
        /// <returns>ApiResponse of MtResource</returns>
        public Crowdin.Api.Client.ApiResponse<MtResource> ApiMtsPostWithHttpInfo(EnterpriseMtCreateForm enterpriseMtCreateForm = default(EnterpriseMtCreateForm))
        {
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

            localVarRequestOptions.Data = enterpriseMtCreateForm;


            // make the HTTP request
            var localVarResponse = this.Client.Post<MtResource>("/mts", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiMtsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add MT 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enterpriseMtCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of MtResource</returns>
        public async System.Threading.Tasks.Task<MtResource> ApiMtsPostAsync(EnterpriseMtCreateForm enterpriseMtCreateForm = default(EnterpriseMtCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<MtResource> localVarResponse = await ApiMtsPostWithHttpInfoAsync(enterpriseMtCreateForm, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add MT 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enterpriseMtCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (MtResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<MtResource>> ApiMtsPostWithHttpInfoAsync(EnterpriseMtCreateForm enterpriseMtCreateForm = default(EnterpriseMtCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

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

            localVarRequestOptions.Data = enterpriseMtCreateForm;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<MtResource>("/mts", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiMtsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
