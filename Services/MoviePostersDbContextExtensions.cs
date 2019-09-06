using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using MoviePostersAPI.Entities;
using System;

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

            Movie bladeRunner = new Movie() 
            {
                Name = "Blade Runner",
                Year = 1982
            };
            Movie highlander = new Movie() 
            {
                Name = "Highlander",
                Year = 1986
            };
            Movie schindlersList = new Movie() 
            {
                Name = @"Schindler's List",
                Year = 1993
            };
            Movie theShining = new Movie() 
            {
                Name = "The Shining",
                Year = 1980
            };
            Movie vertigo = new Movie()
            {
                Name = "Vertigo",
                Year = 1958
            };
            
            var poster1 = new MoviePoster()
            {
                PosterImage = new PosterImage() 
                {
                    Image = seedImage1
                },
                Name =  "Blade Runner by DanKNorris",
                Year =  2014,
                Artist = "DanKNorris",
                Movie = bladeRunner,
            };
            var poster2 = new MoviePoster()
            {
                PosterImage = new PosterImage() 
                {
                    Image = seedImage2
                },
                Name =  "Highlander by Eileen Steinbach",
                Year =  2018,
                Artist = "Eileen Steinbach",
                Movie = highlander
            };
            var poster3 = new MoviePoster()
            {
                PosterImage = new PosterImage() 
                {
                    Image = seedImage3
                },
                Name =  "Highlander by Unknown",
                Year =  1986,
                Artist = "Unknown",
                Movie = highlander
            };
            var poster4 = new MoviePoster()
            {
                PosterImage = new PosterImage() 
                {
                    Image = seedImage4
                },
                Name =  @"Schindler's List by Saul Bass",
                Year =  1993,
                Artist = "Saul Bass",
                Movie = schindlersList
            };
            var poster5 = new MoviePoster()
            {
                PosterImage = new PosterImage() 
                {
                    Image = seedImage5
                },
                Name =  "The Shining by Saul Bass",
                Year =  1980,
                Artist = "Saul Bass",
                Movie = theShining
            };
            var poster6 = new MoviePoster()
            {
                PosterImage = new PosterImage() 
                {
                    Image = seedImage6
                },
                Name =  "Vertigo by Boris Grinsson",
                Year =  1957,
                Artist = "Boris Grinsson",
                Movie = vertigo
            };
            var poster7 = new MoviePoster()
            {
                PosterImage = new PosterImage() 
                {
                    Image = seedImage7
                },
                Name =  "Vertigo by Enzo Nistri",
                Year =  1957,
                Artist = "Enzo Nistri",
                Movie = vertigo
            };
            var poster8 = new MoviePoster()
            {
                PosterImage = new PosterImage() 
                {
                    Image = seedImage8
                },
                Name =  "Vertigo by Roman Cieslewicz",
                Year =  1963,
                Artist = "Roman Cieslewicz",
                Movie = vertigo
            };
            var poster9 = new MoviePoster()
            {
                PosterImage = new PosterImage() 
                {
                    Image = seedImage9
                },
                Name =  "Vertigo by Saul Bass",
                Year =  1957,
                Artist = "Saul Bass",
                Movie = vertigo
            };
            
            var reviews = new List<Review>() {
                new Review()
                {
                    Name = "Hauer",
                    Rating = 3,
                    Comment = "Like tears in rain...",
                    MoviePoster = poster1
                },
                new Review() {
                    Name = "Kurgan",
                    Rating = 3,
                    Comment = "There can be only one...",
                    MoviePoster = poster1
                }
            };

            poster1.Reviews = reviews;

            var moviePosters = new List<MoviePoster>();
            moviePosters.Add(poster1);
            moviePosters.Add(poster2);
            moviePosters.Add(poster3);
            moviePosters.Add(poster4);
            moviePosters.Add(poster5);
            moviePosters.Add(poster6);
            moviePosters.Add(poster7);
            moviePosters.Add(poster8);
            moviePosters.Add(poster9);

            context.AddRange(moviePosters);
            context.SaveChanges();
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