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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = Crowdin.Api.Client.OpenAPIDateConverter;

namespace Crowdin.Api.Model
{
    /// <summary>
    /// EnterpriseTranslationExportForm
    /// </summary>
    [DataContract(Name = "EnterpriseTranslationExportForm")]
    public partial class EnterpriseTranslationExportForm : IEquatable<EnterpriseTranslationExportForm>, IValidatableObject
    {
        /// <summary>
        /// Defines export file format  __Note:__ the &#x60;format&#x60; parameter is required in all cases except when you&#39;d like to export translations for a single file in its original format
        /// </summary>
        /// <value>Defines export file format  __Note:__ the &#x60;format&#x60; parameter is required in all cases except when you&#39;d like to export translations for a single file in its original format</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum FormatEnum
        {
            /// <summary>
            /// Enum Xliff for value: xliff
            /// </summary>
            [EnumMember(Value = "xliff")]
            Xliff = 1,

            /// <summary>
            /// Enum Android for value: android
            /// </summary>
            [EnumMember(Value = "android")]
            Android = 2,

            /// <summary>
            /// Enum Macosx for value: macosx
            /// </summary>
            [EnumMember(Value = "macosx")]
            Macosx = 3

        }


        /// <summary>
        /// Defines export file format  __Note:__ the &#x60;format&#x60; parameter is required in all cases except when you&#39;d like to export translations for a single file in its original format
        /// </summary>
        /// <value>Defines export file format  __Note:__ the &#x60;format&#x60; parameter is required in all cases except when you&#39;d like to export translations for a single file in its original format</value>
        [DataMember(Name = "format", EmitDefaultValue = false)]
        public FormatEnum? Format { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="EnterpriseTranslationExportForm" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EnterpriseTranslationExportForm() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="EnterpriseTranslationExportForm" /> class.
        /// </summary>
        /// <param name="targetLanguageId">Specify target language for export. Get via [List Supported Languages](#operation/api.languages.getMany) (required).</param>
        /// <param name="format">Defines export file format  __Note:__ the &#x60;format&#x60; parameter is required in all cases except when you&#39;d like to export translations for a single file in its original format.</param>
        /// <param name="labelIds">Label Identifiers. Get via [List Labels](#operation/api.projects.labels.getMany).</param>
        /// <param name="branchIds">Branch Identifiers. Get via [List Branches](#operation/api.projects.branches.getMany)  __Note:__ Can&#39;t be used with &#x60;directoryIds&#x60; or &#x60;fileIds&#x60; in same request.</param>
        /// <param name="directoryIds">Directory Identifiers. Get via [List Directories](#operation/api.projects.directories.getMany)  __Note:__ Can&#39;t be used with &#x60;branchIds&#x60; or &#x60;fileIds&#x60; in same request.</param>
        /// <param name="fileIds">File Identifiers. Get via [List Files](#operation/api.projects.files.getMany)  __Note:__ Can&#39;t be used with &#x60;branchIds&#x60; or &#x60;directoryIds&#x60; in same request.</param>
        /// <param name="skipUntranslatedStrings">Defines whether to export only translated strings  __Note:__ Can&#39;t be used with &#x60;skipUntranslatedFiles&#x60; in same request (default to false).</param>
        /// <param name="skipUntranslatedFiles">Defines whether to export only translated file  __Note:__ Can&#39;t be used with &#x60;skipUntranslatedStrings&#x60; in same request (default to false).</param>
        /// <param name="exportWithMinApprovalsCount">Defines whether to export only approved strings.</param>
        public EnterpriseTranslationExportForm(string targetLanguageId = default(string), FormatEnum? format = default(FormatEnum?), List<int> labelIds = default(List<int>), List<int> branchIds = default(List<int>), List<int> directoryIds = default(List<int>), List<int> fileIds = default(List<int>), bool skipUntranslatedStrings = false, bool skipUntranslatedFiles = false, int exportWithMinApprovalsCount = default(int))
        {
            // to ensure "targetLanguageId" is required (not null)
            if (targetLanguageId == null) {
                throw new ArgumentNullException("targetLanguageId is a required property for EnterpriseTranslationExportForm and cannot be null");
            }
            this.TargetLanguageId = targetLanguageId;
            this.Format = format;
            this.LabelIds = labelIds;
            this.BranchIds = branchIds;
            this.DirectoryIds = directoryIds;
            this.FileIds = fileIds;
            this.SkipUntranslatedStrings = skipUntranslatedStrings;
            this.SkipUntranslatedFiles = skipUntranslatedFiles;
            this.ExportWithMinApprovalsCount = exportWithMinApprovalsCount;
        }

        /// <summary>
        /// Specify target language for export. Get via [List Supported Languages](#operation/api.languages.getMany)
        /// </summary>
        /// <value>Specify target language for export. Get via [List Supported Languages](#operation/api.languages.getMany)</value>
        [DataMember(Name = "targetLanguageId", IsRequired = true, EmitDefaultValue = false)]
        public string TargetLanguageId { get; set; }

        /// <summary>
        /// Label Identifiers. Get via [List Labels](#operation/api.projects.labels.getMany)
        /// </summary>
        /// <value>Label Identifiers. Get via [List Labels](#operation/api.projects.labels.getMany)</value>
        [DataMember(Name = "labelIds", EmitDefaultValue = false)]
        public List<int> LabelIds { get; set; }

        /// <summary>
        /// Branch Identifiers. Get via [List Branches](#operation/api.projects.branches.getMany)  __Note:__ Can&#39;t be used with &#x60;directoryIds&#x60; or &#x60;fileIds&#x60; in same request
        /// </summary>
        /// <value>Branch Identifiers. Get via [List Branches](#operation/api.projects.branches.getMany)  __Note:__ Can&#39;t be used with &#x60;directoryIds&#x60; or &#x60;fileIds&#x60; in same request</value>
        [DataMember(Name = "branchIds", EmitDefaultValue = false)]
        public List<int> BranchIds { get; set; }

        /// <summary>
        /// Directory Identifiers. Get via [List Directories](#operation/api.projects.directories.getMany)  __Note:__ Can&#39;t be used with &#x60;branchIds&#x60; or &#x60;fileIds&#x60; in same request
        /// </summary>
        /// <value>Directory Identifiers. Get via [List Directories](#operation/api.projects.directories.getMany)  __Note:__ Can&#39;t be used with &#x60;branchIds&#x60; or &#x60;fileIds&#x60; in same request</value>
        [DataMember(Name = "directoryIds", EmitDefaultValue = false)]
        public List<int> DirectoryIds { get; set; }

        /// <summary>
        /// File Identifiers. Get via [List Files](#operation/api.projects.files.getMany)  __Note:__ Can&#39;t be used with &#x60;branchIds&#x60; or &#x60;directoryIds&#x60; in same request
        /// </summary>
        /// <value>File Identifiers. Get via [List Files](#operation/api.projects.files.getMany)  __Note:__ Can&#39;t be used with &#x60;branchIds&#x60; or &#x60;directoryIds&#x60; in same request</value>
        [DataMember(Name = "fileIds", EmitDefaultValue = false)]
        public List<int> FileIds { get; set; }

        /// <summary>
        /// Defines whether to export only translated strings  __Note:__ Can&#39;t be used with &#x60;skipUntranslatedFiles&#x60; in same request
        /// </summary>
        /// <value>Defines whether to export only translated strings  __Note:__ Can&#39;t be used with &#x60;skipUntranslatedFiles&#x60; in same request</value>
        [DataMember(Name = "skipUntranslatedStrings", EmitDefaultValue = true)]
        public bool SkipUntranslatedStrings { get; set; }

        /// <summary>
        /// Defines whether to export only translated file  __Note:__ Can&#39;t be used with &#x60;skipUntranslatedStrings&#x60; in same request
        /// </summary>
        /// <value>Defines whether to export only translated file  __Note:__ Can&#39;t be used with &#x60;skipUntranslatedStrings&#x60; in same request</value>
        [DataMember(Name = "skipUntranslatedFiles", EmitDefaultValue = true)]
        public bool SkipUntranslatedFiles { get; set; }

        /// <summary>
        /// Defines whether to export only approved strings
        /// </summary>
        /// <value>Defines whether to export only approved strings</value>
        [DataMember(Name = "exportWithMinApprovalsCount", EmitDefaultValue = false)]
        public int ExportWithMinApprovalsCount { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EnterpriseTranslationExportForm {\n");
            sb.Append("  TargetLanguageId: ").Append(TargetLanguageId).Append("\n");
            sb.Append("  Format: ").Append(Format).Append("\n");
            sb.Append("  LabelIds: ").Append(LabelIds).Append("\n");
            sb.Append("  BranchIds: ").Append(BranchIds).Append("\n");
            sb.Append("  DirectoryIds: ").Append(DirectoryIds).Append("\n");
            sb.Append("  FileIds: ").Append(FileIds).Append("\n");
            sb.Append("  SkipUntranslatedStrings: ").Append(SkipUntranslatedStrings).Append("\n");
            sb.Append("  SkipUntranslatedFiles: ").Append(SkipUntranslatedFiles).Append("\n");
            sb.Append("  ExportWithMinApprovalsCount: ").Append(ExportWithMinApprovalsCount).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as EnterpriseTranslationExportForm);
        }

        /// <summary>
        /// Returns true if EnterpriseTranslationExportForm instances are equal
        /// </summary>
        /// <param name="input">Instance of EnterpriseTranslationExportForm to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EnterpriseTranslationExportForm input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.TargetLanguageId == input.TargetLanguageId ||
                    (this.TargetLanguageId != null &&
                    this.TargetLanguageId.Equals(input.TargetLanguageId))
                ) && 
                (
                    this.Format == input.Format ||
                    this.Format.Equals(input.Format)
                ) && 
                (
                    this.LabelIds == input.LabelIds ||
                    this.LabelIds != null &&
                    input.LabelIds != null &&
                    this.LabelIds.SequenceEqual(input.LabelIds)
                ) && 
                (
                    this.BranchIds == input.BranchIds ||
                    this.BranchIds != null &&
                    input.BranchIds != null &&
                    this.BranchIds.SequenceEqual(input.BranchIds)
                ) && 
                (
                    this.DirectoryIds == input.DirectoryIds ||
                    this.DirectoryIds != null &&
                    input.DirectoryIds != null &&
                    this.DirectoryIds.SequenceEqual(input.DirectoryIds)
                ) && 
                (
                    this.FileIds == input.FileIds ||
                    this.FileIds != null &&
                    input.FileIds != null &&
                    this.FileIds.SequenceEqual(input.FileIds)
                ) && 
                (
                    this.SkipUntranslatedStrings == input.SkipUntranslatedStrings ||
                    this.SkipUntranslatedStrings.Equals(input.SkipUntranslatedStrings)
                ) && 
                (
                    this.SkipUntranslatedFiles == input.SkipUntranslatedFiles ||
                    this.SkipUntranslatedFiles.Equals(input.SkipUntranslatedFiles)
                ) && 
                (
                    this.ExportWithMinApprovalsCount == input.ExportWithMinApprovalsCount ||
                    this.ExportWithMinApprovalsCount.Equals(input.ExportWithMinApprovalsCount)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.TargetLanguageId != null)
                    hashCode = hashCode * 59 + this.TargetLanguageId.GetHashCode();
                hashCode = hashCode * 59 + this.Format.GetHashCode();
                if (this.LabelIds != null)
                    hashCode = hashCode * 59 + this.LabelIds.GetHashCode();
                if (this.BranchIds != null)
                    hashCode = hashCode * 59 + this.BranchIds.GetHashCode();
                if (this.DirectoryIds != null)
                    hashCode = hashCode * 59 + this.DirectoryIds.GetHashCode();
                if (this.FileIds != null)
                    hashCode = hashCode * 59 + this.FileIds.GetHashCode();
                hashCode = hashCode * 59 + this.SkipUntranslatedStrings.GetHashCode();
                hashCode = hashCode * 59 + this.SkipUntranslatedFiles.GetHashCode();
                hashCode = hashCode * 59 + this.ExportWithMinApprovalsCount.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
