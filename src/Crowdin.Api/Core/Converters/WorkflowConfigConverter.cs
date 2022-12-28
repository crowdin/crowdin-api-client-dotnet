
using System;
using Crowdin.Api.Workflows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

#nullable enable

namespace Crowdin.Api.Core.Converters
{
    public class WorkflowStepConverter : JsonConverter<WorkflowStep>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, WorkflowStep? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override WorkflowStep? ReadJson(
            JsonReader reader, Type objectType, WorkflowStep? existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            
            existingValue ??= jObject.ToObject<WorkflowStep>();
            if (existingValue is null) return null;
            
            Type? typeToConvert = existingValue.Type switch
            {
                WorkflowStepType.Translate =>
                    typeof(WorkflowTranslationConfig),
                
                WorkflowStepType.Proofread =>
                    typeof(WorkflowProofreadingConfig),
                
                WorkflowStepType.TranslateByVendor =>
                    typeof(WorkflowTranslationByVendorConfig),
                
                WorkflowStepType.ProofreadByVendor =>
                    typeof(WorkflowProofreadingByVendorConfig),
                
                WorkflowStepType.TmPreTranslate =>
                    typeof(WorkflowTmPreTranslationConfig),
                
                WorkflowStepType.MachinePreTranslate =>
                    typeof(WorkflowMtPreTranslationConfig),
                
                WorkflowStepType.CrowdSource =>
                    typeof(WorkflowCrowdsourcingConfig),
                
                _ => null
            };

            if (typeToConvert != null)
            {
                var configRawObject = (JObject) jObject["config"]!;
                var configRawObjectJson = configRawObject.ToString();
                
                existingValue.Config = JsonConvert.DeserializeObject(configRawObjectJson, typeToConvert);
            }
            else
            {
                existingValue.Config = Array.Empty<object>();
            }

            return existingValue;
        }
    }
}