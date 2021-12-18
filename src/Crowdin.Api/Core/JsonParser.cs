
using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

#nullable enable

namespace Crowdin.Api.Core
{
    public interface IJsonParser
    {
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
                    .AsJEnumerable()
                    .Select(jToken =>
                        JsonConvert.DeserializeObject<TData>(
                            jToken["data"]!.ToString(), _options))
                    .ToList()!,
                
                Pagination =
                    JsonConvert.DeserializeObject<Pagination>(
                        rootElement["pagination"]!.ToString(), _options)
            };
        }
    }
}