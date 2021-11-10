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
    public interface IStringTranslationsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Remove Approval
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="approvalId">Approval Identifier. Get via [List Translation Approvals](#operation/api.projects.approvals.getMany)</param>
        /// <returns></returns>
        void ApiProjectsApprovalsDelete(int projectId, int approvalId);

        /// <summary>
        /// Remove Approval
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="approvalId">Approval Identifier. Get via [List Translation Approvals](#operation/api.projects.approvals.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiProjectsApprovalsDeleteWithHttpInfo(int projectId, int approvalId);
        /// <summary>
        /// Get Approval
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="approvalId">Approval Identifier. Get via [List Translation Approvals](#operation/api.projects.approvals.getMany)</param>
        /// <returns>TranslationApprovalResource</returns>
        TranslationApprovalResource ApiProjectsApprovalsGet(int projectId, int approvalId);

        /// <summary>
        /// Get Approval
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="approvalId">Approval Identifier. Get via [List Translation Approvals](#operation/api.projects.approvals.getMany)</param>
        /// <returns>ApiResponse of TranslationApprovalResource</returns>
        ApiResponse<TranslationApprovalResource> ApiProjectsApprovalsGetWithHttpInfo(int projectId, int approvalId);
        /// <summary>
        /// List Translation Approvals
        /// </summary>
        /// <remarks>
        /// __Note:__ Either &#x60;translationId&#x60; OR &#x60;fileId&#x60; with &#x60;languageId&#x60; OR &#x60;stringId&#x60; with &#x60;languageId&#x60; are required
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany) &lt;br&gt; **Note:** Must be used together with &#x60;languageId&#x60; (optional)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany) &lt;br&gt; **Note:** Must be used together with &#x60;languageId&#x60; (optional)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get) &lt;br&gt; **Note:** Must be used together with &#x60;stringId&#x60; or &#x60;fileId&#x60; (optional)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany) &lt;br&gt; **Note:** If specified, &#x60;fileId&#x60;, &#x60;stringId&#x60; and &#x60;languageId&#x60; are ignored (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>TranslationApprovalCollectionResource</returns>
        TranslationApprovalCollectionResource ApiProjectsApprovalsGetMany(int projectId, int? fileId = default(int?), int? stringId = default(int?), string languageId = default(string), int? translationId = default(int?), int? limit = default(int?), int? offset = default(int?));

        /// <summary>
        /// List Translation Approvals
        /// </summary>
        /// <remarks>
        /// __Note:__ Either &#x60;translationId&#x60; OR &#x60;fileId&#x60; with &#x60;languageId&#x60; OR &#x60;stringId&#x60; with &#x60;languageId&#x60; are required
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany) &lt;br&gt; **Note:** Must be used together with &#x60;languageId&#x60; (optional)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany) &lt;br&gt; **Note:** Must be used together with &#x60;languageId&#x60; (optional)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get) &lt;br&gt; **Note:** Must be used together with &#x60;stringId&#x60; or &#x60;fileId&#x60; (optional)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany) &lt;br&gt; **Note:** If specified, &#x60;fileId&#x60;, &#x60;stringId&#x60; and &#x60;languageId&#x60; are ignored (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of TranslationApprovalCollectionResource</returns>
        ApiResponse<TranslationApprovalCollectionResource> ApiProjectsApprovalsGetManyWithHttpInfo(int projectId, int? fileId = default(int?), int? stringId = default(int?), string languageId = default(string), int? translationId = default(int?), int? limit = default(int?), int? offset = default(int?));
        /// <summary>
        /// Add Approval
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationApprovalCreateForm"> (optional)</param>
        /// <returns>TranslationApprovalResource</returns>
        TranslationApprovalResource ApiProjectsApprovalsPost(int projectId, TranslationApprovalCreateForm translationApprovalCreateForm = default(TranslationApprovalCreateForm));

        /// <summary>
        /// Add Approval
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationApprovalCreateForm"> (optional)</param>
        /// <returns>ApiResponse of TranslationApprovalResource</returns>
        ApiResponse<TranslationApprovalResource> ApiProjectsApprovalsPostWithHttpInfo(int projectId, TranslationApprovalCreateForm translationApprovalCreateForm = default(TranslationApprovalCreateForm));
        /// <summary>
        /// List Language Translations
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <param name="stringIds">Filter translations by &#x60;stringIds&#x60; (optional)</param>
        /// <param name="labelIds">Filter translations by &#x60;labelIds&#x60; (optional)</param>
        /// <param name="fileId">Filter translations by &#x60;fileId&#x60; (optional)</param>
        /// <param name="croql">Filter translations by CroQL  __Note:__ Can&#39;t be used with &#x60;stringIds&#x60;, &#x60;labelIds&#x60; or &#x60;fileId&#x60; in same request (optional)</param>
        /// <param name="denormalizePlaceholders">Enable denormalize placeholders (optional, default to 0)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>OneOfPlainLanguageTranslationCollectionResourcePluralLanguageTranslationCollectionResourceIcuLanguageTranslationCollectionResource</returns>
        OneOfPlainLanguageTranslationCollectionResourcePluralLanguageTranslationCollectionResourceIcuLanguageTranslationCollectionResource ApiProjectsLanguagesTranslationsGetMany(int projectId, string languageId, string stringIds = default(string), string labelIds = default(string), int? fileId = default(int?), string croql = default(string), int? denormalizePlaceholders = default(int?), int? limit = default(int?), int? offset = default(int?));

        /// <summary>
        /// List Language Translations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <param name="stringIds">Filter translations by &#x60;stringIds&#x60; (optional)</param>
        /// <param name="labelIds">Filter translations by &#x60;labelIds&#x60; (optional)</param>
        /// <param name="fileId">Filter translations by &#x60;fileId&#x60; (optional)</param>
        /// <param name="croql">Filter translations by CroQL  __Note:__ Can&#39;t be used with &#x60;stringIds&#x60;, &#x60;labelIds&#x60; or &#x60;fileId&#x60; in same request (optional)</param>
        /// <param name="denormalizePlaceholders">Enable denormalize placeholders (optional, default to 0)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of OneOfPlainLanguageTranslationCollectionResourcePluralLanguageTranslationCollectionResourceIcuLanguageTranslationCollectionResource</returns>
        ApiResponse<OneOfPlainLanguageTranslationCollectionResourcePluralLanguageTranslationCollectionResourceIcuLanguageTranslationCollectionResource> ApiProjectsLanguagesTranslationsGetManyWithHttpInfo(int projectId, string languageId, string stringIds = default(string), string labelIds = default(string), int? fileId = default(int?), string croql = default(string), int? denormalizePlaceholders = default(int?), int? limit = default(int?), int? offset = default(int?));
        /// <summary>
        /// Delete Translation
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany)</param>
        /// <returns></returns>
        void ApiProjectsTranslationsDelete(int projectId, int translationId);

        /// <summary>
        /// Delete Translation
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiProjectsTranslationsDeleteWithHttpInfo(int projectId, int translationId);
        /// <summary>
        /// Delete String Translations
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <returns></returns>
        void ApiProjectsTranslationsDeleteMany(int projectId, int stringId, string languageId);

        /// <summary>
        /// Delete String Translations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiProjectsTranslationsDeleteManyWithHttpInfo(int projectId, int stringId, string languageId);
        /// <summary>
        /// Get Translation
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany)</param>
        /// <param name="denormalizePlaceholders">Enable denormalize placeholders (optional, default to 0)</param>
        /// <returns>TranslationResource</returns>
        TranslationResource ApiProjectsTranslationsGet(int projectId, int translationId, int? denormalizePlaceholders = default(int?));

        /// <summary>
        /// Get Translation
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany)</param>
        /// <param name="denormalizePlaceholders">Enable denormalize placeholders (optional, default to 0)</param>
        /// <returns>ApiResponse of TranslationResource</returns>
        ApiResponse<TranslationResource> ApiProjectsTranslationsGetWithHttpInfo(int projectId, int translationId, int? denormalizePlaceholders = default(int?));
        /// <summary>
        /// List String Translations
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <param name="denormalizePlaceholders">Enable denormalize placeholders (optional, default to 0)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>TranslationCollectionResource</returns>
        TranslationCollectionResource ApiProjectsTranslationsGetMany(int projectId, int stringId, string languageId, int? denormalizePlaceholders = default(int?), int? limit = default(int?), int? offset = default(int?));

        /// <summary>
        /// List String Translations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <param name="denormalizePlaceholders">Enable denormalize placeholders (optional, default to 0)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of TranslationCollectionResource</returns>
        ApiResponse<TranslationCollectionResource> ApiProjectsTranslationsGetManyWithHttpInfo(int projectId, int stringId, string languageId, int? denormalizePlaceholders = default(int?), int? limit = default(int?), int? offset = default(int?));
        /// <summary>
        /// Add Translation
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationCreateForm"> (optional)</param>
        /// <returns>TranslationResource</returns>
        TranslationResource ApiProjectsTranslationsPost(int projectId, TranslationCreateForm translationCreateForm = default(TranslationCreateForm));

        /// <summary>
        /// Add Translation
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationCreateForm"> (optional)</param>
        /// <returns>ApiResponse of TranslationResource</returns>
        ApiResponse<TranslationResource> ApiProjectsTranslationsPostWithHttpInfo(int projectId, TranslationCreateForm translationCreateForm = default(TranslationCreateForm));
        /// <summary>
        /// Restore Translation
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany)</param>
        /// <returns>TranslationResource</returns>
        TranslationResource ApiProjectsTranslationsPut(int projectId, int translationId);

        /// <summary>
        /// Restore Translation
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany)</param>
        /// <returns>ApiResponse of TranslationResource</returns>
        ApiResponse<TranslationResource> ApiProjectsTranslationsPutWithHttpInfo(int projectId, int translationId);
        /// <summary>
        /// Cancel Vote
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="voteId">Vote Identifier. Get via [List Translation Votes](#operation/api.projects.votes.getMany)</param>
        /// <returns></returns>
        void ApiProjectsVotesDelete(int projectId, int voteId);

        /// <summary>
        /// Cancel Vote
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="voteId">Vote Identifier. Get via [List Translation Votes](#operation/api.projects.votes.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiProjectsVotesDeleteWithHttpInfo(int projectId, int voteId);
        /// <summary>
        /// Get Vote
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="voteId">Vote Identifier. Get via [List Translation Votes](#operation/api.projects.votes.getMany)</param>
        /// <returns>TranslationVoteResource</returns>
        TranslationVoteResource ApiProjectsVotesGet(int projectId, int voteId);

        /// <summary>
        /// Get Vote
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="voteId">Vote Identifier. Get via [List Translation Votes](#operation/api.projects.votes.getMany)</param>
        /// <returns>ApiResponse of TranslationVoteResource</returns>
        ApiResponse<TranslationVoteResource> ApiProjectsVotesGetWithHttpInfo(int projectId, int voteId);
        /// <summary>
        /// List Translation Votes
        /// </summary>
        /// <remarks>
        /// __Note:__ Either &#x60;translationId&#x60; OR &#x60;stringId&#x60; with &#x60;languageId&#x60; are required
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany) &lt;br&gt; **Note:** Must be used together with &#x60;languageId&#x60; (optional)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get) &lt;br&gt; **Note:** Must be used together with &#x60;stringId&#x60; (optional)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany) &lt;br&gt; **Note:** If specified, &#x60;stringId&#x60; and &#x60;languageId&#x60; are ignored (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>TranslationVoteCollectionResource</returns>
        TranslationVoteCollectionResource ApiProjectsVotesGetMany(int projectId, int? stringId = default(int?), string languageId = default(string), int? translationId = default(int?), int? limit = default(int?), int? offset = default(int?));

        /// <summary>
        /// List Translation Votes
        /// </summary>
        /// <remarks>
        /// __Note:__ Either &#x60;translationId&#x60; OR &#x60;stringId&#x60; with &#x60;languageId&#x60; are required
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany) &lt;br&gt; **Note:** Must be used together with &#x60;languageId&#x60; (optional)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get) &lt;br&gt; **Note:** Must be used together with &#x60;stringId&#x60; (optional)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany) &lt;br&gt; **Note:** If specified, &#x60;stringId&#x60; and &#x60;languageId&#x60; are ignored (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of TranslationVoteCollectionResource</returns>
        ApiResponse<TranslationVoteCollectionResource> ApiProjectsVotesGetManyWithHttpInfo(int projectId, int? stringId = default(int?), string languageId = default(string), int? translationId = default(int?), int? limit = default(int?), int? offset = default(int?));
        /// <summary>
        /// Add Vote
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationVoteCreateForm"> (optional)</param>
        /// <returns>TranslationVoteResource</returns>
        TranslationVoteResource ApiProjectsVotesPost(int projectId, TranslationVoteCreateForm translationVoteCreateForm = default(TranslationVoteCreateForm));

        /// <summary>
        /// Add Vote
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationVoteCreateForm"> (optional)</param>
        /// <returns>ApiResponse of TranslationVoteResource</returns>
        ApiResponse<TranslationVoteResource> ApiProjectsVotesPostWithHttpInfo(int projectId, TranslationVoteCreateForm translationVoteCreateForm = default(TranslationVoteCreateForm));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IStringTranslationsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Remove Approval
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="approvalId">Approval Identifier. Get via [List Translation Approvals](#operation/api.projects.approvals.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiProjectsApprovalsDeleteAsync(int projectId, int approvalId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Remove Approval
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="approvalId">Approval Identifier. Get via [List Translation Approvals](#operation/api.projects.approvals.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiProjectsApprovalsDeleteWithHttpInfoAsync(int projectId, int approvalId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get Approval
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="approvalId">Approval Identifier. Get via [List Translation Approvals](#operation/api.projects.approvals.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TranslationApprovalResource</returns>
        System.Threading.Tasks.Task<TranslationApprovalResource> ApiProjectsApprovalsGetAsync(int projectId, int approvalId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get Approval
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="approvalId">Approval Identifier. Get via [List Translation Approvals](#operation/api.projects.approvals.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TranslationApprovalResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<TranslationApprovalResource>> ApiProjectsApprovalsGetWithHttpInfoAsync(int projectId, int approvalId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List Translation Approvals
        /// </summary>
        /// <remarks>
        /// __Note:__ Either &#x60;translationId&#x60; OR &#x60;fileId&#x60; with &#x60;languageId&#x60; OR &#x60;stringId&#x60; with &#x60;languageId&#x60; are required
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany) &lt;br&gt; **Note:** Must be used together with &#x60;languageId&#x60; (optional)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany) &lt;br&gt; **Note:** Must be used together with &#x60;languageId&#x60; (optional)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get) &lt;br&gt; **Note:** Must be used together with &#x60;stringId&#x60; or &#x60;fileId&#x60; (optional)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany) &lt;br&gt; **Note:** If specified, &#x60;fileId&#x60;, &#x60;stringId&#x60; and &#x60;languageId&#x60; are ignored (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TranslationApprovalCollectionResource</returns>
        System.Threading.Tasks.Task<TranslationApprovalCollectionResource> ApiProjectsApprovalsGetManyAsync(int projectId, int? fileId = default(int?), int? stringId = default(int?), string languageId = default(string), int? translationId = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List Translation Approvals
        /// </summary>
        /// <remarks>
        /// __Note:__ Either &#x60;translationId&#x60; OR &#x60;fileId&#x60; with &#x60;languageId&#x60; OR &#x60;stringId&#x60; with &#x60;languageId&#x60; are required
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany) &lt;br&gt; **Note:** Must be used together with &#x60;languageId&#x60; (optional)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany) &lt;br&gt; **Note:** Must be used together with &#x60;languageId&#x60; (optional)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get) &lt;br&gt; **Note:** Must be used together with &#x60;stringId&#x60; or &#x60;fileId&#x60; (optional)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany) &lt;br&gt; **Note:** If specified, &#x60;fileId&#x60;, &#x60;stringId&#x60; and &#x60;languageId&#x60; are ignored (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TranslationApprovalCollectionResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<TranslationApprovalCollectionResource>> ApiProjectsApprovalsGetManyWithHttpInfoAsync(int projectId, int? fileId = default(int?), int? stringId = default(int?), string languageId = default(string), int? translationId = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Add Approval
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationApprovalCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TranslationApprovalResource</returns>
        System.Threading.Tasks.Task<TranslationApprovalResource> ApiProjectsApprovalsPostAsync(int projectId, TranslationApprovalCreateForm translationApprovalCreateForm = default(TranslationApprovalCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Add Approval
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationApprovalCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TranslationApprovalResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<TranslationApprovalResource>> ApiProjectsApprovalsPostWithHttpInfoAsync(int projectId, TranslationApprovalCreateForm translationApprovalCreateForm = default(TranslationApprovalCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List Language Translations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <param name="stringIds">Filter translations by &#x60;stringIds&#x60; (optional)</param>
        /// <param name="labelIds">Filter translations by &#x60;labelIds&#x60; (optional)</param>
        /// <param name="fileId">Filter translations by &#x60;fileId&#x60; (optional)</param>
        /// <param name="croql">Filter translations by CroQL  __Note:__ Can&#39;t be used with &#x60;stringIds&#x60;, &#x60;labelIds&#x60; or &#x60;fileId&#x60; in same request (optional)</param>
        /// <param name="denormalizePlaceholders">Enable denormalize placeholders (optional, default to 0)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of OneOfPlainLanguageTranslationCollectionResourcePluralLanguageTranslationCollectionResourceIcuLanguageTranslationCollectionResource</returns>
        System.Threading.Tasks.Task<OneOfPlainLanguageTranslationCollectionResourcePluralLanguageTranslationCollectionResourceIcuLanguageTranslationCollectionResource> ApiProjectsLanguagesTranslationsGetManyAsync(int projectId, string languageId, string stringIds = default(string), string labelIds = default(string), int? fileId = default(int?), string croql = default(string), int? denormalizePlaceholders = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List Language Translations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <param name="stringIds">Filter translations by &#x60;stringIds&#x60; (optional)</param>
        /// <param name="labelIds">Filter translations by &#x60;labelIds&#x60; (optional)</param>
        /// <param name="fileId">Filter translations by &#x60;fileId&#x60; (optional)</param>
        /// <param name="croql">Filter translations by CroQL  __Note:__ Can&#39;t be used with &#x60;stringIds&#x60;, &#x60;labelIds&#x60; or &#x60;fileId&#x60; in same request (optional)</param>
        /// <param name="denormalizePlaceholders">Enable denormalize placeholders (optional, default to 0)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (OneOfPlainLanguageTranslationCollectionResourcePluralLanguageTranslationCollectionResourceIcuLanguageTranslationCollectionResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<OneOfPlainLanguageTranslationCollectionResourcePluralLanguageTranslationCollectionResourceIcuLanguageTranslationCollectionResource>> ApiProjectsLanguagesTranslationsGetManyWithHttpInfoAsync(int projectId, string languageId, string stringIds = default(string), string labelIds = default(string), int? fileId = default(int?), string croql = default(string), int? denormalizePlaceholders = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Delete Translation
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiProjectsTranslationsDeleteAsync(int projectId, int translationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete Translation
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiProjectsTranslationsDeleteWithHttpInfoAsync(int projectId, int translationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Delete String Translations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiProjectsTranslationsDeleteManyAsync(int projectId, int stringId, string languageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete String Translations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiProjectsTranslationsDeleteManyWithHttpInfoAsync(int projectId, int stringId, string languageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get Translation
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany)</param>
        /// <param name="denormalizePlaceholders">Enable denormalize placeholders (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TranslationResource</returns>
        System.Threading.Tasks.Task<TranslationResource> ApiProjectsTranslationsGetAsync(int projectId, int translationId, int? denormalizePlaceholders = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get Translation
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany)</param>
        /// <param name="denormalizePlaceholders">Enable denormalize placeholders (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TranslationResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<TranslationResource>> ApiProjectsTranslationsGetWithHttpInfoAsync(int projectId, int translationId, int? denormalizePlaceholders = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List String Translations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <param name="denormalizePlaceholders">Enable denormalize placeholders (optional, default to 0)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TranslationCollectionResource</returns>
        System.Threading.Tasks.Task<TranslationCollectionResource> ApiProjectsTranslationsGetManyAsync(int projectId, int stringId, string languageId, int? denormalizePlaceholders = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List String Translations
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <param name="denormalizePlaceholders">Enable denormalize placeholders (optional, default to 0)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TranslationCollectionResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<TranslationCollectionResource>> ApiProjectsTranslationsGetManyWithHttpInfoAsync(int projectId, int stringId, string languageId, int? denormalizePlaceholders = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Add Translation
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TranslationResource</returns>
        System.Threading.Tasks.Task<TranslationResource> ApiProjectsTranslationsPostAsync(int projectId, TranslationCreateForm translationCreateForm = default(TranslationCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Add Translation
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TranslationResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<TranslationResource>> ApiProjectsTranslationsPostWithHttpInfoAsync(int projectId, TranslationCreateForm translationCreateForm = default(TranslationCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Restore Translation
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TranslationResource</returns>
        System.Threading.Tasks.Task<TranslationResource> ApiProjectsTranslationsPutAsync(int projectId, int translationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Restore Translation
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TranslationResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<TranslationResource>> ApiProjectsTranslationsPutWithHttpInfoAsync(int projectId, int translationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Cancel Vote
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="voteId">Vote Identifier. Get via [List Translation Votes](#operation/api.projects.votes.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiProjectsVotesDeleteAsync(int projectId, int voteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Cancel Vote
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="voteId">Vote Identifier. Get via [List Translation Votes](#operation/api.projects.votes.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiProjectsVotesDeleteWithHttpInfoAsync(int projectId, int voteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get Vote
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="voteId">Vote Identifier. Get via [List Translation Votes](#operation/api.projects.votes.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TranslationVoteResource</returns>
        System.Threading.Tasks.Task<TranslationVoteResource> ApiProjectsVotesGetAsync(int projectId, int voteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get Vote
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="voteId">Vote Identifier. Get via [List Translation Votes](#operation/api.projects.votes.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TranslationVoteResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<TranslationVoteResource>> ApiProjectsVotesGetWithHttpInfoAsync(int projectId, int voteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List Translation Votes
        /// </summary>
        /// <remarks>
        /// __Note:__ Either &#x60;translationId&#x60; OR &#x60;stringId&#x60; with &#x60;languageId&#x60; are required
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany) &lt;br&gt; **Note:** Must be used together with &#x60;languageId&#x60; (optional)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get) &lt;br&gt; **Note:** Must be used together with &#x60;stringId&#x60; (optional)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany) &lt;br&gt; **Note:** If specified, &#x60;stringId&#x60; and &#x60;languageId&#x60; are ignored (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TranslationVoteCollectionResource</returns>
        System.Threading.Tasks.Task<TranslationVoteCollectionResource> ApiProjectsVotesGetManyAsync(int projectId, int? stringId = default(int?), string languageId = default(string), int? translationId = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List Translation Votes
        /// </summary>
        /// <remarks>
        /// __Note:__ Either &#x60;translationId&#x60; OR &#x60;stringId&#x60; with &#x60;languageId&#x60; are required
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany) &lt;br&gt; **Note:** Must be used together with &#x60;languageId&#x60; (optional)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get) &lt;br&gt; **Note:** Must be used together with &#x60;stringId&#x60; (optional)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany) &lt;br&gt; **Note:** If specified, &#x60;stringId&#x60; and &#x60;languageId&#x60; are ignored (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TranslationVoteCollectionResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<TranslationVoteCollectionResource>> ApiProjectsVotesGetManyWithHttpInfoAsync(int projectId, int? stringId = default(int?), string languageId = default(string), int? translationId = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Add Vote
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationVoteCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TranslationVoteResource</returns>
        System.Threading.Tasks.Task<TranslationVoteResource> ApiProjectsVotesPostAsync(int projectId, TranslationVoteCreateForm translationVoteCreateForm = default(TranslationVoteCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Add Vote
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationVoteCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TranslationVoteResource)</returns>
        System.Threading.Tasks.Task<ApiResponse<TranslationVoteResource>> ApiProjectsVotesPostWithHttpInfoAsync(int projectId, TranslationVoteCreateForm translationVoteCreateForm = default(TranslationVoteCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IStringTranslationsApi : IStringTranslationsApiSync, IStringTranslationsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class StringTranslationsApi : IStringTranslationsApi
    {
        private Crowdin.Api.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="StringTranslationsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public StringTranslationsApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringTranslationsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public StringTranslationsApi(string basePath)
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
        /// Initializes a new instance of the <see cref="StringTranslationsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public StringTranslationsApi(Crowdin.Api.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="StringTranslationsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public StringTranslationsApi(Crowdin.Api.Client.ISynchronousClient client, Crowdin.Api.Client.IAsynchronousClient asyncClient, Crowdin.Api.Client.IReadableConfiguration configuration)
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
        /// Remove Approval 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="approvalId">Approval Identifier. Get via [List Translation Approvals](#operation/api.projects.approvals.getMany)</param>
        /// <returns></returns>
        public void ApiProjectsApprovalsDelete(int projectId, int approvalId)
        {
            ApiProjectsApprovalsDeleteWithHttpInfo(projectId, approvalId);
        }

        /// <summary>
        /// Remove Approval 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="approvalId">Approval Identifier. Get via [List Translation Approvals](#operation/api.projects.approvals.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Crowdin.Api.Client.ApiResponse<Object> ApiProjectsApprovalsDeleteWithHttpInfo(int projectId, int approvalId)
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
            localVarRequestOptions.PathParameters.Add("approvalId", Crowdin.Api.Client.ClientUtils.ParameterToString(approvalId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/projects/{projectId}/approvals/{approvalId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsApprovalsDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Remove Approval 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="approvalId">Approval Identifier. Get via [List Translation Approvals](#operation/api.projects.approvals.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiProjectsApprovalsDeleteAsync(int projectId, int approvalId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiProjectsApprovalsDeleteWithHttpInfoAsync(projectId, approvalId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Remove Approval 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="approvalId">Approval Identifier. Get via [List Translation Approvals](#operation/api.projects.approvals.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<Object>> ApiProjectsApprovalsDeleteWithHttpInfoAsync(int projectId, int approvalId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("approvalId", Crowdin.Api.Client.ClientUtils.ParameterToString(approvalId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/projects/{projectId}/approvals/{approvalId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsApprovalsDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Approval 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="approvalId">Approval Identifier. Get via [List Translation Approvals](#operation/api.projects.approvals.getMany)</param>
        /// <returns>TranslationApprovalResource</returns>
        public TranslationApprovalResource ApiProjectsApprovalsGet(int projectId, int approvalId)
        {
            Crowdin.Api.Client.ApiResponse<TranslationApprovalResource> localVarResponse = ApiProjectsApprovalsGetWithHttpInfo(projectId, approvalId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Approval 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="approvalId">Approval Identifier. Get via [List Translation Approvals](#operation/api.projects.approvals.getMany)</param>
        /// <returns>ApiResponse of TranslationApprovalResource</returns>
        public Crowdin.Api.Client.ApiResponse<TranslationApprovalResource> ApiProjectsApprovalsGetWithHttpInfo(int projectId, int approvalId)
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
            localVarRequestOptions.PathParameters.Add("approvalId", Crowdin.Api.Client.ClientUtils.ParameterToString(approvalId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<TranslationApprovalResource>("/projects/{projectId}/approvals/{approvalId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsApprovalsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Approval 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="approvalId">Approval Identifier. Get via [List Translation Approvals](#operation/api.projects.approvals.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TranslationApprovalResource</returns>
        public async System.Threading.Tasks.Task<TranslationApprovalResource> ApiProjectsApprovalsGetAsync(int projectId, int approvalId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<TranslationApprovalResource> localVarResponse = await ApiProjectsApprovalsGetWithHttpInfoAsync(projectId, approvalId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Approval 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="approvalId">Approval Identifier. Get via [List Translation Approvals](#operation/api.projects.approvals.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TranslationApprovalResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<TranslationApprovalResource>> ApiProjectsApprovalsGetWithHttpInfoAsync(int projectId, int approvalId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("approvalId", Crowdin.Api.Client.ClientUtils.ParameterToString(approvalId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<TranslationApprovalResource>("/projects/{projectId}/approvals/{approvalId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsApprovalsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Translation Approvals __Note:__ Either &#x60;translationId&#x60; OR &#x60;fileId&#x60; with &#x60;languageId&#x60; OR &#x60;stringId&#x60; with &#x60;languageId&#x60; are required
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany) &lt;br&gt; **Note:** Must be used together with &#x60;languageId&#x60; (optional)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany) &lt;br&gt; **Note:** Must be used together with &#x60;languageId&#x60; (optional)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get) &lt;br&gt; **Note:** Must be used together with &#x60;stringId&#x60; or &#x60;fileId&#x60; (optional)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany) &lt;br&gt; **Note:** If specified, &#x60;fileId&#x60;, &#x60;stringId&#x60; and &#x60;languageId&#x60; are ignored (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>TranslationApprovalCollectionResource</returns>
        public TranslationApprovalCollectionResource ApiProjectsApprovalsGetMany(int projectId, int? fileId = default(int?), int? stringId = default(int?), string languageId = default(string), int? translationId = default(int?), int? limit = default(int?), int? offset = default(int?))
        {
            Crowdin.Api.Client.ApiResponse<TranslationApprovalCollectionResource> localVarResponse = ApiProjectsApprovalsGetManyWithHttpInfo(projectId, fileId, stringId, languageId, translationId, limit, offset);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Translation Approvals __Note:__ Either &#x60;translationId&#x60; OR &#x60;fileId&#x60; with &#x60;languageId&#x60; OR &#x60;stringId&#x60; with &#x60;languageId&#x60; are required
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany) &lt;br&gt; **Note:** Must be used together with &#x60;languageId&#x60; (optional)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany) &lt;br&gt; **Note:** Must be used together with &#x60;languageId&#x60; (optional)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get) &lt;br&gt; **Note:** Must be used together with &#x60;stringId&#x60; or &#x60;fileId&#x60; (optional)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany) &lt;br&gt; **Note:** If specified, &#x60;fileId&#x60;, &#x60;stringId&#x60; and &#x60;languageId&#x60; are ignored (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of TranslationApprovalCollectionResource</returns>
        public Crowdin.Api.Client.ApiResponse<TranslationApprovalCollectionResource> ApiProjectsApprovalsGetManyWithHttpInfo(int projectId, int? fileId = default(int?), int? stringId = default(int?), string languageId = default(string), int? translationId = default(int?), int? limit = default(int?), int? offset = default(int?))
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
            if (fileId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "fileId", fileId));
            }
            if (stringId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "stringId", stringId));
            }
            if (languageId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "languageId", languageId));
            }
            if (translationId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "translationId", translationId));
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
            var localVarResponse = this.Client.Get<TranslationApprovalCollectionResource>("/projects/{projectId}/approvals", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsApprovalsGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Translation Approvals __Note:__ Either &#x60;translationId&#x60; OR &#x60;fileId&#x60; with &#x60;languageId&#x60; OR &#x60;stringId&#x60; with &#x60;languageId&#x60; are required
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany) &lt;br&gt; **Note:** Must be used together with &#x60;languageId&#x60; (optional)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany) &lt;br&gt; **Note:** Must be used together with &#x60;languageId&#x60; (optional)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get) &lt;br&gt; **Note:** Must be used together with &#x60;stringId&#x60; or &#x60;fileId&#x60; (optional)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany) &lt;br&gt; **Note:** If specified, &#x60;fileId&#x60;, &#x60;stringId&#x60; and &#x60;languageId&#x60; are ignored (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TranslationApprovalCollectionResource</returns>
        public async System.Threading.Tasks.Task<TranslationApprovalCollectionResource> ApiProjectsApprovalsGetManyAsync(int projectId, int? fileId = default(int?), int? stringId = default(int?), string languageId = default(string), int? translationId = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<TranslationApprovalCollectionResource> localVarResponse = await ApiProjectsApprovalsGetManyWithHttpInfoAsync(projectId, fileId, stringId, languageId, translationId, limit, offset, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Translation Approvals __Note:__ Either &#x60;translationId&#x60; OR &#x60;fileId&#x60; with &#x60;languageId&#x60; OR &#x60;stringId&#x60; with &#x60;languageId&#x60; are required
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="fileId">File Identifier. Get via [List Files](#operation/api.projects.files.getMany) &lt;br&gt; **Note:** Must be used together with &#x60;languageId&#x60; (optional)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany) &lt;br&gt; **Note:** Must be used together with &#x60;languageId&#x60; (optional)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get) &lt;br&gt; **Note:** Must be used together with &#x60;stringId&#x60; or &#x60;fileId&#x60; (optional)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany) &lt;br&gt; **Note:** If specified, &#x60;fileId&#x60;, &#x60;stringId&#x60; and &#x60;languageId&#x60; are ignored (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TranslationApprovalCollectionResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<TranslationApprovalCollectionResource>> ApiProjectsApprovalsGetManyWithHttpInfoAsync(int projectId, int? fileId = default(int?), int? stringId = default(int?), string languageId = default(string), int? translationId = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            if (fileId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "fileId", fileId));
            }
            if (stringId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "stringId", stringId));
            }
            if (languageId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "languageId", languageId));
            }
            if (translationId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "translationId", translationId));
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

            var localVarResponse = await this.AsynchronousClient.GetAsync<TranslationApprovalCollectionResource>("/projects/{projectId}/approvals", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsApprovalsGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add Approval 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationApprovalCreateForm"> (optional)</param>
        /// <returns>TranslationApprovalResource</returns>
        public TranslationApprovalResource ApiProjectsApprovalsPost(int projectId, TranslationApprovalCreateForm translationApprovalCreateForm = default(TranslationApprovalCreateForm))
        {
            Crowdin.Api.Client.ApiResponse<TranslationApprovalResource> localVarResponse = ApiProjectsApprovalsPostWithHttpInfo(projectId, translationApprovalCreateForm);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add Approval 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationApprovalCreateForm"> (optional)</param>
        /// <returns>ApiResponse of TranslationApprovalResource</returns>
        public Crowdin.Api.Client.ApiResponse<TranslationApprovalResource> ApiProjectsApprovalsPostWithHttpInfo(int projectId, TranslationApprovalCreateForm translationApprovalCreateForm = default(TranslationApprovalCreateForm))
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
            localVarRequestOptions.Data = translationApprovalCreateForm;


            // make the HTTP request
            var localVarResponse = this.Client.Post<TranslationApprovalResource>("/projects/{projectId}/approvals", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsApprovalsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add Approval 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationApprovalCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TranslationApprovalResource</returns>
        public async System.Threading.Tasks.Task<TranslationApprovalResource> ApiProjectsApprovalsPostAsync(int projectId, TranslationApprovalCreateForm translationApprovalCreateForm = default(TranslationApprovalCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<TranslationApprovalResource> localVarResponse = await ApiProjectsApprovalsPostWithHttpInfoAsync(projectId, translationApprovalCreateForm, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add Approval 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationApprovalCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TranslationApprovalResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<TranslationApprovalResource>> ApiProjectsApprovalsPostWithHttpInfoAsync(int projectId, TranslationApprovalCreateForm translationApprovalCreateForm = default(TranslationApprovalCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.Data = translationApprovalCreateForm;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<TranslationApprovalResource>("/projects/{projectId}/approvals", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsApprovalsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Language Translations 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <param name="stringIds">Filter translations by &#x60;stringIds&#x60; (optional)</param>
        /// <param name="labelIds">Filter translations by &#x60;labelIds&#x60; (optional)</param>
        /// <param name="fileId">Filter translations by &#x60;fileId&#x60; (optional)</param>
        /// <param name="croql">Filter translations by CroQL  __Note:__ Can&#39;t be used with &#x60;stringIds&#x60;, &#x60;labelIds&#x60; or &#x60;fileId&#x60; in same request (optional)</param>
        /// <param name="denormalizePlaceholders">Enable denormalize placeholders (optional, default to 0)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>OneOfPlainLanguageTranslationCollectionResourcePluralLanguageTranslationCollectionResourceIcuLanguageTranslationCollectionResource</returns>
        public OneOfPlainLanguageTranslationCollectionResourcePluralLanguageTranslationCollectionResourceIcuLanguageTranslationCollectionResource ApiProjectsLanguagesTranslationsGetMany(int projectId, string languageId, string stringIds = default(string), string labelIds = default(string), int? fileId = default(int?), string croql = default(string), int? denormalizePlaceholders = default(int?), int? limit = default(int?), int? offset = default(int?))
        {
            Crowdin.Api.Client.ApiResponse<OneOfPlainLanguageTranslationCollectionResourcePluralLanguageTranslationCollectionResourceIcuLanguageTranslationCollectionResource> localVarResponse = ApiProjectsLanguagesTranslationsGetManyWithHttpInfo(projectId, languageId, stringIds, labelIds, fileId, croql, denormalizePlaceholders, limit, offset);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Language Translations 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <param name="stringIds">Filter translations by &#x60;stringIds&#x60; (optional)</param>
        /// <param name="labelIds">Filter translations by &#x60;labelIds&#x60; (optional)</param>
        /// <param name="fileId">Filter translations by &#x60;fileId&#x60; (optional)</param>
        /// <param name="croql">Filter translations by CroQL  __Note:__ Can&#39;t be used with &#x60;stringIds&#x60;, &#x60;labelIds&#x60; or &#x60;fileId&#x60; in same request (optional)</param>
        /// <param name="denormalizePlaceholders">Enable denormalize placeholders (optional, default to 0)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of OneOfPlainLanguageTranslationCollectionResourcePluralLanguageTranslationCollectionResourceIcuLanguageTranslationCollectionResource</returns>
        public Crowdin.Api.Client.ApiResponse<OneOfPlainLanguageTranslationCollectionResourcePluralLanguageTranslationCollectionResourceIcuLanguageTranslationCollectionResource> ApiProjectsLanguagesTranslationsGetManyWithHttpInfo(int projectId, string languageId, string stringIds = default(string), string labelIds = default(string), int? fileId = default(int?), string croql = default(string), int? denormalizePlaceholders = default(int?), int? limit = default(int?), int? offset = default(int?))
        {
            // verify the required parameter 'languageId' is set
            if (languageId == null)
                throw new Crowdin.Api.Client.ApiException(400, "Missing required parameter 'languageId' when calling StringTranslationsApi->ApiProjectsLanguagesTranslationsGetMany");

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
            localVarRequestOptions.PathParameters.Add("languageId", Crowdin.Api.Client.ClientUtils.ParameterToString(languageId)); // path parameter
            if (stringIds != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "stringIds", stringIds));
            }
            if (labelIds != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "labelIds", labelIds));
            }
            if (fileId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "fileId", fileId));
            }
            if (croql != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "croql", croql));
            }
            if (denormalizePlaceholders != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "denormalizePlaceholders", denormalizePlaceholders));
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
            var localVarResponse = this.Client.Get<OneOfPlainLanguageTranslationCollectionResourcePluralLanguageTranslationCollectionResourceIcuLanguageTranslationCollectionResource>("/projects/{projectId}/languages/{languageId}/translations", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsLanguagesTranslationsGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Language Translations 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <param name="stringIds">Filter translations by &#x60;stringIds&#x60; (optional)</param>
        /// <param name="labelIds">Filter translations by &#x60;labelIds&#x60; (optional)</param>
        /// <param name="fileId">Filter translations by &#x60;fileId&#x60; (optional)</param>
        /// <param name="croql">Filter translations by CroQL  __Note:__ Can&#39;t be used with &#x60;stringIds&#x60;, &#x60;labelIds&#x60; or &#x60;fileId&#x60; in same request (optional)</param>
        /// <param name="denormalizePlaceholders">Enable denormalize placeholders (optional, default to 0)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of OneOfPlainLanguageTranslationCollectionResourcePluralLanguageTranslationCollectionResourceIcuLanguageTranslationCollectionResource</returns>
        public async System.Threading.Tasks.Task<OneOfPlainLanguageTranslationCollectionResourcePluralLanguageTranslationCollectionResourceIcuLanguageTranslationCollectionResource> ApiProjectsLanguagesTranslationsGetManyAsync(int projectId, string languageId, string stringIds = default(string), string labelIds = default(string), int? fileId = default(int?), string croql = default(string), int? denormalizePlaceholders = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<OneOfPlainLanguageTranslationCollectionResourcePluralLanguageTranslationCollectionResourceIcuLanguageTranslationCollectionResource> localVarResponse = await ApiProjectsLanguagesTranslationsGetManyWithHttpInfoAsync(projectId, languageId, stringIds, labelIds, fileId, croql, denormalizePlaceholders, limit, offset, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Language Translations 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <param name="stringIds">Filter translations by &#x60;stringIds&#x60; (optional)</param>
        /// <param name="labelIds">Filter translations by &#x60;labelIds&#x60; (optional)</param>
        /// <param name="fileId">Filter translations by &#x60;fileId&#x60; (optional)</param>
        /// <param name="croql">Filter translations by CroQL  __Note:__ Can&#39;t be used with &#x60;stringIds&#x60;, &#x60;labelIds&#x60; or &#x60;fileId&#x60; in same request (optional)</param>
        /// <param name="denormalizePlaceholders">Enable denormalize placeholders (optional, default to 0)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (OneOfPlainLanguageTranslationCollectionResourcePluralLanguageTranslationCollectionResourceIcuLanguageTranslationCollectionResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<OneOfPlainLanguageTranslationCollectionResourcePluralLanguageTranslationCollectionResourceIcuLanguageTranslationCollectionResource>> ApiProjectsLanguagesTranslationsGetManyWithHttpInfoAsync(int projectId, string languageId, string stringIds = default(string), string labelIds = default(string), int? fileId = default(int?), string croql = default(string), int? denormalizePlaceholders = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'languageId' is set
            if (languageId == null)
                throw new Crowdin.Api.Client.ApiException(400, "Missing required parameter 'languageId' when calling StringTranslationsApi->ApiProjectsLanguagesTranslationsGetMany");


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
            localVarRequestOptions.PathParameters.Add("languageId", Crowdin.Api.Client.ClientUtils.ParameterToString(languageId)); // path parameter
            if (stringIds != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "stringIds", stringIds));
            }
            if (labelIds != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "labelIds", labelIds));
            }
            if (fileId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "fileId", fileId));
            }
            if (croql != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "croql", croql));
            }
            if (denormalizePlaceholders != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "denormalizePlaceholders", denormalizePlaceholders));
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

            var localVarResponse = await this.AsynchronousClient.GetAsync<OneOfPlainLanguageTranslationCollectionResourcePluralLanguageTranslationCollectionResourceIcuLanguageTranslationCollectionResource>("/projects/{projectId}/languages/{languageId}/translations", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsLanguagesTranslationsGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany)</param>
        /// <returns></returns>
        public void ApiProjectsTranslationsDelete(int projectId, int translationId)
        {
            ApiProjectsTranslationsDeleteWithHttpInfo(projectId, translationId);
        }

        /// <summary>
        /// Delete Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Crowdin.Api.Client.ApiResponse<Object> ApiProjectsTranslationsDeleteWithHttpInfo(int projectId, int translationId)
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
            localVarRequestOptions.PathParameters.Add("translationId", Crowdin.Api.Client.ClientUtils.ParameterToString(translationId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/projects/{projectId}/translations/{translationId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsTranslationsDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiProjectsTranslationsDeleteAsync(int projectId, int translationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiProjectsTranslationsDeleteWithHttpInfoAsync(projectId, translationId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<Object>> ApiProjectsTranslationsDeleteWithHttpInfoAsync(int projectId, int translationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("translationId", Crowdin.Api.Client.ClientUtils.ParameterToString(translationId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/projects/{projectId}/translations/{translationId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsTranslationsDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete String Translations 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <returns></returns>
        public void ApiProjectsTranslationsDeleteMany(int projectId, int stringId, string languageId)
        {
            ApiProjectsTranslationsDeleteManyWithHttpInfo(projectId, stringId, languageId);
        }

        /// <summary>
        /// Delete String Translations 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Crowdin.Api.Client.ApiResponse<Object> ApiProjectsTranslationsDeleteManyWithHttpInfo(int projectId, int stringId, string languageId)
        {
            // verify the required parameter 'languageId' is set
            if (languageId == null)
                throw new Crowdin.Api.Client.ApiException(400, "Missing required parameter 'languageId' when calling StringTranslationsApi->ApiProjectsTranslationsDeleteMany");

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
            localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "stringId", stringId));
            localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "languageId", languageId));


            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/projects/{projectId}/translations", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsTranslationsDeleteMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete String Translations 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiProjectsTranslationsDeleteManyAsync(int projectId, int stringId, string languageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiProjectsTranslationsDeleteManyWithHttpInfoAsync(projectId, stringId, languageId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete String Translations 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<Object>> ApiProjectsTranslationsDeleteManyWithHttpInfoAsync(int projectId, int stringId, string languageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'languageId' is set
            if (languageId == null)
                throw new Crowdin.Api.Client.ApiException(400, "Missing required parameter 'languageId' when calling StringTranslationsApi->ApiProjectsTranslationsDeleteMany");


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
            localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "stringId", stringId));
            localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "languageId", languageId));


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/projects/{projectId}/translations", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsTranslationsDeleteMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany)</param>
        /// <param name="denormalizePlaceholders">Enable denormalize placeholders (optional, default to 0)</param>
        /// <returns>TranslationResource</returns>
        public TranslationResource ApiProjectsTranslationsGet(int projectId, int translationId, int? denormalizePlaceholders = default(int?))
        {
            Crowdin.Api.Client.ApiResponse<TranslationResource> localVarResponse = ApiProjectsTranslationsGetWithHttpInfo(projectId, translationId, denormalizePlaceholders);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany)</param>
        /// <param name="denormalizePlaceholders">Enable denormalize placeholders (optional, default to 0)</param>
        /// <returns>ApiResponse of TranslationResource</returns>
        public Crowdin.Api.Client.ApiResponse<TranslationResource> ApiProjectsTranslationsGetWithHttpInfo(int projectId, int translationId, int? denormalizePlaceholders = default(int?))
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
            localVarRequestOptions.PathParameters.Add("translationId", Crowdin.Api.Client.ClientUtils.ParameterToString(translationId)); // path parameter
            if (denormalizePlaceholders != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "denormalizePlaceholders", denormalizePlaceholders));
            }


            // make the HTTP request
            var localVarResponse = this.Client.Get<TranslationResource>("/projects/{projectId}/translations/{translationId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsTranslationsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany)</param>
        /// <param name="denormalizePlaceholders">Enable denormalize placeholders (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TranslationResource</returns>
        public async System.Threading.Tasks.Task<TranslationResource> ApiProjectsTranslationsGetAsync(int projectId, int translationId, int? denormalizePlaceholders = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<TranslationResource> localVarResponse = await ApiProjectsTranslationsGetWithHttpInfoAsync(projectId, translationId, denormalizePlaceholders, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany)</param>
        /// <param name="denormalizePlaceholders">Enable denormalize placeholders (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TranslationResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<TranslationResource>> ApiProjectsTranslationsGetWithHttpInfoAsync(int projectId, int translationId, int? denormalizePlaceholders = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("translationId", Crowdin.Api.Client.ClientUtils.ParameterToString(translationId)); // path parameter
            if (denormalizePlaceholders != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "denormalizePlaceholders", denormalizePlaceholders));
            }


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<TranslationResource>("/projects/{projectId}/translations/{translationId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsTranslationsGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List String Translations 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <param name="denormalizePlaceholders">Enable denormalize placeholders (optional, default to 0)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>TranslationCollectionResource</returns>
        public TranslationCollectionResource ApiProjectsTranslationsGetMany(int projectId, int stringId, string languageId, int? denormalizePlaceholders = default(int?), int? limit = default(int?), int? offset = default(int?))
        {
            Crowdin.Api.Client.ApiResponse<TranslationCollectionResource> localVarResponse = ApiProjectsTranslationsGetManyWithHttpInfo(projectId, stringId, languageId, denormalizePlaceholders, limit, offset);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List String Translations 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <param name="denormalizePlaceholders">Enable denormalize placeholders (optional, default to 0)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of TranslationCollectionResource</returns>
        public Crowdin.Api.Client.ApiResponse<TranslationCollectionResource> ApiProjectsTranslationsGetManyWithHttpInfo(int projectId, int stringId, string languageId, int? denormalizePlaceholders = default(int?), int? limit = default(int?), int? offset = default(int?))
        {
            // verify the required parameter 'languageId' is set
            if (languageId == null)
                throw new Crowdin.Api.Client.ApiException(400, "Missing required parameter 'languageId' when calling StringTranslationsApi->ApiProjectsTranslationsGetMany");

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
            localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "stringId", stringId));
            localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "languageId", languageId));
            if (denormalizePlaceholders != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "denormalizePlaceholders", denormalizePlaceholders));
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
            var localVarResponse = this.Client.Get<TranslationCollectionResource>("/projects/{projectId}/translations", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsTranslationsGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List String Translations 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <param name="denormalizePlaceholders">Enable denormalize placeholders (optional, default to 0)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TranslationCollectionResource</returns>
        public async System.Threading.Tasks.Task<TranslationCollectionResource> ApiProjectsTranslationsGetManyAsync(int projectId, int stringId, string languageId, int? denormalizePlaceholders = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<TranslationCollectionResource> localVarResponse = await ApiProjectsTranslationsGetManyWithHttpInfoAsync(projectId, stringId, languageId, denormalizePlaceholders, limit, offset, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List String Translations 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</param>
        /// <param name="denormalizePlaceholders">Enable denormalize placeholders (optional, default to 0)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TranslationCollectionResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<TranslationCollectionResource>> ApiProjectsTranslationsGetManyWithHttpInfoAsync(int projectId, int stringId, string languageId, int? denormalizePlaceholders = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'languageId' is set
            if (languageId == null)
                throw new Crowdin.Api.Client.ApiException(400, "Missing required parameter 'languageId' when calling StringTranslationsApi->ApiProjectsTranslationsGetMany");


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
            localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "stringId", stringId));
            localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "languageId", languageId));
            if (denormalizePlaceholders != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "denormalizePlaceholders", denormalizePlaceholders));
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

            var localVarResponse = await this.AsynchronousClient.GetAsync<TranslationCollectionResource>("/projects/{projectId}/translations", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsTranslationsGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationCreateForm"> (optional)</param>
        /// <returns>TranslationResource</returns>
        public TranslationResource ApiProjectsTranslationsPost(int projectId, TranslationCreateForm translationCreateForm = default(TranslationCreateForm))
        {
            Crowdin.Api.Client.ApiResponse<TranslationResource> localVarResponse = ApiProjectsTranslationsPostWithHttpInfo(projectId, translationCreateForm);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationCreateForm"> (optional)</param>
        /// <returns>ApiResponse of TranslationResource</returns>
        public Crowdin.Api.Client.ApiResponse<TranslationResource> ApiProjectsTranslationsPostWithHttpInfo(int projectId, TranslationCreateForm translationCreateForm = default(TranslationCreateForm))
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
            localVarRequestOptions.Data = translationCreateForm;


            // make the HTTP request
            var localVarResponse = this.Client.Post<TranslationResource>("/projects/{projectId}/translations", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsTranslationsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TranslationResource</returns>
        public async System.Threading.Tasks.Task<TranslationResource> ApiProjectsTranslationsPostAsync(int projectId, TranslationCreateForm translationCreateForm = default(TranslationCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<TranslationResource> localVarResponse = await ApiProjectsTranslationsPostWithHttpInfoAsync(projectId, translationCreateForm, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TranslationResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<TranslationResource>> ApiProjectsTranslationsPostWithHttpInfoAsync(int projectId, TranslationCreateForm translationCreateForm = default(TranslationCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.Data = translationCreateForm;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<TranslationResource>("/projects/{projectId}/translations", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsTranslationsPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Restore Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany)</param>
        /// <returns>TranslationResource</returns>
        public TranslationResource ApiProjectsTranslationsPut(int projectId, int translationId)
        {
            Crowdin.Api.Client.ApiResponse<TranslationResource> localVarResponse = ApiProjectsTranslationsPutWithHttpInfo(projectId, translationId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Restore Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany)</param>
        /// <returns>ApiResponse of TranslationResource</returns>
        public Crowdin.Api.Client.ApiResponse<TranslationResource> ApiProjectsTranslationsPutWithHttpInfo(int projectId, int translationId)
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
            localVarRequestOptions.PathParameters.Add("translationId", Crowdin.Api.Client.ClientUtils.ParameterToString(translationId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Put<TranslationResource>("/projects/{projectId}/translations/{translationId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsTranslationsPut", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Restore Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TranslationResource</returns>
        public async System.Threading.Tasks.Task<TranslationResource> ApiProjectsTranslationsPutAsync(int projectId, int translationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<TranslationResource> localVarResponse = await ApiProjectsTranslationsPutWithHttpInfoAsync(projectId, translationId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Restore Translation 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TranslationResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<TranslationResource>> ApiProjectsTranslationsPutWithHttpInfoAsync(int projectId, int translationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("translationId", Crowdin.Api.Client.ClientUtils.ParameterToString(translationId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PutAsync<TranslationResource>("/projects/{projectId}/translations/{translationId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsTranslationsPut", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Cancel Vote 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="voteId">Vote Identifier. Get via [List Translation Votes](#operation/api.projects.votes.getMany)</param>
        /// <returns></returns>
        public void ApiProjectsVotesDelete(int projectId, int voteId)
        {
            ApiProjectsVotesDeleteWithHttpInfo(projectId, voteId);
        }

        /// <summary>
        /// Cancel Vote 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="voteId">Vote Identifier. Get via [List Translation Votes](#operation/api.projects.votes.getMany)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Crowdin.Api.Client.ApiResponse<Object> ApiProjectsVotesDeleteWithHttpInfo(int projectId, int voteId)
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
            localVarRequestOptions.PathParameters.Add("voteId", Crowdin.Api.Client.ClientUtils.ParameterToString(voteId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/projects/{projectId}/votes/{voteId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsVotesDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Cancel Vote 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="voteId">Vote Identifier. Get via [List Translation Votes](#operation/api.projects.votes.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiProjectsVotesDeleteAsync(int projectId, int voteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiProjectsVotesDeleteWithHttpInfoAsync(projectId, voteId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Cancel Vote 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="voteId">Vote Identifier. Get via [List Translation Votes](#operation/api.projects.votes.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<Object>> ApiProjectsVotesDeleteWithHttpInfoAsync(int projectId, int voteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("voteId", Crowdin.Api.Client.ClientUtils.ParameterToString(voteId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/projects/{projectId}/votes/{voteId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsVotesDelete", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Vote 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="voteId">Vote Identifier. Get via [List Translation Votes](#operation/api.projects.votes.getMany)</param>
        /// <returns>TranslationVoteResource</returns>
        public TranslationVoteResource ApiProjectsVotesGet(int projectId, int voteId)
        {
            Crowdin.Api.Client.ApiResponse<TranslationVoteResource> localVarResponse = ApiProjectsVotesGetWithHttpInfo(projectId, voteId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Vote 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="voteId">Vote Identifier. Get via [List Translation Votes](#operation/api.projects.votes.getMany)</param>
        /// <returns>ApiResponse of TranslationVoteResource</returns>
        public Crowdin.Api.Client.ApiResponse<TranslationVoteResource> ApiProjectsVotesGetWithHttpInfo(int projectId, int voteId)
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
            localVarRequestOptions.PathParameters.Add("voteId", Crowdin.Api.Client.ClientUtils.ParameterToString(voteId)); // path parameter


            // make the HTTP request
            var localVarResponse = this.Client.Get<TranslationVoteResource>("/projects/{projectId}/votes/{voteId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsVotesGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get Vote 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="voteId">Vote Identifier. Get via [List Translation Votes](#operation/api.projects.votes.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TranslationVoteResource</returns>
        public async System.Threading.Tasks.Task<TranslationVoteResource> ApiProjectsVotesGetAsync(int projectId, int voteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<TranslationVoteResource> localVarResponse = await ApiProjectsVotesGetWithHttpInfoAsync(projectId, voteId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get Vote 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="voteId">Vote Identifier. Get via [List Translation Votes](#operation/api.projects.votes.getMany)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TranslationVoteResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<TranslationVoteResource>> ApiProjectsVotesGetWithHttpInfoAsync(int projectId, int voteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.PathParameters.Add("voteId", Crowdin.Api.Client.ClientUtils.ParameterToString(voteId)); // path parameter


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<TranslationVoteResource>("/projects/{projectId}/votes/{voteId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsVotesGet", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Translation Votes __Note:__ Either &#x60;translationId&#x60; OR &#x60;stringId&#x60; with &#x60;languageId&#x60; are required
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany) &lt;br&gt; **Note:** Must be used together with &#x60;languageId&#x60; (optional)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get) &lt;br&gt; **Note:** Must be used together with &#x60;stringId&#x60; (optional)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany) &lt;br&gt; **Note:** If specified, &#x60;stringId&#x60; and &#x60;languageId&#x60; are ignored (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>TranslationVoteCollectionResource</returns>
        public TranslationVoteCollectionResource ApiProjectsVotesGetMany(int projectId, int? stringId = default(int?), string languageId = default(string), int? translationId = default(int?), int? limit = default(int?), int? offset = default(int?))
        {
            Crowdin.Api.Client.ApiResponse<TranslationVoteCollectionResource> localVarResponse = ApiProjectsVotesGetManyWithHttpInfo(projectId, stringId, languageId, translationId, limit, offset);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Translation Votes __Note:__ Either &#x60;translationId&#x60; OR &#x60;stringId&#x60; with &#x60;languageId&#x60; are required
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany) &lt;br&gt; **Note:** Must be used together with &#x60;languageId&#x60; (optional)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get) &lt;br&gt; **Note:** Must be used together with &#x60;stringId&#x60; (optional)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany) &lt;br&gt; **Note:** If specified, &#x60;stringId&#x60; and &#x60;languageId&#x60; are ignored (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <returns>ApiResponse of TranslationVoteCollectionResource</returns>
        public Crowdin.Api.Client.ApiResponse<TranslationVoteCollectionResource> ApiProjectsVotesGetManyWithHttpInfo(int projectId, int? stringId = default(int?), string languageId = default(string), int? translationId = default(int?), int? limit = default(int?), int? offset = default(int?))
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
            if (stringId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "stringId", stringId));
            }
            if (languageId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "languageId", languageId));
            }
            if (translationId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "translationId", translationId));
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
            var localVarResponse = this.Client.Get<TranslationVoteCollectionResource>("/projects/{projectId}/votes", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsVotesGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// List Translation Votes __Note:__ Either &#x60;translationId&#x60; OR &#x60;stringId&#x60; with &#x60;languageId&#x60; are required
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany) &lt;br&gt; **Note:** Must be used together with &#x60;languageId&#x60; (optional)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get) &lt;br&gt; **Note:** Must be used together with &#x60;stringId&#x60; (optional)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany) &lt;br&gt; **Note:** If specified, &#x60;stringId&#x60; and &#x60;languageId&#x60; are ignored (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TranslationVoteCollectionResource</returns>
        public async System.Threading.Tasks.Task<TranslationVoteCollectionResource> ApiProjectsVotesGetManyAsync(int projectId, int? stringId = default(int?), string languageId = default(string), int? translationId = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<TranslationVoteCollectionResource> localVarResponse = await ApiProjectsVotesGetManyWithHttpInfoAsync(projectId, stringId, languageId, translationId, limit, offset, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List Translation Votes __Note:__ Either &#x60;translationId&#x60; OR &#x60;stringId&#x60; with &#x60;languageId&#x60; are required
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany) &lt;br&gt; **Note:** Must be used together with &#x60;languageId&#x60; (optional)</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get) &lt;br&gt; **Note:** Must be used together with &#x60;stringId&#x60; (optional)</param>
        /// <param name="translationId">Translation Identifier. Get via [List String Translations](#operation/api.projects.translations.getMany) &lt;br&gt; **Note:** If specified, &#x60;stringId&#x60; and &#x60;languageId&#x60; are ignored (optional)</param>
        /// <param name="limit">A maximum number of items to retrieve (optional, default to 25)</param>
        /// <param name="offset">A starting offset in the collection (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TranslationVoteCollectionResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<TranslationVoteCollectionResource>> ApiProjectsVotesGetManyWithHttpInfoAsync(int projectId, int? stringId = default(int?), string languageId = default(string), int? translationId = default(int?), int? limit = default(int?), int? offset = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            if (stringId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "stringId", stringId));
            }
            if (languageId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "languageId", languageId));
            }
            if (translationId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Crowdin.Api.Client.ClientUtils.ParameterToMultiMap("", "translationId", translationId));
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

            var localVarResponse = await this.AsynchronousClient.GetAsync<TranslationVoteCollectionResource>("/projects/{projectId}/votes", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsVotesGetMany", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add Vote 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationVoteCreateForm"> (optional)</param>
        /// <returns>TranslationVoteResource</returns>
        public TranslationVoteResource ApiProjectsVotesPost(int projectId, TranslationVoteCreateForm translationVoteCreateForm = default(TranslationVoteCreateForm))
        {
            Crowdin.Api.Client.ApiResponse<TranslationVoteResource> localVarResponse = ApiProjectsVotesPostWithHttpInfo(projectId, translationVoteCreateForm);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add Vote 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationVoteCreateForm"> (optional)</param>
        /// <returns>ApiResponse of TranslationVoteResource</returns>
        public Crowdin.Api.Client.ApiResponse<TranslationVoteResource> ApiProjectsVotesPostWithHttpInfo(int projectId, TranslationVoteCreateForm translationVoteCreateForm = default(TranslationVoteCreateForm))
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
            localVarRequestOptions.Data = translationVoteCreateForm;


            // make the HTTP request
            var localVarResponse = this.Client.Post<TranslationVoteResource>("/projects/{projectId}/votes", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsVotesPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add Vote 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationVoteCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of TranslationVoteResource</returns>
        public async System.Threading.Tasks.Task<TranslationVoteResource> ApiProjectsVotesPostAsync(int projectId, TranslationVoteCreateForm translationVoteCreateForm = default(TranslationVoteCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Crowdin.Api.Client.ApiResponse<TranslationVoteResource> localVarResponse = await ApiProjectsVotesPostWithHttpInfoAsync(projectId, translationVoteCreateForm, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add Vote 
        /// </summary>
        /// <exception cref="Crowdin.Api.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">Project Identifier. Get via [List Projects](#operation/api.projects.getMany)</param>
        /// <param name="translationVoteCreateForm"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (TranslationVoteResource)</returns>
        public async System.Threading.Tasks.Task<Crowdin.Api.Client.ApiResponse<TranslationVoteResource>> ApiProjectsVotesPostWithHttpInfoAsync(int projectId, TranslationVoteCreateForm translationVoteCreateForm = default(TranslationVoteCreateForm), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.Data = translationVoteCreateForm;


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<TranslationVoteResource>("/projects/{projectId}/votes", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiProjectsVotesPost", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
