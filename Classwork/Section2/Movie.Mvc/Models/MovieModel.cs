using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movie.Mvc.Models
{
    public class MovieModel
    {
        //Default constructor: must have
        public MovieModel()
        {

        }
        //Constructor
        public MovieModel( ITSE1430.MovieLib.Movie item )
        {
            if (item !=null)
            {
                Id = item.Id;
                Name = item.Name;
                Description = item.Description;
                RunLength = item.RunLength;
                IsOwned = item.IsOwned;
            };
        }
        public ITSE1430.MovieLib.Movie ToDomain()
        {
            return new ITSE1430.MovieLib.Movie()
            {
                Name = Name,
                Description = Description,
                ReleaseYear = ReleaseYear,
                RunLength = RunLength,
                IsOwned = IsOwned,
            };
        }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public string Description { get; set; }
        [Display(Name = "Release Year")]
        [Range(1900, 2100, ErrorMessage = "Release year must be >= 1900.")]
        public int ReleaseYear { get; set; } = 1900;
        [Display(Name = "Run Length")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Run length must be >= 0.")]
        public int RunLength { get; set; }

        public int Id { get; set; }
        [Display(Name = "Owned")] //change the title 
        public bool IsOwned { get; set; }

    }
}