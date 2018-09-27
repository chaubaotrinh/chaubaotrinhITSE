using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSE1430.MovieLib
{
    public class Movie    //(type = class)  => call Movie instances
    {
        public string GetName()     //Name, ....RunLength are members
                                    //public System.String Name; (same as line 11), change the Name field to GetName method 
        {
            return _name ?? "";     //deal with null
        }
        public void SetName (string value)
        {
            _name = value;
        }
        private string _name; //still need a field Name, now change to _name, and always private

        public string GetDescription()
        {
            return _description ?? "";
        }
        public void SetDescription (string value)
        {
            //this. : use this. to pass instance to others
            _description = value;  
            //same: this._description = value;
        }

        private string _description;   // variables inside instances called fields

        public int GetReleaseYear()
        {
            return _releaseYear;
        }
        public void SetReleaseYear( int value )
        {
            if (value >= 1900)
            _releaseYear = value;
        }
        private int _releaseYear;

        public int GetRunLength()
        {
            return _runLength ;
        }
        public void SetRunLength( int value )
        {
            if (value >= 0)       //make sure the run length is not less than 0
            _runLength = value;
        }
        private int _runLength;

        //int someValue;   // = private int someValue;

        //declare a function Foo inside the instance/class => call Method, not function. C# doesn't have function
        //method: bring functionality into the data
        /*void Foo()
        {
            var x = RunLength;  //RunLength: field, x: variable 

            var isLong = x > 10;

            var y = someValue;

        }*/
    }
}
