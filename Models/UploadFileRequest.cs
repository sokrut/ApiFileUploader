using ApiFileUploader.Extensions;
using System.ComponentModel.DataAnnotations;

namespace ApiFileUploader.Models
{
    public class UploadFileRequest
    {
        [Required]
        [AllowedExtensions(new[] { ".docx" })]
        public IFormFile? File { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(256)]
        public string? Email { get; set; }
    }
}
