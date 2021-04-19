﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Game> GetGames()
        {
            var userId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            var userLibraries = _userManager.Users.Include(u => u.UserGameLibrary);
            return userLibraries.Where(x => x.Id == userId).FirstOrDefault().UserGameLibrary;

           
        }

        public async Task<IEnumerable<Game>> GetGamesAsync()
        {
            var userId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            var userLibraries = _userManager.Users.Include(u => u.UserGameLibrary);
            return await Task.FromResult(userLibraries.Where(x => x.Id == userId).FirstOrDefault().UserGameLibrary);

        }

        public void AddGame(Game game)
        {
            var userId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            var userLibraries = _userManager.Users.Include(u => u.UserGameLibrary);
            var currentLibrary = userLibraries.Where(x => x.Id == userId).FirstOrDefault().UserGameLibrary;
            currentLibrary.Add(game);
            _videoGamesContext.SaveChanges();
        }

        public Game GetByID(int id)
        {
          return _videoGamesContext.Games.SingleOrDefault(g => g.GameId == id);
        }

        public bool DeleteGame(int id)
        {
            var game = _videoGamesContext.Games.SingleOrDefault(game => game.GameId == id);
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

        public bool SaveGames(Game game)
        { 
            var userId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            var userLibraries = _userManager.Users.Include(u => u.UserGameLibrary);
            var currentLibrary = userLibraries.Where(x => x.Id == userId).FirstOrDefault().UserGameLibrary;


            if (_videoGamesContext != null)
            {
                if (game.GameId == 0)
                {
                    AddGame(game);
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

        public List<VideoGamesUser> GetUsers()
        {
            return _videoGamesContext.Users.ToList();
        }

    }
}
