using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AudioController : ControllerBase
    {

        [HttpGet("download/{fileName}")]
        public IActionResult DownloadAudio(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return BadRequest("File name is required");
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "uploads", fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found");
            }

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                stream.CopyTo(memory);
            }
            memory.Position = 0;

            return File(memory, "audio/mpeg", Path.GetFileName(filePath));
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadAudio(IFormFile audioFile)
        {
            if (audioFile == null || audioFile.Length == 0)
            {
                return BadRequest("Audio file is required");
            }

            //Make sure the file is an audio file
            var extension = Path.GetExtension(audioFile.FileName).ToLower();
            var allowedExtensions = new[] { ".mp3", ".wav", ".flac" };

            if (audioFile.ContentType != "audio/mpeg" || !allowedExtensions.Contains(extension))
            {
                return BadRequest("Invalid audio file");
            }

            //file path
            var uploads = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            var filePath = Path.Combine(uploads, audioFile.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await audioFile.CopyToAsync(fileStream);
            }

            return Ok(new { filePath });
        }

    }
}