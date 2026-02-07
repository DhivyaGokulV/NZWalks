using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> AddWalkAsync(Walk walk);
        Task<Walk?> RemoveWalkAsync(Guid id);
        Task<Walk?> UpdateWalkAsync(Guid id, Walk walk);
        Task<Walk?> GetWalkAsync(Guid id);
        Task<List<Walk>> GetAllWalksAsync();
    }
}
