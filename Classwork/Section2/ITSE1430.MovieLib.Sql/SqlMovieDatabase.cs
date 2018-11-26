using System;
using System.Collections.Generic;
using System.Data;
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

            using (var conn = CreateConnection())
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
            using (var conn = CreateConnection())
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

        //Gets the ID if this is a SQL movie
        private object GetMovieId( Movie movie )
        {
            var sql = movie as SqlMovie;

            return sql?.Id ?? 0;
        }

        protected override Movie FindByName( string name )
        {
            //Use a data reader
            using (var conn = CreateConnection())
            {
                var cmd = new SqlCommand("GetAllMovies", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while(reader.Read()) //read data
                    {
                        var movieName = reader.GetString(1);
                        if (String.Compare(movieName, name, true) != 0)
                            continue;

                        //reader.GetOrdinal("Id");

                        return new SqlMovie()
                        {
                            Id = reader.GetFieldValue<int>(0), //0 index
                            Name = movieName,
                            Description = Convert.ToString(reader.GetValue(2)),
                            ReleaseYear = 1900,
                            RunLength = reader.GetFieldValue<int>(3),
                            IsOwned = reader.GetBoolean(4),
                        };
                    };
                };

                return null;
            };
        }

        protected override IEnumerable<Movie> GetAllCore()
        {
            var ds = new DataSet();

            using (var conn = CreateConnection())
            {
                var da = new SqlDataAdapter();
                var cmd = new SqlCommand("GetAllMovies", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Use data adapter to fill dataset
                da.SelectCommand = cmd;
                da.Fill(ds);
            };

            //Read data
            //if (!ds.Tables.OfType<DataTable>().Any())
            //    return Enumerable.Empty<Movie>();
            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
            if (table == null)
                return Enumerable.Empty<Movie>();

            var movies = new List<Movie>();
            foreach (var row in table.Rows.OfType<DataRow>())
            {
                var movie = new SqlMovie()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row.Field<string>("Title"),
                    Description = Convert.ToString(row[2]),
                    ReleaseYear = 1900,
                    RunLength = row.Field<int>(3),
                    IsOwned = Convert.ToBoolean(row[4]),
                };
                movies.Add(movie);
            };

            return movies;
            //throw new NotImplementedException();
            //return new Movie[0];
        }

        protected override void RemoveCore( string name )
        {
            //find ID
            var movie = FindByName(name);
            if (movie == null)
                return;

            using (var conn = CreateConnection())
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
            private SqlConnection CreateConnection() => new SqlConnection(_connectionString);

       
       
    }
}
