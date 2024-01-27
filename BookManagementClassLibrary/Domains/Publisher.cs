using System.ComponentModel.DataAnnotations;

namespace BookManagementClassLibrary.Domains
{
    public class Publisher: BaseDomain
    {
        public string Name { get; set; }
        [Url]
        public string? Website { get; set; }
        public List<Book>? Books { get; set; }
    }
}
