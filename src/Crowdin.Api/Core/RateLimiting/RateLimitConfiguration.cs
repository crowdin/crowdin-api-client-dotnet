
using System;

namespace Crowdin.Api.Core.RateLimiting
{
    public class RateLimitConfiguration
    {
        public int MaxAttempts { get; set; }
            
        public TimeSpan InitialDelay { get; set; }
            
        public TimeSpan MaxDelay { get; set; }
    }
}