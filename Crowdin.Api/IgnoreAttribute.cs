using System;

namespace Crowdin.Api
{
    [AttributeUsage(AttributeTargets.Property)]
    internal sealed class IgnoreAttribute : Attribute
    { }
}
