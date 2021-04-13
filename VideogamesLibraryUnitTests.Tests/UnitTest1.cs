using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using VideoGames.Areas.Services;
using VideoGames.Controllers;
using VideoGames.Models;
using Xunit;

namespace VideogamesLibraryUnitTests.Tests
{
    public class GamesControllerTests
    {
        [Fact]
        public void Games_ShouldReturnViewWithGames()
        {
            //Arrange
            var mockData = new Mock<IUserData>();
            mockData.Setup(data => data.GetGames()).Returns(GetTestGames);
            var gamesController = new GamesController(mockData.Object);

            //Act
            var result = gamesController.Games();



            //Assert
            Assert.IsType<ViewResult>(result);
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
