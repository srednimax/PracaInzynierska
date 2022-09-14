using LibraryDatabase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryDatabase.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Email)
            .HasColumnName("email")
            .HasMaxLength(150)
            .IsRequired();
        builder.HasIndex(x => x.Email).IsUnique();

        builder.Property(x => x.Password)
            .HasColumnName("password")
            .HasColumnType("nvarchar(MAX)")
            .IsRequired();

        builder.Property(x => x.PhoneNumber)
            .HasColumnName("phone_number")
            .HasColumnType("nvarchar(MAX)")
            .IsRequired();

        builder.Property(x => x.FirstName)
            .HasColumnName("first_name")
            .HasColumnType("nvarchar(MAX)")
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasColumnName("last_name")
            .HasColumnType("nvarchar(MAX)")
            .IsRequired();

        builder.Property(x => x.Role)
            .HasColumnName("role")
            .HasColumnType("int")
            .HasDefaultValue(Role.User);

        builder.Property(x => x.Gender)
            .HasColumnName("gender")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(x => x.Birth)
            .HasColumnName("birth")
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(x => x.Penalty)
            .HasColumnName("penalty")
            .HasColumnType("decimal")
            .HasDefaultValue(0);
    }
}