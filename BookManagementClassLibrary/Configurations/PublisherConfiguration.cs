using BookManagementClassLibrary.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManagementClassLibrary.Configurations
{
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.Property("Name").HasMaxLength(200);
            builder.Property("Website").HasMaxLength(500);
            builder.HasMany(p => p.Books).WithOne(p => p.Publisher)
                .HasForeignKey(p => p.PublisherId);
        }
    }
}
