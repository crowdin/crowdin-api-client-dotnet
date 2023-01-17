[<p align='center'><img src='https://support.crowdin.com/assets/logos/crowdin-dark-symbol.png' data-canonical-src='https://support.crowdin.com/assets/logos/crowdin-dark-symbol.png' width='150' height='150' align='center'/></p>](https://crowdin.com)

# Crowdin .NET client [![Tweet](https://img.shields.io/twitter/url/http/shields.io.svg?style=social)](https://twitter.com/intent/tweet?url=https%3A%2F%2Fgithub.com%2Fcrowdin%2Fcrowdin-api-client-dotnet&text=The%20Crowdin%20.NET%20client%20is%20a%20lightweight%20interface%20to%20the%20Crowdin%20API)&nbsp;[![GitHub Repo stars](https://img.shields.io/github/stars/crowdin/crowdin-api-client-dotnet?style=social&cacheSeconds=1800)](https://github.com/crowdin/crowdin-api-client-dotnet/stargazers)

The Crowdin .NET client is a lightweight interface to the Crowdin API v2. It provides common services for making API requests.

Our API is a full-featured RESTful API that helps you to integrate localization into your development process. The endpoints that we use allow you to easily make calls to retrieve information and to execute actions needed.

<div align="center">

[**`API Client Docs`**](https://crowdin.github.io/crowdin-api-client-dotnet/api/Crowdin.Api.html) &nbsp;|&nbsp;
[**`Crowdin API`**](https://developer.crowdin.com/api/v2/) &nbsp;|&nbsp;
[**`Crowdin Enterprise API`**](https://developer.crowdin.com/enterprise/api/v2/)

[![Nuget](https://img.shields.io/nuget/v/Crowdin.Api?cacheSeconds=5000)](https://www.nuget.org/packages/Crowdin.Api/)
[![Nuget](https://img.shields.io/nuget/dt/crowdin.api?cacheSeconds=800)](https://www.nuget.org/packages/Crowdin.Api/)
[![GitHub issues](https://img.shields.io/github/issues/crowdin/crowdin-api-client-dotnet?cacheSeconds=10000)](https://github.com/crowdin/crowdin-api-client-dotnet/issues)
[![GitHub contributors](https://img.shields.io/github/contributors/crowdin/crowdin-api-client-dotnet?cacheSeconds=10000)](https://github.com/crowdin/crowdin-api-client-dotnet/graphs/contributors)
[![GitHub](https://img.shields.io/github/license/crowdin/crowdin-api-client-dotnet?cacheSeconds=20000)](https://github.com/crowdin/crowdin-api-client-dotnet/blob/master/LICENSE)

[![Azure DevOps builds (branch)](https://img.shields.io/azure-devops/build/crowdin/crowdin-dotnet-client/44/main?cacheSeconds=1000)](https://dev.azure.com/crowdin/crowdin-dotnet-client/_build/latest?definitionId=44)
[![Azure DevOps tests](https://img.shields.io/azure-devops/tests/crowdin/crowdin-dotnet-client/44/main?cacheSeconds=1000)](https://dev.azure.com/crowdin/crowdin-dotnet-client/_build/latest?definitionId=44)
[![codecov](https://codecov.io/gh/crowdin/crowdin-api-client-dotnet/branch/main/graph/badge.svg?token=rvpbEqBcLU)](https://codecov.io/gh/crowdin/crowdin-api-client-dotnet)

</div>

### Requirements

* .NET Standard 2.0 support
* C# language version - 8.0+

### Installation

Install via NuGet:

```
// Package Manager
Install-Package Crowdin.Api -Version 2.11.0

// .Net CLI
dotnet add package Crowdin.Api --version 2.11.0

// Package Reference
<PackageReference Include="Crowdin.Api" Version="2.11.0" />

// Paket CLI
paket add Crowdin.Api --version 2.11.0
```

---

:bookmark_tabs: For versions *1.x.x* and lower see the [branch api/v1](https://github.com/crowdin/crowdin-api-client-dotnet/tree/api/v1). Please note that these versions are no longer supported.

:exclamation: Migration from version *1.x.x* to *2.x.x* requires changes in your code.

---

### Usage examples

Instantiate a client with all available APIs

```C#

var credentials = new CrowdinCredentials
{
    AccessToken = "<paste token here>",
    Organization = "organizationName (for Crowdin Enterprise only)"
};
var client = new CrowdinApiClient(credentials);
```

Or use only needed executors
```C#
var credentials = new CrowdinCredentials
{
    AccessToken = "<paste token here>",
    Organization = "organizationName (for Crowdin Enterprise only)"
};

var client = new CrowdinApiClient(credentials);
var executor = new SourceFilesApiExecutor(client);
```

Storage

1. List storages

```C#
ResponseList<StorageResource> storages = await client.Storage.ListStorages();
```

2. Add storage

```C#
await using FileStream fileStream = File.Open("/path/to/file", FileMode.Open);
StorageResource storageResource = await client.Storage.AddStorage(fileStream, filename: "MyFile");
```

Projects

1. List projects

```C#
ResponseList<EnterpriseProject> response = await client.ProjectsGroups.ListProjects<EnterpriseProject>();
```

2. Edit project

```C#
const int projectId = 1;

// Edit info & settings with one request
var patches = new List<ProjectPatch>
{
    // Edit project info
    new ProjectInfoPatch
    {
        Value = "name",
        Path = ProjectInfoPathCode.Cname,
        Operation = PatchOperation.Replace
    },
    new ProjectInfoPatch
    {
        Value = "value here",
        Path = new ProjectInfoPath(ProjectInfoPathCode.LanguageMapping, "languageId", "mapping"),
        Operation = PatchOperation.Test
    },

    // Edit project settings
    new ProjectSettingPatch
    {
        Value = true,
        Path = ProjectSettingPathCode.AutoSubstitution,
        Operation = PatchOperation.Replace
    }
};

// PATCH request
var projectSettingsResponse = await client.ProjectsGroups.EditProject<ProjectSettings>(projectId, patches);
Console.WriteLine(projectSettingsResponse);
```

#### Fetch all records

Get list of all the data available from API via automatic pagination control

```C#
const int parentId = 1;
const int maxAmountOfItems = 50; // amount of needed items. Optional parameter, default: no limit
const int amountPerRequest = 10; // amount of items in response per 1 request. Optional parameter, default: 25

Group[] allGroups = await CrowdinApiClient.WithFetchAll((limit, offset) =>
{
    Console.WriteLine("Limit: {0} | Offset: {1}", limit, offset);
    return client.ProjectsGroups.ListGroups(parentId, limit, offset);
}, maxAmountOfItems, amountPerRequest);
```

Only for list async methods that return `Task<ResponseList<T>>`.

#### Retry configuration

Pass retry service (built-in or custom) if needed

```C#
IRetryService myRetryService = new RetryService(new RetryConfiguration
{
    RetriesCount = 5,
    WaitIntervalMilliseconds = 1000,
    SkipRetryConditions =
    {
        exception => ((CrowdinApiException) exception).Code.GetValueOrDefault() == 1
    }
});

var apiClient = new CrowdinApiClient(new CrowdinCredentials
{
    AccessToken = "<paste token here>",
    Organization = "optional organization (for Enterprise API)"
}, retryService: myRetryService);
```

A custom retry service should also implement interface `IRetryService`.

### Contribution

If you want to contribute please read the [Contributing](CONTRIBUTING.md) guidelines.

### Seeking Assistance
If you find any problems or would like to suggest a feature, please feel free to file an issue on Github at [Issues Page](https://github.com/crowdin/crowdin-dotnet-client/issues).

Need help working with Crowdin .NET client or have any questions?
[Contact Customer Success Service](https://crowdin.com/contacts).

### License
<pre>
The Crowdin .NET client is licensed under the MIT License.
See the LICENSE file distributed with this work for additional
information regarding copyright ownership.

Except as contained in the LICENSE file, the name(s) of the above copyright
holders shall not be used in advertising or otherwise to promote the sale,
use or other dealings in this Software without prior written authorization.
</pre>
