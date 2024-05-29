
using System;
using System.Collections.Generic;
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public class VendorTranslatedTaskCreateForm : AddTaskRequest
    {
        [JsonProperty("title")]
#pragma warning disable CS8618
        public string Title { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("languageId")]
#pragma warning disable CS8618
        public string LanguageId { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("branchIds")]
        public ICollection<int>? BranchIds { get; set; }
        
        [JsonProperty("fileIds")]
        public ICollection<int>? FileIds { get; set; }
        
        [JsonProperty("type")]
        public TaskType Type { get; set; }
        
        [JsonProperty("vendor")]
        public string Vendor => "translated";
        
        [JsonProperty("status")]
        public TaskStatus? Status { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }
        
        [JsonProperty("expertise")]
        public TaskExpertise? Expertise { get; set; }
        
        [JsonProperty("subject")]
        public TaskSubject? Subject { get; set; }
        
        [JsonProperty("labelIds")]
        public ICollection<int>? LabelIds { get; set; }
        
        [JsonProperty("dateFrom")]
        public DateTimeOffset? DateFrom { get; set; }
        
        [JsonProperty("dateTo")]
        public DateTimeOffset? DateTo { get; set; }

        [PublicAPI]
        public enum TaskExpertise
        {
            [SerializedValue("P")]
            Economy,
            
            [SerializedValue("T")]
            Professional,
            
            [SerializedValue("R")]
            Premium
        }

        [PublicAPI]
        public enum TaskSubject
        {
            [SerializedValue("general")]
            General,
            
            [SerializedValue("accounting_finance")]
            AccountingFinance,
            
            [SerializedValue("aerospace_defence")]
            AerospaceDefence,
            
            [SerializedValue("architecture")]
            Architecture,
            
            [SerializedValue("art")]
            Art,
            
            [SerializedValue("automotive")]
            Automotive,
            
            [SerializedValue("certificates_diplomas_licenses_cv_etc")]
            CertificatesDiplomasLicensesCvEtc,
            
            [SerializedValue("chemical")]
            Chemical,
            
            [SerializedValue("civil_engineering_construction")]
            CivilEngineeringConstruction,
            
            [SerializedValue("corporate_social_responsibility")]
            CorporateSocialResponsibility,
            
            [SerializedValue("cosmetics")]
            Cosmetics,
            
            [SerializedValue("culinary")]
            Culinary,
            
            [SerializedValue("electronics_electrical_engineering")]
            ElectronicsElectricalEngineering,
            
            [SerializedValue("energy_power_generation_oil_gas")]
            EnergyPowerGenerationOilGas,
            
            [SerializedValue("environment")]
            Environment,
            
            [SerializedValue("fashion")]
            Fashion,
            
            [SerializedValue("games_videogames_casino")]
            GamesVideoGamesCasino,
            
            [SerializedValue("general_business_commerce")]
            GeneralBusinessCommerce,
            
            [SerializedValue("history_archaeology")]
            HistoryArchaeology,
            
            [SerializedValue("information_technology")]
            InformationTechnology,
            
            [SerializedValue("insurance")]
            Insurance,
            
            [SerializedValue("internet_e-commerce")]
            InternetECommerce,
            
            [SerializedValue("legal_documents_contracts")]
            LegalDocumentsContracts,
            
            [SerializedValue("literary_translations")]
            LiteraryTranslations,
            
            [SerializedValue("marketing_advertising_material_public_relations")]
            MarketingAdvertisingMaterialPublicRelations,
            
            [SerializedValue("matematics_and_physics")]
            MathematicsAndPhysics,
            
            [SerializedValue("mechanical_manufacturing")]
            MechanicalManufacturing,
            
            [SerializedValue("media_journalism_publishing")]
            MediaJournalismPublishing,
            
            [SerializedValue("medical_pharmaceutical")]
            MedicalPharmaceutical,
            
            [SerializedValue("music")]
            Music,
            
            [SerializedValue("private_correspondence_letters")]
            PrivateCorrespondenceLetters,
            
            [SerializedValue("religion")]
            Religion,
            
            [SerializedValue("science")]
            Science,
            
            [SerializedValue("shipping_sailing_maritime")]
            ShippingSailingMaritime,
            
            [SerializedValue("social_science")]
            SocialScience,
            
            [SerializedValue("telecommunications")]
            Telecommunications,
            
            [SerializedValue("travel_tourism")]
            TravelTourism
        }
    }
}