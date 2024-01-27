using BookManagementClassLibrary.Configurations;
using BookManagementClassLibrary.Domains;
using Microsoft.EntityFrameworkCore;

namespace BookManagementClassLibrary.DbContexts
{
    public class BookDbContext : DbContext
    {
        public BookDbContext() { }
        
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=BookManagement;Username=postgres;Password=Asdf!234;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new BookConfiguration().Configure(modelBuilder.Entity<Book>());
            new AuthorConfiguration().Configure(modelBuilder.Entity<Author>());
            new GenreConfiguration().Configure(modelBuilder.Entity<Genre>());
            new UserConfiguration().Configure(modelBuilder.Entity<User>());
            new PublisherConfiguration().Configure(modelBuilder.Entity<Publisher>());
            new LoanConfiguration().Configure(modelBuilder.Entity<Loan>());
        }
    }
}
