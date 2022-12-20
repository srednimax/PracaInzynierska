using LibraryDatabase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryDatabase.Configurations;

public class BookRatingConfiguration:IEntityTypeConfiguration<BookRating>
{
    public void Configure(EntityTypeBuilder<BookRating> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Comment)
            .HasColumnName("comment")
            .HasColumnType("nvarchar(MAX)")
            .IsRequired(false);

        builder.Property(x => x.Rating)
            .HasColumnName("rating")
            .HasColumnType("int")
            .IsRequired();

        builder.ToTable("book_ratings")
            .HasOne(x => x.Book)
            .WithMany()
            .HasForeignKey("book_id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("book_ratings")
            .HasOne(x => x.User)
            .WithMany()
            .HasForeignKey("user_id");
    }
}