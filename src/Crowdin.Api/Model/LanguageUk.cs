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
    /// LanguageUk
    /// </summary>
    [DataContract(Name = "LanguageUk")]
    public partial class LanguageUk : IEquatable<LanguageUk>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageUk" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="name">name.</param>
        /// <param name="editorCode">editorCode.</param>
        /// <param name="twoLettersCode">twoLettersCode.</param>
        /// <param name="threeLettersCode">threeLettersCode.</param>
        /// <param name="locale">locale.</param>
        /// <param name="androidCode">androidCode.</param>
        /// <param name="osxCode">osxCode.</param>
        /// <param name="osxLocale">osxLocale.</param>
        /// <param name="pluralCategoryNames">pluralCategoryNames.</param>
        /// <param name="pluralRules">pluralRules.</param>
        /// <param name="pluralExamples">pluralExamples.</param>
        /// <param name="textDirection">textDirection.</param>
        /// <param name="dialectOf">dialectOf.</param>
        public LanguageUk(string id = default(string), string name = default(string), string editorCode = default(string), string twoLettersCode = default(string), string threeLettersCode = default(string), string locale = default(string), string androidCode = default(string), string osxCode = default(string), string osxLocale = default(string), List<string> pluralCategoryNames = default(List<string>), string pluralRules = default(string), List<string> pluralExamples = default(List<string>), string textDirection = default(string), string dialectOf = default(string))
        {
            this.Id = id;
            this.Name = name;
            this.EditorCode = editorCode;
            this.TwoLettersCode = twoLettersCode;
            this.ThreeLettersCode = threeLettersCode;
            this.Locale = locale;
            this.AndroidCode = androidCode;
            this.OsxCode = osxCode;
            this.OsxLocale = osxLocale;
            this.PluralCategoryNames = pluralCategoryNames;
            this.PluralRules = pluralRules;
            this.PluralExamples = pluralExamples;
            this.TextDirection = textDirection;
            this.DialectOf = dialectOf;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets EditorCode
        /// </summary>
        [DataMember(Name = "editorCode", EmitDefaultValue = false)]
        public string EditorCode { get; set; }

        /// <summary>
        /// Gets or Sets TwoLettersCode
        /// </summary>
        [DataMember(Name = "twoLettersCode", EmitDefaultValue = false)]
        public string TwoLettersCode { get; set; }

        /// <summary>
        /// Gets or Sets ThreeLettersCode
        /// </summary>
        [DataMember(Name = "threeLettersCode", EmitDefaultValue = false)]
        public string ThreeLettersCode { get; set; }

        /// <summary>
        /// Gets or Sets Locale
        /// </summary>
        [DataMember(Name = "locale", EmitDefaultValue = false)]
        public string Locale { get; set; }

        /// <summary>
        /// Gets or Sets AndroidCode
        /// </summary>
        [DataMember(Name = "androidCode", EmitDefaultValue = false)]
        public string AndroidCode { get; set; }

        /// <summary>
        /// Gets or Sets OsxCode
        /// </summary>
        [DataMember(Name = "osxCode", EmitDefaultValue = false)]
        public string OsxCode { get; set; }

        /// <summary>
        /// Gets or Sets OsxLocale
        /// </summary>
        [DataMember(Name = "osxLocale", EmitDefaultValue = false)]
        public string OsxLocale { get; set; }

        /// <summary>
        /// Gets or Sets PluralCategoryNames
        /// </summary>
        [DataMember(Name = "pluralCategoryNames", EmitDefaultValue = false)]
        public List<string> PluralCategoryNames { get; set; }

        /// <summary>
        /// Gets or Sets PluralRules
        /// </summary>
        [DataMember(Name = "pluralRules", EmitDefaultValue = false)]
        public string PluralRules { get; set; }

        /// <summary>
        /// Gets or Sets PluralExamples
        /// </summary>
        [DataMember(Name = "pluralExamples", EmitDefaultValue = false)]
        public List<string> PluralExamples { get; set; }

        /// <summary>
        /// Gets or Sets TextDirection
        /// </summary>
        [DataMember(Name = "textDirection", EmitDefaultValue = false)]
        public string TextDirection { get; set; }

        /// <summary>
        /// Gets or Sets DialectOf
        /// </summary>
        [DataMember(Name = "dialectOf", EmitDefaultValue = true)]
        public string DialectOf { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LanguageUk {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  EditorCode: ").Append(EditorCode).Append("\n");
            sb.Append("  TwoLettersCode: ").Append(TwoLettersCode).Append("\n");
            sb.Append("  ThreeLettersCode: ").Append(ThreeLettersCode).Append("\n");
            sb.Append("  Locale: ").Append(Locale).Append("\n");
            sb.Append("  AndroidCode: ").Append(AndroidCode).Append("\n");
            sb.Append("  OsxCode: ").Append(OsxCode).Append("\n");
            sb.Append("  OsxLocale: ").Append(OsxLocale).Append("\n");
            sb.Append("  PluralCategoryNames: ").Append(PluralCategoryNames).Append("\n");
            sb.Append("  PluralRules: ").Append(PluralRules).Append("\n");
            sb.Append("  PluralExamples: ").Append(PluralExamples).Append("\n");
            sb.Append("  TextDirection: ").Append(TextDirection).Append("\n");
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
            return this.Equals(input as LanguageUk);
        }

        /// <summary>
        /// Returns true if LanguageUk instances are equal
        /// </summary>
        /// <param name="input">Instance of LanguageUk to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LanguageUk input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.EditorCode == input.EditorCode ||
                    (this.EditorCode != null &&
                    this.EditorCode.Equals(input.EditorCode))
                ) && 
                (
                    this.TwoLettersCode == input.TwoLettersCode ||
                    (this.TwoLettersCode != null &&
                    this.TwoLettersCode.Equals(input.TwoLettersCode))
                ) && 
                (
                    this.ThreeLettersCode == input.ThreeLettersCode ||
                    (this.ThreeLettersCode != null &&
                    this.ThreeLettersCode.Equals(input.ThreeLettersCode))
                ) && 
                (
                    this.Locale == input.Locale ||
                    (this.Locale != null &&
                    this.Locale.Equals(input.Locale))
                ) && 
                (
                    this.AndroidCode == input.AndroidCode ||
                    (this.AndroidCode != null &&
                    this.AndroidCode.Equals(input.AndroidCode))
                ) && 
                (
                    this.OsxCode == input.OsxCode ||
                    (this.OsxCode != null &&
                    this.OsxCode.Equals(input.OsxCode))
                ) && 
                (
                    this.OsxLocale == input.OsxLocale ||
                    (this.OsxLocale != null &&
                    this.OsxLocale.Equals(input.OsxLocale))
                ) && 
                (
                    this.PluralCategoryNames == input.PluralCategoryNames ||
                    this.PluralCategoryNames != null &&
                    input.PluralCategoryNames != null &&
                    this.PluralCategoryNames.SequenceEqual(input.PluralCategoryNames)
                ) && 
                (
                    this.PluralRules == input.PluralRules ||
                    (this.PluralRules != null &&
                    this.PluralRules.Equals(input.PluralRules))
                ) && 
                (
                    this.PluralExamples == input.PluralExamples ||
                    this.PluralExamples != null &&
                    input.PluralExamples != null &&
                    this.PluralExamples.SequenceEqual(input.PluralExamples)
                ) && 
                (
                    this.TextDirection == input.TextDirection ||
                    (this.TextDirection != null &&
                    this.TextDirection.Equals(input.TextDirection))
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
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.EditorCode != null)
                    hashCode = hashCode * 59 + this.EditorCode.GetHashCode();
                if (this.TwoLettersCode != null)
                    hashCode = hashCode * 59 + this.TwoLettersCode.GetHashCode();
                if (this.ThreeLettersCode != null)
                    hashCode = hashCode * 59 + this.ThreeLettersCode.GetHashCode();
                if (this.Locale != null)
                    hashCode = hashCode * 59 + this.Locale.GetHashCode();
                if (this.AndroidCode != null)
                    hashCode = hashCode * 59 + this.AndroidCode.GetHashCode();
                if (this.OsxCode != null)
                    hashCode = hashCode * 59 + this.OsxCode.GetHashCode();
                if (this.OsxLocale != null)
                    hashCode = hashCode * 59 + this.OsxLocale.GetHashCode();
                if (this.PluralCategoryNames != null)
                    hashCode = hashCode * 59 + this.PluralCategoryNames.GetHashCode();
                if (this.PluralRules != null)
                    hashCode = hashCode * 59 + this.PluralRules.GetHashCode();
                if (this.PluralExamples != null)
                    hashCode = hashCode * 59 + this.PluralExamples.GetHashCode();
                if (this.TextDirection != null)
                    hashCode = hashCode * 59 + this.TextDirection.GetHashCode();
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
