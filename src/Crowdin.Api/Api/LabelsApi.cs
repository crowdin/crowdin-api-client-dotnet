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
    public interface ILabelsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Delete Label
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <returns></returns>
        void ApiProjectsLabelsDelete(int projectId, int labelId);

        /// <summary>
        /// Delete Label
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiProjectsLabelsDeleteWithHttpInfo(int projectId, int labelId);
        /// <summary>
        /// Get Label
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <returns>LabelResource</returns>
        LabelResource ApiProjectsLabelsGet(int projectId, int labelId);

        /// <summary>
        /// Get Label
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <returns>ApiResponse of LabelResource</returns>
        ApiResponse<LabelResource> ApiProjectsLabelsGetWithHttpInfo(int projectId, int labelId);
        /// <summary>
        /// List Labels
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>LabelCollectionResource</returns>
        LabelCollectionResource ApiProjectsLabelsGetMany(int projectId, int? limit = default(int?), int? offset = default(int?));

        /// <summary>
        /// List Labels
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of LabelCollectionResource</returns>
        ApiResponse<LabelCollectionResource> ApiProjectsLabelsGetManyWithHttpInfo(int projectId, int? limit = default(int?), int? offset = default(int?));
        /// <summary>
        /// Edit Label
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="labelOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>LabelResource</returns>
        LabelResource ApiProjectsLabelsPatch(int projectId, int labelId, List<LabelOperation> labelOperation = default(List<LabelOperation>));

        /// <summary>
        /// Edit Label
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="labelOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>ApiResponse of LabelResource</returns>
        ApiResponse<LabelResource> ApiProjectsLabelsPatchWithHttpInfo(int projectId, int labelId, List<LabelOperation> labelOperation = default(List<LabelOperation>));
        /// <summary>
        /// Add Label
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelCreateForm"> (optional)</param>
        /// <returns>LabelResource</returns>
        LabelResource ApiProjectsLabelsPost(int projectId, LabelCreateForm labelCreateForm = default(LabelCreateForm));

        /// <summary>
        /// Add Label
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelCreateForm"> (optional)</param>
        /// <returns>ApiResponse of LabelResource</returns>
        ApiResponse<LabelResource> ApiProjectsLabelsPostWithHttpInfo(int projectId, LabelCreateForm labelCreateForm = default(LabelCreateForm));
        /// <summary>
        /// Unassign Label from Strings
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="stringIds">String Identifiers. Get via [List Strings](#operation/api.projects.strings.getMany)  __Note:__ You can unassign up to 500 strings at a time.</param>
        /// <returns>StringCollectionResource</returns>
        StringCollectionResource ApiProjectsLabelsStringsDeleteMany(int projectId, int labelId, string stringIds);

        /// <summary>
        /// Unassign Label from Strings
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="stringIds">String Identifiers. Get via [List Strings](#operation/api.projects.strings.getMany)  __Note:__ You can unassign up to 500 strings at a time.</param>
        /// <returns>ApiResponse of StringCollectionResource</returns>
        ApiResponse<StringCollectionResource> ApiProjectsLabelsStringsDeleteManyWithHttpInfo(int projectId, int labelId, string stringIds);
        /// <summary>
        /// Assign Label to Strings
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="labelStringAssignForm"> (optional)</param>
        /// <returns>StringCollectionResource</returns>
        StringCollectionResource ApiProjectsLabelsStringsPost(int projectId, int labelId, LabelStringAssignForm labelStringAssignForm = default(LabelStringAssignForm));

        /// <summary>
        /// Assign Label to Strings
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="labelStringAssignForm"> (optional)</param>
        /// <returns>ApiResponse of StringCollectionResource</returns>
        ApiResponse<StringCollectionResource> ApiProjectsLabelsStringsPostWithHttpInfo(int projectId, int labelId, LabelStringAssignForm labelStringAssignForm = default(LabelStringAssignForm));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ILabelsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Delete Label
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiProjectsLabelsDeleteAsync(int projectId, int labelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete Label
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiProjectsLabelsDeleteWithHttpInfoAsync(int projectId, int labelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get Label
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LabelResource</returns>
        System.Threading.Tasks.Task<LabelResource> ApiProjectsLabelsGetAsync(int projectId, int labelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get Label
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LabelResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<LabelResource>> ApiProjectsLabelsGetWithHttpInfoAsync(int projectId, int labelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List Labels
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LabelCollectionResource</returns>
        System.Threading.Tasks.Task<LabelCollectionResource> ApiProjectsLabelsGetManyAsync(int projectId, int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List Labels
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LabelCollectionResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<LabelCollectionResource>> ApiProjectsLabelsGetManyWithHttpInfoAsync(int projectId, int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Edit Label
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="labelOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LabelResource</returns>
        System.Threading.Tasks.Task<LabelResource> ApiProjectsLabelsPatchAsync(int projectId, int labelId, List<LabelOperation> labelOperation = default(List<LabelOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Edit Label
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="labelOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LabelResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<LabelResource>> ApiProjectsLabelsPatchWithHttpInfoAsync(int projectId, int labelId, List<LabelOperation> labelOperation = default(List<LabelOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Add Label
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LabelResource</returns>
        System.Threading.Tasks.Task<LabelResource> ApiProjectsLabelsPostAsync(int projectId, LabelCreateForm labelCreateForm = default(LabelCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Add Label
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LabelResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<LabelResource>> ApiProjectsLabelsPostWithHttpInfoAsync(int projectId, LabelCreateForm labelCreateForm = default(LabelCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Unassign Label from Strings
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="stringIds">String Identifiers. Get via [List Strings](#operation/api.projects.strings.getMany)  __Note:__ You can unassign up to 500 strings at a time.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of StringCollectionResource</returns>
        System.Threading.Tasks.Task<StringCollectionResource> ApiProjectsLabelsStringsDeleteManyAsync(int projectId, int labelId, string stringIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Unassign Label from Strings
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="stringIds">String Identifiers. Get via [List Strings](#operation/api.projects.strings.getMany)  __Note:__ You can unassign up to 500 strings at a time.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (StringCollectionResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<StringCollectionResource>> ApiProjectsLabelsStringsDeleteManyWithHttpInfoAsync(int projectId, int labelId, string stringIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Assign Label to Strings
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="labelStringAssignForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of StringCollectionResource</returns>
        System.Threading.Tasks.Task<StringCollectionResource> ApiProjectsLabelsStringsPostAsync(int projectId, int labelId, LabelStringAssignForm labelStringAssignForm = default(LabelStringAssignForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Assign Label to Strings
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="labelStringAssignForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (StringCollectionResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<StringCollectionResource>> ApiProjectsLabelsStringsPostWithHttpInfoAsync(int projectId, int labelId, LabelStringAssignForm labelStringAssignForm = default(LabelStringAssignForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ILabelsApi : ILabelsApiSync, ILabelsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class LabelsApi : ILabelsApi
    {
        private Crowdin.Api.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public LabelsApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public LabelsApi(string basePath)
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
        /// Initializes a new instance of the <see cref="LabelsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public LabelsApi(Crowdin.Api.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="LabelsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public LabelsApi(Crowdin.Api.Client.ISynchronousClient client, Crowdin.Api.Client.IAsynchronousClient asyncClient, Crowdin.Api.Client.IReadableConfiguration configuration)
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
        /// Delete Label 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <returns></returns>
        public void ApiProjectsLabelsDelete(int projectId, int labelId)
        {
            ApiProjectsLabelsDeleteWithHttpInfo(projectId, labelId);
        }

        /// <summary>
        /// Delete Label 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Crowdin.Api.Client.ApiResponse<Object> ApiProjectsLabelsDeleteWithHttpInfo(int projectId, int labelId)
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
            localVarRequestOptions.PathParameters.Add("labelId", Crowdin.Api.Client.ClientUtils.ParameterToString(labelId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/projects/{projectId}/labels/{labelId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsLabelsDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete Label 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiProjectsLabelsDeleteAsync(int projectId, int labelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiProjectsLabelsDeleteWithHttpInfoAsync(projectId, labelId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete Label 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<Object>> ApiProjectsLabelsDeleteWithHttpInfoAsync(int projectId, int labelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("labelId", Crowdin.Api.Client.ClientUtils.ParameterToString(labelId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/projects/{projectId}/labels/{labelId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsLabelsDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Label 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <returns>LabelResource</returns>
        public LabelResource ApiProjectsLabelsGet(int projectId, int labelId)
        {
            Crowdin.Api.Client.ApiResponse<LabelResource> localVarResponse = ApiProjectsLabelsGetWithHttpInfo(projectId, labelId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Label 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <returns>ApiResponse of LabelResource</returns>
        public Crowdin.Api.Client.ApiResponse<LabelResource> ApiProjectsLabelsGetWithHttpInfo(int projectId, int labelId)
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
            localVarRequestOptions.PathParameters.Add("labelId", Crowdin.Api.Client.ClientUtils.ParameterToString(labelId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<LabelResource>("/projects/{projectId}/labels/{labelId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsLabelsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Label 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LabelResource</returns>
        public async System.Threading.Tasks.Task<LabelResource> ApiProjectsLabelsGetAsync(int projectId, int labelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<LabelResource> localVarResponse = await ApiProjectsLabelsGetWithHttpInfoAsync(projectId, labelId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Label 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LabelResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<LabelResource>> ApiProjectsLabelsGetWithHttpInfoAsync(int projectId, int labelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("labelId", Crowdin.Api.Client.ClientUtils.ParameterToString(labelId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<LabelResource>("/projects/{projectId}/labels/{labelId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsLabelsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Labels 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>LabelCollectionResource</returns>
        public LabelCollectionResource ApiProjectsLabelsGetMany(int projectId, int? limit = default(int?), int? offset = default(int?))
        {
            Crowdin.Api.Client.ApiResponse<LabelCollectionResource> localVarResponse = ApiProjectsLabelsGetManyWithHttpInfo(projectId, limit, offset);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Labels 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of LabelCollectionResource</returns>
        public Crowdin.Api.Client.ApiResponse<LabelCollectionResource> ApiProjectsLabelsGetManyWithHttpInfo(int projectId, int? limit = default(int?), int? offset = default(int?))
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
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (offset != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "offset", offset));
            }


            // make the HTTP request
            var localVarResponse = this.Client.Get<LabelCollectionResource>("/projects/{projectId}/labels", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsLabelsGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Labels 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LabelCollectionResource</returns>
        public async System.Threading.Tasks.Task<LabelCollectionResource> ApiProjectsLabelsGetManyAsync(int projectId, int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<LabelCollectionResource> localVarResponse = await ApiProjectsLabelsGetManyWithHttpInfoAsync(projectId, limit, offset, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Labels 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LabelCollectionResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<LabelCollectionResource>> ApiProjectsLabelsGetManyWithHttpInfoAsync(int projectId, int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (offset != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "offset", offset));
            }


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<LabelCollectionResource>("/projects/{projectId}/labels", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsLabelsGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Edit Label 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="labelOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>LabelResource</returns>
        public LabelResource ApiProjectsLabelsPatch(int projectId, int labelId, List<LabelOperation> labelOperation = default(List<LabelOperation>))
        {
            Crowdin.Api.Client.ApiResponse<LabelResource> localVarResponse = ApiProjectsLabelsPatchWithHttpInfo(projectId, labelId, labelOperation);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Edit Label 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="labelOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>ApiResponse of LabelResource</returns>
        public Crowdin.Api.Client.ApiResponse<LabelResource> ApiProjectsLabelsPatchWithHttpInfo(int projectId, int labelId, List<LabelOperation> labelOperation = default(List<LabelOperation>))
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

            localVarRequestOptions.PathParameters.Add("projectId", Crowdin.Api.Client.ClientUtils.ParameterToString(projectId)); // path parameter
            localVarRequestOptions.PathParameters.Add("labelId", Crowdin.Api.Client.ClientUtils.ParameterToString(labelId)); // path parameter
            localVarRequestOptions.Data = labelOperation;


            // make the HTTP request
            var localVarResponse = this.Client.Patch<LabelResource>("/projects/{projectId}/labels/{labelId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsLabelsPatch", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Edit Label 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="labelOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LabelResource</returns>
        public async System.Threading.Tasks.Task<LabelResource> ApiProjectsLabelsPatchAsync(int projectId, int labelId, List<LabelOperation> labelOperation = default(List<LabelOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<LabelResource> localVarResponse = await ApiProjectsLabelsPatchWithHttpInfoAsync(projectId, labelId, labelOperation, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Edit Label 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="labelOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LabelResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<LabelResource>> ApiProjectsLabelsPatchWithHttpInfoAsync(int projectId, int labelId, List<LabelOperation> labelOperation = default(List<LabelOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("projectId", Crowdin.Api.Client.ClientUtils.ParameterToString(projectId)); // path parameter
            localVarRequestOptions.PathParameters.Add("labelId", Crowdin.Api.Client.ClientUtils.ParameterToString(labelId)); // path parameter
            localVarRequestOptions.Data = labelOperation;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PatchAsync<LabelResource>("/projects/{projectId}/labels/{labelId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsLabelsPatch", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add Label 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelCreateForm"> (optional)</param>
        /// <returns>LabelResource</returns>
        public LabelResource ApiProjectsLabelsPost(int projectId, LabelCreateForm labelCreateForm = default(LabelCreateForm))
        {
            Crowdin.Api.Client.ApiResponse<LabelResource> localVarResponse = ApiProjectsLabelsPostWithHttpInfo(projectId, labelCreateForm);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add Label 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelCreateForm"> (optional)</param>
        /// <returns>ApiResponse of LabelResource</returns>
        public Crowdin.Api.Client.ApiResponse<LabelResource> ApiProjectsLabelsPostWithHttpInfo(int projectId, LabelCreateForm labelCreateForm = default(LabelCreateForm))
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

            localVarRequestOptions.PathParameters.Add("projectId", Crowdin.Api.Client.ClientUtils.ParameterToString(projectId)); // path parameter
            localVarRequestOptions.Data = labelCreateForm;


            // make the HTTP request
            var localVarResponse = this.Client.Post<LabelResource>("/projects/{projectId}/labels", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsLabelsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add Label 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LabelResource</returns>
        public async System.Threading.Tasks.Task<LabelResource> ApiProjectsLabelsPostAsync(int projectId, LabelCreateForm labelCreateForm = default(LabelCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<LabelResource> localVarResponse = await ApiProjectsLabelsPostWithHttpInfoAsync(projectId, labelCreateForm, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add Label 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LabelResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<LabelResource>> ApiProjectsLabelsPostWithHttpInfoAsync(int projectId, LabelCreateForm labelCreateForm = default(LabelCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("projectId", Crowdin.Api.Client.ClientUtils.ParameterToString(projectId)); // path parameter
            localVarRequestOptions.Data = labelCreateForm;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<LabelResource>("/projects/{projectId}/labels", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsLabelsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Unassign Label from Strings 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="stringIds">String Identifiers. Get via [List Strings](#operation/api.projects.strings.getMany)  __Note:__ You can unassign up to 500 strings at a time.</param>
        /// <returns>StringCollectionResource</returns>
        public StringCollectionResource ApiProjectsLabelsStringsDeleteMany(int projectId, int labelId, string stringIds)
        {
            Crowdin.Api.Client.ApiResponse<StringCollectionResource> localVarResponse = ApiProjectsLabelsStringsDeleteManyWithHttpInfo(projectId, labelId, stringIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Unassign Label from Strings 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="stringIds">String Identifiers. Get via [List Strings](#operation/api.projects.strings.getMany)  __Note:__ You can unassign up to 500 strings at a time.</param>
        /// <returns>ApiResponse of StringCollectionResource</returns>
        public Crowdin.Api.Client.ApiResponse<StringCollectionResource> ApiProjectsLabelsStringsDeleteManyWithHttpInfo(int projectId, int labelId, string stringIds)
        {
            // verify the required parameter 'stringIds' is set
            if (stringIds == null)
                throw new Crowdin.Api.Client.ApiException(400, "Missing required parameter 'stringIds' when calling LabelsApi->ApiProjectsLabelsStringsDeleteMany");

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
            localVarRequestOptions.PathParameters.Add("labelId", Crowdin.Api.Client.ClientUtils.ParameterToString(labelId)); // path parameter
            localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "stringIds", stringIds));


            // make the HTTP request
            var localVarResponse = this.Client.Delete<StringCollectionResource>("/projects/{projectId}/labels/{labelId}/strings", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsLabelsStringsDeleteMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Unassign Label from Strings 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="stringIds">String Identifiers. Get via [List Strings](#operation/api.projects.strings.getMany)  __Note:__ You can unassign up to 500 strings at a time.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of StringCollectionResource</returns>
        public async System.Threading.Tasks.Task<StringCollectionResource> ApiProjectsLabelsStringsDeleteManyAsync(int projectId, int labelId, string stringIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<StringCollectionResource> localVarResponse = await ApiProjectsLabelsStringsDeleteManyWithHttpInfoAsync(projectId, labelId, stringIds, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Unassign Label from Strings 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="stringIds">String Identifiers. Get via [List Strings](#operation/api.projects.strings.getMany)  __Note:__ You can unassign up to 500 strings at a time.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (StringCollectionResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<StringCollectionResource>> ApiProjectsLabelsStringsDeleteManyWithHttpInfoAsync(int projectId, int labelId, string stringIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'stringIds' is set
            if (stringIds == null)
                throw new Crowdin.Api.Client.ApiException(400, "Missing required parameter 'stringIds' when calling LabelsApi->ApiProjectsLabelsStringsDeleteMany");


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
            localVarRequestOptions.PathParameters.Add("labelId", Crowdin.Api.Client.ClientUtils.ParameterToString(labelId)); // path parameter
            localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "stringIds", stringIds));


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<StringCollectionResource>("/projects/{projectId}/labels/{labelId}/strings", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsLabelsStringsDeleteMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Assign Label to Strings 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="labelStringAssignForm"> (optional)</param>
        /// <returns>StringCollectionResource</returns>
        public StringCollectionResource ApiProjectsLabelsStringsPost(int projectId, int labelId, LabelStringAssignForm labelStringAssignForm = default(LabelStringAssignForm))
        {
            Crowdin.Api.Client.ApiResponse<StringCollectionResource> localVarResponse = ApiProjectsLabelsStringsPostWithHttpInfo(projectId, labelId, labelStringAssignForm);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Assign Label to Strings 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="labelStringAssignForm"> (optional)</param>
        /// <returns>ApiResponse of StringCollectionResource</returns>
        public Crowdin.Api.Client.ApiResponse<StringCollectionResource> ApiProjectsLabelsStringsPostWithHttpInfo(int projectId, int labelId, LabelStringAssignForm labelStringAssignForm = default(LabelStringAssignForm))
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

            localVarRequestOptions.PathParameters.Add("projectId", Crowdin.Api.Client.ClientUtils.ParameterToString(projectId)); // path parameter
            localVarRequestOptions.PathParameters.Add("labelId", Crowdin.Api.Client.ClientUtils.ParameterToString(labelId)); // path parameter
            localVarRequestOptions.Data = labelStringAssignForm;


            // make the HTTP request
            var localVarResponse = this.Client.Post<StringCollectionResource>("/projects/{projectId}/labels/{labelId}/strings", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsLabelsStringsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Assign Label to Strings 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="labelStringAssignForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of StringCollectionResource</returns>
        public async System.Threading.Tasks.Task<StringCollectionResource> ApiProjectsLabelsStringsPostAsync(int projectId, int labelId, LabelStringAssignForm labelStringAssignForm = default(LabelStringAssignForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<StringCollectionResource> localVarResponse = await ApiProjectsLabelsStringsPostWithHttpInfoAsync(projectId, labelId, labelStringAssignForm, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Assign Label to Strings 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="labelId">Label Identifier. Get via [List Labels](#operation/api.projects.labels.getMany)</param>
        /// <param name="labelStringAssignForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (StringCollectionResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<StringCollectionResource>> ApiProjectsLabelsStringsPostWithHttpInfoAsync(int projectId, int labelId, LabelStringAssignForm labelStringAssignForm = default(LabelStringAssignForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("projectId", Crowdin.Api.Client.ClientUtils.ParameterToString(projectId)); // path parameter
            localVarRequestOptions.PathParameters.Add("labelId", Crowdin.Api.Client.ClientUtils.ParameterToString(labelId)); // path parameter
            localVarRequestOptions.Data = labelStringAssignForm;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<StringCollectionResource>("/projects/{projectId}/labels/{labelId}/strings", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsLabelsStringsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
