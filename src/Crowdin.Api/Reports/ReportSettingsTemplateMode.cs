
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public enum ReportSettingsTemplateMode
    {
        [SerializedValue("simple")]
        Simple,
        
        [SerializedValue("fuzzy")]
        Fuzzy
    }
}