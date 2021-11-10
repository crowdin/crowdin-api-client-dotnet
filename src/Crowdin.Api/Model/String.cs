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
    /// String
    /// </summary>
    [DataContract(Name = "String")]
    public partial class String : IEquatable<String>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="String" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="projectId">projectId.</param>
        /// <param name="fileId">fileId.</param>
        /// <param name="branchId">branchId.</param>
        /// <param name="directoryId">directoryId.</param>
        /// <param name="identifier">identifier.</param>
        /// <param name="text">text.</param>
        /// <param name="type">type.</param>
        /// <param name="context">context.</param>
        /// <param name="maxLength">maxLength.</param>
        /// <param name="isHidden">isHidden.</param>
        /// <param name="revision">revision.</param>
        /// <param name="hasPlurals">Use fields &#x60;type&#x60; and &#x60;text&#x60; instead.</param>
        /// <param name="isIcu">Use field &#x60;type&#x60; instead.</param>
        /// <param name="labelIds">labelIds.</param>
        /// <param name="createdAt">createdAt.</param>
        /// <param name="updatedAt">updatedAt.</param>
        public String(int id = default(int), int projectId = default(int), int fileId = default(int), int? branchId = default(int?), int? directoryId = default(int?), string identifier = default(string), string text = default(string), string type = default(string), string context = default(string), int maxLength = default(int), bool isHidden = default(bool), int revision = default(int), bool hasPlurals = default(bool), bool isIcu = default(bool), List<int> labelIds = default(List<int>), DateTime createdAt = default(DateTime), DateTime updatedAt = default(DateTime))
        {
            this.Id = id;
            this.ProjectId = projectId;
            this.FileId = fileId;
            this.BranchId = branchId;
            this.DirectoryId = directoryId;
            this.Identifier = identifier;
            this.Text = text;
            this.Type = type;
            this.Context = context;
            this.MaxLength = maxLength;
            this.IsHidden = isHidden;
            this.Revision = revision;
            this.HasPlurals = hasPlurals;
            this.IsIcu = isIcu;
            this.LabelIds = labelIds;
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
        /// Gets or Sets FileId
        /// </summary>
        [DataMember(Name = "fileId", EmitDefaultValue = false)]
        public int FileId { get; set; }

        /// <summary>
        /// Gets or Sets BranchId
        /// </summary>
        [DataMember(Name = "branchId", EmitDefaultValue = true)]
        public int? BranchId { get; set; }

        /// <summary>
        /// Gets or Sets DirectoryId
        /// </summary>
        [DataMember(Name = "directoryId", EmitDefaultValue = true)]
        public int? DirectoryId { get; set; }

        /// <summary>
        /// Gets or Sets Identifier
        /// </summary>
        [DataMember(Name = "identifier", EmitDefaultValue = false)]
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or Sets Text
        /// </summary>
        [DataMember(Name = "text", EmitDefaultValue = false)]
        public string Text { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or Sets Context
        /// </summary>
        [DataMember(Name = "context", EmitDefaultValue = false)]
        public string Context { get; set; }

        /// <summary>
        /// Gets or Sets MaxLength
        /// </summary>
        [DataMember(Name = "maxLength", EmitDefaultValue = false)]
        public int MaxLength { get; set; }

        /// <summary>
        /// Gets or Sets IsHidden
        /// </summary>
        [DataMember(Name = "isHidden", EmitDefaultValue = true)]
        public bool IsHidden { get; set; }

        /// <summary>
        /// Gets or Sets Revision
        /// </summary>
        [DataMember(Name = "revision", EmitDefaultValue = false)]
        public int Revision { get; set; }

        /// <summary>
        /// Use fields &#x60;type&#x60; and &#x60;text&#x60; instead
        /// </summary>
        /// <value>Use fields &#x60;type&#x60; and &#x60;text&#x60; instead</value>
        [DataMember(Name = "hasPlurals", EmitDefaultValue = true)]
        [Obsolete]
        public bool HasPlurals { get; set; }

        /// <summary>
        /// Use field &#x60;type&#x60; instead
        /// </summary>
        /// <value>Use field &#x60;type&#x60; instead</value>
        [DataMember(Name = "isIcu", EmitDefaultValue = true)]
        [Obsolete]
        public bool IsIcu { get; set; }

        /// <summary>
        /// Gets or Sets LabelIds
        /// </summary>
        [DataMember(Name = "labelIds", EmitDefaultValue = false)]
        public List<int> LabelIds { get; set; }

        /// <summary>
        /// Gets or Sets CreatedAt
        /// </summary>
        [DataMember(Name = "createdAt", EmitDefaultValue = false)]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or Sets UpdatedAt
        /// </summary>
        [DataMember(Name = "updatedAt", EmitDefaultValue = false)]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class String {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  ProjectId: ").Append(ProjectId).Append("\n");
            sb.Append("  FileId: ").Append(FileId).Append("\n");
            sb.Append("  BranchId: ").Append(BranchId).Append("\n");
            sb.Append("  DirectoryId: ").Append(DirectoryId).Append("\n");
            sb.Append("  Identifier: ").Append(Identifier).Append("\n");
            sb.Append("  Text: ").Append(Text).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Context: ").Append(Context).Append("\n");
            sb.Append("  MaxLength: ").Append(MaxLength).Append("\n");
            sb.Append("  IsHidden: ").Append(IsHidden).Append("\n");
            sb.Append("  Revision: ").Append(Revision).Append("\n");
            sb.Append("  HasPlurals: ").Append(HasPlurals).Append("\n");
            sb.Append("  IsIcu: ").Append(IsIcu).Append("\n");
            sb.Append("  LabelIds: ").Append(LabelIds).Append("\n");
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
            return this.Equals(input as String);
        }

        /// <summary>
        /// Returns true if String instances are equal
        /// </summary>
        /// <param name="input">Instance of String to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(String input)
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
                    this.FileId == input.FileId ||
                    this.FileId.Equals(input.FileId)
                ) && 
                (
                    this.BranchId == input.BranchId ||
                    (this.BranchId != null &&
                    this.BranchId.Equals(input.BranchId))
                ) && 
                (
                    this.DirectoryId == input.DirectoryId ||
                    (this.DirectoryId != null &&
                    this.DirectoryId.Equals(input.DirectoryId))
                ) && 
                (
                    this.Identifier == input.Identifier ||
                    (this.Identifier != null &&
                    this.Identifier.Equals(input.Identifier))
                ) && 
                (
                    this.Text == input.Text ||
                    (this.Text != null &&
                    this.Text.Equals(input.Text))
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.Context == input.Context ||
                    (this.Context != null &&
                    this.Context.Equals(input.Context))
                ) && 
                (
                    this.MaxLength == input.MaxLength ||
                    this.MaxLength.Equals(input.MaxLength)
                ) && 
                (
                    this.IsHidden == input.IsHidden ||
                    this.IsHidden.Equals(input.IsHidden)
                ) && 
                (
                    this.Revision == input.Revision ||
                    this.Revision.Equals(input.Revision)
                ) && 
                (
                    this.HasPlurals == input.HasPlurals ||
                    this.HasPlurals.Equals(input.HasPlurals)
                ) && 
                (
                    this.IsIcu == input.IsIcu ||
                    this.IsIcu.Equals(input.IsIcu)
                ) && 
                (
                    this.LabelIds == input.LabelIds ||
                    this.LabelIds != null &&
                    input.LabelIds != null &&
                    this.LabelIds.SequenceEqual(input.LabelIds)
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
                hashCode = hashCode * 59 + this.FileId.GetHashCode();
                if (this.BranchId != null)
                    hashCode = hashCode * 59 + this.BranchId.GetHashCode();
                if (this.DirectoryId != null)
                    hashCode = hashCode * 59 + this.DirectoryId.GetHashCode();
                if (this.Identifier != null)
                    hashCode = hashCode * 59 + this.Identifier.GetHashCode();
                if (this.Text != null)
                    hashCode = hashCode * 59 + this.Text.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Context != null)
                    hashCode = hashCode * 59 + this.Context.GetHashCode();
                hashCode = hashCode * 59 + this.MaxLength.GetHashCode();
                hashCode = hashCode * 59 + this.IsHidden.GetHashCode();
                hashCode = hashCode * 59 + this.Revision.GetHashCode();
                hashCode = hashCode * 59 + this.HasPlurals.GetHashCode();
                hashCode = hashCode * 59 + this.IsIcu.GetHashCode();
                if (this.LabelIds != null)
                    hashCode = hashCode * 59 + this.LabelIds.GetHashCode();
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
