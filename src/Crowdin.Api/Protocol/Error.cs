using System;
using Newtonsoft.Json;

namespace Crowdin.Api.Protocol
{
    internal sealed class Error
    {
        [JsonProperty("code")]
        public Int32 Code { get; private set; }

        [JsonProperty("message")]
        public String Message { get; private set; }
    }
}
