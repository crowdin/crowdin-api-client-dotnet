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
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using Xunit;

using Crowdin.Api.Client;
using Crowdin.Api.Api;
// uncomment below to import models
//using Crowdin.Api.Model;

namespace Crowdin.Api.Test.Api
{
    /// <summary>
    ///  Class for testing GlossariesApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class GlossariesApiTests : IDisposable
    {
        private GlossariesApi instance;

        public GlossariesApiTests()
        {
            instance = new GlossariesApi();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of GlossariesApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsType' GlossariesApi
            //Assert.IsType<GlossariesApi>(instance);
        }

        /// <summary>
        /// Test ApiGlossariesDelete
        /// </summary>
        [Fact]
        public void ApiGlossariesDeleteTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int glossaryId = null;
            //instance.ApiGlossariesDelete(glossaryId);
        }

        /// <summary>
        /// Test ApiGlossariesExportsDownloadDownload
        /// </summary>
        [Fact]
        public void ApiGlossariesExportsDownloadDownloadTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int glossaryId = null;
            //string exportId = null;
            //var response = instance.ApiGlossariesExportsDownloadDownload(glossaryId, exportId);
            //Assert.IsType<DownloadLinkResource>(response);
        }

        /// <summary>
        /// Test ApiGlossariesExportsGet
        /// </summary>
        [Fact]
        public void ApiGlossariesExportsGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int glossaryId = null;
            //string exportId = null;
            //var response = instance.ApiGlossariesExportsGet(glossaryId, exportId);
            //Assert.IsType<GlossaryExportResource>(response);
        }

        /// <summary>
        /// Test ApiGlossariesExportsPost
        /// </summary>
        [Fact]
        public void ApiGlossariesExportsPostTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int glossaryId = null;
            //GlossaryExportForm glossaryExportForm = null;
            //var response = instance.ApiGlossariesExportsPost(glossaryId, glossaryExportForm);
            //Assert.IsType<GlossaryExportResource>(response);
        }

        /// <summary>
        /// Test ApiGlossariesGet
        /// </summary>
        [Fact]
        public void ApiGlossariesGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int glossaryId = null;
            //var response = instance.ApiGlossariesGet(glossaryId);
            //Assert.IsType<CrowdinGlossaryResource>(response);
        }

        /// <summary>
        /// Test ApiGlossariesGetMany
        /// </summary>
        [Fact]
        public void ApiGlossariesGetManyTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int? limit = null;
            //int? offset = null;
            //int? userId = null;
            //var response = instance.ApiGlossariesGetMany(limit, offset, userId);
            //Assert.IsType<CrowdinGlossaryCollectionResource>(response);
        }

        /// <summary>
        /// Test ApiGlossariesImportsGet
        /// </summary>
        [Fact]
        public void ApiGlossariesImportsGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int glossaryId = null;
            //string importId = null;
            //var response = instance.ApiGlossariesImportsGet(glossaryId, importId);
            //Assert.IsType<GlossaryImportResource>(response);
        }

        /// <summary>
        /// Test ApiGlossariesImportsPost
        /// </summary>
        [Fact]
        public void ApiGlossariesImportsPostTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int glossaryId = null;
            //GlossaryImportForm glossaryImportForm = null;
            //var response = instance.ApiGlossariesImportsPost(glossaryId, glossaryImportForm);
            //Assert.IsType<GlossaryImportResource>(response);
        }

        /// <summary>
        /// Test ApiGlossariesPatch
        /// </summary>
        [Fact]
        public void ApiGlossariesPatchTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int glossaryId = null;
            //List<GlossaryOperation> glossaryOperation = null;
            //var response = instance.ApiGlossariesPatch(glossaryId, glossaryOperation);
            //Assert.IsType<CrowdinGlossaryResource>(response);
        }

        /// <summary>
        /// Test ApiGlossariesPost
        /// </summary>
        [Fact]
        public void ApiGlossariesPostTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //CrowdinGlossaryCreateForm crowdinGlossaryCreateForm = null;
            //var response = instance.ApiGlossariesPost(crowdinGlossaryCreateForm);
            //Assert.IsType<CrowdinGlossaryResource>(response);
        }

        /// <summary>
        /// Test ApiGlossariesTermsDelete
        /// </summary>
        [Fact]
        public void ApiGlossariesTermsDeleteTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int glossaryId = null;
            //int termId = null;
            //instance.ApiGlossariesTermsDelete(glossaryId, termId);
        }

        /// <summary>
        /// Test ApiGlossariesTermsDeleteMany
        /// </summary>
        [Fact]
        public void ApiGlossariesTermsDeleteManyTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int glossaryId = null;
            //string languageId = null;
            //int? translationOfTermId = null;
            //instance.ApiGlossariesTermsDeleteMany(glossaryId, languageId, translationOfTermId);
        }

        /// <summary>
        /// Test ApiGlossariesTermsGet
        /// </summary>
        [Fact]
        public void ApiGlossariesTermsGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int glossaryId = null;
            //int termId = null;
            //var response = instance.ApiGlossariesTermsGet(glossaryId, termId);
            //Assert.IsType<TermResource>(response);
        }

        /// <summary>
        /// Test ApiGlossariesTermsGetMany
        /// </summary>
        [Fact]
        public void ApiGlossariesTermsGetManyTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int glossaryId = null;
            //int? userId = null;
            //string languageId = null;
            //int? translationOfTermId = null;
            //int? limit = null;
            //int? offset = null;
            //var response = instance.ApiGlossariesTermsGetMany(glossaryId, userId, languageId, translationOfTermId, limit, offset);
            //Assert.IsType<TermCollectionResource>(response);
        }

        /// <summary>
        /// Test ApiGlossariesTermsPatch
        /// </summary>
        [Fact]
        public void ApiGlossariesTermsPatchTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int glossaryId = null;
            //int termId = null;
            //List<TermOperation> termOperation = null;
            //var response = instance.ApiGlossariesTermsPatch(glossaryId, termId, termOperation);
            //Assert.IsType<TermResource>(response);
        }

        /// <summary>
        /// Test ApiGlossariesTermsPost
        /// </summary>
        [Fact]
        public void ApiGlossariesTermsPostTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int glossaryId = null;
            //TermCreateForm termCreateForm = null;
            //var response = instance.ApiGlossariesTermsPost(glossaryId, termCreateForm);
            //Assert.IsType<TermResource>(response);
        }
    }
}
