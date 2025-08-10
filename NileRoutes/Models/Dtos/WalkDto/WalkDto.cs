using NileRoutes.Models.Domain;
using NileRoutes.Models.Dtos.RegionDto;
using NileRoutes.Models.Dtos.DifficultyDto;

namespace NileRoutes.Models.Dtos.WalkDto
{
    public class WalkDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }
        public RegionDto.RegionDto Region { get; set; }
        public DifficultyDto.DifficultyDto Difficulty { get; set; }
    }
}
