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
    public interface ITranslationsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Apply Pre-Translation
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="preTranslationForm"> (optional)</param>
        /// <returns>PreTranslationResource</returns>
        PreTranslationResource ApiProjectsPreTranslationsPost(int projectId, PreTranslationForm preTranslationForm = default(PreTranslationForm));

        /// <summary>
        /// Apply Pre-Translation
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="preTranslationForm"> (optional)</param>
        /// <returns>ApiResponse of PreTranslationResource</returns>
        ApiResponse<PreTranslationResource> ApiProjectsPreTranslationsPostWithHttpInfo(int projectId, PreTranslationForm preTranslationForm = default(PreTranslationForm));
        /// <summary>
        /// Cancel Build
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="buildId">Project Build Identifier. Get via [List Project Builds](#operation/api.projects.translations.builds.getMany)</param>
        /// <returns></returns>
        void ApiProjectsTranslationsBuildsDelete(int projectId, int buildId);

        /// <summary>
        /// Cancel Build
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="buildId">Project Build Identifier. Get via [List Project Builds](#operation/api.projects.translations.builds.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiProjectsTranslationsBuildsDeleteWithHttpInfo(int projectId, int buildId);
        /// <summary>
        /// Build Project Directory Translation
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <param name="crowdinTranslationCreateDirectoryBuildForm"> (optional)</param>
        /// <returns>CrowdinTranslationDirectoryBuildResource</returns>
        CrowdinTranslationDirectoryBuildResource ApiProjectsTranslationsBuildsDirectoriesPost(int projectId, int directoryId, CrowdinTranslationCreateDirectoryBuildForm crowdinTranslationCreateDirectoryBuildForm = default(CrowdinTranslationCreateDirectoryBuildForm));

        /// <summary>
        /// Build Project Directory Translation
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <param name="crowdinTranslationCreateDirectoryBuildForm"> (optional)</param>
        /// <returns>ApiResponse of CrowdinTranslationDirectoryBuildResource</returns>
        ApiResponse<CrowdinTranslationDirectoryBuildResource> ApiProjectsTranslationsBuildsDirectoriesPostWithHttpInfo(int projectId, int directoryId, CrowdinTranslationCreateDirectoryBuildForm crowdinTranslationCreateDirectoryBuildForm = default(CrowdinTranslationCreateDirectoryBuildForm));
        /// <summary>
        /// Download Project Translations
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="buildId">Project Build Identifier. Get via [List Project Builds](#operation/api.projects.translations.builds.getMany)</param>
        /// <returns>DownloadLinkResource</returns>
        DownloadLinkResource ApiProjectsTranslationsBuildsDownloadDownload(int projectId, int buildId);

        /// <summary>
        /// Download Project Translations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="buildId">Project Build Identifier. Get via [List Project Builds](#operation/api.projects.translations.builds.getMany)</param>
        /// <returns>ApiResponse of DownloadLinkResource</returns>
        ApiResponse<DownloadLinkResource> ApiProjectsTranslationsBuildsDownloadDownloadWithHttpInfo(int projectId, int buildId);
        /// <summary>
        /// Build Project File Translation
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="ifNoneMatch">Add **Etag** identifier to the **If-None-Match** request header to see whether any changes were applied to the file. In case the file was changed it would be built. If not you&#39;ll receive a 304 (Not Modified) status code. (optional)</param>
        /// <param name="crowdinFileBuildForm"> (optional)</param>
        /// <returns>FileDownloadLinkResource</returns>
        FileDownloadLinkResource ApiProjectsTranslationsBuildsFilesPost(int projectId, int fileId, string ifNoneMatch = default(string), CrowdinFileBuildForm crowdinFileBuildForm = default(CrowdinFileBuildForm));

        /// <summary>
        /// Build Project File Translation
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="ifNoneMatch">Add **Etag** identifier to the **If-None-Match** request header to see whether any changes were applied to the file. In case the file was changed it would be built. If not you&#39;ll receive a 304 (Not Modified) status code. (optional)</param>
        /// <param name="crowdinFileBuildForm"> (optional)</param>
        /// <returns>ApiResponse of FileDownloadLinkResource</returns>
        ApiResponse<FileDownloadLinkResource> ApiProjectsTranslationsBuildsFilesPostWithHttpInfo(int projectId, int fileId, string ifNoneMatch = default(string), CrowdinFileBuildForm crowdinFileBuildForm = default(CrowdinFileBuildForm));
        /// <summary>
        /// Check Project Build Status
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="buildId">Project Build Identifier. Get via [List Project Builds](#operation/api.projects.translations.builds.getMany)</param>
        /// <returns>CrowdinTranslationProjectBuildResource</returns>
        CrowdinTranslationProjectBuildResource ApiProjectsTranslationsBuildsGet(int projectId, int buildId);

        /// <summary>
        /// Check Project Build Status
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="buildId">Project Build Identifier. Get via [List Project Builds](#operation/api.projects.translations.builds.getMany)</param>
        /// <returns>ApiResponse of CrowdinTranslationProjectBuildResource</returns>
        ApiResponse<CrowdinTranslationProjectBuildResource> ApiProjectsTranslationsBuildsGetWithHttpInfo(int projectId, int buildId);
        /// <summary>
        /// List Project Builds
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Filter builds by &#x60;branchId&#x60; (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>CrowdinTranslationProjectBuildCollectionResource</returns>
        CrowdinTranslationProjectBuildCollectionResource ApiProjectsTranslationsBuildsGetMany(int projectId, int? branchId = default(int?), int? limit = default(int?), int? offset = default(int?));

        /// <summary>
        /// List Project Builds
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Filter builds by &#x60;branchId&#x60; (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of CrowdinTranslationProjectBuildCollectionResource</returns>
        ApiResponse<CrowdinTranslationProjectBuildCollectionResource> ApiProjectsTranslationsBuildsGetManyWithHttpInfo(int projectId, int? branchId = default(int?), int? limit = default(int?), int? offset = default(int?));
        /// <summary>
        /// Build Project Translation
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="UNKNOWN_BASE_TYPE"> (optional)</param>
        /// <returns>CrowdinTranslationProjectBuildResource</returns>
        CrowdinTranslationProjectBuildResource ApiProjectsTranslationsBuildsPost(int projectId, UNKNOWN_BASE_TYPE UNKNOWN_BASE_TYPE = default(UNKNOWN_BASE_TYPE));

        /// <summary>
        /// Build Project Translation
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="UNKNOWN_BASE_TYPE"> (optional)</param>
        /// <returns>ApiResponse of CrowdinTranslationProjectBuildResource</returns>
        ApiResponse<CrowdinTranslationProjectBuildResource> ApiProjectsTranslationsBuildsPostWithHttpInfo(int projectId, UNKNOWN_BASE_TYPE UNKNOWN_BASE_TYPE = default(UNKNOWN_BASE_TYPE));
        /// <summary>
        /// Export Project Translation
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="crowdinTranslationExportForm"> (optional)</param>
        /// <returns>DownloadLinkResource</returns>
        DownloadLinkResource ApiProjectsTranslationsExportsPost(int projectId, CrowdinTranslationExportForm crowdinTranslationExportForm = default(CrowdinTranslationExportForm));

        /// <summary>
        /// Export Project Translation
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="crowdinTranslationExportForm"> (optional)</param>
        /// <returns>ApiResponse of DownloadLinkResource</returns>
        ApiResponse<DownloadLinkResource> ApiProjectsTranslationsExportsPostWithHttpInfo(int projectId, CrowdinTranslationExportForm crowdinTranslationExportForm = default(CrowdinTranslationExportForm));
        /// <summary>
        /// Upload Translations
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <param name="translationUploadForm"> (optional)</param>
        /// <returns>FileImportResource</returns>
        FileImportResource ApiProjectsTranslationsPostOnLanguage(int projectId, string languageId, TranslationUploadForm translationUploadForm = default(TranslationUploadForm));

        /// <summary>
        /// Upload Translations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <param name="translationUploadForm"> (optional)</param>
        /// <returns>ApiResponse of FileImportResource</returns>
        ApiResponse<FileImportResource> ApiProjectsTranslationsPostOnLanguageWithHttpInfo(int projectId, string languageId, TranslationUploadForm translationUploadForm = default(TranslationUploadForm));
        /// <summary>
        /// Pre-Translation Status
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="preTranslationId">Pre-translation Identifier. Get via [Apply Pre-Translation](#operation/api.projects.pre-translations.post)</param>
        /// <returns>PreTranslationResource</returns>
        PreTranslationResource ProjectsProjectIdPreTranslationsPreTranslationIdGet(int projectId, string preTranslationId);

        /// <summary>
        /// Pre-Translation Status
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="preTranslationId">Pre-translation Identifier. Get via [Apply Pre-Translation](#operation/api.projects.pre-translations.post)</param>
        /// <returns>ApiResponse of PreTranslationResource</returns>
        ApiResponse<PreTranslationResource> ProjectsProjectIdPreTranslationsPreTranslationIdGetWithHttpInfo(int projectId, string preTranslationId);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ITranslationsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Apply Pre-Translation
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="preTranslationForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PreTranslationResource</returns>
        System.Threading.Tasks.Task<PreTranslationResource> ApiProjectsPreTranslationsPostAsync(int projectId, PreTranslationForm preTranslationForm = default(PreTranslationForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Apply Pre-Translation
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="preTranslationForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PreTranslationResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<PreTranslationResource>> ApiProjectsPreTranslationsPostWithHttpInfoAsync(int projectId, PreTranslationForm preTranslationForm = default(PreTranslationForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Cancel Build
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="buildId">Project Build Identifier. Get via [List Project Builds](#operation/api.projects.translations.builds.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiProjectsTranslationsBuildsDeleteAsync(int projectId, int buildId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Cancel Build
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="buildId">Project Build Identifier. Get via [List Project Builds](#operation/api.projects.translations.builds.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiProjectsTranslationsBuildsDeleteWithHttpInfoAsync(int projectId, int buildId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Build Project Directory Translation
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <param name="crowdinTranslationCreateDirectoryBuildForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CrowdinTranslationDirectoryBuildResource</returns>
        System.Threading.Tasks.Task<CrowdinTranslationDirectoryBuildResource> ApiProjectsTranslationsBuildsDirectoriesPostAsync(int projectId, int directoryId, CrowdinTranslationCreateDirectoryBuildForm crowdinTranslationCreateDirectoryBuildForm = default(CrowdinTranslationCreateDirectoryBuildForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Build Project Directory Translation
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <param name="crowdinTranslationCreateDirectoryBuildForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CrowdinTranslationDirectoryBuildResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<CrowdinTranslationDirectoryBuildResource>> ApiProjectsTranslationsBuildsDirectoriesPostWithHttpInfoAsync(int projectId, int directoryId, CrowdinTranslationCreateDirectoryBuildForm crowdinTranslationCreateDirectoryBuildForm = default(CrowdinTranslationCreateDirectoryBuildForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Download Project Translations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="buildId">Project Build Identifier. Get via [List Project Builds](#operation/api.projects.translations.builds.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DownloadLinkResource</returns>
        System.Threading.Tasks.Task<DownloadLinkResource> ApiProjectsTranslationsBuildsDownloadDownloadAsync(int projectId, int buildId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Download Project Translations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="buildId">Project Build Identifier. Get via [List Project Builds](#operation/api.projects.translations.builds.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DownloadLinkResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<DownloadLinkResource>> ApiProjectsTranslationsBuildsDownloadDownloadWithHttpInfoAsync(int projectId, int buildId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Build Project File Translation
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="ifNoneMatch">Add **Etag** identifier to the **If-None-Match** request header to see whether any changes were applied to the file. In case the file was changed it would be built. If not you&#39;ll receive a 304 (Not Modified) status code. (optional)</param>
        /// <param name="crowdinFileBuildForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of FileDownloadLinkResource</returns>
        System.Threading.Tasks.Task<FileDownloadLinkResource> ApiProjectsTranslationsBuildsFilesPostAsync(int projectId, int fileId, string ifNoneMatch = default(string), CrowdinFileBuildForm crowdinFileBuildForm = default(CrowdinFileBuildForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Build Project File Translation
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="ifNoneMatch">Add **Etag** identifier to the **If-None-Match** request header to see whether any changes were applied to the file. In case the file was changed it would be built. If not you&#39;ll receive a 304 (Not Modified) status code. (optional)</param>
        /// <param name="crowdinFileBuildForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (FileDownloadLinkResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<FileDownloadLinkResource>> ApiProjectsTranslationsBuildsFilesPostWithHttpInfoAsync(int projectId, int fileId, string ifNoneMatch = default(string), CrowdinFileBuildForm crowdinFileBuildForm = default(CrowdinFileBuildForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Check Project Build Status
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="buildId">Project Build Identifier. Get via [List Project Builds](#operation/api.projects.translations.builds.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CrowdinTranslationProjectBuildResource</returns>
        System.Threading.Tasks.Task<CrowdinTranslationProjectBuildResource> ApiProjectsTranslationsBuildsGetAsync(int projectId, int buildId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Check Project Build Status
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="buildId">Project Build Identifier. Get via [List Project Builds](#operation/api.projects.translations.builds.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CrowdinTranslationProjectBuildResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<CrowdinTranslationProjectBuildResource>> ApiProjectsTranslationsBuildsGetWithHttpInfoAsync(int projectId, int buildId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List Project Builds
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Filter builds by &#x60;branchId&#x60; (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CrowdinTranslationProjectBuildCollectionResource</returns>
        System.Threading.Tasks.Task<CrowdinTranslationProjectBuildCollectionResource> ApiProjectsTranslationsBuildsGetManyAsync(int projectId, int? branchId = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List Project Builds
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Filter builds by &#x60;branchId&#x60; (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CrowdinTranslationProjectBuildCollectionResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<CrowdinTranslationProjectBuildCollectionResource>> ApiProjectsTranslationsBuildsGetManyWithHttpInfoAsync(int projectId, int? branchId = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Build Project Translation
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="UNKNOWN_BASE_TYPE"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CrowdinTranslationProjectBuildResource</returns>
        System.Threading.Tasks.Task<CrowdinTranslationProjectBuildResource> ApiProjectsTranslationsBuildsPostAsync(int projectId, UNKNOWN_BASE_TYPE UNKNOWN_BASE_TYPE = default(UNKNOWN_BASE_TYPE), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Build Project Translation
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="UNKNOWN_BASE_TYPE"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CrowdinTranslationProjectBuildResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<CrowdinTranslationProjectBuildResource>> ApiProjectsTranslationsBuildsPostWithHttpInfoAsync(int projectId, UNKNOWN_BASE_TYPE UNKNOWN_BASE_TYPE = default(UNKNOWN_BASE_TYPE), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Export Project Translation
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="crowdinTranslationExportForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DownloadLinkResource</returns>
        System.Threading.Tasks.Task<DownloadLinkResource> ApiProjectsTranslationsExportsPostAsync(int projectId, CrowdinTranslationExportForm crowdinTranslationExportForm = default(CrowdinTranslationExportForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Export Project Translation
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="crowdinTranslationExportForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DownloadLinkResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<DownloadLinkResource>> ApiProjectsTranslationsExportsPostWithHttpInfoAsync(int projectId, CrowdinTranslationExportForm crowdinTranslationExportForm = default(CrowdinTranslationExportForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Upload Translations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <param name="translationUploadForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of FileImportResource</returns>
        System.Threading.Tasks.Task<FileImportResource> ApiProjectsTranslationsPostOnLanguageAsync(int projectId, string languageId, TranslationUploadForm translationUploadForm = default(TranslationUploadForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Upload Translations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <param name="translationUploadForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (FileImportResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<FileImportResource>> ApiProjectsTranslationsPostOnLanguageWithHttpInfoAsync(int projectId, string languageId, TranslationUploadForm translationUploadForm = default(TranslationUploadForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Pre-Translation Status
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="preTranslationId">Pre-translation Identifier. Get via [Apply Pre-Translation](#operation/api.projects.pre-translations.post)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PreTranslationResource</returns>
        System.Threading.Tasks.Task<PreTranslationResource> ProjectsProjectIdPreTranslationsPreTranslationIdGetAsync(int projectId, string preTranslationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Pre-Translation Status
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="preTranslationId">Pre-translation Identifier. Get via [Apply Pre-Translation](#operation/api.projects.pre-translations.post)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PreTranslationResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<PreTranslationResource>> ProjectsProjectIdPreTranslationsPreTranslationIdGetWithHttpInfoAsync(int projectId, string preTranslationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ITranslationsApi : ITranslationsApiSync, ITranslationsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class TranslationsApi : ITranslationsApi
    {
        private Crowdin.Api.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslationsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public TranslationsApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslationsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public TranslationsApi(string basePath)
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
        /// Initializes a new instance of the <see cref="TranslationsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public TranslationsApi(Crowdin.Api.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="TranslationsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public TranslationsApi(Crowdin.Api.Client.ISynchronousClient client, Crowdin.Api.Client.IAsynchronousClient asyncClient, Crowdin.Api.Client.IReadableConfiguration configuration)
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
        /// Apply Pre-Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="preTranslationForm"> (optional)</param>
        /// <returns>PreTranslationResource</returns>
        public PreTranslationResource ApiProjectsPreTranslationsPost(int projectId, PreTranslationForm preTranslationForm = default(PreTranslationForm))
        {
            Crowdin.Api.Client.ApiResponse<PreTranslationResource> localVarResponse = ApiProjectsPreTranslationsPostWithHttpInfo(projectId, preTranslationForm);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Apply Pre-Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="preTranslationForm"> (optional)</param>
        /// <returns>ApiResponse of PreTranslationResource</returns>
        public Crowdin.Api.Client.ApiResponse<PreTranslationResource> ApiProjectsPreTranslationsPostWithHttpInfo(int projectId, PreTranslationForm preTranslationForm = default(PreTranslationForm))
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
            localVarRequestOptions.Data = preTranslationForm;


            // make the HTTP request
            var localVarResponse = this.Client.Post<PreTranslationResource>("/projects/{projectId}/pre-translations", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsPreTranslationsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Apply Pre-Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="preTranslationForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PreTranslationResource</returns>
        public async System.Threading.Tasks.Task<PreTranslationResource> ApiProjectsPreTranslationsPostAsync(int projectId, PreTranslationForm preTranslationForm = default(PreTranslationForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<PreTranslationResource> localVarResponse = await ApiProjectsPreTranslationsPostWithHttpInfoAsync(projectId, preTranslationForm, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Apply Pre-Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="preTranslationForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PreTranslationResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<PreTranslationResource>> ApiProjectsPreTranslationsPostWithHttpInfoAsync(int projectId, PreTranslationForm preTranslationForm = default(PreTranslationForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.Data = preTranslationForm;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<PreTranslationResource>("/projects/{projectId}/pre-translations", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsPreTranslationsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Cancel Build 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="buildId">Project Build Identifier. Get via [List Project Builds](#operation/api.projects.translations.builds.getMany)</param>
        /// <returns></returns>
        public void ApiProjectsTranslationsBuildsDelete(int projectId, int buildId)
        {
            ApiProjectsTranslationsBuildsDeleteWithHttpInfo(projectId, buildId);
        }

        /// <summary>
        /// Cancel Build 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="buildId">Project Build Identifier. Get via [List Project Builds](#operation/api.projects.translations.builds.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Crowdin.Api.Client.ApiResponse<Object> ApiProjectsTranslationsBuildsDeleteWithHttpInfo(int projectId, int buildId)
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
            localVarRequestOptions.PathParameters.Add("buildId", Crowdin.Api.Client.ClientUtils.ParameterToString(buildId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/projects/{projectId}/translations/builds/{buildId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsTranslationsBuildsDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Cancel Build 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="buildId">Project Build Identifier. Get via [List Project Builds](#operation/api.projects.translations.builds.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiProjectsTranslationsBuildsDeleteAsync(int projectId, int buildId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiProjectsTranslationsBuildsDeleteWithHttpInfoAsync(projectId, buildId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Cancel Build 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="buildId">Project Build Identifier. Get via [List Project Builds](#operation/api.projects.translations.builds.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<Object>> ApiProjectsTranslationsBuildsDeleteWithHttpInfoAsync(int projectId, int buildId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("buildId", Crowdin.Api.Client.ClientUtils.ParameterToString(buildId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/projects/{projectId}/translations/builds/{buildId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsTranslationsBuildsDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Build Project Directory Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <param name="crowdinTranslationCreateDirectoryBuildForm"> (optional)</param>
        /// <returns>CrowdinTranslationDirectoryBuildResource</returns>
        public CrowdinTranslationDirectoryBuildResource ApiProjectsTranslationsBuildsDirectoriesPost(int projectId, int directoryId, CrowdinTranslationCreateDirectoryBuildForm crowdinTranslationCreateDirectoryBuildForm = default(CrowdinTranslationCreateDirectoryBuildForm))
        {
            Crowdin.Api.Client.ApiResponse<CrowdinTranslationDirectoryBuildResource> localVarResponse = ApiProjectsTranslationsBuildsDirectoriesPostWithHttpInfo(projectId, directoryId, crowdinTranslationCreateDirectoryBuildForm);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Build Project Directory Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <param name="crowdinTranslationCreateDirectoryBuildForm"> (optional)</param>
        /// <returns>ApiResponse of CrowdinTranslationDirectoryBuildResource</returns>
        public Crowdin.Api.Client.ApiResponse<CrowdinTranslationDirectoryBuildResource> ApiProjectsTranslationsBuildsDirectoriesPostWithHttpInfo(int projectId, int directoryId, CrowdinTranslationCreateDirectoryBuildForm crowdinTranslationCreateDirectoryBuildForm = default(CrowdinTranslationCreateDirectoryBuildForm))
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
            localVarRequestOptions.Data = crowdinTranslationCreateDirectoryBuildForm;


            // make the HTTP request
            var localVarResponse = this.Client.Post<CrowdinTranslationDirectoryBuildResource>("/projects/{projectId}/translations/builds/directories/{directoryId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsTranslationsBuildsDirectoriesPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Build Project Directory Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <param name="crowdinTranslationCreateDirectoryBuildForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CrowdinTranslationDirectoryBuildResource</returns>
        public async System.Threading.Tasks.Task<CrowdinTranslationDirectoryBuildResource> ApiProjectsTranslationsBuildsDirectoriesPostAsync(int projectId, int directoryId, CrowdinTranslationCreateDirectoryBuildForm crowdinTranslationCreateDirectoryBuildForm = default(CrowdinTranslationCreateDirectoryBuildForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<CrowdinTranslationDirectoryBuildResource> localVarResponse = await ApiProjectsTranslationsBuildsDirectoriesPostWithHttpInfoAsync(projectId, directoryId, crowdinTranslationCreateDirectoryBuildForm, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Build Project Directory Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="directoryId">Directory Identifier. Get via [List Directories](#operation/api.projects.directories.getMany)</param>
        /// <param name="crowdinTranslationCreateDirectoryBuildForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CrowdinTranslationDirectoryBuildResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<CrowdinTranslationDirectoryBuildResource>> ApiProjectsTranslationsBuildsDirectoriesPostWithHttpInfoAsync(int projectId, int directoryId, CrowdinTranslationCreateDirectoryBuildForm crowdinTranslationCreateDirectoryBuildForm = default(CrowdinTranslationCreateDirectoryBuildForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.Data = crowdinTranslationCreateDirectoryBuildForm;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<CrowdinTranslationDirectoryBuildResource>("/projects/{projectId}/translations/builds/directories/{directoryId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsTranslationsBuildsDirectoriesPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Download Project Translations 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="buildId">Project Build Identifier. Get via [List Project Builds](#operation/api.projects.translations.builds.getMany)</param>
        /// <returns>DownloadLinkResource</returns>
        public DownloadLinkResource ApiProjectsTranslationsBuildsDownloadDownload(int projectId, int buildId)
        {
            Crowdin.Api.Client.ApiResponse<DownloadLinkResource> localVarResponse = ApiProjectsTranslationsBuildsDownloadDownloadWithHttpInfo(projectId, buildId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Download Project Translations 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="buildId">Project Build Identifier. Get via [List Project Builds](#operation/api.projects.translations.builds.getMany)</param>
        /// <returns>ApiResponse of DownloadLinkResource</returns>
        public Crowdin.Api.Client.ApiResponse<DownloadLinkResource> ApiProjectsTranslationsBuildsDownloadDownloadWithHttpInfo(int projectId, int buildId)
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
            localVarRequestOptions.PathParameters.Add("buildId", Crowdin.Api.Client.ClientUtils.ParameterToString(buildId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<DownloadLinkResource>("/projects/{projectId}/translations/builds/{buildId}/download", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsTranslationsBuildsDownloadDownload", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Download Project Translations 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="buildId">Project Build Identifier. Get via [List Project Builds](#operation/api.projects.translations.builds.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DownloadLinkResource</returns>
        public async System.Threading.Tasks.Task<DownloadLinkResource> ApiProjectsTranslationsBuildsDownloadDownloadAsync(int projectId, int buildId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<DownloadLinkResource> localVarResponse = await ApiProjectsTranslationsBuildsDownloadDownloadWithHttpInfoAsync(projectId, buildId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Download Project Translations 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="buildId">Project Build Identifier. Get via [List Project Builds](#operation/api.projects.translations.builds.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DownloadLinkResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<DownloadLinkResource>> ApiProjectsTranslationsBuildsDownloadDownloadWithHttpInfoAsync(int projectId, int buildId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("buildId", Crowdin.Api.Client.ClientUtils.ParameterToString(buildId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<DownloadLinkResource>("/projects/{projectId}/translations/builds/{buildId}/download", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsTranslationsBuildsDownloadDownload", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Build Project File Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="ifNoneMatch">Add **Etag** identifier to the **If-None-Match** request header to see whether any changes were applied to the file. In case the file was changed it would be built. If not you&#39;ll receive a 304 (Not Modified) status code. (optional)</param>
        /// <param name="crowdinFileBuildForm"> (optional)</param>
        /// <returns>FileDownloadLinkResource</returns>
        public FileDownloadLinkResource ApiProjectsTranslationsBuildsFilesPost(int projectId, int fileId, string ifNoneMatch = default(string), CrowdinFileBuildForm crowdinFileBuildForm = default(CrowdinFileBuildForm))
        {
            Crowdin.Api.Client.ApiResponse<FileDownloadLinkResource> localVarResponse = ApiProjectsTranslationsBuildsFilesPostWithHttpInfo(projectId, fileId, ifNoneMatch, crowdinFileBuildForm);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Build Project File Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="ifNoneMatch">Add **Etag** identifier to the **If-None-Match** request header to see whether any changes were applied to the file. In case the file was changed it would be built. If not you&#39;ll receive a 304 (Not Modified) status code. (optional)</param>
        /// <param name="crowdinFileBuildForm"> (optional)</param>
        /// <returns>ApiResponse of FileDownloadLinkResource</returns>
        public Crowdin.Api.Client.ApiResponse<FileDownloadLinkResource> ApiProjectsTranslationsBuildsFilesPostWithHttpInfo(int projectId, int fileId, string ifNoneMatch = default(string), CrowdinFileBuildForm crowdinFileBuildForm = default(CrowdinFileBuildForm))
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
            if (ifNoneMatch != null)
            {
                localVarRequestOptions.HeaderParameters.Add("If-None-Match", Crowdin.Api.Client.ClientUtils.ParameterToString(ifNoneMatch)); // header parameter
            }
            localVarRequestOptions.Data = crowdinFileBuildForm;


            // make the HTTP request
            var localVarResponse = this.Client.Post<FileDownloadLinkResource>("/projects/{projectId}/translations/builds/files/{fileId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsTranslationsBuildsFilesPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Build Project File Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="ifNoneMatch">Add **Etag** identifier to the **If-None-Match** request header to see whether any changes were applied to the file. In case the file was changed it would be built. If not you&#39;ll receive a 304 (Not Modified) status code. (optional)</param>
        /// <param name="crowdinFileBuildForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of FileDownloadLinkResource</returns>
        public async System.Threading.Tasks.Task<FileDownloadLinkResource> ApiProjectsTranslationsBuildsFilesPostAsync(int projectId, int fileId, string ifNoneMatch = default(string), CrowdinFileBuildForm crowdinFileBuildForm = default(CrowdinFileBuildForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<FileDownloadLinkResource> localVarResponse = await ApiProjectsTranslationsBuildsFilesPostWithHttpInfoAsync(projectId, fileId, ifNoneMatch, crowdinFileBuildForm, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Build Project File Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany)</param>
        /// <param name="ifNoneMatch">Add **Etag** identifier to the **If-None-Match** request header to see whether any changes were applied to the file. In case the file was changed it would be built. If not you&#39;ll receive a 304 (Not Modified) status code. (optional)</param>
        /// <param name="crowdinFileBuildForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (FileDownloadLinkResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<FileDownloadLinkResource>> ApiProjectsTranslationsBuildsFilesPostWithHttpInfoAsync(int projectId, int fileId, string ifNoneMatch = default(string), CrowdinFileBuildForm crowdinFileBuildForm = default(CrowdinFileBuildForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            if (ifNoneMatch != null)
            {
                localVarRequestOptions.HeaderParameters.Add("If-None-Match", Crowdin.Api.Client.ClientUtils.ParameterToString(ifNoneMatch)); // header parameter
            }
            localVarRequestOptions.Data = crowdinFileBuildForm;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<FileDownloadLinkResource>("/projects/{projectId}/translations/builds/files/{fileId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsTranslationsBuildsFilesPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Check Project Build Status 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="buildId">Project Build Identifier. Get via [List Project Builds](#operation/api.projects.translations.builds.getMany)</param>
        /// <returns>CrowdinTranslationProjectBuildResource</returns>
        public CrowdinTranslationProjectBuildResource ApiProjectsTranslationsBuildsGet(int projectId, int buildId)
        {
            Crowdin.Api.Client.ApiResponse<CrowdinTranslationProjectBuildResource> localVarResponse = ApiProjectsTranslationsBuildsGetWithHttpInfo(projectId, buildId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Check Project Build Status 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="buildId">Project Build Identifier. Get via [List Project Builds](#operation/api.projects.translations.builds.getMany)</param>
        /// <returns>ApiResponse of CrowdinTranslationProjectBuildResource</returns>
        public Crowdin.Api.Client.ApiResponse<CrowdinTranslationProjectBuildResource> ApiProjectsTranslationsBuildsGetWithHttpInfo(int projectId, int buildId)
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
            localVarRequestOptions.PathParameters.Add("buildId", Crowdin.Api.Client.ClientUtils.ParameterToString(buildId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<CrowdinTranslationProjectBuildResource>("/projects/{projectId}/translations/builds/{buildId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsTranslationsBuildsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Check Project Build Status 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="buildId">Project Build Identifier. Get via [List Project Builds](#operation/api.projects.translations.builds.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CrowdinTranslationProjectBuildResource</returns>
        public async System.Threading.Tasks.Task<CrowdinTranslationProjectBuildResource> ApiProjectsTranslationsBuildsGetAsync(int projectId, int buildId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<CrowdinTranslationProjectBuildResource> localVarResponse = await ApiProjectsTranslationsBuildsGetWithHttpInfoAsync(projectId, buildId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Check Project Build Status 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="buildId">Project Build Identifier. Get via [List Project Builds](#operation/api.projects.translations.builds.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CrowdinTranslationProjectBuildResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<CrowdinTranslationProjectBuildResource>> ApiProjectsTranslationsBuildsGetWithHttpInfoAsync(int projectId, int buildId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("buildId", Crowdin.Api.Client.ClientUtils.ParameterToString(buildId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<CrowdinTranslationProjectBuildResource>("/projects/{projectId}/translations/builds/{buildId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsTranslationsBuildsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Project Builds 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Filter builds by &#x60;branchId&#x60; (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>CrowdinTranslationProjectBuildCollectionResource</returns>
        public CrowdinTranslationProjectBuildCollectionResource ApiProjectsTranslationsBuildsGetMany(int projectId, int? branchId = default(int?), int? limit = default(int?), int? offset = default(int?))
        {
            Crowdin.Api.Client.ApiResponse<CrowdinTranslationProjectBuildCollectionResource> localVarResponse = ApiProjectsTranslationsBuildsGetManyWithHttpInfo(projectId, branchId, limit, offset);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Project Builds 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Filter builds by &#x60;branchId&#x60; (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of CrowdinTranslationProjectBuildCollectionResource</returns>
        public Crowdin.Api.Client.ApiResponse<CrowdinTranslationProjectBuildCollectionResource> ApiProjectsTranslationsBuildsGetManyWithHttpInfo(int projectId, int? branchId = default(int?), int? limit = default(int?), int? offset = default(int?))
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
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (offset != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "offset", offset));
            }


            // make the HTTP request
            var localVarResponse = this.Client.Get<CrowdinTranslationProjectBuildCollectionResource>("/projects/{projectId}/translations/builds", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsTranslationsBuildsGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Project Builds 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Filter builds by &#x60;branchId&#x60; (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CrowdinTranslationProjectBuildCollectionResource</returns>
        public async System.Threading.Tasks.Task<CrowdinTranslationProjectBuildCollectionResource> ApiProjectsTranslationsBuildsGetManyAsync(int projectId, int? branchId = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<CrowdinTranslationProjectBuildCollectionResource> localVarResponse = await ApiProjectsTranslationsBuildsGetManyWithHttpInfoAsync(projectId, branchId, limit, offset, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Project Builds 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="branchId">Filter builds by &#x60;branchId&#x60; (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CrowdinTranslationProjectBuildCollectionResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<CrowdinTranslationProjectBuildCollectionResource>> ApiProjectsTranslationsBuildsGetManyWithHttpInfoAsync(int projectId, int? branchId = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (offset != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "offset", offset));
            }


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<CrowdinTranslationProjectBuildCollectionResource>("/projects/{projectId}/translations/builds", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsTranslationsBuildsGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Build Project Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="UNKNOWN_BASE_TYPE"> (optional)</param>
        /// <returns>CrowdinTranslationProjectBuildResource</returns>
        public CrowdinTranslationProjectBuildResource ApiProjectsTranslationsBuildsPost(int projectId, UNKNOWN_BASE_TYPE UNKNOWN_BASE_TYPE = default(UNKNOWN_BASE_TYPE))
        {
            Crowdin.Api.Client.ApiResponse<CrowdinTranslationProjectBuildResource> localVarResponse = ApiProjectsTranslationsBuildsPostWithHttpInfo(projectId, UNKNOWN_BASE_TYPE);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Build Project Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="UNKNOWN_BASE_TYPE"> (optional)</param>
        /// <returns>ApiResponse of CrowdinTranslationProjectBuildResource</returns>
        public Crowdin.Api.Client.ApiResponse<CrowdinTranslationProjectBuildResource> ApiProjectsTranslationsBuildsPostWithHttpInfo(int projectId, UNKNOWN_BASE_TYPE UNKNOWN_BASE_TYPE = default(UNKNOWN_BASE_TYPE))
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
            localVarRequestOptions.Data = UNKNOWN_BASE_TYPE;


            // make the HTTP request
            var localVarResponse = this.Client.Post<CrowdinTranslationProjectBuildResource>("/projects/{projectId}/translations/builds", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsTranslationsBuildsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Build Project Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="UNKNOWN_BASE_TYPE"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CrowdinTranslationProjectBuildResource</returns>
        public async System.Threading.Tasks.Task<CrowdinTranslationProjectBuildResource> ApiProjectsTranslationsBuildsPostAsync(int projectId, UNKNOWN_BASE_TYPE UNKNOWN_BASE_TYPE = default(UNKNOWN_BASE_TYPE), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<CrowdinTranslationProjectBuildResource> localVarResponse = await ApiProjectsTranslationsBuildsPostWithHttpInfoAsync(projectId, UNKNOWN_BASE_TYPE, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Build Project Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="UNKNOWN_BASE_TYPE"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CrowdinTranslationProjectBuildResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<CrowdinTranslationProjectBuildResource>> ApiProjectsTranslationsBuildsPostWithHttpInfoAsync(int projectId, UNKNOWN_BASE_TYPE UNKNOWN_BASE_TYPE = default(UNKNOWN_BASE_TYPE), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.Data = UNKNOWN_BASE_TYPE;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<CrowdinTranslationProjectBuildResource>("/projects/{projectId}/translations/builds", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsTranslationsBuildsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Export Project Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="crowdinTranslationExportForm"> (optional)</param>
        /// <returns>DownloadLinkResource</returns>
        public DownloadLinkResource ApiProjectsTranslationsExportsPost(int projectId, CrowdinTranslationExportForm crowdinTranslationExportForm = default(CrowdinTranslationExportForm))
        {
            Crowdin.Api.Client.ApiResponse<DownloadLinkResource> localVarResponse = ApiProjectsTranslationsExportsPostWithHttpInfo(projectId, crowdinTranslationExportForm);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Export Project Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="crowdinTranslationExportForm"> (optional)</param>
        /// <returns>ApiResponse of DownloadLinkResource</returns>
        public Crowdin.Api.Client.ApiResponse<DownloadLinkResource> ApiProjectsTranslationsExportsPostWithHttpInfo(int projectId, CrowdinTranslationExportForm crowdinTranslationExportForm = default(CrowdinTranslationExportForm))
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
            localVarRequestOptions.Data = crowdinTranslationExportForm;


            // make the HTTP request
            var localVarResponse = this.Client.Post<DownloadLinkResource>("/projects/{projectId}/translations/exports", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsTranslationsExportsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Export Project Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="crowdinTranslationExportForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DownloadLinkResource</returns>
        public async System.Threading.Tasks.Task<DownloadLinkResource> ApiProjectsTranslationsExportsPostAsync(int projectId, CrowdinTranslationExportForm crowdinTranslationExportForm = default(CrowdinTranslationExportForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<DownloadLinkResource> localVarResponse = await ApiProjectsTranslationsExportsPostWithHttpInfoAsync(projectId, crowdinTranslationExportForm, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Export Project Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="crowdinTranslationExportForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DownloadLinkResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<DownloadLinkResource>> ApiProjectsTranslationsExportsPostWithHttpInfoAsync(int projectId, CrowdinTranslationExportForm crowdinTranslationExportForm = default(CrowdinTranslationExportForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.Data = crowdinTranslationExportForm;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<DownloadLinkResource>("/projects/{projectId}/translations/exports", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsTranslationsExportsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Upload Translations 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <param name="translationUploadForm"> (optional)</param>
        /// <returns>FileImportResource</returns>
        public FileImportResource ApiProjectsTranslationsPostOnLanguage(int projectId, string languageId, TranslationUploadForm translationUploadForm = default(TranslationUploadForm))
        {
            Crowdin.Api.Client.ApiResponse<FileImportResource> localVarResponse = ApiProjectsTranslationsPostOnLanguageWithHttpInfo(projectId, languageId, translationUploadForm);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Upload Translations 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <param name="translationUploadForm"> (optional)</param>
        /// <returns>ApiResponse of FileImportResource</returns>
        public Crowdin.Api.Client.ApiResponse<FileImportResource> ApiProjectsTranslationsPostOnLanguageWithHttpInfo(int projectId, string languageId, TranslationUploadForm translationUploadForm = default(TranslationUploadForm))
        {
            // verify the required parameter 'languageId' is set
            if (languageId == null)
                throw new Crowdin.Api.Client.ApiException(400, "Missing required parameter 'languageId' when calling TranslationsApi->ApiProjectsTranslationsPostOnLanguage");

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
            localVarRequestOptions.Data = translationUploadForm;


            // make the HTTP request
            var localVarResponse = this.Client.Post<FileImportResource>("/projects/{projectId}/translations/{languageId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsTranslationsPostOnLanguage", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Upload Translations 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <param name="translationUploadForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of FileImportResource</returns>
        public async System.Threading.Tasks.Task<FileImportResource> ApiProjectsTranslationsPostOnLanguageAsync(int projectId, string languageId, TranslationUploadForm translationUploadForm = default(TranslationUploadForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<FileImportResource> localVarResponse = await ApiProjectsTranslationsPostOnLanguageWithHttpInfoAsync(projectId, languageId, translationUploadForm, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Upload Translations 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <param name="translationUploadForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (FileImportResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<FileImportResource>> ApiProjectsTranslationsPostOnLanguageWithHttpInfoAsync(int projectId, string languageId, TranslationUploadForm translationUploadForm = default(TranslationUploadForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'languageId' is set
            if (languageId == null)
                throw new Crowdin.Api.Client.ApiException(400, "Missing required parameter 'languageId' when calling TranslationsApi->ApiProjectsTranslationsPostOnLanguage");


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
            localVarRequestOptions.Data = translationUploadForm;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<FileImportResource>("/projects/{projectId}/translations/{languageId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsTranslationsPostOnLanguage", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Pre-Translation Status 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="preTranslationId">Pre-translation Identifier. Get via [Apply Pre-Translation](#operation/api.projects.pre-translations.post)</param>
        /// <returns>PreTranslationResource</returns>
        public PreTranslationResource ProjectsProjectIdPreTranslationsPreTranslationIdGet(int projectId, string preTranslationId)
        {
            Crowdin.Api.Client.ApiResponse<PreTranslationResource> localVarResponse = ProjectsProjectIdPreTranslationsPreTranslationIdGetWithHttpInfo(projectId, preTranslationId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Pre-Translation Status 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="preTranslationId">Pre-translation Identifier. Get via [Apply Pre-Translation](#operation/api.projects.pre-translations.post)</param>
        /// <returns>ApiResponse of PreTranslationResource</returns>
        public Crowdin.Api.Client.ApiResponse<PreTranslationResource> ProjectsProjectIdPreTranslationsPreTranslationIdGetWithHttpInfo(int projectId, string preTranslationId)
        {
            // verify the required parameter 'preTranslationId' is set
            if (preTranslationId == null)
                throw new Crowdin.Api.Client.ApiException(400, "Missing required parameter 'preTranslationId' when calling TranslationsApi->ProjectsProjectIdPreTranslationsPreTranslationIdGet");

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
            localVarRequestOptions.PathParameters.Add("preTranslationId", Crowdin.Api.Client.ClientUtils.ParameterToString(preTranslationId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<PreTranslationResource>("/projects/{projectId}/pre-translations/{preTranslationId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ProjectsProjectIdPreTranslationsPreTranslationIdGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Pre-Translation Status 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="preTranslationId">Pre-translation Identifier. Get via [Apply Pre-Translation](#operation/api.projects.pre-translations.post)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PreTranslationResource</returns>
        public async System.Threading.Tasks.Task<PreTranslationResource> ProjectsProjectIdPreTranslationsPreTranslationIdGetAsync(int projectId, string preTranslationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<PreTranslationResource> localVarResponse = await ProjectsProjectIdPreTranslationsPreTranslationIdGetWithHttpInfoAsync(projectId, preTranslationId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Pre-Translation Status 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="preTranslationId">Pre-translation Identifier. Get via [Apply Pre-Translation](#operation/api.projects.pre-translations.post)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PreTranslationResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<PreTranslationResource>> ProjectsProjectIdPreTranslationsPreTranslationIdGetWithHttpInfoAsync(int projectId, string preTranslationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'preTranslationId' is set
            if (preTranslationId == null)
                throw new Crowdin.Api.Client.ApiException(400, "Missing required parameter 'preTranslationId' when calling TranslationsApi->ProjectsProjectIdPreTranslationsPreTranslationIdGet");


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
            localVarRequestOptions.PathParameters.Add("preTranslationId", Crowdin.Api.Client.ClientUtils.ParameterToString(preTranslationId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<PreTranslationResource>("/projects/{projectId}/pre-translations/{preTranslationId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ProjectsProjectIdPreTranslationsPreTranslationIdGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
