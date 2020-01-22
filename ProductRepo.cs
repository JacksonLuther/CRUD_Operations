using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace CRUD_Operations
{
    public class ProductRepo
    {
        public static string connString;

        public List<Product> GetProducts()
        {
            MySqlConnection conn = new MySqlConnection(connString);
            using (conn)
            {
                conn.Open();
                MySqlCommand command = conn.CreateCommand();

                command.CommandText = "SELECT ProductID, Name, Price, StockLevel FROM products;";
                MySqlDataReader reader = command.ExecuteReader();

                var products = new List<Product>();
                while (reader.Read())
                {
                    var row = new Product();
                    row.ProductID = reader.GetInt32("ProductID");
                    row.Name = reader.GetString("Name");
                    row.Price = reader.GetDecimal("Price");
                    row.StockLevel = reader.GetInt32("StockLevel");

                    products.Add(row);
                }
                return products;
            }
        }

        public void CreateProduct(Product p)
        {
            MySqlConnection conn = new MySqlConnection(connString);

            using (conn)
            {
                conn.Open();

                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "INSERT INTO products (Name, Price, CategoryID, OnSale) " +
                    "VALUES(@name, @price, @catID, @sale);";
                command.Parameters.AddWithValue("name", p.Name);
                command.Parameters.AddWithValue("price", p.Price);
                command.Parameters.AddWithValue("catID", p.CategoryID);
                command.Parameters.AddWithValue("sale", p.OnSale);

                command.ExecuteNonQuery();
            }
        }
        public void UpdateProduct(Product p)
        {
            MySqlConnection conn = new MySqlConnection(connString);

            using (conn)
            {
                conn.Open();

                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "UPDATE products SET StockLevel=@stock WHERE ProductID=@prodID;";
                command.Parameters.AddWithValue("stock", p.StockLevel);
                command.Parameters.AddWithValue("ProdID", p.ProductID);
                command.ExecuteNonQuery();
            }
        }
        public void DeleteProduct(int id)
        {
            MySqlConnection conn = new MySqlConnection(connString);

            using (conn)
            {
                conn.Open();

                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "DELETE FROM products WHERE ProductID=@prodID;";
                command.Parameters.AddWithValue("prodID", id);
                command.ExecuteNonQuery();

            }
        }
        public void DeleteProduct(string name)
        {
            MySqlConnection conn = new MySqlConnection(connString);

            using (conn)
            {
                conn.Open();

                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "DELETE FROM products WHERE name=@name;";
                command.Parameters.AddWithValue("name", name);
                command.ExecuteNonQuery();

            }

        }
        public void DeleteProduct(string name, int id)
        {
            MySqlConnection conn = new MySqlConnection(connString);

            using (conn)
            {
                conn.Open();

                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "DELETE FROM products WHERE Name=@name AND ProductID=@prodID;";
                command.Parameters.AddWithValue("name", name);
                command.Parameters.AddWithValue("prodID", id);
                command.ExecuteNonQuery();

            }

        }
    }
}
