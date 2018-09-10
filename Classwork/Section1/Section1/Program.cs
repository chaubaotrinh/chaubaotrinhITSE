/*
 * ITSE 1420
 * Sample implementation 
*/

using System;

namespace Section1
{
    class Program
    {
        static void Main( string[] args )
        {
            bool notQuit;
            do
            {
                notQuit = DisplayMenu();
            }
            while (notQuit);
            //PlayWithStrings();

        }
        

        private static void PlayWithStrings()
        {
            string hoursString = "10A";
            //Convert from string to primitive expression
            //int hours = Int32.Parse(hoursString);
            //int hours;
            //bool result = Int32.TryParse(hoursString, out hours);  //out keyword: output parameter //3lines = 1 next line
            bool result = Int32.TryParse(hoursString, out int hours);

            hoursString = hours.ToString(); //ToString always works in any expression 
            //4.75.ToString();
            //457.ToString();
            //Console.ReadLine().ToString();   //convert any expression into string 

            
            string message = "Hello\tworld"; //escape sequence \t = to tab character 
            string filePath = "C:\\Temp\\Test";
            

            //Verbatim strings
            filePath = @"C:\Temp\Test";

            //Concat
            string firstName = "Bob";
            string lastName = "Smith";
            string name = firstName + " " + lastName;

            //string cannot have value changed/immunable
            //name = "Hello" + name;
            Console.WriteLine("Hello " + name);  // Approach 1
            Console.WriteLine("Hello {0},{1}", firstName, lastName);     //Approach 2 {0} firstName {1} lastName
            string str = String.Format("Hello {0} {1}", firstName, lastName);   //string format //Approach 3
            Console.WriteLine(str);

                // Approach 4  - using this approach 
            Console.WriteLine($"Hello {firstName} {lastName}");

            // NULL vs EMPTY
            string missing = null; //null: I dont have a value 
            string empty = ""; // this is a valid string, not same as null
            string empty2 = String.Empty; //another way of empty string, used for language doesnt support string

            // Checking for empty string -- 3 ways
            // if (firstName.Length == 0)
            // if (firstName != null && firstName != "" )
            // if (firstName == String.Empty)
            if (!String.IsNullOrEmpty(firstName))

            Console.WriteLine(firstName);

            // Other stuff
            string upperName = firstName.ToUpper();  //capitalize the whole string
            string lowerName = firstName.ToLower();

            //Comparison
            bool areEqual = firstName == lastName;
            areEqual = firstName.ToLower() == lastName.ToLower();
            areEqual = String.Compare(firstName, lastName, true) == 0; //return to int type O: equal   --->use this way 
                                                                       // Compare the expression vs the return value => true/false

            bool startsWithA = firstName.StartsWith("A");
            bool endsWithA = firstName.EndsWith("A");
            bool hasA = firstName.IndexOf("A") >= 0;    //how many A in the string??
            string subset = firstName.Substring(4);    //start with index 4 to the end. start point must less than the length

            // Clean up 
            string cleanMe = firstName.Trim();   //delete whitespace in the front and back of the string
            string cleanMeBefore = firstName.TrimStart();   // or TrimEnd()
            string makeLonger = firstName.PadLeft(20);  //PadRight ===> add width in the left or right

        }

        private static void PlayWithArrays()
        {
            int count = ReadInt32("How many names? ", 1);

            string[] names = new string[count];
            for (int index = 0; index < count; ++index)
            {
                Console.Write("Name? ");
                names[index] = Console.ReadLine();
            };


            //foreach v.s for statement (same purpose) 
                    //However foreach loop can't work with the sub array. It will run though the whole array 
            foreach (string name in names)  // new variable name in the names array 
            //number of elements arrayName.Length
            //for (int index = 0; index < names.Length; ++index) 
            {
                //readonly - not allowed 
                //name = " ";  --- can't modify the array, add or remove
                string str = name;
                str = "";
                // Console.WriteLine(names[index]);  --- with for statement 
                Console.WriteLine(name);
            }

        }
           

        private static bool DisplayMenu()
        {
            while (true)  //control flow 
            {

                Console.WriteLine("A)dd Movie");
                Console.WriteLine("E)dit Movie");
                Console.WriteLine("D)elete Movie");
                Console.WriteLine("V)iew Movies");
                Console.WriteLine("Q)uit");

                string input = Console.ReadLine();

                switch (input[0])
                {
                    case 'a':
                    case 'A': AddMovie(); return true;     //multiple cases turn back to the same result

                    case 'e':
                    case 'E': EditMovie(); return true;

                    case 'd':
                    case 'D': DeleteMovie(); return true;

                    case 'v':
                    case 'V': ViewMovies(); return true;

                    case 'q':
                    case 'Q': ; return false;

                    default: Console.WriteLine("Please enter a valid value."); break;   //always break;
                };
            };

        }

        private static void ViewMovies()
        {
            if (String.IsNullOrEmpty(name))         //if there is no Movie, print out no movie 
            {
                Console.WriteLine("No movie available");
                return;
            }
            
            Console.WriteLine(name);

            if (!String.IsNullOrEmpty(description))
                Console.WriteLine(description);

            Console.WriteLine($"Run length = {runLength} mins");
        }

        private static void EditMovie()  //copy from add movie first 
        {
            ViewMovies();

            var newName = ReadString("Enter a name (or press Enter for default: )", false); //do not modify, change true to false or take it out => except empty string 
            if (!String.IsNullOrEmpty(newName))  //assign a new name
                name = newName;

            var newDescription = ReadString("Enter a new description (or press Enter for default: )");
            if (!String.IsNullOrEmpty(newDescription))
                description = newDescription;

          
            var newLength = ReadInt32("Enter run length (in minutes): ", 0);
            if (newLength > 0)
                runLength = newLength;
        }

        private static void AddMovie()
        {
            name = ReadString("Enter a name: ", true);
            description = ReadString("Enter a description: ");
            runLength = ReadInt32("Enter run length (in minutes): ", 0);  //at least 0
        }

        private static void DeleteMovie()
        {
            if (Confirm("Are you sure you want to delete this movie?"))
            {
                //Delete the movie 
                name = null;  //set back to null
                description = null;
                runLength = 0;
            };

        }

        private static bool Confirm( string message ) //generate a method 
        {
            Console.WriteLine($"{message} (Y/N)");
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);  //Readkey return back to keyinfo, true => dont see the key printed out 
                switch (key.KeyChar)
                {
                    case 'Y':
                    case 'y':
                    return true;

                    case 'N':
                    case 'n':
                    return false;
                };

                /*
                if (key.KeyChar == 'Y')
                    return true;
                else if (key.KeyChar == 'N')
                    return false;
                */
            }
            while (true);


        }

        private static int ReadInt32( string message, int minValue )  //read an int  --- parameter
        {
            while (true)
            {

                Console.WriteLine(message);
                string input = Console.ReadLine();

                if (Int32.TryParse(input, out int result))  // can use out var instead of out in 
                {
                    if (result >= minValue)
                        return result;
                };
                Console.WriteLine($"You must enter an integer value >= {minValue}");
            };
        }

        private static string ReadString (string message)
        {
            return ReadString(message, false);
        }

        private static string ReadString( string message, bool required )
        {
            while (true)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();

                if (!String.IsNullOrEmpty(input) || !required )
                    return input;

                Console.WriteLine("You must enter a value");
            };
        }

        //A movie name 
        static string name;
        static string description;
        static int runLength;
        //static DateTime releaseDate;

    }
}
