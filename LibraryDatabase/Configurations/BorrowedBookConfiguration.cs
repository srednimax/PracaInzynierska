using LibraryDatabase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryDatabase.Configurations;

public class BorrowedBookConfiguration : IEntityTypeConfiguration<BorrowedBook>
{
    public void Configure(EntityTypeBuilder<BorrowedBook> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.BorrowDate)
            .HasColumnName("borrowed_date")
            .HasColumnType("datetime")
            .HasDefaultValueSql("CAST( GETDATE() AS DateTime )")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.ReturnDate)
            .HasColumnName("return_date")
            .HasColumnType("datetime")
            .IsRequired(false);

        builder.Property(x => x.IsRenew)
            .HasColumnName("is_renew")
            .HasColumnType("bit")
            .HasDefaultValue(false);

        builder.Property(x => x.IsReturned)
            .HasColumnName("is_returned")
            .HasColumnType("bit")
            .HasDefaultValue(false);

        builder.Property(x => x.Status)
            .HasColumnName("status")
            .HasColumnType("int")
            .HasDefaultValue(Status.Booked);

        builder.ToTable("borrowed_books")
            .HasOne(x => x.Book)
            .WithMany()
            .HasForeignKey("book_id");

        builder.ToTable("borrowed_books")
            .HasOne(x => x.Employee)
            .WithMany()
            .HasForeignKey("employee_id");

        builder.ToTable("borrowed_books")
            .HasOne(x => x.Reader)
            .WithMany()
            .HasForeignKey("reader_id");
        
    }
}