namespace BookManagementClassLibrary.Domains
{
    public class Genre: BaseDomain
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<Book>? Books { get; set; }
    }
}
