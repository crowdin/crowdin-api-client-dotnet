
using System;
using System.Collections.Generic;
using System.Linq;

using Crowdin.Api.Core;
using Crowdin.Api.Core.Converters;

using Moq;
using Newtonsoft.Json;

namespace Crowdin.Api.Tests.Core
{
    public static class TestUtils
    {
        public static Mock<ICrowdinApiClient> CreateMockClientWithDefaultParser()
        {
            Mock<ICrowdinApiClient> mockClient = CreateMockClient();

            mockClient
                .Setup(client => client.DefaultJsonParser)
                .Returns(CreateJsonParser);
            
            return mockClient;
        }

        public static Mock<ICrowdinApiClient> CreateMockClient()
        {
            return new Mock<ICrowdinApiClient>();
        }

        public static IJsonParser CreateJsonParser()
        {
            return new JsonParser(CreateJsonSerializerOptions());
        }

        public static JsonSerializerSettings CreateJsonSerializerOptions()
        {
            return new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Converters =
                {
                    new DescriptionEnumConverter(),
                    new FileExportOptionsConverter(),
                    new FileImportOptionsConverter(),
                    new FileInfoConverter(),
                    new LanguageTranslationsConverter(),
                    new ToStringConverter(),
                    new ReportSettingsTemplateConverter()
                }
            };
        }
        
        public static string ToQueryString(this IDictionary<string, string> queryParams)
        {
            return string.Join("&", queryParams.Select(kvPair => $"{kvPair.Key}={kvPair.Value}"));
        }
        
        public static string CompactJson(string jsonToCompact, JsonSerializerSettings? settings = null)
        {
            settings ??= CreateJsonSerializerOptions();
            
            object? dataFromJson = JsonConvert.DeserializeObject(jsonToCompact, settings);

            if (dataFromJson is null)
            {
                throw new ArgumentNullException(nameof(dataFromJson));
            }

            return JsonConvert.SerializeObject(dataFromJson, settings);
        }
        
        public static IDictionary<string, string> CreateQueryParamsFromPaging(int limit = 25, int offset = 0)
        {
            return new Dictionary<string, string>
            {
                { "limit", limit.ToString() },
                { "offset", offset.ToString() }
            };
        }
    }
}