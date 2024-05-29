
using System;

namespace Crowdin.Api
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class SerializedValueAttribute : Attribute
    {
        public string Name { get; }
        
        public SerializedValueAttribute(string name)
        {
            Name = name;
        }
    }
}