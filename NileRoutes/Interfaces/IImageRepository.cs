using NileRoutes.Models.Domain;

namespace NileRoutes.Interfaces
{
    public interface IImageRepository
    {
        Task<Image> UplaodImageAsync(Image image);
    }
}
