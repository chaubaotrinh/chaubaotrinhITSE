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
    public partial class MainForm : Form
    {
        public MainForm()  
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click( object sender, EventArgs e )
        {
            //call close function 
            if (MessageBox.Show("Are you sure you want to exit?", "Close", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            // "Close" - caption of the dialog => the second string is the title of the message box
            Close();
        }

        private void OnHelpAbout( object sender, EventArgs e )  //change aboutToolStripMenuItem_Click to OnHelpAbout
        {
            //aboutToolStripMenuItem. default variable name, then change to _miHelpAbout in Name property
            MessageBox.Show(this, "Sorry", "Help", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //MessageBox.Show method use the predifined button, change the caption and add the message only!
            // add help icon: add "this," in the beginning and icon code should be in the last position 
        }

        private void OnMovieAdd( object sender, EventArgs e )  //rename 
        {
            var form = new MovieForm();  //create child form code after add form

            if (form.ShowDialog(this) == DialogResult.Cancel)  //after Cancel codes in MovieForm
                return;
                                //form.ShowDialog(); => show model window => can't interact with main/parent window => Alt F4 to exist 
                                //form.Show();  // show modeless window => can interact with main window 


                                //MessageBox.Show("Adding movie");
                                //_movies[0] = form.Movie;
            _database.Add(form.Movie);
            RefreshMovies();
                                //Movie.Name = "";
        }

        //private Movie Movie;
        //private Movie[] _movies = new Movie[100]; // change to array 
        private MovieDatabase _database = new MovieLib.MovieDatabase();

        private void MainForm_Load( object sender, EventArgs e ) //from caption bar, double click 
        {
            _listMovies.DisplayMember = "Name";  //displayMember property => show name 
            RefreshMovies();
            
        }
        private void RefreshMovies()
        {
            var movies = _database.GetAll();

            _listMovies.Items.Clear(); // call clear 
            _listMovies.Items.AddRange(movies); //Addrange method require array 
        }
        private Movie GetSelectedMovie()
        {
            return _listMovies.SelectedItem as Movie; //copy from delete
            
        }

        private void OnMovieDelete( object sender, EventArgs e ) // to delete the movie 
        {
            var item = GetSelectedMovie(); // force item object as Movie type, SelectedItem Property => require to select item 
            if (item == null)
                return;

            _database.Remove(item.Name);
            RefreshMovies();
        }

        private void OnMovieEdit( object sender, EventArgs e ) //start with copy from Add
        {

            var item = GetSelectedMovie(); //copy from delete 
            if (item == null)
                return;

            var form = new MovieForm(); //copy from add
            form.Movie = item;
            if (form.ShowDialog(this) == DialogResult.Cancel)  
                return;
           
            _database.Edit(item.Name, form.Movie);
            RefreshMovies();
        }
    }
}
