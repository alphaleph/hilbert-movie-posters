using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MoviePostersAPI.Services;
using MoviePostersAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace MoviePostersAPI.Controllers
{
    [Route("api/movieposters/{moviePosterId:int}/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private MoviePostersDbContext _context;

        public ReviewsController(MoviePostersDbContext context)
        {
            _context = context;
        }

        //TODO: Exclude via auth
        //NOTE: Only for testing...
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetReviews(int moviePosterId)
        {
            var reviews = await _context.Reviews.ToListAsync();
            return reviews.Exists( r => r.MoviePosterId == moviePosterId) 
                ? (IActionResult)Ok(reviews.FindAll(r => r.MoviePosterId == moviePosterId)) 
                : (IActionResult)NotFound(new Error { Code = "404", Message = "Specified review not found"} );
        }
        
        /// <summary>
        /// Adds a review to movie poster
        /// </summary>
        /// <param name="body">Review to add</param>
        /// <param name="moviePosterId">Access reviews by poster id</param>
        /// <response code="201">Provides copy of the added review</response>
        /// <response code="400">Invalid action parameters</response>
        /// <response code="401">User is unauthorized to access this resource</response>
        /// <response code="404">Specified resource was not found</response>
        [HttpPost]
        // [SwaggerResponse(statusCode: 401, type: typeof(Error), description: "User is unauthorized to access this resource")]
        public async Task<IActionResult> AddReview([FromBody]Review body, [FromRoute][Required]int moviePosterId)
        { 
            if (String.IsNullOrWhiteSpace(body.Name))
            {
                return BadRequest(new Error { Code = "400", Message = "Name field must contain valid characters" });
            }

            System.Diagnostics.Debug.WriteLine(moviePosterId);

            var moviePoster = await _context.MoviePosters.Include(mp => mp.Reviews).SingleOrDefaultAsync(mp => mp.MoviePosterId == moviePosterId);
            
            System.Diagnostics.Debug.WriteLine(moviePoster);

            if (moviePoster == null) 
            {
                return NotFound(new Error { Code = "404", Message = "Specified movie poster not found"});
            }

            if (moviePoster.Reviews.Count > 0 && 
                    moviePoster.Reviews.Any(r => r.Name == body.Name && (r.Comment == body.Comment || r.Rating == body.Rating))) 
            {
                return BadRequest(new Error { Code = "400", Message = "Review already exists"});
            }
            
            var newReview = new Review 
            {
                Name = body.Name,
                Rating = body.Rating,
                Comment = body.Comment,
                MoviePosterId = moviePosterId,
                MoviePoster = moviePoster   
            };

            moviePoster.Reviews.Add(newReview);
            moviePoster.RatingCount++;
            moviePoster.UpdateRating(newReview.Rating);

            try
            {
                await _context.SaveChangesAsync();
                return StatusCode(201, newReview);
            }
            catch (DbUpdateException e)
            {
                return NotFound(new Error { Code = "404", Message = "Error while creating review" });
            }

            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401, default(Error));
        }
        
        /// <summary>
        /// Updates one specified review
        /// </summary>
        /// <param name="body">Update review schema</param>
        /// <param name="moviePosterId">Search reviews by poster id</param>
        /// <param name="reviewId">Perform action by review id</param>
        /// <response code="200">Provides copy of the updated review</response>
        /// <response code="400">Invalid action parameters</response>
        /// <response code="401">User is unauthorized to access this resource</response>
        /// <response code="404">Specified resource was not found</response>
        [HttpPut]
        [Route("{reviewId:int}")]
        // [SwaggerResponse(statusCode: 400, type: typeof(Error), description: "Invalid action parameters")]
        // [SwaggerResponse(statusCode: 401, type: typeof(Error), description: "User is unauthorized to access this resource")]
        public async Task<IActionResult> UpdateReviewById([FromBody]Review body, [FromRoute][Required]int moviePosterId, [FromRoute][Required]int reviewId)
        { 
            if (String.IsNullOrWhiteSpace(body.Name))
            {
                return BadRequest(new Error { Code = "400", Message = "Name field must contain valid characters" });
            }

            var review = await _context.Reviews.SingleOrDefaultAsync(r => (r.MoviePosterId == moviePosterId && r.ReviewId == reviewId));

            if (review == null)
            {
                return NotFound(new Error { Code = "404", Message = "Specified review was not found for update" });
            }

            //Update movie poster rating if review rating changed.
            if (review.Rating != body.Rating) 
            {
                var moviePoster = await _context.MoviePosters.SingleOrDefaultAsync(mp => mp.MoviePosterId == moviePosterId);

                if (moviePoster == null)
                {
                    return NotFound(new Error { Code = "404", Message = "Review's movie poster not found for update" });
                }

                moviePoster.UpdateRating(body.Rating - review.Rating);
                
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    return NotFound(new Error { Code = "404", Message = "Error in updating review's movie poster" });
                }
            }

            review.Name = body.Name;
            review.Comment = body.Comment;
            review.Rating = body.Rating;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(review);
            }
            catch (DbUpdateException e)
            {
                return NotFound(new Error { Code = "404", Message = "Error in updating review" });
            }

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(Error));

            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401, default(Error));
        }

        /// <summary>
        /// Deletes one specified review
        /// </summary>
        /// <param name="moviePosterId">Search reviews by poster id</param>
        /// <param name="reviewId">Perform action by review id</param>
        /// <response code="204">Inherent confirmation of deletion</response>
        /// <response code="400">Invalid action parameters</response>
        /// <response code="401">User is unauthorized to access this resource</response>
        /// <response code="404">Specified resource was not found</response>
        [HttpDelete]
        [Route("{reviewId:int}")]
        // [SwaggerResponse(statusCode: 400, type: typeof(Error), description: "Invalid action parameters")]
        // [SwaggerResponse(statusCode: 401, type: typeof(Error), description: "User is unauthorized to access this resource")]
        public async Task<IActionResult> DeleteReviewById([FromRoute][Required]int moviePosterId, [FromRoute][Required]int reviewId)
        { 
            var review = await _context.Reviews.AsNoTracking()
                                            .SingleOrDefaultAsync(r => (r.MoviePosterId == moviePosterId && r.ReviewId == reviewId));

            if (review == null)
            {
                return NotFound(new Error { Code = "404", Message = "Specified review not found for deletion" });
            }

            var moviePoster = await _context.MoviePosters.SingleOrDefaultAsync(mp => mp.MoviePosterId == moviePosterId);
            moviePoster.RatingCount--;
            moviePoster.UpdateRating(-1*review.Rating);
            moviePoster.Reviews.Remove(review);

            try
            {
                _context.Reviews.Remove(review);
                await _context.SaveChangesAsync();
                return NoContent();                
            }
            catch (DbUpdateException e)
            {
                return NotFound(new Error { Code = "404", Message = "Error in review deletion"});
            }

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(Error));

            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401, default(Error));
        }        
    }
}