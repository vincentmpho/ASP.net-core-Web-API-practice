using Microsoft.EntityFrameworkCore;
using Walk_and_Trails_of_SA_API.Models.Domain;

namespace Walk_and_Trails_of_SA_API.Data 
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed data for Difficulties
            //Easy, Medium, Hard

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("c12576f9-dbb8-42ac-8c8b-7ac7e1d5c269"),
                    Name = "Easy"
                },
                new Difficulty
                {
                    Id = Guid.Parse("d474c924-8ef8-4dc4-b002-308692b1d379"),
                    Name = "Medium"
                },
                new Difficulty
                {
                    Id =Guid.Parse("0b6aa6d4-3066-489e-a8cb-28c3bc73e920"),
                    Name = "Hard"
                }
            };

            //Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            //Seed data for Region
            var regions = new List<Region>()
            {
                new Region()
                {
                    Id=Guid.Parse("fd000ceb-2b33-4e59-a38f-20373e302e03"),
                    Name="Western Cape",
                    Code="WC",
                    RegionImageUrl="https://example.com/western_cape_image.jpg"
                },
                 new Region()
                {
                    Id=Guid.Parse("46595a53-78d5-481f-858b-2c674aa6a646"),
                    Name="Gauteng",
                    Code="GP",
                    RegionImageUrl="https://example.com/gauteng_image.jpg"
                },
                  new Region()
                {
                    Id=Guid.Parse("de08f807-4914-4f76-8fd5-f5ed4dc3b24e"),
                    Name="KwaZulu-Natal",
                    Code="KZN",
                    RegionImageUrl="https://example.com/kwazulu_natal_image.jpg"
                }
            };

            //Seed regions to the database
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }

}
