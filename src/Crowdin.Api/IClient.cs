using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Crowdin.Api.Protocol;

namespace Crowdin.Api
{
	public interface IClient
	{
		Task<HttpResponseMessage> SendApiRequest(String url, Credentials credentials, Object body = null, ResponseType responseType = ResponseType.Xml, CancellationToken cancellationToken = default);
	}
}