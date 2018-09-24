using System;

namespace Crowdin.Api.Protocol
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    internal sealed class PropertyAttribute : Attribute
    {
        public PropertyAttribute(String name)
        {
            Name = name;
        }

        public String Name { get; }
    }
}
