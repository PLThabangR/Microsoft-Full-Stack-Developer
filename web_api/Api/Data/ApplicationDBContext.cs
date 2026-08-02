using System;
using Sytem.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Context comes from here 
using Microsoft.EntityFrameworkCore;
using Api.Model; 

namespace Api.Data
{
    public class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        } 
        //Allow us to acces the DB, Manipulate and return data
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}