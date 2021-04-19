using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGames.Areas.Identity.Data;
using VideoGames.Models;
using VideoGames.ViewModels;

namespace VideoGames.Areas.Services
{
   public interface IUserData
    {

        public IEnumerable<Game> GetGames();
        public Task<IEnumerable<Game>> GetGamesAsync();
        public bool SaveGames(Game game);
        public Game GetByID(int id);
        public bool DeleteGame(int id);
        public void AddGame(Game game);
        public List<VideoGamesUser> GetUsers();
    }
}
