using LibraryDatabase.Models;

namespace LibraryBackend.Repositories.Interfaces;

public interface IUserRepository
{
    public Task<List<User>> GetAllUsers();
    public Task<User?> GetUserById(int id);
    public Task<User?> GetUserByEmail(string email);
    public Task<User?> AddUser(User newUser);
    public Task<User?> UpdateUser(User updateUser);
    public Task<User?> RemoveUser(User userToRemove);
    public Task<User?> SignIn(User user);
}