
using System;
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api
{
    [PublicAPI]
    public class CrowdinApiException : Exception
    {
        public int? Code { get; }
        
        public object? Related { get; }

        public CrowdinApiException(string message) : base(message)
        {
            
        }
        
        public CrowdinApiException(int code, string message) : this(message)
        {
            Code = code;
        }

        public CrowdinApiException(string message, object? related) : this(message)
        {
            Related = related;
        }
    }
}