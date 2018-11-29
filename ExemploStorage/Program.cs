using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;

namespace ExemploStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            CloudStorageAccount account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=storage13net;AccountKey=AhDlxuw3BZ3XhhFvgJUNmvVDBoiUZFXwrZoty/hLCiXdFzR2B/wXVnzlbS/dnRIt7oC/jn8mcvNYoaDluvercg==;EndpointSuffix=core.windows.net");
            
            #region Blob


            //var blobClient = account.CreateCloudBlobClient();
            //var container = blobClient.GetContainerReference("331760");

            //container.CreateIfNotExistsAsync().Wait();

            //var blob = container.GetBlockBlobReference("carla2.txt");
            //blob.UploadTextAsync("Olá Mundo! =)").Wait();

            //var sas = blob.GetSharedAccessSignature(new SharedAccessBlobPolicy {
            //    Permissions = SharedAccessBlobPermissions.Read,
            //    SharedAccessExpiryTime = DateTime.Now.AddYears(5)
            //});

            //Console.WriteLine(blob.Uri + sas);
            #endregion

            var client = account.CreateCloudTableClient();
            var table = client.GetTableReference("rm331760");
            table.CreateIfNotExistsAsync().Wait();

            var entity = new Aluno("331760", "São Paulo");
            entity.Nome = "Carla";
            entity.Email = "carla@teste.com.br";

            table.ExecuteAsync(TableOperation.Insert(entity));

            Console.Read();

            Console.WriteLine("Hello World!");
        }
    }
}
