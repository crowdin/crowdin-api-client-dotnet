
using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Crowdin.Api.Core.Resilience
{
    [PublicAPI]
    public class RetryConfiguration
    {
        public int RetriesCount { get; set; }
        
        public int WaitIntervalMilliseconds { get; set; }

        public ICollection<Predicate<Exception>> SkipRetryConditions { get; set; } = new List<Predicate<Exception>>();
    }
}