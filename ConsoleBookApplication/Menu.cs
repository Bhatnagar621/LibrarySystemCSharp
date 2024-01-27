using BookManagementClassLibrary;
using BookManagementClassLibrary.DbContexts;
using BookManagementClassLibrary.Domains;
using BookManagementClassLibrary.Repositories;

namespace ConsoleBookApplication
{
    internal class Menu
    {
        /// <summary>
        /// Repeatedly display the Main menu
        /// </summary>
        /// <param name="user"></param>
        public static void DisplayMenu(User user)
        {
            LibraryRepository<Book> library = new LibraryRepository<Book>(new BookDbContext());
            int loop = 1;
            while(loop != 0)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Book Inventory Management System");
                Console.WriteLine("1. Add a new book");
                Console.WriteLine("2. Loan a book");
                Console.WriteLine("3. Return a book");
                Console.WriteLine("4. Display book information");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine()??string.Empty);

                switch (choice)
                {
                    case 1:
                        BookFunction.AddBook(library);
                        break;
                    case 2:
                        BookFunction.LoanBook(library, user);
                        break;
                    case 3:
                        BookFunction.ReturnBook(library, user);
                        break;
                    case 4:
                        BookFunction.DisplayBookInformation(library);
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.Write("Enter 0 to exit, 1 to continue");
                loop = int.Parse(Console.ReadLine()??String.Empty);
            }
        }
    }
}
