using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGames.Models;

namespace VideoGames.Data
{
    public class DbInitializer 
    {

        public static void SeedDb(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<GamesDbContext>();
                //if(!context.Games.Any())
                //{
                //    context.AddRange(new Game("Bioshock Infinite", "Shooter", true), new Game("Borderlands 2", "Looter Shooter", true));
                //}
            }
        }
    }
}
