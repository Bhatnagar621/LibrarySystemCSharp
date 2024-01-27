namespace BookManagementClassLibrary.Domains
{
    public class BaseDomain
    {
        public int Id { get; set; }
        public DateOnly LastUpdated { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public bool IsDeleted { get; set; } = false;
    }
}
