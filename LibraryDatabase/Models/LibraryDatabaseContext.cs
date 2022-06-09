using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;

namespace LibraryDatabase.Models;

public class LibraryDatabaseContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }

    public LibraryDatabaseContext(DbContextOptions<LibraryDatabaseContext> options): base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}