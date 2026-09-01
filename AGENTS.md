# AGENTS.md

.NET client for the Crowdin API v2 and Crowdin Enterprise API v2 (NuGet: `Crowdin.Api`).

`src/Crowdin.Api` targets .NET Standard 2.0 with C# 8 and Newtonsoft.Json — no records, no `init`, no file-scoped namespaces, no implicit usings in `src/`. The test project targets net8.0 and is freer. Nullable checking is per-file: start every new `src/` file with `#nullable enable`.

## Layout

`Crowdin.sln` holds four projects: `src/Crowdin.Api` (the library), `tests/Crowdin.Api.UnitTesting` (xUnit + Moq), and two `samples/` projects — a bare `dotnet build` builds all four.

- `src/Crowdin.Api/<Module>/` — one directory per API module: models, request/patch types, `I<Module>ApiExecutor` + `<Module>ApiExecutor`
- `src/Crowdin.Api/CrowdinApiClient.cs` — entry point; exposes executors as properties
- `src/Crowdin.Api/Core/` — HTTP plumbing, `Utils`, JSON converters, `InternalExtensions` helpers
- `tests/Crowdin.Api.UnitTesting/Tests/<Module>/` — tests; JSON fixtures live in `Resources/*.resx`

## Commands

- Build: `dotnet build` (CI: `dotnet build -c Release`)
- Test (all): `dotnet test`
- Test (one class): `dotnet test --filter "FullyQualifiedName~Crowdin.Api.UnitTesting.Tests.Clients.ClientsApiTests"`

There is no lint/format gate — match the style of neighboring files by hand.

## Executor pattern

Every module follows the same shape: `I<Module>ApiExecutor` (interface, `[PublicAPI]`) → `<Module>ApiExecutor` (takes `ICrowdinApiClient`, builds params, sends requests via `SendGetRequest`/`SendPostRequest`/..., parses via `IJsonParser.ParseResponseObject/List<T>()`, `[PublicAPI]` on each public method) → a property on `CrowdinApiClient`.

Registration is not universal: `ClientsApiExecutor` and `NotificationsApiExecutor` exist but are construct-it-yourself, and `Branches`/`Fields` sit on the concrete client but not on `ICrowdinApiClient` — check both files before assuming a module is reachable.

## Adding or changing an endpoint

Fetch the endpoint spec first (see Crowdin API reference below). Then:

1. Models in `src/Crowdin.Api/<Module>/`: `#nullable enable` at the top, `[PublicAPI]` on the type, `[JsonProperty("camelCase")]` on every property, non-nullable strings initialized `= null!`; optional request fields nullable so `NullValueHandling.Ignore` drops them. PATCH paths are a `<X>Patch : PatchEntry` class plus an enum whose members carry `[Description("/jsonPointer")]`.
2. Executor: add the method to both `I<Module>ApiExecutor` and `<Module>ApiExecutor` (two constructors: `(ICrowdinApiClient)` and `(ICrowdinApiClient, IJsonParser)`). List params beyond limit/offset get a `<X>ListParams : IQueryParamsProvider` built with `Utils.CreateQueryParamsFromPaging(...)` plus `AddParamIfPresent(...)`/`AddSortingRulesIfPresent(...)` from `Core/InternalExtensions.cs`. XML-doc every method with the operation links (docfx publishes these), then `[PublicAPI]`.
3. For a new module, register it in BOTH `CrowdinApiClient.cs` (using + property + constructor assignment) and `ICrowdinApiClient.cs` (using + property).
4. A new JSON converter in `Core/Converters/` must be registered twice: in `Utils.CreateJsonSerializerSettings()` and in `TestUtils.CreateJsonSerializerOptions()` in the test project — the two lists are identical by design, and missing one makes tests diverge from runtime behavior.
5. Tests in `tests/.../Tests/<Module>/`: `TestUtils.CreateMockClientWithDefaultParser()` for a `Mock<ICrowdinApiClient>`, then `mockClient.Setup(c => c.SendGetRequest(url, queryParams)).ReturnsAsync(new CrowdinApiResult {...})` — POST setups take a third `null` argument. Assert request serialization separately against `TestUtils.CompactJson(Resources.<Module>.<Name>)`.
6. Fixtures: add a `<data>` entry to `Resources/<Module>.resx` AND hand-add the matching `internal static string` property to `<Module>.Designer.cs` — the `ResXFileCodeGenerator` runs only inside an IDE; `dotnet build` never regenerates designer files. A brand-new `.resx` also needs the `EmbeddedResource`/`Compile Update` pair in the test `.csproj` (copy an existing `Resources\`-prefixed block).

## Crowdin API reference

Before implementing or changing any endpoint, fetch its spec from the llms.txt indexes (pick by environment, then project type):

- https://support.crowdin.com/_llms-txt/api/crowdin/file-based.txt — Crowdin API, file-based projects (start here)
- https://support.crowdin.com/_llms-txt/api/crowdin/string-based.txt — Crowdin API, string-based projects
- https://support.crowdin.com/_llms-txt/api/enterprise/file-based.txt — Crowdin Enterprise API, file-based projects
- https://support.crowdin.com/_llms-txt/api/enterprise/string-based.txt — Crowdin Enterprise API, string-based projects

Each index links one spec file per route (e.g. `.../api.projects.strings.get.txt`) with the exact request and response shapes.

## Conventions

- Conventional Commits for commit messages and PR titles; CI lints PR titles (e.g. `feat(ai): ...`, `fix(translations): ...`).
- PRs target `main`.
- Keep the public API backward compatible.
- Never edit `<Version>` in `Crowdin.Api.csproj` by hand — the Release workflow rewrites it and every `x.y.z` occurrence in `README.md`.

## PR checklist

A change is ready when:

1. `dotnet build -c Release` compiles,
2. `dotnet test` passes,
3. every new or changed endpoint method has a test asserting the request URL/params and response parsing, and
4. every new or changed public member has XML docs with the operation links.
