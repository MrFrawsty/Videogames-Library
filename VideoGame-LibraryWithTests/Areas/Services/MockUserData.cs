using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGames.Models;
using VideoGames.ViewModels;

namespace VideoGames.Areas.Services
{
    public class MockUserData : IUserData
    {
        private List<Game> _mockGames;

        public MockUserData()
        {
            _mockGames = new List<Game>() { new Game { Name = "test1", GameId = 1, Completed = false, Genre = "test" },
                                          {new Game { Name = "test2", GameId = 2, Completed = true, Genre = "test"} },
                                          {new Game { Name = "test3", GameId = 3, Completed = true, Genre = "test"}} };

        }

        public void AddGame(Game game)
        {
            throw new NotImplementedException();
        }

        public bool DeleteGame(int id)
        {
            throw new NotImplementedException();
        }

        public Game GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Game> GetGames()
        {
            return _mockGames;
        }

        public Task<IEnumerable<Game>> GetGamesAsync()
        {
            throw new NotImplementedException();
        }

        public void SaveGames()
        {
            throw new NotImplementedException();
        }
         
        bool IUserData.SaveGames(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
