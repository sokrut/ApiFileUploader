using ApiFileUploader.Models;
using ApiFileUploader.Services;
using Microsoft.AspNetCore.Mvc;


namespace ApiFileUploader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly FileService _fileService;

        public FileController(FileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] UploadFileRequest request)
        {
            await _fileService.UploadAsync(request.File!, request.Email!);
            return Ok();
        }
    }
}
