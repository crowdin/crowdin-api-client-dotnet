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
    /// WebhookCreateForm
    /// </summary>
    [DataContract(Name = "WebhookCreateForm")]
    public partial class WebhookCreateForm : IEquatable<WebhookCreateForm>, IValidatableObject
    {
        /// <summary>
        /// Defines Events
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum EventsEnum
        {
            /// <summary>
            /// Enum FileTranslated for value: file.translated
            /// </summary>
            [EnumMember(Value = "file.translated")]
            FileTranslated = 1,

            /// <summary>
            /// Enum FileApproved for value: file.approved
            /// </summary>
            [EnumMember(Value = "file.approved")]
            FileApproved = 2,

            /// <summary>
            /// Enum ProjectTranslated for value: project.translated
            /// </summary>
            [EnumMember(Value = "project.translated")]
            ProjectTranslated = 3,

            /// <summary>
            /// Enum ProjectApproved for value: project.approved
            /// </summary>
            [EnumMember(Value = "project.approved")]
            ProjectApproved = 4,

            /// <summary>
            /// Enum TranslationUpdated for value: translation.updated
            /// </summary>
            [EnumMember(Value = "translation.updated")]
            TranslationUpdated = 5,

            /// <summary>
            /// Enum StringAdded for value: string.added
            /// </summary>
            [EnumMember(Value = "string.added")]
            StringAdded = 6,

            /// <summary>
            /// Enum StringUpdated for value: string.updated
            /// </summary>
            [EnumMember(Value = "string.updated")]
            StringUpdated = 7,

            /// <summary>
            /// Enum StringDeleted for value: string.deleted
            /// </summary>
            [EnumMember(Value = "string.deleted")]
            StringDeleted = 8,

            /// <summary>
            /// Enum SuggestionAdded for value: suggestion.added
            /// </summary>
            [EnumMember(Value = "suggestion.added")]
            SuggestionAdded = 9,

            /// <summary>
            /// Enum SuggestionUpdated for value: suggestion.updated
            /// </summary>
            [EnumMember(Value = "suggestion.updated")]
            SuggestionUpdated = 10,

            /// <summary>
            /// Enum SuggestionDeleted for value: suggestion.deleted
            /// </summary>
            [EnumMember(Value = "suggestion.deleted")]
            SuggestionDeleted = 11,

            /// <summary>
            /// Enum SuggestionApproved for value: suggestion.approved
            /// </summary>
            [EnumMember(Value = "suggestion.approved")]
            SuggestionApproved = 12,

            /// <summary>
            /// Enum SuggestionDisapproved for value: suggestion.disapproved
            /// </summary>
            [EnumMember(Value = "suggestion.disapproved")]
            SuggestionDisapproved = 13

        }



        /// <summary>
        /// You can configure webhooks for the following events:  *     &#39;file.translated&#39; — project file is fully translated  *     &#39;file.approved&#39; — project file is fully reviewed  *     &#39;project.translated&#39; — all strings in project are translated  *     &#39;project.approved&#39; — all strings in project are approved  *     &#39;translation.updated&#39; — final translation of string is updated (using Replace in suggestions feature)  *     &#39;string.added&#39; — source string is added  *     &#39;string.updated&#39; — source string is updated  *     &#39;string.deleted&#39; — source string is deleted  *     &#39;suggestion.added&#39; — one of source strings is translated  *     &#39;suggestion.updated&#39; — translation for source string is updated (using Replace in suggestions feature)  *     &#39;suggestion.deleted&#39; — one of translations is deleted  *     &#39;suggestion.approved&#39; — translation for string is approved  *     &#39;suggestion.disapproved&#39; — approval for previously added translation is removed
        /// </summary>
        /// <value>You can configure webhooks for the following events:  *     &#39;file.translated&#39; — project file is fully translated  *     &#39;file.approved&#39; — project file is fully reviewed  *     &#39;project.translated&#39; — all strings in project are translated  *     &#39;project.approved&#39; — all strings in project are approved  *     &#39;translation.updated&#39; — final translation of string is updated (using Replace in suggestions feature)  *     &#39;string.added&#39; — source string is added  *     &#39;string.updated&#39; — source string is updated  *     &#39;string.deleted&#39; — source string is deleted  *     &#39;suggestion.added&#39; — one of source strings is translated  *     &#39;suggestion.updated&#39; — translation for source string is updated (using Replace in suggestions feature)  *     &#39;suggestion.deleted&#39; — one of translations is deleted  *     &#39;suggestion.approved&#39; — translation for string is approved  *     &#39;suggestion.disapproved&#39; — approval for previously added translation is removed</value>
        [DataMember(Name = "events", IsRequired = true, EmitDefaultValue = false)]
        public List<EventsEnum> Events { get; set; }
        /// <summary>
        /// Webhook request type
        /// </summary>
        /// <value>Webhook request type</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum RequestTypeEnum
        {
            /// <summary>
            /// Enum POST for value: POST
            /// </summary>
            [EnumMember(Value = "POST")]
            POST = 1,

            /// <summary>
            /// Enum GET for value: GET
            /// </summary>
            [EnumMember(Value = "GET")]
            GET = 2

        }


        /// <summary>
        /// Webhook request type
        /// </summary>
        /// <value>Webhook request type</value>
        [DataMember(Name = "requestType", IsRequired = true, EmitDefaultValue = false)]
        public RequestTypeEnum RequestType { get; set; }
        /// <summary>
        /// Webhook content type
        /// </summary>
        /// <value>Webhook content type</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ContentTypeEnum
        {
            /// <summary>
            /// Enum MultipartFormData for value: multipart/form-data
            /// </summary>
            [EnumMember(Value = "multipart/form-data")]
            MultipartFormData = 1,

            /// <summary>
            /// Enum ApplicationJson for value: application/json
            /// </summary>
            [EnumMember(Value = "application/json")]
            ApplicationJson = 2,

            /// <summary>
            /// Enum ApplicationXWwwFormUrlencoded for value: application/x-www-form-urlencoded
            /// </summary>
            [EnumMember(Value = "application/x-www-form-urlencoded")]
            ApplicationXWwwFormUrlencoded = 3

        }


        /// <summary>
        /// Webhook content type
        /// </summary>
        /// <value>Webhook content type</value>
        [DataMember(Name = "contentType", EmitDefaultValue = false)]
        public ContentTypeEnum? ContentType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="WebhookCreateForm" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected WebhookCreateForm() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WebhookCreateForm" /> class.
        /// </summary>
        /// <param name="name">Webhook name (required).</param>
        /// <param name="url">Webhook URL (required).</param>
        /// <param name="events">You can configure webhooks for the following events:  *     &#39;file.translated&#39; — project file is fully translated  *     &#39;file.approved&#39; — project file is fully reviewed  *     &#39;project.translated&#39; — all strings in project are translated  *     &#39;project.approved&#39; — all strings in project are approved  *     &#39;translation.updated&#39; — final translation of string is updated (using Replace in suggestions feature)  *     &#39;string.added&#39; — source string is added  *     &#39;string.updated&#39; — source string is updated  *     &#39;string.deleted&#39; — source string is deleted  *     &#39;suggestion.added&#39; — one of source strings is translated  *     &#39;suggestion.updated&#39; — translation for source string is updated (using Replace in suggestions feature)  *     &#39;suggestion.deleted&#39; — one of translations is deleted  *     &#39;suggestion.approved&#39; — translation for string is approved  *     &#39;suggestion.disapproved&#39; — approval for previously added translation is removed (required).</param>
        /// <param name="requestType">Webhook request type (required).</param>
        /// <param name="isActive">Defines whether webhook is active (default to true).</param>
        /// <param name="batchingEnabled">Defines whether webhook batching is enabled (default to false).</param>
        /// <param name="contentType">Webhook content type (default to ContentTypeEnum.ApplicationJson).</param>
        /// <param name="headers">Webhook headers.</param>
        /// <param name="payload">Webhook payload.</param>
        public WebhookCreateForm(string name = default(string), string url = default(string), List<EventsEnum> events = default(List<EventsEnum>), RequestTypeEnum requestType = default(RequestTypeEnum), bool isActive = true, bool batchingEnabled = false, ContentTypeEnum? contentType = ContentTypeEnum.ApplicationJson, Object headers = default(Object), Object payload = default(Object))
        {
            // to ensure "name" is required (not null)
            if (name == null) {
                throw new ArgumentNullException("name is a required property for WebhookCreateForm and cannot be null");
            }
            this.Name = name;
            // to ensure "url" is required (not null)
            if (url == null) {
                throw new ArgumentNullException("url is a required property for WebhookCreateForm and cannot be null");
            }
            this.Url = url;
            // to ensure "events" is required (not null)
            if (events == null) {
                throw new ArgumentNullException("events is a required property for WebhookCreateForm and cannot be null");
            }
            this.Events = events;
            this.RequestType = requestType;
            this.IsActive = isActive;
            this.BatchingEnabled = batchingEnabled;
            this.ContentType = contentType;
            this.Headers = headers;
            this.Payload = payload;
        }

        /// <summary>
        /// Webhook name
        /// </summary>
        /// <value>Webhook name</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Webhook URL
        /// </summary>
        /// <value>Webhook URL</value>
        [DataMember(Name = "url", IsRequired = true, EmitDefaultValue = false)]
        public string Url { get; set; }

        /// <summary>
        /// Defines whether webhook is active
        /// </summary>
        /// <value>Defines whether webhook is active</value>
        [DataMember(Name = "isActive", EmitDefaultValue = true)]
        public bool IsActive { get; set; }

        /// <summary>
        /// Defines whether webhook batching is enabled
        /// </summary>
        /// <value>Defines whether webhook batching is enabled</value>
        [DataMember(Name = "batchingEnabled", EmitDefaultValue = true)]
        public bool BatchingEnabled { get; set; }

        /// <summary>
        /// Webhook headers
        /// </summary>
        /// <value>Webhook headers</value>
        [DataMember(Name = "headers", EmitDefaultValue = false)]
        public Object Headers { get; set; }

        /// <summary>
        /// Webhook payload
        /// </summary>
        /// <value>Webhook payload</value>
        [DataMember(Name = "payload", EmitDefaultValue = false)]
        public Object Payload { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class WebhookCreateForm {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  Events: ").Append(Events).Append("\n");
            sb.Append("  RequestType: ").Append(RequestType).Append("\n");
            sb.Append("  IsActive: ").Append(IsActive).Append("\n");
            sb.Append("  BatchingEnabled: ").Append(BatchingEnabled).Append("\n");
            sb.Append("  ContentType: ").Append(ContentType).Append("\n");
            sb.Append("  Headers: ").Append(Headers).Append("\n");
            sb.Append("  Payload: ").Append(Payload).Append("\n");
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
            return this.Equals(input as WebhookCreateForm);
        }

        /// <summary>
        /// Returns true if WebhookCreateForm instances are equal
        /// </summary>
        /// <param name="input">Instance of WebhookCreateForm to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WebhookCreateForm input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Url == input.Url ||
                    (this.Url != null &&
                    this.Url.Equals(input.Url))
                ) && 
                (
                    this.Events == input.Events ||
                    this.Events.SequenceEqual(input.Events)
                ) && 
                (
                    this.RequestType == input.RequestType ||
                    this.RequestType.Equals(input.RequestType)
                ) && 
                (
                    this.IsActive == input.IsActive ||
                    this.IsActive.Equals(input.IsActive)
                ) && 
                (
                    this.BatchingEnabled == input.BatchingEnabled ||
                    this.BatchingEnabled.Equals(input.BatchingEnabled)
                ) && 
                (
                    this.ContentType == input.ContentType ||
                    this.ContentType.Equals(input.ContentType)
                ) && 
                (
                    this.Headers == input.Headers ||
                    (this.Headers != null &&
                    this.Headers.Equals(input.Headers))
                ) && 
                (
                    this.Payload == input.Payload ||
                    (this.Payload != null &&
                    this.Payload.Equals(input.Payload))
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
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Url != null)
                    hashCode = hashCode * 59 + this.Url.GetHashCode();
                hashCode = hashCode * 59 + this.Events.GetHashCode();
                hashCode = hashCode * 59 + this.RequestType.GetHashCode();
                hashCode = hashCode * 59 + this.IsActive.GetHashCode();
                hashCode = hashCode * 59 + this.BatchingEnabled.GetHashCode();
                hashCode = hashCode * 59 + this.ContentType.GetHashCode();
                if (this.Headers != null)
                    hashCode = hashCode * 59 + this.Headers.GetHashCode();
                if (this.Payload != null)
                    hashCode = hashCode * 59 + this.Payload.GetHashCode();
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
