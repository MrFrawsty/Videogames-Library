using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGames.Areas.Identity.Data;
using VideoGames.Data;
using VideoGames.Models;
using VideoGames.ViewModels;

namespace VideoGames.Areas.Services
{
   public interface IUserData
    {
        public Task<IEnumerable<Game>> GetGamesAsync();
        public Task<bool> SaveGamesAsync(Game game);
        public Task<Game> GetByIDAsync(int id);
        public Task <bool> DeleteGameAsync(int id);
        public Task AddGameAsync(Game game);
        public bool DeleteUser(VideoGamesUser user);
        public List<VideoGamesUser> GetUsers();
        public VideoGamesContext GetDbContext(); 
    }
}
