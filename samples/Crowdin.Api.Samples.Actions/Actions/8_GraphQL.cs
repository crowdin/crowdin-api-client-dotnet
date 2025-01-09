
using Newtonsoft.Json.Linq;

using Crowdin.Api.GraphQL;

namespace Crowdin.Api.Samples.Actions
{
    public partial class CrowdinActions
    {
        public async Task ExecuteGraphQLRawQuery()
        {
            const string Query =
                """
                query {
                  viewer {
                    projects(first: 50) {
                      edges {
                        node {
                          name
                  
                          files(first: 10) {
                            totalCount
                            edges {
                              node {
                                name
                                type
                              }
                            }
                          }
                        }
                      }
                    }
                  }
                }
                """;

            var request = new GraphQLRequest
            {
                Query = Query
            };

            JObject? response = await _crowdinApiClient.GraphQL.ExecuteQuery(request);
            
            string[] projectNames =
                response["data"]?["viewer"]?["projects"]?["edges"]?
                    .Select(edge => edge["node"]?["name"]?.Value<string>())
                    .Where(projectNames => !string.IsNullOrWhiteSpace(projectNames))
                    .ToArray()!;

            Console.WriteLine(
                "Project names:\n - {0}",
                string.Join("\n - ", projectNames.Select((name, i) => $"{i + 1}) {name}")));
        }
    }
}