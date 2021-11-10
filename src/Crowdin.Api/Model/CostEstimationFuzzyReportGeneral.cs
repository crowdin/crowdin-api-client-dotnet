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
    /// CostEstimationFuzzyReportGeneral
    /// </summary>
    [DataContract(Name = "cost-estimation-fuzzy.report.general")]
    public partial class CostEstimationFuzzyReportGeneral : IEquatable<CostEstimationFuzzyReportGeneral>, IValidatableObject
    {
        /// <summary>
        /// Defines report unit
        /// </summary>
        /// <value>Defines report unit</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum UnitEnum
        {
            /// <summary>
            /// Enum Strings for value: strings
            /// </summary>
            [EnumMember(Value = "strings")]
            Strings = 1,

            /// <summary>
            /// Enum Words for value: words
            /// </summary>
            [EnumMember(Value = "words")]
            Words = 2,

            /// <summary>
            /// Enum Chars for value: chars
            /// </summary>
            [EnumMember(Value = "chars")]
            Chars = 3,

            /// <summary>
            /// Enum CharsWithSpaces for value: chars_with_spaces
            /// </summary>
            [EnumMember(Value = "chars_with_spaces")]
            CharsWithSpaces = 4

        }


        /// <summary>
        /// Defines report unit
        /// </summary>
        /// <value>Defines report unit</value>
        [DataMember(Name = "unit", EmitDefaultValue = false)]
        public UnitEnum? Unit { get; set; }
        /// <summary>
        /// Defines report currency
        /// </summary>
        /// <value>Defines report currency</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum CurrencyEnum
        {
            /// <summary>
            /// Enum USD for value: USD
            /// </summary>
            [EnumMember(Value = "USD")]
            USD = 1,

            /// <summary>
            /// Enum EUR for value: EUR
            /// </summary>
            [EnumMember(Value = "EUR")]
            EUR = 2,

            /// <summary>
            /// Enum JPY for value: JPY
            /// </summary>
            [EnumMember(Value = "JPY")]
            JPY = 3,

            /// <summary>
            /// Enum GBP for value: GBP
            /// </summary>
            [EnumMember(Value = "GBP")]
            GBP = 4,

            /// <summary>
            /// Enum AUD for value: AUD
            /// </summary>
            [EnumMember(Value = "AUD")]
            AUD = 5,

            /// <summary>
            /// Enum CAD for value: CAD
            /// </summary>
            [EnumMember(Value = "CAD")]
            CAD = 6,

            /// <summary>
            /// Enum CHF for value: CHF
            /// </summary>
            [EnumMember(Value = "CHF")]
            CHF = 7,

            /// <summary>
            /// Enum CNY for value: CNY
            /// </summary>
            [EnumMember(Value = "CNY")]
            CNY = 8,

            /// <summary>
            /// Enum SEK for value: SEK
            /// </summary>
            [EnumMember(Value = "SEK")]
            SEK = 9,

            /// <summary>
            /// Enum NZD for value: NZD
            /// </summary>
            [EnumMember(Value = "NZD")]
            NZD = 10,

            /// <summary>
            /// Enum MXN for value: MXN
            /// </summary>
            [EnumMember(Value = "MXN")]
            MXN = 11,

            /// <summary>
            /// Enum SGD for value: SGD
            /// </summary>
            [EnumMember(Value = "SGD")]
            SGD = 12,

            /// <summary>
            /// Enum HKD for value: HKD
            /// </summary>
            [EnumMember(Value = "HKD")]
            HKD = 13,

            /// <summary>
            /// Enum NOK for value: NOK
            /// </summary>
            [EnumMember(Value = "NOK")]
            NOK = 14,

            /// <summary>
            /// Enum KRW for value: KRW
            /// </summary>
            [EnumMember(Value = "KRW")]
            KRW = 15,

            /// <summary>
            /// Enum TRY for value: TRY
            /// </summary>
            [EnumMember(Value = "TRY")]
            TRY = 16,

            /// <summary>
            /// Enum RUB for value: RUB
            /// </summary>
            [EnumMember(Value = "RUB")]
            RUB = 17,

            /// <summary>
            /// Enum INR for value: INR
            /// </summary>
            [EnumMember(Value = "INR")]
            INR = 18,

            /// <summary>
            /// Enum BRL for value: BRL
            /// </summary>
            [EnumMember(Value = "BRL")]
            BRL = 19,

            /// <summary>
            /// Enum ZAR for value: ZAR
            /// </summary>
            [EnumMember(Value = "ZAR")]
            ZAR = 20,

            /// <summary>
            /// Enum GEL for value: GEL
            /// </summary>
            [EnumMember(Value = "GEL")]
            GEL = 21,

            /// <summary>
            /// Enum UAH for value: UAH
            /// </summary>
            [EnumMember(Value = "UAH")]
            UAH = 22

        }


        /// <summary>
        /// Defines report currency
        /// </summary>
        /// <value>Defines report currency</value>
        [DataMember(Name = "currency", EmitDefaultValue = false)]
        public CurrencyEnum? Currency { get; set; }
        /// <summary>
        /// Defines export file format
        /// </summary>
        /// <value>Defines export file format</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum FormatEnum
        {
            /// <summary>
            /// Enum Xlsx for value: xlsx
            /// </summary>
            [EnumMember(Value = "xlsx")]
            Xlsx = 1,

            /// <summary>
            /// Enum Csv for value: csv
            /// </summary>
            [EnumMember(Value = "csv")]
            Csv = 2,

            /// <summary>
            /// Enum Json for value: json
            /// </summary>
            [EnumMember(Value = "json")]
            Json = 3

        }


        /// <summary>
        /// Defines export file format
        /// </summary>
        /// <value>Defines export file format</value>
        [DataMember(Name = "format", EmitDefaultValue = false)]
        public FormatEnum? Format { get; set; }
        /// <summary>
        /// Defines which strings include in report
        /// </summary>
        /// <value>Defines which strings include in report</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum LabelIncludeTypeEnum
        {
            /// <summary>
            /// Enum WithLabel for value: strings_with_label
            /// </summary>
            [EnumMember(Value = "strings_with_label")]
            WithLabel = 1,

            /// <summary>
            /// Enum WithoutLabel for value: strings_without_label
            /// </summary>
            [EnumMember(Value = "strings_without_label")]
            WithoutLabel = 2

        }


        /// <summary>
        /// Defines which strings include in report
        /// </summary>
        /// <value>Defines which strings include in report</value>
        [DataMember(Name = "labelIncludeType", EmitDefaultValue = false)]
        public LabelIncludeTypeEnum? LabelIncludeType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CostEstimationFuzzyReportGeneral" /> class.
        /// </summary>
        /// <param name="unit">Defines report unit (default to UnitEnum.Words).</param>
        /// <param name="currency">Defines report currency (default to CurrencyEnum.USD).</param>
        /// <param name="format">Defines export file format (default to FormatEnum.Xlsx).</param>
        /// <param name="stepTypes">Defines step type, mode, regularRates.</param>
        /// <param name="languageId">Language Identifier for which the report should be generated. Get via [List Supported Languages](#operation/api.languages.getMany)  __Note:__ Can&#39;t be used with &#x60;individualRates&#x60; (at &#x60;stepTypes&#x60;) in the same request.</param>
        /// <param name="fileIds">Array of file ids.</param>
        /// <param name="directoryIds">Array of directory ids.</param>
        /// <param name="branchIds">Array of branch ids.</param>
        /// <param name="dateFrom">Report date from in UTC, ISO 8601.</param>
        /// <param name="dateTo">Report date to in UTC, ISO 8601.</param>
        /// <param name="labelIds">Array of label ids.</param>
        /// <param name="labelIncludeType">Defines which strings include in report (default to LabelIncludeTypeEnum.WithLabel).</param>
        public CostEstimationFuzzyReportGeneral(UnitEnum? unit = UnitEnum.Words, CurrencyEnum? currency = CurrencyEnum.USD, FormatEnum? format = FormatEnum.Xlsx, List<AnyOfcostEstimationFuzzyStepsTranslatecostEstimationFuzzyStepsProofread> stepTypes = default(List<AnyOfcostEstimationFuzzyStepsTranslatecostEstimationFuzzyStepsProofread>), string languageId = default(string), List<int> fileIds = default(List<int>), List<int> directoryIds = default(List<int>), List<int> branchIds = default(List<int>), DateTime dateFrom = default(DateTime), DateTime dateTo = default(DateTime), List<int> labelIds = default(List<int>), LabelIncludeTypeEnum? labelIncludeType = LabelIncludeTypeEnum.WithLabel)
        {
            this.Unit = unit;
            this.Currency = currency;
            this.Format = format;
            this.StepTypes = stepTypes;
            this.LanguageId = languageId;
            this.FileIds = fileIds;
            this.DirectoryIds = directoryIds;
            this.BranchIds = branchIds;
            this.DateFrom = dateFrom;
            this.DateTo = dateTo;
            this.LabelIds = labelIds;
            this.LabelIncludeType = labelIncludeType;
        }

        /// <summary>
        /// Defines step type, mode, regularRates
        /// </summary>
        /// <value>Defines step type, mode, regularRates</value>
        [DataMember(Name = "stepTypes", EmitDefaultValue = false)]
        public List<AnyOfcostEstimationFuzzyStepsTranslatecostEstimationFuzzyStepsProofread> StepTypes { get; set; }

        /// <summary>
        /// Language Identifier for which the report should be generated. Get via [List Supported Languages](#operation/api.languages.getMany)  __Note:__ Can&#39;t be used with &#x60;individualRates&#x60; (at &#x60;stepTypes&#x60;) in the same request
        /// </summary>
        /// <value>Language Identifier for which the report should be generated. Get via [List Supported Languages](#operation/api.languages.getMany)  __Note:__ Can&#39;t be used with &#x60;individualRates&#x60; (at &#x60;stepTypes&#x60;) in the same request</value>
        [DataMember(Name = "languageId", EmitDefaultValue = false)]
        public string LanguageId { get; set; }

        /// <summary>
        /// Array of file ids
        /// </summary>
        /// <value>Array of file ids</value>
        [DataMember(Name = "fileIds", EmitDefaultValue = false)]
        public List<int> FileIds { get; set; }

        /// <summary>
        /// Array of directory ids
        /// </summary>
        /// <value>Array of directory ids</value>
        [DataMember(Name = "directoryIds", EmitDefaultValue = false)]
        public List<int> DirectoryIds { get; set; }

        /// <summary>
        /// Array of branch ids
        /// </summary>
        /// <value>Array of branch ids</value>
        [DataMember(Name = "branchIds", EmitDefaultValue = false)]
        public List<int> BranchIds { get; set; }

        /// <summary>
        /// Report date from in UTC, ISO 8601
        /// </summary>
        /// <value>Report date from in UTC, ISO 8601</value>
        [DataMember(Name = "dateFrom", EmitDefaultValue = false)]
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// Report date to in UTC, ISO 8601
        /// </summary>
        /// <value>Report date to in UTC, ISO 8601</value>
        [DataMember(Name = "dateTo", EmitDefaultValue = false)]
        public DateTime DateTo { get; set; }

        /// <summary>
        /// Array of label ids
        /// </summary>
        /// <value>Array of label ids</value>
        [DataMember(Name = "labelIds", EmitDefaultValue = false)]
        public List<int> LabelIds { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CostEstimationFuzzyReportGeneral {\n");
            sb.Append("  Unit: ").Append(Unit).Append("\n");
            sb.Append("  Currency: ").Append(Currency).Append("\n");
            sb.Append("  Format: ").Append(Format).Append("\n");
            sb.Append("  StepTypes: ").Append(StepTypes).Append("\n");
            sb.Append("  LanguageId: ").Append(LanguageId).Append("\n");
            sb.Append("  FileIds: ").Append(FileIds).Append("\n");
            sb.Append("  DirectoryIds: ").Append(DirectoryIds).Append("\n");
            sb.Append("  BranchIds: ").Append(BranchIds).Append("\n");
            sb.Append("  DateFrom: ").Append(DateFrom).Append("\n");
            sb.Append("  DateTo: ").Append(DateTo).Append("\n");
            sb.Append("  LabelIds: ").Append(LabelIds).Append("\n");
            sb.Append("  LabelIncludeType: ").Append(LabelIncludeType).Append("\n");
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
            return this.Equals(input as CostEstimationFuzzyReportGeneral);
        }

        /// <summary>
        /// Returns true if CostEstimationFuzzyReportGeneral instances are equal
        /// </summary>
        /// <param name="input">Instance of CostEstimationFuzzyReportGeneral to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CostEstimationFuzzyReportGeneral input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Unit == input.Unit ||
                    this.Unit.Equals(input.Unit)
                ) && 
                (
                    this.Currency == input.Currency ||
                    this.Currency.Equals(input.Currency)
                ) && 
                (
                    this.Format == input.Format ||
                    this.Format.Equals(input.Format)
                ) && 
                (
                    this.StepTypes == input.StepTypes ||
                    this.StepTypes != null &&
                    input.StepTypes != null &&
                    this.StepTypes.SequenceEqual(input.StepTypes)
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
                    this.DirectoryIds == input.DirectoryIds ||
                    this.DirectoryIds != null &&
                    input.DirectoryIds != null &&
                    this.DirectoryIds.SequenceEqual(input.DirectoryIds)
                ) && 
                (
                    this.BranchIds == input.BranchIds ||
                    this.BranchIds != null &&
                    input.BranchIds != null &&
                    this.BranchIds.SequenceEqual(input.BranchIds)
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
                ) && 
                (
                    this.LabelIds == input.LabelIds ||
                    this.LabelIds != null &&
                    input.LabelIds != null &&
                    this.LabelIds.SequenceEqual(input.LabelIds)
                ) && 
                (
                    this.LabelIncludeType == input.LabelIncludeType ||
                    this.LabelIncludeType.Equals(input.LabelIncludeType)
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
                hashCode = hashCode * 59 + this.Unit.GetHashCode();
                hashCode = hashCode * 59 + this.Currency.GetHashCode();
                hashCode = hashCode * 59 + this.Format.GetHashCode();
                if (this.StepTypes != null)
                    hashCode = hashCode * 59 + this.StepTypes.GetHashCode();
                if (this.LanguageId != null)
                    hashCode = hashCode * 59 + this.LanguageId.GetHashCode();
                if (this.FileIds != null)
                    hashCode = hashCode * 59 + this.FileIds.GetHashCode();
                if (this.DirectoryIds != null)
                    hashCode = hashCode * 59 + this.DirectoryIds.GetHashCode();
                if (this.BranchIds != null)
                    hashCode = hashCode * 59 + this.BranchIds.GetHashCode();
                if (this.DateFrom != null)
                    hashCode = hashCode * 59 + this.DateFrom.GetHashCode();
                if (this.DateTo != null)
                    hashCode = hashCode * 59 + this.DateTo.GetHashCode();
                if (this.LabelIds != null)
                    hashCode = hashCode * 59 + this.LabelIds.GetHashCode();
                hashCode = hashCode * 59 + this.LabelIncludeType.GetHashCode();
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
