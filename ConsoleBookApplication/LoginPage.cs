using BookManagementClassLibrary;
using BookManagementClassLibrary.DbContexts;
using BookManagementClassLibrary.Domains;
using BookManagementClassLibrary.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ConsoleBookApplication
{
    internal class LoginPage
    {
        /// <summary>
        /// Start up page to be displayed on running
        /// </summary>
        public static void StartPage()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Book Inventory Management System");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Sign Up");
            Console.WriteLine("3. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine()??string.Empty);

            switch (choice)
            {
                case 1:
                    Login(new BookDbContext().Set<User>());
                    break;
                case 2:
                    SignUp(new UserRepository<User>(new BookDbContext()));
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
        /// <summary>
        /// login for existing users
        /// </summary>
        /// <param name="user"></param>
        static void Login(DbSet<User> user)
        {
            Console.Clear();
            Console.Write("Enter your email: ");
            string email = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter your password: ");
            string password = Console.ReadLine() ?? string.Empty;

            //getting the info if the user enters correct credentials
            var userInfo = user.SingleOrDefault(u => u.Email == email && u.Password == password && u.IsDeleted == false);

            if (userInfo != null)
            {
                Console.WriteLine("Login successful!");
                Menu.DisplayMenu(userInfo);
            }
            else
            {
                Console.WriteLine("Invalid email or password.");
            }
        }
        /// <summary>
        /// Sign up for new users
        /// </summary>
        /// <param name="user"></param>
        static void SignUp(UserRepository<User> user)
        {
            Console.Clear();
            Console.Write("Enter your first name: ");
            string firstName = Console.ReadLine()??string.Empty;
            Console.Write("Enter your last name: ");
            string lastName = Console.ReadLine()?? string.Empty;
            Console.Write("Enter your email: ");
            string email = Console.ReadLine()??string.Empty;
            Console.Write("Enter your password: ");
            string password = Console.ReadLine()??string.Empty;

            var newUser = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };
            //adding the user to the User table
            user.Add(newUser);

            Console.WriteLine("Account created successfully!");
            Menu.DisplayMenu(user.Get(newUser));
        }
    }
}
