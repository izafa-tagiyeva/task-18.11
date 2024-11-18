using ConsoleApp1.Contexts;
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Helper.Exceptions.Exceptionss;

namespace ConsoleApp1.Services
{
    static class BasketService
    {
        public static void ShowBasket()
        {
            Console.Clear();

            using (AppDbContext context = new AppDbContext())
            {
                var basketItems = context.Baskets.Where(b => b.UserId == UserService.LoggedInUserId.Value).ToList();

                if (basketItems.Any())
                {
                    Console.WriteLine("Your Basket:");
                    foreach (var item in basketItems)
                    {
                        var product = context.Products.FirstOrDefault(p => p.Id == item.ProductId);
                        if (product != null)
                        {
                            Console.WriteLine($"{product.Id}. {product.Name} - {product.Price:C}");
                        }
                    }

                    Console.WriteLine("Enter product ID to remove from basket, or 0 to go back:");
                    if (int.TryParse(Console.ReadLine(), out int productId) && productId > 0)
                    {
                        RemoveFromBasket(productId);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Menu closed...");
                    }
                }
                else
                {
                    Console.WriteLine("Basket is empty. Please add products.");
                }
            }
        }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void AddToBasket(int productId)
        {
        

            using (AppDbContext context = new AppDbContext())
            {
                context.Baskets.Add(new Basket
                {
                    UserId = UserService.LoggedInUserId.Value,
                    ProductId = productId
                });
                context.SaveChanges();
            }
        }

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void RemoveFromBasket(int productId)
        {
          

            using (AppDbContext context = new AppDbContext())
            {
                var basketItem = context.Baskets.FirstOrDefault(b => b.UserId == UserService.LoggedInUserId.Value && b.ProductId == productId);

                if (basketItem != null)
                {
                    context.Baskets.Remove(basketItem);
                    context.SaveChanges();
                    Console.WriteLine($"Product with ID {productId} removed from basket.");
                }
                else
                {
                    Console.WriteLine("Product not found in the basket.");
                }
            }
        }
    }

}
