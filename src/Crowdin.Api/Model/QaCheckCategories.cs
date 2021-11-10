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
    /// QaCheckCategories
    /// </summary>
    [DataContract(Name = "qaCheckCategories")]
    public partial class QaCheckCategories : IEquatable<QaCheckCategories>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QaCheckCategories" /> class.
        /// </summary>
        /// <param name="empty">empty (default to true).</param>
        /// <param name="size">size (default to true).</param>
        /// <param name="tags">tags (default to true).</param>
        /// <param name="spaces">spaces (default to true).</param>
        /// <param name="variables">variables (default to true).</param>
        /// <param name="punctuation">punctuation (default to true).</param>
        /// <param name="symbolRegister">symbolRegister (default to true).</param>
        /// <param name="specialSymbols">specialSymbols (default to true).</param>
        /// <param name="wrongTranslation">wrongTranslation (default to true).</param>
        /// <param name="spellcheck">spellcheck (default to true).</param>
        /// <param name="icu">icu (default to true).</param>
        /// <param name="terms">terms (default to false).</param>
        /// <param name="duplicate">duplicate (default to true).</param>
        public QaCheckCategories(bool empty = true, bool size = true, bool tags = true, bool spaces = true, bool variables = true, bool punctuation = true, bool symbolRegister = true, bool specialSymbols = true, bool wrongTranslation = true, bool spellcheck = true, bool icu = true, bool terms = false, bool duplicate = true)
        {
            this.Empty = empty;
            this.Size = size;
            this.Tags = tags;
            this.Spaces = spaces;
            this.Variables = variables;
            this.Punctuation = punctuation;
            this.SymbolRegister = symbolRegister;
            this.SpecialSymbols = specialSymbols;
            this.WrongTranslation = wrongTranslation;
            this.Spellcheck = spellcheck;
            this.Icu = icu;
            this.Terms = terms;
            this.Duplicate = duplicate;
        }

        /// <summary>
        /// Gets or Sets Empty
        /// </summary>
        [DataMember(Name = "empty", EmitDefaultValue = true)]
        public bool Empty { get; set; }

        /// <summary>
        /// Gets or Sets Size
        /// </summary>
        [DataMember(Name = "size", EmitDefaultValue = true)]
        public bool Size { get; set; }

        /// <summary>
        /// Gets or Sets Tags
        /// </summary>
        [DataMember(Name = "tags", EmitDefaultValue = true)]
        public bool Tags { get; set; }

        /// <summary>
        /// Gets or Sets Spaces
        /// </summary>
        [DataMember(Name = "spaces", EmitDefaultValue = true)]
        public bool Spaces { get; set; }

        /// <summary>
        /// Gets or Sets Variables
        /// </summary>
        [DataMember(Name = "variables", EmitDefaultValue = true)]
        public bool Variables { get; set; }

        /// <summary>
        /// Gets or Sets Punctuation
        /// </summary>
        [DataMember(Name = "punctuation", EmitDefaultValue = true)]
        public bool Punctuation { get; set; }

        /// <summary>
        /// Gets or Sets SymbolRegister
        /// </summary>
        [DataMember(Name = "symbolRegister", EmitDefaultValue = true)]
        public bool SymbolRegister { get; set; }

        /// <summary>
        /// Gets or Sets SpecialSymbols
        /// </summary>
        [DataMember(Name = "specialSymbols", EmitDefaultValue = true)]
        public bool SpecialSymbols { get; set; }

        /// <summary>
        /// Gets or Sets WrongTranslation
        /// </summary>
        [DataMember(Name = "wrongTranslation", EmitDefaultValue = true)]
        public bool WrongTranslation { get; set; }

        /// <summary>
        /// Gets or Sets Spellcheck
        /// </summary>
        [DataMember(Name = "spellcheck", EmitDefaultValue = true)]
        public bool Spellcheck { get; set; }

        /// <summary>
        /// Gets or Sets Icu
        /// </summary>
        [DataMember(Name = "icu", EmitDefaultValue = true)]
        public bool Icu { get; set; }

        /// <summary>
        /// Gets or Sets Terms
        /// </summary>
        [DataMember(Name = "terms", EmitDefaultValue = true)]
        public bool Terms { get; set; }

        /// <summary>
        /// Gets or Sets Duplicate
        /// </summary>
        [DataMember(Name = "duplicate", EmitDefaultValue = true)]
        public bool Duplicate { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class QaCheckCategories {\n");
            sb.Append("  Empty: ").Append(Empty).Append("\n");
            sb.Append("  Size: ").Append(Size).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Spaces: ").Append(Spaces).Append("\n");
            sb.Append("  Variables: ").Append(Variables).Append("\n");
            sb.Append("  Punctuation: ").Append(Punctuation).Append("\n");
            sb.Append("  SymbolRegister: ").Append(SymbolRegister).Append("\n");
            sb.Append("  SpecialSymbols: ").Append(SpecialSymbols).Append("\n");
            sb.Append("  WrongTranslation: ").Append(WrongTranslation).Append("\n");
            sb.Append("  Spellcheck: ").Append(Spellcheck).Append("\n");
            sb.Append("  Icu: ").Append(Icu).Append("\n");
            sb.Append("  Terms: ").Append(Terms).Append("\n");
            sb.Append("  Duplicate: ").Append(Duplicate).Append("\n");
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
            return this.Equals(input as QaCheckCategories);
        }

        /// <summary>
        /// Returns true if QaCheckCategories instances are equal
        /// </summary>
        /// <param name="input">Instance of QaCheckCategories to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(QaCheckCategories input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Empty == input.Empty ||
                    this.Empty.Equals(input.Empty)
                ) && 
                (
                    this.Size == input.Size ||
                    this.Size.Equals(input.Size)
                ) && 
                (
                    this.Tags == input.Tags ||
                    this.Tags.Equals(input.Tags)
                ) && 
                (
                    this.Spaces == input.Spaces ||
                    this.Spaces.Equals(input.Spaces)
                ) && 
                (
                    this.Variables == input.Variables ||
                    this.Variables.Equals(input.Variables)
                ) && 
                (
                    this.Punctuation == input.Punctuation ||
                    this.Punctuation.Equals(input.Punctuation)
                ) && 
                (
                    this.SymbolRegister == input.SymbolRegister ||
                    this.SymbolRegister.Equals(input.SymbolRegister)
                ) && 
                (
                    this.SpecialSymbols == input.SpecialSymbols ||
                    this.SpecialSymbols.Equals(input.SpecialSymbols)
                ) && 
                (
                    this.WrongTranslation == input.WrongTranslation ||
                    this.WrongTranslation.Equals(input.WrongTranslation)
                ) && 
                (
                    this.Spellcheck == input.Spellcheck ||
                    this.Spellcheck.Equals(input.Spellcheck)
                ) && 
                (
                    this.Icu == input.Icu ||
                    this.Icu.Equals(input.Icu)
                ) && 
                (
                    this.Terms == input.Terms ||
                    this.Terms.Equals(input.Terms)
                ) && 
                (
                    this.Duplicate == input.Duplicate ||
                    this.Duplicate.Equals(input.Duplicate)
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
                hashCode = hashCode * 59 + this.Empty.GetHashCode();
                hashCode = hashCode * 59 + this.Size.GetHashCode();
                hashCode = hashCode * 59 + this.Tags.GetHashCode();
                hashCode = hashCode * 59 + this.Spaces.GetHashCode();
                hashCode = hashCode * 59 + this.Variables.GetHashCode();
                hashCode = hashCode * 59 + this.Punctuation.GetHashCode();
                hashCode = hashCode * 59 + this.SymbolRegister.GetHashCode();
                hashCode = hashCode * 59 + this.SpecialSymbols.GetHashCode();
                hashCode = hashCode * 59 + this.WrongTranslation.GetHashCode();
                hashCode = hashCode * 59 + this.Spellcheck.GetHashCode();
                hashCode = hashCode * 59 + this.Icu.GetHashCode();
                hashCode = hashCode * 59 + this.Terms.GetHashCode();
                hashCode = hashCode * 59 + this.Duplicate.GetHashCode();
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
