using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using LibraryBackend.Dtos.Book;
using LibraryBackend.Dtos.Genre;
using LibraryBackend.Dtos.User;
using LibraryDatabase.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;

namespace LibraryBackend.Test
{
    [TestClass]
    public class BookControllerTests
    {
        private readonly HttpClient _httpClient;

        public BookControllerTests()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            /*.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.RemoveAll(typeof(LibraryDatabaseContext));
                    services.AddDbContext<LibraryDatabaseContext>(options =>
                    {
                        options.UseInMemoryDatabase("memoryDB");
                    });
                });
            });*/

            _httpClient = webAppFactory.CreateClient();



        }
        [TestMethod]
        public async Task GetAllBooks_ShouldReturnOkStatus()
        {

            var response = await _httpClient.GetAsync("api/Book/GetAll");

            Assert.AreEqual(true, response.StatusCode == HttpStatusCode.OK);

        }

        [TestMethod]
        public async Task AddingNewBook_ShouldReturnOkStatus()
        {
            var bookAdd = new BookAddDto()
            {
                Author = "test",
                Genres = new List<GenreDto>() { new GenreDto() { Id = 7, Name = "Fantastyka Naukowa" } },
                PublishYear = 1999,
                Title = "elo"

            };
            await LoginEmp();

            var response = await _httpClient.PostAsync("api/Book", Serialize(bookAdd));

            Assert.AreEqual(true, response.StatusCode == HttpStatusCode.OK);

        }

        [TestMethod]
        public async Task UpdatingTheBook_ShouldReturnOkStatus()
        {
            var dto = new BookUpdateDto()
            {
                Id = 31,
                Author = "InnyAutor",
                Title = "InnyTytul",
                Genres = new List<GenreDto>(),
                PublishYear = 2000
            };
            await LoginEmp();

            var response = await _httpClient.PutAsync("api/Book",Serialize(dto));

            Assert.AreEqual(true, response.StatusCode == HttpStatusCode.OK);

        }

       
        [TestMethod]
        public async Task DeletingNotExistingBook_ShouldReturnNotFoundStatus()
        {

            await LoginEmp();

            var response = await _httpClient.DeleteAsync("api/Book/12345678");

            Assert.AreEqual(true, response.StatusCode == HttpStatusCode.NotFound);

        }
        [TestMethod]
        public async Task GetRecommendedBooks_ShouldReturnOkStatus()
        {
            await LoginUser();

            var response = await _httpClient.GetAsync("api/Book/Recommended");

            Assert.AreEqual(true,response.StatusCode == HttpStatusCode.OK);
        }


        private async Task<string> GetJwtAsync(UserSignInDto userSignInDto)
        {
            var result = await _httpClient.PostAsync("api/User/SignIn", Serialize(userSignInDto));


            return result.Headers.GetValues("jwt").FirstOrDefault();
        }

        private StringContent Serialize<T>(T dto)
        {
            return new StringContent(JsonConvert.SerializeObject(dto), UnicodeEncoding.UTF8, "application/json");
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