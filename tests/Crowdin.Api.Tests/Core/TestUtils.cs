
using Crowdin.Api;
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
                    new ToStringConverter(),
                }
            };
        }
    }
}