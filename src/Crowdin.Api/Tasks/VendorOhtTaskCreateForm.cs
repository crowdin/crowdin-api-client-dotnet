
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
        
        [JsonProperty("fileIds")]
#pragma warning disable CS8618
        public ICollection<int> FileIds { get; set; }
#pragma warning restore CS8618
        
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
        
        [JsonProperty("includeUntranslatedStringsOnly")]
        public bool? IncludeUntranslatedStringsOnly { get; set; }
        
        [JsonProperty("dateFrom")]
        public DateTimeOffset? DateFrom { get; set; }
        
        [JsonProperty("dateTo")]
        public DateTimeOffset? DateTo { get; set; }
        
        [PublicAPI]
        public enum TaskExpertise
        {
            [Description("standard")]
            Standard,
        
            [Description("mobile-applications")]
            MobileApplications,
        
            [Description("software-it")]
            SoftwareIt,
        
            [Description("gaming-video-games")]
            GamingVideoGames,
        
            [Description("technical-engineering")]
            TechnicalEngineering,
        
            [Description("marketing-consumer-media")]
            MarketingConsumerMedia,
        
            [Description("business-finance")]
            BusinessFinance,
        
            [Description("legal-certificate")]
            LegalCertificate,
        
            [Description("medical")]
            Medical,
        
            [Description("ad-words-banners")]
            AdWordsBanners,
        
            [Description("automotive-aerospace")]
            AutomotiveAerospace,
        
            [Description("scientific")]
            Scientific,
        
            [Description("scientific-academic")]
            ScientificAcademic,
        
            [Description("tourism")]
            Tourism,
        
            [Description("training-employee-handbooks")]
            TrainingEmployeeHandbooks,
        
            [Description("forex-crypto")]
            ForexCrypto
        }
    }
}