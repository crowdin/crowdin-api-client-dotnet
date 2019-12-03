using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Crowdin.Api.Protocol;
using Crowdin.Api.Typed;
using Moq;
using Xunit;

namespace Crowdin.Api.Tests
{
	public class ClientExtensionsTests
	{
		[Fact]
		public async void GetSupportedLanguagesValidResponseReturnsList()
		{
            var supportedLanguageXml =
                @"<?xml version=""1.0"" encoding=""UTF-8""?>
                <languages>
                  <language>
                    <name>Romanian</name>
                    <crowdin_code>ro</crowdin_code>
                    <editor_code>ro</editor_code>
                    <iso_639_1>ro</iso_639_1>
                    <iso_639_3>ron</iso_639_3>
                    <locale>ro-RO</locale>
                    <android_code>ro-rRO</android_code>
                    <osx_code>ro.lproj</osx_code>
                    <osx_locale>ro</osx_locale>
                  </language>
                  <language>
                    <name>French</name>
                    <crowdin_code>fr</crowdin_code>
                    <editor_code>fr</editor_code>
                    <iso_639_1>fr</iso_639_1>
                    <iso_639_3>fra</iso_639_3>
                    <locale>fr-FR</locale>
                    <android_code>fr-rFR</android_code>
                    <osx_code>fr.lproj</osx_code>
                    <osx_locale>fr</osx_locale>
                  </language>
                </languages>";

            var httpResponse = new HttpResponseMessage(HttpStatusCode.Accepted);
            httpResponse.Content = new StringContent(supportedLanguageXml, System.Text.Encoding.UTF8, "text/xml");

            var mockClient = new Mock<IClient>();
			mockClient.Setup(x => x.SendApiRequest(It.Is<string>(s => s.Equals("supported-languages")),
					It.IsAny<Credentials>(), It.IsAny<object>(), ResponseType.Xml, It.IsAny<CancellationToken>()))
				.Returns(Task.FromResult(httpResponse));
			var languageInfo = await mockClient.Object.GetSupportedLanguages();
            Assert.Equal(2, languageInfo.Count);
            Assert.Equal("Romanian", languageInfo[0].Name);
		}
	}
}
