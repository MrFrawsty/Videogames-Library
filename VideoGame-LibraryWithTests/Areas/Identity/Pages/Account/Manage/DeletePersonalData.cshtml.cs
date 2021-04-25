using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using VideoGames.Areas.Identity.Data;
using VideoGames.Areas.Services;

namespace VideoGames.Areas.Identity.Pages.Account.Manage
{
    public class DeletePersonalDataModel : PageModel
    {
        private readonly UserManager<VideoGamesUser> _userManager;
        private readonly SignInManager<VideoGamesUser> _signInManager;
        private readonly ILogger<DeletePersonalDataModel> _logger;
        private readonly IUserData _userData;

        public DeletePersonalDataModel(
            UserManager<VideoGamesUser> userManager,
            SignInManager<VideoGamesUser> signInManager,
            ILogger<DeletePersonalDataModel> logger,
            IUserData userData)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _userData = userData;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public bool RequirePassword { get; set; }

        
        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            RequirePassword = await _userManager.HasPasswordAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            RequirePassword = await _userManager.HasPasswordAsync(user);
            if (RequirePassword)
            {
                if (!await _userManager.CheckPasswordAsync(user, Input.Password))
                {
                    ModelState.AddModelError(string.Empty, "Incorrect password.");
                    return Page();
                }
            }

            var context = _userData.GetDbContext();
            
            var videoGames =  await context.Games.Where(i=> i.VideoGamesUserId == user.Id ) 
                .ToListAsync();

                if(videoGames!=null)  
                {
                    foreach(var game in videoGames)
                    {
                    game.VideoGamesUserId=null;
                    context.Entry(game).State = EntityState.Modified;
                    }
                    await context.SaveChangesAsync();
                }

                    var userId = await _userManager.GetUserIdAsync(user);

                    var result = await _userManager.DeleteAsync(user);


          
            //var result = await _userManager.DeleteAsync(user);
            //var userId = await _userManager.GetUserIdAsync(user);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Unexpected error occurred deleting user with ID '{userId}'.");
            }

            await _signInManager.SignOutAsync();

            _logger.LogInformation("User with ID '{UserId}' deleted themselves.", userId);

            return Redirect("~/");
        }

      
    }
}
