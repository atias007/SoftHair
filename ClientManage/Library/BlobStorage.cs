using System;
using System.Collections.Generic;
using ClientManage.BL;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace ClientManage.Library
{
    public class BlobStorage
    {
        public event EventHandler<BlobStorageEventArgs> UploadAction;

        public BlobStorage()
        {
            _useDevelopmentStorage = true;
        }

        public BlobStorage(string accountName, string accountKey)
        {
            this.AccountName = accountName;
            this.AccountKey = accountKey;
        }

        private readonly bool _useDevelopmentStorage;

        private void OnUploadAction(string message)
        {
            if (UploadAction != null)
            {
                var args = new BlobStorageEventArgs(message);
                UploadAction(this, args);
            }
        }

        public string AccountName { get; private set; }

        public bool ThrowExceptions { get; set; }

        public string AccountKey { get; private set; }

        public bool UploadFile(IEnumerable<BlobUploadFile> files, string container)
        {
            var hasErrors = false;
            CloudBlobContainer blobContainer = null;

            var cloudStorageAccount = 
                _useDevelopmentStorage ? 
                CloudStorageAccount.DevelopmentStorageAccount : 
                CloudStorageAccount.Parse("DefaultEndpointsProtocol=http;AccountName=" + AccountName + ";AccountKey=" + AccountKey);

            try
            {
                // Create the blob client, which provides
                // authenticated access to the Blob service.
                var blobClient = cloudStorageAccount.CreateCloudBlobClient();

                // Get the container reference.
                blobContainer = blobClient.GetContainerReference(container);

                // Create the container if it does not exist.
                if (blobContainer.CreateIfNotExist())
                {
                    OnUploadAction("Create " + container + " BLOB container\r\n");
                }

                // Set permissions on the container.
                var containerPermissions = new BlobContainerPermissions
                                           {
                                               PublicAccess = BlobContainerPublicAccessType.Blob
                                           };

                // This sample sets the container to have public blobs. Your application
                // needs may be different. See the documentation for BlobContainerPermissions
                // for more information about blob container permissions.
                blobContainer.SetPermissions(containerPermissions);
            }
            catch(Exception ex)
            {
                hasErrors = true;
                OnUploadAction("ERROR!\r\n");
                OnUploadAction(ex.Message + "\r\n");

                if (ThrowExceptions) throw;
            }

            if (!hasErrors)
            {
                foreach (var file in files)
                {
                    // Get a reference to the blob.
                    var blob = blobContainer.GetBlobReference(file.Name);

                    // Upload a file from the local system to the blob.
                    try
                    {
                        OnUploadAction(file.Filepath + "... ");
                        blob.UploadFile(file.Filepath); // File from local storage.
                        OnUploadAction("done.\r\n");
                    }
                    catch (Exception ex)
                    {
                        hasErrors = true;
                        OnUploadAction("ERROR!\r\n");
                        OnUploadAction(ex.Message + "\r\n");

                        if (ThrowExceptions) throw;
                    }
                }
            }

            if (hasErrors)
            {
                OnUploadAction("Backup finish with errors!\r\n");
            }
            else
            {
                OnUploadAction("Backup finish successfully\r\n");
                AppSettingsHelper.SetParamValue("FTP_LAST_BACKUP", DateTime.Now);
            }

            return !hasErrors;
        }

        public void UploadFile(string name, string filepath, string container)
        {
            var list = new List<BlobUploadFile>
                       {
                           new BlobUploadFile {Name = name, Filepath = filepath}
                       };
            UploadFile(list, container);
        }
    }

    public class BlobUploadFile
    {
        public string Name { get; set; }

        public string Filepath { get; set; }
    }

    public class BlobStorageEventArgs : EventArgs
    {
        public BlobStorageEventArgs(string message)
        {
            this.Message = message;
        }

        public string Message { get; private set; }
    }
}
