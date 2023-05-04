
using System;
using System.Linq;

using Crowdin.Api.Tests.Core;
using Crowdin.Api.Webhooks;

using Newtonsoft.Json;
using Xunit;

namespace Crowdin.Api.Tests.Webhooks
{
    public class WebhookEventTypeTests
    {
        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public void ShouldAllEventsBeUnique()
        {
            var serializedEvents = Enum.GetValues<EventType>()
                .Select(e => JsonConvert.SerializeObject(e, DefaultSettings))
                .ToArray();

            Assert.Equal(serializedEvents.Length, serializedEvents.Distinct().Count());
        }
    }
}
