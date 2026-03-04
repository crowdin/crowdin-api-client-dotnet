# AGENTS.md

This file provides guidance to AI Agents when working with code in this repository.

## Commands

### Build

```bash
dotnet build
dotnet build --configuration Release
```

### Run all tests

```bash
dotnet test
```

### Run a single test class

```bash
dotnet test --filter "FullyQualifiedName~Crowdin.Api.UnitTesting.Tests.Clients.ClientsApiTests"
```

## Architecture

This is a **.NET Standard 2.0** client library for the Crowdin API v2. The solution (`Crowdin.sln`) contains:

- **`src/Crowdin.Api/`** — the main library (targets .NET Standard 2.0, C# 8)
- **`tests/Crowdin.Api.UnitTesting/`** — xUnit tests (targets .NET 8)

### Executor Pattern

Every API domain (Branches, Glossaries, SourceFiles, etc.) follows the same pattern:

1. **Interface**: `IXxxApiExecutor` — defines available operations
2. **Implementation**: `XxxApiExecutor` — takes `ICrowdinApiClient` in constructor, builds query params, sends requests
3. **Registration**: The executor is exposed as a property on `CrowdinApiClient` (e.g., `client.Branches`, `client.Glossaries`)

`CrowdinApiClient` (`src/Crowdin.Api/CrowdinApiClient.cs`) is the main entry point. It implements `ICrowdinApiClient` and instantiates all executors.

### Request/Response Flow

1. Caller invokes an executor method (e.g., `executor.ListClients(limit, offset)`)
2. Executor builds query params using `Utils.CreateQueryParamsFromPaging()` and similar helpers
3. Executor calls `_apiClient.SendGetRequest(url, queryParams)` (or `SendPostRequest`, `SendPutRequest`, etc.)
4. Response is parsed via `IJsonParser.ParseResponseList<T>()` or `ParseResponseObject<T>()`
5. Typed result returned to caller

### Adding a New API Module

To add a new API module, follow the existing pattern:

1. Create a directory under `src/Crowdin.Api/<ModuleName>/`
2. Define model classes and request/response types
3. Create `IModuleNameApiExecutor` interface
4. Implement `ModuleNameApiExecutor : IModuleNameApiExecutor`
5. Add the executor property to `CrowdinApiClient` and initialize it in the constructor
6. Create corresponding test class under `tests/Crowdin.Api.UnitTesting/Tests/<ModuleName>/`
7. Add test data as a `.resx` resource file under `tests/Crowdin.Api.UnitTesting/Resources/`

### Testing Pattern

Tests mock `ICrowdinApiClient` using Moq and verify that executors correctly parse responses. JSON fixture data is stored in `.resx` files under `tests/Crowdin.Api.UnitTesting/Resources/`.

### Conventions

- Use [Conventional Commits](https://www.conventionalcommits.org/) for commit messages and PR titles (e.g., `feat(ai): ...`, `fix(translations): ...`)
- `[PublicAPI]` (JetBrains.Annotations) is applied to all public API types
- Nullable reference types are enabled (`#nullable enable`)

## Notes For API Details

Always use Crowdin/Crowdin Enterprise `llms.txt` index files for API method details. Choose the correct index by environment first, then project type.

Use these URLs:

- https://support.crowdin.com/_llms-txt/api/crowdin/file-based.txt - Crowdin API (file-based projects, preferred first)
- https://support.crowdin.com/_llms-txt/api/crowdin/string-based.txt - Crowdin API (string-based projects)
- https://support.crowdin.com/_llms-txt/api/enterprise/file-based.txt - Crowdin Enterprise API (file-based projects)
- https://support.crowdin.com/_llms-txt/api/enterprise/string-based.txt - Crowdin Enterprise API (string-based projects)

Each index contains a list of links to the API method details (e.g. https://support.crowdin.com/_llms-txt/api/enterprise/file-based/api.projects.strings.get.txt).
