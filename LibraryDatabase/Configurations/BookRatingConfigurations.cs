using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace LibraryDatabase.Configurations;

public class BookRatingConfigurations:IEntityTypeConfiguration<BookRating>
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

        builder.ToTable("BookRating")
            .HasOne(x => x.Book)
            .WithMany()
            .HasForeignKey("book_id");
    }
}