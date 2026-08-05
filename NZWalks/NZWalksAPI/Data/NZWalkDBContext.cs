using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Data
{
    public class NZWalkDBContext : DbContext
    {
        //Inject the dbContextOptions into the constructor use generics since we work with multiple dbContextOptions
        public NZWalkDBContext(DbContextOptions<NZWalkDBContext> dbContextOptions): base(dbContextOptions)
        {


        }

        // add DbSet<T> properties here, e.g.
        //represernts collections inside the database
        //this will createb the table in the database
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        //Seeding
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);
        //     //Create a list difficulties data
        //    var difficultyData = new List<Difficulty>()
        //    {
        //        new Difficulty()
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = "Easy"
        //        },
        //        new Difficulty()
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = "Medium"
        //        },
        //        new Difficulty()
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = "Hard"
        //        }
        //    };
        //     // model builder will create the table
        //     modelBuilder.Entity<Difficulty>().HasData(difficultyData);

        //     //Seed data for regions 
        //     var regionData = new List<Region>()
        //     {
        //         new Region()
        //         {
        //             Id = Guid.NewGuid(),
        //             Name = "Auckland",
        //             Code = "Auckland",
        //             imageUrl = "https://images.unsplash.com/photo-1506973038032-c6f1e4c8024f?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80"
        //         },
        //         new Region()
        //         {
        //             Id = Guid.NewGuid(),
        //             Name = "Wellington",
        //             Code = "Wellington",
        //             imageUrl = "https://images.unsplash.com/photo-1506973038032-c6f1e4c8024f?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80"
        //         },
        //         new Region()
        //         {
        //             Id = Guid.NewGuid(),
        //             Name = "Christchurch",
        //             Code = "Christchurch",
        //             imageUrl = "https://images.unsplash.com/photo-1506973038032-c6f1e4c8024f?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80"
        //         }
        //     };// end of region data array

        //     //model builder will create the table
        //     modelBuilder.Entity<Region>().HasData(regionData);


            


        // }       
           
        // }
    }
    }

