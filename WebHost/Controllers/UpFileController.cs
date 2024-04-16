using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpFileController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public UpFileController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Chưa chọn file");

            try
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                return Ok(new { filePath });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi: {ex.Message}");
            }
        }
    }
}
