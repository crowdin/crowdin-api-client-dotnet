
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Crowdin.Api.Core.RateLimiting
{
    public class ExponentialBackoffRateLimiter : IRateLimiter
    {
        private readonly RateLimitConfiguration _configuration;
        private readonly Random _random = new Random();

        public ExponentialBackoffRateLimiter(RateLimitConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<HttpResponseMessage> ExecuteRequest(Func<int, Task<HttpResponseMessage>> runRequest)
        {
            var attempts = 0;

            while (attempts < _configuration.MaxAttempts)
            {
                int requestId = attempts + 1;
                HttpResponseMessage responseMessage = await runRequest(requestId);

                if (responseMessage.StatusCode != (HttpStatusCode) 429)
                {
                    return responseMessage;
                }
                
                TimeSpan delay = GetDelayTime(attempts);

                if (delay > _configuration.MaxDelay)
                {
                    throw new RateException("Maximum delay time exceeded.");
                }

                await Task.Delay(delay);
                attempts++;
            }

            throw new RateException("Rate limit exceeded");
        }
        
        private TimeSpan GetDelayTime(int attempts)
        {
            var backoff = (int) Math.Pow(2, attempts);
            
            int delay = _random.Next(
                (int) _configuration.InitialDelay.TotalMilliseconds,
                (int) _configuration.MaxDelay.TotalMilliseconds);
            
            return TimeSpan.FromMilliseconds(backoff + delay);
        }
    }
}