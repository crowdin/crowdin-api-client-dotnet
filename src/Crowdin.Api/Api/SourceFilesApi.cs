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
    public interface ISourceFilesApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Delete Branch
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Branch Identifier. Get via [List Branches](#operation/api.projects.branches.getMany)</param>
        /// <returns></returns>
        void ApiProjectsBranchesDelete(int projectId, int branchId);

        /// <summary>
        /// Delete Branch
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Branch Identifier. Get via [List Branches](#operation/api.projects.branches.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiProjectsBranchesDeleteWithHttpInfo(int projectId, int branchId);
        /// <summary>
        /// Get Branch
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Branch Identifier. Get via [List Branches](#operation/api.projects.branches.getMany)</param>
        /// <returns>BranchResource</returns>
        BranchResource ApiProjectsBranchesGet(int projectId, int branchId);

        /// <summary>
        /// Get Branch
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Branch Identifier. Get via [List Branches](#operation/api.projects.branches.getMany)</param>
        /// <returns>ApiResponse of BranchResource</returns>
        ApiResponse<BranchResource> ApiProjectsBranchesGetWithHttpInfo(int projectId, int branchId);
        /// <summary>
        /// List Branches
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="name">Filter branch by name (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>BranchCollectionResource</returns>
        BranchCollectionResource ApiProjectsBranchesGetMany(int projectId, string name = default(string), int? limit = default(int?), int? offset = default(int?));

        /// <summary>
        /// List Branches
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="name">Filter branch by name (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of BranchCollectionResource</returns>
        ApiResponse<BranchCollectionResource> ApiProjectsBranchesGetManyWithHttpInfo(int projectId, string name = default(string), int? limit = default(int?), int? offset = default(int?));
        /// <summary>
        /// Edit Branch
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Branch Identifier. Get via [List Branches](#operation/api.projects.branches.getMany)</param>
        /// <param name="branchOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>BranchResource</returns>
        BranchResource ApiProjectsBranchesPatch(int projectId, int branchId, List<BranchOperation> branchOperation = default(List<BranchOperation>));

        /// <summary>
        /// Edit Branch
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Branch Identifier. Get via [List Branches](#operation/api.projects.branches.getMany)</param>
        /// <param name="branchOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>ApiResponse of BranchResource</returns>
        ApiResponse<BranchResource> ApiProjectsBranchesPatchWithHttpInfo(int projectId, int branchId, List<BranchOperation> branchOperation = default(List<BranchOperation>));
        /// <summary>
        /// Add Branch
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchCreateForm"> (optional)</param>
        /// <returns>BranchResource</returns>
        BranchResource ApiProjectsBranchesPost(int projectId, BranchCreateForm branchCreateForm = default(BranchCreateForm));

        /// <summary>
        /// Add Branch
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchCreateForm"> (optional)</param>
        /// <returns>ApiResponse of BranchResource</returns>
        ApiResponse<BranchResource> ApiProjectsBranchesPostWithHttpInfo(int projectId, BranchCreateForm branchCreateForm = default(BranchCreateForm));
        /// <summary>
        /// Delete Directory
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <returns></returns>
        void ApiProjectsDirectoriesDelete(int projectId, int directoryId);

        /// <summary>
        /// Delete Directory
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiProjectsDirectoriesDeleteWithHttpInfo(int projectId, int directoryId);
        /// <summary>
        /// Get Directory
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <returns>DirectoryResource</returns>
        DirectoryResource ApiProjectsDirectoriesGet(int projectId, int directoryId);

        /// <summary>
        /// Get Directory
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <returns>ApiResponse of DirectoryResource</returns>
        ApiResponse<DirectoryResource> ApiProjectsDirectoriesGetWithHttpInfo(int projectId, int directoryId);
        /// <summary>
        /// List Directories
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Filter directories by &#x60;branchId&#x60;  __Note:__ Can&#39;t be used with &#x60;directoryId&#x60; in the same request (optional)</param>
        /// <param name="directoryId">Filter directories by &#x60;directoryId&#x60;  __Note:__ Can&#39;t be used with &#x60;branchId&#x60; in the same request (optional)</param>
        /// <param name="filter">Filter directories by &#x60;name&#x60; (optional)</param>
        /// <param name="recursion">Use to list directories recursively  __Note:__ Works only when &#x60;directoryId&#x60; or &#x60;branchId&#x60; parameter is specified (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>DirectoryCollectionResource</returns>
        DirectoryCollectionResource ApiProjectsDirectoriesGetMany(int projectId, int? branchId = default(int?), int? directoryId = default(int?), string filter = default(string), Object recursion = default(Object), int? limit = default(int?), int? offset = default(int?));

        /// <summary>
        /// List Directories
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Filter directories by &#x60;branchId&#x60;  __Note:__ Can&#39;t be used with &#x60;directoryId&#x60; in the same request (optional)</param>
        /// <param name="directoryId">Filter directories by &#x60;directoryId&#x60;  __Note:__ Can&#39;t be used with &#x60;branchId&#x60; in the same request (optional)</param>
        /// <param name="filter">Filter directories by &#x60;name&#x60; (optional)</param>
        /// <param name="recursion">Use to list directories recursively  __Note:__ Works only when &#x60;directoryId&#x60; or &#x60;branchId&#x60; parameter is specified (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of DirectoryCollectionResource</returns>
        ApiResponse<DirectoryCollectionResource> ApiProjectsDirectoriesGetManyWithHttpInfo(int projectId, int? branchId = default(int?), int? directoryId = default(int?), string filter = default(string), Object recursion = default(Object), int? limit = default(int?), int? offset = default(int?));
        /// <summary>
        /// Edit Directory
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <param name="directoryOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>DirectoryResource</returns>
        DirectoryResource ApiProjectsDirectoriesPatch(int projectId, int directoryId, List<DirectoryOperation> directoryOperation = default(List<DirectoryOperation>));

        /// <summary>
        /// Edit Directory
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <param name="directoryOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>ApiResponse of DirectoryResource</returns>
        ApiResponse<DirectoryResource> ApiProjectsDirectoriesPatchWithHttpInfo(int projectId, int directoryId, List<DirectoryOperation> directoryOperation = default(List<DirectoryOperation>));
        /// <summary>
        /// Add Directory
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryCreateForm"> (optional)</param>
        /// <returns>DirectoryResource</returns>
        DirectoryResource ApiProjectsDirectoriesPost(int projectId, DirectoryCreateForm directoryCreateForm = default(DirectoryCreateForm));

        /// <summary>
        /// Add Directory
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryCreateForm"> (optional)</param>
        /// <returns>ApiResponse of DirectoryResource</returns>
        ApiResponse<DirectoryResource> ApiProjectsDirectoriesPostWithHttpInfo(int projectId, DirectoryCreateForm directoryCreateForm = default(DirectoryCreateForm));
        /// <summary>
        /// Delete File
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <returns></returns>
        void ApiProjectsFilesDelete(int projectId, int fileId);

        /// <summary>
        /// Delete File
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiProjectsFilesDeleteWithHttpInfo(int projectId, int fileId);
        /// <summary>
        /// Download File
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <returns>DownloadLinkResource</returns>
        DownloadLinkResource ApiProjectsFilesDownloadGet(int projectId, int fileId);

        /// <summary>
        /// Download File
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <returns>ApiResponse of DownloadLinkResource</returns>
        ApiResponse<DownloadLinkResource> ApiProjectsFilesDownloadGetWithHttpInfo(int projectId, int fileId);
        /// <summary>
        /// Get File
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <returns>OneOfFileInfoResourceFileResource</returns>
        OneOfFileInfoResourceFileResource ApiProjectsFilesGet(int projectId, int fileId);

        /// <summary>
        /// Get File
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <returns>ApiResponse of OneOfFileInfoResourceFileResource</returns>
        ApiResponse<OneOfFileInfoResourceFileResource> ApiProjectsFilesGetWithHttpInfo(int projectId, int fileId);
        /// <summary>
        /// List Files
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">List branch files  __Note:__ Can&#39;t be used with &#x60;directoryId&#x60; in the same request (optional)</param>
        /// <param name="directoryId">List directory files  __Note:__ Can&#39;t be used with &#x60;branchId&#x60; in the same request (optional)</param>
        /// <param name="filter">Filter files by &#x60;name&#x60; (optional)</param>
        /// <param name="recursion">Use to list files recursively  __Note:__ Works only when &#x60;directoryId&#x60; or &#x60;branchId&#x60; parameter is specified (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>OneOfFileInfoCollectionResourceFileCollectionResource</returns>
        OneOfFileInfoCollectionResourceFileCollectionResource ApiProjectsFilesGetMany(int projectId, int? branchId = default(int?), int? directoryId = default(int?), string filter = default(string), Object recursion = default(Object), int? limit = default(int?), int? offset = default(int?));

        /// <summary>
        /// List Files
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">List branch files  __Note:__ Can&#39;t be used with &#x60;directoryId&#x60; in the same request (optional)</param>
        /// <param name="directoryId">List directory files  __Note:__ Can&#39;t be used with &#x60;branchId&#x60; in the same request (optional)</param>
        /// <param name="filter">Filter files by &#x60;name&#x60; (optional)</param>
        /// <param name="recursion">Use to list files recursively  __Note:__ Works only when &#x60;directoryId&#x60; or &#x60;branchId&#x60; parameter is specified (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of OneOfFileInfoCollectionResourceFileCollectionResource</returns>
        ApiResponse<OneOfFileInfoCollectionResourceFileCollectionResource> ApiProjectsFilesGetManyWithHttpInfo(int projectId, int? branchId = default(int?), int? directoryId = default(int?), string filter = default(string), Object recursion = default(Object), int? limit = default(int?), int? offset = default(int?));
        /// <summary>
        /// Edit File
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="fileOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>FileResource</returns>
        FileResource ApiProjectsFilesPatch(int projectId, int fileId, List<FileOperation> fileOperation = default(List<FileOperation>));

        /// <summary>
        /// Edit File
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="fileOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>ApiResponse of FileResource</returns>
        ApiResponse<FileResource> ApiProjectsFilesPatchWithHttpInfo(int projectId, int fileId, List<FileOperation> fileOperation = default(List<FileOperation>));
        /// <summary>
        /// Add File
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileCreateForm"> (optional)</param>
        /// <returns>FileResource</returns>
        FileResource ApiProjectsFilesPost(int projectId, FileCreateForm fileCreateForm = default(FileCreateForm));

        /// <summary>
        /// Add File
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileCreateForm"> (optional)</param>
        /// <returns>ApiResponse of FileResource</returns>
        ApiResponse<FileResource> ApiProjectsFilesPostWithHttpInfo(int projectId, FileCreateForm fileCreateForm = default(FileCreateForm));
        /// <summary>
        /// Update or Restore File
        /// </summary>
        /// <remarks>
        /// Update your current file with a new one or restore it to one of the previous revisions
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="UNKNOWN_BASE_TYPE"> (optional)</param>
        /// <returns>FileResource</returns>
        FileResource ApiProjectsFilesPut(int projectId, int fileId, UNKNOWN_BASE_TYPE UNKNOWN_BASE_TYPE = default(UNKNOWN_BASE_TYPE));

        /// <summary>
        /// Update or Restore File
        /// </summary>
        /// <remarks>
        /// Update your current file with a new one or restore it to one of the previous revisions
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="UNKNOWN_BASE_TYPE"> (optional)</param>
        /// <returns>ApiResponse of FileResource</returns>
        ApiResponse<FileResource> ApiProjectsFilesPutWithHttpInfo(int projectId, int fileId, UNKNOWN_BASE_TYPE UNKNOWN_BASE_TYPE = default(UNKNOWN_BASE_TYPE));
        /// <summary>
        /// Get File Revision
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="revisionId">Revision Identifier. Get via [List File Revisions](#operation/api.projects.files.getMany)</param>
        /// <returns>RevisionResource</returns>
        RevisionResource ApiProjectsFilesRevisionsGet(int projectId, int fileId, int revisionId);

        /// <summary>
        /// Get File Revision
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="revisionId">Revision Identifier. Get via [List File Revisions](#operation/api.projects.files.getMany)</param>
        /// <returns>ApiResponse of RevisionResource</returns>
        ApiResponse<RevisionResource> ApiProjectsFilesRevisionsGetWithHttpInfo(int projectId, int fileId, int revisionId);
        /// <summary>
        /// List File Revisions
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>RevisionCollectionResource</returns>
        RevisionCollectionResource ApiProjectsFilesRevisionsGetMany(int projectId, int fileId, int? limit = default(int?), int? offset = default(int?));

        /// <summary>
        /// List File Revisions
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of RevisionCollectionResource</returns>
        ApiResponse<RevisionCollectionResource> ApiProjectsFilesRevisionsGetManyWithHttpInfo(int projectId, int fileId, int? limit = default(int?), int? offset = default(int?));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ISourceFilesApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Delete Branch
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Branch Identifier. Get via [List Branches](#operation/api.projects.branches.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiProjectsBranchesDeleteAsync(int projectId, int branchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete Branch
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Branch Identifier. Get via [List Branches](#operation/api.projects.branches.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiProjectsBranchesDeleteWithHttpInfoAsync(int projectId, int branchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get Branch
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Branch Identifier. Get via [List Branches](#operation/api.projects.branches.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of BranchResource</returns>
        System.Threading.Tasks.Task<BranchResource> ApiProjectsBranchesGetAsync(int projectId, int branchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get Branch
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Branch Identifier. Get via [List Branches](#operation/api.projects.branches.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (BranchResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<BranchResource>> ApiProjectsBranchesGetWithHttpInfoAsync(int projectId, int branchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List Branches
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="name">Filter branch by name (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of BranchCollectionResource</returns>
        System.Threading.Tasks.Task<BranchCollectionResource> ApiProjectsBranchesGetManyAsync(int projectId, string name = default(string), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List Branches
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="name">Filter branch by name (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (BranchCollectionResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<BranchCollectionResource>> ApiProjectsBranchesGetManyWithHttpInfoAsync(int projectId, string name = default(string), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Edit Branch
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Branch Identifier. Get via [List Branches](#operation/api.projects.branches.getMany)</param>
        /// <param name="branchOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of BranchResource</returns>
        System.Threading.Tasks.Task<BranchResource> ApiProjectsBranchesPatchAsync(int projectId, int branchId, List<BranchOperation> branchOperation = default(List<BranchOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Edit Branch
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Branch Identifier. Get via [List Branches](#operation/api.projects.branches.getMany)</param>
        /// <param name="branchOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (BranchResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<BranchResource>> ApiProjectsBranchesPatchWithHttpInfoAsync(int projectId, int branchId, List<BranchOperation> branchOperation = default(List<BranchOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Add Branch
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of BranchResource</returns>
        System.Threading.Tasks.Task<BranchResource> ApiProjectsBranchesPostAsync(int projectId, BranchCreateForm branchCreateForm = default(BranchCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Add Branch
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (BranchResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<BranchResource>> ApiProjectsBranchesPostWithHttpInfoAsync(int projectId, BranchCreateForm branchCreateForm = default(BranchCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Delete Directory
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiProjectsDirectoriesDeleteAsync(int projectId, int directoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete Directory
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiProjectsDirectoriesDeleteWithHttpInfoAsync(int projectId, int directoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get Directory
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DirectoryResource</returns>
        System.Threading.Tasks.Task<DirectoryResource> ApiProjectsDirectoriesGetAsync(int projectId, int directoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get Directory
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DirectoryResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<DirectoryResource>> ApiProjectsDirectoriesGetWithHttpInfoAsync(int projectId, int directoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List Directories
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Filter directories by &#x60;branchId&#x60;  __Note:__ Can&#39;t be used with &#x60;directoryId&#x60; in the same request (optional)</param>
        /// <param name="directoryId">Filter directories by &#x60;directoryId&#x60;  __Note:__ Can&#39;t be used with &#x60;branchId&#x60; in the same request (optional)</param>
        /// <param name="filter">Filter directories by &#x60;name&#x60; (optional)</param>
        /// <param name="recursion">Use to list directories recursively  __Note:__ Works only when &#x60;directoryId&#x60; or &#x60;branchId&#x60; parameter is specified (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DirectoryCollectionResource</returns>
        System.Threading.Tasks.Task<DirectoryCollectionResource> ApiProjectsDirectoriesGetManyAsync(int projectId, int? branchId = default(int?), int? directoryId = default(int?), string filter = default(string), Object recursion = default(Object), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List Directories
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Filter directories by &#x60;branchId&#x60;  __Note:__ Can&#39;t be used with &#x60;directoryId&#x60; in the same request (optional)</param>
        /// <param name="directoryId">Filter directories by &#x60;directoryId&#x60;  __Note:__ Can&#39;t be used with &#x60;branchId&#x60; in the same request (optional)</param>
        /// <param name="filter">Filter directories by &#x60;name&#x60; (optional)</param>
        /// <param name="recursion">Use to list directories recursively  __Note:__ Works only when &#x60;directoryId&#x60; or &#x60;branchId&#x60; parameter is specified (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DirectoryCollectionResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<DirectoryCollectionResource>> ApiProjectsDirectoriesGetManyWithHttpInfoAsync(int projectId, int? branchId = default(int?), int? directoryId = default(int?), string filter = default(string), Object recursion = default(Object), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Edit Directory
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <param name="directoryOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DirectoryResource</returns>
        System.Threading.Tasks.Task<DirectoryResource> ApiProjectsDirectoriesPatchAsync(int projectId, int directoryId, List<DirectoryOperation> directoryOperation = default(List<DirectoryOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Edit Directory
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <param name="directoryOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DirectoryResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<DirectoryResource>> ApiProjectsDirectoriesPatchWithHttpInfoAsync(int projectId, int directoryId, List<DirectoryOperation> directoryOperation = default(List<DirectoryOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Add Directory
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DirectoryResource</returns>
        System.Threading.Tasks.Task<DirectoryResource> ApiProjectsDirectoriesPostAsync(int projectId, DirectoryCreateForm directoryCreateForm = default(DirectoryCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Add Directory
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DirectoryResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<DirectoryResource>> ApiProjectsDirectoriesPostWithHttpInfoAsync(int projectId, DirectoryCreateForm directoryCreateForm = default(DirectoryCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Delete File
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiProjectsFilesDeleteAsync(int projectId, int fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete File
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiProjectsFilesDeleteWithHttpInfoAsync(int projectId, int fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Download File
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DownloadLinkResource</returns>
        System.Threading.Tasks.Task<DownloadLinkResource> ApiProjectsFilesDownloadGetAsync(int projectId, int fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Download File
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DownloadLinkResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<DownloadLinkResource>> ApiProjectsFilesDownloadGetWithHttpInfoAsync(int projectId, int fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get File
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of OneOfFileInfoResourceFileResource</returns>
        System.Threading.Tasks.Task<OneOfFileInfoResourceFileResource> ApiProjectsFilesGetAsync(int projectId, int fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get File
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (OneOfFileInfoResourceFileResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<OneOfFileInfoResourceFileResource>> ApiProjectsFilesGetWithHttpInfoAsync(int projectId, int fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List Files
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">List branch files  __Note:__ Can&#39;t be used with &#x60;directoryId&#x60; in the same request (optional)</param>
        /// <param name="directoryId">List directory files  __Note:__ Can&#39;t be used with &#x60;branchId&#x60; in the same request (optional)</param>
        /// <param name="filter">Filter files by &#x60;name&#x60; (optional)</param>
        /// <param name="recursion">Use to list files recursively  __Note:__ Works only when &#x60;directoryId&#x60; or &#x60;branchId&#x60; parameter is specified (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of OneOfFileInfoCollectionResourceFileCollectionResource</returns>
        System.Threading.Tasks.Task<OneOfFileInfoCollectionResourceFileCollectionResource> ApiProjectsFilesGetManyAsync(int projectId, int? branchId = default(int?), int? directoryId = default(int?), string filter = default(string), Object recursion = default(Object), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List Files
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">List branch files  __Note:__ Can&#39;t be used with &#x60;directoryId&#x60; in the same request (optional)</param>
        /// <param name="directoryId">List directory files  __Note:__ Can&#39;t be used with &#x60;branchId&#x60; in the same request (optional)</param>
        /// <param name="filter">Filter files by &#x60;name&#x60; (optional)</param>
        /// <param name="recursion">Use to list files recursively  __Note:__ Works only when &#x60;directoryId&#x60; or &#x60;branchId&#x60; parameter is specified (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (OneOfFileInfoCollectionResourceFileCollectionResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<OneOfFileInfoCollectionResourceFileCollectionResource>> ApiProjectsFilesGetManyWithHttpInfoAsync(int projectId, int? branchId = default(int?), int? directoryId = default(int?), string filter = default(string), Object recursion = default(Object), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Edit File
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="fileOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of FileResource</returns>
        System.Threading.Tasks.Task<FileResource> ApiProjectsFilesPatchAsync(int projectId, int fileId, List<FileOperation> fileOperation = default(List<FileOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Edit File
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="fileOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (FileResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<FileResource>> ApiProjectsFilesPatchWithHttpInfoAsync(int projectId, int fileId, List<FileOperation> fileOperation = default(List<FileOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Add File
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of FileResource</returns>
        System.Threading.Tasks.Task<FileResource> ApiProjectsFilesPostAsync(int projectId, FileCreateForm fileCreateForm = default(FileCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Add File
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (FileResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<FileResource>> ApiProjectsFilesPostWithHttpInfoAsync(int projectId, FileCreateForm fileCreateForm = default(FileCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update or Restore File
        /// </summary>
        /// <remarks>
        /// Update your current file with a new one or restore it to one of the previous revisions
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="UNKNOWN_BASE_TYPE"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of FileResource</returns>
        System.Threading.Tasks.Task<FileResource> ApiProjectsFilesPutAsync(int projectId, int fileId, UNKNOWN_BASE_TYPE UNKNOWN_BASE_TYPE = default(UNKNOWN_BASE_TYPE), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Update or Restore File
        /// </summary>
        /// <remarks>
        /// Update your current file with a new one or restore it to one of the previous revisions
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="UNKNOWN_BASE_TYPE"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (FileResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<FileResource>> ApiProjectsFilesPutWithHttpInfoAsync(int projectId, int fileId, UNKNOWN_BASE_TYPE UNKNOWN_BASE_TYPE = default(UNKNOWN_BASE_TYPE), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get File Revision
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="revisionId">Revision Identifier. Get via [List File Revisions](#operation/api.projects.files.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of RevisionResource</returns>
        System.Threading.Tasks.Task<RevisionResource> ApiProjectsFilesRevisionsGetAsync(int projectId, int fileId, int revisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get File Revision
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="revisionId">Revision Identifier. Get via [List File Revisions](#operation/api.projects.files.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (RevisionResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<RevisionResource>> ApiProjectsFilesRevisionsGetWithHttpInfoAsync(int projectId, int fileId, int revisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List File Revisions
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of RevisionCollectionResource</returns>
        System.Threading.Tasks.Task<RevisionCollectionResource> ApiProjectsFilesRevisionsGetManyAsync(int projectId, int fileId, int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List File Revisions
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (RevisionCollectionResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<RevisionCollectionResource>> ApiProjectsFilesRevisionsGetManyWithHttpInfoAsync(int projectId, int fileId, int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ISourceFilesApi : ISourceFilesApiSync, ISourceFilesApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class SourceFilesApi : ISourceFilesApi
    {
        private Crowdin.Api.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SourceFilesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public SourceFilesApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SourceFilesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public SourceFilesApi(string basePath)
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
        /// Initializes a new instance of the <see cref="SourceFilesApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public SourceFilesApi(Crowdin.Api.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="SourceFilesApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public SourceFilesApi(Crowdin.Api.Client.ISynchronousClient client, Crowdin.Api.Client.IAsynchronousClient asyncClient, Crowdin.Api.Client.IReadableConfiguration configuration)
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
        /// Delete Branch 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Branch Identifier. Get via [List Branches](#operation/api.projects.branches.getMany)</param>
        /// <returns></returns>
        public void ApiProjectsBranchesDelete(int projectId, int branchId)
        {
            ApiProjectsBranchesDeleteWithHttpInfo(projectId, branchId);
        }

        /// <summary>
        /// Delete Branch 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Branch Identifier. Get via [List Branches](#operation/api.projects.branches.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Crowdin.Api.Client.ApiResponse<Object> ApiProjectsBranchesDeleteWithHttpInfo(int projectId, int branchId)
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
            localVarRequestOptions.PathParameters.Add("branchId", Crowdin.Api.Client.ClientUtils.ParameterToString(branchId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/projects/{projectId}/branches/{branchId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsBranchesDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete Branch 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Branch Identifier. Get via [List Branches](#operation/api.projects.branches.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiProjectsBranchesDeleteAsync(int projectId, int branchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiProjectsBranchesDeleteWithHttpInfoAsync(projectId, branchId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete Branch 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Branch Identifier. Get via [List Branches](#operation/api.projects.branches.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<Object>> ApiProjectsBranchesDeleteWithHttpInfoAsync(int projectId, int branchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("branchId", Crowdin.Api.Client.ClientUtils.ParameterToString(branchId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/projects/{projectId}/branches/{branchId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsBranchesDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Branch 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Branch Identifier. Get via [List Branches](#operation/api.projects.branches.getMany)</param>
        /// <returns>BranchResource</returns>
        public BranchResource ApiProjectsBranchesGet(int projectId, int branchId)
        {
            Crowdin.Api.Client.ApiResponse<BranchResource> localVarResponse = ApiProjectsBranchesGetWithHttpInfo(projectId, branchId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Branch 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Branch Identifier. Get via [List Branches](#operation/api.projects.branches.getMany)</param>
        /// <returns>ApiResponse of BranchResource</returns>
        public Crowdin.Api.Client.ApiResponse<BranchResource> ApiProjectsBranchesGetWithHttpInfo(int projectId, int branchId)
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
            localVarRequestOptions.PathParameters.Add("branchId", Crowdin.Api.Client.ClientUtils.ParameterToString(branchId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<BranchResource>("/projects/{projectId}/branches/{branchId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsBranchesGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Branch 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Branch Identifier. Get via [List Branches](#operation/api.projects.branches.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of BranchResource</returns>
        public async System.Threading.Tasks.Task<BranchResource> ApiProjectsBranchesGetAsync(int projectId, int branchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<BranchResource> localVarResponse = await ApiProjectsBranchesGetWithHttpInfoAsync(projectId, branchId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Branch 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Branch Identifier. Get via [List Branches](#operation/api.projects.branches.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (BranchResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<BranchResource>> ApiProjectsBranchesGetWithHttpInfoAsync(int projectId, int branchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("branchId", Crowdin.Api.Client.ClientUtils.ParameterToString(branchId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<BranchResource>("/projects/{projectId}/branches/{branchId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsBranchesGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Branches 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="name">Filter branch by name (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>BranchCollectionResource</returns>
        public BranchCollectionResource ApiProjectsBranchesGetMany(int projectId, string name = default(string), int? limit = default(int?), int? offset = default(int?))
        {
            Crowdin.Api.Client.ApiResponse<BranchCollectionResource> localVarResponse = ApiProjectsBranchesGetManyWithHttpInfo(projectId, name, limit, offset);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Branches 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="name">Filter branch by name (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of BranchCollectionResource</returns>
        public Crowdin.Api.Client.ApiResponse<BranchCollectionResource> ApiProjectsBranchesGetManyWithHttpInfo(int projectId, string name = default(string), int? limit = default(int?), int? offset = default(int?))
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
            if (name != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "name", name));
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
            var localVarResponse = this.Client.Get<BranchCollectionResource>("/projects/{projectId}/branches", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsBranchesGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Branches 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="name">Filter branch by name (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of BranchCollectionResource</returns>
        public async System.Threading.Tasks.Task<BranchCollectionResource> ApiProjectsBranchesGetManyAsync(int projectId, string name = default(string), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<BranchCollectionResource> localVarResponse = await ApiProjectsBranchesGetManyWithHttpInfoAsync(projectId, name, limit, offset, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Branches 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="name">Filter branch by name (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (BranchCollectionResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<BranchCollectionResource>> ApiProjectsBranchesGetManyWithHttpInfoAsync(int projectId, string name = default(string), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            if (name != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "name", name));
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

            var localVarResponse = await this.AsynchronousClient.GetAsync<BranchCollectionResource>("/projects/{projectId}/branches", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsBranchesGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Edit Branch 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Branch Identifier. Get via [List Branches](#operation/api.projects.branches.getMany)</param>
        /// <param name="branchOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>BranchResource</returns>
        public BranchResource ApiProjectsBranchesPatch(int projectId, int branchId, List<BranchOperation> branchOperation = default(List<BranchOperation>))
        {
            Crowdin.Api.Client.ApiResponse<BranchResource> localVarResponse = ApiProjectsBranchesPatchWithHttpInfo(projectId, branchId, branchOperation);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Edit Branch 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Branch Identifier. Get via [List Branches](#operation/api.projects.branches.getMany)</param>
        /// <param name="branchOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>ApiResponse of BranchResource</returns>
        public Crowdin.Api.Client.ApiResponse<BranchResource> ApiProjectsBranchesPatchWithHttpInfo(int projectId, int branchId, List<BranchOperation> branchOperation = default(List<BranchOperation>))
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
            localVarRequestOptions.PathParameters.Add("branchId", Crowdin.Api.Client.ClientUtils.ParameterToString(branchId)); // path parameter
            localVarRequestOptions.Data = branchOperation;


            // make the HTTP request
            var localVarResponse = this.Client.Patch<BranchResource>("/projects/{projectId}/branches/{branchId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsBranchesPatch", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Edit Branch 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Branch Identifier. Get via [List Branches](#operation/api.projects.branches.getMany)</param>
        /// <param name="branchOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of BranchResource</returns>
        public async System.Threading.Tasks.Task<BranchResource> ApiProjectsBranchesPatchAsync(int projectId, int branchId, List<BranchOperation> branchOperation = default(List<BranchOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<BranchResource> localVarResponse = await ApiProjectsBranchesPatchWithHttpInfoAsync(projectId, branchId, branchOperation, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Edit Branch 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Branch Identifier. Get via [List Branches](#operation/api.projects.branches.getMany)</param>
        /// <param name="branchOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (BranchResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<BranchResource>> ApiProjectsBranchesPatchWithHttpInfoAsync(int projectId, int branchId, List<BranchOperation> branchOperation = default(List<BranchOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("branchId", Crowdin.Api.Client.ClientUtils.ParameterToString(branchId)); // path parameter
            localVarRequestOptions.Data = branchOperation;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PatchAsync<BranchResource>("/projects/{projectId}/branches/{branchId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsBranchesPatch", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add Branch 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchCreateForm"> (optional)</param>
        /// <returns>BranchResource</returns>
        public BranchResource ApiProjectsBranchesPost(int projectId, BranchCreateForm branchCreateForm = default(BranchCreateForm))
        {
            Crowdin.Api.Client.ApiResponse<BranchResource> localVarResponse = ApiProjectsBranchesPostWithHttpInfo(projectId, branchCreateForm);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add Branch 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchCreateForm"> (optional)</param>
        /// <returns>ApiResponse of BranchResource</returns>
        public Crowdin.Api.Client.ApiResponse<BranchResource> ApiProjectsBranchesPostWithHttpInfo(int projectId, BranchCreateForm branchCreateForm = default(BranchCreateForm))
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
            localVarRequestOptions.Data = branchCreateForm;


            // make the HTTP request
            var localVarResponse = this.Client.Post<BranchResource>("/projects/{projectId}/branches", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsBranchesPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add Branch 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of BranchResource</returns>
        public async System.Threading.Tasks.Task<BranchResource> ApiProjectsBranchesPostAsync(int projectId, BranchCreateForm branchCreateForm = default(BranchCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<BranchResource> localVarResponse = await ApiProjectsBranchesPostWithHttpInfoAsync(projectId, branchCreateForm, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add Branch 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (BranchResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<BranchResource>> ApiProjectsBranchesPostWithHttpInfoAsync(int projectId, BranchCreateForm branchCreateForm = default(BranchCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.Data = branchCreateForm;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<BranchResource>("/projects/{projectId}/branches", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsBranchesPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete Directory 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <returns></returns>
        public void ApiProjectsDirectoriesDelete(int projectId, int directoryId)
        {
            ApiProjectsDirectoriesDeleteWithHttpInfo(projectId, directoryId);
        }

        /// <summary>
        /// Delete Directory 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Crowdin.Api.Client.ApiResponse<Object> ApiProjectsDirectoriesDeleteWithHttpInfo(int projectId, int directoryId)
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
            localVarRequestOptions.PathParameters.Add("directoryId", Crowdin.Api.Client.ClientUtils.ParameterToString(directoryId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/projects/{projectId}/directories/{directoryId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsDirectoriesDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete Directory 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiProjectsDirectoriesDeleteAsync(int projectId, int directoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiProjectsDirectoriesDeleteWithHttpInfoAsync(projectId, directoryId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete Directory 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<Object>> ApiProjectsDirectoriesDeleteWithHttpInfoAsync(int projectId, int directoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("directoryId", Crowdin.Api.Client.ClientUtils.ParameterToString(directoryId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/projects/{projectId}/directories/{directoryId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsDirectoriesDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Directory 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <returns>DirectoryResource</returns>
        public DirectoryResource ApiProjectsDirectoriesGet(int projectId, int directoryId)
        {
            Crowdin.Api.Client.ApiResponse<DirectoryResource> localVarResponse = ApiProjectsDirectoriesGetWithHttpInfo(projectId, directoryId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Directory 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <returns>ApiResponse of DirectoryResource</returns>
        public Crowdin.Api.Client.ApiResponse<DirectoryResource> ApiProjectsDirectoriesGetWithHttpInfo(int projectId, int directoryId)
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
            localVarRequestOptions.PathParameters.Add("directoryId", Crowdin.Api.Client.ClientUtils.ParameterToString(directoryId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<DirectoryResource>("/projects/{projectId}/directories/{directoryId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsDirectoriesGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Directory 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DirectoryResource</returns>
        public async System.Threading.Tasks.Task<DirectoryResource> ApiProjectsDirectoriesGetAsync(int projectId, int directoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<DirectoryResource> localVarResponse = await ApiProjectsDirectoriesGetWithHttpInfoAsync(projectId, directoryId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Directory 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DirectoryResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<DirectoryResource>> ApiProjectsDirectoriesGetWithHttpInfoAsync(int projectId, int directoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("directoryId", Crowdin.Api.Client.ClientUtils.ParameterToString(directoryId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<DirectoryResource>("/projects/{projectId}/directories/{directoryId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsDirectoriesGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Directories 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Filter directories by &#x60;branchId&#x60;  __Note:__ Can&#39;t be used with &#x60;directoryId&#x60; in the same request (optional)</param>
        /// <param name="directoryId">Filter directories by &#x60;directoryId&#x60;  __Note:__ Can&#39;t be used with &#x60;branchId&#x60; in the same request (optional)</param>
        /// <param name="filter">Filter directories by &#x60;name&#x60; (optional)</param>
        /// <param name="recursion">Use to list directories recursively  __Note:__ Works only when &#x60;directoryId&#x60; or &#x60;branchId&#x60; parameter is specified (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>DirectoryCollectionResource</returns>
        public DirectoryCollectionResource ApiProjectsDirectoriesGetMany(int projectId, int? branchId = default(int?), int? directoryId = default(int?), string filter = default(string), Object recursion = default(Object), int? limit = default(int?), int? offset = default(int?))
        {
            Crowdin.Api.Client.ApiResponse<DirectoryCollectionResource> localVarResponse = ApiProjectsDirectoriesGetManyWithHttpInfo(projectId, branchId, directoryId, filter, recursion, limit, offset);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Directories 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Filter directories by &#x60;branchId&#x60;  __Note:__ Can&#39;t be used with &#x60;directoryId&#x60; in the same request (optional)</param>
        /// <param name="directoryId">Filter directories by &#x60;directoryId&#x60;  __Note:__ Can&#39;t be used with &#x60;branchId&#x60; in the same request (optional)</param>
        /// <param name="filter">Filter directories by &#x60;name&#x60; (optional)</param>
        /// <param name="recursion">Use to list directories recursively  __Note:__ Works only when &#x60;directoryId&#x60; or &#x60;branchId&#x60; parameter is specified (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of DirectoryCollectionResource</returns>
        public Crowdin.Api.Client.ApiResponse<DirectoryCollectionResource> ApiProjectsDirectoriesGetManyWithHttpInfo(int projectId, int? branchId = default(int?), int? directoryId = default(int?), string filter = default(string), Object recursion = default(Object), int? limit = default(int?), int? offset = default(int?))
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
            if (branchId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "branchId", branchId));
            }
            if (directoryId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "directoryId", directoryId));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (recursion != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "recursion", recursion));
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
            var localVarResponse = this.Client.Get<DirectoryCollectionResource>("/projects/{projectId}/directories", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsDirectoriesGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Directories 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Filter directories by &#x60;branchId&#x60;  __Note:__ Can&#39;t be used with &#x60;directoryId&#x60; in the same request (optional)</param>
        /// <param name="directoryId">Filter directories by &#x60;directoryId&#x60;  __Note:__ Can&#39;t be used with &#x60;branchId&#x60; in the same request (optional)</param>
        /// <param name="filter">Filter directories by &#x60;name&#x60; (optional)</param>
        /// <param name="recursion">Use to list directories recursively  __Note:__ Works only when &#x60;directoryId&#x60; or &#x60;branchId&#x60; parameter is specified (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DirectoryCollectionResource</returns>
        public async System.Threading.Tasks.Task<DirectoryCollectionResource> ApiProjectsDirectoriesGetManyAsync(int projectId, int? branchId = default(int?), int? directoryId = default(int?), string filter = default(string), Object recursion = default(Object), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<DirectoryCollectionResource> localVarResponse = await ApiProjectsDirectoriesGetManyWithHttpInfoAsync(projectId, branchId, directoryId, filter, recursion, limit, offset, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Directories 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Filter directories by &#x60;branchId&#x60;  __Note:__ Can&#39;t be used with &#x60;directoryId&#x60; in the same request (optional)</param>
        /// <param name="directoryId">Filter directories by &#x60;directoryId&#x60;  __Note:__ Can&#39;t be used with &#x60;branchId&#x60; in the same request (optional)</param>
        /// <param name="filter">Filter directories by &#x60;name&#x60; (optional)</param>
        /// <param name="recursion">Use to list directories recursively  __Note:__ Works only when &#x60;directoryId&#x60; or &#x60;branchId&#x60; parameter is specified (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DirectoryCollectionResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<DirectoryCollectionResource>> ApiProjectsDirectoriesGetManyWithHttpInfoAsync(int projectId, int? branchId = default(int?), int? directoryId = default(int?), string filter = default(string), Object recursion = default(Object), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            if (branchId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "branchId", branchId));
            }
            if (directoryId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "directoryId", directoryId));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (recursion != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "recursion", recursion));
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

            var localVarResponse = await this.AsynchronousClient.GetAsync<DirectoryCollectionResource>("/projects/{projectId}/directories", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsDirectoriesGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Edit Directory 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <param name="directoryOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>DirectoryResource</returns>
        public DirectoryResource ApiProjectsDirectoriesPatch(int projectId, int directoryId, List<DirectoryOperation> directoryOperation = default(List<DirectoryOperation>))
        {
            Crowdin.Api.Client.ApiResponse<DirectoryResource> localVarResponse = ApiProjectsDirectoriesPatchWithHttpInfo(projectId, directoryId, directoryOperation);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Edit Directory 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <param name="directoryOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>ApiResponse of DirectoryResource</returns>
        public Crowdin.Api.Client.ApiResponse<DirectoryResource> ApiProjectsDirectoriesPatchWithHttpInfo(int projectId, int directoryId, List<DirectoryOperation> directoryOperation = default(List<DirectoryOperation>))
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
            localVarRequestOptions.PathParameters.Add("directoryId", Crowdin.Api.Client.ClientUtils.ParameterToString(directoryId)); // path parameter
            localVarRequestOptions.Data = directoryOperation;


            // make the HTTP request
            var localVarResponse = this.Client.Patch<DirectoryResource>("/projects/{projectId}/directories/{directoryId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsDirectoriesPatch", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Edit Directory 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <param name="directoryOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DirectoryResource</returns>
        public async System.Threading.Tasks.Task<DirectoryResource> ApiProjectsDirectoriesPatchAsync(int projectId, int directoryId, List<DirectoryOperation> directoryOperation = default(List<DirectoryOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<DirectoryResource> localVarResponse = await ApiProjectsDirectoriesPatchWithHttpInfoAsync(projectId, directoryId, directoryOperation, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Edit Directory 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <param name="directoryOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DirectoryResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<DirectoryResource>> ApiProjectsDirectoriesPatchWithHttpInfoAsync(int projectId, int directoryId, List<DirectoryOperation> directoryOperation = default(List<DirectoryOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("directoryId", Crowdin.Api.Client.ClientUtils.ParameterToString(directoryId)); // path parameter
            localVarRequestOptions.Data = directoryOperation;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PatchAsync<DirectoryResource>("/projects/{projectId}/directories/{directoryId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsDirectoriesPatch", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add Directory 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryCreateForm"> (optional)</param>
        /// <returns>DirectoryResource</returns>
        public DirectoryResource ApiProjectsDirectoriesPost(int projectId, DirectoryCreateForm directoryCreateForm = default(DirectoryCreateForm))
        {
            Crowdin.Api.Client.ApiResponse<DirectoryResource> localVarResponse = ApiProjectsDirectoriesPostWithHttpInfo(projectId, directoryCreateForm);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add Directory 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryCreateForm"> (optional)</param>
        /// <returns>ApiResponse of DirectoryResource</returns>
        public Crowdin.Api.Client.ApiResponse<DirectoryResource> ApiProjectsDirectoriesPostWithHttpInfo(int projectId, DirectoryCreateForm directoryCreateForm = default(DirectoryCreateForm))
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
            localVarRequestOptions.Data = directoryCreateForm;


            // make the HTTP request
            var localVarResponse = this.Client.Post<DirectoryResource>("/projects/{projectId}/directories", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsDirectoriesPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add Directory 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DirectoryResource</returns>
        public async System.Threading.Tasks.Task<DirectoryResource> ApiProjectsDirectoriesPostAsync(int projectId, DirectoryCreateForm directoryCreateForm = default(DirectoryCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<DirectoryResource> localVarResponse = await ApiProjectsDirectoriesPostWithHttpInfoAsync(projectId, directoryCreateForm, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add Directory 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DirectoryResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<DirectoryResource>> ApiProjectsDirectoriesPostWithHttpInfoAsync(int projectId, DirectoryCreateForm directoryCreateForm = default(DirectoryCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.Data = directoryCreateForm;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<DirectoryResource>("/projects/{projectId}/directories", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsDirectoriesPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete File 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <returns></returns>
        public void ApiProjectsFilesDelete(int projectId, int fileId)
        {
            ApiProjectsFilesDeleteWithHttpInfo(projectId, fileId);
        }

        /// <summary>
        /// Delete File 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Crowdin.Api.Client.ApiResponse<Object> ApiProjectsFilesDeleteWithHttpInfo(int projectId, int fileId)
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
            localVarRequestOptions.PathParameters.Add("fileId", Crowdin.Api.Client.ClientUtils.ParameterToString(fileId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/projects/{projectId}/files/{fileId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsFilesDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete File 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiProjectsFilesDeleteAsync(int projectId, int fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiProjectsFilesDeleteWithHttpInfoAsync(projectId, fileId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete File 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<Object>> ApiProjectsFilesDeleteWithHttpInfoAsync(int projectId, int fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("fileId", Crowdin.Api.Client.ClientUtils.ParameterToString(fileId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/projects/{projectId}/files/{fileId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsFilesDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Download File 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <returns>DownloadLinkResource</returns>
        public DownloadLinkResource ApiProjectsFilesDownloadGet(int projectId, int fileId)
        {
            Crowdin.Api.Client.ApiResponse<DownloadLinkResource> localVarResponse = ApiProjectsFilesDownloadGetWithHttpInfo(projectId, fileId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Download File 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <returns>ApiResponse of DownloadLinkResource</returns>
        public Crowdin.Api.Client.ApiResponse<DownloadLinkResource> ApiProjectsFilesDownloadGetWithHttpInfo(int projectId, int fileId)
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
            localVarRequestOptions.PathParameters.Add("fileId", Crowdin.Api.Client.ClientUtils.ParameterToString(fileId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<DownloadLinkResource>("/projects/{projectId}/files/{fileId}/download", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsFilesDownloadGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Download File 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DownloadLinkResource</returns>
        public async System.Threading.Tasks.Task<DownloadLinkResource> ApiProjectsFilesDownloadGetAsync(int projectId, int fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<DownloadLinkResource> localVarResponse = await ApiProjectsFilesDownloadGetWithHttpInfoAsync(projectId, fileId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Download File 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DownloadLinkResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<DownloadLinkResource>> ApiProjectsFilesDownloadGetWithHttpInfoAsync(int projectId, int fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("fileId", Crowdin.Api.Client.ClientUtils.ParameterToString(fileId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<DownloadLinkResource>("/projects/{projectId}/files/{fileId}/download", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsFilesDownloadGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get File 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <returns>OneOfFileInfoResourceFileResource</returns>
        public OneOfFileInfoResourceFileResource ApiProjectsFilesGet(int projectId, int fileId)
        {
            Crowdin.Api.Client.ApiResponse<OneOfFileInfoResourceFileResource> localVarResponse = ApiProjectsFilesGetWithHttpInfo(projectId, fileId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get File 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <returns>ApiResponse of OneOfFileInfoResourceFileResource</returns>
        public Crowdin.Api.Client.ApiResponse<OneOfFileInfoResourceFileResource> ApiProjectsFilesGetWithHttpInfo(int projectId, int fileId)
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
            localVarRequestOptions.PathParameters.Add("fileId", Crowdin.Api.Client.ClientUtils.ParameterToString(fileId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<OneOfFileInfoResourceFileResource>("/projects/{projectId}/files/{fileId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsFilesGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get File 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of OneOfFileInfoResourceFileResource</returns>
        public async System.Threading.Tasks.Task<OneOfFileInfoResourceFileResource> ApiProjectsFilesGetAsync(int projectId, int fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<OneOfFileInfoResourceFileResource> localVarResponse = await ApiProjectsFilesGetWithHttpInfoAsync(projectId, fileId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get File 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (OneOfFileInfoResourceFileResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<OneOfFileInfoResourceFileResource>> ApiProjectsFilesGetWithHttpInfoAsync(int projectId, int fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("fileId", Crowdin.Api.Client.ClientUtils.ParameterToString(fileId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<OneOfFileInfoResourceFileResource>("/projects/{projectId}/files/{fileId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsFilesGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Files 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">List branch files  __Note:__ Can&#39;t be used with &#x60;directoryId&#x60; in the same request (optional)</param>
        /// <param name="directoryId">List directory files  __Note:__ Can&#39;t be used with &#x60;branchId&#x60; in the same request (optional)</param>
        /// <param name="filter">Filter files by &#x60;name&#x60; (optional)</param>
        /// <param name="recursion">Use to list files recursively  __Note:__ Works only when &#x60;directoryId&#x60; or &#x60;branchId&#x60; parameter is specified (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>OneOfFileInfoCollectionResourceFileCollectionResource</returns>
        public OneOfFileInfoCollectionResourceFileCollectionResource ApiProjectsFilesGetMany(int projectId, int? branchId = default(int?), int? directoryId = default(int?), string filter = default(string), Object recursion = default(Object), int? limit = default(int?), int? offset = default(int?))
        {
            Crowdin.Api.Client.ApiResponse<OneOfFileInfoCollectionResourceFileCollectionResource> localVarResponse = ApiProjectsFilesGetManyWithHttpInfo(projectId, branchId, directoryId, filter, recursion, limit, offset);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Files 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">List branch files  __Note:__ Can&#39;t be used with &#x60;directoryId&#x60; in the same request (optional)</param>
        /// <param name="directoryId">List directory files  __Note:__ Can&#39;t be used with &#x60;branchId&#x60; in the same request (optional)</param>
        /// <param name="filter">Filter files by &#x60;name&#x60; (optional)</param>
        /// <param name="recursion">Use to list files recursively  __Note:__ Works only when &#x60;directoryId&#x60; or &#x60;branchId&#x60; parameter is specified (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of OneOfFileInfoCollectionResourceFileCollectionResource</returns>
        public Crowdin.Api.Client.ApiResponse<OneOfFileInfoCollectionResourceFileCollectionResource> ApiProjectsFilesGetManyWithHttpInfo(int projectId, int? branchId = default(int?), int? directoryId = default(int?), string filter = default(string), Object recursion = default(Object), int? limit = default(int?), int? offset = default(int?))
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
            if (branchId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "branchId", branchId));
            }
            if (directoryId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "directoryId", directoryId));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (recursion != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "recursion", recursion));
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
            var localVarResponse = this.Client.Get<OneOfFileInfoCollectionResourceFileCollectionResource>("/projects/{projectId}/files", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsFilesGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Files 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">List branch files  __Note:__ Can&#39;t be used with &#x60;directoryId&#x60; in the same request (optional)</param>
        /// <param name="directoryId">List directory files  __Note:__ Can&#39;t be used with &#x60;branchId&#x60; in the same request (optional)</param>
        /// <param name="filter">Filter files by &#x60;name&#x60; (optional)</param>
        /// <param name="recursion">Use to list files recursively  __Note:__ Works only when &#x60;directoryId&#x60; or &#x60;branchId&#x60; parameter is specified (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of OneOfFileInfoCollectionResourceFileCollectionResource</returns>
        public async System.Threading.Tasks.Task<OneOfFileInfoCollectionResourceFileCollectionResource> ApiProjectsFilesGetManyAsync(int projectId, int? branchId = default(int?), int? directoryId = default(int?), string filter = default(string), Object recursion = default(Object), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<OneOfFileInfoCollectionResourceFileCollectionResource> localVarResponse = await ApiProjectsFilesGetManyWithHttpInfoAsync(projectId, branchId, directoryId, filter, recursion, limit, offset, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Files 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">List branch files  __Note:__ Can&#39;t be used with &#x60;directoryId&#x60; in the same request (optional)</param>
        /// <param name="directoryId">List directory files  __Note:__ Can&#39;t be used with &#x60;branchId&#x60; in the same request (optional)</param>
        /// <param name="filter">Filter files by &#x60;name&#x60; (optional)</param>
        /// <param name="recursion">Use to list files recursively  __Note:__ Works only when &#x60;directoryId&#x60; or &#x60;branchId&#x60; parameter is specified (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (OneOfFileInfoCollectionResourceFileCollectionResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<OneOfFileInfoCollectionResourceFileCollectionResource>> ApiProjectsFilesGetManyWithHttpInfoAsync(int projectId, int? branchId = default(int?), int? directoryId = default(int?), string filter = default(string), Object recursion = default(Object), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            if (branchId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "branchId", branchId));
            }
            if (directoryId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "directoryId", directoryId));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (recursion != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "recursion", recursion));
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

            var localVarResponse = await this.AsynchronousClient.GetAsync<OneOfFileInfoCollectionResourceFileCollectionResource>("/projects/{projectId}/files", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsFilesGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Edit File 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="fileOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>FileResource</returns>
        public FileResource ApiProjectsFilesPatch(int projectId, int fileId, List<FileOperation> fileOperation = default(List<FileOperation>))
        {
            Crowdin.Api.Client.ApiResponse<FileResource> localVarResponse = ApiProjectsFilesPatchWithHttpInfo(projectId, fileId, fileOperation);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Edit File 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="fileOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>ApiResponse of FileResource</returns>
        public Crowdin.Api.Client.ApiResponse<FileResource> ApiProjectsFilesPatchWithHttpInfo(int projectId, int fileId, List<FileOperation> fileOperation = default(List<FileOperation>))
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
            localVarRequestOptions.PathParameters.Add("fileId", Crowdin.Api.Client.ClientUtils.ParameterToString(fileId)); // path parameter
            localVarRequestOptions.Data = fileOperation;


            // make the HTTP request
            var localVarResponse = this.Client.Patch<FileResource>("/projects/{projectId}/files/{fileId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsFilesPatch", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Edit File 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="fileOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of FileResource</returns>
        public async System.Threading.Tasks.Task<FileResource> ApiProjectsFilesPatchAsync(int projectId, int fileId, List<FileOperation> fileOperation = default(List<FileOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<FileResource> localVarResponse = await ApiProjectsFilesPatchWithHttpInfoAsync(projectId, fileId, fileOperation, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Edit File 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="fileOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (FileResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<FileResource>> ApiProjectsFilesPatchWithHttpInfoAsync(int projectId, int fileId, List<FileOperation> fileOperation = default(List<FileOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("fileId", Crowdin.Api.Client.ClientUtils.ParameterToString(fileId)); // path parameter
            localVarRequestOptions.Data = fileOperation;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PatchAsync<FileResource>("/projects/{projectId}/files/{fileId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsFilesPatch", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add File 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileCreateForm"> (optional)</param>
        /// <returns>FileResource</returns>
        public FileResource ApiProjectsFilesPost(int projectId, FileCreateForm fileCreateForm = default(FileCreateForm))
        {
            Crowdin.Api.Client.ApiResponse<FileResource> localVarResponse = ApiProjectsFilesPostWithHttpInfo(projectId, fileCreateForm);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add File 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileCreateForm"> (optional)</param>
        /// <returns>ApiResponse of FileResource</returns>
        public Crowdin.Api.Client.ApiResponse<FileResource> ApiProjectsFilesPostWithHttpInfo(int projectId, FileCreateForm fileCreateForm = default(FileCreateForm))
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
            localVarRequestOptions.Data = fileCreateForm;


            // make the HTTP request
            var localVarResponse = this.Client.Post<FileResource>("/projects/{projectId}/files", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsFilesPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add File 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of FileResource</returns>
        public async System.Threading.Tasks.Task<FileResource> ApiProjectsFilesPostAsync(int projectId, FileCreateForm fileCreateForm = default(FileCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<FileResource> localVarResponse = await ApiProjectsFilesPostWithHttpInfoAsync(projectId, fileCreateForm, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add File 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (FileResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<FileResource>> ApiProjectsFilesPostWithHttpInfoAsync(int projectId, FileCreateForm fileCreateForm = default(FileCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.Data = fileCreateForm;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<FileResource>("/projects/{projectId}/files", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsFilesPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update or Restore File Update your current file with a new one or restore it to one of the previous revisions
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="UNKNOWN_BASE_TYPE"> (optional)</param>
        /// <returns>FileResource</returns>
        public FileResource ApiProjectsFilesPut(int projectId, int fileId, UNKNOWN_BASE_TYPE UNKNOWN_BASE_TYPE = default(UNKNOWN_BASE_TYPE))
        {
            Crowdin.Api.Client.ApiResponse<FileResource> localVarResponse = ApiProjectsFilesPutWithHttpInfo(projectId, fileId, UNKNOWN_BASE_TYPE);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update or Restore File Update your current file with a new one or restore it to one of the previous revisions
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="UNKNOWN_BASE_TYPE"> (optional)</param>
        /// <returns>ApiResponse of FileResource</returns>
        public Crowdin.Api.Client.ApiResponse<FileResource> ApiProjectsFilesPutWithHttpInfo(int projectId, int fileId, UNKNOWN_BASE_TYPE UNKNOWN_BASE_TYPE = default(UNKNOWN_BASE_TYPE))
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
            localVarRequestOptions.PathParameters.Add("fileId", Crowdin.Api.Client.ClientUtils.ParameterToString(fileId)); // path parameter
            localVarRequestOptions.Data = UNKNOWN_BASE_TYPE;


            // make the HTTP request
            var localVarResponse = this.Client.Put<FileResource>("/projects/{projectId}/files/{fileId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsFilesPut", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update or Restore File Update your current file with a new one or restore it to one of the previous revisions
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="UNKNOWN_BASE_TYPE"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of FileResource</returns>
        public async System.Threading.Tasks.Task<FileResource> ApiProjectsFilesPutAsync(int projectId, int fileId, UNKNOWN_BASE_TYPE UNKNOWN_BASE_TYPE = default(UNKNOWN_BASE_TYPE), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<FileResource> localVarResponse = await ApiProjectsFilesPutWithHttpInfoAsync(projectId, fileId, UNKNOWN_BASE_TYPE, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update or Restore File Update your current file with a new one or restore it to one of the previous revisions
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="UNKNOWN_BASE_TYPE"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (FileResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<FileResource>> ApiProjectsFilesPutWithHttpInfoAsync(int projectId, int fileId, UNKNOWN_BASE_TYPE UNKNOWN_BASE_TYPE = default(UNKNOWN_BASE_TYPE), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("fileId", Crowdin.Api.Client.ClientUtils.ParameterToString(fileId)); // path parameter
            localVarRequestOptions.Data = UNKNOWN_BASE_TYPE;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PutAsync<FileResource>("/projects/{projectId}/files/{fileId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsFilesPut", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get File Revision 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="revisionId">Revision Identifier. Get via [List File Revisions](#operation/api.projects.files.getMany)</param>
        /// <returns>RevisionResource</returns>
        public RevisionResource ApiProjectsFilesRevisionsGet(int projectId, int fileId, int revisionId)
        {
            Crowdin.Api.Client.ApiResponse<RevisionResource> localVarResponse = ApiProjectsFilesRevisionsGetWithHttpInfo(projectId, fileId, revisionId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get File Revision 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="revisionId">Revision Identifier. Get via [List File Revisions](#operation/api.projects.files.getMany)</param>
        /// <returns>ApiResponse of RevisionResource</returns>
        public Crowdin.Api.Client.ApiResponse<RevisionResource> ApiProjectsFilesRevisionsGetWithHttpInfo(int projectId, int fileId, int revisionId)
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
            localVarRequestOptions.PathParameters.Add("fileId", Crowdin.Api.Client.ClientUtils.ParameterToString(fileId)); // path parameter
            localVarRequestOptions.PathParameters.Add("revisionId", Crowdin.Api.Client.ClientUtils.ParameterToString(revisionId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<RevisionResource>("/projects/{projectId}/files/{fileId}/revisions/{revisionId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsFilesRevisionsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get File Revision 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="revisionId">Revision Identifier. Get via [List File Revisions](#operation/api.projects.files.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of RevisionResource</returns>
        public async System.Threading.Tasks.Task<RevisionResource> ApiProjectsFilesRevisionsGetAsync(int projectId, int fileId, int revisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<RevisionResource> localVarResponse = await ApiProjectsFilesRevisionsGetWithHttpInfoAsync(projectId, fileId, revisionId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get File Revision 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="revisionId">Revision Identifier. Get via [List File Revisions](#operation/api.projects.files.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (RevisionResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<RevisionResource>> ApiProjectsFilesRevisionsGetWithHttpInfoAsync(int projectId, int fileId, int revisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("fileId", Crowdin.Api.Client.ClientUtils.ParameterToString(fileId)); // path parameter
            localVarRequestOptions.PathParameters.Add("revisionId", Crowdin.Api.Client.ClientUtils.ParameterToString(revisionId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<RevisionResource>("/projects/{projectId}/files/{fileId}/revisions/{revisionId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsFilesRevisionsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List File Revisions 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>RevisionCollectionResource</returns>
        public RevisionCollectionResource ApiProjectsFilesRevisionsGetMany(int projectId, int fileId, int? limit = default(int?), int? offset = default(int?))
        {
            Crowdin.Api.Client.ApiResponse<RevisionCollectionResource> localVarResponse = ApiProjectsFilesRevisionsGetManyWithHttpInfo(projectId, fileId, limit, offset);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List File Revisions 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of RevisionCollectionResource</returns>
        public Crowdin.Api.Client.ApiResponse<RevisionCollectionResource> ApiProjectsFilesRevisionsGetManyWithHttpInfo(int projectId, int fileId, int? limit = default(int?), int? offset = default(int?))
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
            localVarRequestOptions.PathParameters.Add("fileId", Crowdin.Api.Client.ClientUtils.ParameterToString(fileId)); // path parameter
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (offset != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "offset", offset));
            }


            // make the HTTP request
            var localVarResponse = this.Client.Get<RevisionCollectionResource>("/projects/{projectId}/files/{fileId}/revisions", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsFilesRevisionsGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List File Revisions 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of RevisionCollectionResource</returns>
        public async System.Threading.Tasks.Task<RevisionCollectionResource> ApiProjectsFilesRevisionsGetManyAsync(int projectId, int fileId, int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<RevisionCollectionResource> localVarResponse = await ApiProjectsFilesRevisionsGetManyWithHttpInfoAsync(projectId, fileId, limit, offset, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List File Revisions 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (RevisionCollectionResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<RevisionCollectionResource>> ApiProjectsFilesRevisionsGetManyWithHttpInfoAsync(int projectId, int fileId, int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("fileId", Crowdin.Api.Client.ClientUtils.ParameterToString(fileId)); // path parameter
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (offset != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "offset", offset));
            }


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<RevisionCollectionResource>("/projects/{projectId}/files/{fileId}/revisions", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsFilesRevisionsGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
