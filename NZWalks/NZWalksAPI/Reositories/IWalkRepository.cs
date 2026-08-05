using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Reositories
{
    public interface IWalkRepository
    {
        // Adding filter logic to the repository
        Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null);
        Task<Walk?> GetAsync(Guid id);
        Task<Walk> AddAsync(Walk walk);
        Task<Walk?> UpdateAsync(Guid id, Walk walk);
        Task<Walk?> DeleteAsync(Guid id);
    }
}
