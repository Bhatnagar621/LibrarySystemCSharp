namespace BookManagementClassLibrary.Domains
{
    public class Loan: BaseDomain
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateOnly loanDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly dueDate { get; set; } = DateOnly.FromDateTime(DateTime.Now.AddDays(30));
    }
}
