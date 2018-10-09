using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITSE1430.MovieLib.UI
{
    public partial class MovieForm : Form
    {
        public MovieForm()
        {
            InitializeComponent();
        }

        //public Movie Movie;   //declare a field to store a movie inside of class and outside all other functions, type and field have the same name
        public Movie Movie { get; set; } // change field to property 
        private void OnCancel( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close(); //close function to close the form 
        }

        private void OnSave( object sender, EventArgs e )  //EVENTS
        {
            var movie = new Movie();   //new: to create the instance of the object
            // if you next do movie = new Movie(); => delete line above
            //var movie2 = new Movie(); // => to create a new set of Movie(), not lose the previous one 
            //var name = movie2.GetName();

            movie.Name = _txtName.Text;
            //Name is required
            //movie.SetName (_txtName.Text);
            if (String.IsNullOrEmpty(movie.Name))
                return;
            movie.Description = _txtDescription.Text;
            //movie.SetDescription (_txtDescription.Text);

            //Released year is numeric, if set
            movie.ReleaseYear=( GetInt32(_ReleasedYear));
            if (movie.ReleaseYear < 0)
                return;

            //Run Length, if set
            movie.RunLength = ( GetInt32(_RunLength));
            if (movie.RunLength < 0)
                return;

            movie.IsOwned = _chkOwned.Checked;
            Movie = movie;
            
            DialogResult = DialogResult.OK;  // if click save => return ok
            Close();
        }
        
        private int GetInt32(TextBox textBox)
        {
            if (String.IsNullOrEmpty(textBox.Text))
                return 0;

            if (Int32.TryParse(textBox.Text, out var value))
                return value;

            return -1; // why -1
        }

        private void MovieForm_Load( object sender, EventArgs e )
        {
            if (Movie != null)
            {
                _txtName.Text = Movie.Name;
                _txtDescription.Text = Movie.Description;
                _ReleasedYear.Text = Movie.ReleaseYear.ToString();
                _RunLength.Text = Movie.RunLength.ToString();
                _chkOwned.Checked = Movie.IsOwned;
            };

        }
    }
}
