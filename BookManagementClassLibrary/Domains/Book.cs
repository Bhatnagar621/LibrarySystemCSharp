namespace BookManagementClassLibrary.Domains
{
    public class Book: BaseDomain
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public DateOnly PublishedDate { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public List<Loan>? Loans { get; set; }
    }
}
