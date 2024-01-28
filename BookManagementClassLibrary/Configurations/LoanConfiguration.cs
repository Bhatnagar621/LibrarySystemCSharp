using BookManagementClassLibrary.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManagementClassLibrary.Configurations
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.HasOne(l => l.User).WithOne(u => u.Loan).HasForeignKey<Loan>(l => l.UserId);
            builder.HasOne(l => l.Book).WithMany(b => b.Loans).HasForeignKey(l => l.BookId);
            builder.HasIndex(["Id", "IsDeleted"]);
        }
    }
}
