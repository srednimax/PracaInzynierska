using System.Net;
using AutoMapper;
using LibraryBackend.Dtos.User;
using LibraryDatabase.Models;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryBackend.Test;

[TestClass]
public class UserControllerTests
{
    private readonly HttpClient _httpClient;
    private readonly CustomWebApplicationFactory<Program> _factory;
    private readonly LibraryDatabaseContext _db;
    private readonly IMapper _mapper;

    public UserControllerTests()
    {
        _factory = new CustomWebApplicationFactory<Program>();

        _httpClient = _factory.CreateClient();
        var scope = _factory.Services.GetService<IServiceScopeFactory>().CreateScope();
        _db = scope.ServiceProvider.GetService<LibraryDatabaseContext>();
        _mapper = scope.ServiceProvider.GetService<IMapper>();
    }
    [DataTestMethod]
    [DataRow("email@gmail.com","123$Qwer","firstName","lastName",Gender.Undefined,"123456789")]
    [DataRow("hfiqwkds@wp.pl", "1827dj37W63h@", "Bob", "Smith", Gender.Male, "827301832")]
    [DataRow("dkeodywldpwkdpw@gmail.com", "291292WS8#@sd", "Angelina", "Jelly", Gender.Female, "295740283")]
    public async Task SignUpUser_Should_AddUserToDatabase(string email,string password,string firstName,string lastName,Gender gender,string phoneNumber)
    {
        var userSignUpDto = new UserSignUpDto()
        {
            Email = email,
            Password = password,
            ConfirmPassword = password,
            FirstName =firstName ,
            LastName = lastName,
            Gender = gender,
            PhoneNumber = phoneNumber,
            Birth = DateTime.Now.AddYears(-23)
        };

        var response = await _httpClient.PostAsync("api/User/SignUp", Utilities.Serialize(userSignUpDto));

        var userFromDb = _db.Users.FirstOrDefault(x => x.Email == userSignUpDto.Email);

        Assert.IsNotNull(userFromDb);

    }
    
}