using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using AutoMapper;
using LibraryBackend.Dtos.Book;
using LibraryBackend.Dtos.Genre;
using LibraryBackend.Dtos.User;
using LibraryDatabase.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;

namespace LibraryBackend.Test
{
    [TestClass]
    public class BookControllerTests
    {
        private readonly HttpClient _httpClient;
        private readonly CustomWebApplicationFactory<Program> _factory;
        private readonly LibraryDatabaseContext _db;
        private readonly IMapper _mapper;

        public BookControllerTests()
        {
            _factory = new CustomWebApplicationFactory<Program>();

            _httpClient = _factory.CreateClient();
            var scope = _factory.Services.GetService<IServiceScopeFactory>().CreateScope();
            _db = scope.ServiceProvider.GetService<LibraryDatabaseContext>();
            _mapper = scope.ServiceProvider.GetService<IMapper>();
        }

        [TestMethod]
        public async Task GetAllBooks_Should_ReturnOkStatus()
        {

            var response = await _httpClient.GetAsync("api/Book/GetAll");

            Assert.AreEqual(true, response.StatusCode == HttpStatusCode.OK);

        }

        [TestMethod]
        public async Task AddingNewBook()
        {
            var bookToAdd = new BookAddDto()
            {
                Title = "Nowo dodana",
                Author = "Autor 15",
                Genres = new List<GenreDto>() { new GenreDto() { Id = 1, Name = "test" } },
                PublishYear = 1999,
            };
            
            await LoginEmp();
            var response = await _httpClient.PostAsync("api/Book", Utilities.Serialize(bookToAdd));

            var addedBook = _db.Books.FirstOrDefault(x => x.Title == bookToAdd.Title);

            Assert.AreEqual(bookToAdd.Title, addedBook.Title);
            Assert.AreEqual(bookToAdd.Author,addedBook.Author);

        }
        [TestMethod]
        public async Task AddingNewBook_BadRequest()
        {
            var bookToAdd = new BookAddDto()
            {
                Title = "Nowo dodana",
                Author = "",
                Genres = new List<GenreDto>() { new GenreDto() { Id = 1, Name = "test" } },
                PublishYear = 1999,
            };

            await LoginEmp();
            var response = await _httpClient.PostAsync("api/Book", Utilities.Serialize(bookToAdd));

            Assert.AreEqual(true,response.StatusCode == HttpStatusCode.BadRequest);


        }

        [TestMethod]
        public async Task UpdatingTheBook()
        {
            var bookToUpdateDto = _mapper.Map<BookUpdateDto>(_db.Books.First());
            bookToUpdateDto.Title += "Test";
            bookToUpdateDto.Author += "Test";
            await LoginEmp();

            var response = await _httpClient.PutAsync("api/Book", Utilities.Serialize(bookToUpdateDto));
            var updatedBook = await response.Content.ReadFromJsonAsync<BookDto>();

            Assert.AreEqual(bookToUpdateDto.Id, updatedBook.Id);
            Assert.AreEqual(bookToUpdateDto.Title, updatedBook.Title);
            Assert.AreEqual(bookToUpdateDto.Author, updatedBook.Author);

        }

       
        [TestMethod]
        public async Task DeletingNotExistingBook_Should_ReturnNotFoundStatus()
        {

            await LoginEmp();

            var response = await _httpClient.DeleteAsync("api/Book/12345678");

            Assert.AreEqual(true, response.StatusCode == HttpStatusCode.NotFound);

        }
        [TestMethod]
        public async Task GetRecommendedBooks_Should_ReturnOkStatus()
        {
            await LoginUser();

            var response = await _httpClient.GetAsync("api/Book/Recommended");

            Assert.AreEqual(true,response.StatusCode == HttpStatusCode.OK);
        }


        private async Task<string> GetJwtAsync(UserSignInDto userSignInDto)
        {
            var result = await _httpClient.PostAsync("api/User/SignIn", Utilities.Serialize(userSignInDto));

            var t = result.Headers;
            return result.Headers.GetValues("jwt").FirstOrDefault();
        }



        private async Task LoginEmp()
        {
            var userSignInDto = new UserSignInDto() { Email = "emp@gmail.com", Password = "123$Qwer" };
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJwtAsync(userSignInDto));
        }
        private async Task LoginUser()
        {
            var userSignInDto = new UserSignInDto() { Email = "user@gmail.com", Password = "123$Qwer" };
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJwtAsync(userSignInDto));
        }
    }
}