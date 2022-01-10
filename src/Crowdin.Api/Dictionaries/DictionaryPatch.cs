
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
        
        public ISet<int> WordIndexes { get; set; } = new HashSet<int>();

        public DictionaryPatchPath()
        {
            
        }

        public DictionaryPatchPath(ISet<int> wordIndexes)
        {
            WordIndexes = wordIndexes;
        }

        public DictionaryPatchPath(IEnumerable<int> wordIndexes)
        {
            WordIndexes = new HashSet<int>(wordIndexes);
        }

        public override string ToString()
        {
            return WordIndexes.Count > 0
                ? "/words/" + string.Join(",", WordIndexes.Reverse())
                : "/words";
        }
    }
}