#nullable enable

using System.Collections.Generic;
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Crowdin.Api.ProjectsGroups;

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public class ProjectPermissionsMassOperation
    {
        [JsonProperty("op")]
        public PatchOperation Op { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; } = null!;

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<UserProjectRole>? Value { get; set; }

        public static ProjectPermissionsMassOperation Replace(long projectId, IEnumerable<UserProjectRole> roles) =>
            new ProjectPermissionsMassOperation { Op = PatchOperation.Replace, Path = $"/{projectId}/roles", Value = roles };

        public static ProjectPermissionsMassOperation Add(long projectId, UserProjectRole role) =>
            new ProjectPermissionsMassOperation { Op = PatchOperation.Add, Path = $"/{projectId}/roles/-", Value = new[] { role } };

        public static ProjectPermissionsMassOperation Remove(long projectId) =>
            new ProjectPermissionsMassOperation { Op = PatchOperation.Remove, Path = $"/{projectId}" };
    }
}
