
using JetBrains.Annotations;

using Crowdin.Api.Core;
using Crowdin.Api.Core.Converters;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    [CallToStringForSerialization]
    public class MatchTypeObject
    {
        public string Value { get; }
        
        private MatchTypeObject(string value)
        {
            Value = value;
        }

        public static MatchTypeObject FromCustomRange(int from, int to)
        {
            return new MatchTypeObject($"{from}-{to}");
        }

        public static MatchTypeObject FromStaticRange(MatchType staticRange)
        {
            return new MatchTypeObject(staticRange.ToDescriptionString());
        }

        public static implicit operator MatchTypeObject(MatchType staticValue)
        {
            return FromStaticRange(staticValue);
        }

        public override string ToString()
        {
            return Value;
        }
    }
}