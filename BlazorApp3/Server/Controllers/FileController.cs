using BlazorApp3.Server.Services.Files;
using BlazorApp3.Server.Services.Files.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp3.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet("[action]")] // GET /api/file
        public IEnumerable<string> ListFiles()
        {
            return _fileService.GetFiles();
        }

        [HttpGet("[action]/{fileId}")] // GET /api/file/{fileId}
        public IActionResult Serve(string fileId)
        {
            var byteStream = _fileService.Get(fileId);
            return new FileStreamResult(byteStream, "image/png");
        }

        [HttpDelete("[action]/{fileId}")] // DEL /api/file/{fileId}
        public IActionResult Delete(string fileId)
        {
            var check = _fileService.Delete(fileId);
            if (!check)
                return NotFound(string.Format("Couldn't delete file: {fileId}", fileId));
            return Ok(string.Format("File deleted: {check}", check));
        }

        [HttpPut("[action]")] // PUT /api/file
        public IActionResult Save([FromBody] FileUpload upload)
        {
            _fileService.Save(upload.Data, upload.Name);
            return Ok();
        }
    }
}
