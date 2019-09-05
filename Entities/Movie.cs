using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviePostersAPI.Entities 
{
    public class Movie 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public ICollection<MoviePoster> MoviePosters { get; set; }
    }
}