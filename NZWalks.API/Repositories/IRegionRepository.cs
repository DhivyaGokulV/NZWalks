using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepository
    {
        public Task<List<Region>> GetAllRegionsAsync();
        public Task<Region?> GetRegionByIdAsync(Guid id);
        public Task<Region> AddRegionAsync(Region region);
        public Task<Region?> UpdateRegionAsync(Guid id, Region region);
        public Task<Region?> DeleteRegionAsync(Guid id);
    }
}
