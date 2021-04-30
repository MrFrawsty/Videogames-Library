using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VideoGames.Areas.Identity.Data;

namespace VideoGames.Models
{
    public class Game
        {
            [Key]       
            public long GameId { get; set; }
            [Required]
            public string Name { get; set; }
            public string Genre { get; set; }
            public bool Completed { get; set; }
            
            public int? VideoGamesUserId { get; set;}

            [ForeignKey(nameof(VideoGamesUserId))]
            [InverseProperty("UserGameLibrary")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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
