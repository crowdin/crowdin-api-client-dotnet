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
    /// TermCreateForm
    /// </summary>
    [DataContract(Name = "TermCreateForm")]
    public partial class TermCreateForm : IEquatable<TermCreateForm>, IValidatableObject
    {
        /// <summary>
        /// Term part of speech
        /// </summary>
        /// <value>Term part of speech</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum PartOfSpeechEnum
        {
            /// <summary>
            /// Enum Adjective for value: adjective
            /// </summary>
            [EnumMember(Value = "adjective")]
            Adjective = 1,

            /// <summary>
            /// Enum Adposition for value: adposition
            /// </summary>
            [EnumMember(Value = "adposition")]
            Adposition = 2,

            /// <summary>
            /// Enum Adverb for value: adverb
            /// </summary>
            [EnumMember(Value = "adverb")]
            Adverb = 3,

            /// <summary>
            /// Enum Auxiliary for value: auxiliary
            /// </summary>
            [EnumMember(Value = "auxiliary")]
            Auxiliary = 4,

            /// <summary>
            /// Enum CoordinatingConjunction for value: coordinating conjunction
            /// </summary>
            [EnumMember(Value = "coordinating conjunction")]
            CoordinatingConjunction = 5,

            /// <summary>
            /// Enum Determiner for value: determiner
            /// </summary>
            [EnumMember(Value = "determiner")]
            Determiner = 6,

            /// <summary>
            /// Enum Interjection for value: interjection
            /// </summary>
            [EnumMember(Value = "interjection")]
            Interjection = 7,

            /// <summary>
            /// Enum Noun for value: noun
            /// </summary>
            [EnumMember(Value = "noun")]
            Noun = 8,

            /// <summary>
            /// Enum Numeral for value: numeral
            /// </summary>
            [EnumMember(Value = "numeral")]
            Numeral = 9,

            /// <summary>
            /// Enum Particle for value: particle
            /// </summary>
            [EnumMember(Value = "particle")]
            Particle = 10,

            /// <summary>
            /// Enum Pronoun for value: pronoun
            /// </summary>
            [EnumMember(Value = "pronoun")]
            Pronoun = 11,

            /// <summary>
            /// Enum ProperNoun for value: proper noun
            /// </summary>
            [EnumMember(Value = "proper noun")]
            ProperNoun = 12,

            /// <summary>
            /// Enum SubordinatingConjunction for value: subordinating conjunction
            /// </summary>
            [EnumMember(Value = "subordinating conjunction")]
            SubordinatingConjunction = 13,

            /// <summary>
            /// Enum Verb for value: verb
            /// </summary>
            [EnumMember(Value = "verb")]
            Verb = 14,

            /// <summary>
            /// Enum Other for value: other
            /// </summary>
            [EnumMember(Value = "other")]
            Other = 15

        }


        /// <summary>
        /// Term part of speech
        /// </summary>
        /// <value>Term part of speech</value>
        [DataMember(Name = "partOfSpeech", EmitDefaultValue = false)]
        public PartOfSpeechEnum? PartOfSpeech { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TermCreateForm" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TermCreateForm() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TermCreateForm" /> class.
        /// </summary>
        /// <param name="languageId">Term Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany) (required).</param>
        /// <param name="text">Term (required).</param>
        /// <param name="description">Term description.</param>
        /// <param name="partOfSpeech">Term part of speech.</param>
        /// <param name="translationOfTermId">Defines whether to add translation to the existing term. Get &#x60;id&#x60; via [List Terms](#operation/api.glossaries.terms.getMany).</param>
        public TermCreateForm(string languageId = default(string), string text = default(string), string description = default(string), PartOfSpeechEnum? partOfSpeech = default(PartOfSpeechEnum?), int translationOfTermId = default(int))
        {
            // to ensure "languageId" is required (not null)
            if (languageId == null) {
                throw new ArgumentNullException("languageId is a required property for TermCreateForm and cannot be null");
            }
            this.LanguageId = languageId;
            // to ensure "text" is required (not null)
            if (text == null) {
                throw new ArgumentNullException("text is a required property for TermCreateForm and cannot be null");
            }
            this.Text = text;
            this.Description = description;
            this.PartOfSpeech = partOfSpeech;
            this.TranslationOfTermId = translationOfTermId;
        }

        /// <summary>
        /// Term Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany)
        /// </summary>
        /// <value>Term Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany)</value>
        [DataMember(Name = "languageId", IsRequired = true, EmitDefaultValue = false)]
        public string LanguageId { get; set; }

        /// <summary>
        /// Term
        /// </summary>
        /// <value>Term</value>
        [DataMember(Name = "text", IsRequired = true, EmitDefaultValue = false)]
        public string Text { get; set; }

        /// <summary>
        /// Term description
        /// </summary>
        /// <value>Term description</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Defines whether to add translation to the existing term. Get &#x60;id&#x60; via [List Terms](#operation/api.glossaries.terms.getMany)
        /// </summary>
        /// <value>Defines whether to add translation to the existing term. Get &#x60;id&#x60; via [List Terms](#operation/api.glossaries.terms.getMany)</value>
        [DataMember(Name = "translationOfTermId", EmitDefaultValue = false)]
        public int TranslationOfTermId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TermCreateForm {\n");
            sb.Append("  LanguageId: ").Append(LanguageId).Append("\n");
            sb.Append("  Text: ").Append(Text).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  PartOfSpeech: ").Append(PartOfSpeech).Append("\n");
            sb.Append("  TranslationOfTermId: ").Append(TranslationOfTermId).Append("\n");
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
            return this.Equals(input as TermCreateForm);
        }

        /// <summary>
        /// Returns true if TermCreateForm instances are equal
        /// </summary>
        /// <param name="input">Instance of TermCreateForm to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TermCreateForm input)
        {
            if (input == null)
                return false;

            return 
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
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.PartOfSpeech == input.PartOfSpeech ||
                    this.PartOfSpeech.Equals(input.PartOfSpeech)
                ) && 
                (
                    this.TranslationOfTermId == input.TranslationOfTermId ||
                    this.TranslationOfTermId.Equals(input.TranslationOfTermId)
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
                if (this.LanguageId != null)
                    hashCode = hashCode * 59 + this.LanguageId.GetHashCode();
                if (this.Text != null)
                    hashCode = hashCode * 59 + this.Text.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                hashCode = hashCode * 59 + this.PartOfSpeech.GetHashCode();
                hashCode = hashCode * 59 + this.TranslationOfTermId.GetHashCode();
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
