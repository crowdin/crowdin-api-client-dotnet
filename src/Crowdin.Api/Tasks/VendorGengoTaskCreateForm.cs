
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Crowdin.Api.Core.Converters;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public class VendorGengoTaskCreateForm : AddTaskRequest
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
        public string Vendor => "gengo";
        
        [JsonProperty("status")]
        public TaskStatus? Status { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }
        
        [JsonProperty("expertise")]
        public TaskExpertise? Expertise { get; set; }
        
        [JsonProperty("tone")]
        public TaskTone? Tone { get; set; }
        
        [JsonProperty("purpose")]
        public TaskPurpose? Purpose { get; set; }
        
        [JsonProperty("customerMessage")]
        public string? CustomerMessage { get; set; }
        
        [JsonProperty("usePreferred")]
        public bool? UsePreferred { get; set; }
        
        [JsonProperty("editService")]
        public bool? EditService { get; set; }
        
        [JsonProperty("labelIds")]
        public ICollection<int>? LabelIds { get; set; }
        
        [JsonProperty("dateFrom")]
        public DateTimeOffset? DateFrom { get; set; }
        
        [JsonProperty("dateTo")]
        public DateTimeOffset? DateTo { get; set; }
        
        [PublicAPI]
        public enum TaskExpertise
        {
            [Description("standard")]
            Standard,
        
            [Description("pro")]
            Pro
        }

        [PublicAPI]
        [StrictStringRepresentation]
        public enum TaskTone
        {
            [Description("")]
            NotSet,
        
            Informal,
            Friendly,
            Business,
            Formal,
        
            [Description("other")]
            Other
        }
        
        [PublicAPI]
        public enum TaskPurpose
        {
            [Description("standard")]
            Standard,
        
            [Description("Personal use")]
            PersonalUse,
        
            [Description("Business")]
            Business,
        
            [Description("Online content")]
            OnlineContent,
        
            [Description("App/Web localization")]
            AppWebLocalization,
        
            [Description("Media content")]
            MediaContent,
        
            [Description("Semi-technical")]
            SemiTechnical,
        
            [Description("other")]
            Other
        }
    }
}