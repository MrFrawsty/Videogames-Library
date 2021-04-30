using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGames.Areas.Identity.Data;
using VideoGames.Data;
using VideoGames.Models;

namespace VideoGames.Areas.Services
{
    public class UserData : IUserData
    {
        private readonly UserManager<VideoGamesUser> _userManager;
        private readonly VideoGamesContext _videoGamesContext;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserData(UserManager<VideoGamesUser> userManager, VideoGamesContext videoGamesContext, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _videoGamesContext = videoGamesContext;
            _contextAccessor = httpContextAccessor;

        } 

   
        public async Task<IEnumerable<Game>> GetGamesAsync()
        {
            int userId = _userManager.GetUserAsync(_contextAccessor.HttpContext.User).Result.Id;
            var userLibraries = _userManager.Users.Include(u => u.UserGameLibrary);
            return await Task.FromResult(userLibraries.Where(x => x.Id == userId).FirstOrDefault().UserGameLibrary);
        }

        public async Task AddGameAsync(Game game)
        {
            var userId = _userManager.GetUserAsync(_contextAccessor.HttpContext.User).Result.Id;
            var userLibraries = _userManager.Users.Include(u => u.UserGameLibrary);
            var currentLibrary = await Task.FromResult(userLibraries.Where(x => x.Id == userId).FirstOrDefault().UserGameLibrary);
            currentLibrary.Add(game);
            _videoGamesContext.SaveChanges();
        }

        public async Task<Game> GetByIDAsync(int id)
        {
          return await Task.FromResult(_videoGamesContext.Games.SingleOrDefault(g => g.GameId == id));
        }

        public async Task<bool> DeleteGameAsync(int id)
        {
            var game = await Task.FromResult(_videoGamesContext.Games.SingleOrDefault(game => game.GameId == id));
            if (game != null)
            {
                _videoGamesContext.Remove(game);
                _videoGamesContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task DeleteAllGamesAsync()
        {
            var games = await GetGamesAsync();
            var list = games.ToList();
            
            for(int i = 0; i < list.Count; i++)
            {
                var game = list[i];
              
            }
            _videoGamesContext.SaveChanges();
        }

        public async Task<bool> SaveGamesAsync(Game game)
        { 
            var userId = _userManager.GetUserAsync(_contextAccessor.HttpContext.User).Result.Id;
            var userLibraries = _userManager.Users.Include(u => u.UserGameLibrary);
            var currentLibrary = userLibraries.Where(x => x.Id == userId).FirstOrDefault().UserGameLibrary;


            if (_videoGamesContext != null)
            {
                if (game.GameId == 0)
                {
                    await AddGameAsync(game);
                }
                else
                {
                    var selectedGame = game;
                    var existingGame = currentLibrary.Single(g => g.GameId == game.GameId);
                    existingGame.Name = game.Name;
                    existingGame.Genre = game.Genre;
                    existingGame.Completed = game.Completed;
                }

                _videoGamesContext.SaveChanges();
                 return true;
            }

            else
            { 
                return false;
            }
        }

        public bool DeleteUser(VideoGamesUser user)
        {

            if (user == null)
            {
                return false;
            }
            
                _videoGamesContext.Users.Remove(user);
                _videoGamesContext.SaveChanges();

            return true;
        }

        public List<VideoGamesUser> GetUsers()
        {
            return _videoGamesContext.Users.ToList();
        }

        public VideoGamesContext GetDbContext()
        {
            return _videoGamesContext;
        }


    }
}
