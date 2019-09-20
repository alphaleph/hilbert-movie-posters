using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MoviePostersAPI.Entities 
{
    [DataContract]
    public class MoviePoster //: IEquatable<MoviePoster>
    {
        /// <summary>
        /// Gets or Sets MoviePosterId
        /// </summary>
        [DataMember(Name="moviePosterId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MoviePosterId { get; set; }

        /// <summary>
        /// Gets or Sets PosterImage
        /// </summary>
        [DataMember(Name="posterImage")]
        [Required]
        public PosterImage PosterImage { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Year
        /// </summary>
        [DataMember(Name="year")]
        public int Year { get; set; }

        /// <summary>
        /// Gets or Sets Artist
        /// </summary>
        [DataMember(Name="artist")]
        [Required]
        public string Artist { get; set; }

        /// <summary>
        /// Gets or Sets Rating
        /// </summary>
        [DataMember(Name="rating")]
        public int Rating { get; set; } = 0;

        /// <summary>
        /// Gets or Sets RatingCount
        /// </summary>
        [DataMember(Name="ratingCount")]
        public int RatingCount { get; set; } = 0;

        /// <summary>
        /// Gets or Sets MovieId
        /// </summary>
        [DataMember(Name="movieId")]
        public int MovieId { get; set; }

        /// <summary>
        /// Gets or Sets Movie
        /// </summary>
        [DataMember(Name="movie")]
        public Movie Movie { get; set; }

        /// <summary>
        /// Gets or Sets Reviews
        /// </summary>
        [DataMember(Name="reviews")]
        public ICollection<Review> Reviews { get; set; }

        // /// <summary>
        // /// Returns the string presentation of the object
        // /// </summary>
        // /// <returns>String presentation of the object</returns>
        // public override string ToString()
        // {
        //     var sb = new StringBuilder();
        //     sb.Append("class MoviePoster {\n");
        //     sb.Append("  MoviePosterId: ").Append(MoviePosterId).Append("\n");
        //     sb.Append("  Name: ").Append(Name).Append("\n");
        //     sb.Append("  Artist: ").Append(Artist).Append("\n");
        //     sb.Append("  Year: ").Append(Year).Append("\n");
        //     sb.Append("  Rating: ").Append(Rating).Append("\n");
        //     sb.Append("  RatingCount: ").Append(RatingCount).Append("\n");
        //     sb.Append("  MovieId: ").Append(MovieId).Append("\n");
        //     sb.Append("  Movie: ").Append(Movie).Append("\n");
        //     sb.Append("  PosterImage: ").Append(PosterImage).Append("\n");
        //     sb.Append("  Reviews: ").Append(Reviews).Append("\n");
        //     sb.Append("}\n");
        //     return sb.ToString();
        // }

        // /// <summary>
        // /// Returns the JSON string presentation of the object
        // /// </summary>
        // /// <returns>JSON string presentation of the object</returns>
        // public string ToJson()
        // {
        //     return JsonConvert.SerializeObject(this, Formatting.Indented);
        // }

        // /// <summary>
        // /// Returns true if objects are equal
        // /// </summary>
        // /// <param name="obj">Object to be compared</param>
        // /// <returns>Boolean</returns>
        // public override bool Equals(object obj)
        // {
        //     if (ReferenceEquals(null, obj)) return false;
        //     if (ReferenceEquals(this, obj)) return true;
        //     return obj.GetType() == GetType() && Equals((MoviePoster)obj);
        // }

        // /// <summary>
        // /// Returns true if MoviePoster instances are equal
        // /// </summary>
        // /// <param name="other">Instance of MoviePoster to be compared</param>
        // /// <returns>Boolean</returns>
        // public bool Equals(MoviePoster other)
        // {
        //     if (ReferenceEquals(null, other)) return false;
        //     if (ReferenceEquals(this, other)) return true;

        //     return 
        //         (
        //             MoviePosterId == other.MoviePosterId ||
        //             MoviePosterId != null &&
        //             MoviePosterId.Equals(other.MoviePosterId)
        //         ) && 
        //         (
        //             Name == other.Name ||
        //             Name != null &&
        //             Name.Equals(other.Name)
        //         ) && 
        //         (
        //             Artist == other.Artist ||
        //             Artist != null &&
        //             Artist.Equals(other.Artist)
        //         ) && 
        //         (
        //             Year == other.Year ||
        //             Year != null &&
        //             Year.Equals(other.Year)
        //         ) && 
        //         (
        //             Rating == other.Rating ||
        //             Rating != null &&
        //             Rating.Equals(other.Rating)
        //         ) && 
        //         (
        //             RatingCount == other.RatingCount ||
        //             RatingCount != null &&
        //             RatingCount.Equals(other.RatingCount)
        //         ) && 
        //         (
        //             MovieId == other.MovieId ||
        //             MovieId != null &&
        //             MovieId.Equals(other.MovieId)
        //         ) && 
        //         (
        //             Movie == other.Movie ||
        //             Movie != null &&
        //             Movie.Equals(other.Movie)
        //         ) && 
        //         (
        //             PosterImage == other.PosterImage ||
        //             PosterImage != null &&
        //             PosterImage.Equals(other.PosterImage)
        //         ) && 
        //         (
        //             Reviews == other.Reviews ||
        //             Reviews != null &&
        //             Reviews.SequenceEqual(other.Reviews)
        //         );
        // }

        // /// <summary>
        // /// Gets the hash code
        // /// </summary>
        // /// <returns>Hash code</returns>
        // public override int GetHashCode()
        // {
        //     unchecked // Overflow is fine, just wrap
        //     {
        //         var hashCode = 41;
        //         // Suitable nullity checks etc, of course :)
        //             if (MoviePosterId != null)
        //             hashCode = hashCode * 59 + MoviePosterId.GetHashCode();
        //             if (Name != null)
        //             hashCode = hashCode * 59 + Name.GetHashCode();
        //             if (Artist != null)
        //             hashCode = hashCode * 59 + Artist.GetHashCode();
        //             if (Year != null)
        //             hashCode = hashCode * 59 + Year.GetHashCode();
        //             if (Rating != null)
        //             hashCode = hashCode * 59 + Rating.GetHashCode();
        //             if (RatingCount != null)
        //             hashCode = hashCode * 59 + RatingCount.GetHashCode();
        //             if (MovieId != null)
        //             hashCode = hashCode * 59 + MovieId.GetHashCode();
        //             if (Movie != null)
        //             hashCode = hashCode * 59 + Movie.GetHashCode();
        //             if (PosterImage != null)
        //             hashCode = hashCode * 59 + PosterImage.GetHashCode();
        //             if (Reviews != null)
        //             hashCode = hashCode * 59 + Reviews.GetHashCode();
        //         return hashCode;
        //     }
        // }

        // #region Operators
        // #pragma warning disable 1591

        // public static bool operator ==(MoviePoster left, MoviePoster right)
        // {
        //     return Equals(left, right);
        // }

        // public static bool operator !=(MoviePoster left, MoviePoster right)
        // {
        //     return !Equals(left, right);
        // }

        // #pragma warning restore 1591
        // #endregion Operators

    }
}