﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LibraryDatabase.Models;

public class LibraryDatabaseContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BorrowedBook> BorrowedBooks { get; set; }
    public DbSet<BookRating> BookRatings { get; set; }
    public DbSet<Genre> Genres { get; set; }

    public LibraryDatabaseContext()
    {

    }
    public LibraryDatabaseContext(DbContextOptions<LibraryDatabaseContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .LogTo(Console.WriteLine, LogLevel.Information)
                .UseSqlServer(
                    "Data Source=DESKTOP-6LKDIAB;Database=Library;Integrated Security=True;TrustServerCertificate=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}