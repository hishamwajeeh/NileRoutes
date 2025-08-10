using NileRoutes.Models.Domain;
using NileRoutes.Models.Dtos.RegionDto;

namespace NileRoutes.Interfaces
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllRegionsAsync();
        Task<Region> GetRegionByIdAsync(Guid id);
        Task<Region> CreateRegionAsync(Region region);
        Task<Region?> UpdateRegionAsync(Guid id, Region region);
        Task<Region?> DeleteRegionAsync(Guid id);

    }
}
