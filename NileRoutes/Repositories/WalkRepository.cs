using Microsoft.EntityFrameworkCore;
using NileRoutes.Data;
using NileRoutes.Interfaces;
using NileRoutes.Models.Domain;

namespace NileRoutes.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NileRoutesDbContext _context;
        public WalkRepository(NileRoutesDbContext context)
        {
             _context = context;
        }
        public async Task<Walk> CreateWalkAsync(Walk walk)
        {
            await _context.Walks.AddAsync(walk);
            await _context.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk> DeleteWalkAsync(Guid id)
        {
            var existingWalk = await _context.Walks.FirstOrDefaultAsync(w => w.Id == id);

            if (existingWalk == null)
            {
                return null;
            }

            _context.Walks.Remove(existingWalk);
            await _context.SaveChangesAsync();
            return existingWalk;
        }

        public async Task<IEnumerable<Walk>> GetAllWalksAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true,
            int pageNumber = 1, int pageSize = 10)
        {
            var walks = _context.Walks.Include("Region").Include("Difficulty").AsQueryable();

            //Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(w => w.Name.Contains(filterQuery));
                }
            }

            //Sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(w => w.Name) : walks.OrderByDescending(w => w.Name);
                }
                else if (sortBy.Equals("LengthKm", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(w => w.LengthKm) : walks.OrderByDescending(w => w.LengthKm);
                }
            }
            //Pagination
            int skipResult = (pageNumber - 1) * pageSize;

            return await walks.Skip(skipResult).Take(pageSize).ToListAsync();
        }

        public async Task<Walk> GetWalkByIdAsync(Guid id)
        {
            return await _context.Walks.Include("Region").Include("Difficulty").FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<Walk> UpdateWalkAsync(Guid id, Walk walk)
        {
            var existingWalk = await _context.Walks.FirstOrDefaultAsync(w => w.Id == id);
            if (existingWalk == null)
            {
                return null;
            }

            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthKm = walk.LengthKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.Difficulty = walk.Difficulty;
            existingWalk.Region = walk.Region;

            _context.Walks.Update(existingWalk);
            await _context.SaveChangesAsync();
            return existingWalk;
        }
    }
}
