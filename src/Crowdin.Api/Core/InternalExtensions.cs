
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

#nullable enable

namespace Crowdin.Api.Core
{
    internal static class InternalExtensions
    {
        internal static async Task<JObject> ParseJsonBodyAsync(this HttpContent content)
        {
            string responseJson = await content.ReadAsStringAsync();
            return JObject.Parse(responseJson);
        }
        
        internal static string ToDescriptionString(this Enum? path)
        {
            var attribute = path?
                .GetType()
                .GetField(path.ToString())
                .GetCustomAttribute<DescriptionAttribute>(false);
            
            return attribute != null ? attribute.Description : string.Empty;
        }
        
        internal static string ToQueryString(this IDictionary<string, string> queryParams)
        {
            return string.Join("&", queryParams.Select(kvPair => $"{kvPair.Key}={kvPair.Value}"));
        }
        
        internal static void AddParamIfPresent(this IDictionary<string, string> queryParams, string key, int? value)
        {
            if (value.HasValue)
            {
                queryParams.AddParamIfPresent(key, value.ToString());
            }
        }
        
        internal static void AddParamIfPresent(this IDictionary<string, string> queryParams, string key, long? value)
        {
            if (value.HasValue)
            {
                queryParams.AddParamIfPresent(key, value.ToString());
            }
        }
        
        internal static void AddParamIfPresent(this IDictionary<string, string> queryParams, string key, bool? value)
        {
            if (value.HasValue)
            {
                queryParams.AddParamIfPresent(key, value.ToString().ToLower());
            }
        }
        
        internal static void AddParamIfPresent(this IDictionary<string, string> queryParams, string key, object? value)
        {
            if (value != null)
            {
                queryParams.AddParamIfPresent(key, value.ToString());
            }
        }
        
        internal static void AddParamIfPresent(this IDictionary<string, string> queryParams, string key, string? value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                queryParams.Add(key, value!);
            }
        }
        
        internal static void AddParamIfPresent(this IDictionary<string, string> queryParams, string key, IEnumerable<int>? values)
        {
            if (values != null && values.Any())
            {
                queryParams.Add(key, string.Join(",", values.Select(value => value.ToString())));
            }
        }
        
        internal static void AddParamIfPresent(this IDictionary<string, string> queryParams, string key, IEnumerable<long>? values)
        {
            if (values != null && values.Any())
            {
                queryParams.Add(key, string.Join(",", values.Select(value => value.ToString())));
            }
        }
        
        internal static void AddParamIfPresent(this IDictionary<string, string> queryParams, string key, IEnumerable<bool>? values)
        {
            if (values != null && values.Any())
            {
                queryParams.Add(key, string.Join(",", values.Select(value => value.ToString().ToLower())));
            }
        }
        
        internal static void AddParamIfPresent(this IDictionary<string, string> queryParams, string key, IEnumerable<object>? values)
        {
            if (values != null && values.Any())
            {
                queryParams.Add(key, string.Join(",", values.Select(value => value.ToString())));
            }
        }
        
        internal static void AddParamIfPresent(this IDictionary<string, string> queryParams, string key, IEnumerable<string>? values)
        {
            if (values != null && values.Any())
            {
                queryParams.Add(key, string.Join(",", values));
            }
        }
        
        internal static void AddDescriptionEnumValueIfPresent<TEnum>(
            this IDictionary<string, string> queryParams, string key, TEnum? enumMember)
            where TEnum : struct, Enum
        {
            if (enumMember.HasValue)
            {
                queryParams.Add(key, enumMember.Value.ToDescriptionString());
            }
        }
        
        internal static void AddSortingRulesIfPresent(
            this IDictionary<string, string> queryParams,
            IEnumerable<SortingRule>? sortingRules)
        {
            AddParamIfPresent(queryParams, "orderBy", sortingRules);
        }
    }
}