
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Teams
{
    [PublicAPI]
    public class GroupTeamPatch : PatchEntry
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        [PublicAPI]
        public class Builder
        {
            private Builder()
            {
            }

            public static GroupTeamPatch CreateAddOperation(object value)
            {
                return new GroupTeamPatch
                {
                    Operation = PatchOperation.Add,
                    Path = "/-",
                    Value = value
                };
            }

            public static GroupTeamPatch CreateRemoveOperation(int teamId)
            {
                return new GroupTeamPatch
                {
                    Operation = PatchOperation.Remove,
                    Path = $"/{teamId}"
                };
            }
        }
    }
}