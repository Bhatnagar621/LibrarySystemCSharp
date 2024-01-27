using BookManagementClassLibrary.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManagementClassLibrary.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.Property("Name").HasMaxLength(100).IsRequired();
            builder.Property("Description").HasMaxLength(500);
            builder.HasMany(g => g.Books).WithOne(b => b.Genre);
        }
    }
}
