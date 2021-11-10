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
    public interface ITranslationMemoryApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Delete TM
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <returns></returns>
        void ApiTmsDelete(int tmId);

        /// <summary>
        /// Delete TM
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiTmsDeleteWithHttpInfo(int tmId);
        /// <summary>
        /// Download TM
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export TM](#operation/api.tms.exports.post)</param>
        /// <returns>DownloadLinkResource</returns>
        DownloadLinkResource ApiTmsExportsDownloadDownload(int tmId, string exportId);

        /// <summary>
        /// Download TM
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export TM](#operation/api.tms.exports.post)</param>
        /// <returns>ApiResponse of DownloadLinkResource</returns>
        ApiResponse<DownloadLinkResource> ApiTmsExportsDownloadDownloadWithHttpInfo(int tmId, string exportId);
        /// <summary>
        /// Check TM Export Status
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export TM](#operation/api.tms.exports.post)</param>
        /// <returns>TmExportResource</returns>
        TmExportResource ApiTmsExportsGet(int tmId, string exportId);

        /// <summary>
        /// Check TM Export Status
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export TM](#operation/api.tms.exports.post)</param>
        /// <returns>ApiResponse of TmExportResource</returns>
        ApiResponse<TmExportResource> ApiTmsExportsGetWithHttpInfo(int tmId, string exportId);
        /// <summary>
        /// Export TM
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="tmExportForm"> (optional)</param>
        /// <returns>TmExportResource</returns>
        TmExportResource ApiTmsExportsPost(int tmId, TmExportForm tmExportForm = default(TmExportForm));

        /// <summary>
        /// Export TM
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="tmExportForm"> (optional)</param>
        /// <returns>ApiResponse of TmExportResource</returns>
        ApiResponse<TmExportResource> ApiTmsExportsPostWithHttpInfo(int tmId, TmExportForm tmExportForm = default(TmExportForm));
        /// <summary>
        /// Get TM
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <returns>CrowdinTmResource</returns>
        CrowdinTmResource ApiTmsGet(int tmId);

        /// <summary>
        /// Get TM
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <returns>ApiResponse of CrowdinTmResource</returns>
        ApiResponse<CrowdinTmResource> ApiTmsGetWithHttpInfo(int tmId);
        /// <summary>
        /// List TMs
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">Project Member Identifier. Get via [List Project Members](#operation/api.projects.members.getMany) (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>CrowdinTmCollectionResource</returns>
        CrowdinTmCollectionResource ApiTmsGetMany(int? userId = default(int?), int? limit = default(int?), int? offset = default(int?));

        /// <summary>
        /// List TMs
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">Project Member Identifier. Get via [List Project Members](#operation/api.projects.members.getMany) (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of CrowdinTmCollectionResource</returns>
        ApiResponse<CrowdinTmCollectionResource> ApiTmsGetManyWithHttpInfo(int? userId = default(int?), int? limit = default(int?), int? offset = default(int?));
        /// <summary>
        /// Check TM Import Status
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="importId">Import Identifier, consists of 36 characters. Get via [Import TM](#operation/api.tms.imports.post)</param>
        /// <returns>TmImportResource</returns>
        TmImportResource ApiTmsImportsGet(int tmId, string importId);

        /// <summary>
        /// Check TM Import Status
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="importId">Import Identifier, consists of 36 characters. Get via [Import TM](#operation/api.tms.imports.post)</param>
        /// <returns>ApiResponse of TmImportResource</returns>
        ApiResponse<TmImportResource> ApiTmsImportsGetWithHttpInfo(int tmId, string importId);
        /// <summary>
        /// Import TM
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="tmUploadForm"> (optional)</param>
        /// <returns>TmImportResource</returns>
        TmImportResource ApiTmsImportsPost(int tmId, TmUploadForm tmUploadForm = default(TmUploadForm));

        /// <summary>
        /// Import TM
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="tmUploadForm"> (optional)</param>
        /// <returns>ApiResponse of TmImportResource</returns>
        ApiResponse<TmImportResource> ApiTmsImportsPostWithHttpInfo(int tmId, TmUploadForm tmUploadForm = default(TmUploadForm));
        /// <summary>
        /// Edit TM
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="tmOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>CrowdinTmResource</returns>
        CrowdinTmResource ApiTmsPatch(int tmId, List<TmOperation> tmOperation = default(List<TmOperation>));

        /// <summary>
        /// Edit TM
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="tmOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>ApiResponse of CrowdinTmResource</returns>
        ApiResponse<CrowdinTmResource> ApiTmsPatchWithHttpInfo(int tmId, List<TmOperation> tmOperation = default(List<TmOperation>));
        /// <summary>
        /// Add TM
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="crowdinTmCreateForm"> (optional)</param>
        /// <returns>CrowdinTmResource</returns>
        CrowdinTmResource ApiTmsPost(CrowdinTmCreateForm crowdinTmCreateForm = default(CrowdinTmCreateForm));

        /// <summary>
        /// Add TM
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="crowdinTmCreateForm"> (optional)</param>
        /// <returns>ApiResponse of CrowdinTmResource</returns>
        ApiResponse<CrowdinTmResource> ApiTmsPostWithHttpInfo(CrowdinTmCreateForm crowdinTmCreateForm = default(CrowdinTmCreateForm));
        /// <summary>
        /// Clear TM
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <returns></returns>
        void ApiTmsSegmentsClear(int tmId);

        /// <summary>
        /// Clear TM
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiTmsSegmentsClearWithHttpInfo(int tmId);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ITranslationMemoryApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Delete TM
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiTmsDeleteAsync(int tmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete TM
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiTmsDeleteWithHttpInfoAsync(int tmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Download TM
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export TM](#operation/api.tms.exports.post)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DownloadLinkResource</returns>
        System.Threading.Tasks.Task<DownloadLinkResource> ApiTmsExportsDownloadDownloadAsync(int tmId, string exportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Download TM
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export TM](#operation/api.tms.exports.post)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DownloadLinkResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<DownloadLinkResource>> ApiTmsExportsDownloadDownloadWithHttpInfoAsync(int tmId, string exportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Check TM Export Status
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export TM](#operation/api.tms.exports.post)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TmExportResource</returns>
        System.Threading.Tasks.Task<TmExportResource> ApiTmsExportsGetAsync(int tmId, string exportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Check TM Export Status
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export TM](#operation/api.tms.exports.post)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TmExportResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<TmExportResource>> ApiTmsExportsGetWithHttpInfoAsync(int tmId, string exportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Export TM
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="tmExportForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TmExportResource</returns>
        System.Threading.Tasks.Task<TmExportResource> ApiTmsExportsPostAsync(int tmId, TmExportForm tmExportForm = default(TmExportForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Export TM
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="tmExportForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TmExportResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<TmExportResource>> ApiTmsExportsPostWithHttpInfoAsync(int tmId, TmExportForm tmExportForm = default(TmExportForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get TM
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CrowdinTmResource</returns>
        System.Threading.Tasks.Task<CrowdinTmResource> ApiTmsGetAsync(int tmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get TM
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CrowdinTmResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<CrowdinTmResource>> ApiTmsGetWithHttpInfoAsync(int tmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List TMs
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">Project Member Identifier. Get via [List Project Members](#operation/api.projects.members.getMany) (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CrowdinTmCollectionResource</returns>
        System.Threading.Tasks.Task<CrowdinTmCollectionResource> ApiTmsGetManyAsync(int? userId = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List TMs
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">Project Member Identifier. Get via [List Project Members](#operation/api.projects.members.getMany) (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CrowdinTmCollectionResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<CrowdinTmCollectionResource>> ApiTmsGetManyWithHttpInfoAsync(int? userId = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Check TM Import Status
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="importId">Import Identifier, consists of 36 characters. Get via [Import TM](#operation/api.tms.imports.post)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TmImportResource</returns>
        System.Threading.Tasks.Task<TmImportResource> ApiTmsImportsGetAsync(int tmId, string importId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Check TM Import Status
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="importId">Import Identifier, consists of 36 characters. Get via [Import TM](#operation/api.tms.imports.post)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TmImportResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<TmImportResource>> ApiTmsImportsGetWithHttpInfoAsync(int tmId, string importId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Import TM
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="tmUploadForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TmImportResource</returns>
        System.Threading.Tasks.Task<TmImportResource> ApiTmsImportsPostAsync(int tmId, TmUploadForm tmUploadForm = default(TmUploadForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Import TM
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="tmUploadForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TmImportResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<TmImportResource>> ApiTmsImportsPostWithHttpInfoAsync(int tmId, TmUploadForm tmUploadForm = default(TmUploadForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Edit TM
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="tmOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CrowdinTmResource</returns>
        System.Threading.Tasks.Task<CrowdinTmResource> ApiTmsPatchAsync(int tmId, List<TmOperation> tmOperation = default(List<TmOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Edit TM
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="tmOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CrowdinTmResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<CrowdinTmResource>> ApiTmsPatchWithHttpInfoAsync(int tmId, List<TmOperation> tmOperation = default(List<TmOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Add TM
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="crowdinTmCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CrowdinTmResource</returns>
        System.Threading.Tasks.Task<CrowdinTmResource> ApiTmsPostAsync(CrowdinTmCreateForm crowdinTmCreateForm = default(CrowdinTmCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Add TM
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="crowdinTmCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CrowdinTmResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<CrowdinTmResource>> ApiTmsPostWithHttpInfoAsync(CrowdinTmCreateForm crowdinTmCreateForm = default(CrowdinTmCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Clear TM
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiTmsSegmentsClearAsync(int tmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Clear TM
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiTmsSegmentsClearWithHttpInfoAsync(int tmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ITranslationMemoryApi : ITranslationMemoryApiSync, ITranslationMemoryApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class TranslationMemoryApi : ITranslationMemoryApi
    {
        private Crowdin.Api.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslationMemoryApi"/> class.
        /// </summary>
        /// <returns></returns>
        public TranslationMemoryApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslationMemoryApi"/> class.
        /// </summary>
        /// <returns></returns>
        public TranslationMemoryApi(string basePath)
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
        /// Initializes a new instance of the <see cref="TranslationMemoryApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public TranslationMemoryApi(Crowdin.Api.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="TranslationMemoryApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public TranslationMemoryApi(Crowdin.Api.Client.ISynchronousClient client, Crowdin.Api.Client.IAsynchronousClient asyncClient, Crowdin.Api.Client.IReadableConfiguration configuration)
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
        /// Delete TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <returns></returns>
        public void ApiTmsDelete(int tmId)
        {
            ApiTmsDeleteWithHttpInfo(tmId);
        }

        /// <summary>
        /// Delete TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Crowdin.Api.Client.ApiResponse<Object> ApiTmsDeleteWithHttpInfo(int tmId)
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

            localVarRequestOptions.PathParameters.Add("tmId", Crowdin.Api.Client.ClientUtils.ParameterToString(tmId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/tms/{tmId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiTmsDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiTmsDeleteAsync(int tmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiTmsDeleteWithHttpInfoAsync(tmId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<Object>> ApiTmsDeleteWithHttpInfoAsync(int tmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("tmId", Crowdin.Api.Client.ClientUtils.ParameterToString(tmId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/tms/{tmId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiTmsDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Download TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export TM](#operation/api.tms.exports.post)</param>
        /// <returns>DownloadLinkResource</returns>
        public DownloadLinkResource ApiTmsExportsDownloadDownload(int tmId, string exportId)
        {
            Crowdin.Api.Client.ApiResponse<DownloadLinkResource> localVarResponse = ApiTmsExportsDownloadDownloadWithHttpInfo(tmId, exportId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Download TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export TM](#operation/api.tms.exports.post)</param>
        /// <returns>ApiResponse of DownloadLinkResource</returns>
        public Crowdin.Api.Client.ApiResponse<DownloadLinkResource> ApiTmsExportsDownloadDownloadWithHttpInfo(int tmId, string exportId)
        {
            // verify the required parameter 'exportId' is set
            if (exportId == null)
                throw new Crowdin.Api.Client.ApiException(400, "Missing required parameter 'exportId' when calling TranslationMemoryApi->ApiTmsExportsDownloadDownload");

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

            localVarRequestOptions.PathParameters.Add("tmId", Crowdin.Api.Client.ClientUtils.ParameterToString(tmId)); // path parameter
            localVarRequestOptions.PathParameters.Add("exportId", Crowdin.Api.Client.ClientUtils.ParameterToString(exportId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<DownloadLinkResource>("/tms/{tmId}/exports/{exportId}/download", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiTmsExportsDownloadDownload", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Download TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export TM](#operation/api.tms.exports.post)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DownloadLinkResource</returns>
        public async System.Threading.Tasks.Task<DownloadLinkResource> ApiTmsExportsDownloadDownloadAsync(int tmId, string exportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<DownloadLinkResource> localVarResponse = await ApiTmsExportsDownloadDownloadWithHttpInfoAsync(tmId, exportId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Download TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export TM](#operation/api.tms.exports.post)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DownloadLinkResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<DownloadLinkResource>> ApiTmsExportsDownloadDownloadWithHttpInfoAsync(int tmId, string exportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'exportId' is set
            if (exportId == null)
                throw new Crowdin.Api.Client.ApiException(400, "Missing required parameter 'exportId' when calling TranslationMemoryApi->ApiTmsExportsDownloadDownload");


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

            localVarRequestOptions.PathParameters.Add("tmId", Crowdin.Api.Client.ClientUtils.ParameterToString(tmId)); // path parameter
            localVarRequestOptions.PathParameters.Add("exportId", Crowdin.Api.Client.ClientUtils.ParameterToString(exportId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<DownloadLinkResource>("/tms/{tmId}/exports/{exportId}/download", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiTmsExportsDownloadDownload", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Check TM Export Status 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export TM](#operation/api.tms.exports.post)</param>
        /// <returns>TmExportResource</returns>
        public TmExportResource ApiTmsExportsGet(int tmId, string exportId)
        {
            Crowdin.Api.Client.ApiResponse<TmExportResource> localVarResponse = ApiTmsExportsGetWithHttpInfo(tmId, exportId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Check TM Export Status 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export TM](#operation/api.tms.exports.post)</param>
        /// <returns>ApiResponse of TmExportResource</returns>
        public Crowdin.Api.Client.ApiResponse<TmExportResource> ApiTmsExportsGetWithHttpInfo(int tmId, string exportId)
        {
            // verify the required parameter 'exportId' is set
            if (exportId == null)
                throw new Crowdin.Api.Client.ApiException(400, "Missing required parameter 'exportId' when calling TranslationMemoryApi->ApiTmsExportsGet");

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

            localVarRequestOptions.PathParameters.Add("tmId", Crowdin.Api.Client.ClientUtils.ParameterToString(tmId)); // path parameter
            localVarRequestOptions.PathParameters.Add("exportId", Crowdin.Api.Client.ClientUtils.ParameterToString(exportId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<TmExportResource>("/tms/{tmId}/exports/{exportId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiTmsExportsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Check TM Export Status 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export TM](#operation/api.tms.exports.post)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TmExportResource</returns>
        public async System.Threading.Tasks.Task<TmExportResource> ApiTmsExportsGetAsync(int tmId, string exportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<TmExportResource> localVarResponse = await ApiTmsExportsGetWithHttpInfoAsync(tmId, exportId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Check TM Export Status 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export TM](#operation/api.tms.exports.post)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TmExportResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<TmExportResource>> ApiTmsExportsGetWithHttpInfoAsync(int tmId, string exportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'exportId' is set
            if (exportId == null)
                throw new Crowdin.Api.Client.ApiException(400, "Missing required parameter 'exportId' when calling TranslationMemoryApi->ApiTmsExportsGet");


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

            localVarRequestOptions.PathParameters.Add("tmId", Crowdin.Api.Client.ClientUtils.ParameterToString(tmId)); // path parameter
            localVarRequestOptions.PathParameters.Add("exportId", Crowdin.Api.Client.ClientUtils.ParameterToString(exportId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<TmExportResource>("/tms/{tmId}/exports/{exportId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiTmsExportsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Export TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="tmExportForm"> (optional)</param>
        /// <returns>TmExportResource</returns>
        public TmExportResource ApiTmsExportsPost(int tmId, TmExportForm tmExportForm = default(TmExportForm))
        {
            Crowdin.Api.Client.ApiResponse<TmExportResource> localVarResponse = ApiTmsExportsPostWithHttpInfo(tmId, tmExportForm);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Export TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="tmExportForm"> (optional)</param>
        /// <returns>ApiResponse of TmExportResource</returns>
        public Crowdin.Api.Client.ApiResponse<TmExportResource> ApiTmsExportsPostWithHttpInfo(int tmId, TmExportForm tmExportForm = default(TmExportForm))
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

            localVarRequestOptions.PathParameters.Add("tmId", Crowdin.Api.Client.ClientUtils.ParameterToString(tmId)); // path parameter
            localVarRequestOptions.Data = tmExportForm;


            // make the HTTP request
            var localVarResponse = this.Client.Post<TmExportResource>("/tms/{tmId}/exports", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiTmsExportsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Export TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="tmExportForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TmExportResource</returns>
        public async System.Threading.Tasks.Task<TmExportResource> ApiTmsExportsPostAsync(int tmId, TmExportForm tmExportForm = default(TmExportForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<TmExportResource> localVarResponse = await ApiTmsExportsPostWithHttpInfoAsync(tmId, tmExportForm, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Export TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="tmExportForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TmExportResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<TmExportResource>> ApiTmsExportsPostWithHttpInfoAsync(int tmId, TmExportForm tmExportForm = default(TmExportForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("tmId", Crowdin.Api.Client.ClientUtils.ParameterToString(tmId)); // path parameter
            localVarRequestOptions.Data = tmExportForm;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<TmExportResource>("/tms/{tmId}/exports", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiTmsExportsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <returns>CrowdinTmResource</returns>
        public CrowdinTmResource ApiTmsGet(int tmId)
        {
            Crowdin.Api.Client.ApiResponse<CrowdinTmResource> localVarResponse = ApiTmsGetWithHttpInfo(tmId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <returns>ApiResponse of CrowdinTmResource</returns>
        public Crowdin.Api.Client.ApiResponse<CrowdinTmResource> ApiTmsGetWithHttpInfo(int tmId)
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

            localVarRequestOptions.PathParameters.Add("tmId", Crowdin.Api.Client.ClientUtils.ParameterToString(tmId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<CrowdinTmResource>("/tms/{tmId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiTmsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CrowdinTmResource</returns>
        public async System.Threading.Tasks.Task<CrowdinTmResource> ApiTmsGetAsync(int tmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<CrowdinTmResource> localVarResponse = await ApiTmsGetWithHttpInfoAsync(tmId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CrowdinTmResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<CrowdinTmResource>> ApiTmsGetWithHttpInfoAsync(int tmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("tmId", Crowdin.Api.Client.ClientUtils.ParameterToString(tmId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<CrowdinTmResource>("/tms/{tmId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiTmsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List TMs 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">Project Member Identifier. Get via [List Project Members](#operation/api.projects.members.getMany) (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>CrowdinTmCollectionResource</returns>
        public CrowdinTmCollectionResource ApiTmsGetMany(int? userId = default(int?), int? limit = default(int?), int? offset = default(int?))
        {
            Crowdin.Api.Client.ApiResponse<CrowdinTmCollectionResource> localVarResponse = ApiTmsGetManyWithHttpInfo(userId, limit, offset);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List TMs 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">Project Member Identifier. Get via [List Project Members](#operation/api.projects.members.getMany) (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of CrowdinTmCollectionResource</returns>
        public Crowdin.Api.Client.ApiResponse<CrowdinTmCollectionResource> ApiTmsGetManyWithHttpInfo(int? userId = default(int?), int? limit = default(int?), int? offset = default(int?))
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

            if (userId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "userId", userId));
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
            var localVarResponse = this.Client.Get<CrowdinTmCollectionResource>("/tms", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiTmsGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List TMs 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">Project Member Identifier. Get via [List Project Members](#operation/api.projects.members.getMany) (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CrowdinTmCollectionResource</returns>
        public async System.Threading.Tasks.Task<CrowdinTmCollectionResource> ApiTmsGetManyAsync(int? userId = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<CrowdinTmCollectionResource> localVarResponse = await ApiTmsGetManyWithHttpInfoAsync(userId, limit, offset, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List TMs 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">Project Member Identifier. Get via [List Project Members](#operation/api.projects.members.getMany) (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CrowdinTmCollectionResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<CrowdinTmCollectionResource>> ApiTmsGetManyWithHttpInfoAsync(int? userId = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            if (userId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "userId", userId));
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

            var localVarResponse = await this.AsynchronousClient.GetAsync<CrowdinTmCollectionResource>("/tms", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiTmsGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Check TM Import Status 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="importId">Import Identifier, consists of 36 characters. Get via [Import TM](#operation/api.tms.imports.post)</param>
        /// <returns>TmImportResource</returns>
        public TmImportResource ApiTmsImportsGet(int tmId, string importId)
        {
            Crowdin.Api.Client.ApiResponse<TmImportResource> localVarResponse = ApiTmsImportsGetWithHttpInfo(tmId, importId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Check TM Import Status 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="importId">Import Identifier, consists of 36 characters. Get via [Import TM](#operation/api.tms.imports.post)</param>
        /// <returns>ApiResponse of TmImportResource</returns>
        public Crowdin.Api.Client.ApiResponse<TmImportResource> ApiTmsImportsGetWithHttpInfo(int tmId, string importId)
        {
            // verify the required parameter 'importId' is set
            if (importId == null)
                throw new Crowdin.Api.Client.ApiException(400, "Missing required parameter 'importId' when calling TranslationMemoryApi->ApiTmsImportsGet");

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

            localVarRequestOptions.PathParameters.Add("tmId", Crowdin.Api.Client.ClientUtils.ParameterToString(tmId)); // path parameter
            localVarRequestOptions.PathParameters.Add("importId", Crowdin.Api.Client.ClientUtils.ParameterToString(importId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<TmImportResource>("/tms/{tmId}/imports/{importId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiTmsImportsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Check TM Import Status 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="importId">Import Identifier, consists of 36 characters. Get via [Import TM](#operation/api.tms.imports.post)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TmImportResource</returns>
        public async System.Threading.Tasks.Task<TmImportResource> ApiTmsImportsGetAsync(int tmId, string importId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<TmImportResource> localVarResponse = await ApiTmsImportsGetWithHttpInfoAsync(tmId, importId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Check TM Import Status 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="importId">Import Identifier, consists of 36 characters. Get via [Import TM](#operation/api.tms.imports.post)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TmImportResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<TmImportResource>> ApiTmsImportsGetWithHttpInfoAsync(int tmId, string importId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'importId' is set
            if (importId == null)
                throw new Crowdin.Api.Client.ApiException(400, "Missing required parameter 'importId' when calling TranslationMemoryApi->ApiTmsImportsGet");


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

            localVarRequestOptions.PathParameters.Add("tmId", Crowdin.Api.Client.ClientUtils.ParameterToString(tmId)); // path parameter
            localVarRequestOptions.PathParameters.Add("importId", Crowdin.Api.Client.ClientUtils.ParameterToString(importId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<TmImportResource>("/tms/{tmId}/imports/{importId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiTmsImportsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Import TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="tmUploadForm"> (optional)</param>
        /// <returns>TmImportResource</returns>
        public TmImportResource ApiTmsImportsPost(int tmId, TmUploadForm tmUploadForm = default(TmUploadForm))
        {
            Crowdin.Api.Client.ApiResponse<TmImportResource> localVarResponse = ApiTmsImportsPostWithHttpInfo(tmId, tmUploadForm);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Import TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="tmUploadForm"> (optional)</param>
        /// <returns>ApiResponse of TmImportResource</returns>
        public Crowdin.Api.Client.ApiResponse<TmImportResource> ApiTmsImportsPostWithHttpInfo(int tmId, TmUploadForm tmUploadForm = default(TmUploadForm))
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

            localVarRequestOptions.PathParameters.Add("tmId", Crowdin.Api.Client.ClientUtils.ParameterToString(tmId)); // path parameter
            localVarRequestOptions.Data = tmUploadForm;


            // make the HTTP request
            var localVarResponse = this.Client.Post<TmImportResource>("/tms/{tmId}/imports", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiTmsImportsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Import TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="tmUploadForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TmImportResource</returns>
        public async System.Threading.Tasks.Task<TmImportResource> ApiTmsImportsPostAsync(int tmId, TmUploadForm tmUploadForm = default(TmUploadForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<TmImportResource> localVarResponse = await ApiTmsImportsPostWithHttpInfoAsync(tmId, tmUploadForm, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Import TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="tmUploadForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TmImportResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<TmImportResource>> ApiTmsImportsPostWithHttpInfoAsync(int tmId, TmUploadForm tmUploadForm = default(TmUploadForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("tmId", Crowdin.Api.Client.ClientUtils.ParameterToString(tmId)); // path parameter
            localVarRequestOptions.Data = tmUploadForm;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<TmImportResource>("/tms/{tmId}/imports", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiTmsImportsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Edit TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="tmOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>CrowdinTmResource</returns>
        public CrowdinTmResource ApiTmsPatch(int tmId, List<TmOperation> tmOperation = default(List<TmOperation>))
        {
            Crowdin.Api.Client.ApiResponse<CrowdinTmResource> localVarResponse = ApiTmsPatchWithHttpInfo(tmId, tmOperation);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Edit TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="tmOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>ApiResponse of CrowdinTmResource</returns>
        public Crowdin.Api.Client.ApiResponse<CrowdinTmResource> ApiTmsPatchWithHttpInfo(int tmId, List<TmOperation> tmOperation = default(List<TmOperation>))
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

            localVarRequestOptions.PathParameters.Add("tmId", Crowdin.Api.Client.ClientUtils.ParameterToString(tmId)); // path parameter
            localVarRequestOptions.Data = tmOperation;


            // make the HTTP request
            var localVarResponse = this.Client.Patch<CrowdinTmResource>("/tms/{tmId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiTmsPatch", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Edit TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="tmOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CrowdinTmResource</returns>
        public async System.Threading.Tasks.Task<CrowdinTmResource> ApiTmsPatchAsync(int tmId, List<TmOperation> tmOperation = default(List<TmOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<CrowdinTmResource> localVarResponse = await ApiTmsPatchWithHttpInfoAsync(tmId, tmOperation, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Edit TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="tmOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CrowdinTmResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<CrowdinTmResource>> ApiTmsPatchWithHttpInfoAsync(int tmId, List<TmOperation> tmOperation = default(List<TmOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("tmId", Crowdin.Api.Client.ClientUtils.ParameterToString(tmId)); // path parameter
            localVarRequestOptions.Data = tmOperation;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PatchAsync<CrowdinTmResource>("/tms/{tmId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiTmsPatch", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="crowdinTmCreateForm"> (optional)</param>
        /// <returns>CrowdinTmResource</returns>
        public CrowdinTmResource ApiTmsPost(CrowdinTmCreateForm crowdinTmCreateForm = default(CrowdinTmCreateForm))
        {
            Crowdin.Api.Client.ApiResponse<CrowdinTmResource> localVarResponse = ApiTmsPostWithHttpInfo(crowdinTmCreateForm);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="crowdinTmCreateForm"> (optional)</param>
        /// <returns>ApiResponse of CrowdinTmResource</returns>
        public Crowdin.Api.Client.ApiResponse<CrowdinTmResource> ApiTmsPostWithHttpInfo(CrowdinTmCreateForm crowdinTmCreateForm = default(CrowdinTmCreateForm))
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

            localVarRequestOptions.Data = crowdinTmCreateForm;


            // make the HTTP request
            var localVarResponse = this.Client.Post<CrowdinTmResource>("/tms", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiTmsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="crowdinTmCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CrowdinTmResource</returns>
        public async System.Threading.Tasks.Task<CrowdinTmResource> ApiTmsPostAsync(CrowdinTmCreateForm crowdinTmCreateForm = default(CrowdinTmCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<CrowdinTmResource> localVarResponse = await ApiTmsPostWithHttpInfoAsync(crowdinTmCreateForm, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="crowdinTmCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CrowdinTmResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<CrowdinTmResource>> ApiTmsPostWithHttpInfoAsync(CrowdinTmCreateForm crowdinTmCreateForm = default(CrowdinTmCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.Data = crowdinTmCreateForm;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<CrowdinTmResource>("/tms", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiTmsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Clear TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <returns></returns>
        public void ApiTmsSegmentsClear(int tmId)
        {
            ApiTmsSegmentsClearWithHttpInfo(tmId);
        }

        /// <summary>
        /// Clear TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Crowdin.Api.Client.ApiResponse<Object> ApiTmsSegmentsClearWithHttpInfo(int tmId)
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

            localVarRequestOptions.PathParameters.Add("tmId", Crowdin.Api.Client.ClientUtils.ParameterToString(tmId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/tms/{tmId}/segments", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiTmsSegmentsClear", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Clear TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiTmsSegmentsClearAsync(int tmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiTmsSegmentsClearWithHttpInfoAsync(tmId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Clear TM 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="tmId">TM Identifier. Get via [List TMs](#operation/api.tms.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<Object>> ApiTmsSegmentsClearWithHttpInfoAsync(int tmId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("tmId", Crowdin.Api.Client.ClientUtils.ParameterToString(tmId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/tms/{tmId}/segments", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiTmsSegmentsClear", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
