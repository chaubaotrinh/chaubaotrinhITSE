using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSE1430.MovieLib.Sql
{
    public class SqlMovieDatabase : MovieDatabase
    {
        //constructor 
        public SqlMovieDatabase (string connectionString )
        {
            if (connectionString == null)
                throw new ArgumentNullException(nameof(connectionString));
            if (connectionString == "")
                throw new ArgumentException("Connection string cannot be empty.", nameof(connectionString));

            _connectionString = connectionString;
        }

        private readonly string _connectionString;

        protected override void AddCore( Movie movie )
        {
            //Create connection 
            //var conn = new SqlConnection(_connectionString);

            //Command associated with connection 
            //var cmd = new SqlCommand("AddMovie", conn); //AddMovie stored in database
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //////Approach 1
            //var param = new SqlParameter("@title",System.Data.SqlDbType.VarChar);
            ////set parameter value to the title
            //param.Value = movie.Name;
            ////Assocaite parameter with command
            //cmd.Parameters.Add(param);

            //////Approach 2
            //var param = cmd.Parameters.Add("@title", System.Data.SqlDbType.VarChar);
            //param.Value = movie.Name;

            //////Approach 3: Database does not support Release Year
            //cmd.Parameters.AddWithValue("@title", movie.Name);
            //cmd.Parameters.AddWithValue("@length", movie.RunLength);
            //cmd.Parameters.AddWithValue("@isOwned", movie.IsOwned);
            //cmd.Parameters.AddWithValue("@description", movie.Description);

            //Run command
            //Open connection - to have connection to share the work. When open, need to close: try - finally. In order to make sure even codes after open fail, it still closes
            //Problems: scope

            //try
            //{
            //    conn.Open();
            //    var result = cmd.ExecuteScalar(); //Execute command => Insert => return back an object
            //    var id = Convert.ToInt32(result);
            //} finally
            //{
            //    //close connection 
            //    conn.Close();
            //}

            using (var conn = CreatConnection())
            {
                var cmd = new SqlCommand("AddMovie", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@title", movie.Name);
                cmd.Parameters.AddWithValue("@length", movie.RunLength);
                cmd.Parameters.AddWithValue("@isOwned", movie.IsOwned);
                cmd.Parameters.AddWithValue("@description", movie.Description);

                conn.Open();
                var result = cmd.ExecuteScalar();
                var id = Convert.ToInt32(result);
            };

             

        }

        protected override void EditCore( Movie oldMovie, Movie newMovie )
        {
            using (var conn = CreatConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UpdateMovie";
                //var cmd = new SqlCommand("AddMovie", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var id = GetMovieId(oldMovie);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@title", newMovie.Name);
                cmd.Parameters.AddWithValue("@length", newMovie.RunLength);
                cmd.Parameters.AddWithValue("@isOwned", newMovie.IsOwned);
                cmd.Parameters.AddWithValue("@description", newMovie.Description);

                conn.Open();
                cmd.ExecuteNonQuery();
               
            };
        }

        private object GetMovieId( Movie oldMovie )
        {
            return 1;
        }

        protected override Movie FindByName( string name )
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<Movie> GetAllCore()
        {
            //throw new NotImplementedException();
            return new Movie[0]; //return an empty array
        }

        protected override void RemoveCore( string name )
        {
            //find ID
            var movie = FindByName(name);
            if (movie == null)
                return;

            using (var conn = CreatConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "RemoveMovie";
                //var cmd = new SqlCommand("AddMovie", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var id = GetMovieId(movie);
                cmd.Parameters.AddWithValue("@id", id);
               
                conn.Open();
                cmd.ExecuteNonQuery();

            };
        }
            private SqlConnection CreatConnection() => new SqlConnection(_connectionString);
    }
}
