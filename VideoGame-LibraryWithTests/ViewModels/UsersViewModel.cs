using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGames.Areas.Identity.Data;

namespace VideoGames.ViewModels
{
    public class UsersViewModel
    {
       public List<VideoGamesUser> Users { get; set; }

        public UsersViewModel(List<VideoGamesUser> users)
        {
            Users = users;
        }

        public UsersViewModel()
        {

        }
    }
}
