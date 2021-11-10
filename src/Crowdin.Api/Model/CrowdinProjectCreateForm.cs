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
    /// CrowdinProjectCreateForm
    /// </summary>
    [DataContract(Name = "CrowdinProjectCreateForm")]
    public partial class CrowdinProjectCreateForm : IEquatable<CrowdinProjectCreateForm>, IValidatableObject
    {
        /// <summary>
        /// Defines the project type. Available values:  *      0 – file-based  *      1 – string-based
        /// </summary>
        /// <value>Defines the project type. Available values:  *      0 – file-based  *      1 – string-based</value>
        public enum TypeEnum
        {
            /// <summary>
            /// Enum NUMBER_0 for value: 0
            /// </summary>
            NUMBER_0 = 0,

            /// <summary>
            /// Enum NUMBER_1 for value: 1
            /// </summary>
            NUMBER_1 = 1

        }


        /// <summary>
        /// Defines the project type. Available values:  *      0 – file-based  *      1 – string-based
        /// </summary>
        /// <value>Defines the project type. Available values:  *      0 – file-based  *      1 – string-based</value>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public TypeEnum? Type { get; set; }
        /// <summary>
        /// Defines how users can join the project. Available values:  *      open – anyone can join the project  *      private – only invited users can join the project
        /// </summary>
        /// <value>Defines how users can join the project. Available values:  *      open – anyone can join the project  *      private – only invited users can join the project</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum VisibilityEnum
        {
            /// <summary>
            /// Enum Open for value: open
            /// </summary>
            [EnumMember(Value = "open")]
            Open = 1,

            /// <summary>
            /// Enum Private for value: private
            /// </summary>
            [EnumMember(Value = "private")]
            Private = 2

        }


        /// <summary>
        /// Defines how users can join the project. Available values:  *      open – anyone can join the project  *      private – only invited users can join the project
        /// </summary>
        /// <value>Defines how users can join the project. Available values:  *      open – anyone can join the project  *      private – only invited users can join the project</value>
        [DataMember(Name = "visibility", EmitDefaultValue = false)]
        public VisibilityEnum? Visibility { get; set; }
        /// <summary>
        /// Defines access to project languages. Available values:  *      open – each project user can access all project languages  *      moderate – users should join each project language separately
        /// </summary>
        /// <value>Defines access to project languages. Available values:  *      open – each project user can access all project languages  *      moderate – users should join each project language separately</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum LanguageAccessPolicyEnum
        {
            /// <summary>
            /// Enum Open for value: open
            /// </summary>
            [EnumMember(Value = "open")]
            Open = 1,

            /// <summary>
            /// Enum Moderate for value: moderate
            /// </summary>
            [EnumMember(Value = "moderate")]
            Moderate = 2

        }


        /// <summary>
        /// Defines access to project languages. Available values:  *      open – each project user can access all project languages  *      moderate – users should join each project language separately
        /// </summary>
        /// <value>Defines access to project languages. Available values:  *      open – each project user can access all project languages  *      moderate – users should join each project language separately</value>
        [DataMember(Name = "languageAccessPolicy", EmitDefaultValue = false)]
        public LanguageAccessPolicyEnum? LanguageAccessPolicy { get; set; }
        /// <summary>
        /// Values available:  *             0 - Show – translators will translate each instance separately,  *             1 - Hide (regular detection) – all duplicates will share the same translation  *             2 - Show, but auto-translate them,  *             3 - Show within a version branch (regular detection) - duplicates will be hidden only between versions branches  *             4 - Hide (strict detection) – all duplicates will share the same translation  *             5 - Show within a version branch (strict detection) - duplicates will be hidden only between versions branches
        /// </summary>
        /// <value>Values available:  *             0 - Show – translators will translate each instance separately,  *             1 - Hide (regular detection) – all duplicates will share the same translation  *             2 - Show, but auto-translate them,  *             3 - Show within a version branch (regular detection) - duplicates will be hidden only between versions branches  *             4 - Hide (strict detection) – all duplicates will share the same translation  *             5 - Show within a version branch (strict detection) - duplicates will be hidden only between versions branches</value>
        public enum TranslateDuplicatesEnum
        {
            /// <summary>
            /// Enum NUMBER_0 for value: 0
            /// </summary>
            NUMBER_0 = 0,

            /// <summary>
            /// Enum NUMBER_1 for value: 1
            /// </summary>
            NUMBER_1 = 1,

            /// <summary>
            /// Enum NUMBER_2 for value: 2
            /// </summary>
            NUMBER_2 = 2,

            /// <summary>
            /// Enum NUMBER_3 for value: 3
            /// </summary>
            NUMBER_3 = 3,

            /// <summary>
            /// Enum NUMBER_4 for value: 4
            /// </summary>
            NUMBER_4 = 4,

            /// <summary>
            /// Enum NUMBER_5 for value: 5
            /// </summary>
            NUMBER_5 = 5

        }


        /// <summary>
        /// Values available:  *             0 - Show – translators will translate each instance separately,  *             1 - Hide (regular detection) – all duplicates will share the same translation  *             2 - Show, but auto-translate them,  *             3 - Show within a version branch (regular detection) - duplicates will be hidden only between versions branches  *             4 - Hide (strict detection) – all duplicates will share the same translation  *             5 - Show within a version branch (strict detection) - duplicates will be hidden only between versions branches
        /// </summary>
        /// <value>Values available:  *             0 - Show – translators will translate each instance separately,  *             1 - Hide (regular detection) – all duplicates will share the same translation  *             2 - Show, but auto-translate them,  *             3 - Show within a version branch (regular detection) - duplicates will be hidden only between versions branches  *             4 - Hide (strict detection) – all duplicates will share the same translation  *             5 - Show within a version branch (strict detection) - duplicates will be hidden only between versions branches</value>
        [DataMember(Name = "translateDuplicates", EmitDefaultValue = false)]
        public TranslateDuplicatesEnum? TranslateDuplicates { get; set; }
        /// <summary>
        /// Values available:  *             0 - Auto,  *             1 - Count tags,  *             1 - Skip tags
        /// </summary>
        /// <value>Values available:  *             0 - Auto,  *             1 - Count tags,  *             1 - Skip tags</value>
        public enum TagsDetectionEnum
        {
            /// <summary>
            /// Enum NUMBER_0 for value: 0
            /// </summary>
            NUMBER_0 = 0,

            /// <summary>
            /// Enum NUMBER_1 for value: 1
            /// </summary>
            NUMBER_1 = 1,

            /// <summary>
            /// Enum NUMBER_2 for value: 2
            /// </summary>
            NUMBER_2 = 2

        }


        /// <summary>
        /// Values available:  *             0 - Auto,  *             1 - Count tags,  *             1 - Skip tags
        /// </summary>
        /// <value>Values available:  *             0 - Auto,  *             1 - Count tags,  *             1 - Skip tags</value>
        [DataMember(Name = "tagsDetection", EmitDefaultValue = false)]
        public TagsDetectionEnum? TagsDetection { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CrowdinProjectCreateForm" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CrowdinProjectCreateForm() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CrowdinProjectCreateForm" /> class.
        /// </summary>
        /// <param name="type">Defines the project type. Available values:  *      0 – file-based  *      1 – string-based (default to TypeEnum.NUMBER_0).</param>
        /// <param name="normalizePlaceholder">Enable the transformation of the placeholders to the unified format to improve the work with TM suggestions.</param>
        /// <param name="saveMetaInfoInSource">Context and max.length added in Crowdin will be visible in the downloaded files.</param>
        /// <param name="notificationSettings">Notification Settings.</param>
        /// <param name="name">Project Name (required).</param>
        /// <param name="identifier">Project Identifier.</param>
        /// <param name="sourceLanguageId">Source Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany) (required).</param>
        /// <param name="targetLanguageIds">Target Languages Identifiers. Get via [List Supported Languages](#operation/api.languages.getMany).</param>
        /// <param name="visibility">Defines how users can join the project. Available values:  *      open – anyone can join the project  *      private – only invited users can join the project (default to VisibilityEnum.Private).</param>
        /// <param name="languageAccessPolicy">Defines access to project languages. Available values:  *      open – each project user can access all project languages  *      moderate – users should join each project language separately (default to LanguageAccessPolicyEnum.Open).</param>
        /// <param name="cname">Custom domain name.</param>
        /// <param name="description">Project description.</param>
        /// <param name="translateDuplicates">Values available:  *             0 - Show – translators will translate each instance separately,  *             1 - Hide (regular detection) – all duplicates will share the same translation  *             2 - Show, but auto-translate them,  *             3 - Show within a version branch (regular detection) - duplicates will be hidden only between versions branches  *             4 - Hide (strict detection) – all duplicates will share the same translation  *             5 - Show within a version branch (strict detection) - duplicates will be hidden only between versions branches (default to TranslateDuplicatesEnum.NUMBER_0).</param>
        /// <param name="tagsDetection">Values available:  *             0 - Auto,  *             1 - Count tags,  *             1 - Skip tags (default to TagsDetectionEnum.NUMBER_0).</param>
        /// <param name="isMtAllowed">Allows machine translations (Microsoft Translator, Google Translate) be visible for translators in the Editor. (default to true).</param>
        /// <param name="autoSubstitution">Allows auto-substitution (default to true).</param>
        /// <param name="autoTranslateDialects">Automatically fill in regional dialects.  If &#x60;true&#x60;, all untranslated strings in regional dialects (e.g. Argentine Spanish) will automatically include translations completed in the primary language (e.g. Spanish). (default to false).</param>
        /// <param name="publicDownloads">Allows translators to download source files to their machines and upload translations back into the project. Project owner and managers can always download sources and upload translations. (default to true).</param>
        /// <param name="hiddenStringsProofreadersAccess">Allows proofreaders to work with hidden strings. Project owner and managers can always access hidden strings (default to true).</param>
        /// <param name="useGlobalTm">If &#x60;true&#x60; - machine translations from connected MT engines (e.g. Microsoft Translator, Google Translate) will appear as suggestions in the Editor.  __Note:__ If your organization plan is free or opensource - default value of this one will be &#x60;true&#x60; (default to false).</param>
        /// <param name="skipUntranslatedStrings">Defines whether to skip untranslated strings.</param>
        /// <param name="skipUntranslatedFiles">Defines whether to export only translated file.</param>
        /// <param name="exportApprovedOnly">Defines whether to export only approved strings.</param>
        /// <param name="inContext">Enable In-Context translations.  __Note:__ Must be used together with &#x60;inContextPseudoLanguageId&#x60; (default to false).</param>
        /// <param name="inContextProcessHiddenStrings">Export hidden strings via pseudo-language.  __Note:__ If &#x60;true&#x60; - hidden strings included in the pseudo-language archive will be translatable via In-Context. (default to true).</param>
        /// <param name="inContextPseudoLanguageId">In-Context pseudo-language id.  __Note:__ Must be different from project source and target languages.</param>
        /// <param name="qaCheckIsActive">If &#x60;true&#x60; - QA checks are active (default to true).</param>
        /// <param name="qaCheckCategories">qaCheckCategories.</param>
        /// <param name="languageMapping">languageMapping.</param>
        /// <param name="glossaryAccess">Allow project members to manage glossary terms. The project owner and managers always can add and edit terms. (default to false).</param>
        public CrowdinProjectCreateForm(TypeEnum? type = TypeEnum.NUMBER_0, bool normalizePlaceholder = default(bool), bool saveMetaInfoInSource = default(bool), Object notificationSettings = default(Object), string name = default(string), string identifier = default(string), string sourceLanguageId = default(string), List<string> targetLanguageIds = default(List<string>), VisibilityEnum? visibility = VisibilityEnum.Private, LanguageAccessPolicyEnum? languageAccessPolicy = LanguageAccessPolicyEnum.Open, string cname = default(string), string description = default(string), TranslateDuplicatesEnum? translateDuplicates = TranslateDuplicatesEnum.NUMBER_0, TagsDetectionEnum? tagsDetection = TagsDetectionEnum.NUMBER_0, bool isMtAllowed = true, bool autoSubstitution = true, bool autoTranslateDialects = false, bool publicDownloads = true, bool hiddenStringsProofreadersAccess = true, bool useGlobalTm = false, bool skipUntranslatedStrings = default(bool), bool skipUntranslatedFiles = default(bool), bool exportApprovedOnly = default(bool), bool inContext = false, bool inContextProcessHiddenStrings = true, string inContextPseudoLanguageId = default(string), bool qaCheckIsActive = true, QaCheckCategories qaCheckCategories = default(QaCheckCategories), CrowdinStringsBasedProjectCreateFormLanguageMapping languageMapping = default(CrowdinStringsBasedProjectCreateFormLanguageMapping), bool glossaryAccess = false)
        {
            // to ensure "name" is required (not null)
            if (name == null) {
                throw new ArgumentNullException("name is a required property for CrowdinProjectCreateForm and cannot be null");
            }
            this.Name = name;
            // to ensure "sourceLanguageId" is required (not null)
            if (sourceLanguageId == null) {
                throw new ArgumentNullException("sourceLanguageId is a required property for CrowdinProjectCreateForm and cannot be null");
            }
            this.SourceLanguageId = sourceLanguageId;
            this.Type = type;
            this.NormalizePlaceholder = normalizePlaceholder;
            this.SaveMetaInfoInSource = saveMetaInfoInSource;
            this.NotificationSettings = notificationSettings;
            this.Identifier = identifier;
            this.TargetLanguageIds = targetLanguageIds;
            this.Visibility = visibility;
            this.LanguageAccessPolicy = languageAccessPolicy;
            this.Cname = cname;
            this.Description = description;
            this.TranslateDuplicates = translateDuplicates;
            this.TagsDetection = tagsDetection;
            this.IsMtAllowed = isMtAllowed;
            this.AutoSubstitution = autoSubstitution;
            this.AutoTranslateDialects = autoTranslateDialects;
            this.PublicDownloads = publicDownloads;
            this.HiddenStringsProofreadersAccess = hiddenStringsProofreadersAccess;
            this.UseGlobalTm = useGlobalTm;
            this.SkipUntranslatedStrings = skipUntranslatedStrings;
            this.SkipUntranslatedFiles = skipUntranslatedFiles;
            this.ExportApprovedOnly = exportApprovedOnly;
            this.InContext = inContext;
            this.InContextProcessHiddenStrings = inContextProcessHiddenStrings;
            this.InContextPseudoLanguageId = inContextPseudoLanguageId;
            this.QaCheckIsActive = qaCheckIsActive;
            this.QaCheckCategories = qaCheckCategories;
            this.LanguageMapping = languageMapping;
            this.GlossaryAccess = glossaryAccess;
        }

        /// <summary>
        /// Enable the transformation of the placeholders to the unified format to improve the work with TM suggestions
        /// </summary>
        /// <value>Enable the transformation of the placeholders to the unified format to improve the work with TM suggestions</value>
        [DataMember(Name = "normalizePlaceholder", EmitDefaultValue = true)]
        public bool NormalizePlaceholder { get; set; }

        /// <summary>
        /// Context and max.length added in Crowdin will be visible in the downloaded files
        /// </summary>
        /// <value>Context and max.length added in Crowdin will be visible in the downloaded files</value>
        [DataMember(Name = "saveMetaInfoInSource", EmitDefaultValue = true)]
        public bool SaveMetaInfoInSource { get; set; }

        /// <summary>
        /// Notification Settings
        /// </summary>
        /// <value>Notification Settings</value>
        [DataMember(Name = "notificationSettings", EmitDefaultValue = false)]
        public Object NotificationSettings { get; set; }

        /// <summary>
        /// Project Name
        /// </summary>
        /// <value>Project Name</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Project Identifier
        /// </summary>
        /// <value>Project Identifier</value>
        [DataMember(Name = "identifier", EmitDefaultValue = false)]
        public string Identifier { get; set; }

        /// <summary>
        /// Source Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany)
        /// </summary>
        /// <value>Source Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany)</value>
        [DataMember(Name = "sourceLanguageId", IsRequired = true, EmitDefaultValue = false)]
        public string SourceLanguageId { get; set; }

        /// <summary>
        /// Target Languages Identifiers. Get via [List Supported Languages](#operation/api.languages.getMany)
        /// </summary>
        /// <value>Target Languages Identifiers. Get via [List Supported Languages](#operation/api.languages.getMany)</value>
        [DataMember(Name = "targetLanguageIds", EmitDefaultValue = false)]
        public List<string> TargetLanguageIds { get; set; }

        /// <summary>
        /// Custom domain name
        /// </summary>
        /// <value>Custom domain name</value>
        [DataMember(Name = "cname", EmitDefaultValue = false)]
        public string Cname { get; set; }

        /// <summary>
        /// Project description
        /// </summary>
        /// <value>Project description</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Allows machine translations (Microsoft Translator, Google Translate) be visible for translators in the Editor.
        /// </summary>
        /// <value>Allows machine translations (Microsoft Translator, Google Translate) be visible for translators in the Editor.</value>
        [DataMember(Name = "isMtAllowed", EmitDefaultValue = true)]
        public bool IsMtAllowed { get; set; }

        /// <summary>
        /// Allows auto-substitution
        /// </summary>
        /// <value>Allows auto-substitution</value>
        [DataMember(Name = "autoSubstitution", EmitDefaultValue = true)]
        public bool AutoSubstitution { get; set; }

        /// <summary>
        /// Automatically fill in regional dialects.  If &#x60;true&#x60;, all untranslated strings in regional dialects (e.g. Argentine Spanish) will automatically include translations completed in the primary language (e.g. Spanish).
        /// </summary>
        /// <value>Automatically fill in regional dialects.  If &#x60;true&#x60;, all untranslated strings in regional dialects (e.g. Argentine Spanish) will automatically include translations completed in the primary language (e.g. Spanish).</value>
        [DataMember(Name = "autoTranslateDialects", EmitDefaultValue = true)]
        public bool AutoTranslateDialects { get; set; }

        /// <summary>
        /// Allows translators to download source files to their machines and upload translations back into the project. Project owner and managers can always download sources and upload translations.
        /// </summary>
        /// <value>Allows translators to download source files to their machines and upload translations back into the project. Project owner and managers can always download sources and upload translations.</value>
        [DataMember(Name = "publicDownloads", EmitDefaultValue = true)]
        public bool PublicDownloads { get; set; }

        /// <summary>
        /// Allows proofreaders to work with hidden strings. Project owner and managers can always access hidden strings
        /// </summary>
        /// <value>Allows proofreaders to work with hidden strings. Project owner and managers can always access hidden strings</value>
        [DataMember(Name = "hiddenStringsProofreadersAccess", EmitDefaultValue = true)]
        public bool HiddenStringsProofreadersAccess { get; set; }

        /// <summary>
        /// If &#x60;true&#x60; - machine translations from connected MT engines (e.g. Microsoft Translator, Google Translate) will appear as suggestions in the Editor.  __Note:__ If your organization plan is free or opensource - default value of this one will be &#x60;true&#x60;
        /// </summary>
        /// <value>If &#x60;true&#x60; - machine translations from connected MT engines (e.g. Microsoft Translator, Google Translate) will appear as suggestions in the Editor.  __Note:__ If your organization plan is free or opensource - default value of this one will be &#x60;true&#x60;</value>
        [DataMember(Name = "useGlobalTm", EmitDefaultValue = true)]
        public bool UseGlobalTm { get; set; }

        /// <summary>
        /// Defines whether to skip untranslated strings
        /// </summary>
        /// <value>Defines whether to skip untranslated strings</value>
        [DataMember(Name = "skipUntranslatedStrings", EmitDefaultValue = true)]
        public bool SkipUntranslatedStrings { get; set; }

        /// <summary>
        /// Defines whether to export only translated file
        /// </summary>
        /// <value>Defines whether to export only translated file</value>
        [DataMember(Name = "skipUntranslatedFiles", EmitDefaultValue = true)]
        public bool SkipUntranslatedFiles { get; set; }

        /// <summary>
        /// Defines whether to export only approved strings
        /// </summary>
        /// <value>Defines whether to export only approved strings</value>
        [DataMember(Name = "exportApprovedOnly", EmitDefaultValue = true)]
        public bool ExportApprovedOnly { get; set; }

        /// <summary>
        /// Enable In-Context translations.  __Note:__ Must be used together with &#x60;inContextPseudoLanguageId&#x60;
        /// </summary>
        /// <value>Enable In-Context translations.  __Note:__ Must be used together with &#x60;inContextPseudoLanguageId&#x60;</value>
        [DataMember(Name = "inContext", EmitDefaultValue = true)]
        public bool InContext { get; set; }

        /// <summary>
        /// Export hidden strings via pseudo-language.  __Note:__ If &#x60;true&#x60; - hidden strings included in the pseudo-language archive will be translatable via In-Context.
        /// </summary>
        /// <value>Export hidden strings via pseudo-language.  __Note:__ If &#x60;true&#x60; - hidden strings included in the pseudo-language archive will be translatable via In-Context.</value>
        [DataMember(Name = "inContextProcessHiddenStrings", EmitDefaultValue = true)]
        public bool InContextProcessHiddenStrings { get; set; }

        /// <summary>
        /// In-Context pseudo-language id.  __Note:__ Must be different from project source and target languages
        /// </summary>
        /// <value>In-Context pseudo-language id.  __Note:__ Must be different from project source and target languages</value>
        [DataMember(Name = "inContextPseudoLanguageId", EmitDefaultValue = false)]
        public string InContextPseudoLanguageId { get; set; }

        /// <summary>
        /// If &#x60;true&#x60; - QA checks are active
        /// </summary>
        /// <value>If &#x60;true&#x60; - QA checks are active</value>
        [DataMember(Name = "qaCheckIsActive", EmitDefaultValue = true)]
        public bool QaCheckIsActive { get; set; }

        /// <summary>
        /// Gets or Sets QaCheckCategories
        /// </summary>
        [DataMember(Name = "qaCheckCategories", EmitDefaultValue = false)]
        public QaCheckCategories QaCheckCategories { get; set; }

        /// <summary>
        /// Gets or Sets LanguageMapping
        /// </summary>
        [DataMember(Name = "languageMapping", EmitDefaultValue = false)]
        public CrowdinStringsBasedProjectCreateFormLanguageMapping LanguageMapping { get; set; }

        /// <summary>
        /// Allow project members to manage glossary terms. The project owner and managers always can add and edit terms.
        /// </summary>
        /// <value>Allow project members to manage glossary terms. The project owner and managers always can add and edit terms.</value>
        [DataMember(Name = "glossaryAccess", EmitDefaultValue = true)]
        public bool GlossaryAccess { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CrowdinProjectCreateForm {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  NormalizePlaceholder: ").Append(NormalizePlaceholder).Append("\n");
            sb.Append("  SaveMetaInfoInSource: ").Append(SaveMetaInfoInSource).Append("\n");
            sb.Append("  NotificationSettings: ").Append(NotificationSettings).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Identifier: ").Append(Identifier).Append("\n");
            sb.Append("  SourceLanguageId: ").Append(SourceLanguageId).Append("\n");
            sb.Append("  TargetLanguageIds: ").Append(TargetLanguageIds).Append("\n");
            sb.Append("  Visibility: ").Append(Visibility).Append("\n");
            sb.Append("  LanguageAccessPolicy: ").Append(LanguageAccessPolicy).Append("\n");
            sb.Append("  Cname: ").Append(Cname).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  TranslateDuplicates: ").Append(TranslateDuplicates).Append("\n");
            sb.Append("  TagsDetection: ").Append(TagsDetection).Append("\n");
            sb.Append("  IsMtAllowed: ").Append(IsMtAllowed).Append("\n");
            sb.Append("  AutoSubstitution: ").Append(AutoSubstitution).Append("\n");
            sb.Append("  AutoTranslateDialects: ").Append(AutoTranslateDialects).Append("\n");
            sb.Append("  PublicDownloads: ").Append(PublicDownloads).Append("\n");
            sb.Append("  HiddenStringsProofreadersAccess: ").Append(HiddenStringsProofreadersAccess).Append("\n");
            sb.Append("  UseGlobalTm: ").Append(UseGlobalTm).Append("\n");
            sb.Append("  SkipUntranslatedStrings: ").Append(SkipUntranslatedStrings).Append("\n");
            sb.Append("  SkipUntranslatedFiles: ").Append(SkipUntranslatedFiles).Append("\n");
            sb.Append("  ExportApprovedOnly: ").Append(ExportApprovedOnly).Append("\n");
            sb.Append("  InContext: ").Append(InContext).Append("\n");
            sb.Append("  InContextProcessHiddenStrings: ").Append(InContextProcessHiddenStrings).Append("\n");
            sb.Append("  InContextPseudoLanguageId: ").Append(InContextPseudoLanguageId).Append("\n");
            sb.Append("  QaCheckIsActive: ").Append(QaCheckIsActive).Append("\n");
            sb.Append("  QaCheckCategories: ").Append(QaCheckCategories).Append("\n");
            sb.Append("  LanguageMapping: ").Append(LanguageMapping).Append("\n");
            sb.Append("  GlossaryAccess: ").Append(GlossaryAccess).Append("\n");
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
            return this.Equals(input as CrowdinProjectCreateForm);
        }

        /// <summary>
        /// Returns true if CrowdinProjectCreateForm instances are equal
        /// </summary>
        /// <param name="input">Instance of CrowdinProjectCreateForm to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CrowdinProjectCreateForm input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Type == input.Type ||
                    this.Type.Equals(input.Type)
                ) && 
                (
                    this.NormalizePlaceholder == input.NormalizePlaceholder ||
                    this.NormalizePlaceholder.Equals(input.NormalizePlaceholder)
                ) && 
                (
                    this.SaveMetaInfoInSource == input.SaveMetaInfoInSource ||
                    this.SaveMetaInfoInSource.Equals(input.SaveMetaInfoInSource)
                ) && 
                (
                    this.NotificationSettings == input.NotificationSettings ||
                    (this.NotificationSettings != null &&
                    this.NotificationSettings.Equals(input.NotificationSettings))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Identifier == input.Identifier ||
                    (this.Identifier != null &&
                    this.Identifier.Equals(input.Identifier))
                ) && 
                (
                    this.SourceLanguageId == input.SourceLanguageId ||
                    (this.SourceLanguageId != null &&
                    this.SourceLanguageId.Equals(input.SourceLanguageId))
                ) && 
                (
                    this.TargetLanguageIds == input.TargetLanguageIds ||
                    this.TargetLanguageIds != null &&
                    input.TargetLanguageIds != null &&
                    this.TargetLanguageIds.SequenceEqual(input.TargetLanguageIds)
                ) && 
                (
                    this.Visibility == input.Visibility ||
                    this.Visibility.Equals(input.Visibility)
                ) && 
                (
                    this.LanguageAccessPolicy == input.LanguageAccessPolicy ||
                    this.LanguageAccessPolicy.Equals(input.LanguageAccessPolicy)
                ) && 
                (
                    this.Cname == input.Cname ||
                    (this.Cname != null &&
                    this.Cname.Equals(input.Cname))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.TranslateDuplicates == input.TranslateDuplicates ||
                    this.TranslateDuplicates.Equals(input.TranslateDuplicates)
                ) && 
                (
                    this.TagsDetection == input.TagsDetection ||
                    this.TagsDetection.Equals(input.TagsDetection)
                ) && 
                (
                    this.IsMtAllowed == input.IsMtAllowed ||
                    this.IsMtAllowed.Equals(input.IsMtAllowed)
                ) && 
                (
                    this.AutoSubstitution == input.AutoSubstitution ||
                    this.AutoSubstitution.Equals(input.AutoSubstitution)
                ) && 
                (
                    this.AutoTranslateDialects == input.AutoTranslateDialects ||
                    this.AutoTranslateDialects.Equals(input.AutoTranslateDialects)
                ) && 
                (
                    this.PublicDownloads == input.PublicDownloads ||
                    this.PublicDownloads.Equals(input.PublicDownloads)
                ) && 
                (
                    this.HiddenStringsProofreadersAccess == input.HiddenStringsProofreadersAccess ||
                    this.HiddenStringsProofreadersAccess.Equals(input.HiddenStringsProofreadersAccess)
                ) && 
                (
                    this.UseGlobalTm == input.UseGlobalTm ||
                    this.UseGlobalTm.Equals(input.UseGlobalTm)
                ) && 
                (
                    this.SkipUntranslatedStrings == input.SkipUntranslatedStrings ||
                    this.SkipUntranslatedStrings.Equals(input.SkipUntranslatedStrings)
                ) && 
                (
                    this.SkipUntranslatedFiles == input.SkipUntranslatedFiles ||
                    this.SkipUntranslatedFiles.Equals(input.SkipUntranslatedFiles)
                ) && 
                (
                    this.ExportApprovedOnly == input.ExportApprovedOnly ||
                    this.ExportApprovedOnly.Equals(input.ExportApprovedOnly)
                ) && 
                (
                    this.InContext == input.InContext ||
                    this.InContext.Equals(input.InContext)
                ) && 
                (
                    this.InContextProcessHiddenStrings == input.InContextProcessHiddenStrings ||
                    this.InContextProcessHiddenStrings.Equals(input.InContextProcessHiddenStrings)
                ) && 
                (
                    this.InContextPseudoLanguageId == input.InContextPseudoLanguageId ||
                    (this.InContextPseudoLanguageId != null &&
                    this.InContextPseudoLanguageId.Equals(input.InContextPseudoLanguageId))
                ) && 
                (
                    this.QaCheckIsActive == input.QaCheckIsActive ||
                    this.QaCheckIsActive.Equals(input.QaCheckIsActive)
                ) && 
                (
                    this.QaCheckCategories == input.QaCheckCategories ||
                    (this.QaCheckCategories != null &&
                    this.QaCheckCategories.Equals(input.QaCheckCategories))
                ) && 
                (
                    this.LanguageMapping == input.LanguageMapping ||
                    (this.LanguageMapping != null &&
                    this.LanguageMapping.Equals(input.LanguageMapping))
                ) && 
                (
                    this.GlossaryAccess == input.GlossaryAccess ||
                    this.GlossaryAccess.Equals(input.GlossaryAccess)
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
                hashCode = hashCode * 59 + this.Type.GetHashCode();
                hashCode = hashCode * 59 + this.NormalizePlaceholder.GetHashCode();
                hashCode = hashCode * 59 + this.SaveMetaInfoInSource.GetHashCode();
                if (this.NotificationSettings != null)
                    hashCode = hashCode * 59 + this.NotificationSettings.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Identifier != null)
                    hashCode = hashCode * 59 + this.Identifier.GetHashCode();
                if (this.SourceLanguageId != null)
                    hashCode = hashCode * 59 + this.SourceLanguageId.GetHashCode();
                if (this.TargetLanguageIds != null)
                    hashCode = hashCode * 59 + this.TargetLanguageIds.GetHashCode();
                hashCode = hashCode * 59 + this.Visibility.GetHashCode();
                hashCode = hashCode * 59 + this.LanguageAccessPolicy.GetHashCode();
                if (this.Cname != null)
                    hashCode = hashCode * 59 + this.Cname.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                hashCode = hashCode * 59 + this.TranslateDuplicates.GetHashCode();
                hashCode = hashCode * 59 + this.TagsDetection.GetHashCode();
                hashCode = hashCode * 59 + this.IsMtAllowed.GetHashCode();
                hashCode = hashCode * 59 + this.AutoSubstitution.GetHashCode();
                hashCode = hashCode * 59 + this.AutoTranslateDialects.GetHashCode();
                hashCode = hashCode * 59 + this.PublicDownloads.GetHashCode();
                hashCode = hashCode * 59 + this.HiddenStringsProofreadersAccess.GetHashCode();
                hashCode = hashCode * 59 + this.UseGlobalTm.GetHashCode();
                hashCode = hashCode * 59 + this.SkipUntranslatedStrings.GetHashCode();
                hashCode = hashCode * 59 + this.SkipUntranslatedFiles.GetHashCode();
                hashCode = hashCode * 59 + this.ExportApprovedOnly.GetHashCode();
                hashCode = hashCode * 59 + this.InContext.GetHashCode();
                hashCode = hashCode * 59 + this.InContextProcessHiddenStrings.GetHashCode();
                if (this.InContextPseudoLanguageId != null)
                    hashCode = hashCode * 59 + this.InContextPseudoLanguageId.GetHashCode();
                hashCode = hashCode * 59 + this.QaCheckIsActive.GetHashCode();
                if (this.QaCheckCategories != null)
                    hashCode = hashCode * 59 + this.QaCheckCategories.GetHashCode();
                if (this.LanguageMapping != null)
                    hashCode = hashCode * 59 + this.LanguageMapping.GetHashCode();
                hashCode = hashCode * 59 + this.GlossaryAccess.GetHashCode();
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
