using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Reositories
{
    public class InMemoryRepository : IRegionRepository
    {
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
            return new List<Region> {      new Region { Id = Guid.NewGuid(), Name = "Auckland", Code = "Auckland" },
    new Region { Id = Guid.NewGuid(), Name = "Wellington", Code = "Wellington" },
    new Region { Id = Guid.NewGuid(), Name = "Christchurch", Code = "Christchurch" }
            };
        }


        

        

        public Task<Region> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Region> UpdateAsync(Guid id, Region region)
        {
            throw new NotImplementedException();
        }
    }
}
