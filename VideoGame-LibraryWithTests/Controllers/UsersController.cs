using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGames.Areas.Identity.Data;
using VideoGames.Areas.Services;
using VideoGames.Data;
using VideoGames.Models;
using VideoGames.ViewModels;

namespace VideoGames.Controllers
{
    //THIS CLASS IS FOR DEVELOPMENT ONLY
    //PRODUCTION CODE WOULD HAVE SAFER WAY OF MANAGING DATABASE

    public class UsersController : Controller
    {
        private readonly UserData _userData;
        private readonly UserManager<VideoGamesUser> _userManager;
        private readonly VideoGamesContext _videoGamesContext;
        public List<Game> CurrentUsersLibrary { get; set; }
       

        public UsersController(VideoGamesContext videoGamesContext, UserManager<VideoGamesUser> userManager, UserData userData)
        {
            _userData = userData;
            _videoGamesContext = videoGamesContext;
            _userManager = userManager;
        }

        public ActionResult Users()
        {
            UsersViewModel usersViewModel = new UsersViewModel();
            usersViewModel.Users = GetUsers();
            return View(usersViewModel);
        }

        public ActionResult DeleteUser(int id)
        {

            var user = _videoGamesContext.Users.SingleOrDefault(user => user.Id == id);
            _videoGamesContext.Users.Remove(user);
            _videoGamesContext.SaveChanges();

            return RedirectToAction("Users");

        }

        public async Task GetCurrentUserGameLibrary()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            
            CurrentUsersLibrary = currentUser.UserGameLibrary;
            
        }

        public List<VideoGamesUser> GetUsers()
        {
           return _videoGamesContext.Users.ToList();
        }
    }
}
