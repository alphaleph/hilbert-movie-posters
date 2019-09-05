using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviePostersAPI.Entities 
{
    public class MoviePoster 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Artist { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public int RatingCount { get; set; }

        [Required]
        public Movie Movie { get; set; }

        public ICollection<Review> Reviews { get; set; }

    }
}