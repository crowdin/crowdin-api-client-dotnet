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
    public interface IScreenshotsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Delete Screenshot
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <returns></returns>
        void ApiProjectsScreenshotsDelete(int projectId, int screenshotId);

        /// <summary>
        /// Delete Screenshot
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiProjectsScreenshotsDeleteWithHttpInfo(int projectId, int screenshotId);
        /// <summary>
        /// Get Screenshot
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <returns>ScreenshotResource</returns>
        ScreenshotResource ApiProjectsScreenshotsGet(int projectId, int screenshotId);

        /// <summary>
        /// Get Screenshot
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <returns>ApiResponse of ScreenshotResource</returns>
        ApiResponse<ScreenshotResource> ApiProjectsScreenshotsGetWithHttpInfo(int projectId, int screenshotId);
        /// <summary>
        /// List Screenshots
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ScreenshotCollectionResource</returns>
        ScreenshotCollectionResource ApiProjectsScreenshotsGetMany(int projectId, int? limit = default(int?), int? offset = default(int?));

        /// <summary>
        /// List Screenshots
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of ScreenshotCollectionResource</returns>
        ApiResponse<ScreenshotCollectionResource> ApiProjectsScreenshotsGetManyWithHttpInfo(int projectId, int? limit = default(int?), int? offset = default(int?));
        /// <summary>
        /// Edit Screenshot
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="screenshotOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>ScreenshotResource</returns>
        ScreenshotResource ApiProjectsScreenshotsPatch(int projectId, int screenshotId, List<ScreenshotOperation> screenshotOperation = default(List<ScreenshotOperation>));

        /// <summary>
        /// Edit Screenshot
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="screenshotOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>ApiResponse of ScreenshotResource</returns>
        ApiResponse<ScreenshotResource> ApiProjectsScreenshotsPatchWithHttpInfo(int projectId, int screenshotId, List<ScreenshotOperation> screenshotOperation = default(List<ScreenshotOperation>));
        /// <summary>
        /// Add Screenshot
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotCreateForm"> (optional)</param>
        /// <returns>ScreenshotResource</returns>
        ScreenshotResource ApiProjectsScreenshotsPost(int projectId, ScreenshotCreateForm screenshotCreateForm = default(ScreenshotCreateForm));

        /// <summary>
        /// Add Screenshot
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotCreateForm"> (optional)</param>
        /// <returns>ApiResponse of ScreenshotResource</returns>
        ApiResponse<ScreenshotResource> ApiProjectsScreenshotsPostWithHttpInfo(int projectId, ScreenshotCreateForm screenshotCreateForm = default(ScreenshotCreateForm));
        /// <summary>
        /// Update Screenshot
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="screenshotReplaceForm"> (optional)</param>
        /// <returns>ScreenshotResource</returns>
        ScreenshotResource ApiProjectsScreenshotsPut(int projectId, int screenshotId, ScreenshotReplaceForm screenshotReplaceForm = default(ScreenshotReplaceForm));

        /// <summary>
        /// Update Screenshot
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="screenshotReplaceForm"> (optional)</param>
        /// <returns>ApiResponse of ScreenshotResource</returns>
        ApiResponse<ScreenshotResource> ApiProjectsScreenshotsPutWithHttpInfo(int projectId, int screenshotId, ScreenshotReplaceForm screenshotReplaceForm = default(ScreenshotReplaceForm));
        /// <summary>
        /// Delete Tag
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagId">Tag Identifier. Get via [List Tags](#operation/api.projects.screenshots.tags.getMany)</param>
        /// <returns></returns>
        void ApiProjectsScreenshotsTagsDelete(int projectId, int screenshotId, int tagId);

        /// <summary>
        /// Delete Tag
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagId">Tag Identifier. Get via [List Tags](#operation/api.projects.screenshots.tags.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiProjectsScreenshotsTagsDeleteWithHttpInfo(int projectId, int screenshotId, int tagId);
        /// <summary>
        /// Clear Tags
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <returns></returns>
        void ApiProjectsScreenshotsTagsDeleteMany(int projectId, int screenshotId);

        /// <summary>
        /// Clear Tags
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiProjectsScreenshotsTagsDeleteManyWithHttpInfo(int projectId, int screenshotId);
        /// <summary>
        /// Get Tag
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagId">Tag Identifier. Get via [List Tags](#operation/api.projects.screenshots.tags.getMany)</param>
        /// <returns>TagResource</returns>
        TagResource ApiProjectsScreenshotsTagsGet(int projectId, int screenshotId, int tagId);

        /// <summary>
        /// Get Tag
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagId">Tag Identifier. Get via [List Tags](#operation/api.projects.screenshots.tags.getMany)</param>
        /// <returns>ApiResponse of TagResource</returns>
        ApiResponse<TagResource> ApiProjectsScreenshotsTagsGetWithHttpInfo(int projectId, int screenshotId, int tagId);
        /// <summary>
        /// List Tags
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>TagCollectionResource</returns>
        TagCollectionResource ApiProjectsScreenshotsTagsGetMany(int projectId, int screenshotId, int? limit = default(int?), int? offset = default(int?));

        /// <summary>
        /// List Tags
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of TagCollectionResource</returns>
        ApiResponse<TagCollectionResource> ApiProjectsScreenshotsTagsGetManyWithHttpInfo(int projectId, int screenshotId, int? limit = default(int?), int? offset = default(int?));
        /// <summary>
        /// Edit Tag
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagId">Tag Identifier. Get via [List Tags](#operation/api.projects.screenshots.tags.getMany)</param>
        /// <param name="tagOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>ScreenshotResource</returns>
        ScreenshotResource ApiProjectsScreenshotsTagsPatch(int projectId, int screenshotId, int tagId, List<TagOperation> tagOperation = default(List<TagOperation>));

        /// <summary>
        /// Edit Tag
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagId">Tag Identifier. Get via [List Tags](#operation/api.projects.screenshots.tags.getMany)</param>
        /// <param name="tagOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>ApiResponse of ScreenshotResource</returns>
        ApiResponse<ScreenshotResource> ApiProjectsScreenshotsTagsPatchWithHttpInfo(int projectId, int screenshotId, int tagId, List<TagOperation> tagOperation = default(List<TagOperation>));
        /// <summary>
        /// Add Tag
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagCreateForm"> (optional)</param>
        /// <returns>TagResource</returns>
        TagResource ApiProjectsScreenshotsTagsPost(int projectId, int screenshotId, List<TagCreateForm> tagCreateForm = default(List<TagCreateForm>));

        /// <summary>
        /// Add Tag
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagCreateForm"> (optional)</param>
        /// <returns>ApiResponse of TagResource</returns>
        ApiResponse<TagResource> ApiProjectsScreenshotsTagsPostWithHttpInfo(int projectId, int screenshotId, List<TagCreateForm> tagCreateForm = default(List<TagCreateForm>));
        /// <summary>
        /// Replace Tags (Auto Tag)
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="UNKNOWN_BASE_TYPE"> (optional)</param>
        /// <returns></returns>
        void ApiProjectsScreenshotsTagsPutMany(int projectId, int screenshotId, UNKNOWN_BASE_TYPE UNKNOWN_BASE_TYPE = default(UNKNOWN_BASE_TYPE));

        /// <summary>
        /// Replace Tags (Auto Tag)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="UNKNOWN_BASE_TYPE"> (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiProjectsScreenshotsTagsPutManyWithHttpInfo(int projectId, int screenshotId, UNKNOWN_BASE_TYPE UNKNOWN_BASE_TYPE = default(UNKNOWN_BASE_TYPE));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IScreenshotsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Delete Screenshot
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiProjectsScreenshotsDeleteAsync(int projectId, int screenshotId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete Screenshot
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiProjectsScreenshotsDeleteWithHttpInfoAsync(int projectId, int screenshotId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get Screenshot
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ScreenshotResource</returns>
        System.Threading.Tasks.Task<ScreenshotResource> ApiProjectsScreenshotsGetAsync(int projectId, int screenshotId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get Screenshot
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ScreenshotResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<ScreenshotResource>> ApiProjectsScreenshotsGetWithHttpInfoAsync(int projectId, int screenshotId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List Screenshots
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ScreenshotCollectionResource</returns>
        System.Threading.Tasks.Task<ScreenshotCollectionResource> ApiProjectsScreenshotsGetManyAsync(int projectId, int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List Screenshots
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ScreenshotCollectionResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<ScreenshotCollectionResource>> ApiProjectsScreenshotsGetManyWithHttpInfoAsync(int projectId, int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Edit Screenshot
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="screenshotOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ScreenshotResource</returns>
        System.Threading.Tasks.Task<ScreenshotResource> ApiProjectsScreenshotsPatchAsync(int projectId, int screenshotId, List<ScreenshotOperation> screenshotOperation = default(List<ScreenshotOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Edit Screenshot
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="screenshotOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ScreenshotResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<ScreenshotResource>> ApiProjectsScreenshotsPatchWithHttpInfoAsync(int projectId, int screenshotId, List<ScreenshotOperation> screenshotOperation = default(List<ScreenshotOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Add Screenshot
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ScreenshotResource</returns>
        System.Threading.Tasks.Task<ScreenshotResource> ApiProjectsScreenshotsPostAsync(int projectId, ScreenshotCreateForm screenshotCreateForm = default(ScreenshotCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Add Screenshot
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ScreenshotResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<ScreenshotResource>> ApiProjectsScreenshotsPostWithHttpInfoAsync(int projectId, ScreenshotCreateForm screenshotCreateForm = default(ScreenshotCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update Screenshot
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="screenshotReplaceForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ScreenshotResource</returns>
        System.Threading.Tasks.Task<ScreenshotResource> ApiProjectsScreenshotsPutAsync(int projectId, int screenshotId, ScreenshotReplaceForm screenshotReplaceForm = default(ScreenshotReplaceForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Update Screenshot
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="screenshotReplaceForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ScreenshotResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<ScreenshotResource>> ApiProjectsScreenshotsPutWithHttpInfoAsync(int projectId, int screenshotId, ScreenshotReplaceForm screenshotReplaceForm = default(ScreenshotReplaceForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Delete Tag
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagId">Tag Identifier. Get via [List Tags](#operation/api.projects.screenshots.tags.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiProjectsScreenshotsTagsDeleteAsync(int projectId, int screenshotId, int tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete Tag
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagId">Tag Identifier. Get via [List Tags](#operation/api.projects.screenshots.tags.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiProjectsScreenshotsTagsDeleteWithHttpInfoAsync(int projectId, int screenshotId, int tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Clear Tags
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiProjectsScreenshotsTagsDeleteManyAsync(int projectId, int screenshotId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Clear Tags
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiProjectsScreenshotsTagsDeleteManyWithHttpInfoAsync(int projectId, int screenshotId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get Tag
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagId">Tag Identifier. Get via [List Tags](#operation/api.projects.screenshots.tags.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TagResource</returns>
        System.Threading.Tasks.Task<TagResource> ApiProjectsScreenshotsTagsGetAsync(int projectId, int screenshotId, int tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get Tag
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagId">Tag Identifier. Get via [List Tags](#operation/api.projects.screenshots.tags.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TagResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<TagResource>> ApiProjectsScreenshotsTagsGetWithHttpInfoAsync(int projectId, int screenshotId, int tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List Tags
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TagCollectionResource</returns>
        System.Threading.Tasks.Task<TagCollectionResource> ApiProjectsScreenshotsTagsGetManyAsync(int projectId, int screenshotId, int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List Tags
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TagCollectionResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<TagCollectionResource>> ApiProjectsScreenshotsTagsGetManyWithHttpInfoAsync(int projectId, int screenshotId, int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Edit Tag
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagId">Tag Identifier. Get via [List Tags](#operation/api.projects.screenshots.tags.getMany)</param>
        /// <param name="tagOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ScreenshotResource</returns>
        System.Threading.Tasks.Task<ScreenshotResource> ApiProjectsScreenshotsTagsPatchAsync(int projectId, int screenshotId, int tagId, List<TagOperation> tagOperation = default(List<TagOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Edit Tag
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagId">Tag Identifier. Get via [List Tags](#operation/api.projects.screenshots.tags.getMany)</param>
        /// <param name="tagOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ScreenshotResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<ScreenshotResource>> ApiProjectsScreenshotsTagsPatchWithHttpInfoAsync(int projectId, int screenshotId, int tagId, List<TagOperation> tagOperation = default(List<TagOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Add Tag
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TagResource</returns>
        System.Threading.Tasks.Task<TagResource> ApiProjectsScreenshotsTagsPostAsync(int projectId, int screenshotId, List<TagCreateForm> tagCreateForm = default(List<TagCreateForm>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Add Tag
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TagResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<TagResource>> ApiProjectsScreenshotsTagsPostWithHttpInfoAsync(int projectId, int screenshotId, List<TagCreateForm> tagCreateForm = default(List<TagCreateForm>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Replace Tags (Auto Tag)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="UNKNOWN_BASE_TYPE"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiProjectsScreenshotsTagsPutManyAsync(int projectId, int screenshotId, UNKNOWN_BASE_TYPE UNKNOWN_BASE_TYPE = default(UNKNOWN_BASE_TYPE), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Replace Tags (Auto Tag)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="UNKNOWN_BASE_TYPE"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiProjectsScreenshotsTagsPutManyWithHttpInfoAsync(int projectId, int screenshotId, UNKNOWN_BASE_TYPE UNKNOWN_BASE_TYPE = default(UNKNOWN_BASE_TYPE), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IScreenshotsApi : IScreenshotsApiSync, IScreenshotsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ScreenshotsApi : IScreenshotsApi
    {
        private Crowdin.Api.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScreenshotsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ScreenshotsApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScreenshotsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ScreenshotsApi(string basePath)
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
        /// Initializes a new instance of the <see cref="ScreenshotsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ScreenshotsApi(Crowdin.Api.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="ScreenshotsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public ScreenshotsApi(Crowdin.Api.Client.ISynchronousClient client, Crowdin.Api.Client.IAsynchronousClient asyncClient, Crowdin.Api.Client.IReadableConfiguration configuration)
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
        /// Delete Screenshot 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <returns></returns>
        public void ApiProjectsScreenshotsDelete(int projectId, int screenshotId)
        {
            ApiProjectsScreenshotsDeleteWithHttpInfo(projectId, screenshotId);
        }

        /// <summary>
        /// Delete Screenshot 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Crowdin.Api.Client.ApiResponse<Object> ApiProjectsScreenshotsDeleteWithHttpInfo(int projectId, int screenshotId)
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
            localVarRequestOptions.PathParameters.Add("screenshotId", Crowdin.Api.Client.ClientUtils.ParameterToString(screenshotId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/projects/{projectId}/screenshots/{screenshotId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsScreenshotsDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete Screenshot 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiProjectsScreenshotsDeleteAsync(int projectId, int screenshotId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiProjectsScreenshotsDeleteWithHttpInfoAsync(projectId, screenshotId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete Screenshot 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<Object>> ApiProjectsScreenshotsDeleteWithHttpInfoAsync(int projectId, int screenshotId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("screenshotId", Crowdin.Api.Client.ClientUtils.ParameterToString(screenshotId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/projects/{projectId}/screenshots/{screenshotId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsScreenshotsDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Screenshot 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <returns>ScreenshotResource</returns>
        public ScreenshotResource ApiProjectsScreenshotsGet(int projectId, int screenshotId)
        {
            Crowdin.Api.Client.ApiResponse<ScreenshotResource> localVarResponse = ApiProjectsScreenshotsGetWithHttpInfo(projectId, screenshotId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Screenshot 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <returns>ApiResponse of ScreenshotResource</returns>
        public Crowdin.Api.Client.ApiResponse<ScreenshotResource> ApiProjectsScreenshotsGetWithHttpInfo(int projectId, int screenshotId)
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
            localVarRequestOptions.PathParameters.Add("screenshotId", Crowdin.Api.Client.ClientUtils.ParameterToString(screenshotId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<ScreenshotResource>("/projects/{projectId}/screenshots/{screenshotId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsScreenshotsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Screenshot 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ScreenshotResource</returns>
        public async System.Threading.Tasks.Task<ScreenshotResource> ApiProjectsScreenshotsGetAsync(int projectId, int screenshotId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<ScreenshotResource> localVarResponse = await ApiProjectsScreenshotsGetWithHttpInfoAsync(projectId, screenshotId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Screenshot 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ScreenshotResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<ScreenshotResource>> ApiProjectsScreenshotsGetWithHttpInfoAsync(int projectId, int screenshotId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("screenshotId", Crowdin.Api.Client.ClientUtils.ParameterToString(screenshotId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<ScreenshotResource>("/projects/{projectId}/screenshots/{screenshotId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsScreenshotsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Screenshots 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ScreenshotCollectionResource</returns>
        public ScreenshotCollectionResource ApiProjectsScreenshotsGetMany(int projectId, int? limit = default(int?), int? offset = default(int?))
        {
            Crowdin.Api.Client.ApiResponse<ScreenshotCollectionResource> localVarResponse = ApiProjectsScreenshotsGetManyWithHttpInfo(projectId, limit, offset);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Screenshots 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of ScreenshotCollectionResource</returns>
        public Crowdin.Api.Client.ApiResponse<ScreenshotCollectionResource> ApiProjectsScreenshotsGetManyWithHttpInfo(int projectId, int? limit = default(int?), int? offset = default(int?))
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
            var localVarResponse = this.Client.Get<ScreenshotCollectionResource>("/projects/{projectId}/screenshots", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsScreenshotsGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Screenshots 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ScreenshotCollectionResource</returns>
        public async System.Threading.Tasks.Task<ScreenshotCollectionResource> ApiProjectsScreenshotsGetManyAsync(int projectId, int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<ScreenshotCollectionResource> localVarResponse = await ApiProjectsScreenshotsGetManyWithHttpInfoAsync(projectId, limit, offset, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Screenshots 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ScreenshotCollectionResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<ScreenshotCollectionResource>> ApiProjectsScreenshotsGetManyWithHttpInfoAsync(int projectId, int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            var localVarResponse = await this.AsynchronousClient.GetAsync<ScreenshotCollectionResource>("/projects/{projectId}/screenshots", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsScreenshotsGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Edit Screenshot 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="screenshotOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>ScreenshotResource</returns>
        public ScreenshotResource ApiProjectsScreenshotsPatch(int projectId, int screenshotId, List<ScreenshotOperation> screenshotOperation = default(List<ScreenshotOperation>))
        {
            Crowdin.Api.Client.ApiResponse<ScreenshotResource> localVarResponse = ApiProjectsScreenshotsPatchWithHttpInfo(projectId, screenshotId, screenshotOperation);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Edit Screenshot 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="screenshotOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>ApiResponse of ScreenshotResource</returns>
        public Crowdin.Api.Client.ApiResponse<ScreenshotResource> ApiProjectsScreenshotsPatchWithHttpInfo(int projectId, int screenshotId, List<ScreenshotOperation> screenshotOperation = default(List<ScreenshotOperation>))
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
            localVarRequestOptions.PathParameters.Add("screenshotId", Crowdin.Api.Client.ClientUtils.ParameterToString(screenshotId)); // path parameter
            localVarRequestOptions.Data = screenshotOperation;


            // make the HTTP request
            var localVarResponse = this.Client.Patch<ScreenshotResource>("/projects/{projectId}/screenshots/{screenshotId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsScreenshotsPatch", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Edit Screenshot 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="screenshotOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ScreenshotResource</returns>
        public async System.Threading.Tasks.Task<ScreenshotResource> ApiProjectsScreenshotsPatchAsync(int projectId, int screenshotId, List<ScreenshotOperation> screenshotOperation = default(List<ScreenshotOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<ScreenshotResource> localVarResponse = await ApiProjectsScreenshotsPatchWithHttpInfoAsync(projectId, screenshotId, screenshotOperation, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Edit Screenshot 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="screenshotOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ScreenshotResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<ScreenshotResource>> ApiProjectsScreenshotsPatchWithHttpInfoAsync(int projectId, int screenshotId, List<ScreenshotOperation> screenshotOperation = default(List<ScreenshotOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("screenshotId", Crowdin.Api.Client.ClientUtils.ParameterToString(screenshotId)); // path parameter
            localVarRequestOptions.Data = screenshotOperation;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PatchAsync<ScreenshotResource>("/projects/{projectId}/screenshots/{screenshotId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsScreenshotsPatch", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add Screenshot 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotCreateForm"> (optional)</param>
        /// <returns>ScreenshotResource</returns>
        public ScreenshotResource ApiProjectsScreenshotsPost(int projectId, ScreenshotCreateForm screenshotCreateForm = default(ScreenshotCreateForm))
        {
            Crowdin.Api.Client.ApiResponse<ScreenshotResource> localVarResponse = ApiProjectsScreenshotsPostWithHttpInfo(projectId, screenshotCreateForm);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add Screenshot 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotCreateForm"> (optional)</param>
        /// <returns>ApiResponse of ScreenshotResource</returns>
        public Crowdin.Api.Client.ApiResponse<ScreenshotResource> ApiProjectsScreenshotsPostWithHttpInfo(int projectId, ScreenshotCreateForm screenshotCreateForm = default(ScreenshotCreateForm))
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
            localVarRequestOptions.Data = screenshotCreateForm;


            // make the HTTP request
            var localVarResponse = this.Client.Post<ScreenshotResource>("/projects/{projectId}/screenshots", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsScreenshotsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add Screenshot 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ScreenshotResource</returns>
        public async System.Threading.Tasks.Task<ScreenshotResource> ApiProjectsScreenshotsPostAsync(int projectId, ScreenshotCreateForm screenshotCreateForm = default(ScreenshotCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<ScreenshotResource> localVarResponse = await ApiProjectsScreenshotsPostWithHttpInfoAsync(projectId, screenshotCreateForm, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add Screenshot 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ScreenshotResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<ScreenshotResource>> ApiProjectsScreenshotsPostWithHttpInfoAsync(int projectId, ScreenshotCreateForm screenshotCreateForm = default(ScreenshotCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.Data = screenshotCreateForm;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<ScreenshotResource>("/projects/{projectId}/screenshots", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsScreenshotsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update Screenshot 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="screenshotReplaceForm"> (optional)</param>
        /// <returns>ScreenshotResource</returns>
        public ScreenshotResource ApiProjectsScreenshotsPut(int projectId, int screenshotId, ScreenshotReplaceForm screenshotReplaceForm = default(ScreenshotReplaceForm))
        {
            Crowdin.Api.Client.ApiResponse<ScreenshotResource> localVarResponse = ApiProjectsScreenshotsPutWithHttpInfo(projectId, screenshotId, screenshotReplaceForm);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update Screenshot 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="screenshotReplaceForm"> (optional)</param>
        /// <returns>ApiResponse of ScreenshotResource</returns>
        public Crowdin.Api.Client.ApiResponse<ScreenshotResource> ApiProjectsScreenshotsPutWithHttpInfo(int projectId, int screenshotId, ScreenshotReplaceForm screenshotReplaceForm = default(ScreenshotReplaceForm))
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
            localVarRequestOptions.PathParameters.Add("screenshotId", Crowdin.Api.Client.ClientUtils.ParameterToString(screenshotId)); // path parameter
            localVarRequestOptions.Data = screenshotReplaceForm;


            // make the HTTP request
            var localVarResponse = this.Client.Put<ScreenshotResource>("/projects/{projectId}/screenshots/{screenshotId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsScreenshotsPut", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update Screenshot 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="screenshotReplaceForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ScreenshotResource</returns>
        public async System.Threading.Tasks.Task<ScreenshotResource> ApiProjectsScreenshotsPutAsync(int projectId, int screenshotId, ScreenshotReplaceForm screenshotReplaceForm = default(ScreenshotReplaceForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<ScreenshotResource> localVarResponse = await ApiProjectsScreenshotsPutWithHttpInfoAsync(projectId, screenshotId, screenshotReplaceForm, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update Screenshot 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="screenshotReplaceForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ScreenshotResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<ScreenshotResource>> ApiProjectsScreenshotsPutWithHttpInfoAsync(int projectId, int screenshotId, ScreenshotReplaceForm screenshotReplaceForm = default(ScreenshotReplaceForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("screenshotId", Crowdin.Api.Client.ClientUtils.ParameterToString(screenshotId)); // path parameter
            localVarRequestOptions.Data = screenshotReplaceForm;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PutAsync<ScreenshotResource>("/projects/{projectId}/screenshots/{screenshotId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsScreenshotsPut", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete Tag 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagId">Tag Identifier. Get via [List Tags](#operation/api.projects.screenshots.tags.getMany)</param>
        /// <returns></returns>
        public void ApiProjectsScreenshotsTagsDelete(int projectId, int screenshotId, int tagId)
        {
            ApiProjectsScreenshotsTagsDeleteWithHttpInfo(projectId, screenshotId, tagId);
        }

        /// <summary>
        /// Delete Tag 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagId">Tag Identifier. Get via [List Tags](#operation/api.projects.screenshots.tags.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Crowdin.Api.Client.ApiResponse<Object> ApiProjectsScreenshotsTagsDeleteWithHttpInfo(int projectId, int screenshotId, int tagId)
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
            localVarRequestOptions.PathParameters.Add("screenshotId", Crowdin.Api.Client.ClientUtils.ParameterToString(screenshotId)); // path parameter
            localVarRequestOptions.PathParameters.Add("tagId", Crowdin.Api.Client.ClientUtils.ParameterToString(tagId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/projects/{projectId}/screenshots/{screenshotId}/tags/{tagId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsScreenshotsTagsDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete Tag 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagId">Tag Identifier. Get via [List Tags](#operation/api.projects.screenshots.tags.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiProjectsScreenshotsTagsDeleteAsync(int projectId, int screenshotId, int tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiProjectsScreenshotsTagsDeleteWithHttpInfoAsync(projectId, screenshotId, tagId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete Tag 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagId">Tag Identifier. Get via [List Tags](#operation/api.projects.screenshots.tags.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<Object>> ApiProjectsScreenshotsTagsDeleteWithHttpInfoAsync(int projectId, int screenshotId, int tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("screenshotId", Crowdin.Api.Client.ClientUtils.ParameterToString(screenshotId)); // path parameter
            localVarRequestOptions.PathParameters.Add("tagId", Crowdin.Api.Client.ClientUtils.ParameterToString(tagId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/projects/{projectId}/screenshots/{screenshotId}/tags/{tagId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsScreenshotsTagsDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Clear Tags 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <returns></returns>
        public void ApiProjectsScreenshotsTagsDeleteMany(int projectId, int screenshotId)
        {
            ApiProjectsScreenshotsTagsDeleteManyWithHttpInfo(projectId, screenshotId);
        }

        /// <summary>
        /// Clear Tags 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Crowdin.Api.Client.ApiResponse<Object> ApiProjectsScreenshotsTagsDeleteManyWithHttpInfo(int projectId, int screenshotId)
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
            localVarRequestOptions.PathParameters.Add("screenshotId", Crowdin.Api.Client.ClientUtils.ParameterToString(screenshotId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/projects/{projectId}/screenshots/{screenshotId}/tags", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsScreenshotsTagsDeleteMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Clear Tags 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiProjectsScreenshotsTagsDeleteManyAsync(int projectId, int screenshotId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiProjectsScreenshotsTagsDeleteManyWithHttpInfoAsync(projectId, screenshotId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Clear Tags 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<Object>> ApiProjectsScreenshotsTagsDeleteManyWithHttpInfoAsync(int projectId, int screenshotId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("screenshotId", Crowdin.Api.Client.ClientUtils.ParameterToString(screenshotId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/projects/{projectId}/screenshots/{screenshotId}/tags", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsScreenshotsTagsDeleteMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Tag 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagId">Tag Identifier. Get via [List Tags](#operation/api.projects.screenshots.tags.getMany)</param>
        /// <returns>TagResource</returns>
        public TagResource ApiProjectsScreenshotsTagsGet(int projectId, int screenshotId, int tagId)
        {
            Crowdin.Api.Client.ApiResponse<TagResource> localVarResponse = ApiProjectsScreenshotsTagsGetWithHttpInfo(projectId, screenshotId, tagId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Tag 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagId">Tag Identifier. Get via [List Tags](#operation/api.projects.screenshots.tags.getMany)</param>
        /// <returns>ApiResponse of TagResource</returns>
        public Crowdin.Api.Client.ApiResponse<TagResource> ApiProjectsScreenshotsTagsGetWithHttpInfo(int projectId, int screenshotId, int tagId)
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
            localVarRequestOptions.PathParameters.Add("screenshotId", Crowdin.Api.Client.ClientUtils.ParameterToString(screenshotId)); // path parameter
            localVarRequestOptions.PathParameters.Add("tagId", Crowdin.Api.Client.ClientUtils.ParameterToString(tagId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<TagResource>("/projects/{projectId}/screenshots/{screenshotId}/tags/{tagId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsScreenshotsTagsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Tag 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagId">Tag Identifier. Get via [List Tags](#operation/api.projects.screenshots.tags.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TagResource</returns>
        public async System.Threading.Tasks.Task<TagResource> ApiProjectsScreenshotsTagsGetAsync(int projectId, int screenshotId, int tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<TagResource> localVarResponse = await ApiProjectsScreenshotsTagsGetWithHttpInfoAsync(projectId, screenshotId, tagId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Tag 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagId">Tag Identifier. Get via [List Tags](#operation/api.projects.screenshots.tags.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TagResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<TagResource>> ApiProjectsScreenshotsTagsGetWithHttpInfoAsync(int projectId, int screenshotId, int tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("screenshotId", Crowdin.Api.Client.ClientUtils.ParameterToString(screenshotId)); // path parameter
            localVarRequestOptions.PathParameters.Add("tagId", Crowdin.Api.Client.ClientUtils.ParameterToString(tagId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<TagResource>("/projects/{projectId}/screenshots/{screenshotId}/tags/{tagId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsScreenshotsTagsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Tags 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>TagCollectionResource</returns>
        public TagCollectionResource ApiProjectsScreenshotsTagsGetMany(int projectId, int screenshotId, int? limit = default(int?), int? offset = default(int?))
        {
            Crowdin.Api.Client.ApiResponse<TagCollectionResource> localVarResponse = ApiProjectsScreenshotsTagsGetManyWithHttpInfo(projectId, screenshotId, limit, offset);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Tags 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of TagCollectionResource</returns>
        public Crowdin.Api.Client.ApiResponse<TagCollectionResource> ApiProjectsScreenshotsTagsGetManyWithHttpInfo(int projectId, int screenshotId, int? limit = default(int?), int? offset = default(int?))
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
            localVarRequestOptions.PathParameters.Add("screenshotId", Crowdin.Api.Client.ClientUtils.ParameterToString(screenshotId)); // path parameter
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (offset != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "offset", offset));
            }


            // make the HTTP request
            var localVarResponse = this.Client.Get<TagCollectionResource>("/projects/{projectId}/screenshots/{screenshotId}/tags", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsScreenshotsTagsGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Tags 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TagCollectionResource</returns>
        public async System.Threading.Tasks.Task<TagCollectionResource> ApiProjectsScreenshotsTagsGetManyAsync(int projectId, int screenshotId, int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<TagCollectionResource> localVarResponse = await ApiProjectsScreenshotsTagsGetManyWithHttpInfoAsync(projectId, screenshotId, limit, offset, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Tags 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TagCollectionResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<TagCollectionResource>> ApiProjectsScreenshotsTagsGetManyWithHttpInfoAsync(int projectId, int screenshotId, int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("screenshotId", Crowdin.Api.Client.ClientUtils.ParameterToString(screenshotId)); // path parameter
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (offset != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "offset", offset));
            }


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<TagCollectionResource>("/projects/{projectId}/screenshots/{screenshotId}/tags", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsScreenshotsTagsGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Edit Tag 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagId">Tag Identifier. Get via [List Tags](#operation/api.projects.screenshots.tags.getMany)</param>
        /// <param name="tagOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>ScreenshotResource</returns>
        public ScreenshotResource ApiProjectsScreenshotsTagsPatch(int projectId, int screenshotId, int tagId, List<TagOperation> tagOperation = default(List<TagOperation>))
        {
            Crowdin.Api.Client.ApiResponse<ScreenshotResource> localVarResponse = ApiProjectsScreenshotsTagsPatchWithHttpInfo(projectId, screenshotId, tagId, tagOperation);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Edit Tag 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagId">Tag Identifier. Get via [List Tags](#operation/api.projects.screenshots.tags.getMany)</param>
        /// <param name="tagOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>ApiResponse of ScreenshotResource</returns>
        public Crowdin.Api.Client.ApiResponse<ScreenshotResource> ApiProjectsScreenshotsTagsPatchWithHttpInfo(int projectId, int screenshotId, int tagId, List<TagOperation> tagOperation = default(List<TagOperation>))
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
            localVarRequestOptions.PathParameters.Add("screenshotId", Crowdin.Api.Client.ClientUtils.ParameterToString(screenshotId)); // path parameter
            localVarRequestOptions.PathParameters.Add("tagId", Crowdin.Api.Client.ClientUtils.ParameterToString(tagId)); // path parameter
            localVarRequestOptions.Data = tagOperation;


            // make the HTTP request
            var localVarResponse = this.Client.Patch<ScreenshotResource>("/projects/{projectId}/screenshots/{screenshotId}/tags/{tagId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsScreenshotsTagsPatch", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Edit Tag 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagId">Tag Identifier. Get via [List Tags](#operation/api.projects.screenshots.tags.getMany)</param>
        /// <param name="tagOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ScreenshotResource</returns>
        public async System.Threading.Tasks.Task<ScreenshotResource> ApiProjectsScreenshotsTagsPatchAsync(int projectId, int screenshotId, int tagId, List<TagOperation> tagOperation = default(List<TagOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<ScreenshotResource> localVarResponse = await ApiProjectsScreenshotsTagsPatchWithHttpInfoAsync(projectId, screenshotId, tagId, tagOperation, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Edit Tag 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagId">Tag Identifier. Get via [List Tags](#operation/api.projects.screenshots.tags.getMany)</param>
        /// <param name="tagOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ScreenshotResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<ScreenshotResource>> ApiProjectsScreenshotsTagsPatchWithHttpInfoAsync(int projectId, int screenshotId, int tagId, List<TagOperation> tagOperation = default(List<TagOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("screenshotId", Crowdin.Api.Client.ClientUtils.ParameterToString(screenshotId)); // path parameter
            localVarRequestOptions.PathParameters.Add("tagId", Crowdin.Api.Client.ClientUtils.ParameterToString(tagId)); // path parameter
            localVarRequestOptions.Data = tagOperation;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PatchAsync<ScreenshotResource>("/projects/{projectId}/screenshots/{screenshotId}/tags/{tagId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsScreenshotsTagsPatch", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add Tag 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagCreateForm"> (optional)</param>
        /// <returns>TagResource</returns>
        public TagResource ApiProjectsScreenshotsTagsPost(int projectId, int screenshotId, List<TagCreateForm> tagCreateForm = default(List<TagCreateForm>))
        {
            Crowdin.Api.Client.ApiResponse<TagResource> localVarResponse = ApiProjectsScreenshotsTagsPostWithHttpInfo(projectId, screenshotId, tagCreateForm);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add Tag 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagCreateForm"> (optional)</param>
        /// <returns>ApiResponse of TagResource</returns>
        public Crowdin.Api.Client.ApiResponse<TagResource> ApiProjectsScreenshotsTagsPostWithHttpInfo(int projectId, int screenshotId, List<TagCreateForm> tagCreateForm = default(List<TagCreateForm>))
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
            localVarRequestOptions.PathParameters.Add("screenshotId", Crowdin.Api.Client.ClientUtils.ParameterToString(screenshotId)); // path parameter
            localVarRequestOptions.Data = tagCreateForm;


            // make the HTTP request
            var localVarResponse = this.Client.Post<TagResource>("/projects/{projectId}/screenshots/{screenshotId}/tags", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsScreenshotsTagsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add Tag 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TagResource</returns>
        public async System.Threading.Tasks.Task<TagResource> ApiProjectsScreenshotsTagsPostAsync(int projectId, int screenshotId, List<TagCreateForm> tagCreateForm = default(List<TagCreateForm>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<TagResource> localVarResponse = await ApiProjectsScreenshotsTagsPostWithHttpInfoAsync(projectId, screenshotId, tagCreateForm, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add Tag 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="tagCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TagResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<TagResource>> ApiProjectsScreenshotsTagsPostWithHttpInfoAsync(int projectId, int screenshotId, List<TagCreateForm> tagCreateForm = default(List<TagCreateForm>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("screenshotId", Crowdin.Api.Client.ClientUtils.ParameterToString(screenshotId)); // path parameter
            localVarRequestOptions.Data = tagCreateForm;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<TagResource>("/projects/{projectId}/screenshots/{screenshotId}/tags", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsScreenshotsTagsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Replace Tags (Auto Tag) 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="UNKNOWN_BASE_TYPE"> (optional)</param>
        /// <returns></returns>
        public void ApiProjectsScreenshotsTagsPutMany(int projectId, int screenshotId, UNKNOWN_BASE_TYPE UNKNOWN_BASE_TYPE = default(UNKNOWN_BASE_TYPE))
        {
            ApiProjectsScreenshotsTagsPutManyWithHttpInfo(projectId, screenshotId, UNKNOWN_BASE_TYPE);
        }

        /// <summary>
        /// Replace Tags (Auto Tag) 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="UNKNOWN_BASE_TYPE"> (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Crowdin.Api.Client.ApiResponse<Object> ApiProjectsScreenshotsTagsPutManyWithHttpInfo(int projectId, int screenshotId, UNKNOWN_BASE_TYPE UNKNOWN_BASE_TYPE = default(UNKNOWN_BASE_TYPE))
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
            localVarRequestOptions.PathParameters.Add("screenshotId", Crowdin.Api.Client.ClientUtils.ParameterToString(screenshotId)); // path parameter
            localVarRequestOptions.Data = UNKNOWN_BASE_TYPE;


            // make the HTTP request
            var localVarResponse = this.Client.Put<Object>("/projects/{projectId}/screenshots/{screenshotId}/tags", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsScreenshotsTagsPutMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Replace Tags (Auto Tag) 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="UNKNOWN_BASE_TYPE"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiProjectsScreenshotsTagsPutManyAsync(int projectId, int screenshotId, UNKNOWN_BASE_TYPE UNKNOWN_BASE_TYPE = default(UNKNOWN_BASE_TYPE), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiProjectsScreenshotsTagsPutManyWithHttpInfoAsync(projectId, screenshotId, UNKNOWN_BASE_TYPE, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Replace Tags (Auto Tag) 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="screenshotId">Screenshot Identifier. Get via [List Screenshots](#operation/api.projects.screenshots.getMany)</param>
        /// <param name="UNKNOWN_BASE_TYPE"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<Object>> ApiProjectsScreenshotsTagsPutManyWithHttpInfoAsync(int projectId, int screenshotId, UNKNOWN_BASE_TYPE UNKNOWN_BASE_TYPE = default(UNKNOWN_BASE_TYPE), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("screenshotId", Crowdin.Api.Client.ClientUtils.ParameterToString(screenshotId)); // path parameter
            localVarRequestOptions.Data = UNKNOWN_BASE_TYPE;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PutAsync<Object>("/projects/{projectId}/screenshots/{screenshotId}/tags", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsScreenshotsTagsPutMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
