using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace MoviePostersAPI.Entities 
{
    public class MoviePoster 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public PosterImage PosterImage { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int Year { get; set; }

        [Required]
        public string Artist { get; set; }

        public int Rating { get; set; } = 0;

        public int RatingCount { get; set; } = 0;

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public ICollection<Review> Reviews { get; set; }

    }
}