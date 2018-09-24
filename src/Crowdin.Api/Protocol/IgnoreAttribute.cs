using System;

namespace Crowdin.Api.Protocol
{
    [AttributeUsage(AttributeTargets.Property)]
    internal sealed class IgnoreAttribute : Attribute
    { }
}
