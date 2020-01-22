using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace CRUD_Operations
{
    class Program
    {
        static void Main(string[] args)
        {

            string defaultKey = File.ReadAllText("appsettings.Debug.Json");
            JObject jObject = JObject.Parse(defaultKey);
            JToken token = jObject["DefaultConnection"];
            string connectionString = token.ToString();
            ProductRepo.connString = connectionString;

            


            ProductRepo repo = new ProductRepo();

            //Create Products

            //Console.WriteLine("Creating Product.....");
            //var newProduct = new Product
            //{
            //    Name = "Jjacksons Product",
            //    Price = 420.69M,
            //    CategoryID = 2,
            //    OnSale = 0
            //};
            //repo.CreateProduct(newProduct);
            //Console.WriteLine("Product Created!");

            //Update Products

            //Console.WriteLine("Updating Product....");
            //var newInfo = new Product { StockLevel = 27, ProductID = 941 };
            //repo.UpdateProduct(newInfo);
            //Console.WriteLine("Product Updated!");
            
            // DELETE

            //repo.DeleteProduct(943);
            //repo.DeleteProduct("Jacksons Product");
            //repo.DeleteProduct("Jjacksons Product", 946);

            // Read Products

            List<Product> products = repo.GetProducts();

            foreach (var prod in products)
            {
                Console.WriteLine($"{prod.ProductID}  {prod.Name} ----------- ${prod.Price}--------Quantity: {prod.StockLevel} of these items.");
            }

            











        }
    }
}
