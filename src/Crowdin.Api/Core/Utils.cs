
using System.Collections.Generic;
using System.Net;

using Newtonsoft.Json;

using Crowdin.Api.Core.Converters;

#nullable enable

namespace Crowdin.Api.Core
{
    internal static class Utils
    {
        internal static IDictionary<string, string> CreateQueryParamsFromPaging(int limit, int offset)
        {
            return new Dictionary<string, string>
            {
                { "limit", limit.ToString() },
                { "offset", offset.ToString() }
            };
        }

        internal static void ThrowIfStatusNot204(HttpStatusCode statusCode, string message)
        {
            if (statusCode != HttpStatusCode.NoContent)
            {
                throw new CrowdinApiException(message);
            }
        }

        internal static JsonSerializerSettings CreateJsonSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Converters =
                {
                    new ReportMatchTypeObjectConverter(),
                    new DescriptionEnumConverter(),
                    new FileExportOptionsConverter(),
                    new FileImportOptionsConverter(),
                    new FileInfoConverter(),
                    new LanguageTranslationsConverter(),
                    new ToStringConverter(),
                    new ProjectFileFormatSettingsConverter(),
                    new ProjectStringsExporterSettingsConverter(),
                    new ReportSettingsTemplateConverter(),
                    new WorkflowStepConverter(),
                    new FieldConfigConverter(),
                    new AiPromptConfigurationConverter(),
                    new AiProviderCredentialsConverter(),
                    new SourceStringConverter()
                }
            };
        }
    }
}