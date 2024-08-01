
// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;

using Crowdin.Api;
using Crowdin.Api.ProjectsGroups;

var client = new CrowdinApiClient(new CrowdinCredentials
{
    AccessToken = "<paste token here>",
    Organization = "optional organization (for Enterprise API)"
});

ResponseList<EnterpriseProject> response = await client.ProjectsGroups.ListProjects<EnterpriseProject>();

const int projectId = 1;

var operations = new List<ProjectPatch>
{
    new ProjectInfoPatch
    {
        Value = 1,
        Path = ProjectInfoPathCode.Cname,
        Operation = PatchOperation.Replace
    },
    new ProjectInfoPatch
    {
        Value = "test",
        Path = new ProjectInfoPath(ProjectInfoPathCode.LanguageMapping, "en", "2"),
        Operation = PatchOperation.Test
    },
    new ProjectSettingPatch
    {
        Value = true,
        Path = ProjectSettingPathCode.AutoSubstitution,
        Operation = PatchOperation.Replace
    }
};

var projectSettingsResponse = await client.ProjectsGroups.EditProject<ProjectSettings>(projectId, operations);
Console.WriteLine(projectSettingsResponse);

// Get all elements by automatic pagination control

const int parentId = 1;
const int maxAmountOfItems = 50;
const int amountPerRequest = 10;

Group[] allGroups = await CrowdinApiClient.WithFetchAll((limit, offset) =>
{
    Console.WriteLine("{0} {1}", limit, offset);
    return client.ProjectsGroups.ListGroups(parentId, limit: limit, offset: offset);
}, maxAmountOfItems, amountPerRequest);

Console.WriteLine(allGroups);