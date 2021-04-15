using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using VideoGames.Areas.Services;
using VideoGames.Controllers;
using VideoGames.Models;
using VideoGames.ViewModels;
using Xunit;
using System.Threading.Tasks;

namespace VideogamesLibraryUnitTests.Tests
{
    public class GamesControllerTests
    {
  
        [Fact]
        public async Task Games_ShouldReturnViewWithGames()
        {
            //Arrange
            var mockData = new Mock<IUserData>();
            mockData.Setup(data => data.GetGamesAsync()).ReturnsAsync(GetTestGames);
            var gamesController = new GamesController(mockData.Object);

            //Act
            var result = await gamesController.Games();



            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var viewModel = Assert.IsAssignableFrom<GamesViewModel>(viewResult.ViewData.Model);
            Assert.Equal(2, viewModel.GameLibrary.Count);


        }

        [Fact]
        public void SaveGames_ShouldRedirectIfTrue()
        {
            var game = new Game() { GameId = 1, Name = "Test Game", Completed = true, Genre = "Test Genre" };
            //Arrange
            var mockData = new Mock<IUserData>();
            mockData.Setup(m => m.SaveGames(game)).Returns(true);
            var gamesController = new GamesController(mockData.Object);

            //Act
            var result = gamesController.Save(game);

            //Assert
            var actionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Games", actionResult.ActionName);

        }

        [Fact]
        public void SaveGames_ShouldReturnNotFoundIfFalse()
        {
            //Arrange
            var mockData = new Mock<IUserData>();
            var gamesController = new GamesController(mockData.Object);

            //Act
            var result = gamesController.Save(new Game());

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        private List<Game> GetTestGames()
        {
            var games = new List<Game>()
            {new Game() { GameId = 1, Name = "Test Game 1", Genre = "Test Genre", Completed = false },
            {new Game() { GameId = 2, Name = "Test Game 2", Genre = "Test Genre", Completed = false } } };

            return games;


        }
    }
}
