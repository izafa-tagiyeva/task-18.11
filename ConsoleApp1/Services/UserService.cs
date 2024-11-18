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
    
        static public class UserService
        {
            public static int? LoggedInUserId { get; set; }

            public static void Register()
            {
                Console.Clear();
                Console.WriteLine("Registration:");
                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Surname: ");
                string surname = Console.ReadLine();

                Console.Write("Username: ");
                string username = Console.ReadLine();

                Console.Write("Password: ");
                string password = Console.ReadLine();

             

                using (AppDbContext context = new AppDbContext())
                {
                    if (context.Users.Any(u => u.Username == username))
                    {
                        Console.WriteLine("This username is already taken.");
                    }
                    else
                    {
                        context.Users.Add(new User { Name = name, Surname = surname, Username = username, Password = password });
                        context.SaveChanges();
                        Console.WriteLine("Registration successful!");
                    }
                }
               LoggedInMenu.Start();
            }

/// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            public static void Login()
            {
                Console.Clear();
                Console.WriteLine("Login:");
                Console.Write("Username: ");
                string username = Console.ReadLine();

                Console.Write("Password: ");
                string password = Console.ReadLine();

                using (AppDbContext context = new AppDbContext())
                {
                    var user = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
                    if (user != null)
                    {
                        Console.Clear();
                        Console.WriteLine($"Welcome, {user.Name}!");
                        LoggedInUserId = user.Id;
                        LoggedInMenu.Start();
                    }
                    else
                    {
                        Console.WriteLine("Username or password is incorrect.");
                    }
                }
               LoggedInMenu.Start();
            }
        }


    }


