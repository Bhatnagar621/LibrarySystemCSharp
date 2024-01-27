using BookManagementClassLibrary.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManagementClassLibrary.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property("Title").HasMaxLength(100).IsRequired();
            builder.Property("ISBN").HasMaxLength(13).IsRequired();
            builder.Property("Price").HasPrecision(5, 2);
        }
    }
}
