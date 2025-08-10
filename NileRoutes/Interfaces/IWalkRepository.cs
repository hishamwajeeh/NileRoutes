using NileRoutes.Models.Domain;

namespace NileRoutes.Interfaces
{
    public interface IWalkRepository
    {
        Task<IEnumerable<Walk>> GetAllWalksAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true,
            int pageNumber = 1, int pageSize = 10);
        Task<Walk> GetWalkByIdAsync(Guid id);
        Task<Walk> CreateWalkAsync(Walk walk);
        Task<Walk> UpdateWalkAsync(Guid id, Walk walk);
        Task<Walk> DeleteWalkAsync(Guid id);
    }
}
