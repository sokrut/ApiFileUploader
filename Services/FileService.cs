using ApiFileUploader.Infrastructure;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Options;

namespace ApiFileUploader.Services
{
    public class FileService
    {
        private readonly IOptions<AzureBlobStorageOptions> _azureBlobOptions;
        private readonly BlobContainerClient _fileContainer;

        public FileService(IOptions<AzureBlobStorageOptions> azureOptions)
        {
            _azureBlobOptions = azureOptions;
            var credential = new StorageSharedKeyCredential(_azureBlobOptions.Value.StorageAccountName, _azureBlobOptions.Value.StorageAccountKey);
            var blobServiceClient = new BlobServiceClient(new Uri(_azureBlobOptions.Value.StorageBlobUri!), credential);
            _fileContainer = blobServiceClient.GetBlobContainerClient(_azureBlobOptions.Value.StorageContainerName);
        }

        public async Task UploadAsync(IFormFile blob, string email)
        {
            var metadata = new Dictionary<string, string>();
            metadata[_azureBlobOptions.Value.StorageContainerMetadataEmail!] = email;

            var options = new BlobUploadOptions()
            {
                Metadata = metadata
            };

            var client = _fileContainer.GetBlobClient(blob.FileName);

            await using (Stream? data = blob.OpenReadStream())
            {
                await client.UploadAsync(data, options);
            }
        }
    }
}
