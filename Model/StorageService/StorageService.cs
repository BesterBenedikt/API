using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.WindowsAzure; // Namespace for CloudConfigurationManager
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Blob; // Namespace for Blob storage types
using Microsoft.Azure; //Namespace for CloudConfigurationManager
using System.Configuration;

namespace Model.StorageService
{
    class StorageService
    {
        private static  CloudStorageAccount storageAccount;
        private static CloudBlobClient blobClient;
        private static CloudBlobContainer container;
        private static CloudBlockBlob blockBlob;

        public StorageService()
        {
            // Retrieve storage account from connection string.
            storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the blob client.
            blobClient = storageAccount.CreateCloudBlobClient();

        }

        public string getURL(string playerID)
        {

            // Retrieve a reference to a container.
            container = blobClient.GetContainerReference(CloudConfigurationManager.GetSetting("PlayerContainer"));

            blockBlob = container.GetBlockBlobReference(playerID.ToString());
            return blockBlob.Uri.ToString();
        }

    }
}
