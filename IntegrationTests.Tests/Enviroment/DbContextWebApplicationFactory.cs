using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGames.Data;
using Xunit;

namespace IntegrationTests.Tests
{
   public class DbContextWebApplicationFactory<TStartup> 
     : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault
                (d => d.ServiceType == typeof(DbContextOptions<VideoGamesContext>));

                services.Remove(descriptor);

                services.AddDbContext<VideoGamesContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                });

                var serviceProvider = services.BuildServiceProvider();

                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                   
                    var db = scopedServices.GetRequiredService<VideoGamesContext>();
                    var logger = scopedServices
                    .GetRequiredService<ILogger<DbContextWebApplicationFactory<TStartup>>>();


                    db.Database.EnsureCreated();

                    try
                    {
                        Utilities.InitializeTestDb(db);
                    }
                    catch(Exception e)
                    {
                        logger.LogError(e, "An error has occured while seeding the database. Error:" + e.Message);
                    }
                }

            });
  
        }

    }
}
