
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Crowdin.Api.UnitTesting.Resources;

namespace Crowdin.Api.UnitTesting.Tests
{
    public class ErrorDeserializationTests
    {
        [Fact]
        public async Task Code_400_InvalidRequestParameters()
        {
            HttpResponseMessage response = CreateResponseMessage(
                HttpStatusCode.BadRequest,
                Core_ErrorResponses.Code_400_InvalidRequestParameters);

            var exception =
                await Assert.ThrowsAsync<CrowdinApiException>(() =>
                    CrowdinApiClient.CheckDefaultPreconditionsAndErrors(response));

            Assert.StartsWith("Invalid Request Parameters", exception.Message);
            Assert.Contains("Key [keyHere]: Invalid type given. String expected", exception.Message);

            Assert.IsType<ErrorResource[]>(exception.Related);

            ErrorResource? selector = (exception.Related as ErrorResource[])?.First();
            Assert.NotNull(selector);
            Assert.Equal("keyHere", selector!.Key);

            AttributeError? error = selector.Errors?.First();
            Assert.NotNull(error);
            Assert.Equal("StringTypeInvalid", error!.Code);
            Assert.Equal("Invalid type given. String expected", error.Message);
        }

        [Fact]
        public async Task Code_405_MethodNotAllowed()
        {
            HttpResponseMessage response = CreateResponseMessage(
                HttpStatusCode.MethodNotAllowed,
                Core_ErrorResponses.Code_405_MethodNotAllowed);

            var exception =
                await Assert.ThrowsAsync<CrowdinApiException>(() =>
                    CrowdinApiClient.CheckDefaultPreconditionsAndErrors(response));

            Assert.Equal("Method Not Allowed", exception.Message);
            Assert.Equal((int)HttpStatusCode.MethodNotAllowed, exception.Code);
        }

        private static HttpResponseMessage CreateResponseMessage(HttpStatusCode statusCode, string jsonString)
        {
            return new HttpResponseMessage
            {
                StatusCode = statusCode,
                Content = new StringContent(jsonString, Encoding.UTF8, MediaTypeNames.Application.Json)
            };
        }
    }
}