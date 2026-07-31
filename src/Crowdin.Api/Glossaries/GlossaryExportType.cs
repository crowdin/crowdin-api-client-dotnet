
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public enum GlossaryExportType
    {
        [Description("concepts")]
        Concepts,

        [Description("terms")]
        Terms
    }
}
