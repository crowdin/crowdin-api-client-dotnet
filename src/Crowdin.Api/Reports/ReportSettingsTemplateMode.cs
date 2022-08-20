
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public enum ReportSettingsTemplateMode
    {
        [Description("simple")]
        Simple,
        
        [Description("fuzzy")]
        Fuzzy
    }
}