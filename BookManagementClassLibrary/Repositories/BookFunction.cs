using BookManagementClassLibrary.DbContexts;
using BookManagementClassLibrary.Domains;

namespace BookManagementClassLibrary.Repositories
{
    public class BookFunction
    {
        /// <summary>
        /// Enter a new book in the database, i.e., Book table
        /// </summary>
        /// <param name="library"></param>
        public static void AddBook(LibraryRepository<Book> library)
        {
            Console.Clear();
            Console.WriteLine("Enter book information:");

            Console.Write("Title: ");
            string title = Console.ReadLine()??string.Empty;
            Console.Write("Author Id: ");
            int authorId = int.Parse(Console.ReadLine()??string.Empty);
            Console.Write("Genre Id: ");
            int genreId = int.Parse(Console.ReadLine() ?? string.Empty);
            Console.Write("Publisher Id: ");
            int publisherId = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.Write("Published Date (YYYY-MM-DD): ");
            string publishedDateString = Console.ReadLine()??string.Empty;
            DateOnly publishedDate = DateOnly.Parse(publishedDateString?? new ("2001,01,01"));

            Console.Write("ISBN: ");
            string isbn = Console.ReadLine() ?? string.Empty;

            Console.Write("Price: ");
            decimal price = decimal.Parse(Console.ReadLine() ?? string.Empty);

            Console.Write("Stock: ");
            int stock = int.Parse(Console.ReadLine() ?? string.Empty);

            //new book element
            var newBook = new Book
            {
                Title = title,
                AuthorId = authorId,
                GenreId = genreId,
                PublisherId = publisherId,
                PublishedDate = publishedDate,
                ISBN = isbn,
                Price = price,
                Stock = stock,
            };

            library.Add(newBook);
            Console.WriteLine("Book added successfully!");
        }

        /// <summary>
        /// User loans a book, book quantity decreases by 1, new record added to Loan table
        /// </summary>
        /// <param name="library"></param>
        /// <param name="user"></param>
        public static void LoanBook(LibraryRepository<Book> library, User user)
        {
            var context = new BookDbContext();
            LibraryRepository<Loan> loanRepo = new LibraryRepository<Loan>(context);
            UserRepository<User> userRepo = new UserRepository<User>(context);
            Console.Clear();
            Console.Write("Enter book ID to loan: ");

            int bookId = int.Parse(Console.ReadLine()??string.Empty);
            var bookDb = context.Set<Book>();
            var book = bookDb.FirstOrDefault(b=> b.Id==bookId);

            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }
            
            if (book.Stock <= 0)
            {
                Console.WriteLine("Book is out of stock.");
                return;
            }

            book.Stock--; //stock decrease by 1
            library.Update(book);

            var loanData = new Loan
            {
                BookId = book.Id,
                UserId = userRepo.Get(user).Id
            };
            loanRepo.Add(loanData); //new loan added


            Console.WriteLine("Book loaned successfully!");
        }

        /// <summary>
        /// User returns a book, book quantity increase by 1, loan is deleted
        /// </summary>
        /// <param name="library"></param>
        /// <param name="user"></param>
        public static void ReturnBook(LibraryRepository<Book> library, User user)
        {
            var context = new BookDbContext();
            LibraryRepository<Loan> loanRepo = new LibraryRepository<Loan>(context);
            UserRepository<User> userRepo = new UserRepository<User>(context);

            Console.Clear();
            Console.Write("Enter book ID to return: ");

            int bookId = int.Parse(Console.ReadLine()??string.Empty);
            var bookDb = context.Set<Book>();
            var book = bookDb.FirstOrDefault(b => b.Id == bookId);

            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            var userInfo = userRepo.Get(user);
            var loanData = context.Set<Loan>()
                .FirstOrDefault(l => l.BookId==book.Id && l.UserId==userInfo.Id);

            if (loanData == null)
            {
                Console.WriteLine("Loan does not exist");
                return;
            }

            loanRepo.Delete(loanData!); //loan is deleted

            book.Stock++;   //stock is increased
            library.Update(book);

            Console.WriteLine("Book returned successfully!");
        }

        /// <summary>
        /// takes in book Id, returns the information about the book
        /// </summary>
        /// <param name="library"></param>
        public static void DisplayBookInformation(LibraryRepository<Book> library)
        {
            var context = new BookDbContext();
            Console.Clear();
            Console.Write("Enter book ID to display information: ");

            int bookId = int.Parse(Console.ReadLine() ?? string.Empty);
            var bookDb = context.Set<Book>();
            var book = bookDb.FirstOrDefault(b => b.Id == bookId);

            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            Console.WriteLine("Book Information:");
            Console.WriteLine($"Title: {book.Title}");
            //Console.WriteLine($"Author: {book.Author.FirstName} {book.Author.LastName}");
            //Console.WriteLine($"Genre: {book.Genre.Name}");
            //Console.WriteLine($"Publisher: {book.Publisher.Name}");
            Console.WriteLine($"Published Date: {book.PublishedDate}");
            Console.WriteLine($"ISBN: {book.ISBN}");
            Console.WriteLine($"Price: Rs. {book.Price}");
            Console.WriteLine($"Stock: {book.Stock}");
        }
    }
}
