using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Linq;

namespace HttpTriggerCore
{
    using Microsoft.Azure.WebJobs;

    public class HttpTrigger
    {
        [FunctionName("HttpTrigger")]
        public static IActionResult Run([HttpTrigger] HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            if (req.Query.TryGetValue("name", out StringValues value)) {
                return new OkObjectResult($"Hello, {value.First()}");
            }

            return new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
