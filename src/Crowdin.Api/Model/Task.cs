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
    /// Task
    /// </summary>
    [DataContract(Name = "Task")]
    public partial class Task : IEquatable<Task>, IValidatableObject
    {
        /// <summary>
        /// Defines Status
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            /// <summary>
            /// Enum Todo for value: todo
            /// </summary>
            [EnumMember(Value = "todo")]
            Todo = 1,

            /// <summary>
            /// Enum InProgress for value: in_progress
            /// </summary>
            [EnumMember(Value = "in_progress")]
            InProgress = 2,

            /// <summary>
            /// Enum Done for value: done
            /// </summary>
            [EnumMember(Value = "done")]
            Done = 3,

            /// <summary>
            /// Enum Closed for value: closed
            /// </summary>
            [EnumMember(Value = "closed")]
            Closed = 4

        }


        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public StatusEnum? Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Task" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="projectId">projectId.</param>
        /// <param name="creatorId">creatorId.</param>
        /// <param name="type">type.</param>
        /// <param name="vendor">vendor.</param>
        /// <param name="status">status.</param>
        /// <param name="title">title.</param>
        /// <param name="assignees">assignees.</param>
        /// <param name="assignedTeams">assignedTeams.</param>
        /// <param name="fileIds">fileIds.</param>
        /// <param name="progress">progress.</param>
        /// <param name="translateProgress">translateProgress.</param>
        /// <param name="sourceLanguageId">sourceLanguageId.</param>
        /// <param name="targetLanguageId">targetLanguageId.</param>
        /// <param name="description">description.</param>
        /// <param name="hash">hash.</param>
        /// <param name="translationUrl">translationUrl.</param>
        /// <param name="wordsCount">wordsCount.</param>
        /// <param name="filesCount">filesCount.</param>
        /// <param name="commentsCount">commentsCount.</param>
        /// <param name="deadline">in UTC.</param>
        /// <param name="timeRange">timeRange.</param>
        /// <param name="workflowStepId">workflowStepId.</param>
        /// <param name="buyUrl">buyUrl.</param>
        /// <param name="createdAt">in UTC.</param>
        /// <param name="updatedAt">in UTC.</param>
        public Task(int id = default(int), int projectId = default(int), string creatorId = default(string), int type = default(int), string vendor = default(string), StatusEnum? status = default(StatusEnum?), string title = default(string), List<TaskAssignee> assignees = default(List<TaskAssignee>), List<TaskAssignedTeam> assignedTeams = default(List<TaskAssignedTeam>), List<int> fileIds = default(List<int>), TaskProgress progress = default(TaskProgress), TaskProgress translateProgress = default(TaskProgress), string sourceLanguageId = default(string), string targetLanguageId = default(string), string description = default(string), string hash = default(string), string translationUrl = default(string), int wordsCount = default(int), int filesCount = default(int), int commentsCount = default(int), DateTime deadline = default(DateTime), string timeRange = default(string), int workflowStepId = default(int), string buyUrl = default(string), DateTime createdAt = default(DateTime), DateTime updatedAt = default(DateTime))
        {
            this.Id = id;
            this.ProjectId = projectId;
            this.CreatorId = creatorId;
            this.Type = type;
            this.Vendor = vendor;
            this.Status = status;
            this.Title = title;
            this.Assignees = assignees;
            this.AssignedTeams = assignedTeams;
            this.FileIds = fileIds;
            this.Progress = progress;
            this.TranslateProgress = translateProgress;
            this.SourceLanguageId = sourceLanguageId;
            this.TargetLanguageId = targetLanguageId;
            this.Description = description;
            this.Hash = hash;
            this.TranslationUrl = translationUrl;
            this.WordsCount = wordsCount;
            this.FilesCount = filesCount;
            this.CommentsCount = commentsCount;
            this.Deadline = deadline;
            this.TimeRange = timeRange;
            this.WorkflowStepId = workflowStepId;
            this.BuyUrl = buyUrl;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets ProjectId
        /// </summary>
        [DataMember(Name = "projectId", EmitDefaultValue = false)]
        public int ProjectId { get; set; }

        /// <summary>
        /// Gets or Sets CreatorId
        /// </summary>
        [DataMember(Name = "creatorId", EmitDefaultValue = false)]
        public string CreatorId { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public int Type { get; set; }

        /// <summary>
        /// Gets or Sets Vendor
        /// </summary>
        [DataMember(Name = "vendor", EmitDefaultValue = false)]
        public string Vendor { get; set; }

        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [DataMember(Name = "title", EmitDefaultValue = false)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets Assignees
        /// </summary>
        [DataMember(Name = "assignees", EmitDefaultValue = false)]
        public List<TaskAssignee> Assignees { get; set; }

        /// <summary>
        /// Gets or Sets AssignedTeams
        /// </summary>
        [DataMember(Name = "assignedTeams", EmitDefaultValue = false)]
        public List<TaskAssignedTeam> AssignedTeams { get; set; }

        /// <summary>
        /// Gets or Sets FileIds
        /// </summary>
        [DataMember(Name = "fileIds", EmitDefaultValue = false)]
        public List<int> FileIds { get; set; }

        /// <summary>
        /// Gets or Sets Progress
        /// </summary>
        [DataMember(Name = "progress", EmitDefaultValue = false)]
        public TaskProgress Progress { get; set; }

        /// <summary>
        /// Gets or Sets TranslateProgress
        /// </summary>
        [DataMember(Name = "translateProgress", EmitDefaultValue = false)]
        public TaskProgress TranslateProgress { get; set; }

        /// <summary>
        /// Gets or Sets SourceLanguageId
        /// </summary>
        [DataMember(Name = "sourceLanguageId", EmitDefaultValue = false)]
        public string SourceLanguageId { get; set; }

        /// <summary>
        /// Gets or Sets TargetLanguageId
        /// </summary>
        [DataMember(Name = "targetLanguageId", EmitDefaultValue = false)]
        public string TargetLanguageId { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Hash
        /// </summary>
        [DataMember(Name = "hash", EmitDefaultValue = false)]
        public string Hash { get; set; }

        /// <summary>
        /// Gets or Sets TranslationUrl
        /// </summary>
        [DataMember(Name = "translationUrl", EmitDefaultValue = false)]
        public string TranslationUrl { get; set; }

        /// <summary>
        /// Gets or Sets WordsCount
        /// </summary>
        [DataMember(Name = "wordsCount", EmitDefaultValue = false)]
        public int WordsCount { get; set; }

        /// <summary>
        /// Gets or Sets FilesCount
        /// </summary>
        [DataMember(Name = "filesCount", EmitDefaultValue = false)]
        public int FilesCount { get; set; }

        /// <summary>
        /// Gets or Sets CommentsCount
        /// </summary>
        [DataMember(Name = "commentsCount", EmitDefaultValue = false)]
        public int CommentsCount { get; set; }

        /// <summary>
        /// in UTC
        /// </summary>
        /// <value>in UTC</value>
        [DataMember(Name = "deadline", EmitDefaultValue = false)]
        public DateTime Deadline { get; set; }

        /// <summary>
        /// Gets or Sets TimeRange
        /// </summary>
        [DataMember(Name = "timeRange", EmitDefaultValue = false)]
        public string TimeRange { get; set; }

        /// <summary>
        /// Gets or Sets WorkflowStepId
        /// </summary>
        [DataMember(Name = "workflowStepId", EmitDefaultValue = false)]
        public int WorkflowStepId { get; set; }

        /// <summary>
        /// Gets or Sets BuyUrl
        /// </summary>
        [DataMember(Name = "buyUrl", EmitDefaultValue = false)]
        public string BuyUrl { get; set; }

        /// <summary>
        /// in UTC
        /// </summary>
        /// <value>in UTC</value>
        [DataMember(Name = "createdAt", EmitDefaultValue = false)]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// in UTC
        /// </summary>
        /// <value>in UTC</value>
        [DataMember(Name = "updatedAt", EmitDefaultValue = false)]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Task {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  ProjectId: ").Append(ProjectId).Append("\n");
            sb.Append("  CreatorId: ").Append(CreatorId).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Vendor: ").Append(Vendor).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Assignees: ").Append(Assignees).Append("\n");
            sb.Append("  AssignedTeams: ").Append(AssignedTeams).Append("\n");
            sb.Append("  FileIds: ").Append(FileIds).Append("\n");
            sb.Append("  Progress: ").Append(Progress).Append("\n");
            sb.Append("  TranslateProgress: ").Append(TranslateProgress).Append("\n");
            sb.Append("  SourceLanguageId: ").Append(SourceLanguageId).Append("\n");
            sb.Append("  TargetLanguageId: ").Append(TargetLanguageId).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Hash: ").Append(Hash).Append("\n");
            sb.Append("  TranslationUrl: ").Append(TranslationUrl).Append("\n");
            sb.Append("  WordsCount: ").Append(WordsCount).Append("\n");
            sb.Append("  FilesCount: ").Append(FilesCount).Append("\n");
            sb.Append("  CommentsCount: ").Append(CommentsCount).Append("\n");
            sb.Append("  Deadline: ").Append(Deadline).Append("\n");
            sb.Append("  TimeRange: ").Append(TimeRange).Append("\n");
            sb.Append("  WorkflowStepId: ").Append(WorkflowStepId).Append("\n");
            sb.Append("  BuyUrl: ").Append(BuyUrl).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
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
            return this.Equals(input as Task);
        }

        /// <summary>
        /// Returns true if Task instances are equal
        /// </summary>
        /// <param name="input">Instance of Task to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Task input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    this.Id.Equals(input.Id)
                ) && 
                (
                    this.ProjectId == input.ProjectId ||
                    this.ProjectId.Equals(input.ProjectId)
                ) && 
                (
                    this.CreatorId == input.CreatorId ||
                    (this.CreatorId != null &&
                    this.CreatorId.Equals(input.CreatorId))
                ) && 
                (
                    this.Type == input.Type ||
                    this.Type.Equals(input.Type)
                ) && 
                (
                    this.Vendor == input.Vendor ||
                    (this.Vendor != null &&
                    this.Vendor.Equals(input.Vendor))
                ) && 
                (
                    this.Status == input.Status ||
                    this.Status.Equals(input.Status)
                ) && 
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
                ) && 
                (
                    this.Assignees == input.Assignees ||
                    this.Assignees != null &&
                    input.Assignees != null &&
                    this.Assignees.SequenceEqual(input.Assignees)
                ) && 
                (
                    this.AssignedTeams == input.AssignedTeams ||
                    this.AssignedTeams != null &&
                    input.AssignedTeams != null &&
                    this.AssignedTeams.SequenceEqual(input.AssignedTeams)
                ) && 
                (
                    this.FileIds == input.FileIds ||
                    this.FileIds != null &&
                    input.FileIds != null &&
                    this.FileIds.SequenceEqual(input.FileIds)
                ) && 
                (
                    this.Progress == input.Progress ||
                    (this.Progress != null &&
                    this.Progress.Equals(input.Progress))
                ) && 
                (
                    this.TranslateProgress == input.TranslateProgress ||
                    (this.TranslateProgress != null &&
                    this.TranslateProgress.Equals(input.TranslateProgress))
                ) && 
                (
                    this.SourceLanguageId == input.SourceLanguageId ||
                    (this.SourceLanguageId != null &&
                    this.SourceLanguageId.Equals(input.SourceLanguageId))
                ) && 
                (
                    this.TargetLanguageId == input.TargetLanguageId ||
                    (this.TargetLanguageId != null &&
                    this.TargetLanguageId.Equals(input.TargetLanguageId))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Hash == input.Hash ||
                    (this.Hash != null &&
                    this.Hash.Equals(input.Hash))
                ) && 
                (
                    this.TranslationUrl == input.TranslationUrl ||
                    (this.TranslationUrl != null &&
                    this.TranslationUrl.Equals(input.TranslationUrl))
                ) && 
                (
                    this.WordsCount == input.WordsCount ||
                    this.WordsCount.Equals(input.WordsCount)
                ) && 
                (
                    this.FilesCount == input.FilesCount ||
                    this.FilesCount.Equals(input.FilesCount)
                ) && 
                (
                    this.CommentsCount == input.CommentsCount ||
                    this.CommentsCount.Equals(input.CommentsCount)
                ) && 
                (
                    this.Deadline == input.Deadline ||
                    (this.Deadline != null &&
                    this.Deadline.Equals(input.Deadline))
                ) && 
                (
                    this.TimeRange == input.TimeRange ||
                    (this.TimeRange != null &&
                    this.TimeRange.Equals(input.TimeRange))
                ) && 
                (
                    this.WorkflowStepId == input.WorkflowStepId ||
                    this.WorkflowStepId.Equals(input.WorkflowStepId)
                ) && 
                (
                    this.BuyUrl == input.BuyUrl ||
                    (this.BuyUrl != null &&
                    this.BuyUrl.Equals(input.BuyUrl))
                ) && 
                (
                    this.CreatedAt == input.CreatedAt ||
                    (this.CreatedAt != null &&
                    this.CreatedAt.Equals(input.CreatedAt))
                ) && 
                (
                    this.UpdatedAt == input.UpdatedAt ||
                    (this.UpdatedAt != null &&
                    this.UpdatedAt.Equals(input.UpdatedAt))
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
                hashCode = hashCode * 59 + this.Id.GetHashCode();
                hashCode = hashCode * 59 + this.ProjectId.GetHashCode();
                if (this.CreatorId != null)
                    hashCode = hashCode * 59 + this.CreatorId.GetHashCode();
                hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Vendor != null)
                    hashCode = hashCode * 59 + this.Vendor.GetHashCode();
                hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
                if (this.Assignees != null)
                    hashCode = hashCode * 59 + this.Assignees.GetHashCode();
                if (this.AssignedTeams != null)
                    hashCode = hashCode * 59 + this.AssignedTeams.GetHashCode();
                if (this.FileIds != null)
                    hashCode = hashCode * 59 + this.FileIds.GetHashCode();
                if (this.Progress != null)
                    hashCode = hashCode * 59 + this.Progress.GetHashCode();
                if (this.TranslateProgress != null)
                    hashCode = hashCode * 59 + this.TranslateProgress.GetHashCode();
                if (this.SourceLanguageId != null)
                    hashCode = hashCode * 59 + this.SourceLanguageId.GetHashCode();
                if (this.TargetLanguageId != null)
                    hashCode = hashCode * 59 + this.TargetLanguageId.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.Hash != null)
                    hashCode = hashCode * 59 + this.Hash.GetHashCode();
                if (this.TranslationUrl != null)
                    hashCode = hashCode * 59 + this.TranslationUrl.GetHashCode();
                hashCode = hashCode * 59 + this.WordsCount.GetHashCode();
                hashCode = hashCode * 59 + this.FilesCount.GetHashCode();
                hashCode = hashCode * 59 + this.CommentsCount.GetHashCode();
                if (this.Deadline != null)
                    hashCode = hashCode * 59 + this.Deadline.GetHashCode();
                if (this.TimeRange != null)
                    hashCode = hashCode * 59 + this.TimeRange.GetHashCode();
                hashCode = hashCode * 59 + this.WorkflowStepId.GetHashCode();
                if (this.BuyUrl != null)
                    hashCode = hashCode * 59 + this.BuyUrl.GetHashCode();
                if (this.CreatedAt != null)
                    hashCode = hashCode * 59 + this.CreatedAt.GetHashCode();
                if (this.UpdatedAt != null)
                    hashCode = hashCode * 59 + this.UpdatedAt.GetHashCode();
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
