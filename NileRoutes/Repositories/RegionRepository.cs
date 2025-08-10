using Microsoft.EntityFrameworkCore;
using NileRoutes.Data;
using NileRoutes.Interfaces;
using NileRoutes.Models.Domain;
using NileRoutes.Models.Dtos.RegionDto;

namespace NileRoutes.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NileRoutesDbContext _context;
        public RegionRepository(NileRoutesDbContext context)
        {
            _context = context;
        }

        public async Task<Region> CreateRegionAsync(Region region)
        {
            await _context.Regions.AddAsync(region);
            await _context.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteRegionAsync(Guid id)
        {
            var existingRegion = await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }
            _context.Regions.Remove(existingRegion);
            await _context.SaveChangesAsync();
            return existingRegion;
        }

        public async Task<IEnumerable<Region>> GetAllRegionsAsync()
        {
            return await _context.Regions.ToListAsync();
        }

        public async Task<Region> GetRegionByIdAsync(Guid id)
        {
            return await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> UpdateRegionAsync(Guid id, Region region)
        {
            var existingRegion = await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }
            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            await _context.SaveChangesAsync();
            return existingRegion;
        }
    }
}
