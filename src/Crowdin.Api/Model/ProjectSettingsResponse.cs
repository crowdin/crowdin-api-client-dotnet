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
    /// ProjectSettingsResponse
    /// </summary>
    [DataContract(Name = "ProjectSettingsResponse")]
    public partial class ProjectSettingsResponse : IEquatable<ProjectSettingsResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectSettingsResponse" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="userId">userId.</param>
        /// <param name="sourceLanguageId">sourceLanguageId.</param>
        /// <param name="targetLanguageIds">targetLanguageIds.</param>
        /// <param name="languageAccessPolicy">languageAccessPolicy.</param>
        /// <param name="name">name.</param>
        /// <param name="cname">cname.</param>
        /// <param name="identifier">identifier.</param>
        /// <param name="description">description.</param>
        /// <param name="visibility">visibility.</param>
        /// <param name="logo">logo.</param>
        /// <param name="publicDownloads">publicDownloads.</param>
        /// <param name="createdAt">createdAt.</param>
        /// <param name="updatedAt">updatedAt.</param>
        /// <param name="lastActivity">lastActivity.</param>
        /// <param name="targetLanguages">targetLanguages.</param>
        /// <param name="translateDuplicates">translateDuplicates.</param>
        /// <param name="tagsDetection">tagsDetection.</param>
        /// <param name="glossaryAccess">glossaryAccess (default to false).</param>
        /// <param name="isMtAllowed">isMtAllowed.</param>
        /// <param name="hiddenStringsProofreadersAccess">hiddenStringsProofreadersAccess (default to true).</param>
        /// <param name="autoSubstitution">autoSubstitution.</param>
        /// <param name="exportTranslatedOnly">exportTranslatedOnly.</param>
        /// <param name="skipUntranslatedStrings">skipUntranslatedStrings.</param>
        /// <param name="skipUntranslatedFiles">skipUntranslatedFiles.</param>
        /// <param name="exportApprovedOnly">exportApprovedOnly.</param>
        /// <param name="autoTranslateDialects">autoTranslateDialects.</param>
        /// <param name="useGlobalTm">useGlobalTm.</param>
        /// <param name="normalizePlaceholder">normalizePlaceholder.</param>
        /// <param name="saveMetaInfoInSource">saveMetaInfoInSource.</param>
        /// <param name="inContext">inContext.</param>
        /// <param name="inContextProcessHiddenStrings">inContextProcessHiddenStrings.</param>
        /// <param name="inContextPseudoLanguageId">inContextPseudoLanguageId.</param>
        /// <param name="inContextPseudoLanguage">inContextPseudoLanguage.</param>
        /// <param name="isSuspended">isSuspended.</param>
        /// <param name="qaCheckIsActive">qaCheckIsActive.</param>
        /// <param name="qaCheckCategories">qaCheckCategories.</param>
        /// <param name="languageMapping">languageMapping.</param>
        /// <param name="notificationSettings">notificationSettings.</param>
        public ProjectSettingsResponse(int id = default(int), int userId = default(int), string sourceLanguageId = default(string), List<string> targetLanguageIds = default(List<string>), string languageAccessPolicy = default(string), string name = default(string), string cname = default(string), string identifier = default(string), string description = default(string), string visibility = default(string), string logo = default(string), bool publicDownloads = default(bool), DateTime createdAt = default(DateTime), DateTime updatedAt = default(DateTime), DateTime lastActivity = default(DateTime), List<Language> targetLanguages = default(List<Language>), int translateDuplicates = default(int), int tagsDetection = default(int), bool glossaryAccess = false, bool isMtAllowed = default(bool), bool hiddenStringsProofreadersAccess = true, bool autoSubstitution = default(bool), bool exportTranslatedOnly = default(bool), bool skipUntranslatedStrings = default(bool), bool skipUntranslatedFiles = default(bool), bool exportApprovedOnly = default(bool), bool autoTranslateDialects = default(bool), bool useGlobalTm = default(bool), bool normalizePlaceholder = default(bool), bool saveMetaInfoInSource = default(bool), bool inContext = default(bool), bool inContextProcessHiddenStrings = default(bool), string inContextPseudoLanguageId = default(string), LanguageUk inContextPseudoLanguage = default(LanguageUk), bool isSuspended = default(bool), bool qaCheckIsActive = default(bool), QaCheckCategories qaCheckCategories = default(QaCheckCategories), ProjectSettingsResponseAllOfLanguageMapping languageMapping = default(ProjectSettingsResponseAllOfLanguageMapping), ProjectSettingsResponseAllOfNotificationSettings notificationSettings = default(ProjectSettingsResponseAllOfNotificationSettings))
        {
            this.Id = id;
            this.UserId = userId;
            this.SourceLanguageId = sourceLanguageId;
            this.TargetLanguageIds = targetLanguageIds;
            this.LanguageAccessPolicy = languageAccessPolicy;
            this.Name = name;
            this.Cname = cname;
            this.Identifier = identifier;
            this.Description = description;
            this.Visibility = visibility;
            this.Logo = logo;
            this.PublicDownloads = publicDownloads;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.LastActivity = lastActivity;
            this.TargetLanguages = targetLanguages;
            this.TranslateDuplicates = translateDuplicates;
            this.TagsDetection = tagsDetection;
            this.GlossaryAccess = glossaryAccess;
            this.IsMtAllowed = isMtAllowed;
            this.HiddenStringsProofreadersAccess = hiddenStringsProofreadersAccess;
            this.AutoSubstitution = autoSubstitution;
            this.ExportTranslatedOnly = exportTranslatedOnly;
            this.SkipUntranslatedStrings = skipUntranslatedStrings;
            this.SkipUntranslatedFiles = skipUntranslatedFiles;
            this.ExportApprovedOnly = exportApprovedOnly;
            this.AutoTranslateDialects = autoTranslateDialects;
            this.UseGlobalTm = useGlobalTm;
            this.NormalizePlaceholder = normalizePlaceholder;
            this.SaveMetaInfoInSource = saveMetaInfoInSource;
            this.InContext = inContext;
            this.InContextProcessHiddenStrings = inContextProcessHiddenStrings;
            this.InContextPseudoLanguageId = inContextPseudoLanguageId;
            this.InContextPseudoLanguage = inContextPseudoLanguage;
            this.IsSuspended = isSuspended;
            this.QaCheckIsActive = qaCheckIsActive;
            this.QaCheckCategories = qaCheckCategories;
            this.LanguageMapping = languageMapping;
            this.NotificationSettings = notificationSettings;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets UserId
        /// </summary>
        [DataMember(Name = "userId", EmitDefaultValue = false)]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or Sets SourceLanguageId
        /// </summary>
        [DataMember(Name = "sourceLanguageId", EmitDefaultValue = false)]
        public string SourceLanguageId { get; set; }

        /// <summary>
        /// Gets or Sets TargetLanguageIds
        /// </summary>
        [DataMember(Name = "targetLanguageIds", EmitDefaultValue = false)]
        public List<string> TargetLanguageIds { get; set; }

        /// <summary>
        /// Gets or Sets LanguageAccessPolicy
        /// </summary>
        [DataMember(Name = "languageAccessPolicy", EmitDefaultValue = false)]
        public string LanguageAccessPolicy { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Cname
        /// </summary>
        [DataMember(Name = "cname", EmitDefaultValue = true)]
        public string Cname { get; set; }

        /// <summary>
        /// Gets or Sets Identifier
        /// </summary>
        [DataMember(Name = "identifier", EmitDefaultValue = false)]
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Visibility
        /// </summary>
        [DataMember(Name = "visibility", EmitDefaultValue = false)]
        public string Visibility { get; set; }

        /// <summary>
        /// Gets or Sets Logo
        /// </summary>
        [DataMember(Name = "logo", EmitDefaultValue = false)]
        public string Logo { get; set; }

        /// <summary>
        /// Gets or Sets PublicDownloads
        /// </summary>
        [DataMember(Name = "publicDownloads", EmitDefaultValue = true)]
        public bool PublicDownloads { get; set; }

        /// <summary>
        /// Gets or Sets CreatedAt
        /// </summary>
        [DataMember(Name = "createdAt", EmitDefaultValue = false)]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or Sets UpdatedAt
        /// </summary>
        [DataMember(Name = "updatedAt", EmitDefaultValue = false)]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Gets or Sets LastActivity
        /// </summary>
        [DataMember(Name = "lastActivity", EmitDefaultValue = false)]
        public DateTime LastActivity { get; set; }

        /// <summary>
        /// Gets or Sets TargetLanguages
        /// </summary>
        [DataMember(Name = "targetLanguages", EmitDefaultValue = false)]
        public List<Language> TargetLanguages { get; set; }

        /// <summary>
        /// Gets or Sets TranslateDuplicates
        /// </summary>
        [DataMember(Name = "translateDuplicates", EmitDefaultValue = false)]
        public int TranslateDuplicates { get; set; }

        /// <summary>
        /// Gets or Sets TagsDetection
        /// </summary>
        [DataMember(Name = "tagsDetection", EmitDefaultValue = false)]
        public int TagsDetection { get; set; }

        /// <summary>
        /// Gets or Sets GlossaryAccess
        /// </summary>
        [DataMember(Name = "glossaryAccess", EmitDefaultValue = true)]
        public bool GlossaryAccess { get; set; }

        /// <summary>
        /// Gets or Sets IsMtAllowed
        /// </summary>
        [DataMember(Name = "isMtAllowed", EmitDefaultValue = true)]
        public bool IsMtAllowed { get; set; }

        /// <summary>
        /// Gets or Sets HiddenStringsProofreadersAccess
        /// </summary>
        [DataMember(Name = "hiddenStringsProofreadersAccess", EmitDefaultValue = true)]
        public bool HiddenStringsProofreadersAccess { get; set; }

        /// <summary>
        /// Gets or Sets AutoSubstitution
        /// </summary>
        [DataMember(Name = "autoSubstitution", EmitDefaultValue = true)]
        public bool AutoSubstitution { get; set; }

        /// <summary>
        /// Gets or Sets ExportTranslatedOnly
        /// </summary>
        [DataMember(Name = "exportTranslatedOnly", EmitDefaultValue = true)]
        public bool ExportTranslatedOnly { get; set; }

        /// <summary>
        /// Gets or Sets SkipUntranslatedStrings
        /// </summary>
        [DataMember(Name = "skipUntranslatedStrings", EmitDefaultValue = true)]
        public bool SkipUntranslatedStrings { get; set; }

        /// <summary>
        /// Gets or Sets SkipUntranslatedFiles
        /// </summary>
        [DataMember(Name = "skipUntranslatedFiles", EmitDefaultValue = true)]
        public bool SkipUntranslatedFiles { get; set; }

        /// <summary>
        /// Gets or Sets ExportApprovedOnly
        /// </summary>
        [DataMember(Name = "exportApprovedOnly", EmitDefaultValue = true)]
        public bool ExportApprovedOnly { get; set; }

        /// <summary>
        /// Gets or Sets AutoTranslateDialects
        /// </summary>
        [DataMember(Name = "autoTranslateDialects", EmitDefaultValue = true)]
        public bool AutoTranslateDialects { get; set; }

        /// <summary>
        /// Gets or Sets UseGlobalTm
        /// </summary>
        [DataMember(Name = "useGlobalTm", EmitDefaultValue = true)]
        public bool UseGlobalTm { get; set; }

        /// <summary>
        /// Gets or Sets NormalizePlaceholder
        /// </summary>
        [DataMember(Name = "normalizePlaceholder", EmitDefaultValue = true)]
        public bool NormalizePlaceholder { get; set; }

        /// <summary>
        /// Gets or Sets SaveMetaInfoInSource
        /// </summary>
        [DataMember(Name = "saveMetaInfoInSource", EmitDefaultValue = true)]
        public bool SaveMetaInfoInSource { get; set; }

        /// <summary>
        /// Gets or Sets InContext
        /// </summary>
        [DataMember(Name = "inContext", EmitDefaultValue = true)]
        public bool InContext { get; set; }

        /// <summary>
        /// Gets or Sets InContextProcessHiddenStrings
        /// </summary>
        [DataMember(Name = "inContextProcessHiddenStrings", EmitDefaultValue = true)]
        public bool InContextProcessHiddenStrings { get; set; }

        /// <summary>
        /// Gets or Sets InContextPseudoLanguageId
        /// </summary>
        [DataMember(Name = "inContextPseudoLanguageId", EmitDefaultValue = true)]
        public string InContextPseudoLanguageId { get; set; }

        /// <summary>
        /// Gets or Sets InContextPseudoLanguage
        /// </summary>
        [DataMember(Name = "inContextPseudoLanguage", EmitDefaultValue = false)]
        public LanguageUk InContextPseudoLanguage { get; set; }

        /// <summary>
        /// Gets or Sets IsSuspended
        /// </summary>
        [DataMember(Name = "isSuspended", EmitDefaultValue = true)]
        public bool IsSuspended { get; set; }

        /// <summary>
        /// Gets or Sets QaCheckIsActive
        /// </summary>
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
        public ProjectSettingsResponseAllOfLanguageMapping LanguageMapping { get; set; }

        /// <summary>
        /// Gets or Sets NotificationSettings
        /// </summary>
        [DataMember(Name = "notificationSettings", EmitDefaultValue = false)]
        public ProjectSettingsResponseAllOfNotificationSettings NotificationSettings { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ProjectSettingsResponse {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  UserId: ").Append(UserId).Append("\n");
            sb.Append("  SourceLanguageId: ").Append(SourceLanguageId).Append("\n");
            sb.Append("  TargetLanguageIds: ").Append(TargetLanguageIds).Append("\n");
            sb.Append("  LanguageAccessPolicy: ").Append(LanguageAccessPolicy).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Cname: ").Append(Cname).Append("\n");
            sb.Append("  Identifier: ").Append(Identifier).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Visibility: ").Append(Visibility).Append("\n");
            sb.Append("  Logo: ").Append(Logo).Append("\n");
            sb.Append("  PublicDownloads: ").Append(PublicDownloads).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  LastActivity: ").Append(LastActivity).Append("\n");
            sb.Append("  TargetLanguages: ").Append(TargetLanguages).Append("\n");
            sb.Append("  TranslateDuplicates: ").Append(TranslateDuplicates).Append("\n");
            sb.Append("  TagsDetection: ").Append(TagsDetection).Append("\n");
            sb.Append("  GlossaryAccess: ").Append(GlossaryAccess).Append("\n");
            sb.Append("  IsMtAllowed: ").Append(IsMtAllowed).Append("\n");
            sb.Append("  HiddenStringsProofreadersAccess: ").Append(HiddenStringsProofreadersAccess).Append("\n");
            sb.Append("  AutoSubstitution: ").Append(AutoSubstitution).Append("\n");
            sb.Append("  ExportTranslatedOnly: ").Append(ExportTranslatedOnly).Append("\n");
            sb.Append("  SkipUntranslatedStrings: ").Append(SkipUntranslatedStrings).Append("\n");
            sb.Append("  SkipUntranslatedFiles: ").Append(SkipUntranslatedFiles).Append("\n");
            sb.Append("  ExportApprovedOnly: ").Append(ExportApprovedOnly).Append("\n");
            sb.Append("  AutoTranslateDialects: ").Append(AutoTranslateDialects).Append("\n");
            sb.Append("  UseGlobalTm: ").Append(UseGlobalTm).Append("\n");
            sb.Append("  NormalizePlaceholder: ").Append(NormalizePlaceholder).Append("\n");
            sb.Append("  SaveMetaInfoInSource: ").Append(SaveMetaInfoInSource).Append("\n");
            sb.Append("  InContext: ").Append(InContext).Append("\n");
            sb.Append("  InContextProcessHiddenStrings: ").Append(InContextProcessHiddenStrings).Append("\n");
            sb.Append("  InContextPseudoLanguageId: ").Append(InContextPseudoLanguageId).Append("\n");
            sb.Append("  InContextPseudoLanguage: ").Append(InContextPseudoLanguage).Append("\n");
            sb.Append("  IsSuspended: ").Append(IsSuspended).Append("\n");
            sb.Append("  QaCheckIsActive: ").Append(QaCheckIsActive).Append("\n");
            sb.Append("  QaCheckCategories: ").Append(QaCheckCategories).Append("\n");
            sb.Append("  LanguageMapping: ").Append(LanguageMapping).Append("\n");
            sb.Append("  NotificationSettings: ").Append(NotificationSettings).Append("\n");
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
            return this.Equals(input as ProjectSettingsResponse);
        }

        /// <summary>
        /// Returns true if ProjectSettingsResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of ProjectSettingsResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProjectSettingsResponse input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    this.Id.Equals(input.Id)
                ) && 
                (
                    this.UserId == input.UserId ||
                    this.UserId.Equals(input.UserId)
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
                    this.LanguageAccessPolicy == input.LanguageAccessPolicy ||
                    (this.LanguageAccessPolicy != null &&
                    this.LanguageAccessPolicy.Equals(input.LanguageAccessPolicy))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Cname == input.Cname ||
                    (this.Cname != null &&
                    this.Cname.Equals(input.Cname))
                ) && 
                (
                    this.Identifier == input.Identifier ||
                    (this.Identifier != null &&
                    this.Identifier.Equals(input.Identifier))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Visibility == input.Visibility ||
                    (this.Visibility != null &&
                    this.Visibility.Equals(input.Visibility))
                ) && 
                (
                    this.Logo == input.Logo ||
                    (this.Logo != null &&
                    this.Logo.Equals(input.Logo))
                ) && 
                (
                    this.PublicDownloads == input.PublicDownloads ||
                    this.PublicDownloads.Equals(input.PublicDownloads)
                ) && 
                (
                    this.CreatedAt == input.CreatedAt ||
                    (this.CreatedAt != null &&
                    this.CreatedAt.Equals(input.CreatedAt))
                ) && 
                (
                    this.UpdatedAt == input.UpdatedAt ||
                    (this.UpdatedAt != null &&
                    this.UpdatedAt.Equals(input.UpdatedAt))
                ) && 
                (
                    this.LastActivity == input.LastActivity ||
                    (this.LastActivity != null &&
                    this.LastActivity.Equals(input.LastActivity))
                ) && 
                (
                    this.TargetLanguages == input.TargetLanguages ||
                    this.TargetLanguages != null &&
                    input.TargetLanguages != null &&
                    this.TargetLanguages.SequenceEqual(input.TargetLanguages)
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
                    this.GlossaryAccess == input.GlossaryAccess ||
                    this.GlossaryAccess.Equals(input.GlossaryAccess)
                ) && 
                (
                    this.IsMtAllowed == input.IsMtAllowed ||
                    this.IsMtAllowed.Equals(input.IsMtAllowed)
                ) && 
                (
                    this.HiddenStringsProofreadersAccess == input.HiddenStringsProofreadersAccess ||
                    this.HiddenStringsProofreadersAccess.Equals(input.HiddenStringsProofreadersAccess)
                ) && 
                (
                    this.AutoSubstitution == input.AutoSubstitution ||
                    this.AutoSubstitution.Equals(input.AutoSubstitution)
                ) && 
                (
                    this.ExportTranslatedOnly == input.ExportTranslatedOnly ||
                    this.ExportTranslatedOnly.Equals(input.ExportTranslatedOnly)
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
                    this.AutoTranslateDialects == input.AutoTranslateDialects ||
                    this.AutoTranslateDialects.Equals(input.AutoTranslateDialects)
                ) && 
                (
                    this.UseGlobalTm == input.UseGlobalTm ||
                    this.UseGlobalTm.Equals(input.UseGlobalTm)
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
                    this.InContextPseudoLanguage == input.InContextPseudoLanguage ||
                    (this.InContextPseudoLanguage != null &&
                    this.InContextPseudoLanguage.Equals(input.InContextPseudoLanguage))
                ) && 
                (
                    this.IsSuspended == input.IsSuspended ||
                    this.IsSuspended.Equals(input.IsSuspended)
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
                    this.NotificationSettings == input.NotificationSettings ||
                    (this.NotificationSettings != null &&
                    this.NotificationSettings.Equals(input.NotificationSettings))
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
                hashCode = hashCode * 59 + this.Id.GetHashCode();
                hashCode = hashCode * 59 + this.UserId.GetHashCode();
                if (this.SourceLanguageId != null)
                    hashCode = hashCode * 59 + this.SourceLanguageId.GetHashCode();
                if (this.TargetLanguageIds != null)
                    hashCode = hashCode * 59 + this.TargetLanguageIds.GetHashCode();
                if (this.LanguageAccessPolicy != null)
                    hashCode = hashCode * 59 + this.LanguageAccessPolicy.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Cname != null)
                    hashCode = hashCode * 59 + this.Cname.GetHashCode();
                if (this.Identifier != null)
                    hashCode = hashCode * 59 + this.Identifier.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.Visibility != null)
                    hashCode = hashCode * 59 + this.Visibility.GetHashCode();
                if (this.Logo != null)
                    hashCode = hashCode * 59 + this.Logo.GetHashCode();
                hashCode = hashCode * 59 + this.PublicDownloads.GetHashCode();
                if (this.CreatedAt != null)
                    hashCode = hashCode * 59 + this.CreatedAt.GetHashCode();
                if (this.UpdatedAt != null)
                    hashCode = hashCode * 59 + this.UpdatedAt.GetHashCode();
                if (this.LastActivity != null)
                    hashCode = hashCode * 59 + this.LastActivity.GetHashCode();
                if (this.TargetLanguages != null)
                    hashCode = hashCode * 59 + this.TargetLanguages.GetHashCode();
                hashCode = hashCode * 59 + this.TranslateDuplicates.GetHashCode();
                hashCode = hashCode * 59 + this.TagsDetection.GetHashCode();
                hashCode = hashCode * 59 + this.GlossaryAccess.GetHashCode();
                hashCode = hashCode * 59 + this.IsMtAllowed.GetHashCode();
                hashCode = hashCode * 59 + this.HiddenStringsProofreadersAccess.GetHashCode();
                hashCode = hashCode * 59 + this.AutoSubstitution.GetHashCode();
                hashCode = hashCode * 59 + this.ExportTranslatedOnly.GetHashCode();
                hashCode = hashCode * 59 + this.SkipUntranslatedStrings.GetHashCode();
                hashCode = hashCode * 59 + this.SkipUntranslatedFiles.GetHashCode();
                hashCode = hashCode * 59 + this.ExportApprovedOnly.GetHashCode();
                hashCode = hashCode * 59 + this.AutoTranslateDialects.GetHashCode();
                hashCode = hashCode * 59 + this.UseGlobalTm.GetHashCode();
                hashCode = hashCode * 59 + this.NormalizePlaceholder.GetHashCode();
                hashCode = hashCode * 59 + this.SaveMetaInfoInSource.GetHashCode();
                hashCode = hashCode * 59 + this.InContext.GetHashCode();
                hashCode = hashCode * 59 + this.InContextProcessHiddenStrings.GetHashCode();
                if (this.InContextPseudoLanguageId != null)
                    hashCode = hashCode * 59 + this.InContextPseudoLanguageId.GetHashCode();
                if (this.InContextPseudoLanguage != null)
                    hashCode = hashCode * 59 + this.InContextPseudoLanguage.GetHashCode();
                hashCode = hashCode * 59 + this.IsSuspended.GetHashCode();
                hashCode = hashCode * 59 + this.QaCheckIsActive.GetHashCode();
                if (this.QaCheckCategories != null)
                    hashCode = hashCode * 59 + this.QaCheckCategories.GetHashCode();
                if (this.LanguageMapping != null)
                    hashCode = hashCode * 59 + this.LanguageMapping.GetHashCode();
                if (this.NotificationSettings != null)
                    hashCode = hashCode * 59 + this.NotificationSettings.GetHashCode();
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
