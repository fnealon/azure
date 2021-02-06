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
    public static class ActivityFunctions
    {
        [FunctionName("A_TranscodeVideo")]
        public static async Task<VideoFileInfo> TranscodeVideo(
            [ActivityTrigger] VideoFileInfo inputVideo, 
            //[HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"Transcoding {inputVideo.Location} to {inputVideo.BitRate}");
            await Task.Delay(5000);

            var transCodedLocation = $"{Path.GetFileNameWithoutExtension(inputVideo.Location)} -" +
                $"{inputVideo.BitRate}kbps.mp4";
            return new VideoFileInfo
            {
                Location = transCodedLocation,
                BitRate = inputVideo.BitRate
            };
        }

        [FunctionName("A_ExtractThumbnail")]
        public static async Task<string> ExtractThumbnail(
            [ActivityTrigger] string inputVideo,
            //[HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"Extracting Thumnail {inputVideo}");
            await Task.Delay(5000);
            return "thumbanil.jpg";
        }

        [FunctionName("A_PrependIntro")]
        public static async Task<string> PrependIntro(
            [ActivityTrigger] string inputVideo,
            //[HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"Prepending intro {inputVideo}");
            await Task.Delay(5000);
            return "intro.mp4";
        }
    }
}
