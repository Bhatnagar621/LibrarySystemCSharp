using BookManagementClassLibrary.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManagementClassLibrary.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property("FirstName").HasMaxLength(100);
            builder.Property("LastName").HasMaxLength(100);
            builder.Property("Email").HasMaxLength(500);
            builder.Property("Password").HasMaxLength(100);
            builder.HasIndex("Email").IsUnique();
            builder.HasIndex(["Id", "IsDeleted"]);
        }
    }
}
