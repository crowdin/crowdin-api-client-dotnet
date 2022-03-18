
using System;
using Crowdin.Api.StringTranslations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

#nullable enable

namespace Crowdin.Api.Core.Converters
{
    public class LanguageTranslationsConverter : JsonConverter<LanguageTranslations>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, LanguageTranslations? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override LanguageTranslations? ReadJson(
            JsonReader reader, Type objectType, LanguageTranslations? existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);

            if (!obj.TryGetValue("contentType", out JToken? contentTypeToken) && contentTypeToken is null)
            {
                throw new Exception("LanguageTranslations deserialization error: can't get class");
            }

            string contentType = contentTypeToken.Value<string>()
                                 ?? throw new ArgumentNullException(nameof(contentTypeToken));

            Type returnType = contentType switch
            {
                "text/plain" => typeof(PlainLanguageTranslations),
                "application/vnd.crowdin.text+plural" => typeof(PluralLanguageTranslations),
                "application/vnd.crowdin.text+icu" => typeof(IcuLanguageTranslations),
                
                _ => throw new Exception($"Wrong type: {contentType}")
            };

            return (LanguageTranslations?) JsonConvert.DeserializeObject(obj.ToString(), returnType);
        }
    }
}