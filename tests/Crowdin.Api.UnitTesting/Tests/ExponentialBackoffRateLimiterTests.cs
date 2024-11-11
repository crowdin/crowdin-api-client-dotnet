
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Xunit;
using Xunit.Abstractions;

using Crowdin.Api.Core.RateLimiting;

namespace Crowdin.Api.UnitTesting.Tests
{
    public class ExponentialBackoffRateLimiterTests
    {
        private readonly IRateLimiter _rateLimiter;
        private readonly ITestOutputHelper _testOutputHelper;

        public ExponentialBackoffRateLimiterTests(ITestOutputHelper testOutputHelper)
        {
            _rateLimiter = new ExponentialBackoffRateLimiter(new RateLimitConfiguration
            {
                MaxAttempts = 10,
                MaxDelay = TimeSpan.FromSeconds(5),
                InitialDelay = TimeSpan.FromMilliseconds(100)
            });

            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public async Task SingleSuccessRequest()
        {
            var codes = new[] { HttpStatusCode.OK };

            await RunFakeRequestsAndAssert(codes, expectedAttemptsCount: 1);
        }

        [Fact]
        public async Task OneRateLimitErrorOccurred()
        {
            var codes = new[] { (HttpStatusCode)429, HttpStatusCode.OK };

            await RunFakeRequestsAndAssert(codes, expectedAttemptsCount: 2);
        }

        [Fact]
        public async Task MultiRateLimitErrorOccurred()
        {
            var codes = new[]
            {
                (HttpStatusCode) 429,
                (HttpStatusCode) 429,
                (HttpStatusCode) 429,
                HttpStatusCode.OK
            };

            await RunFakeRequestsAndAssert(codes, expectedAttemptsCount: 4);
        }

        // ReSharper disable once SuggestBaseTypeForParameter
        private async Task RunFakeRequestsAndAssert(HttpStatusCode[] attemptResults, int expectedAttemptsCount)
        {
            var actualAttemptsCount = 0;

            HttpResponseMessage? theLastResponse =
                await _rateLimiter.ExecuteRequest(async requestId =>
                {
                    _testOutputHelper.WriteLine("Executing request №{0}", requestId);
                    actualAttemptsCount++;

                    return await CreateResponseMessage(attemptResults[requestId - 1]);
                });

            Assert.Equal(HttpStatusCode.OK, theLastResponse.StatusCode);
            Assert.Equal(expectedAttemptsCount, actualAttemptsCount);
        }

        private static Task<HttpResponseMessage> CreateResponseMessage(HttpStatusCode code)
        {
            return Task.FromResult(new HttpResponseMessage(code));
        }
    }
}