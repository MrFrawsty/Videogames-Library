using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGames.Models
{
    public class Game
    {



        [Key]
        public long GameId { get; set; }
        public string UserId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Genre { get; set; }
        public bool Completed { get; set; }

      



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
