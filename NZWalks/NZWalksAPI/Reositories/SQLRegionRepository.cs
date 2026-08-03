using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace NZWalksAPI.Reositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalkDBContext dBContext;
        public SQLRegionRepository(NZWalkDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public Task<Region> AddAsync(Region region)
        {
            throw new NotImplementedException();
        }

        public Task<Region> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dBContext.Regions.ToListAsync();
        
        }

        public async Task<Region> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Region> UpdateAsync(Guid id, Region region)
        {
            throw new NotImplementedException();
        }
    }
}
