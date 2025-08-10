using Microsoft.EntityFrameworkCore;
using NileRoutes.Models.Domain;

namespace NileRoutes.Data
{
    public class NileRoutesDbContext : DbContext
    {
        public NileRoutesDbContext(DbContextOptions<NileRoutesDbContext> options) : base(options)
        {

        }

        public DbSet<Walk> Walks { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seeding data for difficulty
            var difficulty = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("f1b4532c-2bd0-417d-aebc-08c3661d09e5"),
                    Name = "Easy"
                },

                new Difficulty()
                {
                    Id = Guid.Parse("594f967b-b050-4cd5-a244-5c76a94c09bb"),
                    Name = "Medium"
                },

                new Difficulty()
                {
                    Id = Guid.Parse("62e23720-f44c-4984-86cc-015f32be0ca1"),
                    Name = "Hard"
                }
            };
            modelBuilder.Entity<Difficulty>().HasData(difficulty);

            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("2b902116-dceb-4c77-a982-bd4f3bd6baae"),
                    Code = 101,
                    Name = "Cairo",
                    RegionImageUrl = "https://www.presidency.eg/media/99953/%D8%A7%D9%84%D8%B7%D8%B1%D9%8A%D9%82-%D8%A7%D9%84%D8%AF%D8%A7%D8%A6%D8%B1%D9%89-%D8%A7%D9%84%D8%A3%D9%88%D8%B3%D8%B7%D9%89-%D9%85%D9%86-%D8%B7%D8%B1%D9%8A%D9%82-%D8%A8%D9%84%D8%A8%D9%8A%D8%B3-%D8%AD%D8%AA%D9%89-%D8%AA%D9%82%D8%A7%D8%B7%D8%B9%D9%87-%D9%85%D8%B9-%D8%B7%D8%B1%D9%8A%D9%82-%D8%A7%D9%84%D9%82%D8%A7%D9%87%D8%B1%D8%A9-%D8%A7%D9%84%D8%B3%D9%88%D9%8A%D8%B3-0jpg.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("8c3e3508-6551-4411-88ce-c3904cfc82b2"),
                    Code = 102,
                    Name = "Alex",
                    RegionImageUrl = "https://nasseryouthmovement.net/uploads/images/2022/05/image_750x_62777178a4830.jpg"
                }
            };
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
