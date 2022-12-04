using LibraryDatabase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryDatabase.Configurations;

public class BookConfiguration:IEntityTypeConfiguration<Book>
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

        builder.Property(x => x.IsBorrowed)
            .HasColumnName("is_borrowed")
            .HasColumnType("bit")
            .HasDefaultValue(false);

        builder.Property(x => x.Rating)
            .HasColumnName("rating")
            .HasColumnType("float")
            .HasDefaultValue(0);

        builder
            .HasMany(b => b.Genres)
            .WithMany(g => g.Books)
            .UsingEntity<BookGenre>(
                x =>
                    x.HasOne(y => y.Genre)
                        .WithMany(y => y.BookGenres)
                        .HasForeignKey(y => y.GenreId),
                x =>
                    x.HasOne(y => y.Book)
                        .WithMany(y => y.BookGenres)
                        .HasForeignKey(y => y.BookId)
            );

    }
}