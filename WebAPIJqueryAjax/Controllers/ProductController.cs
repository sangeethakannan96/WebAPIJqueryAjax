using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIJqueryAjax.Models;

namespace WebAPIJqueryAjax.Controllers
{
    public class ProductController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Product> Get()
        {
            List<Product> product = new List<Product>();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand("select * from Product", conn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                product.Add(new Product()
                {
                    Id = Convert.ToInt32(reader.GetValue(0)),
                    Name = reader.GetValue(1).ToString(),
                    Price = Convert.ToDecimal(reader.GetValue(2)),
                    Quantity = Convert.ToInt32(reader.GetValue(3)),
                    Active = Convert.ToInt32(reader.GetValue(4))
                });
            }
            conn.Close();
            return product;
           
        }

        // GET api/<controller>/5
        public Product Get(int id)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand("Select * from Product where Id=@id", conn);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            Product product = new Product();
            while (reader.Read())
            {
                product.Id = Convert.ToInt32(reader.GetValue(0));
                product.Name = reader.GetValue(1).ToString();
                product.Price = Convert.ToDecimal(reader.GetValue(2));
                product.Quantity = Convert.ToInt32(reader.GetValue(3));
                product.Active = Convert.ToInt32(reader.GetValue(4));
            }
            conn.Close();
            return product;
        }

        // POST api/<controller>
        public string Post(Product product)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand("insert into Product(Name, Price, Quantity, Active) Values(@Name, @Price, @Quantity, @Active)", conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Price", product.Price);
            command.Parameters.AddWithValue("@Quantity", product.Quantity);
            command.Parameters.AddWithValue("@Active", product.Active);
            command.ExecuteNonQuery();
            conn.Close();
            return "Inserted successfully";


        }

        // PUT api/<controller>/5
        public string Post(Product product, int id)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand("update Product set Name=@Name, Price=@Price, Quantity=@Quantity where Id=@id", conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Price", product.Price);

            command.Parameters.AddWithValue("@Quantity", product.Quantity);
            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();
            conn.Close();
            return "Updated successfully";

        }

        // DELETE api/<controller>/5
        public string Delete(int id)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand("Delete from Product where Id=@id", conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            conn.Close();
            return "Deleted successfully";
        }
    }
}