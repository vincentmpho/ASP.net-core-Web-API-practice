using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Walk_and_Trails_of_SA_API.Data
{
    public class SAWalksAuthDbContext : IdentityDbContext
    {
        public SAWalksAuthDbContext(DbContextOptions<SAWalksAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "77397e81-38c6-4aab-ab63-b1fc8543b1fd";
            var writerRoleId = "491f81be-bcd2-45aa-9351-ed8a701cb110";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id =readerRoleId,
                    ConcurrencyStamp= readerRoleId,
                    Name = "readerRoleId",
                    NormalizedName = "readerRoleId".ToUpper(),
                },
                 new IdentityRole
                {
                    Id =writerRoleId,
                    ConcurrencyStamp= writerRoleId,
                    Name = "writerRoleId",
                    NormalizedName ="writerRoleId" .ToUpper(),
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
