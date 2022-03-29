
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdin.Api.Core.Resilience
{
    public interface IRetryService
    {
        Task<T> ExecuteRequestAsync<T>(Func<Task<T>> func);
    }
    
    public class RetryService : IRetryService
    {
        private readonly RetryConfiguration _configuration;

        public RetryService(RetryConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<T> ExecuteRequestAsync<T>(Func<Task<T>> func)
        {
            for (var i = 0; i <= _configuration.RetriesCount; i++)
            {
                try
                {
                    return await func();
                }
                catch (Exception exception)
                {
                    bool skip = _configuration.SkipRetryConditions.Any(condition => condition(exception));
                    if (skip || i == _configuration.RetriesCount)
                    {
                        throw;
                    }

                    await Task.Delay(_configuration.WaitIntervalMilliseconds);
                }
            }

            throw new Exception("Wrong retry configuration. Failed to get value");
        }
    }
}