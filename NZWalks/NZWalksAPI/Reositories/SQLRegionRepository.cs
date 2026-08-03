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
        public async Task<Region> AddAsync(Region region)
        {       //add to database
             await dBContext.Regions.AddAsync(region);
             //save
            await dBContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
                //check if region exist
            var existingRegion = await dBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }

             dBContext.Regions.Remove(existingRegion);
            await dBContext.SaveChangesAsync();
            return existingRegion;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dBContext.Regions.ToListAsync();
        
        }

        public async Task<Region?> GetAsync(Guid id)
        {
            return await dBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        { 
            // check if region exists
            var existingRegion = dBContext.Regions.FirstOrDefault(x => x.Id == id);
            // update region if it exists
            if (existingRegion == null)
            {
                return null;
            }
            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.imageUrl = region.imageUrl;
            //save changes
            await dBContext.SaveChangesAsync();
            // return the updated region
            return existingRegion;
             
        }
    }
}
