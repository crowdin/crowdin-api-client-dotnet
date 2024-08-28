
using System;
using Crowdin.Api.Core;
using JetBrains.Annotations;

namespace Crowdin.Api
{
    [PublicAPI]
    public class SortingRule
    {
        public string Field { get; set; }
        
        public SortingOrder? Order { get; set; }
        
        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(Field))
            {
                throw new ArgumentNullException(nameof(Field), $"Field is required");
            }
            
            return Field + (Order.HasValue ? " " + Order.Value.ToDescriptionString() : string.Empty);
        }
    }
}