
using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

#nullable enable

namespace Crowdin.Api.Core
{
    public interface IJsonParser
    {
        TData[] ParseArray<TData>(JToken token);
        
        TData ParseResponseObject<TData>(JToken token);

        TData ParseResponseObject<TData>(JObject rootElement);

        ResponseList<TData> ParseResponseList<TData>(JObject rootElement);
    }
    
    public class JsonParser : IJsonParser
    {
        private readonly JsonSerializerSettings _options;

        public JsonParser(JsonSerializerSettings options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public TData[] ParseArray<TData>(JToken token)
        {
            CheckJTokenTypeOrThrow(token.Type, JTokenType.Array);
            
            return token
                .Select(ParseResponseObject<TData>)
                .ToArray();
        }
        
        public TData ParseResponseObject<TData>(JToken token)
        {
            CheckJTokenTypeOrThrow(token.Type, JTokenType.Object);
            return ParseResponseObject<TData>((JObject) token);
        }

        public TData ParseResponseObject<TData>(JObject rootElement)
        {
            JToken pointer =
                rootElement.TryGetValue("data", out JToken? dataObject)
                    ? dataObject
                    : rootElement;

            return JsonConvert.DeserializeObject<TData>(pointer.ToString(), _options)!;
        }

        public ResponseList<TData> ParseResponseList<TData>(JObject rootElement)
        {
            return new ResponseList<TData>
            {
                Data = rootElement["data"]!
                    .Select(ParseResponseObject<TData>)
                    .ToList(),
                
                Pagination =
                    rootElement["pagination"] != null
                    ? ParseResponseObject<Pagination>(rootElement["pagination"]!)
                    : null
            };
        }
        
        private static void CheckJTokenTypeOrThrow(JTokenType actualType, JTokenType neededType)
        {
            if (actualType != neededType)
            {
                string actualTypeString = Enum.GetName(typeof(JTokenType), actualType) ?? "<unknown>";
                string neededTypeString = Enum.GetName(typeof(JTokenType), neededType) ?? "<unknown>";
                
                throw new ArgumentException($"Token is not a JSON {neededTypeString}. Passed token type: {actualTypeString}");
            }
        }
    }
}