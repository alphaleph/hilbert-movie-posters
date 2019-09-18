using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace MoviePostersAPI.Entities 
{
    public class Movie 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int Year { get; set; }

        [Required]
        public ICollection<MoviePoster> MoviePosters { get; set; }
    }
}