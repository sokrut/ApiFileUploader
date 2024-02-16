using System.ComponentModel.DataAnnotations;

namespace ApiFileUploader.Infrastructure
{
    public class AzureBlobStorageOptions
    {
        [Required]
        public string? StorageAccountName { get; set; }

        [Required]
        public string? StorageAccountKey { get; set; }

        [Required]
        public string? StorageBlobUri { get; set; }

        [Required]
        public string? StorageContainerName { get; set; }

        [Required]
        public string? StorageContainerMetadataEmail { get; set; }
    }
}