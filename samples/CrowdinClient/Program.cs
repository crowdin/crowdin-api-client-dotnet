using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Crowdin.Api;
using Crowdin.Api.Typed;
using Microsoft.Extensions.Configuration;

namespace CrowdinClient
{
    internal sealed class Program
    {
        private Program(IConfiguration config)
        {
            Configuration = config;
        }

        private static async Task Main(String[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            var program = new Program(config);
            await program.Run();

            ConsoleWriteMessage("Press [Enter] to exit.");
        }

        private async Task Run()
        {
            var httpClient = new HttpClient {BaseAddress = new Uri(Configuration["api"])};
            var crowdin = new Client(httpClient);

            ConsoleWriteMessage("Press [Enter] to list Crowdin supported languages");
            ReadOnlyCollection<LanguageInfo> languages = await crowdin.GetSupportedLanguages();
            ConsoleOutput(languages);

            ConsoleWriteMessage("Press [Enter] to list account projects");
            var accountCredentials = GetConfigValue<AccountCredentials>("account");
            ReadOnlyCollection<AccountProjectInfo> accountProjects = await crowdin.GetAccountProjects(accountCredentials);
            ConsoleOutput(accountProjects);

            ConsoleWriteMessage("Press [Enter] to get project information using project API key");
            var projectId = Configuration["project:projectId"];
            var projectCredentials = GetConfigValue<ProjectCredentials>("project");
            ProjectInfo project = await crowdin.GetProjectInfo(projectId, projectCredentials);
            ConsoleOutput(project);

            ConsoleWriteMessage("Press [Enter] to get project information using account API key");
            project = await crowdin.GetProjectInfo(projectId, accountCredentials);
            ConsoleOutput(project);

            ConsoleWriteMessage("Press [Enter] to get project translation status");
            ReadOnlyCollection<TargetLanguageStatus> projectTranslationStatus = await crowdin.GetProjectStatus(projectId, accountCredentials);
            ConsoleOutput(projectTranslationStatus);

            ConsoleWriteMessage("Press [Enter] to get language translation status");
            var getLanguageStatusParameters = new GetLanguageStatusParameters {
                Language = "de"
            };
            LanguageTranslationStatus languageTranslationStatus = await crowdin.GetLanguageStatus(projectId, accountCredentials, getLanguageStatusParameters);
            ConsoleOutput(languageTranslationStatus.Files);
        }

        private T GetConfigValue<T>(String key)
        {
            return Configuration.GetSection(key).Get<T>();
        }

        private static void ConsoleWriteMessage(String message)
        {
            Console.WriteLine();
            Console.WriteLine(message);
            Console.ReadLine();
        }

        private static void ConsoleOutput(Object value)
        {
            Console.WriteLine(value);
        }

        private static void ConsoleOutput<T>(IList<T> values)
        {
            Int32 outputItems = Math.Min(3, values.Count);
            for (Int32 i = 0; i < outputItems; i++)
            {
                ConsoleOutput(values[i]);
            }

            Int32 restItems = values.Count - outputItems;
            if (restItems > 0)
            {
                Console.WriteLine($"...({restItems} more items)");
            }
        }

        private IConfiguration Configuration { get; }
    }
}
