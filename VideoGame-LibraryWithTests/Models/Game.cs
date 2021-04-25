using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using VideoGames.Areas.Identity.Data;

namespace VideoGames.Models
{
        public class Game
        {
            [Key]
            //TODO CHANGE ID TO STRING??
            public long GameId { get; set; }
            [Required]
            public string Name { get; set; }
            public string Genre { get; set; }
            public bool Completed { get; set; }
            
            public string VideoGamesUserId { get; set;}

            [ForeignKey(nameof(VideoGamesUserId))]
            [InverseProperty("UserGameLibrary")]
            public VideoGamesUser VideoGamesUser{ get; set; }
        

            public Game(string name, string genre, bool completed, int id)
            {
                GameId = id;
                Name = name;
                Genre = genre;
                Completed = completed;

            }

            public Game()
            {
           

            }

        }
}
