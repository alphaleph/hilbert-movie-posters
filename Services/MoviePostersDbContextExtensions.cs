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

            byte[] seedImage1 = GetImageBytes("Blade-Runner-by-DanKNorris-2014.jpg");
            byte[] seedImage2 = GetImageBytes("Highlander-by-Eileen-Steinbach-2018.png");
            byte[] seedImage3 = GetImageBytes("Highlander-by-Unknown-1986.jpg");
            byte[] seedImage4 = GetImageBytes(@"Schindler's-List-by-Saul-Bass-1993.jpg");
            byte[] seedImage5 = GetImageBytes("The-Shining-by-Saul-Bass-1980.png");
            byte[] seedImage6 = GetImageBytes("Vertigo-by-Boris-Grinsson-1957.jpg");
            byte[] seedImage7 = GetImageBytes("Vertigo-by-Enzo-Nistri-1957.jpg");
            byte[] seedImage8 = GetImageBytes("Vertigo-by-Roman-Cieslewicz-1963.jpg");
            byte[] seedImage9 = GetImageBytes("Vertigo-by-Saul-Bass-1957.jpg");

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
                    PosterImage = new PosterImage() 
                    {
                        MoviePosterId = 1,
                        Image = seedImage1
                    },
                    MoviePosterId = 1,
                    Name =  "Blade Runner by DanKNorris",
                    Year =  2014,
                    Artist = "DanKNorris",
                    MovieId = 1,
                    Movie = movies[0],
                },
                new MoviePoster()
                {
                    PosterImage = new PosterImage() 
                    {
                        MoviePosterId = 2,
                        Image = seedImage2
                    },
                    MoviePosterId = 2,
                    Name =  "Highlander by Eileen Steinbach",
                    Year =  2018,
                    Artist = "Eileen Steinbach",
                    MovieId = 2,
                    Movie = movies[1]
                },
                new MoviePoster()
                {
                    PosterImage = new PosterImage() 
                    {
                        MoviePosterId = 3,
                        Image = seedImage3
                    },
                    MoviePosterId = 3,
                    Name =  "Highlander by Unknown",
                    Year =  1986,
                    Artist = "Unknown",
                    MovieId = 2,
                    Movie = movies[1]
                },
                new MoviePoster()
                {
                    PosterImage = new PosterImage() 
                    {
                        MoviePosterId = 4,
                        Image = seedImage4
                    },
                    MoviePosterId = 4,
                    Name =  @"Schindler's List by Saul Bass",
                    Year =  1993,
                    Artist = "Saul Bass",
                    MovieId = 3,
                    Movie = movies[2]
                },
                new MoviePoster()
                {
                    PosterImage = new PosterImage() 
                    {
                        MoviePosterId = 5,
                        Image = seedImage5
                    },
                    MoviePosterId = 5,
                    Name =  "The Shining by Saul Bass",
                    Year =  1980,
                    Artist = "Saul Bass",
                    MovieId = 4,
                    Movie = movies[3]
                },
                new MoviePoster()
                {
                    PosterImage = new PosterImage() 
                    {
                        MoviePosterId = 6,
                        Image = seedImage6
                    },
                    MoviePosterId = 6,
                    Name =  "Vertigo by Boris Grinsson",
                    Year =  1957,
                    Artist = "Boris Grinsson",
                    MovieId = 5,
                    Movie = movies[4]
                },
                new MoviePoster()
                {
                    PosterImage = new PosterImage() 
                    {
                        MoviePosterId = 7,
                        Image = seedImage7
                    },
                    MoviePosterId = 7,
                    Name =  "Vertigo by Enzo Nistri",
                    Year =  1957,
                    Artist = "Enzo Nistri",
                    MovieId = 5,
                    Movie = movies[4]
                },
                new MoviePoster()
                {
                    PosterImage = new PosterImage() 
                    {
                        MoviePosterId = 8,
                        Image = seedImage8
                    },
                    MoviePosterId = 8,
                    Name =  "Vertigo by Roman Cieslewicz",
                    Year =  1963,
                    Artist = "Roman Cieslewicz",
                    MovieId = 5,
                    Movie = movies[4]
                },
                new MoviePoster()
                {
                    PosterImage = new PosterImage() 
                    {
                        MoviePosterId = 9,
                        Image = seedImage9
                    },
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

        public static byte[] GetImageBytes(string imageName)
        {
            var filename = $@".\assets\{imageName}";
            byte[] imageData = null;
            if (File.Exists(filename))
            {
                try {
                    imageData = System.IO.File.ReadAllBytes(filename);
                }
                catch (IOException e)
                {
                    if (e.Source != null)
                        Console.WriteLine($"IOException source: {e.Source}");
                    throw;
                    
                }
            } 
            else
            {
                Console.WriteLine($"{filename} does not exist...");
            }

            return imageData;

        }
    }
}