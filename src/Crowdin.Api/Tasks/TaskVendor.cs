
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public enum TaskVendor
    {
        // ReSharper disable IdentifierTypo
        
        [Description("alconost")]
        Alconost,
        
        [Description("babbleon")]
        BabbleOn,
        
        [Description("tomedes")]
        Tomedes,
        
        [Description("e2f")]
        E2F,
        
        [Description("write_path_admin")]
        WritePath,
        
        [Description("inlingo")]
        Inlingo,
        
        [Description("acclaro")]
        Acclaro,
        
        [Description("translate_by_humans")]
        TranslateByHumans,
        
        [Description("lingo24")]
        Lingo24,
        
        [Description("assertio_language_services")]
        AssertioLanguageServices,
        
        [Description("gte_localize")]
        GteLocalize,
        
        [Description("kettu_solutions")]
        KettuSolutions,
        
        [Description("languageline_solutions")]
        LanguageLineTranslationSolutions,
        
        [Description("crowdin_language_service")]
        CrowdinLanguageServices
        
        // ReSharper restore IdentifierTypo
    }
}