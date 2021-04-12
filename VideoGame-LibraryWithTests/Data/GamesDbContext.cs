using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGames.Models;

namespace VideoGames.Data
{
    public class GamesDbContext : DbContext
    {
      
       //public DbSet<Game> NewGames { get; set; }
       // public GamesDbContext(DbContextOptions<GamesDbContext> options)
       //     : base(options)
       // {

       // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Game>().HasData(new Game("Batman Arkham Asylum", "Action", false, -1));
            //modelBuilder.Entity<Game>().HasData(new Game("Guild Wars 2", "MMORPG", false, -2));
            //modelBuilder.Entity<Game>().HasData(new Game("Halo", "Shooter", true, -3));
            //modelBuilder.Entity<Game>().HasData(new Game("Call Of Duty 2", "Shooter", false, -4));
            //modelBuilder.Entity<Game>().HasData(new Game("BioShock Infinite", "Shooter", true, -5));

        }
    }
}
