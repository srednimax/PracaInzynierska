using LibraryBackend.Repositories;
using LibraryBackend.Repositories.Interfaces;
using LibraryBackend.Services;
using LibraryBackend.Services.Interfaces;
using LibraryDatabase.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<LibraryDatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryDatabase"));
    options.EnableSensitiveDataLogging();
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// services
builder.Services.AddTransient<IUserService, UserService>();

// repositories
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IBookRatingRepository, BookRatingRepository>();
builder.Services.AddTransient<IBorrowedBookRepository,BorrowedBookRepository>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LibraryDatabaseContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
