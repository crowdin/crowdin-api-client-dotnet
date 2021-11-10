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
    /// FileCreateForm
    /// </summary>
    [DataContract(Name = "FileCreateForm")]
    public partial class FileCreateForm : IEquatable<FileCreateForm>, IValidatableObject
    {

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public ProjectFileType? Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="FileCreateForm" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected FileCreateForm() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="FileCreateForm" /> class.
        /// </summary>
        /// <param name="storageId">Storage Identifier. Get via [List Storages](#operation/api.storages.getMany) (required).</param>
        /// <param name="name">File name  __Note:__ Can&#39;t contain &#x60;\\ / : * ? \&quot; &lt; &gt; |&#x60; symbols.  &#x60;ZIP&#x60; files are not allowed. (required).</param>
        /// <param name="branchId">Branch Identifier — defines branch to which file will be added. Get via [List Branches](#operation/api.projects.branches.getMany)  __Note:__ Can&#39;t be used with &#x60;directoryId&#x60; in same request.</param>
        /// <param name="directoryId">Directory Identifier — defines directory to which file will be added. Get via [List Directories](#operation/api.projects.directories.getMany)  * __Note:__ Can&#39;t be used with &#x60;branchId&#x60; in same request.</param>
        /// <param name="title">Use to provide more details for translators. Title is available in UI only.</param>
        /// <param name="type">type.</param>
        /// <param name="importOptions">importOptions.</param>
        /// <param name="exportOptions">exportOptions.</param>
        /// <param name="excludedTargetLanguages">Set Target Languages the file should not be translated into. Do not use this option if the file should be available for all project languages..</param>
        /// <param name="attachLabelIds">Attach labels to strings. Get via [List Labels](#operation/api.projects.labels.getMany).</param>
        public FileCreateForm(int storageId = default(int), string name = default(string), int branchId = default(int), int directoryId = default(int), string title = default(string), ProjectFileType? type = default(ProjectFileType?), FileImportOptions importOptions = default(FileImportOptions), FileExportOptions exportOptions = default(FileExportOptions), List<string> excludedTargetLanguages = default(List<string>), List<int> attachLabelIds = default(List<int>))
        {
            this.StorageId = storageId;
            // to ensure "name" is required (not null)
            if (name == null) {
                throw new ArgumentNullException("name is a required property for FileCreateForm and cannot be null");
            }
            this.Name = name;
            this.BranchId = branchId;
            this.DirectoryId = directoryId;
            this.Title = title;
            this.Type = type;
            this.ImportOptions = importOptions;
            this.ExportOptions = exportOptions;
            this.ExcludedTargetLanguages = excludedTargetLanguages;
            this.AttachLabelIds = attachLabelIds;
        }

        /// <summary>
        /// Storage Identifier. Get via [List Storages](#operation/api.storages.getMany)
        /// </summary>
        /// <value>Storage Identifier. Get via [List Storages](#operation/api.storages.getMany)</value>
        [DataMember(Name = "storageId", IsRequired = true, EmitDefaultValue = false)]
        public int StorageId { get; set; }

        /// <summary>
        /// File name  __Note:__ Can&#39;t contain &#x60;\\ / : * ? \&quot; &lt; &gt; |&#x60; symbols.  &#x60;ZIP&#x60; files are not allowed.
        /// </summary>
        /// <value>File name  __Note:__ Can&#39;t contain &#x60;\\ / : * ? \&quot; &lt; &gt; |&#x60; symbols.  &#x60;ZIP&#x60; files are not allowed.</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Branch Identifier — defines branch to which file will be added. Get via [List Branches](#operation/api.projects.branches.getMany)  __Note:__ Can&#39;t be used with &#x60;directoryId&#x60; in same request
        /// </summary>
        /// <value>Branch Identifier — defines branch to which file will be added. Get via [List Branches](#operation/api.projects.branches.getMany)  __Note:__ Can&#39;t be used with &#x60;directoryId&#x60; in same request</value>
        [DataMember(Name = "branchId", EmitDefaultValue = false)]
        public int BranchId { get; set; }

        /// <summary>
        /// Directory Identifier — defines directory to which file will be added. Get via [List Directories](#operation/api.projects.directories.getMany)  * __Note:__ Can&#39;t be used with &#x60;branchId&#x60; in same request
        /// </summary>
        /// <value>Directory Identifier — defines directory to which file will be added. Get via [List Directories](#operation/api.projects.directories.getMany)  * __Note:__ Can&#39;t be used with &#x60;branchId&#x60; in same request</value>
        [DataMember(Name = "directoryId", EmitDefaultValue = false)]
        public int DirectoryId { get; set; }

        /// <summary>
        /// Use to provide more details for translators. Title is available in UI only
        /// </summary>
        /// <value>Use to provide more details for translators. Title is available in UI only</value>
        [DataMember(Name = "title", EmitDefaultValue = false)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets ImportOptions
        /// </summary>
        [DataMember(Name = "importOptions", EmitDefaultValue = false)]
        public FileImportOptions ImportOptions { get; set; }

        /// <summary>
        /// Gets or Sets ExportOptions
        /// </summary>
        [DataMember(Name = "exportOptions", EmitDefaultValue = false)]
        public FileExportOptions ExportOptions { get; set; }

        /// <summary>
        /// Set Target Languages the file should not be translated into. Do not use this option if the file should be available for all project languages.
        /// </summary>
        /// <value>Set Target Languages the file should not be translated into. Do not use this option if the file should be available for all project languages.</value>
        [DataMember(Name = "excludedTargetLanguages", EmitDefaultValue = true)]
        public List<string> ExcludedTargetLanguages { get; set; }

        /// <summary>
        /// Attach labels to strings. Get via [List Labels](#operation/api.projects.labels.getMany)
        /// </summary>
        /// <value>Attach labels to strings. Get via [List Labels](#operation/api.projects.labels.getMany)</value>
        [DataMember(Name = "attachLabelIds", EmitDefaultValue = false)]
        public List<int> AttachLabelIds { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FileCreateForm {\n");
            sb.Append("  StorageId: ").Append(StorageId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  BranchId: ").Append(BranchId).Append("\n");
            sb.Append("  DirectoryId: ").Append(DirectoryId).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  ImportOptions: ").Append(ImportOptions).Append("\n");
            sb.Append("  ExportOptions: ").Append(ExportOptions).Append("\n");
            sb.Append("  ExcludedTargetLanguages: ").Append(ExcludedTargetLanguages).Append("\n");
            sb.Append("  AttachLabelIds: ").Append(AttachLabelIds).Append("\n");
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
            return this.Equals(input as FileCreateForm);
        }

        /// <summary>
        /// Returns true if FileCreateForm instances are equal
        /// </summary>
        /// <param name="input">Instance of FileCreateForm to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FileCreateForm input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.StorageId == input.StorageId ||
                    this.StorageId.Equals(input.StorageId)
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.BranchId == input.BranchId ||
                    this.BranchId.Equals(input.BranchId)
                ) && 
                (
                    this.DirectoryId == input.DirectoryId ||
                    this.DirectoryId.Equals(input.DirectoryId)
                ) && 
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
                ) && 
                (
                    this.Type == input.Type ||
                    this.Type.Equals(input.Type)
                ) && 
                (
                    this.ImportOptions == input.ImportOptions ||
                    (this.ImportOptions != null &&
                    this.ImportOptions.Equals(input.ImportOptions))
                ) && 
                (
                    this.ExportOptions == input.ExportOptions ||
                    (this.ExportOptions != null &&
                    this.ExportOptions.Equals(input.ExportOptions))
                ) && 
                (
                    this.ExcludedTargetLanguages == input.ExcludedTargetLanguages ||
                    this.ExcludedTargetLanguages != null &&
                    input.ExcludedTargetLanguages != null &&
                    this.ExcludedTargetLanguages.SequenceEqual(input.ExcludedTargetLanguages)
                ) && 
                (
                    this.AttachLabelIds == input.AttachLabelIds ||
                    this.AttachLabelIds != null &&
                    input.AttachLabelIds != null &&
                    this.AttachLabelIds.SequenceEqual(input.AttachLabelIds)
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
                hashCode = hashCode * 59 + this.StorageId.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                hashCode = hashCode * 59 + this.BranchId.GetHashCode();
                hashCode = hashCode * 59 + this.DirectoryId.GetHashCode();
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
                hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.ImportOptions != null)
                    hashCode = hashCode * 59 + this.ImportOptions.GetHashCode();
                if (this.ExportOptions != null)
                    hashCode = hashCode * 59 + this.ExportOptions.GetHashCode();
                if (this.ExcludedTargetLanguages != null)
                    hashCode = hashCode * 59 + this.ExcludedTargetLanguages.GetHashCode();
                if (this.AttachLabelIds != null)
                    hashCode = hashCode * 59 + this.AttachLabelIds.GetHashCode();
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
