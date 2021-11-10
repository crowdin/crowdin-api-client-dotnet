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
    /// TranslationCreateForm
    /// </summary>
    [DataContract(Name = "TranslationCreateForm")]
    public partial class TranslationCreateForm : IEquatable<TranslationCreateForm>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TranslationCreateForm" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TranslationCreateForm() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TranslationCreateForm" /> class.
        /// </summary>
        /// <param name="stringId">String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany) (required).</param>
        /// <param name="languageId">Language Identifier. Get via [Project Target Languages](#operation/api.projects.get) (required).</param>
        /// <param name="text">Translation text (required).</param>
        /// <param name="pluralCategoryName">Plural form. Acceptable keys are &#x60;zero&#x60;, &#x60;one&#x60;, &#x60;two&#x60;, &#x60;few&#x60;, &#x60;many&#x60;, and &#x60;other&#x60;.</param>
        public TranslationCreateForm(int stringId = default(int), string languageId = default(string), string text = default(string), string pluralCategoryName = default(string))
        {
            this.StringId = stringId;
            // to ensure "languageId" is required (not null)
            if (languageId == null) {
                throw new ArgumentNullException("languageId is a required property for TranslationCreateForm and cannot be null");
            }
            this.LanguageId = languageId;
            // to ensure "text" is required (not null)
            if (text == null) {
                throw new ArgumentNullException("text is a required property for TranslationCreateForm and cannot be null");
            }
            this.Text = text;
            this.PluralCategoryName = pluralCategoryName;
        }

        /// <summary>
        /// String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany)
        /// </summary>
        /// <value>String Identifier. Get via [List Strings](#operation/api.projects.strings.getMany)</value>
        [DataMember(Name = "stringId", IsRequired = true, EmitDefaultValue = false)]
        public int StringId { get; set; }

        /// <summary>
        /// Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)
        /// </summary>
        /// <value>Language Identifier. Get via [Project Target Languages](#operation/api.projects.get)</value>
        [DataMember(Name = "languageId", IsRequired = true, EmitDefaultValue = false)]
        public string LanguageId { get; set; }

        /// <summary>
        /// Translation text
        /// </summary>
        /// <value>Translation text</value>
        [DataMember(Name = "text", IsRequired = true, EmitDefaultValue = false)]
        public string Text { get; set; }

        /// <summary>
        /// Plural form. Acceptable keys are &#x60;zero&#x60;, &#x60;one&#x60;, &#x60;two&#x60;, &#x60;few&#x60;, &#x60;many&#x60;, and &#x60;other&#x60;
        /// </summary>
        /// <value>Plural form. Acceptable keys are &#x60;zero&#x60;, &#x60;one&#x60;, &#x60;two&#x60;, &#x60;few&#x60;, &#x60;many&#x60;, and &#x60;other&#x60;</value>
        [DataMember(Name = "pluralCategoryName", EmitDefaultValue = false)]
        public string PluralCategoryName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TranslationCreateForm {\n");
            sb.Append("  StringId: ").Append(StringId).Append("\n");
            sb.Append("  LanguageId: ").Append(LanguageId).Append("\n");
            sb.Append("  Text: ").Append(Text).Append("\n");
            sb.Append("  PluralCategoryName: ").Append(PluralCategoryName).Append("\n");
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
            return this.Equals(input as TranslationCreateForm);
        }

        /// <summary>
        /// Returns true if TranslationCreateForm instances are equal
        /// </summary>
        /// <param name="input">Instance of TranslationCreateForm to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TranslationCreateForm input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.StringId == input.StringId ||
                    this.StringId.Equals(input.StringId)
                ) && 
                (
                    this.LanguageId == input.LanguageId ||
                    (this.LanguageId != null &&
                    this.LanguageId.Equals(input.LanguageId))
                ) && 
                (
                    this.Text == input.Text ||
                    (this.Text != null &&
                    this.Text.Equals(input.Text))
                ) && 
                (
                    this.PluralCategoryName == input.PluralCategoryName ||
                    (this.PluralCategoryName != null &&
                    this.PluralCategoryName.Equals(input.PluralCategoryName))
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
                hashCode = hashCode * 59 + this.StringId.GetHashCode();
                if (this.LanguageId != null)
                    hashCode = hashCode * 59 + this.LanguageId.GetHashCode();
                if (this.Text != null)
                    hashCode = hashCode * 59 + this.Text.GetHashCode();
                if (this.PluralCategoryName != null)
                    hashCode = hashCode * 59 + this.PluralCategoryName.GetHashCode();
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
