// See https://aka.ms/new-console-template for more information

using BookManagementClassLibrary;
using BookManagementClassLibrary.DbContexts;
using BookManagementClassLibrary.Domains;
using ConsoleBookApplication;

//LibraryRepository<Author> authortable = new LibraryRepository<Author>(new BookDbContext());
//LibraryRepository<Genre> genreTable = new LibraryRepository<Genre>(new BookDbContext());
//LibraryRepository<Book> bookTable = new LibraryRepository<Book>(new BookDbContext());
//LibraryRepository<Publisher> publisherTable = new LibraryRepository<Publisher>(new BookDbContext());


LoginPage.StartPage(); //startup page of the console

//var tableData = new List<Author>
//{
//    new Author{FirstName="Rainbow", LastName="Rowell"},
//    new Author{FirstName="Khaled", LastName="Hosseini"},
//    new Author{FirstName="James", LastName="Forrester"},
//    new Author{FirstName="Shari", LastName="Lapena"},
//    new Author{FirstName="Alexandra", LastName="Potter"},
//    new Author{FirstName="Amish", LastName="Tripathi", Description="An author and a diplomat from india"}
//};

//var genreData = new List<Genre>
//{
//    new Genre{Name="Romance"},
//    new Genre{Name="Fiction"},
//    new Genre{Name="History"},
//    new Genre{Name="Crime"},
//    new Genre{Name="Fantasy"},
//    new Genre{Name="Non-Fiction"},
//    new Genre{Name="Self-Help"},
//    new Genre{Name="Sci-Fi"},
//    new Genre{Name="Horror"},
//};

//var publisherData = new List<Publisher>
//{
//    new Publisher{Name="Westland"},
//    new Publisher{Name="Hodder"},
//    new Publisher{Name="Corgi"},
//    new Publisher{Name="Headline Review"},
//    new Publisher{Name="Bloomsbury"},
//    new Publisher{Name="Orion"}
//};

//var bookData = new List<Book>
//{
//    new Book{
//        Title="A Thousand Splendid Suns",
//        ISBN="9781408844441",
//        AuthorId=2,
//        GenreId=2,
//        PublisherId = 5,
//        PublishedDate = DateOnly.Parse(new ("2007,02,01")),
//        Price=499,
//        Stock=10
//    },
//    new Book{
//        Title="The Kite Runner",
//        ISBN="978140824856",
//        AuthorId=2,
//        GenreId=2,
//        PublisherId = 5,
//        PublishedDate = DateOnly.Parse(new ("2007,02,01")),
//        Price=499,
//        Stock=10
//    },
//    new Book{
//        Title="Eleanor & Park",
//        ISBN="9781409120544",
//        AuthorId=1,
//        GenreId=1,
//        PublisherId = 6,
//        PublishedDate = DateOnly.Parse(new ("2012,02,01")),
//        Price=499,
//        Stock=10
//    },

//};




//genreTable.AddRange(genreData);

//publisherTable.AddRange(publisherData);

//authortable.AddRange(tableData);

//bookTable.AddRange(bookData);


