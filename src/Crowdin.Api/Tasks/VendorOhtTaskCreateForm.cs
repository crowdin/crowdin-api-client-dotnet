
using System;
using System.Collections.Generic;
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public class VendorOhtTaskCreateForm : AddTaskRequest
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
        public string Vendor => "oht";
        
        [JsonProperty("status")]
        public TaskStatus? Status { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }
        
        [JsonProperty("expertise")]
        public TaskExpertise? Expertise { get; set; }
        
        [JsonProperty("labelIds")]
        public ICollection<int>? LabelIds { get; set; }
        
        [JsonProperty("skipUntranslatedStrings")]
        public bool? SkipUntranslatedStrings { get; set; }

        [JsonProperty("includePreTranslatedStringsOnly")]
        public bool? IncludePreTranslatedStringsOnly { get; set; }
        
        [JsonProperty("includeUntranslatedStringsOnly")]
        public bool? IncludeUntranslatedStringsOnly { get; set; }
        
        [JsonProperty("dateFrom")]
        public DateTimeOffset? DateFrom { get; set; }
        
        [JsonProperty("dateTo")]
        public DateTimeOffset? DateTo { get; set; }
        
        [PublicAPI]
        public enum TaskExpertise
        {
            [SerializedValue("standard")]
            Standard,
        
            [SerializedValue("mobile-applications")]
            MobileApplications,
        
            [SerializedValue("software-it")]
            SoftwareIt,
        
            [SerializedValue("gaming-video-games")]
            GamingVideoGames,
        
            [SerializedValue("technical-engineering")]
            TechnicalEngineering,
        
            [SerializedValue("marketing-consumer-media")]
            MarketingConsumerMedia,
        
            [SerializedValue("business-finance")]
            BusinessFinance,
        
            [SerializedValue("legal-certificate")]
            LegalCertificate,
        
            [SerializedValue("medical")]
            Medical,
        
            [SerializedValue("ad-words-banners")]
            AdWordsBanners,
        
            [SerializedValue("automotive-aerospace")]
            AutomotiveAerospace,
        
            [SerializedValue("scientific")]
            Scientific,
        
            [SerializedValue("scientific-academic")]
            ScientificAcademic,
        
            [SerializedValue("tourism")]
            Tourism,
        
            [SerializedValue("training-employee-handbooks")]
            TrainingEmployeeHandbooks,
        
            [SerializedValue("forex-crypto")]
            ForexCrypto
        }
    }
}