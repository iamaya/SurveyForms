using System;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;

namespace SurveyForms.Core.Helpers
{
	public class BlobHelper
	{
		public BlobHelper ()
		{
		}
		private static string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=ahpictures;AccountKey=YQO0gAISadL5+zqs//snB8olPtWaWuFE0O2avGmRX1rimt/9vnL/R3CPhjygak1bGe93eJPVrb/Bry5ButdxbQ==";

		//private static string blobpath = "https://ahpictures.blob.core.windows.net/" ;
		private static string BlobContainer = "devcontainer/" ;


		public bool UploadToBlob(byte[] stream, string filename)
		{
			try {
				var storageAccount = CloudStorageAccount.Parse (storageConnectionString);
				var blobStorage = storageAccount.CreateCloudBlobClient ();
				
				CloudBlobContainer container = blobStorage.GetContainerReference (BlobContainer);
				container = this.getCloudBlobContainer (container, 5);
				
				CloudBlockBlob blob = container.GetBlockBlobReference (filename);
				blob.Properties.ContentType = "image/jpeg";
				
				blob.UploadFromByteArray (stream, 0, stream.GetUpperBound (0));
			} catch (Exception) {
				return false;
			}
			return true;
		}

		public string DownloadBlobfromAzure()
		{
			// Create the storage account with the connection string.
			CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);

			// Create the blob client object.
			CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

			// Get a reference to the container for which shared access signature will be created.
			CloudBlobContainer container = blobClient.GetContainerReference(BlobContainer.Replace("/", ""));
			//CloudBlobContainer container = blobClient.GetContainerReference("privatetest");

			//container.CreateIfNotExists();

			// Create blob container permissions, consisting of a shared access policy 
			// and a public access setting. 
			BlobContainerPermissions blobPermissions = new BlobContainerPermissions();

			// The shared access policy provides 
			// read/write access to the container for 10 hours.
			blobPermissions.SharedAccessPolicies.Add("accesspolicy", new SharedAccessBlobPolicy()
				{
					// To ensure SAS is valid immediately, don’t set start time.
					// This way, you can avoid failures caused by small clock differences.
					SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(5),
					Permissions = SharedAccessBlobPermissions.Write |
						SharedAccessBlobPermissions.Read
				});

			// The public access setting explicitly specifies that 
			// the container is private, so that it can't be accessed anonymously.
			blobPermissions.PublicAccess = BlobContainerPublicAccessType.Off;

			// Set the permission policy on the container.
			container.SetPermissions(blobPermissions);

			// Get the shared access signature to share with users.
			string sasToken =
				container.GetSharedAccessSignature(new SharedAccessBlobPolicy(), "accesspolicy");

			return sasToken;


		}

		public string DownloadBlobfromAzure(string BlobContainer)
		{



			// Create the storage account with the connection string.
			CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);

			// Create the blob client object.
			CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

			// Get a reference to the container for which shared access signature will be created.
			CloudBlobContainer container = blobClient.GetContainerReference(BlobContainer.ToString().Replace("/", ""));
			//CloudBlobContainer container = blobClient.GetContainerReference("privatetest");

			//container.CreateIfNotExists();

			// Create blob container permissions, consisting of a shared access policy 
			// and a public access setting. 
			BlobContainerPermissions blobPermissions = new BlobContainerPermissions();

			// The shared access policy provides 
			// read/write access to the container for 10 hours.
			blobPermissions.SharedAccessPolicies.Add("accesspolicy", new SharedAccessBlobPolicy()
				{
					// To ensure SAS is valid immediately, don’t set start time.
					// This way, you can avoid failures caused by small clock differences.
					SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(5),
					Permissions = SharedAccessBlobPermissions.Write |
						SharedAccessBlobPermissions.Read
				});

			// The public access setting explicitly specifies that 
			// the container is private, so that it can't be accessed anonymously.
			blobPermissions.PublicAccess = BlobContainerPublicAccessType.Off;

			// Set the permission policy on the container.
			container.SetPermissions(blobPermissions);

			// Get the shared access signature to share with users.
			string sasToken =
				container.GetSharedAccessSignature(new SharedAccessBlobPolicy(), "accesspolicy");

			return sasToken;


		}
		public CloudBlobContainer getCloudBlobContainer(CloudBlobContainer container, int time)
		{

			BlobContainerPermissions blobPermissions = new BlobContainerPermissions();
			blobPermissions.SharedAccessPolicies.Add("accesspolicy", new SharedAccessBlobPolicy()
				{
					// To ensure SAS is valid immediately, don’t set start time.
					// This way, you can avoid failures caused by small clock differences.
					SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(time),
					Permissions = SharedAccessBlobPermissions.Write |
						SharedAccessBlobPermissions.Read
				});
			blobPermissions.PublicAccess = BlobContainerPublicAccessType.Off;
			container.SetPermissions(blobPermissions);
			return container;
		} 
	}
}

