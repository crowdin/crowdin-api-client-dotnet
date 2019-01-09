using System;

namespace Crowdin.Api
{
    public sealed class AccountCredentials : Credentials
    {
        public String LoginName { get; set; }

        public String AccountKey { get; set; }
    }
}
