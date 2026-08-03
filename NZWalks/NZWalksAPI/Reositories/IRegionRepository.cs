using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Reositories
{
    public interface IRegionRepository
    {
        //Get all Regions
        Task<List<Region>> GetAllAsync();

        //Get Region by Id
        Task<Region> GetAsync(Guid id);
        //Add Region
        Task<Region> AddAsync(Region region);
        //Update Region
        Task<Region> UpdateAsync(Guid id, Region region);
        //Delete Region
        Task<Region> DeleteAsync(Guid id);
    }
}
