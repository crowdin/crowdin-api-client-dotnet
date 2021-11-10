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
    /// CrowdinVendorTranslatedTaskCreateForm
    /// </summary>
    [DataContract(Name = "CrowdinVendorTranslatedTaskCreateForm")]
    public partial class CrowdinVendorTranslatedTaskCreateForm : IEquatable<CrowdinVendorTranslatedTaskCreateForm>, IValidatableObject
    {
        /// <summary>
        /// Task status
        /// </summary>
        /// <value>Task status</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            /// <summary>
            /// Enum Todo for value: todo
            /// </summary>
            [EnumMember(Value = "todo")]
            Todo = 1,

            /// <summary>
            /// Enum InProgress for value: in_progress
            /// </summary>
            [EnumMember(Value = "in_progress")]
            InProgress = 2

        }


        /// <summary>
        /// Task status
        /// </summary>
        /// <value>Task status</value>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public StatusEnum? Status { get; set; }
        /// <summary>
        /// Task expertise:  *    \&quot;P\&quot; - Economy (Automatic translation + revision)  *    \&quot;T\&quot; - Professional (1 translator + quality control)  *    \&quot;R\&quot; - Premium (2 translators + quality control)
        /// </summary>
        /// <value>Task expertise:  *    \&quot;P\&quot; - Economy (Automatic translation + revision)  *    \&quot;T\&quot; - Professional (1 translator + quality control)  *    \&quot;R\&quot; - Premium (2 translators + quality control)</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ExpertiseEnum
        {
            /// <summary>
            /// Enum P for value: P
            /// </summary>
            [EnumMember(Value = "P")]
            P = 1,

            /// <summary>
            /// Enum T for value: T
            /// </summary>
            [EnumMember(Value = "T")]
            T = 2,

            /// <summary>
            /// Enum R for value: R
            /// </summary>
            [EnumMember(Value = "R")]
            R = 3

        }


        /// <summary>
        /// Task expertise:  *    \&quot;P\&quot; - Economy (Automatic translation + revision)  *    \&quot;T\&quot; - Professional (1 translator + quality control)  *    \&quot;R\&quot; - Premium (2 translators + quality control)
        /// </summary>
        /// <value>Task expertise:  *    \&quot;P\&quot; - Economy (Automatic translation + revision)  *    \&quot;T\&quot; - Professional (1 translator + quality control)  *    \&quot;R\&quot; - Premium (2 translators + quality control)</value>
        [DataMember(Name = "expertise", EmitDefaultValue = false)]
        public ExpertiseEnum? Expertise { get; set; }
        /// <summary>
        /// Task subject:  *    \&quot;general\&quot;  *    \&quot;accounting_finance\&quot;  *    \&quot;aerospace_defence\&quot;  *    \&quot;architecture\&quot;  *    \&quot;art\&quot;  *    \&quot;automotive\&quot;  *    \&quot;certificates_diplomas_licences_cv_etc\&quot;  *    \&quot;chemical\&quot;  *    \&quot;civil_engineering_construction\&quot;  *    \&quot;corporate_social_responsibility\&quot;  *    \&quot;cosmetics\&quot;  *    \&quot;culinary\&quot;  *    \&quot;electronics_electrical_engineering\&quot;  *    \&quot;energy_power_generation_oil_gas\&quot;  *    \&quot;environment\&quot;  *    \&quot;fashion\&quot;  *    \&quot;games_viseogames_casino\&quot;  *    \&quot;general_business_commerce\&quot;  *    \&quot;history_archaeology\&quot;  *    \&quot;information_technology\&quot;  *    \&quot;insurance\&quot;  *    \&quot;internet_e-commerce\&quot;  *    \&quot;legal_documents_contracts\&quot;  *    \&quot;literary_translations\&quot;  *    \&quot;marketing_advertising_material_public_relations\&quot;  *    \&quot;matematics_and_physics\&quot;  *    \&quot;mechanical_manufacturing\&quot;  *    \&quot;media_journalism_publishing\&quot;  *    \&quot;medical_pharmaceutical\&quot;  *    \&quot;music\&quot;  *    \&quot;private_correspondence_letters\&quot;  *    \&quot;religion\&quot;  *    \&quot;science\&quot;  *    \&quot;shipping_sailing_maritime\&quot;  *    \&quot;social_science\&quot;  *    \&quot;telecommunications\&quot;  *    \&quot;travel_tourism\&quot;
        /// </summary>
        /// <value>Task subject:  *    \&quot;general\&quot;  *    \&quot;accounting_finance\&quot;  *    \&quot;aerospace_defence\&quot;  *    \&quot;architecture\&quot;  *    \&quot;art\&quot;  *    \&quot;automotive\&quot;  *    \&quot;certificates_diplomas_licences_cv_etc\&quot;  *    \&quot;chemical\&quot;  *    \&quot;civil_engineering_construction\&quot;  *    \&quot;corporate_social_responsibility\&quot;  *    \&quot;cosmetics\&quot;  *    \&quot;culinary\&quot;  *    \&quot;electronics_electrical_engineering\&quot;  *    \&quot;energy_power_generation_oil_gas\&quot;  *    \&quot;environment\&quot;  *    \&quot;fashion\&quot;  *    \&quot;games_viseogames_casino\&quot;  *    \&quot;general_business_commerce\&quot;  *    \&quot;history_archaeology\&quot;  *    \&quot;information_technology\&quot;  *    \&quot;insurance\&quot;  *    \&quot;internet_e-commerce\&quot;  *    \&quot;legal_documents_contracts\&quot;  *    \&quot;literary_translations\&quot;  *    \&quot;marketing_advertising_material_public_relations\&quot;  *    \&quot;matematics_and_physics\&quot;  *    \&quot;mechanical_manufacturing\&quot;  *    \&quot;media_journalism_publishing\&quot;  *    \&quot;medical_pharmaceutical\&quot;  *    \&quot;music\&quot;  *    \&quot;private_correspondence_letters\&quot;  *    \&quot;religion\&quot;  *    \&quot;science\&quot;  *    \&quot;shipping_sailing_maritime\&quot;  *    \&quot;social_science\&quot;  *    \&quot;telecommunications\&quot;  *    \&quot;travel_tourism\&quot;</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SubjectEnum
        {
            /// <summary>
            /// Enum General for value: general
            /// </summary>
            [EnumMember(Value = "general")]
            General = 1,

            /// <summary>
            /// Enum AccountingFinance for value: accounting_finance
            /// </summary>
            [EnumMember(Value = "accounting_finance")]
            AccountingFinance = 2,

            /// <summary>
            /// Enum AerospaceDefence for value: aerospace_defence
            /// </summary>
            [EnumMember(Value = "aerospace_defence")]
            AerospaceDefence = 3,

            /// <summary>
            /// Enum Architecture for value: architecture
            /// </summary>
            [EnumMember(Value = "architecture")]
            Architecture = 4,

            /// <summary>
            /// Enum Art for value: art
            /// </summary>
            [EnumMember(Value = "art")]
            Art = 5,

            /// <summary>
            /// Enum Automotive for value: automotive
            /// </summary>
            [EnumMember(Value = "automotive")]
            Automotive = 6,

            /// <summary>
            /// Enum CertificatesDiplomasLicencesCvEtc for value: certificates_diplomas_licences_cv_etc
            /// </summary>
            [EnumMember(Value = "certificates_diplomas_licences_cv_etc")]
            CertificatesDiplomasLicencesCvEtc = 7,

            /// <summary>
            /// Enum Chemical for value: chemical
            /// </summary>
            [EnumMember(Value = "chemical")]
            Chemical = 8,

            /// <summary>
            /// Enum CivilEngineeringConstruction for value: civil_engineering_construction
            /// </summary>
            [EnumMember(Value = "civil_engineering_construction")]
            CivilEngineeringConstruction = 9,

            /// <summary>
            /// Enum CorporateSocialResponsibility for value: corporate_social_responsibility
            /// </summary>
            [EnumMember(Value = "corporate_social_responsibility")]
            CorporateSocialResponsibility = 10,

            /// <summary>
            /// Enum Cosmetics for value: cosmetics
            /// </summary>
            [EnumMember(Value = "cosmetics")]
            Cosmetics = 11,

            /// <summary>
            /// Enum Culinary for value: culinary
            /// </summary>
            [EnumMember(Value = "culinary")]
            Culinary = 12,

            /// <summary>
            /// Enum ElectronicsElectricalEngineering for value: electronics_electrical_engineering
            /// </summary>
            [EnumMember(Value = "electronics_electrical_engineering")]
            ElectronicsElectricalEngineering = 13,

            /// <summary>
            /// Enum EnergyPowerGenerationOilGas for value: energy_power_generation_oil_gas
            /// </summary>
            [EnumMember(Value = "energy_power_generation_oil_gas")]
            EnergyPowerGenerationOilGas = 14,

            /// <summary>
            /// Enum Environment for value: environment
            /// </summary>
            [EnumMember(Value = "environment")]
            Environment = 15,

            /// <summary>
            /// Enum Fashion for value: fashion
            /// </summary>
            [EnumMember(Value = "fashion")]
            Fashion = 16,

            /// <summary>
            /// Enum GamesViseogamesCasino for value: games_viseogames_casino
            /// </summary>
            [EnumMember(Value = "games_viseogames_casino")]
            GamesViseogamesCasino = 17,

            /// <summary>
            /// Enum GeneralBusinessCommerce for value: general_business_commerce
            /// </summary>
            [EnumMember(Value = "general_business_commerce")]
            GeneralBusinessCommerce = 18,

            /// <summary>
            /// Enum HistoryArchaeology for value: history_archaeology
            /// </summary>
            [EnumMember(Value = "history_archaeology")]
            HistoryArchaeology = 19,

            /// <summary>
            /// Enum InformationTechnology for value: information_technology
            /// </summary>
            [EnumMember(Value = "information_technology")]
            InformationTechnology = 20,

            /// <summary>
            /// Enum Insurance for value: insurance
            /// </summary>
            [EnumMember(Value = "insurance")]
            Insurance = 21,

            /// <summary>
            /// Enum InternetECommerce for value: internet_e-commerce
            /// </summary>
            [EnumMember(Value = "internet_e-commerce")]
            InternetECommerce = 22,

            /// <summary>
            /// Enum LegalDocumentsContracts for value: legal_documents_contracts
            /// </summary>
            [EnumMember(Value = "legal_documents_contracts")]
            LegalDocumentsContracts = 23,

            /// <summary>
            /// Enum LiteraryTranslations for value: literary_translations
            /// </summary>
            [EnumMember(Value = "literary_translations")]
            LiteraryTranslations = 24,

            /// <summary>
            /// Enum MarketingAdvertisingMaterialPublicRelations for value: marketing_advertising_material_public_relations
            /// </summary>
            [EnumMember(Value = "marketing_advertising_material_public_relations")]
            MarketingAdvertisingMaterialPublicRelations = 25,

            /// <summary>
            /// Enum MatematicsAndPhysics for value: matematics_and_physics
            /// </summary>
            [EnumMember(Value = "matematics_and_physics")]
            MatematicsAndPhysics = 26,

            /// <summary>
            /// Enum MechanicalManufacturing for value: mechanical_manufacturing
            /// </summary>
            [EnumMember(Value = "mechanical_manufacturing")]
            MechanicalManufacturing = 27,

            /// <summary>
            /// Enum MediaJournalismPublishing for value: media_journalism_publishing
            /// </summary>
            [EnumMember(Value = "media_journalism_publishing")]
            MediaJournalismPublishing = 28,

            /// <summary>
            /// Enum MedicalPharmaceutical for value: medical_pharmaceutical
            /// </summary>
            [EnumMember(Value = "medical_pharmaceutical")]
            MedicalPharmaceutical = 29,

            /// <summary>
            /// Enum Music for value: music
            /// </summary>
            [EnumMember(Value = "music")]
            Music = 30,

            /// <summary>
            /// Enum PrivateCorrespondenceLetters for value: private_correspondence_letters
            /// </summary>
            [EnumMember(Value = "private_correspondence_letters")]
            PrivateCorrespondenceLetters = 31,

            /// <summary>
            /// Enum Religion for value: religion
            /// </summary>
            [EnumMember(Value = "religion")]
            Religion = 32,

            /// <summary>
            /// Enum Science for value: science
            /// </summary>
            [EnumMember(Value = "science")]
            Science = 33,

            /// <summary>
            /// Enum ShippingSailingMaritime for value: shipping_sailing_maritime
            /// </summary>
            [EnumMember(Value = "shipping_sailing_maritime")]
            ShippingSailingMaritime = 34,

            /// <summary>
            /// Enum SocialScience for value: social_science
            /// </summary>
            [EnumMember(Value = "social_science")]
            SocialScience = 35,

            /// <summary>
            /// Enum Telecommunications for value: telecommunications
            /// </summary>
            [EnumMember(Value = "telecommunications")]
            Telecommunications = 36,

            /// <summary>
            /// Enum TravelTourism for value: travel_tourism
            /// </summary>
            [EnumMember(Value = "travel_tourism")]
            TravelTourism = 37

        }


        /// <summary>
        /// Task subject:  *    \&quot;general\&quot;  *    \&quot;accounting_finance\&quot;  *    \&quot;aerospace_defence\&quot;  *    \&quot;architecture\&quot;  *    \&quot;art\&quot;  *    \&quot;automotive\&quot;  *    \&quot;certificates_diplomas_licences_cv_etc\&quot;  *    \&quot;chemical\&quot;  *    \&quot;civil_engineering_construction\&quot;  *    \&quot;corporate_social_responsibility\&quot;  *    \&quot;cosmetics\&quot;  *    \&quot;culinary\&quot;  *    \&quot;electronics_electrical_engineering\&quot;  *    \&quot;energy_power_generation_oil_gas\&quot;  *    \&quot;environment\&quot;  *    \&quot;fashion\&quot;  *    \&quot;games_viseogames_casino\&quot;  *    \&quot;general_business_commerce\&quot;  *    \&quot;history_archaeology\&quot;  *    \&quot;information_technology\&quot;  *    \&quot;insurance\&quot;  *    \&quot;internet_e-commerce\&quot;  *    \&quot;legal_documents_contracts\&quot;  *    \&quot;literary_translations\&quot;  *    \&quot;marketing_advertising_material_public_relations\&quot;  *    \&quot;matematics_and_physics\&quot;  *    \&quot;mechanical_manufacturing\&quot;  *    \&quot;media_journalism_publishing\&quot;  *    \&quot;medical_pharmaceutical\&quot;  *    \&quot;music\&quot;  *    \&quot;private_correspondence_letters\&quot;  *    \&quot;religion\&quot;  *    \&quot;science\&quot;  *    \&quot;shipping_sailing_maritime\&quot;  *    \&quot;social_science\&quot;  *    \&quot;telecommunications\&quot;  *    \&quot;travel_tourism\&quot;
        /// </summary>
        /// <value>Task subject:  *    \&quot;general\&quot;  *    \&quot;accounting_finance\&quot;  *    \&quot;aerospace_defence\&quot;  *    \&quot;architecture\&quot;  *    \&quot;art\&quot;  *    \&quot;automotive\&quot;  *    \&quot;certificates_diplomas_licences_cv_etc\&quot;  *    \&quot;chemical\&quot;  *    \&quot;civil_engineering_construction\&quot;  *    \&quot;corporate_social_responsibility\&quot;  *    \&quot;cosmetics\&quot;  *    \&quot;culinary\&quot;  *    \&quot;electronics_electrical_engineering\&quot;  *    \&quot;energy_power_generation_oil_gas\&quot;  *    \&quot;environment\&quot;  *    \&quot;fashion\&quot;  *    \&quot;games_viseogames_casino\&quot;  *    \&quot;general_business_commerce\&quot;  *    \&quot;history_archaeology\&quot;  *    \&quot;information_technology\&quot;  *    \&quot;insurance\&quot;  *    \&quot;internet_e-commerce\&quot;  *    \&quot;legal_documents_contracts\&quot;  *    \&quot;literary_translations\&quot;  *    \&quot;marketing_advertising_material_public_relations\&quot;  *    \&quot;matematics_and_physics\&quot;  *    \&quot;mechanical_manufacturing\&quot;  *    \&quot;media_journalism_publishing\&quot;  *    \&quot;medical_pharmaceutical\&quot;  *    \&quot;music\&quot;  *    \&quot;private_correspondence_letters\&quot;  *    \&quot;religion\&quot;  *    \&quot;science\&quot;  *    \&quot;shipping_sailing_maritime\&quot;  *    \&quot;social_science\&quot;  *    \&quot;telecommunications\&quot;  *    \&quot;travel_tourism\&quot;</value>
        [DataMember(Name = "subject", EmitDefaultValue = false)]
        public SubjectEnum? Subject { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CrowdinVendorTranslatedTaskCreateForm" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CrowdinVendorTranslatedTaskCreateForm() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CrowdinVendorTranslatedTaskCreateForm" /> class.
        /// </summary>
        /// <param name="title">Task title (required).</param>
        /// <param name="languageId">Task Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany) (required).</param>
        /// <param name="fileIds">Task file ids (required).</param>
        /// <param name="type">Task type:  *     2 - translate by vendor (required).</param>
        /// <param name="vendor">Task vendor:  *    \&quot;translated\&quot; - Translated.com (required).</param>
        /// <param name="status">Task status (default to StatusEnum.Todo).</param>
        /// <param name="description">Task description.</param>
        /// <param name="expertise">Task expertise:  *    \&quot;P\&quot; - Economy (Automatic translation + revision)  *    \&quot;T\&quot; - Professional (1 translator + quality control)  *    \&quot;R\&quot; - Premium (2 translators + quality control) (default to ExpertiseEnum.P).</param>
        /// <param name="subject">Task subject:  *    \&quot;general\&quot;  *    \&quot;accounting_finance\&quot;  *    \&quot;aerospace_defence\&quot;  *    \&quot;architecture\&quot;  *    \&quot;art\&quot;  *    \&quot;automotive\&quot;  *    \&quot;certificates_diplomas_licences_cv_etc\&quot;  *    \&quot;chemical\&quot;  *    \&quot;civil_engineering_construction\&quot;  *    \&quot;corporate_social_responsibility\&quot;  *    \&quot;cosmetics\&quot;  *    \&quot;culinary\&quot;  *    \&quot;electronics_electrical_engineering\&quot;  *    \&quot;energy_power_generation_oil_gas\&quot;  *    \&quot;environment\&quot;  *    \&quot;fashion\&quot;  *    \&quot;games_viseogames_casino\&quot;  *    \&quot;general_business_commerce\&quot;  *    \&quot;history_archaeology\&quot;  *    \&quot;information_technology\&quot;  *    \&quot;insurance\&quot;  *    \&quot;internet_e-commerce\&quot;  *    \&quot;legal_documents_contracts\&quot;  *    \&quot;literary_translations\&quot;  *    \&quot;marketing_advertising_material_public_relations\&quot;  *    \&quot;matematics_and_physics\&quot;  *    \&quot;mechanical_manufacturing\&quot;  *    \&quot;media_journalism_publishing\&quot;  *    \&quot;medical_pharmaceutical\&quot;  *    \&quot;music\&quot;  *    \&quot;private_correspondence_letters\&quot;  *    \&quot;religion\&quot;  *    \&quot;science\&quot;  *    \&quot;shipping_sailing_maritime\&quot;  *    \&quot;social_science\&quot;  *    \&quot;telecommunications\&quot;  *    \&quot;travel_tourism\&quot; (default to SubjectEnum.General).</param>
        /// <param name="labelIds">Label Identifiers. Get via [List Labels](#operation/api.projects.labels.getMany).</param>
        /// <param name="dateFrom">Defines start date for interval when strings were modified  Format: UTC, ISO 8601.</param>
        /// <param name="dateTo">Defines end date for interval when strings were modified  Format: UTC, ISO 8601.</param>
        public CrowdinVendorTranslatedTaskCreateForm(string title = default(string), string languageId = default(string), List<int> fileIds = default(List<int>), int type = default(int), string vendor = default(string), StatusEnum? status = StatusEnum.Todo, string description = default(string), ExpertiseEnum? expertise = ExpertiseEnum.P, SubjectEnum? subject = SubjectEnum.General, List<int> labelIds = default(List<int>), DateTime dateFrom = default(DateTime), DateTime dateTo = default(DateTime))
        {
            // to ensure "title" is required (not null)
            if (title == null) {
                throw new ArgumentNullException("title is a required property for CrowdinVendorTranslatedTaskCreateForm and cannot be null");
            }
            this.Title = title;
            // to ensure "languageId" is required (not null)
            if (languageId == null) {
                throw new ArgumentNullException("languageId is a required property for CrowdinVendorTranslatedTaskCreateForm and cannot be null");
            }
            this.LanguageId = languageId;
            // to ensure "fileIds" is required (not null)
            if (fileIds == null) {
                throw new ArgumentNullException("fileIds is a required property for CrowdinVendorTranslatedTaskCreateForm and cannot be null");
            }
            this.FileIds = fileIds;
            this.Type = type;
            // to ensure "vendor" is required (not null)
            if (vendor == null) {
                throw new ArgumentNullException("vendor is a required property for CrowdinVendorTranslatedTaskCreateForm and cannot be null");
            }
            this.Vendor = vendor;
            this.Status = status;
            this.Description = description;
            this.Expertise = expertise;
            this.Subject = subject;
            this.LabelIds = labelIds;
            this.DateFrom = dateFrom;
            this.DateTo = dateTo;
        }

        /// <summary>
        /// Task title
        /// </summary>
        /// <value>Task title</value>
        [DataMember(Name = "title", IsRequired = true, EmitDefaultValue = false)]
        public string Title { get; set; }

        /// <summary>
        /// Task Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany)
        /// </summary>
        /// <value>Task Language Identifier. Get via [List Supported Languages](#operation/api.languages.getMany)</value>
        [DataMember(Name = "languageId", IsRequired = true, EmitDefaultValue = false)]
        public string LanguageId { get; set; }

        /// <summary>
        /// Task file ids
        /// </summary>
        /// <value>Task file ids</value>
        [DataMember(Name = "fileIds", IsRequired = true, EmitDefaultValue = false)]
        public List<int> FileIds { get; set; }

        /// <summary>
        /// Task type:  *     2 - translate by vendor
        /// </summary>
        /// <value>Task type:  *     2 - translate by vendor</value>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = false)]
        public int Type { get; set; }

        /// <summary>
        /// Task vendor:  *    \&quot;translated\&quot; - Translated.com
        /// </summary>
        /// <value>Task vendor:  *    \&quot;translated\&quot; - Translated.com</value>
        [DataMember(Name = "vendor", IsRequired = true, EmitDefaultValue = false)]
        public string Vendor { get; set; }

        /// <summary>
        /// Task description
        /// </summary>
        /// <value>Task description</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Label Identifiers. Get via [List Labels](#operation/api.projects.labels.getMany)
        /// </summary>
        /// <value>Label Identifiers. Get via [List Labels](#operation/api.projects.labels.getMany)</value>
        [DataMember(Name = "labelIds", EmitDefaultValue = false)]
        public List<int> LabelIds { get; set; }

        /// <summary>
        /// Defines start date for interval when strings were modified  Format: UTC, ISO 8601
        /// </summary>
        /// <value>Defines start date for interval when strings were modified  Format: UTC, ISO 8601</value>
        [DataMember(Name = "dateFrom", EmitDefaultValue = false)]
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// Defines end date for interval when strings were modified  Format: UTC, ISO 8601
        /// </summary>
        /// <value>Defines end date for interval when strings were modified  Format: UTC, ISO 8601</value>
        [DataMember(Name = "dateTo", EmitDefaultValue = false)]
        public DateTime DateTo { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CrowdinVendorTranslatedTaskCreateForm {\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  LanguageId: ").Append(LanguageId).Append("\n");
            sb.Append("  FileIds: ").Append(FileIds).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Vendor: ").Append(Vendor).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Expertise: ").Append(Expertise).Append("\n");
            sb.Append("  Subject: ").Append(Subject).Append("\n");
            sb.Append("  LabelIds: ").Append(LabelIds).Append("\n");
            sb.Append("  DateFrom: ").Append(DateFrom).Append("\n");
            sb.Append("  DateTo: ").Append(DateTo).Append("\n");
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
            return this.Equals(input as CrowdinVendorTranslatedTaskCreateForm);
        }

        /// <summary>
        /// Returns true if CrowdinVendorTranslatedTaskCreateForm instances are equal
        /// </summary>
        /// <param name="input">Instance of CrowdinVendorTranslatedTaskCreateForm to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CrowdinVendorTranslatedTaskCreateForm input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
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
                    this.Type == input.Type ||
                    this.Type.Equals(input.Type)
                ) && 
                (
                    this.Vendor == input.Vendor ||
                    (this.Vendor != null &&
                    this.Vendor.Equals(input.Vendor))
                ) && 
                (
                    this.Status == input.Status ||
                    this.Status.Equals(input.Status)
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Expertise == input.Expertise ||
                    this.Expertise.Equals(input.Expertise)
                ) && 
                (
                    this.Subject == input.Subject ||
                    this.Subject.Equals(input.Subject)
                ) && 
                (
                    this.LabelIds == input.LabelIds ||
                    this.LabelIds != null &&
                    input.LabelIds != null &&
                    this.LabelIds.SequenceEqual(input.LabelIds)
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
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
                if (this.LanguageId != null)
                    hashCode = hashCode * 59 + this.LanguageId.GetHashCode();
                if (this.FileIds != null)
                    hashCode = hashCode * 59 + this.FileIds.GetHashCode();
                hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Vendor != null)
                    hashCode = hashCode * 59 + this.Vendor.GetHashCode();
                hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                hashCode = hashCode * 59 + this.Expertise.GetHashCode();
                hashCode = hashCode * 59 + this.Subject.GetHashCode();
                if (this.LabelIds != null)
                    hashCode = hashCode * 59 + this.LabelIds.GetHashCode();
                if (this.DateFrom != null)
                    hashCode = hashCode * 59 + this.DateFrom.GetHashCode();
                if (this.DateTo != null)
                    hashCode = hashCode * 59 + this.DateTo.GetHashCode();
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
