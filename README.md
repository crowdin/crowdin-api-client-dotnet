[<p align='center'><img src='https://support.crowdin.com/assets/logos/crowdin-dark-symbol.png' data-canonical-src='https://support.crowdin.com/assets/logos/crowdin-dark-symbol.png' width='200' height='200' align='center'/></p>](https://crowdin.com)

# Crowdin .NET client (v1)

The Crowdin .NET client is a lightweight interface to the Crowdin API v1. It provides common services for making API requests.

Our API is a full-featured RESTful API that helps you to integrate localization into your development process. The endpoints that we use allow you to easily make calls to retrieve information and to execute actions needed.

For more about Crowdin API v1 see the [documentation](https://support.crowdin.com/api/api-integration-setup/).

### Status

[![Nuget](https://img.shields.io/nuget/v/Crowdin.Api?cacheSeconds=5000)](https://www.nuget.org/packages/Crowdin.Api/)
[![Nuget](https://img.shields.io/nuget/dt/crowdin.api?cacheSeconds=800)](https://www.nuget.org/packages/Crowdin.Api/)
[![GitHub issues](https://img.shields.io/github/issues/crowdin/crowdin-dotnet-client?cacheSeconds=10000)](https://github.com/crowdin/crowdin-dotnet-client/issues)
[![GitHub contributors](https://img.shields.io/github/contributors/crowdin/crowdin-dotnet-client?cacheSeconds=10000)](https://github.com/crowdin/crowdin-dotnet-client/graphs/contributors)
[![GitHub](https://img.shields.io/github/license/crowdin/crowdin-dotnet-client?cacheSeconds=20000)](https://github.com/crowdin/crowdin-dotnet-client/blob/master/LICENSE)

[![Azure DevOps builds (branch)](https://img.shields.io/azure-devops/build/crowdin/crowdin-dotnet-client/19/master?cacheSeconds=1000)](https://dev.azure.com/crowdin/crowdin-dotnet-client/_build/latest?definitionId=27&branchName=master)
[![Azure DevOps tests (branch)](https://img.shields.io/azure-devops/tests/crowdin/crowdin-dotnet-client/19/master?cacheSeconds=1000)](https://dev.azure.com/crowdin/crowdin-dotnet-client/_build/latest?definitionId=27&branchName=master)

### Requirements

* .NET Core - 2.1
* C# language version - 7.3

### Installation

1. Install via NuGet:

```C#
// Package Manager
Install-Package Crowdin.Api

// .Net CLI
dotnet add package Crowdin.Api

// PackageReference
<PackageReference Include="Crowdin.Api" />

// Paket CLI
paket add Crowdin.Api
```

2. Download this library to your project's 3rd party libraries path:

    ```
    git clone https://github.com/crowdin/crowdin-dotnet-client.git </your-project/src/Crowdin.Api>
    ```

    include library:

    ```C#
    <ItemGroup>
      <ProjectReference Include="src\Crowdin.Api\Crowdin.Api.csproj" />
    </ItemGroup>
    ```

    and start using it in your project:

    ```C#
    using Crowdin.Api;
    ```

### Quick Start

The API client must be instantiated and configured before calling any API method.

```C#

var httpClient = new HttpClient {BaseAddress = new Uri(Configuration["api"])};
var crowdin = new Client(httpClient);

var projectId = Configuration["project:projectId"];
var projectCredentials = GetConfigValue<ProjectCredentials>("project");

ProjectInfo project = await crowdin.GetProjectInfo(projectId, projectCredentials);

ConsoleOutput(project);
```

Please go to the [samples](https://github.com/crowdin/crowdin-dotnet-client/tree/master/samples) section to see more API calls examples.

### Contribution
We are happy to accept contributions to the Crowdin .NET client. To contribute please do the following:
1. Fork the repository on GitHub.
2. Decide which code you want to submit. Commit your changes and push to the new branch.
3. Ensure that your code adheres to standard conventions, as used in the rest of the library.
4. Submit a pull request with your patch on Github.

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
