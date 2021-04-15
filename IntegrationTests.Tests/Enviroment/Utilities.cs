using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGames.Areas.Identity.Data;
using VideoGames.Data;
using VideoGames.Models;
using Moq;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IntegrationTests.Tests
{
    class Utilities
    {
        public static void InitializeTestDb(VideoGamesContext videoGamesContext)
        {
            videoGamesContext.AddRange(GetSeedUsers());
            videoGamesContext.SaveChanges();
        }

        public static void ReInitializeTestDb(VideoGamesContext videoGamesContext)
        {
            videoGamesContext.Games.RemoveRange(videoGamesContext.Games);
            InitializeTestDb(videoGamesContext);
        }

        public static List<VideoGamesUser> GetSeedUsers()
        {
            var users = new List<VideoGamesUser>()
           {
             new VideoGamesUser()
             {
               Id = "1",
               UserGameLibrary = new List<Game>
               {
                new Game() { GameId = 1,Name ="User1 First Test Game Name", Genre = "Test Genre 1", Completed = false},
                new Game() { GameId = 2, Name ="User1 Second Test Game Name",Genre = "Test Genre 2", Completed = false},
                new Game() { GameId = 3, Name ="User1 Third Test Game Name", Genre = "Test Genre 3", Completed = false}
               }
             },
            new VideoGamesUser()
             {
             Id = "2",
             UserGameLibrary = new List<Game>
             {
             new Game() { GameId = 1, Name = "User2 First Test Game Name", Genre = "Test Genre 1", Completed = false},
             new Game() { GameId = 2, Name = "User2 Second Test Game Name", Genre = "Test Genre 2", Completed = false},
             new Game() { GameId = 3, Name = "User2 Third Test Game Name", Genre = "Test Genre 3", Completed = false}
              }
            },
           new VideoGamesUser()
            {
            Id = "3",
            UserGameLibrary = new List<Game>
            {
             new Game() { GameId = 1, Name = "User3 First Test Game Name", Genre = "Test Genre 1", Completed = false},
             new Game() { GameId = 2, Name = "User3 Second Test Game Name", Genre = "Test Genre 2", Completed = false},
             new Game() { GameId = 3, Name = "User3 Third Test Game Name", Genre = "Test Genre 3", Completed = false}
            }
            }
        };
            return users;
        }

        public static Mock<UserManager<VideoGamesUser>> MockUserManager<TUser>() where TUser : class
        {
            var userList = GetSeedUsers();
            var store = new Mock<UserStore<VideoGamesUser>>();
            foreach(var user in userList)
            {
                store.Setup(s => s.CreateAsync(user, CancellationToken.None));
            }
         
            return new Mock<UserManager<VideoGamesUser>>(store.Object);
 
        }

        public static UserStore<VideoGamesUser> GetUserStore()
        {
            var userList = GetSeedUsers();
            var store = new Mock<UserStore<VideoGamesUser>>();
            foreach (var user in userList)
            {
                store.Setup(s => s.CreateAsync(user, CancellationToken.None));
            }

            return store.Object;

        }
    }
}
