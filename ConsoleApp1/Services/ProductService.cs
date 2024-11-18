using ConsoleApp1.Contexts;
using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Helper.Exceptions.Exceptionss;

namespace ConsoleApp1.Services
{
    static public class ProductService
    {
        public static void ShowProducts()
        {
            Console.Clear();
            using (AppDbContext context = new AppDbContext())
            {
                var products = context.Products.ToList();

                if (products.Any())
                {
                    foreach (var product in products)
                    {
                        Console.WriteLine($"{product.Id}. {product.Name} - {product.Price:C}");
                    }
                }
                else
                {
                    Console.WriteLine("No products available.");
                    return;
                }

                Console.WriteLine("Enter product ID to add to cart, or 0 to go back:");
                if (int.TryParse(Console.ReadLine(), out int productId) && productId > 0)
                {
                    var product = context.Products.Find(productId);
                    if (product != null)
                    {
                        BasketService.AddToBasket(productId);
                        Console.WriteLine($"{product.Name} added to basket.");
                    }
                    else
                    {
                        Console.WriteLine("Product not found.");
                    }
                }
            }
        }
    }


}
