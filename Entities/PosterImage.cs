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
    public class PosterImage //: IEquatable<PosterImage>
    {
        /// <summary>
        /// Gets or Sets PosterImageId
        /// </summary>
        [DataMember(Name="posterImageId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PosterImageId { get; set; }

        /// <summary>
        /// Gets or Sets Image
        /// </summary>
        [DataMember(Name="image")]
        [Required]
        public byte[] Image { get; set; }

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
        //     sb.Append("class PosterImage {\n");
        //     sb.Append("  PosterImageId: ").Append(PosterImageId).Append("\n");
        //     sb.Append("  Image: ").Append(Image).Append("\n");
        //     sb.Append("  MoviePosterId: ").Append(MoviePosterId).Append("\n");
        //     sb.Append("  MoviePoster: ").Append(MoviePoster).Append("\n");
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
        //     return obj.GetType() == GetType() && Equals((PosterImage)obj);
        // }

        // /// <summary>
        // /// Returns true if PosterImage instances are equal
        // /// </summary>
        // /// <param name="other">Instance of PosterImage to be compared</param>
        // /// <returns>Boolean</returns>
        // public bool Equals(PosterImage other)
        // {
        //     if (ReferenceEquals(null, other)) return false;
        //     if (ReferenceEquals(this, other)) return true;

        //     return 
        //         (
        //             PosterImageId == other.PosterImageId ||
        //             PosterImageId != null &&
        //             PosterImageId.Equals(other.PosterImageId)
        //         ) && 
        //         (
        //             Image == other.Image ||
        //             Image != null &&
        //             Image.Equals(other.Image)
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
        //             if (PosterImageId != null)
        //             hashCode = hashCode * 59 + PosterImageId.GetHashCode();
        //             if (Image != null)
        //             hashCode = hashCode * 59 + Image.GetHashCode();
        //             if (MoviePosterId != null)
        //             hashCode = hashCode * 59 + MoviePosterId.GetHashCode();
        //             if (MoviePoster != null)
        //             hashCode = hashCode * 59 + MoviePoster.GetHashCode();
        //         return hashCode;
        //     }
        // }

        // #region Operators
        // #pragma warning disable 1591

        // public static bool operator ==(PosterImage left, PosterImage right)
        // {
        //     return Equals(left, right);
        // }

        // public static bool operator !=(PosterImage left, PosterImage right)
        // {
        //     return !Equals(left, right);
        // }

        // #pragma warning restore 1591
        // #endregion Operators
    }
}