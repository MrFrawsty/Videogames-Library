using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VideoGames;
using VideoGames.Areas.Identity.Data;
using VideoGames.Areas.Services;
using VideoGames.Data;
using VideoGames.Models;
using Xunit;

namespace IntegrationTests.Tests
{
    public class UserDataTests : IClassFixture<DbContextWebApplicationFactory<Startup>>
    {
        private readonly DbContextWebApplicationFactory<Startup> _dbContextWebApplicationFactory;
        private readonly HttpClient _httpClient;
        private readonly VideoGamesContext _videoGamesContext;

        public UserDataTests(DbContextWebApplicationFactory<Startup> dbContextwebApplicationFactory)
        {
            _dbContextWebApplicationFactory = dbContextwebApplicationFactory;
            _httpClient = _dbContextWebApplicationFactory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });

           // var host = _dbContextWebApplicationFactory.Server.Host;

            using (var scope = _dbContextWebApplicationFactory.Services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;

                _videoGamesContext = scopedServices.GetRequiredService<VideoGamesContext>();

                _videoGamesContext.Database.EnsureCreated();

            }

        }

        [Fact]
        public async Task UserDataGetGamesAsync_ShouldReturnGames()
        {
            //Arrange

            var store = Utilities.GetUserStore();
            var user = new VideoGamesUser() { Id = "1" };
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };
            var identity = new ClaimsIdentity(claims);
            var claimsPrincipal = new ClaimsPrincipal(identity);
            
            var httpContext = new Mock<HttpContext>();
            httpContext.Setup(c => c.User).Returns(claimsPrincipal);
            var context_Accessor = new Mock<IHttpContextAccessor>();
            context_Accessor.Setup(c => c.HttpContext).Returns(httpContext.Object);
            var userManager = Utilities.MockUserManager<VideoGamesUser>();
         
            var userData = new UserData(userManager.Object, _videoGamesContext, context_Accessor.Object);

            //Act
            var result = await userData.GetGamesAsync();

            //Assert
            Assert.IsAssignableFrom<IEnumerable<Game>>(result);
        }

    }
}
