using ConsoleApp1.Contexts;
using ConsoleApp1.Models;
using ConsoleApp1.Services;
using static ConsoleApp1.Helper.Exceptions.Exceptionss;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Main Menu ===");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("0. Exit");

                Console.Write("Please select your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        UserService.Login();
                        break;
                    case "2":
                        UserService.Register();
                        break;
                    case "0":
                        Console.WriteLine("Exiting the application...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
    


  
