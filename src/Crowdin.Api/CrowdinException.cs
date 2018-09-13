using System;
using System.Runtime.InteropServices;

namespace Crowdin.Api
{
    public sealed class CrowdinException : ExternalException
    {
        public CrowdinException(String message, Int32 errorCode) : base(message, errorCode)
        { }
    }
}
