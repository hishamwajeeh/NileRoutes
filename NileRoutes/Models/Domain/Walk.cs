using System.ComponentModel.DataAnnotations.Schema;

namespace NileRoutes.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthKm { get; set; }
        public string? WalkImageUrl { get; set; }

        // Difficulty relationship
        public Guid DifficultyId { get; set; }
        [ForeignKey("DifficultyId")]
        public Difficulty Difficulty { get; set; }

        // Region relationship
        public Guid RegionId { get; set; }
        [ForeignKey("RegionId")]
        public Region Region { get; set; }
    }
}
