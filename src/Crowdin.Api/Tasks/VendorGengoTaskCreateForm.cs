
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
        
        [JsonProperty("branchIds")]
        public ICollection<int>? BranchIds { get; set; }
        
        [JsonProperty("fileIds")]
        public ICollection<int>? FileIds { get; set; }
        
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
            [SerializedValue("standard")]
            Standard,
        
            [SerializedValue("pro")]
            Pro
        }

        [PublicAPI]
        [StrictStringRepresentation]
        public enum TaskTone
        {
            [SerializedValue("")]
            NotSet,
        
            Informal,
            Friendly,
            Business,
            Formal,
        
            [SerializedValue("other")]
            Other
        }
        
        [PublicAPI]
        public enum TaskPurpose
        {
            [SerializedValue("standard")]
            Standard,
        
            [SerializedValue("Personal use")]
            PersonalUse,
        
            [SerializedValue("Business")]
            Business,
        
            [SerializedValue("Online content")]
            OnlineContent,
        
            [SerializedValue("App/Web localization")]
            AppWebLocalization,
        
            [SerializedValue("Media content")]
            MediaContent,
        
            [SerializedValue("Semi-technical")]
            SemiTechnical,
        
            [SerializedValue("other")]
            Other
        }
    }
}