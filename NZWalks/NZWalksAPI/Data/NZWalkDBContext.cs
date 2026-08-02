using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Data
{
    public class NZWalkDBContext : DbContext
    {
        public NZWalkDBContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {


        }

        // add DbSet<T> properties here, e.g.
        //represernts collections inside the database
        //this will createb the table in the database
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }
      
    }
}
