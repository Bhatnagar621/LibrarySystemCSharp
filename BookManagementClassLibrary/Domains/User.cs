using System.ComponentModel.DataAnnotations;

namespace BookManagementClassLibrary.Domains
{
    public class User: BaseDomain
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public Loan? Loan { get; set; }
    }
}
