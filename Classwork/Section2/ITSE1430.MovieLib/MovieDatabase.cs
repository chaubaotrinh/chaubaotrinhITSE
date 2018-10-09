﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSE1430.MovieLib
{
    public class MovieDatabase //create new class to store the movie 
    {
        public MovieDatabase() : this(true)  //default constructor - empty, passing true
        {

        }

        private static Movie[] GetSeedMovies(bool seed)
        {
            if (!seed)
                return new Movie[0];


            var movies = new Movie[2];

            movies[0] = new Movie();
            movies[0].Name = "Jaws";
            movies[0].RunLength = 120;
            movies[0].ReleaseYear = 1977;

            movies[1] = new Movie();
            movies[1].Name = "What about Bob?";
            movies[1].RunLength = 96;
            movies[1].ReleaseYear = 2004;

            return movies;
        }

        public MovieDatabase (bool seed) : this(GetSeedMovies(seed))  //another constructor, call the previous constructor 
        {
            /*if (seed)
            {
                var movie = new Movie();
                movie.Name = "Jaws";
                movie.RunLength = 120;
                movie.ReleaseYear = 1977;
                Add(movie);

                movie = new Movie();
                movie.Name = "What about Bob?";
                movie.RunLength = 96;
                movie.ReleaseYear = 2004;
                Add(movie);
            };*/
        }

        public MovieDatabase(Movie[] movies) // constructor 
        {
            for (var index = 0; index < movies.Length; ++index)
                _movies[index] = movies[index];
        }

        public void Add( Movie movie )
        {
            var index = FindNextFreeIndex();
            if (index >= 0)
                _movies[index] = movie;

        }

        private int FindNextFreeIndex()
        {
            for (var index = 0; index < _movies.Length; ++index)
            {
                if (_movies[index] == null)
                    return index;
            };

            return -1; // ?

        }

        private Movie[] _movies = new Movie[100];

        public Movie[] GetAll()
        {
            var count = 0; 
            foreach (var movie in _movies)
            {
                if (movie != null)
                    ++count;
            };

            var temp = new Movie[count];
            var index = 0;
            foreach (var movie in _movies)
            {
                if (movie != null)
                    temp[index++] = movie;
            };
            return temp;
        }

        public void Edit (string name, Movie movie)
        {
            //Find movie by name 
            Remove(name);

            //Replace it 
            Add(movie);
        }

        public void Remove (string name) // to remove/delete movie
        {
            for (var index = 0; index < _movies.Length; ++index)
            {
                if (String.Compare(name, _movies[index]?.Name, true )== 0)
                {
                    _movies[index] = null;
                    return; 
                };
            };
        }
    }
}