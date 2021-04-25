using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VideoGames.Areas.Identity.Data;
using VideoGames.Models;

namespace VideoGames.Data
{
    public class VideoGamesContext : IdentityDbContext<VideoGamesUser>
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<VideoGamesUser> VideoGamesUsers { get; set; }
        public VideoGamesContext(DbContextOptions<VideoGamesContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Game>()
                .HasOne<VideoGamesUser>(u => u.VideoGamesUser)
                .WithMany(g => g.UserGameLibrary)
                .HasForeignKey("VideoGamesUserId")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

                     
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
