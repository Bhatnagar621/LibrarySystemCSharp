using BookManagementClassLibrary.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManagementClassLibrary.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property("FirstName").HasMaxLength(100);
            builder.Property("LastName").HasMaxLength(100);
            builder.Property("Description").HasMaxLength(500);
            builder.HasMany(a => a.Books).WithOne(b => b.Author).
                HasForeignKey(b => b.AuthorId);
            builder.HasIndex(["Id", "IsDeleted"]);
        }
    }
}
