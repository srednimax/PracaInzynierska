﻿// <auto-generated />
using System;
using LibraryDatabase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryDatabase.Migrations
{
    [DbContext(typeof(LibraryDatabaseContext))]
    [Migration("20221122113819_returnedDate")]
    partial class returnedDate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LibraryDatabase.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("author");

                    b.Property<bool>("IsBorrowed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("is_borrowed");

                    b.Property<int>("PublishYear")
                        .HasColumnType("int")
                        .HasColumnName("publish_year");

                    b.Property<double>("Rating")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0)
                        .HasColumnName("rating");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("books", (string)null);
                });

            modelBuilder.Entity("LibraryDatabase.Models.BookGenre", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("BookId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("BookGenre");
                });

            modelBuilder.Entity("LibraryDatabase.Models.BookRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("comment");

                    b.Property<int>("Rating")
                        .HasColumnType("int")
                        .HasColumnName("rating");

                    b.Property<int?>("book_id")
                        .HasColumnType("int");

                    b.Property<int?>("user_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("book_id");

                    b.HasIndex("user_id");

                    b.ToTable("book_ratings", (string)null);
                });

            modelBuilder.Entity("LibraryDatabase.Models.BorrowedBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("BorrowDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("borrowed_date")
                        .HasDefaultValueSql("CAST( GETDATE() AS DateTime )");

                    b.Property<bool>("IsRated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("is_rated");

                    b.Property<bool>("IsRenew")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("is_renew");

                    b.Property<bool>("IsReturned")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("is_returned");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime")
                        .HasColumnName("return_date");

                    b.Property<DateTime?>("ReturnedDate")
                        .HasColumnType("datetime")
                        .HasColumnName("returned_date");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("status");

                    b.Property<int?>("book_id")
                        .HasColumnType("int");

                    b.Property<int?>("employee_id")
                        .HasColumnType("int");

                    b.Property<int?>("reader_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("book_id");

                    b.HasIndex("employee_id");

                    b.HasIndex("reader_id");

                    b.ToTable("borrowed_books", (string)null);
                });

            modelBuilder.Entity("LibraryDatabase.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("genres", (string)null);
                });

            modelBuilder.Entity("LibraryDatabase.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("Birth")
                        .IsRequired()
                        .HasColumnType("datetime")
                        .HasColumnName("birth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("first_name");

                    b.Property<int>("Gender")
                        .HasColumnType("int")
                        .HasColumnName("gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("password");

                    b.Property<decimal>("Penalty")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(38,17)")
                        .HasDefaultValue(0m)
                        .HasColumnName("penalty");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("phone_number");

                    b.Property<int>("Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("role");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("LibraryDatabase.Models.BookGenre", b =>
                {
                    b.HasOne("LibraryDatabase.Models.Book", "Book")
                        .WithMany("BookGenres")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LibraryDatabase.Models.Genre", "Genre")
                        .WithMany("BookGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("LibraryDatabase.Models.BookRating", b =>
                {
                    b.HasOne("LibraryDatabase.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("book_id");

                    b.HasOne("LibraryDatabase.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("user_id");

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LibraryDatabase.Models.BorrowedBook", b =>
                {
                    b.HasOne("LibraryDatabase.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("book_id");

                    b.HasOne("LibraryDatabase.Models.User", "Employee")
                        .WithMany()
                        .HasForeignKey("employee_id");

                    b.HasOne("LibraryDatabase.Models.User", "Reader")
                        .WithMany()
                        .HasForeignKey("reader_id");

                    b.Navigation("Book");

                    b.Navigation("Employee");

                    b.Navigation("Reader");
                });

            modelBuilder.Entity("LibraryDatabase.Models.Book", b =>
                {
                    b.Navigation("BookGenres");
                });

            modelBuilder.Entity("LibraryDatabase.Models.Genre", b =>
                {
                    b.Navigation("BookGenres");
                });
#pragma warning restore 612, 618
        }
    }
}
