
using System;
using System.Threading.Tasks;
using Crowdin.Api.Core.Resilience;
using Xunit;

namespace Crowdin.Api.UnitTesting.Tests.Common
{
    public class RetryServiceTests
    {
        [Fact]
        public async Task ShouldNotRetry()
        {
            var retryService = new RetryService(new RetryConfiguration
            {
                RetriesCount = 5,
                WaitIntervalMilliseconds = 150
            });

            const int expectedResult = 1;
            int actualResult = await retryService.ExecuteRequestAsync(() => Task.FromResult(expectedResult));
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public async Task ShouldRetryOnce()
        {
            const int result = 1;
            var isExecuted = false;

            async Task<int> Function()
            {
                await Task.Delay(20);

                if (!isExecuted)
                {
                    isExecuted = true;
                    throw new Exception("error");
                }

                return result;
            }

            var retryService = new RetryService(new RetryConfiguration
            {
                RetriesCount = 5,
                WaitIntervalMilliseconds = 150
            });

            int executedResult = await retryService.ExecuteRequestAsync(Function);
            Assert.Equal(result, executedResult);
        }

        [Fact]
        public async Task ShouldFailByRetryCount()
        {
            async Task<int> Function()
            {
                await Task.Delay(50);
                throw new Exception("error");
            }

            var retryService = new RetryService(new RetryConfiguration
            {
                RetriesCount = 5,
                WaitIntervalMilliseconds = 150
            });

            await Assert.ThrowsAsync<Exception>(() => retryService.ExecuteRequestAsync(Function));
        }

        [Fact]
        public async Task ShouldFailByRetryConditions()
        {
            const int errorCode = 10;

            async Task<int> Function()
            {
                await Task.Delay(20);
                throw new CrowdinApiException(errorCode, "error");
            }

            var retryService = new RetryService(new RetryConfiguration
            {
                RetriesCount = 5,
                WaitIntervalMilliseconds = 150,
                SkipRetryConditions =
                {
                    exception => ((CrowdinApiException) exception).Code.GetValueOrDefault() == errorCode
                }
            });

            await Assert.ThrowsAsync<CrowdinApiException>(() => retryService.ExecuteRequestAsync(Function));
        }
    }
}