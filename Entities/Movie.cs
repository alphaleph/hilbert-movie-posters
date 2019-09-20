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
    public class Movie //: IEquatable<Movie>
    {
        /// <summary>
        /// Gets or Sets MovieId
        /// </summary>
        [DataMember(Name="movieId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }

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
        /// Gets or Sets MoviePosters
        /// </summary>
        [DataMember(Name="moviePosters")]
        [Required]
        public ICollection<MoviePoster> MoviePosters { get; set; }

        // /// <summary>
        // /// Returns the string presentation of the object
        // /// </summary>
        // /// <returns>String presentation of the object</returns>
        // public override string ToString()
        // {
        //     var sb = new StringBuilder();
        //     sb.Append("class Movie {\n");
        //     sb.Append("  MovieId: ").Append(MovieId).Append("\n");
        //     sb.Append("  Name: ").Append(Name).Append("\n");
        //     sb.Append("  Year: ").Append(Year).Append("\n");
        //     sb.Append("  MoviePosters: ").Append(MoviePosters).Append("\n");
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
        //     return obj.GetType() == GetType() && Equals((Movie)obj);
        // }

        // /// <summary>
        // /// Returns true if Movie instances are equal
        // /// </summary>
        // /// <param name="other">Instance of Movie to be compared</param>
        // /// <returns>Boolean</returns>
        // public bool Equals(Movie other)
        // {
        //     if (ReferenceEquals(null, other)) return false;
        //     if (ReferenceEquals(this, other)) return true;

        //     return 
        //         (
        //             MovieId == other.MovieId ||
        //             MovieId != null &&
        //             MovieId.Equals(other.MovieId)
        //         ) && 
        //         (
        //             Name == other.Name ||
        //             Name != null &&
        //             Name.Equals(other.Name)
        //         ) && 
        //         (
        //             Year == other.Year ||
        //             Year != null &&
        //             Year.Equals(other.Year)
        //         ) && 
        //         (
        //             MoviePosters == other.MoviePosters ||
        //             MoviePosters != null &&
        //             MoviePosters.SequenceEqual(other.MoviePosters)
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
        //             if (MovieId != null)
        //             hashCode = hashCode * 59 + MovieId.GetHashCode();
        //             if (Name != null)
        //             hashCode = hashCode * 59 + Name.GetHashCode();
        //             if (Year != null)
        //             hashCode = hashCode * 59 + Year.GetHashCode();
        //             if (MoviePosters != null)
        //             hashCode = hashCode * 59 + MoviePosters.GetHashCode();
        //         return hashCode;
        //     }
        // }

        // #region Operators
        // #pragma warning disable 1591

        // public static bool operator ==(Movie left, Movie right)
        // {
        //     return Equals(left, right);
        // }

        // public static bool operator !=(Movie left, Movie right)
        // {
        //     return !Equals(left, right);
        // }

        // #pragma warning restore 1591
        // #endregion Operators
    }
}