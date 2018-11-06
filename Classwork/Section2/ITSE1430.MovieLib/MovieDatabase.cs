using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSE1430.MovieLib
{
    public abstract class MovieDatabase : IMovieDatabase //create new class to store the movie 
    {
       
        public void Add( Movie movie )
        {
            //Validate
            if (movie == null)
                throw new ArgumentNullException("movie");
            ObjectValidator.Validate(movie);

            //if (movie == null) return;
            try
            {
                AddCore(movie);
            }
            catch (Exception e)
            {
                throw new Exception("Add failed", e);
            };

            

        }

        protected abstract void AddCore( Movie movie ); //virtual v.s. abstract??

        public IEnumerable<Movie> GetAll()
        {
            return GetAllCore();
        }

        protected abstract IEnumerable<Movie> GetAllCore();


        public void Edit (string name, Movie movie)
        {
            ////TODO: Validate
            //if (String.IsNullOrEmpty(name))
            //    return;

            if (name == null)
                throw new ArgumentNullException(nameof(name));
            else if (name == "")
                throw new ArgumentNullException("Name cannot be empty.", nameof(name));
            
            //Validate
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));
            ObjectValidator.Validate(movie);

            //if (movie == null)
            //    return;

            var existing = FindByName(name);

            if (existing == null)
                throw new Exception("Movie not found."); //1 sentence message

   
            EditCore(existing, movie);
        }

        protected abstract Movie FindByName( string name );
        protected abstract void EditCore( Movie oldMovie, Movie newMovie );



       
        public void Remove (string name) // to remove/delete movie
        {
            //TODO: Validate
            if (String.IsNullOrEmpty(name))
                return;

            RemoveCore(name);

            //var movie = FindMovie(name);
            //if (movie != null)
            //    _items.Remove(movie);
            //for (var index = 0; index < _movies.Length; ++index)
            //{
            //    if (String.Compare(name, _movies[index]?.Name, true )== 0)
            //    {
            //        _items.Remove
            //        _movies[index] = null;
            //        return; 
            //    };
            //};
        }

        protected abstract void RemoveCore( string name );
    }
}
