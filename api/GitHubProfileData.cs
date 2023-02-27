using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text.Json;
using System.Net.Http.Headers;

namespace Vhn.Function
{
  public static class GitHubProfileData
    {
        private static HttpClient httpClient = new HttpClient();
        
        [FunctionName("GitHubProfileData")]
        public static async ValueTask<ActionResult<GitHubFunctionResponse>> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string profile = req.Query["profile"];

            GitHubFunctionResponse functionResponse = null;
            if (!string.IsNullOrWhiteSpace(profile)) {
                var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.github.com/users/{profile}");
                var header = new ProductInfoHeaderValue("my-first-static-web-app", "1.0");
                request.Headers.UserAgent.Add(header);

                var gitHubResponse = await httpClient.SendAsync(request);

                var content = await gitHubResponse.Content.ReadAsStringAsync();

                var gitHubResponseDeserialize = JsonSerializer.Deserialize<GitHubResponse>(content);

                functionResponse = new GitHubFunctionResponse(gitHubResponseDeserialize);
            }
            else
            {
                functionResponse = new GitHubFunctionResponse("This HTTP triggered function executed successfully. Pass a GitHub Profile in the query string for a personalized response. (?profile=victorvhn)");
            }

            return new OkObjectResult(functionResponse);
        }
    }
}
