using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalksAPI.Data
{
    public class AuthDbContext: IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options): base(options)
        {
            
        }

        //Seeding data in the database
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {   Id = Guid.NewGuid().ToString(),
                  ConcurrencyStamp = Guid.NewGuid().ToString(),
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {   Id = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            };//end of list
            //Seed data
            modelBuilder.Entity<IdentityRole>().HasData(roles);
            }  //end of method 


    } //end of class
}//End of namespace
        
   
