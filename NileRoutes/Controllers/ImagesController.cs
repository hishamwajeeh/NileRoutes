using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NileRoutes.Interfaces;
using NileRoutes.Models.Domain;
using NileRoutes.Models.Dtos.ImageDto;

namespace NileRoutes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;
        public ImagesController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }


        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> UplaodImage([FromForm] ImageUploadRequestDto request)
        {
            ValidateFileUpload(request);

            if (ModelState.IsValid)
            {
                // convert Dto to Domain Model
                var imageDomainModel = new Image
                {
                    File = request.File,
                    FileExtension = Path.GetExtension(request.File.FileName),
                    FileSizeInBytes = request.File.Length,
                    FileName = request.FileName,
                    FileDescription = request.FileDescription,
                };

                // Call the repository to save the image
                await _imageRepository.UplaodImageAsync(imageDomainModel);
                return Ok(imageDomainModel);
            }
            return BadRequest(ModelState);
        }

        private void ValidateFileUpload (ImageUploadRequestDto request)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };

            if (!allowedExtensions.Contains(Path.GetExtension(request.File.FileName)))
            {
                ModelState.AddModelError("File","Unsupported File Extension");
            }

            if (request.File.Length > 5 * 1024 * 1024) // 5 MB limit
            {
                ModelState.AddModelError("File", "File size exceeds the limit of 5 MB");
            }
        }
    }
}
