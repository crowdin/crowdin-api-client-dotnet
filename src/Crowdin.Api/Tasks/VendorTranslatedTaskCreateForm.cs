
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
        public ICollection<long>? BranchIds { get; set; }
        
        [JsonProperty("fileIds")]
        public ICollection<long>? FileIds { get; set; }
        
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
        public ICollection<long>? LabelIds { get; set; }
        
        [JsonProperty("dateFrom")]
        public DateTimeOffset? DateFrom { get; set; }
        
        [JsonProperty("dateTo")]
        public DateTimeOffset? DateTo { get; set; }

        [PublicAPI]
        public enum TaskExpertise
        {
            [Description("P")]
            Economy,
            
            [Description("T")]
            Professional,
            
            [Description("R")]
            Premium
        }

        [PublicAPI]
        public enum TaskSubject
        {
            [Description("general")]
            General,
            
            [Description("accounting_finance")]
            AccountingFinance,
            
            [Description("aerospace_defence")]
            AerospaceDefence,
            
            [Description("architecture")]
            Architecture,
            
            [Description("art")]
            Art,
            
            [Description("automotive")]
            Automotive,
            
            [Description("certificates_diplomas_licenses_cv_etc")]
            CertificatesDiplomasLicensesCvEtc,
            
            [Description("chemical")]
            Chemical,
            
            [Description("civil_engineering_construction")]
            CivilEngineeringConstruction,
            
            [Description("corporate_social_responsibility")]
            CorporateSocialResponsibility,
            
            [Description("cosmetics")]
            Cosmetics,
            
            [Description("culinary")]
            Culinary,
            
            [Description("electronics_electrical_engineering")]
            ElectronicsElectricalEngineering,
            
            [Description("energy_power_generation_oil_gas")]
            EnergyPowerGenerationOilGas,
            
            [Description("environment")]
            Environment,
            
            [Description("fashion")]
            Fashion,
            
            [Description("games_videogames_casino")]
            GamesVideoGamesCasino,
            
            [Description("general_business_commerce")]
            GeneralBusinessCommerce,
            
            [Description("history_archaeology")]
            HistoryArchaeology,
            
            [Description("information_technology")]
            InformationTechnology,
            
            [Description("insurance")]
            Insurance,
            
            [Description("internet_e-commerce")]
            InternetECommerce,
            
            [Description("legal_documents_contracts")]
            LegalDocumentsContracts,
            
            [Description("literary_translations")]
            LiteraryTranslations,
            
            [Description("marketing_advertising_material_public_relations")]
            MarketingAdvertisingMaterialPublicRelations,
            
            [Description("matematics_and_physics")]
            MathematicsAndPhysics,
            
            [Description("mechanical_manufacturing")]
            MechanicalManufacturing,
            
            [Description("media_journalism_publishing")]
            MediaJournalismPublishing,
            
            [Description("medical_pharmaceutical")]
            MedicalPharmaceutical,
            
            [Description("music")]
            Music,
            
            [Description("private_correspondence_letters")]
            PrivateCorrespondenceLetters,
            
            [Description("religion")]
            Religion,
            
            [Description("science")]
            Science,
            
            [Description("shipping_sailing_maritime")]
            ShippingSailingMaritime,
            
            [Description("social_science")]
            SocialScience,
            
            [Description("telecommunications")]
            Telecommunications,
            
            [Description("travel_tourism")]
            TravelTourism
        }
    }
}