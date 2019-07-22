using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new List<Product>()
            {
                new Product(){Id=1, Name="Nokia 3310", Price=2838, ProductType="Mobile"},
                new Product(){Id=1, Name="Apple iMac", Price=234324, ProductType="Mobile"},
                new Product(){Id=1, Name="Table", Price=13344, ProductType="Furniture"},
                new Product(){Id=1, Name="Chair", Price=12345, ProductType="Furniture"},
                new Product(){Id=1, Name="Monitor", Price=9000, ProductType="Computer"},
                new Product(){Id=1, Name="Laptop", Price=60000, ProductType="Computer"},
                new Product(){Id=1, Name="Pen", Price=1000, ProductType="Stationary"},
            };

            //SELECT Name,Price,Code FROM Products WHERE Price>5000 AND Price<20000

            var retrieveProducts = from product in products
                                   where product.Price > 5000 && product.Price < 20000
                                   orderby product.Name descending
                                   select 
                                   new {
                                       Name = product.Name,
                                       Price = product.Price,
                                       Code = product.Name + product.ProductType
                                   } ;



            var productList = products
                                .Where(p=> p.Price > 5000 && p.Price < 20000)
                                .OrderByDescending(p=>p.Name)
                                .Select(p=> new {
                                    Name = p.Name,
                                    Price = p.Price,
                                    Code = p.Name + p.ProductType
                                });


            foreach (var p in retrieveProducts)
            {
                Console.WriteLine(p.Name + " " + p.Price+" "+p.Code);
            }

            Console.ReadKey();

        }
    }
}
