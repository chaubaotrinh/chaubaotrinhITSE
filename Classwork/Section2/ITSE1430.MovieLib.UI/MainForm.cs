using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITSE1430.MovieLib.Memory;

namespace ITSE1430.MovieLib.UI
{
    public partial class MainForm : Form
    {
        
   

        public MainForm()  // constructor: name = name of class, and no return type even void, can have or not parameter 
        {
            InitializeComponent();
        }

        private void OnFileExit( object sender, EventArgs e )
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
        private MovieDatabase _database = new MemoryMovieDatabase();

       
        private void RefreshMovies()
        {
            //OrderBy
            //var movies = _database.GetAll();

            //LINQ syntax
            var movies = from m in _database.GetAll()
                         orderby m.Name
                         select m;

            _listMovies.Items.Clear(); // call clear 
            //foreach (var movie in movies)
            //    _listMovies.Items.Add(movie);

            _listMovies.Items.AddRange(movies.ToArray()); //Addrange method require array 
        }
        private Movie GetSelectedMovie()
        {
            return _listMovies.SelectedItem as Movie; //copy from delete
            
        }

        private void OnMovieDelete( object sender, EventArgs e ) // to delete the movie 
        {
            DeleteMovie();
        }

        private void OnMovieEdit( object sender, EventArgs e ) //start with copy from Add
        {

            EditMovie();
        }

        private void OnMovieDoubleClick( object sender, EventArgs e )
        {
            //var control = sender as ListBox;
            //var item = control.SelectedItem as Movie;
            EditMovie();
        }

        private void EditMovie()
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

        private void OnListKeyUp( object sender, KeyEventArgs e )
        {
            if (e.KeyData == Keys.Delete)
            {
                DeleteMovie();
            };
        }

        private void DeleteMovie()
        {
            var item = GetSelectedMovie(); // force item object as Movie type, SelectedItem Property => require to select item 
            if (item == null)
                return;

            _database.Remove(item.Name);
            RefreshMovies();
        }

        //This method can be overriden in a derived type
        protected virtual void SomeFunction()  //virtual method - based implementation may be overriden 
        {

        }

        //This method MUST BE defined in a derived type 
        //protected abstract void SomeAbstractFunction()
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>

        protected override void OnLoad( EventArgs e )  //derived method. Start with override keyword 
        {
            base.OnLoad(e);

            //Seed database
            //var seed = new SeedDatabase();
            //SeedDatabase.Seed(_database);  Call SeedDatabase. Type of _database: interface 
            _database.Seed();

            _listMovies.DisplayMember = "Name";
            RefreshMovies();
        }

       
    }


}
