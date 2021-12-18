
using System;
using System.Collections.Generic;
using System.Linq;

using Crowdin.Api.SourceFiles;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

#nullable enable

namespace Crowdin.Api.Core.Converters
{
    public class FileInfoConverter : JsonConverter<FileInfoResource>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, FileInfoResource? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override FileInfoResource? ReadJson(
            JsonReader reader, Type objectType, FileInfoResource? existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);

            IEnumerable<string> properties = jObject.Properties().Select(property => property.Name);

            Type returnType =
                ContainsAny(properties, "revisionId",
                    "priority", "importOptions", "exportOptions",
                    "excludedTargetLanguages", "createdAt", "updatedAt")
                    ? typeof(FileResource)
                    : typeof(FileInfoResource);

            return (FileInfoResource?) JsonConvert.DeserializeObject(jObject.ToString(), returnType);
        }

        private static bool ContainsAny(IEnumerable<string> fields, params string[] values)
        {
            return values.Any(fields.Contains);
        }
    }
}