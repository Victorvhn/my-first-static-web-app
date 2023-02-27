using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Vhn.Function
{
  public static class GitHubProfileData
    {
        [FunctionName("GitHubProfileData")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var profile = req.Query["profile"];

            string responseMessage = string.IsNullOrEmpty(profile)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string for a personalized response."
                : $"Hello, {profile}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(new { Text = responseMessage });
        }
    }
}
