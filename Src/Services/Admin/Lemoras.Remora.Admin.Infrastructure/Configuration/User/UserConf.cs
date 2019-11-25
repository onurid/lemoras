using Lemoras.Remora.Admin.Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lemoras.Remora.Infrastructure.Configuration
{
    internal class UserConf : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("user_id");

            builder.Property(u => u.Username)
                .HasColumnName("username");

            builder.Property(u => u.Password)
                .HasColumnName("password");

            builder.Property(u => u.Email)
                .HasColumnName("email");

            builder.Property(u => u.Firstname)
                .HasColumnName("first_name");

            builder.Property(u => u.Lastname)
                .HasColumnName("last_name");

            builder.Property(u => u.Active)
                .HasColumnName("active");            

            builder.Property(u => u.LastLogindate)
               .HasColumnName("last_login_date");
        }
    }
}
