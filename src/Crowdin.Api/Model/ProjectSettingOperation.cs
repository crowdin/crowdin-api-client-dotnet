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
using JsonSubTypes;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = Crowdin.Api.Client.OpenAPIDateConverter;

namespace Crowdin.Api.Model
{
    /// <summary>
    /// A JSON Patch operation as defined by [RFC 6902](https://tools.ietf.org/html/rfc6902#section-4)
    /// </summary>
    [DataContract(Name = "ProjectSettingOperation")]
    [JsonConverter(typeof(JsonSubtypes), "Op")]
    [JsonSubtypes.KnownSubType(typeof(ProjectSettingOperationAdd), "ProjectSettingOperationAdd")]
    [JsonSubtypes.KnownSubType(typeof(ProjectSettingOperationRemove), "ProjectSettingOperationRemove")]
    [JsonSubtypes.KnownSubType(typeof(ProjectSettingOperationReplace), "ProjectSettingOperationReplace")]
    [JsonSubtypes.KnownSubType(typeof(ProjectSettingOperationTest), "ProjectSettingOperationTest")]
    [JsonSubtypes.KnownSubType(typeof(ProjectSettingOperationAdd), "add")]
    [JsonSubtypes.KnownSubType(typeof(ProjectSettingOperationRemove), "remove")]
    [JsonSubtypes.KnownSubType(typeof(ProjectSettingOperationReplace), "replace")]
    [JsonSubtypes.KnownSubType(typeof(ProjectSettingOperationTest), "test")]
    public partial class ProjectSettingOperation : IEquatable<ProjectSettingOperation>, IValidatableObject
    {
        /// <summary>
        /// Patch operation to perform
        /// </summary>
        /// <value>Patch operation to perform</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum OpEnum
        {
            /// <summary>
            /// Enum Add for value: add
            /// </summary>
            [EnumMember(Value = "add")]
            Add = 1,

            /// <summary>
            /// Enum Replace for value: replace
            /// </summary>
            [EnumMember(Value = "replace")]
            Replace = 2,

            /// <summary>
            /// Enum Remove for value: remove
            /// </summary>
            [EnumMember(Value = "remove")]
            Remove = 3,

            /// <summary>
            /// Enum Test for value: test
            /// </summary>
            [EnumMember(Value = "test")]
            Test = 4

        }


