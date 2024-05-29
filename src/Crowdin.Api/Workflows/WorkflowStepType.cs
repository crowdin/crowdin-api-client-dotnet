
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Workflows
{
    [PublicAPI]
    public enum WorkflowStepType
    {
        [SerializedValue("Start")]
        Start,
        
        [SerializedValue("Crowdsource")]
        CrowdSource,
        
        [SerializedValue("CustomCode")]
        CustomCode,
        
        [SerializedValue("MachinePreTranslate")]
        MachinePreTranslate,
        
        [SerializedValue("ProofreadByVendor")]
        ProofreadByVendor,
        
        [SerializedValue("Proofread")]
        Proofread,
        
        [SerializedValue("SourceTextReview")]
        SourceTextReview,
        
        [SerializedValue("SwitchLanguage")]
        SwitchLanguage,
        
        [SerializedValue("TMPreTranslate")]
        TmPreTranslate,
        
        [SerializedValue("TranslateByApiVendor")]
        TranslateByApiVendor,
        
        [SerializedValue("TranslateByVendor")]
        TranslateByVendor,
        
        [SerializedValue("Translate")]
        Translate,
        
        [SerializedValue("End")]
        End
    }
}