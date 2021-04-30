using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using VideoGames.Areas.Services;
using VideoGames.Models;
using VideoGames.ViewModels;

namespace VideoGames.Controllers
{
    public class GamesController : Controller
    {
        
        private readonly IUserData _userData;

        public GamesController(IUserData userData)
        {
            _userData = userData;
        }
        
        [Authorize]
        public async Task<IActionResult> Games()
        {
            var currentUserLibrary =  await _userData.GetGamesAsync();
            var gamesViewModel = new GamesViewModel();
            gamesViewModel.GameLibrary = currentUserLibrary.ToList();
            return View(gamesViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(Game game)
        {
            if ( await _userData.SaveGamesAsync(game) == true)
            
                return RedirectToAction("Games");
 
            else
                return NotFound();
        }
        
        [Route("GamesController/LoadAddGameView")]
        public ActionResult LoadAddGameView()
        {
            return View("AddGameView");
        }

        [AutoValidateAntiforgeryToken]
        [Route("GamesController/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var game = await _userData.GetByIDAsync(id);

            if (game == null)

                return NotFound();

            var viewModel = new GamesViewModel(game);
         
            return View("AddGameView", viewModel);
        }

        [AutoValidateAntiforgeryToken]
        public async Task <IActionResult> Delete(int id)
        {
           
            if (await _userData.DeleteGameAsync(id))
            {
                return RedirectToAction("Games");
            }

                return NotFound();

        }

        public ActionResult SearchWebForGame(string gameName)
        {
            string search = @"http://www.google.com/search?q=" + gameName;
            return Redirect(search);
        }

    }
}
