using NileRoutes.Data;
using NileRoutes.Interfaces;
using NileRoutes.Models.Domain;

namespace NileRoutes.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly NileRoutesDbContext _dbContext;
        public ImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor contextAccessor, NileRoutesDbContext dbContext)
        {
            _webHostEnvironment = webHostEnvironment;
            _contextAccessor = contextAccessor;
            _dbContext = dbContext;
        }

        public async Task<Image> UplaodImageAsync(Image image)
        {
            var localFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images",
                $"{image.FileName}{image.FileExtension}");

            // Upload image to local path
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            //Url to access the image
            var urlFilePath = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}{_contextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";

            image.FilePath = urlFilePath;

            //add image to images table
            await _dbContext.Images.AddAsync(image);
            await _dbContext.SaveChangesAsync();

            return image;
        }
    }
}
