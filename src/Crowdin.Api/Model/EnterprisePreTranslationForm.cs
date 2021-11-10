/*
 * Crowdin API v2
 *
 *  # Introduction Welcome to Crowdin Enterprise API v2 documentation.  Our API is a full-featured RESTful API that helps you to integrate localization into your development process. The endpoints that we use allow you to easily make calls to retrieve information and to execute actions needed.  Most of the functionality of Crowdin Enterprise is available through the API. It allows you to create projects for translations, add and update files, download translations, and much more. In this way, you can script the complex actions that your situation requires.  Documentation starts with a general overview of the design and technology that was implemented and is followed by detailed information on specific methods and endpoints.  ## Asynchronous Operations Methods such as report generation, project build, and file download need some time to be completed and are finalized in several steps. It is what we call asynchronous operations. This  approach allows the application to work without interruptions while the method is running at the background.  To run asynchronous operations, 3 subsequent API methods are used:  *     Method to start operation – returns the status __Found__ if the resource you’re requesting is already generated. Typically, __201 Accepted__ status is returned along with the operation identifier. The operation status is then checked with the help of this identifier.  *     Method to check the status of operation – returns  the completion percentage.  *     Method to get the temporary link for resource download – mostly used for export operations. When the operation is completed, you can run this method to get a temporary link for resource download.  __Note:__ Download link is active for a few minutes.  For example, to download a Translation Memory (TM), you need to run following sequence of API methods:  *     [_Export TM_](#operation/api.tms.exports.post)  *     [_Check TM Export Status_](#operation/api.tms.exports.get)  *     [_Download TM_](#operation/api.tms.exports.getMany)  ## File Upload With Crowdin Enterprise API v2 all files such as files for localization, screenshots, Glossaries, and Translation Memories should be first uploaded to the [Storage](#tag/Storage). After you upload file to the Storage it will have a unique storage id using which you can then add the file to the project.  For example, to upload a localization file to your project, you need to run the following sequence of API methods:  *     [_Add Storage_](#operation/api.storages.post) – upload localization file body to storage at Crowdin server  *     [_Add File_](#operation/api.projects.files.post) – define where to add the localization file with specific _storage id_  ## Authorization To work with Crowdin Enterprise API v2 use one of the following access tokens:   *     [_Personal Access Token_](/enterprise/personal-access-tokens/#creating-a-personal-access-token)  *     [_OAuth Access Token_](/enterprise/authorizing-oauth-apps/#make-requests-to-the-api-with-the-access-token-returned)  Make sure to use the following __header__ in your requests:  `Authorization: Bearer ACCESS_TOKEN`  Responses in case authorization fail:  __401 Unauthorized__ ``` {   \"error\": {     \"message\": \"Unauthorized\",     \"code\": 401   } } ```  __403 Forbidden__ ``` {   \"error\": {     \"message\": \"Not allowed endpoint for token scopes\",     \"code\": 403   } } ``` ``` {   \"error\": {     \"message\": \"Not allowed space for your token\",     \"code\": 403   } } ```  ## Requests All requests should be made using the HTTPS protocol so that traffic is encrypted. The interface responds to different methods depending on the action required.  When a request is successful, a response will typically be sent back in the form of a JSON object. If you specify `Accept` header response will be `application/json`. It’s not required to specify `Accept` header so you can leave it empty.  The API expects all writing requests (_POST_, _PUT_, _PATCH_) in JSON format with the `Content-Type: application/json` header. This ensures that your request is interpreted correctly.  __Note:__ `Content-Type` header can be different (e.g. `image/jpeg`, `text/csv`) if you upload the file using _POST_ methods with a specified content type.  RESTful APIs enable you to call individual API endpoints to perform the following requests:  *     <span class='http-method method-list get'>GET</span> - for simple retrieval of information about source files, translations, or projects. The information you request will be returned to you as a JSON object. The attributes defined by the JSON object can be used to form additional requests.  *     <span class='http-method method-list post'>POST</span> - to create or add a new element. This request includes all of the attributes necessary to create a new object.  *     <span class='http-method method-list put'>PUT</span> - to update or replace the specific element. This request sets the state of the target using the provided values, regardless of their current values.  *     <span class='http-method method-list patch'>PATCH</span> - to edit some specific fields of an entity. With these requests, you only need to provide the data you want to change.  *     <span class='http-method method-list delete'>DELETE</span> - to remove element from your account. Request works if specified object is found. If it is not found, the operation will return a response indicating that the object was not found.  For example, to edit the name and description of a project, where the requested resource is the project with `id` = 1, the request is the following:  __Example Endpoint__ <div class='well well-sm'> <span class='http-method patch'>PATCH</span> https://{organization_domain}.api.crowdin.com/api/v2/<span class='api-section-block-highlighted'>projects/1</span> </div>  where <span class='api-section-block-highlighted'>projects/1</span> is the requested resource.  __Content-Type header:__ `application/json`  __Request body__ ``` [   {\"op\":\"replace\", \"path\":\"/name\", \"value\":\"Project new name\"},   {\"op\":\"replace\", \"path\":\"/description\", \"value\":\"New description for the project\"} ] ```  ## Rate Limits The number of simultaneous API requests per account is 20 requests. Response code __429 Too Many Requests__ is returned when the limit is exceeded.  ## Crowdin API Clients The Crowdin API clients are the lightweight interfaces developed for the Crowdin API v2. They provide common services for making API requests.  You may find detailed information on each client in its respective GitHub repository:  [_Crowdin JavaScript client_](https://github.com/crowdin/crowdin-api-client-js)\\ [_Crowdin PHP client_](https://github.com/crowdin/crowdin-api-client-php)\\ [_Crowdin Java client_](https://github.com/crowdin/crowdin-api-client-java)\\ [_Crowdin Python client_](https://github.com/crowdin/crowdin-api-client-python)\\ _Crowdin .NET client_ _(Coming soon)_  
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
    /// EnterprisePreTranslationForm
    /// </summary>
    [DataContract(Name = "EnterprisePreTranslationForm")]
    public partial class EnterprisePreTranslationForm : IEquatable<EnterprisePreTranslationForm>, IValidatableObject
    {
        /// <summary>
        /// Defines pre-translation method. Available values:  *     &#39;tm&#39; – pre-translation via Translation Memory  *     &#39;mt&#39; – pre-translation via Machine Translation. &#39;mt&#39; should be used with &#x60;engineId&#x60; parameter
        /// </summary>
        /// <value>Defines pre-translation method. Available values:  *     &#39;tm&#39; – pre-translation via Translation Memory  *     &#39;mt&#39; – pre-translation via Machine Translation. &#39;mt&#39; should be used with &#x60;engineId&#x60; parameter</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum MethodEnum
        {
            /// <summary>
            /// Enum Tm for value: tm
            /// </summary>
            [EnumMember(Value = "tm")]
            Tm = 1,

            /// <summary>
            /// Enum Mt for value: mt
            /// </summary>
            [EnumMember(Value = "mt")]
            Mt = 2

        }


        /// <summary>
        /// Defines pre-translation method. Available values:  *     &#39;tm&#39; – pre-translation via Translation Memory  *     &#39;mt&#39; – pre-translation via Machine Translation. &#39;mt&#39; should be used with &#x60;engineId&#x60; parameter
        /// </summary>
        /// <value>Defines pre-translation method. Available values:  *     &#39;tm&#39; – pre-translation via Translation Memory  *     &#39;mt&#39; – pre-translation via Machine Translation. &#39;mt&#39; should be used with &#x60;engineId&#x60; parameter</value>
        [DataMember(Name = "method", EmitDefaultValue = false)]
        public MethodEnum? Method { get; set; }
        /// <summary>
        /// Defines which translations added by TM pre-translation should be auto-approved. Available values:  *     &#39;all&#39; – all  *     &#39;perfectMatchOnly&#39; – with perfect TM match  *     &#39;exceptAutoSubstituted&#39; – all (skip auto-substituted suggestions)  *     &#39;none&#39; – no auto-approve
        /// </summary>
        /// <value>Defines which translations added by TM pre-translation should be auto-approved. Available values:  *     &#39;all&#39; – all  *     &#39;perfectMatchOnly&#39; – with perfect TM match  *     &#39;exceptAutoSubstituted&#39; – all (skip auto-substituted suggestions)  *     &#39;none&#39; – no auto-approve</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum AutoApproveOptionEnum
        {
            /// <summary>
            /// Enum All for value: all
            /// </summary>
            [EnumMember(Value = "all")]
            All = 1,

            /// <summary>
            /// Enum ExceptAutoSubstituted for value: exceptAutoSubstituted
            /// </summary>
            [EnumMember(Value = "exceptAutoSubstituted")]
            ExceptAutoSubstituted = 2,

            /// <summary>
            /// Enum PerfectMatchOnly for value: perfectMatchOnly
            /// </summary>
            [EnumMember(Value = "perfectMatchOnly")]
            PerfectMatchOnly = 3,

            /// <summary>
            /// Enum None for value: none
            /// </summary>
            [EnumMember(Value = "none")]
            None = 4

        }


        /// <summary>
        /// Defines which translations added by TM pre-translation should be auto-approved. Available values:  *     &#39;all&#39; – all  *     &#39;perfectMatchOnly&#39; – with perfect TM match  *     &#39;exceptAutoSubstituted&#39; – all (skip auto-substituted suggestions)  *     &#39;none&#39; – no auto-approve
        /// </summary>
        /// <value>Defines which translations added by TM pre-translation should be auto-approved. Available values:  *     &#39;all&#39; – all  *     &#39;perfectMatchOnly&#39; – with perfect TM match  *     &#39;exceptAutoSubstituted&#39; – all (skip auto-substituted suggestions)  *     &#39;none&#39; – no auto-approve</value>
        [DataMember(Name = "autoApproveOption", EmitDefaultValue = false)]
        public AutoApproveOptionEnum? AutoApproveOption { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="EnterprisePreTranslationForm" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EnterprisePreTranslationForm() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="EnterprisePreTranslationForm" /> class.
        /// </summary>
        /// <param name="languageIds">Set of languages to which pre-translation should be applied. Get via [List Supported Languages](#operation/api.languages.getMany) (required).</param>
        /// <param name="fileIds">Files array that should be translated (required).</param>
        /// <param name="method">Defines pre-translation method. Available values:  *     &#39;tm&#39; – pre-translation via Translation Memory  *     &#39;mt&#39; – pre-translation via Machine Translation. &#39;mt&#39; should be used with &#x60;engineId&#x60; parameter (default to MethodEnum.Tm).</param>
        /// <param name="engineId">Machine Translation engine Identifier. Get via [List MTs](#operation/api.mts.getMany).</param>
        /// <param name="autoApproveOption">Defines which translations added by TM pre-translation should be auto-approved. Available values:  *     &#39;all&#39; – all  *     &#39;perfectMatchOnly&#39; – with perfect TM match  *     &#39;exceptAutoSubstituted&#39; – all (skip auto-substituted suggestions)  *     &#39;none&#39; – no auto-approve (default to AutoApproveOptionEnum.None).</param>
        /// <param name="duplicateTranslations">Adds translations even if the same translation already exists. Default is &#x60;false&#x60;  __Note:__ Works only with TM pre-translation method (default to false).</param>
        /// <param name="translateUntranslatedOnly">Applies pre-translation for untranslated strings only. Default is &#x60;true&#x60;  __Note:__ Works only with TM pre-translation method (default to true).</param>
        /// <param name="translateWithPerfectMatchOnly">Applies pre-translation only for the strings with perfect match (source text and contextual information are identical)  __Note:__ Works only with TM pre-translation method (default to false).</param>
        /// <param name="markAddedTranslationsAsDone">Strings marked as done follow your project&#39;s workflow and appear on the corresponding step (default to true).</param>
        /// <param name="fallbackLanguages">fallbackLanguages.</param>
        public EnterprisePreTranslationForm(List<string> languageIds = default(List<string>), List<int> fileIds = default(List<int>), MethodEnum? method = MethodEnum.Tm, int engineId = default(int), AutoApproveOptionEnum? autoApproveOption = AutoApproveOptionEnum.None, bool duplicateTranslations = false, bool translateUntranslatedOnly = true, bool translateWithPerfectMatchOnly = false, bool markAddedTranslationsAsDone = true, FallbackLanguagesScheme fallbackLanguages = default(FallbackLanguagesScheme))
        {
            // to ensure "languageIds" is required (not null)
            if (languageIds == null) {
                throw new ArgumentNullException("languageIds is a required property for EnterprisePreTranslationForm and cannot be null");
            }
            this.LanguageIds = languageIds;
            // to ensure "fileIds" is required (not null)
            if (fileIds == null) {
                throw new ArgumentNullException("fileIds is a required property for EnterprisePreTranslationForm and cannot be null");
            }
            this.FileIds = fileIds;
            this.Method = method;
            this.EngineId = engineId;
            this.AutoApproveOption = autoApproveOption;
            this.DuplicateTranslations = duplicateTranslations;
            this.TranslateUntranslatedOnly = translateUntranslatedOnly;
            this.TranslateWithPerfectMatchOnly = translateWithPerfectMatchOnly;
            this.MarkAddedTranslationsAsDone = markAddedTranslationsAsDone;
            this.FallbackLanguages = fallbackLanguages;
        }

        /// <summary>
        /// Set of languages to which pre-translation should be applied. Get via [List Supported Languages](#operation/api.languages.getMany)
        /// </summary>
        /// <value>Set of languages to which pre-translation should be applied. Get via [List Supported Languages](#operation/api.languages.getMany)</value>
        [DataMember(Name = "languageIds", IsRequired = true, EmitDefaultValue = false)]
        public List<string> LanguageIds { get; set; }

        /// <summary>
        /// Files array that should be translated
        /// </summary>
        /// <value>Files array that should be translated</value>
        [DataMember(Name = "fileIds", IsRequired = true, EmitDefaultValue = false)]
        public List<int> FileIds { get; set; }

        /// <summary>
        /// Machine Translation engine Identifier. Get via [List MTs](#operation/api.mts.getMany)
        /// </summary>
        /// <value>Machine Translation engine Identifier. Get via [List MTs](#operation/api.mts.getMany)</value>
        [DataMember(Name = "engineId", EmitDefaultValue = false)]
        public int EngineId { get; set; }

        /// <summary>
        /// Adds translations even if the same translation already exists. Default is &#x60;false&#x60;  __Note:__ Works only with TM pre-translation method
        /// </summary>
        /// <value>Adds translations even if the same translation already exists. Default is &#x60;false&#x60;  __Note:__ Works only with TM pre-translation method</value>
        [DataMember(Name = "duplicateTranslations", EmitDefaultValue = true)]
        public bool DuplicateTranslations { get; set; }

        /// <summary>
        /// Applies pre-translation for untranslated strings only. Default is &#x60;true&#x60;  __Note:__ Works only with TM pre-translation method
        /// </summary>
        /// <value>Applies pre-translation for untranslated strings only. Default is &#x60;true&#x60;  __Note:__ Works only with TM pre-translation method</value>
        [DataMember(Name = "translateUntranslatedOnly", EmitDefaultValue = true)]
        public bool TranslateUntranslatedOnly { get; set; }

        /// <summary>
        /// Applies pre-translation only for the strings with perfect match (source text and contextual information are identical)  __Note:__ Works only with TM pre-translation method
        /// </summary>
        /// <value>Applies pre-translation only for the strings with perfect match (source text and contextual information are identical)  __Note:__ Works only with TM pre-translation method</value>
        [DataMember(Name = "translateWithPerfectMatchOnly", EmitDefaultValue = true)]
        public bool TranslateWithPerfectMatchOnly { get; set; }

        /// <summary>
        /// Strings marked as done follow your project&#39;s workflow and appear on the corresponding step
        /// </summary>
        /// <value>Strings marked as done follow your project&#39;s workflow and appear on the corresponding step</value>
        [DataMember(Name = "markAddedTranslationsAsDone", EmitDefaultValue = true)]
        public bool MarkAddedTranslationsAsDone { get; set; }

        /// <summary>
        /// Gets or Sets FallbackLanguages
        /// </summary>
        [DataMember(Name = "fallbackLanguages", EmitDefaultValue = false)]
        public FallbackLanguagesScheme FallbackLanguages { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EnterprisePreTranslationForm {\n");
            sb.Append("  LanguageIds: ").Append(LanguageIds).Append("\n");
            sb.Append("  FileIds: ").Append(FileIds).Append("\n");
            sb.Append("  Method: ").Append(Method).Append("\n");
            sb.Append("  EngineId: ").Append(EngineId).Append("\n");
            sb.Append("  AutoApproveOption: ").Append(AutoApproveOption).Append("\n");
            sb.Append("  DuplicateTranslations: ").Append(DuplicateTranslations).Append("\n");
            sb.Append("  TranslateUntranslatedOnly: ").Append(TranslateUntranslatedOnly).Append("\n");
            sb.Append("  TranslateWithPerfectMatchOnly: ").Append(TranslateWithPerfectMatchOnly).Append("\n");
            sb.Append("  MarkAddedTranslationsAsDone: ").Append(MarkAddedTranslationsAsDone).Append("\n");
            sb.Append("  FallbackLanguages: ").Append(FallbackLanguages).Append("\n");
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
            return this.Equals(input as EnterprisePreTranslationForm);
        }

        /// <summary>
        /// Returns true if EnterprisePreTranslationForm instances are equal
        /// </summary>
        /// <param name="input">Instance of EnterprisePreTranslationForm to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EnterprisePreTranslationForm input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.LanguageIds == input.LanguageIds ||
                    this.LanguageIds != null &&
                    input.LanguageIds != null &&
                    this.LanguageIds.SequenceEqual(input.LanguageIds)
                ) && 
                (
                    this.FileIds == input.FileIds ||
                    this.FileIds != null &&
                    input.FileIds != null &&
                    this.FileIds.SequenceEqual(input.FileIds)
                ) && 
                (
                    this.Method == input.Method ||
                    this.Method.Equals(input.Method)
                ) && 
                (
                    this.EngineId == input.EngineId ||
                    this.EngineId.Equals(input.EngineId)
                ) && 
                (
                    this.AutoApproveOption == input.AutoApproveOption ||
                    this.AutoApproveOption.Equals(input.AutoApproveOption)
                ) && 
                (
                    this.DuplicateTranslations == input.DuplicateTranslations ||
                    this.DuplicateTranslations.Equals(input.DuplicateTranslations)
                ) && 
                (
                    this.TranslateUntranslatedOnly == input.TranslateUntranslatedOnly ||
                    this.TranslateUntranslatedOnly.Equals(input.TranslateUntranslatedOnly)
                ) && 
                (
                    this.TranslateWithPerfectMatchOnly == input.TranslateWithPerfectMatchOnly ||
                    this.TranslateWithPerfectMatchOnly.Equals(input.TranslateWithPerfectMatchOnly)
                ) && 
                (
                    this.MarkAddedTranslationsAsDone == input.MarkAddedTranslationsAsDone ||
                    this.MarkAddedTranslationsAsDone.Equals(input.MarkAddedTranslationsAsDone)
                ) && 
                (
                    this.FallbackLanguages == input.FallbackLanguages ||
                    (this.FallbackLanguages != null &&
                    this.FallbackLanguages.Equals(input.FallbackLanguages))
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
                if (this.LanguageIds != null)
                    hashCode = hashCode * 59 + this.LanguageIds.GetHashCode();
                if (this.FileIds != null)
                    hashCode = hashCode * 59 + this.FileIds.GetHashCode();
                hashCode = hashCode * 59 + this.Method.GetHashCode();
                hashCode = hashCode * 59 + this.EngineId.GetHashCode();
                hashCode = hashCode * 59 + this.AutoApproveOption.GetHashCode();
                hashCode = hashCode * 59 + this.DuplicateTranslations.GetHashCode();
                hashCode = hashCode * 59 + this.TranslateUntranslatedOnly.GetHashCode();
                hashCode = hashCode * 59 + this.TranslateWithPerfectMatchOnly.GetHashCode();
                hashCode = hashCode * 59 + this.MarkAddedTranslationsAsDone.GetHashCode();
                if (this.FallbackLanguages != null)
                    hashCode = hashCode * 59 + this.FallbackLanguages.GetHashCode();
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
