using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NileRoutes.Data
{
    public class NileRouteAuthDbContext : IdentityDbContext
    {
        public NileRouteAuthDbContext(DbContextOptions<NileRouteAuthDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "ffba811f-b06d-4771-af9a-455ebfd3ec83";
            var writerRoleId = "fddfca22-e6b2-4a27-a69e-0ab9da10de2b";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "READER"
                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "WRITER"
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
