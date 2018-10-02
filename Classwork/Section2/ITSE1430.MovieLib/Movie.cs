using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSE1430.MovieLib
{
    public class Movie              //(type = class)  => call Movie instances
    {
        public string Name          //property Name: no ()
        {
            get { return _name ?? ""; }   // string get ()
            set { _name = value; }  // void set (string value) => return nothing 
        }
        // public string GetName()     //Name, ....RunLength are members
        //public System.String Name; (same as line 11), change the Name field to GetName method 
        // {
        //    return _name ?? "";     //deal with null
        //}
        //public void SetName (string value)
        //{
        //   _name = value;
        //}
        private string _name = ""; //still need a field Name, now change to _name, and always private, initialize field _name to empty 

        public string Description
        {
            get { return _description ?? ""; }  // never return null
            set { _description = value; }
        }
        /*public string GetDescription()
        {
            return _description ?? "";
        }
        public void SetDescription (string value)
        {
            //this. : use this. to pass instance to others
            _description = value;  
            //same: this._description = value;
        }*/

        private string _description;   // variables inside instances called fields

        public int ReleaseYear { get; set; } = 1900;  //initialize the backing field 
        /*{
            get { return _releaseYear; }
            set
            {
                if (value >= 1900)
                    _releaseYear = value;
            }
        }*/

        /*public int GetReleaseYear()
        {
            return _releaseYear;
        }
        public void SetReleaseYear( int value )
        {
            if (value >= 1900)
            _releaseYear = value;
        }
        */

        //private int _releaseYear = 1900;

        // Auto property syntax
        public int RunLength { get; set; }
        /*{
            get { return _runLength; }
            set
            {
                if (value >= 0)
                    _runLength = value;
            }
        }
        */

        /*public int GetRunLength()
        {
            return _runLength ;
        }
        public void SetRunLength( int value )
        {
                                 //make sure the run length is not less than 0
            _runLength = value;
        }
        */
        //private int _runLength;  // initialized to 0 by default, can't initialized to another field 

        //int someValue;   // = private int someValue;

        //declare a function Foo inside the instance/class => call Method, not function. C# doesn't have function
        //method: bring functionality into the data
        /*void Foo()
        {
            var x = RunLength;  //RunLength: field, x: variable 

            var isLong = x > 10;

            var y = someValue;

        }*/

        //Mixed accessibility 
        public int Id { get; private set;}  // can read but not write
        //public int PassWord {private get; set;}

        public bool IsColor
        {
            get { return ReleaseYear > 1940; }  // no setter => nobody can write
        }

    }
}
