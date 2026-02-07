using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public DbSet<Region> Regions { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            var difficulties = new List<Difficulty>()
            {
                new()
                {
                    Id = Guid.Parse("6782b3bb-97ac-401c-9af0-23be8f8b4a12"),
                    Name = "Easy"
                },
                new()
                {
                    Id = Guid.Parse("970543e6-4357-4a54-99e5-a9bd00810fbb"),
                    Name = "Medium"
                },
                new()
                {
                    Id = Guid.Parse("647ad00f-8df6-473d-83bb-7462b8083dc1"),
                    Name = "Hard"
                }
            };
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            var regions = new List<Region>()
            {
                new()
                {
                    Id = Guid.Parse("ebdcfdce-ab1a-4c35-bb6e-1b52f717b9d9"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = "https://example.com/images/northland.jpg",
                },
                new()
                {
                    Id = Guid.Parse("94856d92-e4b1-4866-8bb6-9c06b8f7f021"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://example.com/images/auckland.jpg"
                },
                new()
                {
                    Id = Guid.Parse("87cc682e-5889-4856-ae98-2c7c3f072304"),
                    Name = "Waikato",
                    Code = "WKO",
                    RegionImageUrl = "https://example.com/images/waikato.jpg"
                }
            };
            modelBuilder.Entity<Region>().HasData(regions);

            //var walks = new List<Walk>()
            //{
            //    new Walk()
            //    {
            //        Id = Guid.Parse("d4e5f6g7-h8i9-0j1k-2l3m-4n5o6p7q8r9s"),
            //        Name = "Coastal Walk",
            //        LengthInKm = 10.5,
            //        RegionId = regions[0].Id,
            //        DifficultyId = difficulties[0].Id,
            //        WalkImageUrl = "https://example.com/images/coastal_walk.jpg"
            //    },
            //    new Walk()
            //    {
            //        Id = Guid.Parse("e5f6g7h8-i9j0-1k2l-3m4n-5o6p7q8r9s0t"),
            //        Name = "Mountain Trail",
            //        LengthInKm = 15.2,
            //        RegionId = regions[1].Id,
            //        DifficultyId = difficulties[1].Id,
            //        WalkImageUrl = "https://example.com/images/mountain_trail.jpg"
            //    },
            //    new Walk()
            //    {
            //        Id = Guid.Parse("f6g7h8i9-j0k1-2l3m-4n5o-6p7q8r9s0t1u"),
            //        Name = "Forest Path",
            //        LengthInKm = 8.3,
            //        RegionId = regions[2].Id,
            //        DifficultyId = difficulties[2].Id,
            //        WalkImageUrl = "https://example.com/images/forest_path.jpg"
            //    }
            //};
            //modelBuilder.Entity<Walk>().HasData(walks);
        }
    }
}
