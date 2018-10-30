//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ITSE1430.MovieLib
//{
//    public class Movie : IValidatableObject          //interface, starts with I, can work with multiple interfaces (: I...., I..., I... )
//    {
//        public string Name          //property Name: no ()
//        {
//            get { return _name ?? ""; }   // string get ()
//            set { _name = value; }  // void set (string value) => return nothing 
//        }
//        // public string GetName()     //Name, ....RunLength are members
//        //public System.String Name; (same as line 11), change the Name field to GetName method 
//        // {
//        //    return _name ?? "";     //deal with null
//        //}
//        //public void SetName (string value)
//        //{
//        //   _name = value;
//        //}
//        private string _name = ""; //still need a field Name, now change to _name, and always private, initialize field _name to empty 

//        public string Description
//        {
//            get { return _description ?? ""; }  // never return null
//            set { _description = value; }
//        }
//        /*public string GetDescription()
//        {
//            return _description ?? "";
//        }
//        public void SetDescription (string value)
//        {
//            //this. : use this. to pass instance to others
//            _description = value;  
//            //same: this._description = value;
//        }*/

//        private string _description;   // variables inside instances called fields

//        public int ReleaseYear { get; set; } = 1900;  //initialize the backing field 
//        /*{
//            get { return _releaseYear; }
//            set
//            {
//                if (value >= 1900)
//                    _releaseYear = value;
//            }
//        }*/

//        /*public int GetReleaseYear()
//        {
//            return _releaseYear;
//        }
//        public void SetReleaseYear( int value )
//        {
//            if (value >= 1900)
//            _releaseYear = value;
//        }
//        */

//        //private int _releaseYear = 1900;

//        // Auto property syntax
//        public int RunLength { get; set; }
//        /*{
//            get { return _runLength; }
//            set
//            {
//                if (value >= 0)
//                    _runLength = value;
//            }
//        }
//        */

//        /*public int GetRunLength()
//        {
//            return _runLength ;
//        }
//        public void SetRunLength( int value )
//        {
//                                 //make sure the run length is not less than 0
//            _runLength = value;
//        }
//        */
//        //private int _runLength;  // initialized to 0 by default, can't initialized to another field 

//        //int someValue;   // = private int someValue;

//        //declare a function Foo inside the instance/class => call Method, not function. C# doesn't have function
//        //method: bring functionality into the data
//        /*void Foo()
//        {
//            var x = RunLength;  //RunLength: field, x: variable 

//            var isLong = x > 10;

//            var y = someValue;

//        }*/

//        //Mixed accessibility 
//        public int Id { get; private set;}  // can read but not write
//        //public int PassWord {private get; set;}

//        public bool IsColor
//        {
//            get { return ReleaseYear > 1940; }  // no setter => nobody can write
//        }

//        public bool IsOwned { get; set; } // check box is boolean value 

//        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )  //generate interface
//        {
//            //implement validatable object
//            var results = new List<ValidationResult>();


//            //movie name is required
//            if (String.IsNullOrEmpty(Name))
//                results.Add(new ValidationResult("Name is required.", new[] {nameof(Name) }));  //nameof: convert to string 
//            //release year required
//            if (ReleaseYear < 1900)
//                results.Add(new ValidationResult("Release year must be >= 1900", new[] { nameof(ReleaseYear) }));
//            //run length is required
//            if (RunLength < 0)
//                results.Add(new ValidationResult("Run length must be >= 0", new[] { nameof(RunLength) }));


//            return results;
//        }
//    }

//}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSE1430.MovieLib
{
    public class Movie : IValidatableObject
    {
        //Property to back the name field
        public string Name
        {
            get => _name ?? "";  
            set => _name = value;
            //lambda replace     //get { return _name ?? ""; }  // string get ()
                                 //set { _name = value; }       // void set ( string value )
        }

        //Backing field for name
        private string _name = "";

        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value; }
        }

        private string _description;

        //Using auto property with field initializer
        public int ReleaseYear { get; set; } = 1900;

        //Using auto property
        public int RunLength { get; set; }

        //Using mixed accessibility
        public int Id { get; private set; }

        //Using calculated property with no setter
        public bool IsColor => ReleaseYear > 1940; 
        // if get/read property only, lambda doesnt need { } like below
        //{
        //    //get { return ReleaseYear > 1940; }
        //    get => ReleaseYear > 1940;
        //}

        public bool IsOwned { get; set; }

        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext ) //must be public 
        {
            //var results = new List<ValidationResult>();

            if (String.IsNullOrEmpty(Name))
                yield return new ValidationResult("Name is required.",
                                new[] { nameof(Name) });

            if (ReleaseYear < 1900)
                yield return new ValidationResult("Release year must be >= 1900",
                                new[] { nameof(ReleaseYear) });

            if (RunLength < 0)
                yield return new ValidationResult("Run length must be >= 0",
                                new[] { nameof(RunLength) });
        }


        #region Unused Code

        //Don't make fields public
        //public System.String Name;

        //public string GetName ()
        //{
        //    return _name ?? "";
        //}
        //public void SetName ( string value )
        //{
        //    _name = value;
        //}

        //public string GetDescription ()
        //{
        //    return _description ?? "";
        //}

        //public void SetDescription ( Movie this, string value )
        //public void SetDescription ( string value )
        //{
        //    //this._description = value;
        //    //this.
        //    _description = value;
        //}

        //{
        //    get { return _releaseYear; }
        //    set {
        //        if (value >= 1900)
        //            _releaseYear = value;
        //    }
        //}

        //public int GetReleaseYear()
        //{
        //    return _releaseYear;
        //}
        //public void SetReleaseYear ( int value )
        //{
        //    if (value >= 1900)
        //        _releaseYear = value;
        //}
        //private int _releaseYear = 1900;

        //Auto property syntax

        //public int GetRunLength()
        //{
        //    return _runLength;
        //}
        //public void SetRunLength( int value )
        //{
        //    if (value >= 0)
        //        _runLength = value;
        //}
        //private int _runLength;

        //int someValue;
        //private int someValue2;

        //void Foo ()
        //{
        //    var x = RunLength;

        //    var isLong = x > 100;

        //    var y = someValue;

        //}
        #endregion
    }
}

