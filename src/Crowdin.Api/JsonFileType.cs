
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api
{
    [PublicAPI]
    public enum JsonFileType
    {
        [SerializedValue("i18next_json")]
        I18NextJson,
        
        [SerializedValue("nestjs_i18n")]
        NestJsI18N
    }
}