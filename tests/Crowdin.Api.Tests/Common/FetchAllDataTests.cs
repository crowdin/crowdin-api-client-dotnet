
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Crowdin.Api.Tests.Common
{
    public class FetchAllDataTests
    {
        private static readonly int[] ArrayOfNumbers;
        
        static FetchAllDataTests()
        {
            var i = 0;
            ArrayOfNumbers = new int[50].Select(_ => ++i).ToArray();
        }

        [Fact]
        public async Task AmountPerRequest_RequestsCount_1()
        {
            const int maxAmountPerRequest = 51;
            const int expectedExecutionsCount = 1;
            await RunRequestsAndCheckCountOrThrow(expectedExecutionsCount, maxAmountPerRequest);
        }

        [Fact]
        public async Task AmountPerRequest_RequestsCount_2()
        {
            const int maxAmountPerRequest = 26;
            const int expectedExecutionsCount = 2;
            await RunRequestsAndCheckCountOrThrow(expectedExecutionsCount, maxAmountPerRequest);
        }

        [Fact]
        public async Task AmountPerRequest_RequestsCount_50()
        {
            const int maxAmountPerRequest = 1;
            const int expectedExecutionsCount = 51;
            await RunRequestsAndCheckCountOrThrow(expectedExecutionsCount, maxAmountPerRequest);
        }

        [Fact]
        public async Task MaxAmountOfItems_RequestsCount_1()
        {
            const int expectedItemsCount = 20;
            const int expectedExecutionsCount = 1;

            await RunRequestsAndCheckCountOrThrow(expectedExecutionsCount, maxAmountOfItems: expectedItemsCount);
        }
        
        [Fact]
        public async Task MaxAmountOfItems_RequestsCount_2()
        {
            const int expectedItemsCount = 40;
            const int expectedExecutionsCount = 2;

            await RunRequestsAndCheckCountOrThrow(expectedExecutionsCount, maxAmountOfItems: expectedItemsCount);
        }
        
        [Fact]
        public async Task MaxAmountOfItems_RequestsCount_50()
        {
            const int expectedItemsCount = 50;
            const int amountOfItemsPerRequest = 1;
            const int expectedExecutionsCount = 50;

            await RunRequestsAndCheckCountOrThrow(expectedExecutionsCount, amountOfItemsPerRequest, expectedItemsCount);
        }

        private static async Task RunRequestsAndCheckCountOrThrow(
            int executionsCountLimit,
            int amountPerRequest = 25,
            int? maxAmountOfItems = null)
        {
            int[] expectedArray =
                maxAmountOfItems < ArrayOfNumbers.Length
                    ? ArrayOfNumbers.Take(maxAmountOfItems.Value).ToArray()
                    : ArrayOfNumbers;
            
            var executionsCounter = 0;
            
            int[] actualArray = await CrowdinApiClient.WithFetchAll((limit, offset) =>
            {
                executionsCounter++;
                
                if (executionsCounter > executionsCountLimit)
                {
                    throw new Exception("No subsequent requests allowed");
                }
                
                return Task.FromResult(new ResponseList<int>
                {
                    Data = ArrayOfNumbers.Skip(offset).Take(limit).ToList()
                });
            }, maxAmountOfItems, amountPerRequest);
            
            Assert.Equal(expectedArray.Length, actualArray.Length);
            Assert.Equal(expectedArray, actualArray);
        }
    }
}