﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ITSE1430.MovieLib.Memory
//{
//    public class MemoryMovieDatabase : MovieDatabase //create new class to store the movie 
//    {
//        public MemoryMovieDatabase() : this(true)  //default constructor - empty, passing true
//        {

//        }

//        private static Movie[] GetSeedMovies( bool seed )
//        {
//            if (!seed)
//                return new Movie[0];


//            return new [] //collection
//            { 

//                new Movie()
//                {
//                    Name = "Jaws",
//                    RunLength = 120,
//                    ReleaseYear = 1977,
//                },

//                new Movie()
//                {
//                    Name = "What about Bob?",
//                    RunLength = 96,
//                    ReleaseYear = 2004,
//                },
//        };


//        }

//        public MemoryMovieDatabase (bool seed) : this(GetSeedMovies(seed))  //another constructor, call the previous constructor 
//        {
//            /*if (seed)
//            {
//                var movie = new Movie();
//                movie.Name = "Jaws";
//                movie.RunLength = 120;
//                movie.ReleaseYear = 1977;
//                Add(movie);

//                movie = new Movie();
//                movie.Name = "What about Bob?";
//                movie.RunLength = 96;
//                movie.ReleaseYear = 2004;
//                Add(movie);
//            };*/
//        }

//        public MemoryMovieDatabase(Movie[] movies) // constructor 
//        {
//            _items.AddRange(movies); // AddRange method => add 1 or more movies 
//            //for (var index = 0; index < movies.Length; ++index)
//            //    _movies[index] = movies[index];
//        }

//        protected override void AddCore( Movie movie )
//        {
//            _items.Add(movie);
//            //var index = FindNextFreeIndex();
//            //if (index >= 0)
//            //    _movies[index] = movie;

//        }

//        //private int FindNextFreeIndex()
//        //{
//        //    for (var index = 0; index < _movies.Length; ++index)
//        //    {
//        //        if (_movies[index] == null)
//        //            return index;
//        //    };

//        //    return -1; // ?

//        //}

//        //private Movie[] _movies = new Movie[100];

//        private List<Movie> _items = new List<Movie>(); //item is the list of movie. List is generic type.List => store a list of items

//        protected override Movie[] GetAllCore()
//        {
//            //how many movies do we have
//            var count = _items.Count; 
//            //foreach (var movie in _movies)
//            //{
//            //    if (movie != null)
//            //        ++count;
//            //};

//            var temp = new Movie[count];
//            var index = 0;
//            foreach (var movie in _items)
//            {
//                //if (movie != null)
//                    temp[index++] = movie;
//            };
//            return temp;
//        }

//        protected override void EditCore( Movie oldMovie, Movie newMovie )
//        {
//            //Find movie by name 
//            _items.Remove(oldMovie);

//            //Replace it 
//            _items.Add(newMovie);
//        }
//    }
//        protected override Movie FindByName( string name )
//    {
//            /*var pairs = new Dictionary<string, Movie>(); *///key is string, movie() is value

//            foreach (var movie in  _items)
//            //for (var index = 0; index < _movies.Length; ++index)
//            {
//                if (String.Compare(name, movie.Name, true) == 0)
//                    return movie;
//            };
//            return null;
//        }
//        protected override void RemoveCore ( string name )
//        {
//            var movie = FindByName(name);
//            if (movie != null)
//                _items.Remove(movie);
//            //for (var index = 0; index < _movies.Length; ++index)
//            //{
//            //    if (String.Compare(name, _movies[index]?.Name, true )== 0)
//            //    {
//            //        _items.Remove
//            //        _movies[index] = null;
//            //        return; 
//            //    };
//            //};
//        }
//    }
//}


using System;
using System.Collections.Generic;

namespace ITSE1430.MovieLib.Memory
{
    /// <summary>Manages a set of movies.</summary>
    public class MemoryMovieDatabase : MovieDatabase
    {
        /// <summary>Adds a movie to the database.</summary>
        /// <param name="movie">The movie to add.</param>
        protected override void AddCore( Movie movie )
        {
            _items.Add(movie);
            //var index = FindNextFreeIndex();
            //if (index >= 0)
            //    _movies[index] = movie;
        }

        /// <summary>Gets all the movies.</summary>
        /// <returns>The list of movies.</returns>
        protected override IEnumerable<Movie> GetAllCore()
        {
            return _items;
            //How many movies do we have
            //var count = _items.Count;

            //var temp = new Movie[count];
            //var index = 0;
            //foreach (var movie in _items)
            //{
            //    temp[index++] = movie;
            //};

            //return temp;
        }

        /// <summary>Edits an existing movie.</summary>
        /// <param name="name">The movie to edit.</param>
        /// <param name="movie">The new movie.</param>
        protected override void EditCore( Movie oldMovie, Movie newMovie )
        {
            //Find movie by name
            _items.Remove(oldMovie);

            //Replace it
            _items.Add(newMovie);
        }

        /// <summary>Removes a movie.</summary>
        /// <param name="name">The movie to remove.</param>
        protected override void RemoveCore( string name )
        {
            var movie = FindByName(name);
            if (movie != null)
                _items.Remove(movie);
        }

        #region Private Members

        protected override Movie FindByName( string name )
        {
            //Example with multiple type parameters
            //var pairs = new Dictionary<string, Movie>();

            //for (var index = 0; index < _movies.Length; ++index)
            foreach (var movie in _items)
            {
                //if (String.Compare(name, _movies[index]?.Name, true) == 0)
                if (String.Compare(name, movie.Name, true) == 0)
                    return movie;
            };

            return null;
        }

        //private Movie[] _movies = new Movie[100];
        private List<Movie> _items = new List<Movie>();
        #endregion
    }
}


