using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext: DbContext
    {
        DbSet<Region> Regions { get; set; }
        DbSet<Difficulty> Difficulties { get; set; }
        DbSet<Walk> Walks { get; set; }
        public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
               
        }
    }
}
