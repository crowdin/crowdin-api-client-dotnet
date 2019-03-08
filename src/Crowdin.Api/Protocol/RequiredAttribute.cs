using System;

namespace Crowdin.Api.Protocol
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class RequiredAttribute : Attribute
    { }
}
