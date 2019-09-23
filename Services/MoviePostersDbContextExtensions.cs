using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using MoviePostersAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace MoviePostersAPI.Services
{
    public static class MoviePostersDbContextExtensions
    {
        public static void CreateSeedData(MoviePostersDbContext context)
        {
            if (context.MoviePosters.Any())
                return;

            var movies = new Movie[] 
            {
                new Movie() 
                {
                    MovieId = 1,
                    Name = "Blade Runner",
                    Year = 1982
                },
                new Movie() 
                {
                    MovieId = 2,
                    Name = "Highlander",
                    Year = 1986
                },
                new Movie() 
                {
                    MovieId = 3,
                    Name = @"Schindler's List",
                    Year = 1993
                },
                new Movie() 
                {
                    MovieId = 4,
                    Name = "The Shining",
                    Year = 1980
                },
                new Movie()
                {
                    MovieId = 5,
                    Name = "Vertigo",
                    Year = 1958
                }    
            };
            
            var moviePosters = new MoviePoster[]
            {
                new MoviePoster() 
                {
                    PosterImageUrl = "https://res.cloudinary.com/chaua0927/image/upload/v1569250604/hilbert-poster-images/bfo8lhzcrej5fvco4l3w.jpg",
                    MoviePosterId = 1,
                    Name =  "Blade Runner by DanKNorris",
                    Year =  2014,
                    Artist = "DanKNorris",
                    MovieId = 1,
                    Movie = movies[0],
                },
                new MoviePoster()
                {
                    PosterImageUrl = "https://res.cloudinary.com/chaua0927/image/upload/v1569250605/hilbert-poster-images/dbigh1i3lq3yovm943ui.png",
                    MoviePosterId = 2,
                    Name =  "Highlander by Eileen Steinbach",
                    Year =  2018,
                    Artist = "Eileen Steinbach",
                    MovieId = 2,
                    Movie = movies[1]
                },
                new MoviePoster()
                {
                    PosterImageUrl = "https://res.cloudinary.com/chaua0927/image/upload/v1569250606/hilbert-poster-images/vgex4exmf1uidt9ovuxr.jpg",
                    MoviePosterId = 3,
                    Name =  "Highlander by Unknown",
                    Year =  1986,
                    Artist = "Unknown",
                    MovieId = 2,
                    Movie = movies[1]
                },
                new MoviePoster()
                {
                    PosterImageUrl = "https://res.cloudinary.com/chaua0927/image/upload/v1569250608/hilbert-poster-images/jqrliijupdnfqhh3wr4m.jpg",
                    MoviePosterId = 4,
                    Name =  @"Schindler's List by Saul Bass",
                    Year =  1993,
                    Artist = "Saul Bass",
                    MovieId = 3,
                    Movie = movies[2]
                },
                new MoviePoster()
                {
                    PosterImageUrl = "https://res.cloudinary.com/chaua0927/image/upload/v1569250608/hilbert-poster-images/zz9gspbirvhnjlejoydt.png",
                    MoviePosterId = 5,
                    Name =  "The Shining by Saul Bass",
                    Year =  1980,
                    Artist = "Saul Bass",
                    MovieId = 4,
                    Movie = movies[3]
                },
                new MoviePoster()
                {
                    PosterImageUrl = "https://res.cloudinary.com/chaua0927/image/upload/v1569250609/hilbert-poster-images/qzhe68aq6wfpavqxed7p.jpg",
                    MoviePosterId = 6,
                    Name =  "Vertigo by Boris Grinsson",
                    Year =  1957,
                    Artist = "Boris Grinsson",
                    MovieId = 5,
                    Movie = movies[4]
                },
                new MoviePoster()
                {
                    PosterImageUrl = "https://res.cloudinary.com/chaua0927/image/upload/v1569250610/hilbert-poster-images/bqaylkhfugaqhd4rwsqs.jpg",
                    MoviePosterId = 7,
                    Name =  "Vertigo by Enzo Nistri",
                    Year =  1957,
                    Artist = "Enzo Nistri",
                    MovieId = 5,
                    Movie = movies[4]
                },
                new MoviePoster()
                {
                    PosterImageUrl = "https://res.cloudinary.com/chaua0927/image/upload/v1569250611/hilbert-poster-images/zgyo9eeuaocu55gdmyak.jpg",
                    MoviePosterId = 8,
                    Name =  "Vertigo by Roman Cieslewicz",
                    Year =  1963,
                    Artist = "Roman Cieslewicz",
                    MovieId = 5,
                    Movie = movies[4]
                },
                new MoviePoster()
                {
                    PosterImageUrl = "https://res.cloudinary.com/chaua0927/image/upload/v1569250613/hilbert-poster-images/ug7lheqvarlkzhmmpawx.jpg",
                    MoviePosterId = 9,
                    Name =  "Vertigo by Saul Bass",
                    Year =  1957,
                    Artist = "Saul Bass",
                    MovieId = 5,
                    Movie = movies[4]
                }
            };
            
            var reviews = new Review[] 
            {
                new Review()
                {
                    ReviewId = 1,
                    Name = "Hauer",
                    Rating = 3,
                    Comment = "Like tears in rain...",
                    MoviePosterId = 1,
                },
                new Review() {
                    ReviewId = 2,
                    Name = "Kurgan",
                    Rating = 1,
                    Comment = "There can be only one...",
                    MoviePosterId = 1,
                }
            };

            context.Database.OpenConnection();
            try 
            {
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Movies ON");
                foreach (Movie m in movies)
                {
                    context.Movies.Add(m);
                }
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Movies OFF");
            }
            finally 
            {
                context.Database.CloseConnection();
            }

            context.Database.OpenConnection();
            try 
            {
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.MoviePosters ON");
                foreach (MoviePoster mp in moviePosters)
                {
                    context.MoviePosters.Add(mp);
                }
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.MoviePosters OFF");
            }
            finally 
            {
                context.Database.CloseConnection();
            }

            context.Database.OpenConnection();
            try 
            {
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Reviews ON");
                foreach (Review r in reviews)
                {
                    context.Reviews.Add(r);
                }
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Reviews OFF");
            }
            finally 
            {
                context.Database.CloseConnection();
            }
        }
    }
}