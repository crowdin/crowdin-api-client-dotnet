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

            Console.WriteLine();
            Console.WriteLine("Press [Enter] to exit.");
            Console.ReadLine();
        }

        private async Task Run()
        {
            var httpClient = new HttpClient {BaseAddress = new Uri(Configuration["api"])};
            var crowdin = new Client(httpClient);

            Console.WriteLine("Press [Enter] to list Crowdin supported languages");
            Console.ReadLine();
            HttpResponseMessage response = await crowdin.GetSupportedLanguages();
            String content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);

            Console.WriteLine("Press [Enter] to list account projects");
            Console.ReadLine();
            var accountCredentials = GetConfigValue<AccountCredentials>("account");
            response = await crowdin.GetAccountProjects(accountCredentials);
            content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
        }

        private T GetConfigValue<T>(String key)
        {
            return Configuration.GetSection(key).Get<T>();
        }

        private IConfiguration Configuration { get; }
    }
}
