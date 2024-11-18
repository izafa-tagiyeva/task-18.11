using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    public class LoggedInMenu
    {
        public  void Start()
        {
            while (true)
            {
                Console.WriteLine("1. Show Products");
                Console.WriteLine("2. Show Basket");
                Console.WriteLine("3. Log Out");

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ProductService.ShowProducts();
                        break;
                    case "2":
                        BasketService.ShowBasket();
                        break;
                   
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}
