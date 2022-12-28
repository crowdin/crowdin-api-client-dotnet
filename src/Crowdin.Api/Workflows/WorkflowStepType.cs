
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Workflows
{
    [PublicAPI]
    public enum WorkflowStepType
    {
        [Description("Start")]
        Start,
        
        [Description("Crowdsource")]
        CrowdSource,
        
        [Description("CustomCode")]
        CustomCode,
        
        [Description("MachinePreTranslate")]
        MachinePreTranslate,
        
        [Description("ProofreadByVendor")]
        ProofreadByVendor,
        
        [Description("Proofread")]
        Proofread,
        
        [Description("SourceTextReview")]
        SourceTextReview,
        
        [Description("SwitchLanguage")]
        SwitchLanguage,
        
        [Description("TMPreTranslate")]
        TmPreTranslate,
        
        [Description("TranslateByApiVendor")]
        TranslateByApiVendor,
        
        [Description("TranslateByVendor")]
        TranslateByVendor,
        
        [Description("Translate")]
        Translate,
        
        [Description("End")]
        End
    }
}