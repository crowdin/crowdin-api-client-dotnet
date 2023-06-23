
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api
{
    [PublicAPI]
    public enum JsonFileType
    {
        [Description("i18next_json")]
        I18NextJson,
        
        [Description("nestjs_i18n")]
        NestJsI18N
    }
}