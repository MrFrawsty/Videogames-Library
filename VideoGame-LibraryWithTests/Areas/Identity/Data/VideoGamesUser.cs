using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using VideoGames.Models;

namespace VideoGames.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the VideoGamesUser class
    public class VideoGamesUser : IdentityUser
    {
        public List<Game> UserGameLibrary { get; set; }

        //TODO change to Icollection at later time
        public VideoGamesUser(List<Game> games)
        {
            UserGameLibrary = games;
        }

        public VideoGamesUser()
        {

        }
    }

    
}
