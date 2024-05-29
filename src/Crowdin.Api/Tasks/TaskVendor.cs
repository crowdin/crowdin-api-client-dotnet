
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public enum TaskVendor
    {
        // ReSharper disable IdentifierTypo
        
        [SerializedValue("alconost")]
        Alconost,
        
        [SerializedValue("babbleon")]
        BabbleOn,
        
        [SerializedValue("tomedes")]
        Tomedes,
        
        [SerializedValue("e2f")]
        E2F,
        
        [SerializedValue("write_path_admin")]
        WritePath,
        
        [SerializedValue("inlingo")]
        Inlingo,
        
        [SerializedValue("acclaro")]
        Acclaro,
        
        [SerializedValue("translate_by_humans")]
        TranslateByHumans,
        
        [SerializedValue("lingo24")]
        Lingo24,
        
        [SerializedValue("assertio_language_services")]
        AssertioLanguageServices,
        
        [SerializedValue("gte_localize")]
        GteLocalize,
        
        [SerializedValue("kettu_solutions")]
        KettuSolutions,
        
        [SerializedValue("languageline_solutions")]
        LanguageLineTranslationSolutions
        
        // ReSharper restore IdentifierTypo
    }
}