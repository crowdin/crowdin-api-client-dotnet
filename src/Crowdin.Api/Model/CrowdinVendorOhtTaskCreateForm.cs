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
    /// CrowdinVendorOhtTaskCreateForm
    /// </summary>
    [DataContract(Name = "CrowdinVendorOhtTaskCreateForm")]
    public partial class CrowdinVendorOhtTaskCreateForm : IEquatable<CrowdinVendorOhtTaskCreateForm>, IValidatableObject
    {
        /// <summary>
        /// Task type:  *     2 - translate by vendor  *     3 - proofread by vendor
        /// </summary>
        /// <value>Task type:  *     2 - translate by vendor  *     3 - proofread by vendor</value>
        public enum TypeEnum
        {
            /// <summary>
            /// Enum NUMBER_2 for value: 2
            /// </summary>
            NUMBER_2 = 2,

            /// <summary>
            /// Enum NUMBER_3 for value: 3
            /// </summary>
            NUMBER_3 = 3

        }


        /// <summary>
        /// Task type:  *     2 - translate by vendor  *     3 - proofread by vendor
        /// </summary>
        /// <value>Task type:  *     2 - translate by vendor  *     3 - proofread by vendor</value>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public TypeEnum Type { get; set; }
        /// <summary>
        /// Task status
        /// </summary>
        /// <value>Task status</value>
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
            InProgress = 2

        }


        /// <summary>
        /// Task status
        /// </summary>
        /// <value>Task status</value>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public StatusEnum? Status { get; set; }
        /// <summary>
        /// Task expertise:  *    \&quot;standard\&quot;  *    \&quot;mobile-applications\&quot;  *    \&quot;software-it\&quot;  *    \&quot;gaming-video-games\&quot;  *    \&quot;technical-engineering\&quot;  *    \&quot;marketing-consumer-media\&quot;  *    \&quot;business-finance\&quot;  *    \&quot;legal-certificate\&quot;  *    \&quot;medical\&quot;  *    \&quot;ad-words-banners\&quot;  *    \&quot;automotive-aerospace\&quot;  *    \&quot;scientific\&quot;  *    \&quot;scientific-academic\&quot;  *    \&quot;tourism\&quot;  *    \&quot;training-employee-handbooks\&quot;  *    \&quot;forex-crypto\&quot;
        /// </summary>
        /// <value>Task expertise:  *    \&quot;standard\&quot;  *    \&quot;mobile-applications\&quot;  *    \&quot;software-it\&quot;  *    \&quot;gaming-video-games\&quot;  *    \&quot;technical-engineering\&quot;  *    \&quot;marketing-consumer-media\&quot;  *    \&quot;business-finance\&quot;  *    \&quot;legal-certificate\&quot;  *    \&quot;medical\&quot;  *    \&quot;ad-words-banners\&quot;  *    \&quot;automotive-aerospace\&quot;  *    \&quot;scientific\&quot;  *    \&quot;scientific-academic\&quot;  *    \&quot;tourism\&quot;  *    \&quot;training-employee-handbooks\&quot;  *    \&quot;forex-crypto\&quot;</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ExpertiseEnum
        {
            /// <summary>
            /// Enum Standard for value: standard
            /// </summary>
            [EnumMember(Value = "standard")]
            Standard = 1,

            /// <summary>
            /// Enum MobileApplications for value: mobile-applications
            /// </summary>
            [EnumMember(Value = "mobile-applications")]
            MobileApplications = 2,

            /// <summary>
            /// Enum SoftwareIt for value: software-it
            /// </summary>
            [EnumMember(Value = "software-it")]
            SoftwareIt = 3,

            /// <summary>
            /// Enum GamingVideoGames for value: gaming-video-games
            /// </summary>
            [EnumMember(Value = "gaming-video-games")]
            GamingVideoGames = 4,

            /// <summary>
            /// Enum TechnicalEngineering for value: technical-engineering
            /// </summary>
            [EnumMember(Value = "technical-engineering")]
            TechnicalEngineering = 5,

            /// <summary>
            /// Enum MarketingConsumerMedia for value: marketing-consumer-media
            /// </summary>
            [EnumMember(Value = "marketing-consumer-media")]
            MarketingConsumerMedia = 6,

            /// <summary>
            /// Enum BusinessFinance for value: business-finance
            /// </summary>
            [EnumMember(Value = "business-finance")]
            BusinessFinance = 7,

            /// <summary>
            /// Enum LegalCertificate for value: legal-certificate
            /// </summary>
            [EnumMember(Value = "legal-certificate")]
            LegalCertificate = 8,

            /// <summary>
            /// Enum Medical for value: medical
            /// </summary>
            [EnumMember(Value = "medical")]
            Medical = 9,

            /// <summary>
            /// Enum AdWordsBanners for value: ad-words-banners
            /// </summary>
            [EnumMember(Value = "ad-words-banners")]
            AdWordsBanners = 10,

            /// <summary>
            /// Enum AutomotiveAerospace for value: automotive-aerospace
            /// </summary>
            [EnumMember(Value = "automotive-aerospace")]
            AutomotiveAerospace = 11,

            /// <summary>
            /// Enum Scientific for value: scientific
            /// </summary>
            [EnumMember(Value = "scientific")]
            Scientific = 12,

            /// <summary>
            /// Enum ScientificAcademic for value: scientific-academic
            /// </summary>
            [EnumMember(Value = "scientific-academic")]
            ScientificAcademic = 13,

            /// <summary>
            /// Enum Tourism for value: tourism
            /// </summary>
            [EnumMember(Value = "tourism")]
            Tourism = 14,

            /// <summary>
            /// Enum TrainingEmployeeHandbooks for value: training-employee-handbooks
            /// </summary>
            [EnumMember(Value = "training-employee-handbooks")]
            TrainingEmployeeHandbooks = 15,

            /// <summary>
            /// Enum ForexCrypto for value: forex-crypto
            /// </summary>
            [EnumMember(Value = "forex-crypto")]
            ForexCrypto = 16

        }


        /// <summary>
        /// Task expertise:  *    \&quot;standard\&quot;  *    \&quot;mobile-applications\&quot;  *    \&quot;software-it\&quot;  *    \&quot;gaming-video-games\&quot;  *    \&quot;technical-engineering\&quot;  *    \&quot;marketing-consumer-media\&quot;  *    \&quot;business-finance\&quot;  *    \&quot;legal-certificate\&quot;  *    \&quot;medical\&quot;  *    \&quot;ad-words-banners\&quot;  *    \&quot;automotive-aerospace\&quot;  *    \&quot;scientific\&quot;  *    \&quot;scientific-academic\&quot;  *    \&quot;tourism\&quot;  *    \&quot;training-employee-handbooks\&quot;  *    \&quot;forex-crypto\&quot;
        /// </summary>
        /// <value>Task expertise:  *    \&quot;standard\&quot;  *    \&quot;mobile-applications\&quot;  *    \&quot;software-it\&quot;  *    \&quot;gaming-video-games\&quot;  *    \&quot;technical-engineering\&quot;  *    \&quot;marketing-consumer-media\&quot;  *    \&quot;business-finance\&quot;  *    \&quot;legal-certificate\&quot;  *    \&quot;medical\&quot;  *    \&quot;ad-words-banners\&quot;  *    \&quot;automotive-aerospace\&quot;  *    \&quot;scientific\&quot;  *    \&quot;scientific-academic\&quot;  *    \&quot;tourism\&quot;  *    \&quot;training-employee-handbooks\&quot;  *    \&quot;forex-crypto\&quot;</value>
        [DataMember(Name = "expertise", EmitDefaultValue = false)]
        public ExpertiseEnum? Expertise { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CrowdinVendorOhtTaskCreateForm" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CrowdinVendorOhtTaskCreateForm() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CrowdinVendorOhtTaskCreateForm" /> class.
        /// </summary>
        /// <param name="title">Task title (required).</param>
        /// <param name="languageId">Task Language Identifier. Get via [Project Target Languages](#operation/api.projects.get) (required).</param>
        /// <param name="fileIds">Task file ids (required).</param>
        /// <param name="type">Task type:  *     2 - translate by vendor  *     3 - proofread by vendor (required).</param>
        /// <param name="vendor">Task vendor:  *    \&quot;oht\&quot; - OneHourTranslation (required).</param>
        /// <param name="status">Task status (default to StatusEnum.Todo).</param>
        /// <param name="description">Task description.</param>
        /// <param name="expertise">Task expertise:  *    \&quot;standard\&quot;  *    \&quot;mobile-applications\&quot;  *    \&quot;software-it\&quot;  *    \&quot;gaming-video-games\&quot;  *    \&quot;technical-engineering\&quot;  *    \&quot;marketing-consumer-media\&quot;  *    \&quot;business-finance\&quot;  *    \&quot;legal-certificate\&quot;  *    \&quot;medical\&quot;  *    \&quot;ad-words-banners\&quot;  *    \&quot;automotive-aerospace\&quot;  *    \&quot;scientific\&quot;  *    \&quot;scientific-academic\&quot;  *    \&quot;tourism\&quot;  *    \&quot;training-employee-handbooks\&quot;  *    \&quot;forex-crypto\&quot; (default to ExpertiseEnum.Standard).</param>
        /// <param name="labelIds">Label Identifiers. Get via [List Labels](#operation/api.projects.labels.getMany).</param>
        /// <param name="skipUntranslatedStrings">Defines whether to include only translated strings  __Note:__ &#x60;true&#x60; value can&#39;t be used with &#x60;includeUntranslatedStringsOnly&#x3D;true&#x60; in same request (default to false).</param>
        /// <param name="includeUntranslatedStringsOnly">Defines whether to include only untranslated strings  __Note:__ &#x60;true&#x60; value can&#39;t be used with &#x60;skipUntranslatedStrings&#x3D;true&#x60; in same request (default to false).</param>
        /// <param name="dateFrom">Defines start date for interval when strings were modified  Format: UTC, ISO 8601.</param>
        /// <param name="dateTo">Defines end date for interval when strings were modified  Format: UTC, ISO 8601.</param>
        public CrowdinVendorOhtTaskCreateForm(string title = default(string), string languageId = default(string), List<int> fileIds = default(List<int>), TypeEnum type = default(TypeEnum), string vendor = default(string), StatusEnum? status = StatusEnum.Todo, string description = default(string), ExpertiseEnum? expertise = ExpertiseEnum.Standard, List<int> labelIds = default(List<int>), bool skipUntranslatedStrings = false, bool includeUntranslatedStringsOnly = false, DateTime dateFrom = default(DateTime), DateTime dateTo = default(DateTime))
        {
            // to ensure "title" is required (not null)
            if (title == null) {
                throw new ArgumentNullException("title is a required property for CrowdinVendorOhtTaskCreateForm and cannot be null");
            }
            this.Title = title;
            // to ensure "languageId" is required (not null)
            if (languageId == null) {
                throw new ArgumentNullException("languageId is a required property for CrowdinVendorOhtTaskCreateForm and cannot be null");
            }
            this.LanguageId = languageId;
            // to ensure "fileIds" is required (not null)
            if (fileIds == null) {
                throw new ArgumentNullException("fileIds is a required property for CrowdinVendorOhtTaskCreateForm and cannot be null");
            }
            this.FileIds = fileIds;
            this.Type = type;
            // to ensure "vendor" is required (not null)
            if (vendor == null) {
                throw new ArgumentNullException("vendor is a required property for CrowdinVendorOhtTaskCreateForm and cannot be null");
            }
            this.Vendor = vendor;
            this.Status = status;
            this.Description = description;
            this.Expertise = expertise;
            this.LabelIds = labelIds;
            this.SkipUntranslatedStrings = skipUntranslatedStrings;
            this.IncludeUntranslatedStringsOnly = includeUntranslatedStringsOnly;
            this.DateFrom = dateFrom;
            this.DateTo = dateTo;
        }

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
        /// Task file ids
        /// </summary>
        /// <value>Task file ids</value>
        [DataMember(Name = "fileIds", IsRequired = true, EmitDefaultValue = false)]
        public List<int> FileIds { get; set; }

        /// <summary>
        /// Task vendor:  *    \&quot;oht\&quot; - OneHourTranslation
        /// </summary>
        /// <value>Task vendor:  *    \&quot;oht\&quot; - OneHourTranslation</value>
        [DataMember(Name = "vendor", IsRequired = true, EmitDefaultValue = false)]
        public string Vendor { get; set; }

        /// <summary>
        /// Task description
        /// </summary>
        /// <value>Task description</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Label Identifiers. Get via [List Labels](#operation/api.projects.labels.getMany)
        /// </summary>
        /// <value>Label Identifiers. Get via [List Labels](#operation/api.projects.labels.getMany)</value>
        [DataMember(Name = "labelIds", EmitDefaultValue = false)]
        public List<int> LabelIds { get; set; }

        /// <summary>
        /// Defines whether to include only translated strings  __Note:__ &#x60;true&#x60; value can&#39;t be used with &#x60;includeUntranslatedStringsOnly&#x3D;true&#x60; in same request
        /// </summary>
        /// <value>Defines whether to include only translated strings  __Note:__ &#x60;true&#x60; value can&#39;t be used with &#x60;includeUntranslatedStringsOnly&#x3D;true&#x60; in same request</value>
        [DataMember(Name = "skipUntranslatedStrings", EmitDefaultValue = true)]
        public bool SkipUntranslatedStrings { get; set; }

        /// <summary>
        /// Defines whether to include only untranslated strings  __Note:__ &#x60;true&#x60; value can&#39;t be used with &#x60;skipUntranslatedStrings&#x3D;true&#x60; in same request
        /// </summary>
        /// <value>Defines whether to include only untranslated strings  __Note:__ &#x60;true&#x60; value can&#39;t be used with &#x60;skipUntranslatedStrings&#x3D;true&#x60; in same request</value>
        [DataMember(Name = "includeUntranslatedStringsOnly", EmitDefaultValue = true)]
        public bool IncludeUntranslatedStringsOnly { get; set; }

        /// <summary>
        /// Defines start date for interval when strings were modified  Format: UTC, ISO 8601
        /// </summary>
        /// <value>Defines start date for interval when strings were modified  Format: UTC, ISO 8601</value>
        [DataMember(Name = "dateFrom", EmitDefaultValue = false)]
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// Defines end date for interval when strings were modified  Format: UTC, ISO 8601
        /// </summary>
        /// <value>Defines end date for interval when strings were modified  Format: UTC, ISO 8601</value>
        [DataMember(Name = "dateTo", EmitDefaultValue = false)]
        public DateTime DateTo { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CrowdinVendorOhtTaskCreateForm {\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  LanguageId: ").Append(LanguageId).Append("\n");
            sb.Append("  FileIds: ").Append(FileIds).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Vendor: ").Append(Vendor).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Expertise: ").Append(Expertise).Append("\n");
            sb.Append("  LabelIds: ").Append(LabelIds).Append("\n");
            sb.Append("  SkipUntranslatedStrings: ").Append(SkipUntranslatedStrings).Append("\n");
            sb.Append("  IncludeUntranslatedStringsOnly: ").Append(IncludeUntranslatedStringsOnly).Append("\n");
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
            return this.Equals(input as CrowdinVendorOhtTaskCreateForm);
        }

        /// <summary>
        /// Returns true if CrowdinVendorOhtTaskCreateForm instances are equal
        /// </summary>
        /// <param name="input">Instance of CrowdinVendorOhtTaskCreateForm to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CrowdinVendorOhtTaskCreateForm input)
        {
            if (input == null)
                return false;

            return 
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
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Expertise == input.Expertise ||
                    this.Expertise.Equals(input.Expertise)
                ) && 
                (
                    this.LabelIds == input.LabelIds ||
                    this.LabelIds != null &&
                    input.LabelIds != null &&
                    this.LabelIds.SequenceEqual(input.LabelIds)
                ) && 
                (
                    this.SkipUntranslatedStrings == input.SkipUntranslatedStrings ||
                    this.SkipUntranslatedStrings.Equals(input.SkipUntranslatedStrings)
                ) && 
                (
                    this.IncludeUntranslatedStringsOnly == input.IncludeUntranslatedStringsOnly ||
                    this.IncludeUntranslatedStringsOnly.Equals(input.IncludeUntranslatedStringsOnly)
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
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
                if (this.LanguageId != null)
                    hashCode = hashCode * 59 + this.LanguageId.GetHashCode();
                if (this.FileIds != null)
                    hashCode = hashCode * 59 + this.FileIds.GetHashCode();
                hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Vendor != null)
                    hashCode = hashCode * 59 + this.Vendor.GetHashCode();
                hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                hashCode = hashCode * 59 + this.Expertise.GetHashCode();
                if (this.LabelIds != null)
                    hashCode = hashCode * 59 + this.LabelIds.GetHashCode();
                hashCode = hashCode * 59 + this.SkipUntranslatedStrings.GetHashCode();
                hashCode = hashCode * 59 + this.IncludeUntranslatedStringsOnly.GetHashCode();
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
