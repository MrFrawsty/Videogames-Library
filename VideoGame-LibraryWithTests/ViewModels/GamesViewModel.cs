using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGames.Models;

namespace VideoGames.ViewModels
{
    public class GamesViewModel
    {
        public List<Game> GameLibrary { get; set; }
        public Game Game { get; set; }

        public GamesViewModel(Game game)
        {
            Game = game;
        }
        
        public GamesViewModel()
        {

        }

        public GamesViewModel(List<Game> gameLibrary)
        {
            GameLibrary = gameLibrary;
        }
      
    }
}
