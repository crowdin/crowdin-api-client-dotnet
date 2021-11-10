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
    public interface IGlossariesApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Delete Glossary
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <returns></returns>
        void ApiGlossariesDelete(int glossaryId);

        /// <summary>
        /// Delete Glossary
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiGlossariesDeleteWithHttpInfo(int glossaryId);
        /// <summary>
        /// Download Glossary
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export Glossary](#operation/api.glossaries.exports.post)</param>
        /// <returns>DownloadLinkResource</returns>
        DownloadLinkResource ApiGlossariesExportsDownloadDownload(int glossaryId, string exportId);

        /// <summary>
        /// Download Glossary
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export Glossary](#operation/api.glossaries.exports.post)</param>
        /// <returns>ApiResponse of DownloadLinkResource</returns>
        ApiResponse<DownloadLinkResource> ApiGlossariesExportsDownloadDownloadWithHttpInfo(int glossaryId, string exportId);
        /// <summary>
        /// Check Glossary Export Status
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export Glossary](#operation/api.glossaries.exports.post)</param>
        /// <returns>GlossaryExportResource</returns>
        GlossaryExportResource ApiGlossariesExportsGet(int glossaryId, string exportId);

        /// <summary>
        /// Check Glossary Export Status
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export Glossary](#operation/api.glossaries.exports.post)</param>
        /// <returns>ApiResponse of GlossaryExportResource</returns>
        ApiResponse<GlossaryExportResource> ApiGlossariesExportsGetWithHttpInfo(int glossaryId, string exportId);
        /// <summary>
        /// Export Glossary
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="glossaryExportForm"> (optional)</param>
        /// <returns>GlossaryExportResource</returns>
        GlossaryExportResource ApiGlossariesExportsPost(int glossaryId, GlossaryExportForm glossaryExportForm = default(GlossaryExportForm));

        /// <summary>
        /// Export Glossary
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="glossaryExportForm"> (optional)</param>
        /// <returns>ApiResponse of GlossaryExportResource</returns>
        ApiResponse<GlossaryExportResource> ApiGlossariesExportsPostWithHttpInfo(int glossaryId, GlossaryExportForm glossaryExportForm = default(GlossaryExportForm));
        /// <summary>
        /// Get Glossary
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <returns>CrowdinGlossaryResource</returns>
        CrowdinGlossaryResource ApiGlossariesGet(int glossaryId);

        /// <summary>
        /// Get Glossary
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <returns>ApiResponse of CrowdinGlossaryResource</returns>
        ApiResponse<CrowdinGlossaryResource> ApiGlossariesGetWithHttpInfo(int glossaryId);
        /// <summary>
        /// List Glossaries
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="userId">List user glossaries (optional)</param>
        /// <returns>CrowdinGlossaryCollectionResource</returns>
        CrowdinGlossaryCollectionResource ApiGlossariesGetMany(int? limit = default(int?), int? offset = default(int?), int? userId = default(int?));

        /// <summary>
        /// List Glossaries
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="userId">List user glossaries (optional)</param>
        /// <returns>ApiResponse of CrowdinGlossaryCollectionResource</returns>
        ApiResponse<CrowdinGlossaryCollectionResource> ApiGlossariesGetManyWithHttpInfo(int? limit = default(int?), int? offset = default(int?), int? userId = default(int?));
        /// <summary>
        /// Check Glossary Import Status
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="importId">Import Identifier, consists of 36 characters. Get via [Import Glossary](#operation/api.glossaries.imports.post)</param>
        /// <returns>GlossaryImportResource</returns>
        GlossaryImportResource ApiGlossariesImportsGet(int glossaryId, string importId);

        /// <summary>
        /// Check Glossary Import Status
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="importId">Import Identifier, consists of 36 characters. Get via [Import Glossary](#operation/api.glossaries.imports.post)</param>
        /// <returns>ApiResponse of GlossaryImportResource</returns>
        ApiResponse<GlossaryImportResource> ApiGlossariesImportsGetWithHttpInfo(int glossaryId, string importId);
        /// <summary>
        /// Import Glossary
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="glossaryImportForm"> (optional)</param>
        /// <returns>GlossaryImportResource</returns>
        GlossaryImportResource ApiGlossariesImportsPost(int glossaryId, GlossaryImportForm glossaryImportForm = default(GlossaryImportForm));

        /// <summary>
        /// Import Glossary
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="glossaryImportForm"> (optional)</param>
        /// <returns>ApiResponse of GlossaryImportResource</returns>
        ApiResponse<GlossaryImportResource> ApiGlossariesImportsPostWithHttpInfo(int glossaryId, GlossaryImportForm glossaryImportForm = default(GlossaryImportForm));
        /// <summary>
        /// Edit Glossary
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="glossaryOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>CrowdinGlossaryResource</returns>
        CrowdinGlossaryResource ApiGlossariesPatch(int glossaryId, List<GlossaryOperation> glossaryOperation = default(List<GlossaryOperation>));

        /// <summary>
        /// Edit Glossary
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="glossaryOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>ApiResponse of CrowdinGlossaryResource</returns>
        ApiResponse<CrowdinGlossaryResource> ApiGlossariesPatchWithHttpInfo(int glossaryId, List<GlossaryOperation> glossaryOperation = default(List<GlossaryOperation>));
        /// <summary>
        /// Add Glossary
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="crowdinGlossaryCreateForm"> (optional)</param>
        /// <returns>CrowdinGlossaryResource</returns>
        CrowdinGlossaryResource ApiGlossariesPost(CrowdinGlossaryCreateForm crowdinGlossaryCreateForm = default(CrowdinGlossaryCreateForm));

        /// <summary>
        /// Add Glossary
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="crowdinGlossaryCreateForm"> (optional)</param>
        /// <returns>ApiResponse of CrowdinGlossaryResource</returns>
        ApiResponse<CrowdinGlossaryResource> ApiGlossariesPostWithHttpInfo(CrowdinGlossaryCreateForm crowdinGlossaryCreateForm = default(CrowdinGlossaryCreateForm));
        /// <summary>
        /// Delete Term
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termId">Term Identifier. Get via [List Terms](#operation/api.glossaries.terms.getMany)</param>
        /// <returns></returns>
        void ApiGlossariesTermsDelete(int glossaryId, int termId);

        /// <summary>
        /// Delete Term
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termId">Term Identifier. Get via [List Terms](#operation/api.glossaries.terms.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiGlossariesTermsDeleteWithHttpInfo(int glossaryId, int termId);
        /// <summary>
        /// Clear Glossary
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany) (optional)</param>
        /// <param name="translationOfTermId">Defines whether to delete specific term along with its translations.  Get &#x60;id&#x60; via [List Terms](#operation/api.glossaries.terms.getMany) (optional)</param>
        /// <returns></returns>
        void ApiGlossariesTermsDeleteMany(int glossaryId, string languageId = default(string), int? translationOfTermId = default(int?));

        /// <summary>
        /// Clear Glossary
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany) (optional)</param>
        /// <param name="translationOfTermId">Defines whether to delete specific term along with its translations.  Get &#x60;id&#x60; via [List Terms](#operation/api.glossaries.terms.getMany) (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiGlossariesTermsDeleteManyWithHttpInfo(int glossaryId, string languageId = default(string), int? translationOfTermId = default(int?));
        /// <summary>
        /// Get Term
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termId">Term Identifier. Get via [List Terms](#operation/api.glossaries.terms.getMany)</param>
        /// <returns>TermResource</returns>
        TermResource ApiGlossariesTermsGet(int glossaryId, int termId);

        /// <summary>
        /// Get Term
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termId">Term Identifier. Get via [List Terms](#operation/api.glossaries.terms.getMany)</param>
        /// <returns>ApiResponse of TermResource</returns>
        ApiResponse<TermResource> ApiGlossariesTermsGetWithHttpInfo(int glossaryId, int termId);
        /// <summary>
        /// List Terms
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="userId">Project Member Identifier. Get via [List Project Members](#operation/api.projects.members.getMany) (optional)</param>
        /// <param name="languageId">Term Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany) (optional)</param>
        /// <param name="translationOfTermId">Filter terms by &#x60;termId&#x60;  __Note:__ Use for terms that have translations (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>TermCollectionResource</returns>
        TermCollectionResource ApiGlossariesTermsGetMany(int glossaryId, int? userId = default(int?), string languageId = default(string), int? translationOfTermId = default(int?), int? limit = default(int?), int? offset = default(int?));

        /// <summary>
        /// List Terms
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="userId">Project Member Identifier. Get via [List Project Members](#operation/api.projects.members.getMany) (optional)</param>
        /// <param name="languageId">Term Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany) (optional)</param>
        /// <param name="translationOfTermId">Filter terms by &#x60;termId&#x60;  __Note:__ Use for terms that have translations (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of TermCollectionResource</returns>
        ApiResponse<TermCollectionResource> ApiGlossariesTermsGetManyWithHttpInfo(int glossaryId, int? userId = default(int?), string languageId = default(string), int? translationOfTermId = default(int?), int? limit = default(int?), int? offset = default(int?));
        /// <summary>
        /// Edit Term
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termId">Term Identifier. Get via [List Terms](#operation/api.glossaries.terms.getMany)</param>
        /// <param name="termOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>TermResource</returns>
        TermResource ApiGlossariesTermsPatch(int glossaryId, int termId, List<TermOperation> termOperation = default(List<TermOperation>));

        /// <summary>
        /// Edit Term
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termId">Term Identifier. Get via [List Terms](#operation/api.glossaries.terms.getMany)</param>
        /// <param name="termOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>ApiResponse of TermResource</returns>
        ApiResponse<TermResource> ApiGlossariesTermsPatchWithHttpInfo(int glossaryId, int termId, List<TermOperation> termOperation = default(List<TermOperation>));
        /// <summary>
        /// Add Term
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termCreateForm"> (optional)</param>
        /// <returns>TermResource</returns>
        TermResource ApiGlossariesTermsPost(int glossaryId, TermCreateForm termCreateForm = default(TermCreateForm));

        /// <summary>
        /// Add Term
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termCreateForm"> (optional)</param>
        /// <returns>ApiResponse of TermResource</returns>
        ApiResponse<TermResource> ApiGlossariesTermsPostWithHttpInfo(int glossaryId, TermCreateForm termCreateForm = default(TermCreateForm));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IGlossariesApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Delete Glossary
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiGlossariesDeleteAsync(int glossaryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete Glossary
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiGlossariesDeleteWithHttpInfoAsync(int glossaryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Download Glossary
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export Glossary](#operation/api.glossaries.exports.post)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DownloadLinkResource</returns>
        System.Threading.Tasks.Task<DownloadLinkResource> ApiGlossariesExportsDownloadDownloadAsync(int glossaryId, string exportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Download Glossary
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export Glossary](#operation/api.glossaries.exports.post)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DownloadLinkResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<DownloadLinkResource>> ApiGlossariesExportsDownloadDownloadWithHttpInfoAsync(int glossaryId, string exportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Check Glossary Export Status
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export Glossary](#operation/api.glossaries.exports.post)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GlossaryExportResource</returns>
        System.Threading.Tasks.Task<GlossaryExportResource> ApiGlossariesExportsGetAsync(int glossaryId, string exportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Check Glossary Export Status
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export Glossary](#operation/api.glossaries.exports.post)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GlossaryExportResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<GlossaryExportResource>> ApiGlossariesExportsGetWithHttpInfoAsync(int glossaryId, string exportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Export Glossary
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="glossaryExportForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GlossaryExportResource</returns>
        System.Threading.Tasks.Task<GlossaryExportResource> ApiGlossariesExportsPostAsync(int glossaryId, GlossaryExportForm glossaryExportForm = default(GlossaryExportForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Export Glossary
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="glossaryExportForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GlossaryExportResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<GlossaryExportResource>> ApiGlossariesExportsPostWithHttpInfoAsync(int glossaryId, GlossaryExportForm glossaryExportForm = default(GlossaryExportForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get Glossary
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CrowdinGlossaryResource</returns>
        System.Threading.Tasks.Task<CrowdinGlossaryResource> ApiGlossariesGetAsync(int glossaryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get Glossary
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CrowdinGlossaryResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<CrowdinGlossaryResource>> ApiGlossariesGetWithHttpInfoAsync(int glossaryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List Glossaries
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="userId">List user glossaries (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CrowdinGlossaryCollectionResource</returns>
        System.Threading.Tasks.Task<CrowdinGlossaryCollectionResource> ApiGlossariesGetManyAsync(int? limit = default(int?), int? offset = default(int?), int? userId = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List Glossaries
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="userId">List user glossaries (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CrowdinGlossaryCollectionResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<CrowdinGlossaryCollectionResource>> ApiGlossariesGetManyWithHttpInfoAsync(int? limit = default(int?), int? offset = default(int?), int? userId = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Check Glossary Import Status
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="importId">Import Identifier, consists of 36 characters. Get via [Import Glossary](#operation/api.glossaries.imports.post)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GlossaryImportResource</returns>
        System.Threading.Tasks.Task<GlossaryImportResource> ApiGlossariesImportsGetAsync(int glossaryId, string importId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Check Glossary Import Status
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="importId">Import Identifier, consists of 36 characters. Get via [Import Glossary](#operation/api.glossaries.imports.post)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GlossaryImportResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<GlossaryImportResource>> ApiGlossariesImportsGetWithHttpInfoAsync(int glossaryId, string importId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Import Glossary
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="glossaryImportForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GlossaryImportResource</returns>
        System.Threading.Tasks.Task<GlossaryImportResource> ApiGlossariesImportsPostAsync(int glossaryId, GlossaryImportForm glossaryImportForm = default(GlossaryImportForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Import Glossary
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="glossaryImportForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GlossaryImportResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<GlossaryImportResource>> ApiGlossariesImportsPostWithHttpInfoAsync(int glossaryId, GlossaryImportForm glossaryImportForm = default(GlossaryImportForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Edit Glossary
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="glossaryOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CrowdinGlossaryResource</returns>
        System.Threading.Tasks.Task<CrowdinGlossaryResource> ApiGlossariesPatchAsync(int glossaryId, List<GlossaryOperation> glossaryOperation = default(List<GlossaryOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Edit Glossary
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="glossaryOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CrowdinGlossaryResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<CrowdinGlossaryResource>> ApiGlossariesPatchWithHttpInfoAsync(int glossaryId, List<GlossaryOperation> glossaryOperation = default(List<GlossaryOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Add Glossary
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="crowdinGlossaryCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CrowdinGlossaryResource</returns>
        System.Threading.Tasks.Task<CrowdinGlossaryResource> ApiGlossariesPostAsync(CrowdinGlossaryCreateForm crowdinGlossaryCreateForm = default(CrowdinGlossaryCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Add Glossary
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="crowdinGlossaryCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CrowdinGlossaryResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<CrowdinGlossaryResource>> ApiGlossariesPostWithHttpInfoAsync(CrowdinGlossaryCreateForm crowdinGlossaryCreateForm = default(CrowdinGlossaryCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Delete Term
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termId">Term Identifier. Get via [List Terms](#operation/api.glossaries.terms.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiGlossariesTermsDeleteAsync(int glossaryId, int termId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete Term
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termId">Term Identifier. Get via [List Terms](#operation/api.glossaries.terms.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiGlossariesTermsDeleteWithHttpInfoAsync(int glossaryId, int termId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Clear Glossary
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany) (optional)</param>
        /// <param name="translationOfTermId">Defines whether to delete specific term along with its translations.  Get &#x60;id&#x60; via [List Terms](#operation/api.glossaries.terms.getMany) (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiGlossariesTermsDeleteManyAsync(int glossaryId, string languageId = default(string), int? translationOfTermId = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Clear Glossary
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany) (optional)</param>
        /// <param name="translationOfTermId">Defines whether to delete specific term along with its translations.  Get &#x60;id&#x60; via [List Terms](#operation/api.glossaries.terms.getMany) (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiGlossariesTermsDeleteManyWithHttpInfoAsync(int glossaryId, string languageId = default(string), int? translationOfTermId = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get Term
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termId">Term Identifier. Get via [List Terms](#operation/api.glossaries.terms.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TermResource</returns>
        System.Threading.Tasks.Task<TermResource> ApiGlossariesTermsGetAsync(int glossaryId, int termId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get Term
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termId">Term Identifier. Get via [List Terms](#operation/api.glossaries.terms.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TermResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<TermResource>> ApiGlossariesTermsGetWithHttpInfoAsync(int glossaryId, int termId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List Terms
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="userId">Project Member Identifier. Get via [List Project Members](#operation/api.projects.members.getMany) (optional)</param>
        /// <param name="languageId">Term Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany) (optional)</param>
        /// <param name="translationOfTermId">Filter terms by &#x60;termId&#x60;  __Note:__ Use for terms that have translations (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TermCollectionResource</returns>
        System.Threading.Tasks.Task<TermCollectionResource> ApiGlossariesTermsGetManyAsync(int glossaryId, int? userId = default(int?), string languageId = default(string), int? translationOfTermId = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List Terms
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="userId">Project Member Identifier. Get via [List Project Members](#operation/api.projects.members.getMany) (optional)</param>
        /// <param name="languageId">Term Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany) (optional)</param>
        /// <param name="translationOfTermId">Filter terms by &#x60;termId&#x60;  __Note:__ Use for terms that have translations (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TermCollectionResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<TermCollectionResource>> ApiGlossariesTermsGetManyWithHttpInfoAsync(int glossaryId, int? userId = default(int?), string languageId = default(string), int? translationOfTermId = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Edit Term
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termId">Term Identifier. Get via [List Terms](#operation/api.glossaries.terms.getMany)</param>
        /// <param name="termOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TermResource</returns>
        System.Threading.Tasks.Task<TermResource> ApiGlossariesTermsPatchAsync(int glossaryId, int termId, List<TermOperation> termOperation = default(List<TermOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Edit Term
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termId">Term Identifier. Get via [List Terms](#operation/api.glossaries.terms.getMany)</param>
        /// <param name="termOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TermResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<TermResource>> ApiGlossariesTermsPatchWithHttpInfoAsync(int glossaryId, int termId, List<TermOperation> termOperation = default(List<TermOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Add Term
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TermResource</returns>
        System.Threading.Tasks.Task<TermResource> ApiGlossariesTermsPostAsync(int glossaryId, TermCreateForm termCreateForm = default(TermCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Add Term
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TermResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<TermResource>> ApiGlossariesTermsPostWithHttpInfoAsync(int glossaryId, TermCreateForm termCreateForm = default(TermCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IGlossariesApi : IGlossariesApiSync, IGlossariesApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class GlossariesApi : IGlossariesApi
    {
        private Crowdin.Api.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="GlossariesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public GlossariesApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GlossariesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public GlossariesApi(string basePath)
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
        /// Initializes a new instance of the <see cref="GlossariesApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public GlossariesApi(Crowdin.Api.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="GlossariesApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public GlossariesApi(Crowdin.Api.Client.ISynchronousClient client, Crowdin.Api.Client.IAsynchronousClient asyncClient, Crowdin.Api.Client.IReadableConfiguration configuration)
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
        /// Delete Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <returns></returns>
        public void ApiGlossariesDelete(int glossaryId)
        {
            ApiGlossariesDeleteWithHttpInfo(glossaryId);
        }

        /// <summary>
        /// Delete Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Crowdin.Api.Client.ApiResponse<Object> ApiGlossariesDeleteWithHttpInfo(int glossaryId)
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

            localVarRequestOptions.PathParameters.Add("glossaryId", Crowdin.Api.Client.ClientUtils.ParameterToString(glossaryId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/glossaries/{glossaryId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiGlossariesDeleteAsync(int glossaryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiGlossariesDeleteWithHttpInfoAsync(glossaryId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<Object>> ApiGlossariesDeleteWithHttpInfoAsync(int glossaryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("glossaryId", Crowdin.Api.Client.ClientUtils.ParameterToString(glossaryId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/glossaries/{glossaryId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Download Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export Glossary](#operation/api.glossaries.exports.post)</param>
        /// <returns>DownloadLinkResource</returns>
        public DownloadLinkResource ApiGlossariesExportsDownloadDownload(int glossaryId, string exportId)
        {
            Crowdin.Api.Client.ApiResponse<DownloadLinkResource> localVarResponse = ApiGlossariesExportsDownloadDownloadWithHttpInfo(glossaryId, exportId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Download Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export Glossary](#operation/api.glossaries.exports.post)</param>
        /// <returns>ApiResponse of DownloadLinkResource</returns>
        public Crowdin.Api.Client.ApiResponse<DownloadLinkResource> ApiGlossariesExportsDownloadDownloadWithHttpInfo(int glossaryId, string exportId)
        {
            // verify the required parameter 'exportId' is set
            if (exportId == null)
                throw new Crowdin.Api.Client.ApiException(400, "Missing required parameter 'exportId' when calling GlossariesApi->ApiGlossariesExportsDownloadDownload");

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

            localVarRequestOptions.PathParameters.Add("glossaryId", Crowdin.Api.Client.ClientUtils.ParameterToString(glossaryId)); // path parameter
            localVarRequestOptions.PathParameters.Add("exportId", Crowdin.Api.Client.ClientUtils.ParameterToString(exportId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<DownloadLinkResource>("/glossaries/{glossaryId}/exports/{exportId}/download", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesExportsDownloadDownload", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Download Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export Glossary](#operation/api.glossaries.exports.post)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DownloadLinkResource</returns>
        public async System.Threading.Tasks.Task<DownloadLinkResource> ApiGlossariesExportsDownloadDownloadAsync(int glossaryId, string exportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<DownloadLinkResource> localVarResponse = await ApiGlossariesExportsDownloadDownloadWithHttpInfoAsync(glossaryId, exportId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Download Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export Glossary](#operation/api.glossaries.exports.post)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DownloadLinkResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<DownloadLinkResource>> ApiGlossariesExportsDownloadDownloadWithHttpInfoAsync(int glossaryId, string exportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'exportId' is set
            if (exportId == null)
                throw new Crowdin.Api.Client.ApiException(400, "Missing required parameter 'exportId' when calling GlossariesApi->ApiGlossariesExportsDownloadDownload");


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

            localVarRequestOptions.PathParameters.Add("glossaryId", Crowdin.Api.Client.ClientUtils.ParameterToString(glossaryId)); // path parameter
            localVarRequestOptions.PathParameters.Add("exportId", Crowdin.Api.Client.ClientUtils.ParameterToString(exportId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<DownloadLinkResource>("/glossaries/{glossaryId}/exports/{exportId}/download", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesExportsDownloadDownload", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Check Glossary Export Status 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export Glossary](#operation/api.glossaries.exports.post)</param>
        /// <returns>GlossaryExportResource</returns>
        public GlossaryExportResource ApiGlossariesExportsGet(int glossaryId, string exportId)
        {
            Crowdin.Api.Client.ApiResponse<GlossaryExportResource> localVarResponse = ApiGlossariesExportsGetWithHttpInfo(glossaryId, exportId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Check Glossary Export Status 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export Glossary](#operation/api.glossaries.exports.post)</param>
        /// <returns>ApiResponse of GlossaryExportResource</returns>
        public Crowdin.Api.Client.ApiResponse<GlossaryExportResource> ApiGlossariesExportsGetWithHttpInfo(int glossaryId, string exportId)
        {
            // verify the required parameter 'exportId' is set
            if (exportId == null)
                throw new Crowdin.Api.Client.ApiException(400, "Missing required parameter 'exportId' when calling GlossariesApi->ApiGlossariesExportsGet");

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

            localVarRequestOptions.PathParameters.Add("glossaryId", Crowdin.Api.Client.ClientUtils.ParameterToString(glossaryId)); // path parameter
            localVarRequestOptions.PathParameters.Add("exportId", Crowdin.Api.Client.ClientUtils.ParameterToString(exportId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<GlossaryExportResource>("/glossaries/{glossaryId}/exports/{exportId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesExportsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Check Glossary Export Status 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export Glossary](#operation/api.glossaries.exports.post)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GlossaryExportResource</returns>
        public async System.Threading.Tasks.Task<GlossaryExportResource> ApiGlossariesExportsGetAsync(int glossaryId, string exportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<GlossaryExportResource> localVarResponse = await ApiGlossariesExportsGetWithHttpInfoAsync(glossaryId, exportId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Check Glossary Export Status 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="exportId">Export Identifier, consists of 36 characters. Get via [Export Glossary](#operation/api.glossaries.exports.post)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GlossaryExportResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<GlossaryExportResource>> ApiGlossariesExportsGetWithHttpInfoAsync(int glossaryId, string exportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'exportId' is set
            if (exportId == null)
                throw new Crowdin.Api.Client.ApiException(400, "Missing required parameter 'exportId' when calling GlossariesApi->ApiGlossariesExportsGet");


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

            localVarRequestOptions.PathParameters.Add("glossaryId", Crowdin.Api.Client.ClientUtils.ParameterToString(glossaryId)); // path parameter
            localVarRequestOptions.PathParameters.Add("exportId", Crowdin.Api.Client.ClientUtils.ParameterToString(exportId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<GlossaryExportResource>("/glossaries/{glossaryId}/exports/{exportId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesExportsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Export Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="glossaryExportForm"> (optional)</param>
        /// <returns>GlossaryExportResource</returns>
        public GlossaryExportResource ApiGlossariesExportsPost(int glossaryId, GlossaryExportForm glossaryExportForm = default(GlossaryExportForm))
        {
            Crowdin.Api.Client.ApiResponse<GlossaryExportResource> localVarResponse = ApiGlossariesExportsPostWithHttpInfo(glossaryId, glossaryExportForm);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Export Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="glossaryExportForm"> (optional)</param>
        /// <returns>ApiResponse of GlossaryExportResource</returns>
        public Crowdin.Api.Client.ApiResponse<GlossaryExportResource> ApiGlossariesExportsPostWithHttpInfo(int glossaryId, GlossaryExportForm glossaryExportForm = default(GlossaryExportForm))
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

            localVarRequestOptions.PathParameters.Add("glossaryId", Crowdin.Api.Client.ClientUtils.ParameterToString(glossaryId)); // path parameter
            localVarRequestOptions.Data = glossaryExportForm;


            // make the HTTP request
            var localVarResponse = this.Client.Post<GlossaryExportResource>("/glossaries/{glossaryId}/exports", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesExportsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Export Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="glossaryExportForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GlossaryExportResource</returns>
        public async System.Threading.Tasks.Task<GlossaryExportResource> ApiGlossariesExportsPostAsync(int glossaryId, GlossaryExportForm glossaryExportForm = default(GlossaryExportForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<GlossaryExportResource> localVarResponse = await ApiGlossariesExportsPostWithHttpInfoAsync(glossaryId, glossaryExportForm, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Export Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="glossaryExportForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GlossaryExportResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<GlossaryExportResource>> ApiGlossariesExportsPostWithHttpInfoAsync(int glossaryId, GlossaryExportForm glossaryExportForm = default(GlossaryExportForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("glossaryId", Crowdin.Api.Client.ClientUtils.ParameterToString(glossaryId)); // path parameter
            localVarRequestOptions.Data = glossaryExportForm;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<GlossaryExportResource>("/glossaries/{glossaryId}/exports", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesExportsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <returns>CrowdinGlossaryResource</returns>
        public CrowdinGlossaryResource ApiGlossariesGet(int glossaryId)
        {
            Crowdin.Api.Client.ApiResponse<CrowdinGlossaryResource> localVarResponse = ApiGlossariesGetWithHttpInfo(glossaryId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <returns>ApiResponse of CrowdinGlossaryResource</returns>
        public Crowdin.Api.Client.ApiResponse<CrowdinGlossaryResource> ApiGlossariesGetWithHttpInfo(int glossaryId)
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

            localVarRequestOptions.PathParameters.Add("glossaryId", Crowdin.Api.Client.ClientUtils.ParameterToString(glossaryId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<CrowdinGlossaryResource>("/glossaries/{glossaryId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CrowdinGlossaryResource</returns>
        public async System.Threading.Tasks.Task<CrowdinGlossaryResource> ApiGlossariesGetAsync(int glossaryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<CrowdinGlossaryResource> localVarResponse = await ApiGlossariesGetWithHttpInfoAsync(glossaryId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CrowdinGlossaryResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<CrowdinGlossaryResource>> ApiGlossariesGetWithHttpInfoAsync(int glossaryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("glossaryId", Crowdin.Api.Client.ClientUtils.ParameterToString(glossaryId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<CrowdinGlossaryResource>("/glossaries/{glossaryId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Glossaries 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="userId">List user glossaries (optional)</param>
        /// <returns>CrowdinGlossaryCollectionResource</returns>
        public CrowdinGlossaryCollectionResource ApiGlossariesGetMany(int? limit = default(int?), int? offset = default(int?), int? userId = default(int?))
        {
            Crowdin.Api.Client.ApiResponse<CrowdinGlossaryCollectionResource> localVarResponse = ApiGlossariesGetManyWithHttpInfo(limit, offset, userId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Glossaries 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="userId">List user glossaries (optional)</param>
        /// <returns>ApiResponse of CrowdinGlossaryCollectionResource</returns>
        public Crowdin.Api.Client.ApiResponse<CrowdinGlossaryCollectionResource> ApiGlossariesGetManyWithHttpInfo(int? limit = default(int?), int? offset = default(int?), int? userId = default(int?))
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

            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (offset != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "offset", offset));
            }
            if (userId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "userId", userId));
            }


            // make the HTTP request
            var localVarResponse = this.Client.Get<CrowdinGlossaryCollectionResource>("/glossaries", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Glossaries 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="userId">List user glossaries (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CrowdinGlossaryCollectionResource</returns>
        public async System.Threading.Tasks.Task<CrowdinGlossaryCollectionResource> ApiGlossariesGetManyAsync(int? limit = default(int?), int? offset = default(int?), int? userId = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<CrowdinGlossaryCollectionResource> localVarResponse = await ApiGlossariesGetManyWithHttpInfoAsync(limit, offset, userId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Glossaries 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="userId">List user glossaries (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CrowdinGlossaryCollectionResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<CrowdinGlossaryCollectionResource>> ApiGlossariesGetManyWithHttpInfoAsync(int? limit = default(int?), int? offset = default(int?), int? userId = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (offset != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "offset", offset));
            }
            if (userId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "userId", userId));
            }


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<CrowdinGlossaryCollectionResource>("/glossaries", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Check Glossary Import Status 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="importId">Import Identifier, consists of 36 characters. Get via [Import Glossary](#operation/api.glossaries.imports.post)</param>
        /// <returns>GlossaryImportResource</returns>
        public GlossaryImportResource ApiGlossariesImportsGet(int glossaryId, string importId)
        {
            Crowdin.Api.Client.ApiResponse<GlossaryImportResource> localVarResponse = ApiGlossariesImportsGetWithHttpInfo(glossaryId, importId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Check Glossary Import Status 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="importId">Import Identifier, consists of 36 characters. Get via [Import Glossary](#operation/api.glossaries.imports.post)</param>
        /// <returns>ApiResponse of GlossaryImportResource</returns>
        public Crowdin.Api.Client.ApiResponse<GlossaryImportResource> ApiGlossariesImportsGetWithHttpInfo(int glossaryId, string importId)
        {
            // verify the required parameter 'importId' is set
            if (importId == null)
                throw new Crowdin.Api.Client.ApiException(400, "Missing required parameter 'importId' when calling GlossariesApi->ApiGlossariesImportsGet");

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

            localVarRequestOptions.PathParameters.Add("glossaryId", Crowdin.Api.Client.ClientUtils.ParameterToString(glossaryId)); // path parameter
            localVarRequestOptions.PathParameters.Add("importId", Crowdin.Api.Client.ClientUtils.ParameterToString(importId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<GlossaryImportResource>("/glossaries/{glossaryId}/imports/{importId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesImportsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Check Glossary Import Status 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="importId">Import Identifier, consists of 36 characters. Get via [Import Glossary](#operation/api.glossaries.imports.post)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GlossaryImportResource</returns>
        public async System.Threading.Tasks.Task<GlossaryImportResource> ApiGlossariesImportsGetAsync(int glossaryId, string importId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<GlossaryImportResource> localVarResponse = await ApiGlossariesImportsGetWithHttpInfoAsync(glossaryId, importId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Check Glossary Import Status 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="importId">Import Identifier, consists of 36 characters. Get via [Import Glossary](#operation/api.glossaries.imports.post)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GlossaryImportResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<GlossaryImportResource>> ApiGlossariesImportsGetWithHttpInfoAsync(int glossaryId, string importId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'importId' is set
            if (importId == null)
                throw new Crowdin.Api.Client.ApiException(400, "Missing required parameter 'importId' when calling GlossariesApi->ApiGlossariesImportsGet");


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

            localVarRequestOptions.PathParameters.Add("glossaryId", Crowdin.Api.Client.ClientUtils.ParameterToString(glossaryId)); // path parameter
            localVarRequestOptions.PathParameters.Add("importId", Crowdin.Api.Client.ClientUtils.ParameterToString(importId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<GlossaryImportResource>("/glossaries/{glossaryId}/imports/{importId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesImportsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Import Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="glossaryImportForm"> (optional)</param>
        /// <returns>GlossaryImportResource</returns>
        public GlossaryImportResource ApiGlossariesImportsPost(int glossaryId, GlossaryImportForm glossaryImportForm = default(GlossaryImportForm))
        {
            Crowdin.Api.Client.ApiResponse<GlossaryImportResource> localVarResponse = ApiGlossariesImportsPostWithHttpInfo(glossaryId, glossaryImportForm);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Import Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="glossaryImportForm"> (optional)</param>
        /// <returns>ApiResponse of GlossaryImportResource</returns>
        public Crowdin.Api.Client.ApiResponse<GlossaryImportResource> ApiGlossariesImportsPostWithHttpInfo(int glossaryId, GlossaryImportForm glossaryImportForm = default(GlossaryImportForm))
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

            localVarRequestOptions.PathParameters.Add("glossaryId", Crowdin.Api.Client.ClientUtils.ParameterToString(glossaryId)); // path parameter
            localVarRequestOptions.Data = glossaryImportForm;


            // make the HTTP request
            var localVarResponse = this.Client.Post<GlossaryImportResource>("/glossaries/{glossaryId}/imports", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesImportsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Import Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="glossaryImportForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GlossaryImportResource</returns>
        public async System.Threading.Tasks.Task<GlossaryImportResource> ApiGlossariesImportsPostAsync(int glossaryId, GlossaryImportForm glossaryImportForm = default(GlossaryImportForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<GlossaryImportResource> localVarResponse = await ApiGlossariesImportsPostWithHttpInfoAsync(glossaryId, glossaryImportForm, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Import Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="glossaryImportForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GlossaryImportResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<GlossaryImportResource>> ApiGlossariesImportsPostWithHttpInfoAsync(int glossaryId, GlossaryImportForm glossaryImportForm = default(GlossaryImportForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("glossaryId", Crowdin.Api.Client.ClientUtils.ParameterToString(glossaryId)); // path parameter
            localVarRequestOptions.Data = glossaryImportForm;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<GlossaryImportResource>("/glossaries/{glossaryId}/imports", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesImportsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Edit Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="glossaryOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>CrowdinGlossaryResource</returns>
        public CrowdinGlossaryResource ApiGlossariesPatch(int glossaryId, List<GlossaryOperation> glossaryOperation = default(List<GlossaryOperation>))
        {
            Crowdin.Api.Client.ApiResponse<CrowdinGlossaryResource> localVarResponse = ApiGlossariesPatchWithHttpInfo(glossaryId, glossaryOperation);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Edit Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="glossaryOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>ApiResponse of CrowdinGlossaryResource</returns>
        public Crowdin.Api.Client.ApiResponse<CrowdinGlossaryResource> ApiGlossariesPatchWithHttpInfo(int glossaryId, List<GlossaryOperation> glossaryOperation = default(List<GlossaryOperation>))
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

            localVarRequestOptions.PathParameters.Add("glossaryId", Crowdin.Api.Client.ClientUtils.ParameterToString(glossaryId)); // path parameter
            localVarRequestOptions.Data = glossaryOperation;


            // make the HTTP request
            var localVarResponse = this.Client.Patch<CrowdinGlossaryResource>("/glossaries/{glossaryId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesPatch", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Edit Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="glossaryOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CrowdinGlossaryResource</returns>
        public async System.Threading.Tasks.Task<CrowdinGlossaryResource> ApiGlossariesPatchAsync(int glossaryId, List<GlossaryOperation> glossaryOperation = default(List<GlossaryOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<CrowdinGlossaryResource> localVarResponse = await ApiGlossariesPatchWithHttpInfoAsync(glossaryId, glossaryOperation, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Edit Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="glossaryOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CrowdinGlossaryResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<CrowdinGlossaryResource>> ApiGlossariesPatchWithHttpInfoAsync(int glossaryId, List<GlossaryOperation> glossaryOperation = default(List<GlossaryOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("glossaryId", Crowdin.Api.Client.ClientUtils.ParameterToString(glossaryId)); // path parameter
            localVarRequestOptions.Data = glossaryOperation;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PatchAsync<CrowdinGlossaryResource>("/glossaries/{glossaryId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesPatch", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="crowdinGlossaryCreateForm"> (optional)</param>
        /// <returns>CrowdinGlossaryResource</returns>
        public CrowdinGlossaryResource ApiGlossariesPost(CrowdinGlossaryCreateForm crowdinGlossaryCreateForm = default(CrowdinGlossaryCreateForm))
        {
            Crowdin.Api.Client.ApiResponse<CrowdinGlossaryResource> localVarResponse = ApiGlossariesPostWithHttpInfo(crowdinGlossaryCreateForm);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="crowdinGlossaryCreateForm"> (optional)</param>
        /// <returns>ApiResponse of CrowdinGlossaryResource</returns>
        public Crowdin.Api.Client.ApiResponse<CrowdinGlossaryResource> ApiGlossariesPostWithHttpInfo(CrowdinGlossaryCreateForm crowdinGlossaryCreateForm = default(CrowdinGlossaryCreateForm))
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

            localVarRequestOptions.Data = crowdinGlossaryCreateForm;


            // make the HTTP request
            var localVarResponse = this.Client.Post<CrowdinGlossaryResource>("/glossaries", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="crowdinGlossaryCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CrowdinGlossaryResource</returns>
        public async System.Threading.Tasks.Task<CrowdinGlossaryResource> ApiGlossariesPostAsync(CrowdinGlossaryCreateForm crowdinGlossaryCreateForm = default(CrowdinGlossaryCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<CrowdinGlossaryResource> localVarResponse = await ApiGlossariesPostWithHttpInfoAsync(crowdinGlossaryCreateForm, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="crowdinGlossaryCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CrowdinGlossaryResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<CrowdinGlossaryResource>> ApiGlossariesPostWithHttpInfoAsync(CrowdinGlossaryCreateForm crowdinGlossaryCreateForm = default(CrowdinGlossaryCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.Data = crowdinGlossaryCreateForm;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<CrowdinGlossaryResource>("/glossaries", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete Term 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termId">Term Identifier. Get via [List Terms](#operation/api.glossaries.terms.getMany)</param>
        /// <returns></returns>
        public void ApiGlossariesTermsDelete(int glossaryId, int termId)
        {
            ApiGlossariesTermsDeleteWithHttpInfo(glossaryId, termId);
        }

        /// <summary>
        /// Delete Term 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termId">Term Identifier. Get via [List Terms](#operation/api.glossaries.terms.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Crowdin.Api.Client.ApiResponse<Object> ApiGlossariesTermsDeleteWithHttpInfo(int glossaryId, int termId)
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

            localVarRequestOptions.PathParameters.Add("glossaryId", Crowdin.Api.Client.ClientUtils.ParameterToString(glossaryId)); // path parameter
            localVarRequestOptions.PathParameters.Add("termId", Crowdin.Api.Client.ClientUtils.ParameterToString(termId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/glossaries/{glossaryId}/terms/{termId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesTermsDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete Term 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termId">Term Identifier. Get via [List Terms](#operation/api.glossaries.terms.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiGlossariesTermsDeleteAsync(int glossaryId, int termId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiGlossariesTermsDeleteWithHttpInfoAsync(glossaryId, termId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete Term 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termId">Term Identifier. Get via [List Terms](#operation/api.glossaries.terms.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<Object>> ApiGlossariesTermsDeleteWithHttpInfoAsync(int glossaryId, int termId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("glossaryId", Crowdin.Api.Client.ClientUtils.ParameterToString(glossaryId)); // path parameter
            localVarRequestOptions.PathParameters.Add("termId", Crowdin.Api.Client.ClientUtils.ParameterToString(termId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/glossaries/{glossaryId}/terms/{termId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesTermsDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Clear Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany) (optional)</param>
        /// <param name="translationOfTermId">Defines whether to delete specific term along with its translations.  Get &#x60;id&#x60; via [List Terms](#operation/api.glossaries.terms.getMany) (optional)</param>
        /// <returns></returns>
        public void ApiGlossariesTermsDeleteMany(int glossaryId, string languageId = default(string), int? translationOfTermId = default(int?))
        {
            ApiGlossariesTermsDeleteManyWithHttpInfo(glossaryId, languageId, translationOfTermId);
        }

        /// <summary>
        /// Clear Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany) (optional)</param>
        /// <param name="translationOfTermId">Defines whether to delete specific term along with its translations.  Get &#x60;id&#x60; via [List Terms](#operation/api.glossaries.terms.getMany) (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Crowdin.Api.Client.ApiResponse<Object> ApiGlossariesTermsDeleteManyWithHttpInfo(int glossaryId, string languageId = default(string), int? translationOfTermId = default(int?))
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

            localVarRequestOptions.PathParameters.Add("glossaryId", Crowdin.Api.Client.ClientUtils.ParameterToString(glossaryId)); // path parameter
            if (languageId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "languageId", languageId));
            }
            if (translationOfTermId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "translationOfTermId", translationOfTermId));
            }


            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/glossaries/{glossaryId}/terms", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesTermsDeleteMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Clear Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany) (optional)</param>
        /// <param name="translationOfTermId">Defines whether to delete specific term along with its translations.  Get &#x60;id&#x60; via [List Terms](#operation/api.glossaries.terms.getMany) (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiGlossariesTermsDeleteManyAsync(int glossaryId, string languageId = default(string), int? translationOfTermId = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiGlossariesTermsDeleteManyWithHttpInfoAsync(glossaryId, languageId, translationOfTermId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Clear Glossary 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany) (optional)</param>
        /// <param name="translationOfTermId">Defines whether to delete specific term along with its translations.  Get &#x60;id&#x60; via [List Terms](#operation/api.glossaries.terms.getMany) (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<Object>> ApiGlossariesTermsDeleteManyWithHttpInfoAsync(int glossaryId, string languageId = default(string), int? translationOfTermId = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("glossaryId", Crowdin.Api.Client.ClientUtils.ParameterToString(glossaryId)); // path parameter
            if (languageId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "languageId", languageId));
            }
            if (translationOfTermId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "translationOfTermId", translationOfTermId));
            }


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/glossaries/{glossaryId}/terms", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesTermsDeleteMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Term 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termId">Term Identifier. Get via [List Terms](#operation/api.glossaries.terms.getMany)</param>
        /// <returns>TermResource</returns>
        public TermResource ApiGlossariesTermsGet(int glossaryId, int termId)
        {
            Crowdin.Api.Client.ApiResponse<TermResource> localVarResponse = ApiGlossariesTermsGetWithHttpInfo(glossaryId, termId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Term 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termId">Term Identifier. Get via [List Terms](#operation/api.glossaries.terms.getMany)</param>
        /// <returns>ApiResponse of TermResource</returns>
        public Crowdin.Api.Client.ApiResponse<TermResource> ApiGlossariesTermsGetWithHttpInfo(int glossaryId, int termId)
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

            localVarRequestOptions.PathParameters.Add("glossaryId", Crowdin.Api.Client.ClientUtils.ParameterToString(glossaryId)); // path parameter
            localVarRequestOptions.PathParameters.Add("termId", Crowdin.Api.Client.ClientUtils.ParameterToString(termId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<TermResource>("/glossaries/{glossaryId}/terms/{termId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesTermsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Term 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termId">Term Identifier. Get via [List Terms](#operation/api.glossaries.terms.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TermResource</returns>
        public async System.Threading.Tasks.Task<TermResource> ApiGlossariesTermsGetAsync(int glossaryId, int termId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<TermResource> localVarResponse = await ApiGlossariesTermsGetWithHttpInfoAsync(glossaryId, termId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Term 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termId">Term Identifier. Get via [List Terms](#operation/api.glossaries.terms.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TermResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<TermResource>> ApiGlossariesTermsGetWithHttpInfoAsync(int glossaryId, int termId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("glossaryId", Crowdin.Api.Client.ClientUtils.ParameterToString(glossaryId)); // path parameter
            localVarRequestOptions.PathParameters.Add("termId", Crowdin.Api.Client.ClientUtils.ParameterToString(termId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<TermResource>("/glossaries/{glossaryId}/terms/{termId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesTermsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Terms 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="userId">Project Member Identifier. Get via [List Project Members](#operation/api.projects.members.getMany) (optional)</param>
        /// <param name="languageId">Term Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany) (optional)</param>
        /// <param name="translationOfTermId">Filter terms by &#x60;termId&#x60;  __Note:__ Use for terms that have translations (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>TermCollectionResource</returns>
        public TermCollectionResource ApiGlossariesTermsGetMany(int glossaryId, int? userId = default(int?), string languageId = default(string), int? translationOfTermId = default(int?), int? limit = default(int?), int? offset = default(int?))
        {
            Crowdin.Api.Client.ApiResponse<TermCollectionResource> localVarResponse = ApiGlossariesTermsGetManyWithHttpInfo(glossaryId, userId, languageId, translationOfTermId, limit, offset);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Terms 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="userId">Project Member Identifier. Get via [List Project Members](#operation/api.projects.members.getMany) (optional)</param>
        /// <param name="languageId">Term Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany) (optional)</param>
        /// <param name="translationOfTermId">Filter terms by &#x60;termId&#x60;  __Note:__ Use for terms that have translations (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of TermCollectionResource</returns>
        public Crowdin.Api.Client.ApiResponse<TermCollectionResource> ApiGlossariesTermsGetManyWithHttpInfo(int glossaryId, int? userId = default(int?), string languageId = default(string), int? translationOfTermId = default(int?), int? limit = default(int?), int? offset = default(int?))
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

            localVarRequestOptions.PathParameters.Add("glossaryId", Crowdin.Api.Client.ClientUtils.ParameterToString(glossaryId)); // path parameter
            if (userId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "userId", userId));
            }
            if (languageId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "languageId", languageId));
            }
            if (translationOfTermId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "translationOfTermId", translationOfTermId));
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
            var localVarResponse = this.Client.Get<TermCollectionResource>("/glossaries/{glossaryId}/terms", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesTermsGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Terms 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="userId">Project Member Identifier. Get via [List Project Members](#operation/api.projects.members.getMany) (optional)</param>
        /// <param name="languageId">Term Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany) (optional)</param>
        /// <param name="translationOfTermId">Filter terms by &#x60;termId&#x60;  __Note:__ Use for terms that have translations (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TermCollectionResource</returns>
        public async System.Threading.Tasks.Task<TermCollectionResource> ApiGlossariesTermsGetManyAsync(int glossaryId, int? userId = default(int?), string languageId = default(string), int? translationOfTermId = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<TermCollectionResource> localVarResponse = await ApiGlossariesTermsGetManyWithHttpInfoAsync(glossaryId, userId, languageId, translationOfTermId, limit, offset, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Terms 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="userId">Project Member Identifier. Get via [List Project Members](#operation/api.projects.members.getMany) (optional)</param>
        /// <param name="languageId">Term Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany) (optional)</param>
        /// <param name="translationOfTermId">Filter terms by &#x60;termId&#x60;  __Note:__ Use for terms that have translations (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TermCollectionResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<TermCollectionResource>> ApiGlossariesTermsGetManyWithHttpInfoAsync(int glossaryId, int? userId = default(int?), string languageId = default(string), int? translationOfTermId = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("glossaryId", Crowdin.Api.Client.ClientUtils.ParameterToString(glossaryId)); // path parameter
            if (userId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "userId", userId));
            }
            if (languageId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "languageId", languageId));
            }
            if (translationOfTermId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "translationOfTermId", translationOfTermId));
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

            var localVarResponse = await this.AsynchronousClient.GetAsync<TermCollectionResource>("/glossaries/{glossaryId}/terms", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesTermsGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Edit Term 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termId">Term Identifier. Get via [List Terms](#operation/api.glossaries.terms.getMany)</param>
        /// <param name="termOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>TermResource</returns>
        public TermResource ApiGlossariesTermsPatch(int glossaryId, int termId, List<TermOperation> termOperation = default(List<TermOperation>))
        {
            Crowdin.Api.Client.ApiResponse<TermResource> localVarResponse = ApiGlossariesTermsPatchWithHttpInfo(glossaryId, termId, termOperation);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Edit Term 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termId">Term Identifier. Get via [List Terms](#operation/api.glossaries.terms.getMany)</param>
        /// <param name="termOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <returns>ApiResponse of TermResource</returns>
        public Crowdin.Api.Client.ApiResponse<TermResource> ApiGlossariesTermsPatchWithHttpInfo(int glossaryId, int termId, List<TermOperation> termOperation = default(List<TermOperation>))
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

            localVarRequestOptions.PathParameters.Add("glossaryId", Crowdin.Api.Client.ClientUtils.ParameterToString(glossaryId)); // path parameter
            localVarRequestOptions.PathParameters.Add("termId", Crowdin.Api.Client.ClientUtils.ParameterToString(termId)); // path parameter
            localVarRequestOptions.Data = termOperation;


            // make the HTTP request
            var localVarResponse = this.Client.Patch<TermResource>("/glossaries/{glossaryId}/terms/{termId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesTermsPatch", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Edit Term 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termId">Term Identifier. Get via [List Terms](#operation/api.glossaries.terms.getMany)</param>
        /// <param name="termOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TermResource</returns>
        public async System.Threading.Tasks.Task<TermResource> ApiGlossariesTermsPatchAsync(int glossaryId, int termId, List<TermOperation> termOperation = default(List<TermOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<TermResource> localVarResponse = await ApiGlossariesTermsPatchWithHttpInfoAsync(glossaryId, termId, termOperation, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Edit Term 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termId">Term Identifier. Get via [List Terms](#operation/api.glossaries.terms.getMany)</param>
        /// <param name="termOperation">A JSON Patch document as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6902#section-3\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6902&lt;/a&gt; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TermResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<TermResource>> ApiGlossariesTermsPatchWithHttpInfoAsync(int glossaryId, int termId, List<TermOperation> termOperation = default(List<TermOperation>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("glossaryId", Crowdin.Api.Client.ClientUtils.ParameterToString(glossaryId)); // path parameter
            localVarRequestOptions.PathParameters.Add("termId", Crowdin.Api.Client.ClientUtils.ParameterToString(termId)); // path parameter
            localVarRequestOptions.Data = termOperation;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PatchAsync<TermResource>("/glossaries/{glossaryId}/terms/{termId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesTermsPatch", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add Term 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termCreateForm"> (optional)</param>
        /// <returns>TermResource</returns>
        public TermResource ApiGlossariesTermsPost(int glossaryId, TermCreateForm termCreateForm = default(TermCreateForm))
        {
            Crowdin.Api.Client.ApiResponse<TermResource> localVarResponse = ApiGlossariesTermsPostWithHttpInfo(glossaryId, termCreateForm);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add Term 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termCreateForm"> (optional)</param>
        /// <returns>ApiResponse of TermResource</returns>
        public Crowdin.Api.Client.ApiResponse<TermResource> ApiGlossariesTermsPostWithHttpInfo(int glossaryId, TermCreateForm termCreateForm = default(TermCreateForm))
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

            localVarRequestOptions.PathParameters.Add("glossaryId", Crowdin.Api.Client.ClientUtils.ParameterToString(glossaryId)); // path parameter
            localVarRequestOptions.Data = termCreateForm;


            // make the HTTP request
            var localVarResponse = this.Client.Post<TermResource>("/glossaries/{glossaryId}/terms", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesTermsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add Term 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TermResource</returns>
        public async System.Threading.Tasks.Task<TermResource> ApiGlossariesTermsPostAsync(int glossaryId, TermCreateForm termCreateForm = default(TermCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<TermResource> localVarResponse = await ApiGlossariesTermsPostWithHttpInfoAsync(glossaryId, termCreateForm, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add Term 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="glossaryId">Glossary Identifier. Get via [List Glossaries](#operation/api.glossaries.getMany)</param>
        /// <param name="termCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TermResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<TermResource>> ApiGlossariesTermsPostWithHttpInfoAsync(int glossaryId, TermCreateForm termCreateForm = default(TermCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("glossaryId", Crowdin.Api.Client.ClientUtils.ParameterToString(glossaryId)); // path parameter
            localVarRequestOptions.Data = termCreateForm;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<TermResource>("/glossaries/{glossaryId}/terms", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiGlossariesTermsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
