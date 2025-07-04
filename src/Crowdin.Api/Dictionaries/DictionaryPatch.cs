
using System.Collections.Generic;
using System.Linq;

using Crowdin.Api.Core.Converters;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Dictionaries
{
    [PublicAPI]
    public class DictionaryPatch : PatchEntry
    {
        [JsonProperty("path")]
        public DictionaryPatchPath Path { get; set; }
    }

    [PublicAPI]
    [CallToStringForSerialization]
    public class DictionaryPatchPath
    {
        public static DictionaryPatchPath Words => new DictionaryPatchPath();
        
        public ISet<long> WordIndexes { get; set; } = new HashSet<long>();

        public DictionaryPatchPath()
        {
            
        }

        public DictionaryPatchPath(ISet<long> wordIndexes)
        {
            WordIndexes = wordIndexes;
        }

        public DictionaryPatchPath(IEnumerable<long> wordIndexes)
        {
            WordIndexes = new HashSet<long>(wordIndexes);
        }

        public override string ToString()
        {
            return WordIndexes.Count > 0
                ? "/words/" + string.Join(",", WordIndexes.Reverse())
                : "/words";
        }
    }
}