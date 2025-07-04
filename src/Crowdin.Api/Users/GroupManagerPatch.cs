
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public class GroupManagerPatch : PatchEntry
    {
        [JsonProperty("path")]
        public string Path { get; set; }
        
        [PublicAPI]
        public class Builder
        {
            private Builder()
            {
            }

            public static GroupManagerPatch CreateAddOperation(object value)
            {
                return new GroupManagerPatch
                {
                    Operation = PatchOperation.Add,
                    Path = "/-",
                    Value = value
                };
            }

            public static GroupManagerPatch CreateRemoveOperation(long userId)
            {
                return new GroupManagerPatch
                {
                    Operation = PatchOperation.Remove,
                    Path = $"/{userId}"
                };
            }
        }
    }
}