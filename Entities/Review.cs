using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MoviePostersAPI.Entities
{
    [DataContract]
    public class Review //: IEquatable<Review>
    {
        /// <summary>
        /// Gets or Sets ReviewId
        /// </summary>
        [DataMember(Name="reviewId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewId { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets PostedDate
        /// </summary>
        [DataMember(Name="postedDate")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime PostedDate { get; set; }

        /// <summary>
        /// Gets or Sets Rating
        /// </summary>
        [Range(0, 5)]
        [DataMember(Name="rating")]
        [Required]
        public int Rating { get; set; }

        /// <summary>
        /// Gets or Sets Comment
        /// </summary>
        [DataMember(Name="comment")]
        [MaxLength(255)]
        public string Comment { get; set; }

        /// <summary>
        /// Gets or Sets MoviePosterId
        /// </summary>
        [DataMember(Name="moviePosterId")]
        public int MoviePosterId { get; set; }
        
        /// <summary>
        /// Gets or Sets MoviePoster
        /// </summary>
        [DataMember(Name="moviePoster")]
        public MoviePoster MoviePoster { get; set; }


        // /// <summary>
        // /// Returns the string presentation of the object
        // /// </summary>
        // /// <returns>String presentation of the object</returns>
        // public override string ToString()
        // {
        //     var sb = new StringBuilder();
        //     sb.Append("class Review {\n");
        //     sb.Append("  Name: ").Append(Name).Append("\n");
        //     sb.Append("  MoviePosterId: ").Append(MoviePosterId).Append("\n");
        //     sb.Append("  MoviePoster: ").Append(MoviePoster).Append("\n");
        //     sb.Append("  PostedDate: ").Append(PostedDate).Append("\n");
        //     sb.Append("  Rating: ").Append(Rating).Append("\n");
        //     sb.Append("  Comment: ").Append(Comment).Append("\n");
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
        //     return obj.GetType() == GetType() && Equals((Review)obj);
        // }

        // /// <summary>
        // /// Returns true if Review instances are equal
        // /// </summary>
        // /// <param name="other">Instance of Review to be compared</param>
        // /// <returns>Boolean</returns>
        // public bool Equals(Review other)
        // {
        //     if (ReferenceEquals(null, other)) return false;
        //     if (ReferenceEquals(this, other)) return true;

        //     return 
        //         (
        //             Name == other.Name ||
        //             Name != null &&
        //             Name.Equals(other.Name)
        //         ) && 
        //         (
        //             MoviePosterId == other.MoviePosterId ||
        //             MoviePosterId != null &&
        //             MoviePosterId.Equals(other.MoviePosterId)
        //         ) && 
        //         (
        //             MoviePoster == other.MoviePoster ||
        //             MoviePoster != null &&
        //             MoviePoster.Equals(other.MoviePoster)
        //         ) && 
        //         (
        //             PostedDate == other.PostedDate ||
        //             PostedDate != null &&
        //             PostedDate.Equals(other.PostedDate)
        //         ) && 
        //         (
        //             Rating == other.Rating ||
        //             Rating != null &&
        //             Rating.Equals(other.Rating)
        //         ) && 
        //         (
        //             Comment == other.Comment ||
        //             Comment != null &&
        //             Comment.Equals(other.Comment)
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
        //             if (Name != null)
        //             hashCode = hashCode * 59 + Name.GetHashCode();
        //             if (MoviePosterId != null)
        //             hashCode = hashCode * 59 + MoviePosterId.GetHashCode();
        //             if (MoviePoster != null)
        //             hashCode = hashCode * 59 + MoviePoster.GetHashCode();
        //             if (PostedDate != null)
        //             hashCode = hashCode * 59 + PostedDate.GetHashCode();
        //             if (Rating != null)
        //             hashCode = hashCode * 59 + Rating.GetHashCode();
        //             if (Comment != null)
        //             hashCode = hashCode * 59 + Comment.GetHashCode();
        //         return hashCode;
        //     }
        // }

        // #region Operators
        // #pragma warning disable 1591

        // public static bool operator ==(Review left, Review right)
        // {
        //     return Equals(left, right);
        // }

        // public static bool operator !=(Review left, Review right)
        // {
        //     return !Equals(left, right);
        // }

        // #pragma warning restore 1591
        // #endregion Operators
    }
}