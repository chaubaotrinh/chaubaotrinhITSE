/* 
 * Student: Chau Trinh
 * Class: ITSE 1430
 * Lab 4: Nile
 * Date: 19 Nov 2018
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Stores.Sql
{
    public class SqlProductDatabase : ProductDatabase
    {
        public SqlProductDatabase( string connectionString )
        {
            //Validate
            if (connectionString == null)
                throw new ArgumentNullException(nameof(connectionString));
            if (connectionString == "")
                throw new ArgumentException("Connection string cannot be empty."
                            , nameof(connectionString));

            _connectionString = connectionString;
        }
        
        private readonly string _connectionString;

        protected override Product AddCore( Product product )
        {
            using (var conn = CreateConnection())
            {
                var cmd = new SqlCommand("AddProduct", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@isDiscontinued", product.IsDiscontinued);
               
                conn.Open();
                var result = cmd.ExecuteScalar();
                var id = Convert.ToInt32(result);
            };

            return AddCore(product);
        }

        protected override IEnumerable<Product> GetAllCore()
        {
            //Using a data set
            var ds = new DataSet();

            //Create connection
            using (var conn = CreateConnection())
            {
                var da = new SqlDataAdapter();
                var cmd = new SqlCommand("GetAllProducts", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Use data adapter to fill dataset
                da.SelectCommand = cmd;
                da.Fill(ds);
            };

            //Must have at least one table
            
            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
            if (table == null)
                return Enumerable.Empty<Product>();

            //Enumerate the rows
            var products = new List<Product>();
            foreach (var row in table.Rows.OfType<DataRow>())
            {
                //Use ordinal or column names
                var product = new Product()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row.Field<string>("Name"),
                    Description = row.Field<string>("Description"),
                    Price = Convert.ToDecimal(row["Price"]),
                    IsDiscontinued = row.Field<bool>("IsDiscontinued"),
                };
                products.Add(product);
            };

            return products;
        }

        protected override Product GetCore( int id )
        {

            return FindProduct(id);
        }

        protected override void RemoveCore( int id )
        {
            var product = GetCore(id);
            if (product == null)
                return;

            using (var conn = CreateConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "RemoveMovie";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@id", GetCore(product.Id));

                conn.Open();
                cmd.ExecuteNonQuery();
            };

        }

        protected override Product FindProduct( int id )
        {
            //Use a data reader
            using (var conn = CreateConnection())
            {
                var cmd = new SqlCommand("GetAllProducts", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var productId = reader.GetFieldValue<int>(0);
                        if (productId != id)
                            continue;


                        return new Product()
                        {
                            Id = productId,
                            Name = Convert.ToString(reader.GetValue(1)),
                            Price = reader.GetFieldValue<decimal>(2),
                            Description = Convert.ToString(reader.GetValue(3)),
                            IsDiscontinued = reader.GetBoolean(4),
                        };
                    };
                };
            };
            return null;
        }

        protected override Product UpdateCore( Product existing, Product newItem )
        {
            using (var conn = CreateConnection())
            {
              
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UpdateProduct";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var id = GetCore(existing.Id);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", newItem.Name);
                cmd.Parameters.AddWithValue("@description", newItem.Description);
                cmd.Parameters.AddWithValue("@price", newItem.Price);
                cmd.Parameters.AddWithValue("@isDiscontinued", newItem.IsDiscontinued);
                

                conn.Open();
                cmd.ExecuteNonQuery();
            };
            return UpdateCore(existing, newItem);
        }

        private SqlConnection CreateConnection() => new SqlConnection(_connectionString);

       
    }
}
