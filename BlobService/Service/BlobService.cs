using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlobServices.Services
{
    public class BlobService : IBlobService
    {
        private readonly CloudBlobClient _blobClient;
        private CloudBlobContainer _activeContainer;
        public BlobService(string connectionString)
        {
            var cloudStorageAccount = CloudStorageAccount.Parse(connectionString);

            _blobClient = cloudStorageAccount.CreateCloudBlobClient();
        }

        public string ListFiles()
        {
            var blobList = _activeContainer.ListBlobs();

            string resultStr = "";
            foreach (var blob in blobList)
            {
                var blobFileName = blob.Uri.LocalPath;
                var partialStr = "File: ";
                partialStr += blobFileName + " ";
                partialStr += "at " + blob.Uri + "\n";

                resultStr += partialStr;
            }

            return resultStr;
        }

        public byte[] RetrieveFile(string path)
        {
            var blobBlock = _activeContainer.GetBlockBlobReference(path);
            if (!blobBlock.Exists())
                return Enumerable.Empty<byte>().ToArray();

            byte[] file = null;
            blobBlock.DownloadToByteArray(file, 0);

            return file;
        }

        public void SelectBlobContainer(string container)
        {
            _activeContainer = _blobClient.GetContainerReference(container);
            _activeContainer.CreateIfNotExists(BlobContainerPublicAccessType.Blob, null, null);
        }

        public void UploadFile(byte[] file, string fileName)
        {
            var blobBlock = _activeContainer.GetBlockBlobReference(fileName);
            blobBlock.UploadFromByteArray(file, 0, file.Count());
        }
    }
}
