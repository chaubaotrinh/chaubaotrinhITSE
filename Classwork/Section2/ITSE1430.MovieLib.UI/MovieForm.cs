using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
            if (!ValidateChildren()) //validate children in form 
                return;

            //Initialize syntax
            var movie = new Movie()     //new: to create the instance of the object
            {                          // if you next do movie = new Movie(); => delete line above
                                       //var movie2 = new Movie(); // => to create a new set of Movie(), not lose the previous one 
                                       //var name = movie2.GetName();


                Name = _txtName.Text,
            //Name is required
            //movie.SetName (_txtName.Text);
            //if (String.IsNullOrEmpty(movie.Name))
            //    return;
                Description = _txtDescription.Text,
            //movie.SetDescription (_txtDescription.Text);

            //Released year is numeric, if set
                ReleaseYear= GetInt32(_ReleasedYear),
            //if (movie.ReleaseYear < 0)
            //    return;

            //Run Length, if set
                RunLength = GetInt32(_RunLength),
            //if (movie.RunLength < 0)
            //    return;

                IsOwned = _chkOwned.Checked,
            };

            //Validator.TryValidateObject()
            var results = ObjectValidator.Validate(movie);
            //if (results.Count > 0)
            foreach (var result in results )
            {
                //var firstMessage = results[0];
                MessageBox.Show(this, result.ErrorMessage, "Validation Failed", MessageBoxButtons.OK);

                return;
            };


            Movie = movie;
            
            DialogResult = DialogResult.OK;  // if click save => return ok
            Close();
        }
        
        private int GetInt32(TextBox textBox)
        {
            if (String.IsNullOrEmpty(textBox.Text))
                return -1;

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
            ValidateChildren(); //validate all children
        }

        private void OnValidateName( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                //control.Error
                _errors.SetError(control, "Name is required");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnValidateReleaseYear( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;
            var result = GetInt32(control);
            if (result < 0)
            {
                _errors.SetError(control, "Must be > 0");
                e.Cancel = true;
            }
            else
                _errors.SetError(control, "");

        }

        private void OnValidateRunLength( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;
            var result = GetInt32(control);
            if (result < 1900)
            {
                _errors.SetError(control, "Must be > 1900");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");

        }
    }
}