        /// <summary>
        /// Patch operation to perform
        /// </summary>
        /// <value>Patch operation to perform</value>
        [DataMember(Name = "op", IsRequired = true, EmitDefaultValue = false)]
        public OpEnum Op { get; set; }
        /// <summary>
        /// Where &#x60;languageId&#x60; is one of project&#39;s languages and &#x60;mappingKey&#x60; is one of language-based export pattern fields. &lt;p&gt;A JSON Pointer as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6901\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6901&lt;/a&gt;&lt;/p&gt;
        /// </summary>
        /// <value>Where &#x60;languageId&#x60; is one of project&#39;s languages and &#x60;mappingKey&#x60; is one of language-based export pattern fields. &lt;p&gt;A JSON Pointer as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6901\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6901&lt;/a&gt;&lt;/p&gt;</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum PathEnum
        {
            /// <summary>
            /// Enum TranslateDuplicates for value: /translateDuplicates
            /// </summary>
            [EnumMember(Value = "/translateDuplicates")]
            TranslateDuplicates = 1,

            /// <summary>
            /// Enum IsMtAllowed for value: /isMtAllowed
            /// </summary>
            [EnumMember(Value = "/isMtAllowed")]
            IsMtAllowed = 2,

            /// <summary>
            /// Enum AutoSubstitution for value: /autoSubstitution
            /// </summary>
            [EnumMember(Value = "/autoSubstitution")]
            AutoSubstitution = 3,

            /// <summary>
            /// Enum SkipUntranslatedStrings for value: /skipUntranslatedStrings
            /// </summary>
            [EnumMember(Value = "/skipUntranslatedStrings")]
            SkipUntranslatedStrings = 4,

            /// <summary>
            /// Enum ExportApprovedOnly for value: /exportApprovedOnly
            /// </summary>
            [EnumMember(Value = "/exportApprovedOnly")]
            ExportApprovedOnly = 5,

            /// <summary>
            /// Enum AutoTranslateDialects for value: /autoTranslateDialects
            /// </summary>
            [EnumMember(Value = "/autoTranslateDialects")]
            AutoTranslateDialects = 6,

            /// <summary>
            /// Enum PublicDownloads for value: /publicDownloads
            /// </summary>
            [EnumMember(Value = "/publicDownloads")]
            PublicDownloads = 7,

            /// <summary>
            /// Enum UseGlobalTm for value: /useGlobalTm
            /// </summary>
            [EnumMember(Value = "/useGlobalTm")]
            UseGlobalTm = 8,

            /// <summary>
            /// Enum NormalizePlaceholder for value: normalizePlaceholder
            /// </summary>
            [EnumMember(Value = "normalizePlaceholder")]
            NormalizePlaceholder = 9,

            /// <summary>
            /// Enum SaveMetaInfoInSource for value: saveMetaInfoInSource
            /// </summary>
            [EnumMember(Value = "saveMetaInfoInSource")]
            SaveMetaInfoInSource = 10,

            /// <summary>
            /// Enum InContext for value: /inContext
            /// </summary>
            [EnumMember(Value = "/inContext")]
            InContext = 11,

            /// <summary>
            /// Enum PseudoLanguageId for value: /pseudoLanguageId
            /// </summary>
            [EnumMember(Value = "/pseudoLanguageId")]
            PseudoLanguageId = 12,

            /// <summary>
            /// Enum QaCheckIsActive for value: /qaCheckIsActive
            /// </summary>
            [EnumMember(Value = "/qaCheckIsActive")]
            QaCheckIsActive = 13,

            /// <summary>
            /// Enum QaCheckCategories for value: /qaCheckCategories
            /// </summary>
            [EnumMember(Value = "/qaCheckCategories")]
            QaCheckCategories = 14,

            /// <summary>
            /// Enum QaCheckCategoriescategory for value: /qaCheckCategories/{category}
            /// </summary>
            [EnumMember(Value = "/qaCheckCategories/{category}")]
            QaCheckCategoriescategory = 15,

            /// <summary>
            /// Enum LanguageMapping for value: /languageMapping
            /// </summary>
            [EnumMember(Value = "/languageMapping")]
            LanguageMapping = 16,

            /// <summary>
            /// Enum LanguageMappinglanguageId for value: /languageMapping/{languageId}
            /// </summary>
            [EnumMember(Value = "/languageMapping/{languageId}")]
            LanguageMappinglanguageId = 17,

            /// <summary>
            /// Enum LanguageMappinglanguageIdmappingKey for value: /languageMapping/{languageId}/{mappingKey}
            /// </summary>
            [EnumMember(Value = "/languageMapping/{languageId}/{mappingKey}")]
            LanguageMappinglanguageIdmappingKey = 18

        }


        /// <summary>
        /// Where &#x60;languageId&#x60; is one of project&#39;s languages and &#x60;mappingKey&#x60; is one of language-based export pattern fields. &lt;p&gt;A JSON Pointer as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6901\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6901&lt;/a&gt;&lt;/p&gt;
        /// </summary>
        /// <value>Where &#x60;languageId&#x60; is one of project&#39;s languages and &#x60;mappingKey&#x60; is one of language-based export pattern fields. &lt;p&gt;A JSON Pointer as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6901\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6901&lt;/a&gt;&lt;/p&gt;</value>
        [DataMember(Name = "path", IsRequired = true, EmitDefaultValue = false)]
        public PathEnum Path { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectSettingOperation" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ProjectSettingOperation() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectSettingOperation" /> class.
        /// </summary>
        /// <param name="op">Patch operation to perform (required).</param>
        /// <param name="path">Where &#x60;languageId&#x60; is one of project&#39;s languages and &#x60;mappingKey&#x60; is one of language-based export pattern fields. &lt;p&gt;A JSON Pointer as defined by &lt;a href&#x3D;\&quot;https://tools.ietf.org/html/rfc6901\&quot; target&#x3D;\&quot;_blank\&quot;&gt;RFC 6901&lt;/a&gt;&lt;/p&gt; (required).</param>
        public ProjectSettingOperation(OpEnum op = default(OpEnum), PathEnum path = default(PathEnum))
        {
            this.Op = op;
            this.Path = path;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ProjectSettingOperation {\n");
            sb.Append("  Op: ").Append(Op).Append("\n");
            sb.Append("  Path: ").Append(Path).Append("\n");
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
            return this.Equals(input as ProjectSettingOperation);
        }

        /// <summary>
        /// Returns true if ProjectSettingOperation instances are equal
        /// </summary>
        /// <param name="input">Instance of ProjectSettingOperation to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProjectSettingOperation input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Op == input.Op ||
                    this.Op.Equals(input.Op)
                ) && 
                (
                    this.Path == input.Path ||
                    this.Path.Equals(input.Path)
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
                hashCode = hashCode * 59 + this.Op.GetHashCode();
                hashCode = hashCode * 59 + this.Path.GetHashCode();
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
            return this.BaseValidate(validationContext);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        protected IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> BaseValidate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
