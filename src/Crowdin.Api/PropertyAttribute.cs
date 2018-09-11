using System;

namespace Crowdin.Api
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
