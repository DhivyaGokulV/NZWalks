using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;

        public SQLRegionRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<Region> AddRegionAsync(Region region)
        {
            await nZWalksDbContext.Regions.AddAsync(region);
            await nZWalksDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteRegionAsync(Guid id)
        {
            var region = await GetRegionByIdAsync(id);
            if (region == null)
            {
                return null;
            }
            nZWalksDbContext.Regions.Remove(region);
            await nZWalksDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<List<Region>> GetAllRegionsAsync()
        {
            return await nZWalksDbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetRegionByIdAsync(Guid id)
        {
            return await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region?> UpdateRegionAsync(Guid id, Region region)
        {
            var existingRegion = await GetRegionByIdAsync(id);
            if (existingRegion == null)
            {
                return null;
            }

            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            await nZWalksDbContext.SaveChangesAsync();
            return existingRegion;
        }
    }
}
