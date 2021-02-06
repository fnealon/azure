using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DurableDemo1
{
    public static class ProcessVideoOrchestrators
    {
        [FunctionName("O_ProcessVideo")]
        public static async Task<object> RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext ctx,
            ILogger log)
        {           
            var videoLocation = ctx.GetInput<string>();

            if (!ctx.IsReplaying)
                log.LogInformation("About to call transcode video activity");

            var bitRates = new[] { 100, 2000, 3000, 4000 };
            var transCodeTasks = new List<Task<VideoFileInfo>> ();

            foreach(var bitRate in bitRates)
            {
                var info = new VideoFileInfo() { BitRate = bitRate, Location = videoLocation };
                var task = ctx.CallActivityAsync<VideoFileInfo>("A_TranscodeVideo", info);
                transCodeTasks.Add(task);
            }
            var transcodeResults = await Task.WhenAll(transCodeTasks);

            var transcodedLocation = transcodeResults.FirstOrDefault().Location;

            //var retriedLocation = await ctx.CallActivityWithRetryAsync<string>("Jake",
            //    new RetryOptions(TimeSpan.FromSeconds(4), 3),
            //    videoLocation);

            if (!ctx.IsReplaying)
                log.LogInformation("About to call extract thumbnail");

            var thumbnailLocation = await
                ctx.CallActivityAsync<string>("A_ExtractThumbnail", transcodedLocation);

            if (!ctx.IsReplaying)
                log.LogInformation("About to call prepend intro");

            var withIntroLocation = await
                ctx.CallActivityAsync<string>("A_PrependIntro", transcodedLocation);

            // Timing Out waiting for an even
            using(var cts = new CancellationTokenSource())
            {
                var timeout = ctx.CurrentUtcDateTime.AddDays(1);
                var timeoutTask = ctx.CreateTimer(timeout, cts.Token);
                var approvalTask = ctx.WaitForExternalEvent<string>("EventName");

                var theWinner = await Task.WhenAny(timeoutTask, approvalTask);
                if(theWinner == approvalTask)
                {
                    var approved = approvalTask.Result;
                    cts.Cancel();
                }
                else
                {
                    var approved = "Timed Out";
                }
            }

            



            return new
            {
                Transcoded = transcodedLocation,
                Thumbnail = thumbnailLocation,
                WithIntro = withIntroLocation
            };

        }

    }
}