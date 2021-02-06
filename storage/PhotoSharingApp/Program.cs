using System;
using Microsoft.Extensions.Configuration;
using System.IO;
//using Microsoft.WindowsAzure.Storage;
//using Microsoft.WindowsAzure.Storage.Blob;
using Azure.Storage;
using Azure.Storage.Blobs;
using System.Threading.Tasks;

namespace PhotoSharingApp
{
    /// <summary>
    /// ConnectionString
    /// ContainerName
    /// </summary>
    class Program
    {

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            var connectionString = configuration["StorageAccountConnectionString"];
            var containerName = configuration["ContainerName"];
            var filePathOfBlob = configuration["FileName"];
            

            // Get a reference to the container and create it 
            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);
            //blobContainerClient.Create()
            await blobContainerClient.CreateIfNotExistsAsync();

            using(var fs = new FileStream(filePathOfBlob, FileMode.Open))
            {
                var response = blobContainerClient.UploadBlob("BlobName", fs);
            }
           

            var blobClient = blobContainerClient.GetBlobClient("BlobName");

            var anotherResponse = await blobClient.DownloadToAsync("downloaded.txt");
           //anotherResponse.Status
          
        }
    }
}
