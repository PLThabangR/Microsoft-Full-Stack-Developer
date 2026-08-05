using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Reositories
{

    public class WalkServiceRepository : IWalkRepository
    {

        //Inject dbContext
        private readonly NZWalkDBContext dbContext;

        public WalkServiceRepository(NZWalkDBContext dBContext)
        {
            this.dbContext = dBContext;
        }

        public async Task<Walk> AddAsync(Walk walk)
        {   
            //add to database
            await dbContext.Walks.AddAsync(walk);
            //save changes
            await dbContext.SaveChangesAsync();
            //return the created
            return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
           //Check if exist 
           var existingWalk =await  dbContext.Walks.FirstOrDefaultAsync(x => x.id == id);

            if (existingWalk == null)
            {
                return null;
            }
            //remove from database
            dbContext.Walks.Remove(existingWalk);
            //save changes
           await  dbContext.SaveChangesAsync();
            //return the deleted
            return existingWalk;
        }

        public async Task<List<Walk>> GetAllAsync(string? filterOn=null, string? filterQuery=null)
        {  
            //Include details from region and difficulty tables as Querables
             var walks =  dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();
            
            //Filtering
            //If filterOn and filterQuery are not null
            if (string.IsNullOrWhiteSpace(filterOn)==false && string.IsNullOrWhiteSpace(filterQuery)==false)
            {
                //check which column fliterOn is at
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase) )
                {  //Filter using the column and the query
                    walks = walks.Where(x => x.Name.Contains(filterQuery));

                }
              
            }

                //return query results to User
                return await walks.ToListAsync();
            //Get all walks from the database
            ///Include details from region and difficulty tables
           // return await dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
           
        }

        public async Task<Walk?> GetAsync(Guid id)
        {           //Get the region from the database if not exist it will return null
            return await dbContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {   
            // check if region exists
            var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.id == id);
            // update region if it exists
            if (existingWalk == null)
            {
                return null;
            }
            //update values
            existingWalk.Name = walk.Name;
            existingWalk.Description= walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl= walk.WalkImageUrl;
            existingWalk.RegionId = walk.RegionId;
            existingWalk.DifficultyId = walk.DifficultyId;

            //save changes
            await dbContext.SaveChangesAsync();
            // return the updated region
            return existingWalk;
            
        }
    }
}
