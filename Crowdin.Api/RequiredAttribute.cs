using System;

namespace Crowdin.Api
{
    [AttributeUsage(AttributeTargets.Property)]
    internal sealed class RequiredAttribute : Attribute
    { }
}
