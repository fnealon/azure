using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;

namespace DurableDemo1
{
    public static class ProcessVideoStarted
    {
        [FunctionName("ProcessVideoStarted")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger log)
        {
            // parse query parameter
            string video = req.Query["video"];

            // Get request body
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            // Set name to query string or body data
            video = video ?? data?.video;

            if (video == null)
            {
               // return req.CreateResponse(HttpStatusCode.BadRequest,
                // var responseMsg ="Please pass the video location the query string or in the request body";
                return new BadRequestResult();
            }

            log.LogInformation($"About to start orchestration for {video}");

            var orchestrationId = await starter.StartNewAsync("O_ProcessVideo", video);
            
            return starter.CreateCheckStatusResponse(req, orchestrationId);
        }
    }
}
