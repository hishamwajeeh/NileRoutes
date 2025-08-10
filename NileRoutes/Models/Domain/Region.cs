namespace NileRoutes.Models.Domain
{
    public class Region
    {
        public Guid Id { get; set; }
        public int Code { get; set; } 
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }

        //public Difficulty Difficulty { get; set; } // Assuming Difficulty is another class in your domain
        //public int DifficultyId { get; set; } // Foreign key for Difficulty
    }
}
