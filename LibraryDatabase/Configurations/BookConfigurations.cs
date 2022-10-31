using LibraryDatabase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryDatabase.Configurations;

public class BookConfigurations:IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("books");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Title)
            .HasColumnName("title")
            .HasColumnType("nvarchar(MAX)")
            .IsRequired();

        builder.Property(x => x.Author)
            .HasColumnName("author")
            .HasColumnType("nvarchar(MAX)")
            .IsRequired();

        builder.Property(x => x.PublishYear)
            .HasColumnName("publish_year")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(x => x.Genre)
            .HasColumnName("genre")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(x => x.IsBorrowed)
            .HasColumnName("is_borrowed")
            .HasColumnType("bit")
            .HasDefaultValue(false);

        builder.Property(x => x.Rating)
            .HasColumnName("rating")
            .HasColumnType("float")
            .HasDefaultValue(0);

    }
}