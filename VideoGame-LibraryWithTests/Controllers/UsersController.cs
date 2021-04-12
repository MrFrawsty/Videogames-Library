using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VideoGames.Areas.Identity.Data;
using VideoGames.Data;
using VideoGames.Models;
using VideoGames.ViewModels;

namespace VideoGames.Controllers
{
    public class UsersController : Controller
    {
        public List<Game> CurrentUsersLibrary { get; set; }
        UserManager<VideoGamesUser> _userManager;
        VideoGamesContext _videoGamesContext;
       

        public UsersController(VideoGamesContext videoGamesContext, UserManager<VideoGamesUser> userManager)
        {
            _videoGamesContext = videoGamesContext;
            _userManager = userManager;
 
            
        }

        public ActionResult Users()
        {
            UsersViewModel usersViewModel = new UsersViewModel();
            usersViewModel.Users = GetUsers();
            return View(usersViewModel);
        }

        public ActionResult DeleteUser(string id)
        {
            var user = _videoGamesContext.Users.SingleOrDefault(user => user.Id == id.ToString());
            _videoGamesContext.Users.Remove(user);
            _videoGamesContext.SaveChanges();

            return RedirectToAction("Users");

        }

        public async Task GetCurrentUserGameLibrary()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            
            CurrentUsersLibrary = currentUser.UserGameLibrary;
            
        }

        public VideoGamesUser GetCurrentUser()
        {
           // var claimsIdentity = (ClaimsIdentity)this.User.Identity;
           // var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var id = HttpContext.User.Identity.Name;
            
            return _videoGamesContext.Users.FirstOrDefault(u => u.Id == id);
        }

     

        public List<VideoGamesUser> GetUsers()
        {
           return _videoGamesContext.Users.ToList();
        }
    }
}
