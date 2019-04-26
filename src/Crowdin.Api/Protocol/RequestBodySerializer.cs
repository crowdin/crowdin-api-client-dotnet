using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Crowdin.Api.Protocol
{
    internal static class RequestBodySerializer
    {
        public static IEnumerable<(String, Object)> Serialize(Object body)
        {
            Type bodyType = body.GetType();
            return bodyType
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(ConsiderProperty)
                .Select(property => (property.ResolveMemberName().ToLower(), GetPropertyValue(body, property)))
                .SelectMany(ExpandMember);
        }

        private static IEnumerable<(String, Object)> ExpandMember(this (String Name, Object Value) member)
        {
            return member.Value
                .ExpandValue()
                .Select(item => (member.Name + item.Name, item.Value));
        }

        private static IEnumerable<(String Name, Object Value)> ExpandValue(this Object value)
        {
            switch (value)
            {
                case null:
                    return Enumerable.Empty<(String, Object)>();

                case Boolean typedValue:
                    return typedValue.Expand();

                case DateTime typedValue:
                    return typedValue.Expand();

                case Enum typedValue:
                    return typedValue.Expand();

                case StringDictionary typedValue:
                    return typedValue.Expand();

                case IDictionary typedValue:
                    return typedValue.Expand();

                case IEnumerable typedValue when !(typedValue is String):
                    return typedValue.Expand();

                case var obj when (Type.GetTypeCode(obj.GetType()) == TypeCode.Object) && !(obj is FileInfo):
                    return obj.Expand();

                default:
                    return new[] { (String.Empty, value) };
            }
        }

        private static IEnumerable<(String, Object)> Expand(this Boolean value)
        {
            yield return (String.Empty, value ? 1 : 0);
        }

        private static IEnumerable<(String, Object)> Expand(this DateTime value)
        {
            yield return (String.Empty, value.ToString("s"));
        }

        private static IEnumerable<(String, Object)> Expand(this Enum value)
        {
            Type enumType = value.GetType();
            var asNumber = (AsNumberAttribute)Attribute.GetCustomAttribute(enumType, typeof(AsNumberAttribute));
            Object resolvedValue;
            if (asNumber != null)
            {
                resolvedValue = Convert.ChangeType(value, Enum.GetUnderlyingType(enumType));
            }
            else
            {
                FieldInfo enumField = enumType.GetField(value.ToString());
                resolvedValue = ResolveMemberName(enumField).ToLower();
            }

            yield return (String.Empty, resolvedValue);
        }

        private static IEnumerable<(String, Object)> Expand(this StringDictionary value)
        {
            return value.Keys.Cast<String>()
                .Select(key => ($"[{key}]", (Object)value[key]))
                .SelectMany(ExpandMember);
        }

        private static IEnumerable<(String, Object)> Expand(this IDictionary value)
        {
            return value.Keys.Cast<Object>()
                .Select(key => ($"[{key}]", value[key]))
                .SelectMany(ExpandMember);
        }

        private static IEnumerable<(String, Object)> Expand(this IEnumerable value)
        {
            return value.Cast<Object>()
                .Select((item, index) => ($"[{index}]", item))
                .SelectMany(ExpandMember);
        }

        private static IEnumerable<(String, Object)> Expand(this Object value)
        {
            Type type = value.GetType();
            return type
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(ConsiderProperty)
                .Select(property => ($"[{property.ResolveMemberName().ToLower()}]", property.GetValue(value)))
                .SelectMany(ExpandMember);
        }

        private static Boolean ConsiderProperty(this PropertyInfo property)
        {
            if (!property.CanRead)
            {
                return false;
            }

            var attribute = (IgnoreAttribute) Attribute.GetCustomAttribute(property, typeof(IgnoreAttribute));
            return attribute == null;
        }

        private static String ResolveMemberName(this MemberInfo member)
        {
            var attribute = (PropertyAttribute) Attribute.GetCustomAttribute(member, typeof(PropertyAttribute));
            return attribute?.Name ?? member.Name;
        }

        private static Object GetPropertyValue(Object obj, PropertyInfo property)
        {
            var required = (RequiredAttribute) Attribute.GetCustomAttribute(property, typeof(RequiredAttribute));
            Object value = property.GetValue(obj);
            if (required == null)
            {
                return value;
            }

            return value ?? throw new ArgumentException("Value is required.", property.Name);
        }
    }
}
