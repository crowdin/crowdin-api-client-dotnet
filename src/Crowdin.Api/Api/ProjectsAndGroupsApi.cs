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
    public interface IProjectsAndGroupsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Delete Group
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)</param>
        /// <returns></returns>
        void ApiGroupsDelete(int groupId);

        /// <summary>
        /// Delete Group
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiGroupsDeleteWithHttpInfo(int groupId);
        /// <summary>
        /// Get Group
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)</param>
        /// <returns>GroupResource</returns>
        GroupResource ApiGroupsGet(int groupId);

        /// <summary>
        /// Get Group
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)</param>
        /// <returns>ApiResponse of GroupResource</returns>
        ApiResponse<GroupResource> ApiGroupsGetWithHttpInfo(int groupId);
        /// <summary>
        /// List Groups
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parentId">Parent Group Identifier. Get via [List Groups](#operation/api.groups.getMany)  __Note__: Set 0 to see groups of root group (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>GroupCollectionResource</returns>
        GroupCollectionResource ApiGroupsGetMany(int? parentId = default(int?), int? limit = default(int?), int? offset = default(int?));

        /// <summary>
        /// List Groups
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parentId">Parent Group Identifier. Get via [List Groups](#operation/api.groups.getMany)  __Note__: Set 0 to see groups of root group (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of GroupCollectionResource</returns>
        ApiResponse<GroupCollectionResource> ApiGroupsGetManyWithHttpInfo(int? parentId = default(int?), int? limit = default(int?), int? offset = default(int?));
        /// <summary>
        /// Edit Group
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)</param>
        /// <param name="groupOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>GroupResource</returns>
        GroupResource ApiGroupsPatch(int groupId, List<GroupOperation> groupOperation = default(List<GroupOperation>));

        /// <summary>
        /// Edit Group
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)</param>
        /// <param name="groupOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>ApiResponse of GroupResource</returns>
        ApiResponse<GroupResource> ApiGroupsPatchWithHttpInfo(int groupId, List<GroupOperation> groupOperation = default(List<GroupOperation>));
        /// <summary>
        /// Add Group
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupCreateForm"> (optional)</param>
        /// <returns>GroupResource</returns>
        GroupResource ApiGroupsPost(GroupCreateForm groupCreateForm = default(GroupCreateForm));

        /// <summary>
        /// Add Group
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupCreateForm"> (optional)</param>
        /// <returns>ApiResponse of GroupResource</returns>
        ApiResponse<GroupResource> ApiGroupsPostWithHttpInfo(GroupCreateForm groupCreateForm = default(GroupCreateForm));
        /// <summary>
        /// Delete Project
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <returns></returns>
        void ApiProjectsDelete(int projectId);

        /// <summary>
        /// Delete Project
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiProjectsDeleteWithHttpInfo(int projectId);
        /// <summary>
        /// Get Project
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <returns>OneOfProjectResponseProjectSettingsResponse</returns>
        OneOfProjectResponseProjectSettingsResponse ApiProjectsGet(int projectId);

        /// <summary>
        /// Get Project
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <returns>ApiResponse of OneOfProjectResponseProjectSettingsResponse</returns>
        ApiResponse<OneOfProjectResponseProjectSettingsResponse> ApiProjectsGetWithHttpInfo(int projectId);
        /// <summary>
        /// List Projects
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)  __Note__: Set 0 to see items of root group (optional)</param>
        /// <param name="hasManagerAccess">Projects with Manager Access  *          0 - false  *          1 - true (optional, default to 0)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>EnterpriseProjectCollectionResource</returns>
        EnterpriseProjectCollectionResource ApiProjectsGetMany(int? groupId = default(int?), int? hasManagerAccess = default(int?), int? limit = default(int?), int? offset = default(int?));

        /// <summary>
        /// List Projects
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)  __Note__: Set 0 to see items of root group (optional)</param>
        /// <param name="hasManagerAccess">Projects with Manager Access  *          0 - false  *          1 - true (optional, default to 0)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of EnterpriseProjectCollectionResource</returns>
        ApiResponse<EnterpriseProjectCollectionResource> ApiProjectsGetManyWithHttpInfo(int? groupId = default(int?), int? hasManagerAccess = default(int?), int? limit = default(int?), int? offset = default(int?));
        /// <summary>
        /// Edit Project
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="oneOfProjectInfoOperationProjectSettingOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>OneOfProjectResponseProjectSettingsResponse</returns>
        OneOfProjectResponseProjectSettingsResponse ApiProjectsPatch(int projectId, List<OneOfProjectInfoOperationProjectSettingOperation> oneOfProjectInfoOperationProjectSettingOperation = default(List<OneOfProjectInfoOperationProjectSettingOperation>));

        /// <summary>
        /// Edit Project
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="oneOfProjectInfoOperationProjectSettingOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>ApiResponse of OneOfProjectResponseProjectSettingsResponse</returns>
        ApiResponse<OneOfProjectResponseProjectSettingsResponse> ApiProjectsPatchWithHttpInfo(int projectId, List<OneOfProjectInfoOperationProjectSettingOperation> oneOfProjectInfoOperationProjectSettingOperation = default(List<OneOfProjectInfoOperationProjectSettingOperation>));
        /// <summary>
        /// Add Project
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enterpriseProjectCreateForm"> (optional)</param>
        /// <returns>OneOfProjectResponseProjectSettingsResponse</returns>
        OneOfProjectResponseProjectSettingsResponse ApiProjectsPost(EnterpriseProjectCreateForm enterpriseProjectCreateForm = default(EnterpriseProjectCreateForm));

        /// <summary>
        /// Add Project
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enterpriseProjectCreateForm"> (optional)</param>
        /// <returns>ApiResponse of OneOfProjectResponseProjectSettingsResponse</returns>
        ApiResponse<OneOfProjectResponseProjectSettingsResponse> ApiProjectsPostWithHttpInfo(EnterpriseProjectCreateForm enterpriseProjectCreateForm = default(EnterpriseProjectCreateForm));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IProjectsAndGroupsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Delete Group
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiGroupsDeleteAsync(int groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete Group
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiGroupsDeleteWithHttpInfoAsync(int groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get Group
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GroupResource</returns>
        System.Threading.Tasks.Task<GroupResource> ApiGroupsGetAsync(int groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get Group
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GroupResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<GroupResource>> ApiGroupsGetWithHttpInfoAsync(int groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List Groups
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parentId">Parent Group Identifier. Get via [List Groups](#operation/api.groups.getMany)  __Note__: Set 0 to see groups of root group (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GroupCollectionResource</returns>
        System.Threading.Tasks.Task<GroupCollectionResource> ApiGroupsGetManyAsync(int? parentId = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List Groups
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parentId">Parent Group Identifier. Get via [List Groups](#operation/api.groups.getMany)  __Note__: Set 0 to see groups of root group (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GroupCollectionResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<GroupCollectionResource>> ApiGroupsGetManyWithHttpInfoAsync(int? parentId = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Edit Group
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)</param>
        /// <param name="groupOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GroupResource</returns>
        System.Threading.Tasks.Task<GroupResource> ApiGroupsPatchAsync(int groupId, List<GroupOperation> groupOperation = default(List<GroupOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Edit Group
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)</param>
        /// <param name="groupOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GroupResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<GroupResource>> ApiGroupsPatchWithHttpInfoAsync(int groupId, List<GroupOperation> groupOperation = default(List<GroupOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Add Group
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GroupResource</returns>
        System.Threading.Tasks.Task<GroupResource> ApiGroupsPostAsync(GroupCreateForm groupCreateForm = default(GroupCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Add Group
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GroupResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<GroupResource>> ApiGroupsPostWithHttpInfoAsync(GroupCreateForm groupCreateForm = default(GroupCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Delete Project
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiProjectsDeleteAsync(int projectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete Project
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiProjectsDeleteWithHttpInfoAsync(int projectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get Project
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of OneOfProjectResponseProjectSettingsResponse</returns>
        System.Threading.Tasks.Task<OneOfProjectResponseProjectSettingsResponse> ApiProjectsGetAsync(int projectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get Project
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (OneOfProjectResponseProjectSettingsResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<OneOfProjectResponseProjectSettingsResponse>> ApiProjectsGetWithHttpInfoAsync(int projectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List Projects
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)  __Note__: Set 0 to see items of root group (optional)</param>
        /// <param name="hasManagerAccess">Projects with Manager Access  *          0 - false  *          1 - true (optional, default to 0)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of EnterpriseProjectCollectionResource</returns>
        System.Threading.Tasks.Task<EnterpriseProjectCollectionResource> ApiProjectsGetManyAsync(int? groupId = default(int?), int? hasManagerAccess = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List Projects
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)  __Note__: Set 0 to see items of root group (optional)</param>
        /// <param name="hasManagerAccess">Projects with Manager Access  *          0 - false  *          1 - true (optional, default to 0)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (EnterpriseProjectCollectionResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<EnterpriseProjectCollectionResource>> ApiProjectsGetManyWithHttpInfoAsync(int? groupId = default(int?), int? hasManagerAccess = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Edit Project
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="oneOfProjectInfoOperationProjectSettingOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of OneOfProjectResponseProjectSettingsResponse</returns>
        System.Threading.Tasks.Task<OneOfProjectResponseProjectSettingsResponse> ApiProjectsPatchAsync(int projectId, List<OneOfProjectInfoOperationProjectSettingOperation> oneOfProjectInfoOperationProjectSettingOperation = default(List<OneOfProjectInfoOperationProjectSettingOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Edit Project
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="oneOfProjectInfoOperationProjectSettingOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (OneOfProjectResponseProjectSettingsResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<OneOfProjectResponseProjectSettingsResponse>> ApiProjectsPatchWithHttpInfoAsync(int projectId, List<OneOfProjectInfoOperationProjectSettingOperation> oneOfProjectInfoOperationProjectSettingOperation = default(List<OneOfProjectInfoOperationProjectSettingOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Add Project
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enterpriseProjectCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of OneOfProjectResponseProjectSettingsResponse</returns>
        System.Threading.Tasks.Task<OneOfProjectResponseProjectSettingsResponse> ApiProjectsPostAsync(EnterpriseProjectCreateForm enterpriseProjectCreateForm = default(EnterpriseProjectCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Add Project
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enterpriseProjectCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (OneOfProjectResponseProjectSettingsResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<OneOfProjectResponseProjectSettingsResponse>> ApiProjectsPostWithHttpInfoAsync(EnterpriseProjectCreateForm enterpriseProjectCreateForm = default(EnterpriseProjectCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IProjectsAndGroupsApi : IProjectsAndGroupsApiSync, IProjectsAndGroupsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ProjectsAndGroupsApi : IProjectsAndGroupsApi
    {
        private Crowdin.Api.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectsAndGroupsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ProjectsAndGroupsApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectsAndGroupsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ProjectsAndGroupsApi(string basePath)
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
        /// Initializes a new instance of the <see cref="ProjectsAndGroupsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ProjectsAndGroupsApi(Crowdin.Api.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="ProjectsAndGroupsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public ProjectsAndGroupsApi(Crowdin.Api.Client.ISynchronousClient client, Crowdin.Api.Client.IAsynchronousClient asyncClient, Crowdin.Api.Client.IReadableConfiguration configuration)
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
        /// Delete Group 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)</param>
        /// <returns></returns>
        public void ApiGroupsDelete(int groupId)
        {
            ApiGroupsDeleteWithHttpInfo(groupId);
        }

        /// <summary>
        /// Delete Group 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Crowdin.Api.Client.ApiResponse<Object> ApiGroupsDeleteWithHttpInfo(int groupId)
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

            localVarRequestOptions.PathParameters.Add("groupId", Crowdin.Api.Client.ClientUtils.ParameterToString(groupId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/groups/{groupId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGroupsDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete Group 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiGroupsDeleteAsync(int groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiGroupsDeleteWithHttpInfoAsync(groupId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete Group 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<Object>> ApiGroupsDeleteWithHttpInfoAsync(int groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("groupId", Crowdin.Api.Client.ClientUtils.ParameterToString(groupId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/groups/{groupId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGroupsDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Group 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)</param>
        /// <returns>GroupResource</returns>
        public GroupResource ApiGroupsGet(int groupId)
        {
            Crowdin.Api.Client.ApiResponse<GroupResource> localVarResponse = ApiGroupsGetWithHttpInfo(groupId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Group 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)</param>
        /// <returns>ApiResponse of GroupResource</returns>
        public Crowdin.Api.Client.ApiResponse<GroupResource> ApiGroupsGetWithHttpInfo(int groupId)
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

            localVarRequestOptions.PathParameters.Add("groupId", Crowdin.Api.Client.ClientUtils.ParameterToString(groupId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<GroupResource>("/groups/{groupId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGroupsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Group 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GroupResource</returns>
        public async System.Threading.Tasks.Task<GroupResource> ApiGroupsGetAsync(int groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<GroupResource> localVarResponse = await ApiGroupsGetWithHttpInfoAsync(groupId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Group 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GroupResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<GroupResource>> ApiGroupsGetWithHttpInfoAsync(int groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("groupId", Crowdin.Api.Client.ClientUtils.ParameterToString(groupId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<GroupResource>("/groups/{groupId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGroupsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Groups 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parentId">Parent Group Identifier. Get via [List Groups](#operation/api.groups.getMany)  __Note__: Set 0 to see groups of root group (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>GroupCollectionResource</returns>
        public GroupCollectionResource ApiGroupsGetMany(int? parentId = default(int?), int? limit = default(int?), int? offset = default(int?))
        {
            Crowdin.Api.Client.ApiResponse<GroupCollectionResource> localVarResponse = ApiGroupsGetManyWithHttpInfo(parentId, limit, offset);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Groups 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parentId">Parent Group Identifier. Get via [List Groups](#operation/api.groups.getMany)  __Note__: Set 0 to see groups of root group (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of GroupCollectionResource</returns>
        public Crowdin.Api.Client.ApiResponse<GroupCollectionResource> ApiGroupsGetManyWithHttpInfo(int? parentId = default(int?), int? limit = default(int?), int? offset = default(int?))
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

            if (parentId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "parentId", parentId));
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
            var localVarResponse = this.Client.Get<GroupCollectionResource>("/groups", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGroupsGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Groups 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parentId">Parent Group Identifier. Get via [List Groups](#operation/api.groups.getMany)  __Note__: Set 0 to see groups of root group (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GroupCollectionResource</returns>
        public async System.Threading.Tasks.Task<GroupCollectionResource> ApiGroupsGetManyAsync(int? parentId = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<GroupCollectionResource> localVarResponse = await ApiGroupsGetManyWithHttpInfoAsync(parentId, limit, offset, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Groups 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parentId">Parent Group Identifier. Get via [List Groups](#operation/api.groups.getMany)  __Note__: Set 0 to see groups of root group (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GroupCollectionResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<GroupCollectionResource>> ApiGroupsGetManyWithHttpInfoAsync(int? parentId = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            if (parentId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "parentId", parentId));
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

            var localVarResponse = await this.AsynchronousClient.GetAsync<GroupCollectionResource>("/groups", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGroupsGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Edit Group 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)</param>
        /// <param name="groupOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>GroupResource</returns>
        public GroupResource ApiGroupsPatch(int groupId, List<GroupOperation> groupOperation = default(List<GroupOperation>))
        {
            Crowdin.Api.Client.ApiResponse<GroupResource> localVarResponse = ApiGroupsPatchWithHttpInfo(groupId, groupOperation);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Edit Group 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)</param>
        /// <param name="groupOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>ApiResponse of GroupResource</returns>
        public Crowdin.Api.Client.ApiResponse<GroupResource> ApiGroupsPatchWithHttpInfo(int groupId, List<GroupOperation> groupOperation = default(List<GroupOperation>))
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

            localVarRequestOptions.PathParameters.Add("groupId", Crowdin.Api.Client.ClientUtils.ParameterToString(groupId)); // path parameter
            localVarRequestOptions.Data = groupOperation;


            // make the HTTP request
            var localVarResponse = this.Client.Patch<GroupResource>("/groups/{groupId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGroupsPatch", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Edit Group 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)</param>
        /// <param name="groupOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GroupResource</returns>
        public async System.Threading.Tasks.Task<GroupResource> ApiGroupsPatchAsync(int groupId, List<GroupOperation> groupOperation = default(List<GroupOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<GroupResource> localVarResponse = await ApiGroupsPatchWithHttpInfoAsync(groupId, groupOperation, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Edit Group 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)</param>
        /// <param name="groupOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GroupResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<GroupResource>> ApiGroupsPatchWithHttpInfoAsync(int groupId, List<GroupOperation> groupOperation = default(List<GroupOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("groupId", Crowdin.Api.Client.ClientUtils.ParameterToString(groupId)); // path parameter
            localVarRequestOptions.Data = groupOperation;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PatchAsync<GroupResource>("/groups/{groupId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGroupsPatch", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add Group 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupCreateForm"> (optional)</param>
        /// <returns>GroupResource</returns>
        public GroupResource ApiGroupsPost(GroupCreateForm groupCreateForm = default(GroupCreateForm))
        {
            Crowdin.Api.Client.ApiResponse<GroupResource> localVarResponse = ApiGroupsPostWithHttpInfo(groupCreateForm);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add Group 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupCreateForm"> (optional)</param>
        /// <returns>ApiResponse of GroupResource</returns>
        public Crowdin.Api.Client.ApiResponse<GroupResource> ApiGroupsPostWithHttpInfo(GroupCreateForm groupCreateForm = default(GroupCreateForm))
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

            localVarRequestOptions.Data = groupCreateForm;


            // make the HTTP request
            var localVarResponse = this.Client.Post<GroupResource>("/groups", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGroupsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add Group 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GroupResource</returns>
        public async System.Threading.Tasks.Task<GroupResource> ApiGroupsPostAsync(GroupCreateForm groupCreateForm = default(GroupCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<GroupResource> localVarResponse = await ApiGroupsPostWithHttpInfoAsync(groupCreateForm, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add Group 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GroupResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<GroupResource>> ApiGroupsPostWithHttpInfoAsync(GroupCreateForm groupCreateForm = default(GroupCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.Data = groupCreateForm;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<GroupResource>("/groups", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGroupsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete Project 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <returns></returns>
        public void ApiProjectsDelete(int projectId)
        {
            ApiProjectsDeleteWithHttpInfo(projectId);
        }

        /// <summary>
        /// Delete Project 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Crowdin.Api.Client.ApiResponse<Object> ApiProjectsDeleteWithHttpInfo(int projectId)
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


            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/projects/{projectId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete Project 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiProjectsDeleteAsync(int projectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiProjectsDeleteWithHttpInfoAsync(projectId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete Project 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<Object>> ApiProjectsDeleteWithHttpInfoAsync(int projectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/projects/{projectId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Project 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <returns>OneOfProjectResponseProjectSettingsResponse</returns>
        public OneOfProjectResponseProjectSettingsResponse ApiProjectsGet(int projectId)
        {
            Crowdin.Api.Client.ApiResponse<OneOfProjectResponseProjectSettingsResponse> localVarResponse = ApiProjectsGetWithHttpInfo(projectId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Project 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <returns>ApiResponse of OneOfProjectResponseProjectSettingsResponse</returns>
        public Crowdin.Api.Client.ApiResponse<OneOfProjectResponseProjectSettingsResponse> ApiProjectsGetWithHttpInfo(int projectId)
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


            // make the HTTP request
            var localVarResponse = this.Client.Get<OneOfProjectResponseProjectSettingsResponse>("/projects/{projectId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Project 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of OneOfProjectResponseProjectSettingsResponse</returns>
        public async System.Threading.Tasks.Task<OneOfProjectResponseProjectSettingsResponse> ApiProjectsGetAsync(int projectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<OneOfProjectResponseProjectSettingsResponse> localVarResponse = await ApiProjectsGetWithHttpInfoAsync(projectId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Project 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (OneOfProjectResponseProjectSettingsResponse)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<OneOfProjectResponseProjectSettingsResponse>> ApiProjectsGetWithHttpInfoAsync(int projectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<OneOfProjectResponseProjectSettingsResponse>("/projects/{projectId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Projects 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)  __Note__: Set 0 to see items of root group (optional)</param>
        /// <param name="hasManagerAccess">Projects with Manager Access  *          0 - false  *          1 - true (optional, default to 0)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>EnterpriseProjectCollectionResource</returns>
        public EnterpriseProjectCollectionResource ApiProjectsGetMany(int? groupId = default(int?), int? hasManagerAccess = default(int?), int? limit = default(int?), int? offset = default(int?))
        {
            Crowdin.Api.Client.ApiResponse<EnterpriseProjectCollectionResource> localVarResponse = ApiProjectsGetManyWithHttpInfo(groupId, hasManagerAccess, limit, offset);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Projects 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)  __Note__: Set 0 to see items of root group (optional)</param>
        /// <param name="hasManagerAccess">Projects with Manager Access  *          0 - false  *          1 - true (optional, default to 0)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of EnterpriseProjectCollectionResource</returns>
        public Crowdin.Api.Client.ApiResponse<EnterpriseProjectCollectionResource> ApiProjectsGetManyWithHttpInfo(int? groupId = default(int?), int? hasManagerAccess = default(int?), int? limit = default(int?), int? offset = default(int?))
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
            if (hasManagerAccess != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "hasManagerAccess", hasManagerAccess));
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
            var localVarResponse = this.Client.Get<EnterpriseProjectCollectionResource>("/projects", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Projects 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)  __Note__: Set 0 to see items of root group (optional)</param>
        /// <param name="hasManagerAccess">Projects with Manager Access  *          0 - false  *          1 - true (optional, default to 0)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of EnterpriseProjectCollectionResource</returns>
        public async System.Threading.Tasks.Task<EnterpriseProjectCollectionResource> ApiProjectsGetManyAsync(int? groupId = default(int?), int? hasManagerAccess = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<EnterpriseProjectCollectionResource> localVarResponse = await ApiProjectsGetManyWithHttpInfoAsync(groupId, hasManagerAccess, limit, offset, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Projects 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="groupId">Group Identifier. Get via [List Groups](#operation/api.groups.getMany)  __Note__: Set 0 to see items of root group (optional)</param>
        /// <param name="hasManagerAccess">Projects with Manager Access  *          0 - false  *          1 - true (optional, default to 0)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (EnterpriseProjectCollectionResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<EnterpriseProjectCollectionResource>> ApiProjectsGetManyWithHttpInfoAsync(int? groupId = default(int?), int? hasManagerAccess = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            if (hasManagerAccess != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "hasManagerAccess", hasManagerAccess));
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

            var localVarResponse = await this.AsynchronousClient.GetAsync<EnterpriseProjectCollectionResource>("/projects", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Edit Project 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="oneOfProjectInfoOperationProjectSettingOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>OneOfProjectResponseProjectSettingsResponse</returns>
        public OneOfProjectResponseProjectSettingsResponse ApiProjectsPatch(int projectId, List<OneOfProjectInfoOperationProjectSettingOperation> oneOfProjectInfoOperationProjectSettingOperation = default(List<OneOfProjectInfoOperationProjectSettingOperation>))
        {
            Crowdin.Api.Client.ApiResponse<OneOfProjectResponseProjectSettingsResponse> localVarResponse = ApiProjectsPatchWithHttpInfo(projectId, oneOfProjectInfoOperationProjectSettingOperation);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Edit Project 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="oneOfProjectInfoOperationProjectSettingOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>ApiResponse of OneOfProjectResponseProjectSettingsResponse</returns>
        public Crowdin.Api.Client.ApiResponse<OneOfProjectResponseProjectSettingsResponse> ApiProjectsPatchWithHttpInfo(int projectId, List<OneOfProjectInfoOperationProjectSettingOperation> oneOfProjectInfoOperationProjectSettingOperation = default(List<OneOfProjectInfoOperationProjectSettingOperation>))
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
            localVarRequestOptions.Data = oneOfProjectInfoOperationProjectSettingOperation;


            // make the HTTP request
            var localVarResponse = this.Client.Patch<OneOfProjectResponseProjectSettingsResponse>("/projects/{projectId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsPatch", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Edit Project 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="oneOfProjectInfoOperationProjectSettingOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of OneOfProjectResponseProjectSettingsResponse</returns>
        public async System.Threading.Tasks.Task<OneOfProjectResponseProjectSettingsResponse> ApiProjectsPatchAsync(int projectId, List<OneOfProjectInfoOperationProjectSettingOperation> oneOfProjectInfoOperationProjectSettingOperation = default(List<OneOfProjectInfoOperationProjectSettingOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<OneOfProjectResponseProjectSettingsResponse> localVarResponse = await ApiProjectsPatchWithHttpInfoAsync(projectId, oneOfProjectInfoOperationProjectSettingOperation, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Edit Project 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="oneOfProjectInfoOperationProjectSettingOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (OneOfProjectResponseProjectSettingsResponse)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<OneOfProjectResponseProjectSettingsResponse>> ApiProjectsPatchWithHttpInfoAsync(int projectId, List<OneOfProjectInfoOperationProjectSettingOperation> oneOfProjectInfoOperationProjectSettingOperation = default(List<OneOfProjectInfoOperationProjectSettingOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.Data = oneOfProjectInfoOperationProjectSettingOperation;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PatchAsync<OneOfProjectResponseProjectSettingsResponse>("/projects/{projectId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsPatch", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add Project 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enterpriseProjectCreateForm"> (optional)</param>
        /// <returns>OneOfProjectResponseProjectSettingsResponse</returns>
        public OneOfProjectResponseProjectSettingsResponse ApiProjectsPost(EnterpriseProjectCreateForm enterpriseProjectCreateForm = default(EnterpriseProjectCreateForm))
        {
            Crowdin.Api.Client.ApiResponse<OneOfProjectResponseProjectSettingsResponse> localVarResponse = ApiProjectsPostWithHttpInfo(enterpriseProjectCreateForm);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add Project 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enterpriseProjectCreateForm"> (optional)</param>
        /// <returns>ApiResponse of OneOfProjectResponseProjectSettingsResponse</returns>
        public Crowdin.Api.Client.ApiResponse<OneOfProjectResponseProjectSettingsResponse> ApiProjectsPostWithHttpInfo(EnterpriseProjectCreateForm enterpriseProjectCreateForm = default(EnterpriseProjectCreateForm))
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

            localVarRequestOptions.Data = enterpriseProjectCreateForm;


            // make the HTTP request
            var localVarResponse = this.Client.Post<OneOfProjectResponseProjectSettingsResponse>("/projects", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add Project 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enterpriseProjectCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of OneOfProjectResponseProjectSettingsResponse</returns>
        public async System.Threading.Tasks.Task<OneOfProjectResponseProjectSettingsResponse> ApiProjectsPostAsync(EnterpriseProjectCreateForm enterpriseProjectCreateForm = default(EnterpriseProjectCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<OneOfProjectResponseProjectSettingsResponse> localVarResponse = await ApiProjectsPostWithHttpInfoAsync(enterpriseProjectCreateForm, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add Project 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="enterpriseProjectCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (OneOfProjectResponseProjectSettingsResponse)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<OneOfProjectResponseProjectSettingsResponse>> ApiProjectsPostWithHttpInfoAsync(EnterpriseProjectCreateForm enterpriseProjectCreateForm = default(EnterpriseProjectCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.Data = enterpriseProjectCreateForm;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<OneOfProjectResponseProjectSettingsResponse>("/projects", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
