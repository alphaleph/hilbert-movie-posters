using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace MoviePostersAPI.Entities
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime PostedDate { get; set; }

        public int? Rating { get; set; }

        [MaxLength(255)]
        public string Comment { get; set; }

        public int MoviePosterId { get; set; }
        [Required]
        public MoviePoster MoviePoster { get; set; }
    }
}