using System;
using System.Net.Http;
using System.Threading.Tasks;
using Crowdin.Api;
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
            LanguageInfo[] languages = await crowdin.GetSupportedLanguages();
            ConsoleOutput(languages);

            ConsoleWriteMessage("Press [Enter] to list account projects");
            var accountCredentials = GetConfigValue<AccountCredentials>("account");
            AccountProjectInfo[] accountProjects = await crowdin.GetAccountProjects(accountCredentials);
            ConsoleOutput(accountProjects);
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

        private static void ConsoleOutput<T>(T[] values)
        {
            Int32 outputItems = Math.Min(3, values.Length);
            for (Int32 i = 0; i < outputItems; i++)
            {
                ConsoleOutput(values[i]);
            }

            Int32 restItems = values.Length - outputItems;
            if (restItems > 0)
            {
                Console.WriteLine($"...({restItems} more items)");
            }
        }

        private IConfiguration Configuration { get; }
    }
}
