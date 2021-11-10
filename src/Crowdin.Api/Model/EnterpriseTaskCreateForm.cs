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
    /// EnterpriseTaskCreateForm
    /// </summary>
    [DataContract(Name = "EnterpriseTaskCreateForm")]
    public partial class EnterpriseTaskCreateForm : IEquatable<EnterpriseTaskCreateForm>, IValidatableObject
    {
        /// <summary>
        /// Task status
        /// </summary>
        /// <value>Task status</value>
        public enum StatusEnum
        {
            /// <summary>
            /// Enum NUMBER_null for value: null
            /// </summary>
            NUMBER_null = null,

            /// <summary>
            /// Enum NUMBER_null for value: null
            /// </summary>
            NUMBER_null = null

        }


        /// <summary>
        /// Task status
        /// </summary>
        /// <value>Task status</value>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public StatusEnum? Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="EnterpriseTaskCreateForm" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EnterpriseTaskCreateForm() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="EnterpriseTaskCreateForm" /> class.
        /// </summary>
        /// <param name="workflowStepId">Task workflow step id (required).</param>
        /// <param name="title">Task title (required).</param>
        /// <param name="languageId">Task Language Identifier. Get via [Project Target Languages](#operation/api.projects.get) (required).</param>
        /// <param name="fileIds">Task File Identifiers. Get via [List Files](#operation/api.projects.files.getMany) (required).</param>
        /// <param name="status">Task status.</param>
        /// <param name="description">Task description.</param>
        /// <param name="splitFiles">Split files for task (default to false).</param>
        /// <param name="skipAssignedStrings">Skip strings already included in other tasks (default to false).</param>
        /// <param name="assignees">assignees.</param>
        /// <param name="deadline">Task deadline in UTC, ISO 8601.</param>
        /// <param name="labelIds">Label Identifiers. Get via [List Labels](#operation/api.projects.labels.getMany).</param>
        /// <param name="dateFrom">Task date from in UTC, ISO 8601.</param>
        /// <param name="dateTo">Task date to in UTC, ISO 8601.</param>
        public EnterpriseTaskCreateForm(int workflowStepId = default(int), string title = default(string), string languageId = default(string), List<int> fileIds = default(List<int>), StatusEnum? status = default(StatusEnum?), string description = default(string), bool splitFiles = false, bool skipAssignedStrings = false, List<EnterpriseTaskAssignee> assignees = default(List<EnterpriseTaskAssignee>), DateTime deadline = default(DateTime), List<int> labelIds = default(List<int>), DateTime dateFrom = default(DateTime), DateTime dateTo = default(DateTime))
        {
            this.WorkflowStepId = workflowStepId;
            // to ensure "title" is required (not null)
            if (title == null) {
                throw new ArgumentNullException("title is a required property for EnterpriseTaskCreateForm and cannot be null");
            }
            this.Title = title;
            // to ensure "languageId" is required (not null)
            if (languageId == null) {
                throw new ArgumentNullException("languageId is a required property for EnterpriseTaskCreateForm and cannot be null");
            }
            this.LanguageId = languageId;
            // to ensure "fileIds" is required (not null)
            if (fileIds == null) {
                throw new ArgumentNullException("fileIds is a required property for EnterpriseTaskCreateForm and cannot be null");
            }
            this.FileIds = fileIds;
            this.Status = status;
            this.Description = description;
            this.SplitFiles = splitFiles;
            this.SkipAssignedStrings = skipAssignedStrings;
            this.Assignees = assignees;
            this.Deadline = deadline;
            this.LabelIds = labelIds;
            this.DateFrom = dateFrom;
            this.DateTo = dateTo;
        }

        /// <summary>
        /// Task workflow step id
        /// </summary>
        /// <value>Task workflow step id</value>
        [DataMember(Name = "workflowStepId", IsRequired = true, EmitDefaultValue = false)]
        public int WorkflowStepId { get; set; }

        /// <summary>
        /// Task title
        /// </summary>
        /// <value>Task title</value>
        [DataMember(Name = "title", IsRequired = true, EmitDefaultValue = false)]
        public string Title { get; set; }

        /// <summary>
        /// Task Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)
        /// </summary>
        /// <value>Task Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</value>
        [DataMember(Name = "languageId", IsRequired = true, EmitDefaultValue = false)]
        public string LanguageId { get; set; }

        /// <summary>
        /// Task File Identifiers. Get via [List Files](#operation/api.projects.files.getMany)
        /// </summary>
        /// <value>Task File Identifiers. Get via [List Files](#operation/api.projects.files.getMany)</value>
        [DataMember(Name = "fileIds", IsRequired = true, EmitDefaultValue = false)]
        public List<int> FileIds { get; set; }

        /// <summary>
        /// Task description
        /// </summary>
        /// <value>Task description</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Split files for task
        /// </summary>
        /// <value>Split files for task</value>
        [DataMember(Name = "splitFiles", EmitDefaultValue = true)]
        public bool SplitFiles { get; set; }

        /// <summary>
        /// Skip strings already included in other tasks
        /// </summary>
        /// <value>Skip strings already included in other tasks</value>
        [DataMember(Name = "skipAssignedStrings", EmitDefaultValue = true)]
        public bool SkipAssignedStrings { get; set; }

        /// <summary>
        /// Gets or Sets Assignees
        /// </summary>
        [DataMember(Name = "assignees", EmitDefaultValue = false)]
        public List<EnterpriseTaskAssignee> Assignees { get; set; }

        /// <summary>
        /// Task deadline in UTC, ISO 8601
        /// </summary>
        /// <value>Task deadline in UTC, ISO 8601</value>
        [DataMember(Name = "deadline", EmitDefaultValue = false)]
        public DateTime Deadline { get; set; }

        /// <summary>
        /// Label Identifiers. Get via [List Labels](#operation/api.projects.labels.getMany)
        /// </summary>
        /// <value>Label Identifiers. Get via [List Labels](#operation/api.projects.labels.getMany)</value>
        [DataMember(Name = "labelIds", EmitDefaultValue = false)]
        public List<int> LabelIds { get; set; }

        /// <summary>
        /// Task date from in UTC, ISO 8601
        /// </summary>
        /// <value>Task date from in UTC, ISO 8601</value>
        [DataMember(Name = "dateFrom", EmitDefaultValue = false)]
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// Task date to in UTC, ISO 8601
        /// </summary>
        /// <value>Task date to in UTC, ISO 8601</value>
        [DataMember(Name = "dateTo", EmitDefaultValue = false)]
        public DateTime DateTo { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EnterpriseTaskCreateForm {\n");
            sb.Append("  WorkflowStepId: ").Append(WorkflowStepId).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  LanguageId: ").Append(LanguageId).Append("\n");
            sb.Append("  FileIds: ").Append(FileIds).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  SplitFiles: ").Append(SplitFiles).Append("\n");
            sb.Append("  SkipAssignedStrings: ").Append(SkipAssignedStrings).Append("\n");
            sb.Append("  Assignees: ").Append(Assignees).Append("\n");
            sb.Append("  Deadline: ").Append(Deadline).Append("\n");
            sb.Append("  LabelIds: ").Append(LabelIds).Append("\n");
            sb.Append("  DateFrom: ").Append(DateFrom).Append("\n");
            sb.Append("  DateTo: ").Append(DateTo).Append("\n");
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
            return this.Equals(input as EnterpriseTaskCreateForm);
        }

        /// <summary>
        /// Returns true if EnterpriseTaskCreateForm instances are equal
        /// </summary>
        /// <param name="input">Instance of EnterpriseTaskCreateForm to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EnterpriseTaskCreateForm input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.WorkflowStepId == input.WorkflowStepId ||
                    this.WorkflowStepId.Equals(input.WorkflowStepId)
                ) && 
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
                ) && 
                (
                    this.LanguageId == input.LanguageId ||
                    (this.LanguageId != null &&
                    this.LanguageId.Equals(input.LanguageId))
                ) && 
                (
                    this.FileIds == input.FileIds ||
                    this.FileIds != null &&
                    input.FileIds != null &&
                    this.FileIds.SequenceEqual(input.FileIds)
                ) && 
                (
                    this.Status == input.Status ||
                    this.Status.Equals(input.Status)
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.SplitFiles == input.SplitFiles ||
                    this.SplitFiles.Equals(input.SplitFiles)
                ) && 
                (
                    this.SkipAssignedStrings == input.SkipAssignedStrings ||
                    this.SkipAssignedStrings.Equals(input.SkipAssignedStrings)
                ) && 
                (
                    this.Assignees == input.Assignees ||
                    this.Assignees != null &&
                    input.Assignees != null &&
                    this.Assignees.SequenceEqual(input.Assignees)
                ) && 
                (
                    this.Deadline == input.Deadline ||
                    (this.Deadline != null &&
                    this.Deadline.Equals(input.Deadline))
                ) && 
                (
                    this.LabelIds == input.LabelIds ||
                    this.LabelIds != null &&
                    input.LabelIds != null &&
                    this.LabelIds.SequenceEqual(input.LabelIds)
                ) && 
                (
                    this.DateFrom == input.DateFrom ||
                    (this.DateFrom != null &&
                    this.DateFrom.Equals(input.DateFrom))
                ) && 
                (
                    this.DateTo == input.DateTo ||
                    (this.DateTo != null &&
                    this.DateTo.Equals(input.DateTo))
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
                hashCode = hashCode * 59 + this.WorkflowStepId.GetHashCode();
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
                if (this.LanguageId != null)
                    hashCode = hashCode * 59 + this.LanguageId.GetHashCode();
                if (this.FileIds != null)
                    hashCode = hashCode * 59 + this.FileIds.GetHashCode();
                hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                hashCode = hashCode * 59 + this.SplitFiles.GetHashCode();
                hashCode = hashCode * 59 + this.SkipAssignedStrings.GetHashCode();
                if (this.Assignees != null)
                    hashCode = hashCode * 59 + this.Assignees.GetHashCode();
                if (this.Deadline != null)
                    hashCode = hashCode * 59 + this.Deadline.GetHashCode();
                if (this.LabelIds != null)
                    hashCode = hashCode * 59 + this.LabelIds.GetHashCode();
                if (this.DateFrom != null)
                    hashCode = hashCode * 59 + this.DateFrom.GetHashCode();
                if (this.DateTo != null)
                    hashCode = hashCode * 59 + this.DateTo.GetHashCode();
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
