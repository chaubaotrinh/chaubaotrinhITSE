using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSE1430.MovieLib
{
    public static class MovieDatabaseExtensions 
    {
        public static void Seed( this IMovieDatabase source )  //extension method 
        {
            var movies = new[] {
                new Movie() {
                    Name = "Jaws",
                    RunLength = 120,
                    ReleaseYear = 1977,
                },
                new Movie() {
                    Name = "What About Bob?",
                    RunLength = 96,
                    ReleaseYear = 2004,
                },
            };
            Seed(source, movies);
        }
        public static void Seed( this IMovieDatabase source, Movie[] movies ) //to qualify extention method: in static class, members are public and static, "this" before first parameter named "source"
        {
            foreach (var movie in movies)
                source.Add(movie);
        }

    }
}
