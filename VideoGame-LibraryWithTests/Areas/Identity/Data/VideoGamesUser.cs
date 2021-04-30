using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using VideoGames.Models;

namespace VideoGames.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the VideoGamesUser class
    public class VideoGamesUser : IdentityUser<int>
    {
        [InverseProperty(nameof(Game.VideoGamesUser))]
        public List<Game> UserGameLibrary { get; set; }

        public VideoGamesUser(List<Game> games)
        {
            UserGameLibrary = games;
        }

        public VideoGamesUser()
        {

        }
    }

    
}
