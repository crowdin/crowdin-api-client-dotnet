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
    /// GlossaryImportForm
    /// </summary>
    [DataContract(Name = "GlossaryImportForm")]
    public partial class GlossaryImportForm : IEquatable<GlossaryImportForm>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GlossaryImportForm" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GlossaryImportForm() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GlossaryImportForm" /> class.
        /// </summary>
        /// <param name="storageId">Storage Identifier. Get via [List Storages](#operation/api.storages.getMany)  Supported file formats: TBX, CSV, XLS/XLSX (required).</param>
        /// <param name="scheme">Defines data columns mapping. Acceptable value is combination of following constants:   *    &#x60;term_{%language_code%}&#x60; – column with terms  *    &#x60;description_{%language_code%}&#x60; – column with terms description  *    &#x60;partOfSpeech_{%language_code%}&#x60; – column with terms part of speech  &lt;br&gt;where &#x60;%language_code%&#x60; – placeholder for your language code  __Note:__ Used for upload of CSV or XLS/XLSX files only.</param>
        /// <param name="firstLineContainsHeader">Defines whether file includes first row header that should not be imported  __Note:__  Used for upload of CSV or XLS/XLSX files only (default to false).</param>
        public GlossaryImportForm(int storageId = default(int), Object scheme = default(Object), bool firstLineContainsHeader = false)
        {
            this.StorageId = storageId;
            this.Scheme = scheme;
            this.FirstLineContainsHeader = firstLineContainsHeader;
        }

        /// <summary>
        /// Storage Identifier. Get via [List Storages](#operation/api.storages.getMany)  Supported file formats: TBX, CSV, XLS/XLSX
        /// </summary>
        /// <value>Storage Identifier. Get via [List Storages](#operation/api.storages.getMany)  Supported file formats: TBX, CSV, XLS/XLSX</value>
        [DataMember(Name = "storageId", IsRequired = true, EmitDefaultValue = false)]
        public int StorageId { get; set; }

        /// <summary>
        /// Defines data columns mapping. Acceptable value is combination of following constants:   *    &#x60;term_{%language_code%}&#x60; – column with terms  *    &#x60;description_{%language_code%}&#x60; – column with terms description  *    &#x60;partOfSpeech_{%language_code%}&#x60; – column with terms part of speech  &lt;br&gt;where &#x60;%language_code%&#x60; – placeholder for your language code  __Note:__ Used for upload of CSV or XLS/XLSX files only
        /// </summary>
        /// <value>Defines data columns mapping. Acceptable value is combination of following constants:   *    &#x60;term_{%language_code%}&#x60; – column with terms  *    &#x60;description_{%language_code%}&#x60; – column with terms description  *    &#x60;partOfSpeech_{%language_code%}&#x60; – column with terms part of speech  &lt;br&gt;where &#x60;%language_code%&#x60; – placeholder for your language code  __Note:__ Used for upload of CSV or XLS/XLSX files only</value>
        [DataMember(Name = "scheme", EmitDefaultValue = false)]
        public Object Scheme { get; set; }

        /// <summary>
        /// Defines whether file includes first row header that should not be imported  __Note:__  Used for upload of CSV or XLS/XLSX files only
        /// </summary>
        /// <value>Defines whether file includes first row header that should not be imported  __Note:__  Used for upload of CSV or XLS/XLSX files only</value>
        [DataMember(Name = "firstLineContainsHeader", EmitDefaultValue = true)]
        public bool FirstLineContainsHeader { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GlossaryImportForm {\n");
            sb.Append("  StorageId: ").Append(StorageId).Append("\n");
            sb.Append("  Scheme: ").Append(Scheme).Append("\n");
            sb.Append("  FirstLineContainsHeader: ").Append(FirstLineContainsHeader).Append("\n");
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
            return this.Equals(input as GlossaryImportForm);
        }

        /// <summary>
        /// Returns true if GlossaryImportForm instances are equal
        /// </summary>
        /// <param name="input">Instance of GlossaryImportForm to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GlossaryImportForm input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.StorageId == input.StorageId ||
                    this.StorageId.Equals(input.StorageId)
                ) && 
                (
                    this.Scheme == input.Scheme ||
                    (this.Scheme != null &&
                    this.Scheme.Equals(input.Scheme))
                ) && 
                (
                    this.FirstLineContainsHeader == input.FirstLineContainsHeader ||
                    this.FirstLineContainsHeader.Equals(input.FirstLineContainsHeader)
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
                hashCode = hashCode * 59 + this.StorageId.GetHashCode();
                if (this.Scheme != null)
                    hashCode = hashCode * 59 + this.Scheme.GetHashCode();
                hashCode = hashCode * 59 + this.FirstLineContainsHeader.GetHashCode();
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
