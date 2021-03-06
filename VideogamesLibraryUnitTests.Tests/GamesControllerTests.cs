using Microsoft.AspNetCore.Mvc;
using Moq;
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
        public async Task SaveGames_ShouldRedirectIfTrue()
        {
            var game = new Game() { GameId = 1, Name = "Test Game", Completed = true, Genre = "Test Genre" };
            //Arrange
            var mockData = new Mock<IUserData>();
            mockData.Setup(m => m.SaveGamesAsync(game)).ReturnsAsync(true);
            var gamesController = new GamesController(mockData.Object);

            //Act
            var result = await gamesController.Save(game);

            //Assert
            var actionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Games", actionResult.ActionName);

        }

        [Fact]
        public async Task SaveGames_ShouldReturnNotFoundIfFalse()
        {
            //Arrange
            var mockData = new Mock<IUserData>();
            var gamesController = new GamesController(mockData.Object);

            //Act
            var result = await gamesController.Save(new Game());

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Edit_ShouldReturnViewWithGameMatchingId()
        {
            //Arrange
            var game = new Game()
            { GameId = 1, Name = "Test Game 1", Genre = "Test Genre", Completed = false };
            var mockData = new Mock<IUserData>();
            mockData.Setup(m => m.GetByIDAsync(1)).ReturnsAsync(game);
            var gamesController = new GamesController(mockData.Object);

            //Act
            var result = await gamesController.Edit(1);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<GamesViewModel>(viewResult.ViewData.Model);
            Assert.Equal("AddGameView", viewResult.ViewName);
            Assert.Equal("Test Game 1", model.Game.Name);


        }

        [Fact]
        public async Task Edit_ShouldReturnNotFoundWithNullId()
        {
            //Arrange
            var mockData = new Mock<IUserData>();
            
            var gamesController = new GamesController(mockData.Object);

            //Act
            var result = await gamesController.Edit(1);

            //Assert
            Assert.IsType<NotFoundResult>(result);
            


        }

        [Fact]
        public async Task Delete_ShouldRedirectIfTrue()
        {
            //Arrange
            var mockData = new Mock<IUserData>();
            mockData.Setup(m => m.DeleteGameAsync(1)).ReturnsAsync(true);
            var gamesController = new GamesController(mockData.Object);

            //Act
            var result = await gamesController.Delete(1);

            //Assert
           var action = Assert.IsType<RedirectToActionResult>(result).ActionName;
            Assert.Equal("Games", action);
        }

        [Fact]
        public async Task Delete_ShouldReturnNotFoundIfFalse()
        {
            //Arrange
            var mockData = new Mock<IUserData>();
            mockData.Setup(m => m.DeleteGameAsync(1)).ReturnsAsync(false);
            var gamesController = new GamesController(mockData.Object);

            //Act
            var result = await gamesController.Delete(1);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void SearchWebForGame_ShouldReturnResult()
        {
            //Arrange
            var mockData = new Mock<IUserData>();
            var gamesController = new GamesController(mockData.Object);

            //Act
            var result = gamesController.SearchWebForGame("Test");

            //Assert
           var redirect = Assert.IsType<RedirectResult>(result);
            Assert.Equal(@"http://www.google.com/search?q=" + "Test", redirect.Url);

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
