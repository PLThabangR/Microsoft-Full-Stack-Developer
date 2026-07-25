using System;
using Microsoft.EntityFrameworkCore;
using WebApplication1.models;

namespace WebApplication1;

public class GameStoreConrext (DbContextOptions<GameStoreConrext> options):DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();

    public DbSet<Genre> Genre => Set<Genre>();

}
