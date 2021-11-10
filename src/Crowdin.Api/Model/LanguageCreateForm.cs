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
    /// LanguageCreateForm
    /// </summary>
    [DataContract(Name = "LanguageCreateForm")]
    public partial class LanguageCreateForm : IEquatable<LanguageCreateForm>, IValidatableObject
    {
        /// <summary>
        /// Text direction in custom language. Available values:  *               &#39;ltr&#39; — left-to-right  *               &#39;rtl&#39; — right-to-left
        /// </summary>
        /// <value>Text direction in custom language. Available values:  *               &#39;ltr&#39; — left-to-right  *               &#39;rtl&#39; — right-to-left</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TextDirectionEnum
        {
            /// <summary>
            /// Enum Ltr for value: ltr
            /// </summary>
            [EnumMember(Value = "ltr")]
            Ltr = 1,

            /// <summary>
            /// Enum Rtl for value: rtl
            /// </summary>
            [EnumMember(Value = "rtl")]
            Rtl = 2

        }


        /// <summary>
        /// Text direction in custom language. Available values:  *               &#39;ltr&#39; — left-to-right  *               &#39;rtl&#39; — right-to-left
        /// </summary>
        /// <value>Text direction in custom language. Available values:  *               &#39;ltr&#39; — left-to-right  *               &#39;rtl&#39; — right-to-left</value>
        [DataMember(Name = "textDirection", IsRequired = true, EmitDefaultValue = false)]
        public TextDirectionEnum TextDirection { get; set; }


        /// <summary>
        /// Array with category names
        /// </summary>
        /// <value>Array with category names</value>
        [DataMember(Name = "pluralCategoryNames", IsRequired = true, EmitDefaultValue = false)]
        public PluralCategoryNamesEnum PluralCategoryNames { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageCreateForm" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected LanguageCreateForm() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageCreateForm" /> class.
        /// </summary>
        /// <param name="name">Language name (required).</param>
        /// <param name="code">Custom language code (required).</param>
        /// <param name="localeCode">Custom language locale code (required).</param>
        /// <param name="textDirection">Text direction in custom language. Available values:  *               &#39;ltr&#39; — left-to-right  *               &#39;rtl&#39; — right-to-left (required).</param>
        /// <param name="pluralCategoryNames">Array with category names (required).</param>
        /// <param name="threeLettersCode">Custom language 3 letters code  __Format:__ ISO 6393 code (required).</param>
        /// <param name="twoLettersCode">Custom language 2 letters code  __Format:__ ISO 6391 code.</param>
        /// <param name="dialectOf">Use if custom language is a dialect. Get &#x60;id&#x60; via [List Supported Languages](#operation/api.languages.getMany).</param>
        public LanguageCreateForm(string name = default(string), string code = default(string), string localeCode = default(string), TextDirectionEnum textDirection = default(TextDirectionEnum), PluralCategoryNamesEnum pluralCategoryNames = default(PluralCategoryNamesEnum), string threeLettersCode = default(string), string twoLettersCode = default(string), string dialectOf = default(string))
        {
            // to ensure "name" is required (not null)
            if (name == null) {
                throw new ArgumentNullException("name is a required property for LanguageCreateForm and cannot be null");
            }
            this.Name = name;
            // to ensure "code" is required (not null)
            if (code == null) {
                throw new ArgumentNullException("code is a required property for LanguageCreateForm and cannot be null");
            }
            this.Code = code;
            // to ensure "localeCode" is required (not null)
            if (localeCode == null) {
                throw new ArgumentNullException("localeCode is a required property for LanguageCreateForm and cannot be null");
            }
            this.LocaleCode = localeCode;
            this.TextDirection = textDirection;
            // to ensure "pluralCategoryNames" is required (not null)
            if (pluralCategoryNames == null) {
                throw new ArgumentNullException("pluralCategoryNames is a required property for LanguageCreateForm and cannot be null");
            }
            this.PluralCategoryNames = pluralCategoryNames;
            // to ensure "threeLettersCode" is required (not null)
            if (threeLettersCode == null) {
                throw new ArgumentNullException("threeLettersCode is a required property for LanguageCreateForm and cannot be null");
            }
            this.ThreeLettersCode = threeLettersCode;
            this.TwoLettersCode = twoLettersCode;
            this.DialectOf = dialectOf;
        }

        /// <summary>
        /// Language name
        /// </summary>
        /// <value>Language name</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Custom language code
        /// </summary>
        /// <value>Custom language code</value>
        [DataMember(Name = "code", IsRequired = true, EmitDefaultValue = false)]
        public string Code { get; set; }

        /// <summary>
        /// Custom language locale code
        /// </summary>
        /// <value>Custom language locale code</value>
        [DataMember(Name = "localeCode", IsRequired = true, EmitDefaultValue = false)]
        public string LocaleCode { get; set; }

        /// <summary>
        /// Custom language 3 letters code  __Format:__ ISO 6393 code
        /// </summary>
        /// <value>Custom language 3 letters code  __Format:__ ISO 6393 code</value>
        [DataMember(Name = "threeLettersCode", IsRequired = true, EmitDefaultValue = false)]
        public string ThreeLettersCode { get; set; }

        /// <summary>
        /// Custom language 2 letters code  __Format:__ ISO 6391 code
        /// </summary>
        /// <value>Custom language 2 letters code  __Format:__ ISO 6391 code</value>
        [DataMember(Name = "twoLettersCode", EmitDefaultValue = false)]
        public string TwoLettersCode { get; set; }

        /// <summary>
        /// Use if custom language is a dialect. Get &#x60;id&#x60; via [List Supported Languages](#operation/api.languages.getMany)
        /// </summary>
        /// <value>Use if custom language is a dialect. Get &#x60;id&#x60; via [List Supported Languages](#operation/api.languages.getMany)</value>
        [DataMember(Name = "dialectOf", EmitDefaultValue = false)]
        public string DialectOf { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LanguageCreateForm {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  LocaleCode: ").Append(LocaleCode).Append("\n");
            sb.Append("  TextDirection: ").Append(TextDirection).Append("\n");
            sb.Append("  PluralCategoryNames: ").Append(PluralCategoryNames).Append("\n");
            sb.Append("  ThreeLettersCode: ").Append(ThreeLettersCode).Append("\n");
            sb.Append("  TwoLettersCode: ").Append(TwoLettersCode).Append("\n");
            sb.Append("  DialectOf: ").Append(DialectOf).Append("\n");
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
            return this.Equals(input as LanguageCreateForm);
        }

        /// <summary>
        /// Returns true if LanguageCreateForm instances are equal
        /// </summary>
        /// <param name="input">Instance of LanguageCreateForm to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LanguageCreateForm input)
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
                    this.Code == input.Code ||
                    (this.Code != null &&
                    this.Code.Equals(input.Code))
                ) && 
                (
                    this.LocaleCode == input.LocaleCode ||
                    (this.LocaleCode != null &&
                    this.LocaleCode.Equals(input.LocaleCode))
                ) && 
                (
                    this.TextDirection == input.TextDirection ||
                    this.TextDirection.Equals(input.TextDirection)
                ) && 
                (
                    this.PluralCategoryNames == input.PluralCategoryNames ||
                    this.PluralCategoryNames.SequenceEqual(input.PluralCategoryNames)
                ) && 
                (
                    this.ThreeLettersCode == input.ThreeLettersCode ||
                    (this.ThreeLettersCode != null &&
                    this.ThreeLettersCode.Equals(input.ThreeLettersCode))
                ) && 
                (
                    this.TwoLettersCode == input.TwoLettersCode ||
                    (this.TwoLettersCode != null &&
                    this.TwoLettersCode.Equals(input.TwoLettersCode))
                ) && 
                (
                    this.DialectOf == input.DialectOf ||
                    (this.DialectOf != null &&
                    this.DialectOf.Equals(input.DialectOf))
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
                if (this.Code != null)
                    hashCode = hashCode * 59 + this.Code.GetHashCode();
                if (this.LocaleCode != null)
                    hashCode = hashCode * 59 + this.LocaleCode.GetHashCode();
                hashCode = hashCode * 59 + this.TextDirection.GetHashCode();
                hashCode = hashCode * 59 + this.PluralCategoryNames.GetHashCode();
                if (this.ThreeLettersCode != null)
                    hashCode = hashCode * 59 + this.ThreeLettersCode.GetHashCode();
                if (this.TwoLettersCode != null)
                    hashCode = hashCode * 59 + this.TwoLettersCode.GetHashCode();
                if (this.DialectOf != null)
                    hashCode = hashCode * 59 + this.DialectOf.GetHashCode();
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
