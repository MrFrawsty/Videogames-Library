using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGames.Models;
using VideoGames.ViewModels;

namespace VideoGames.Areas.Services
{
   public interface IUserData
    {

        public IEnumerable<Game> GetGames();
        public bool SaveGames(Game game);
        public Game GetByID(int id);
        public bool DeleteGame(int id);
        public void AddGame(Game game);
    }
}
