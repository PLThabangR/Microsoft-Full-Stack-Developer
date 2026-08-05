using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Reositories
{
    public interface IWalkRepository
    {
        // Adding filter logic to the repository
        Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool? isAscending = false, int pageNumber = 1, int pageSize = 1000);
        Task<Walk?> GetAsync(Guid id);
        Task<Walk> AddAsync(Walk walk);
        Task<Walk?> UpdateAsync(Guid id, Walk walk);
        Task<Walk?> DeleteAsync(Guid id);
    }
}
