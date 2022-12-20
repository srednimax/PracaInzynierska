using LibraryBackend.Repositories.Interfaces;
using LibraryDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryBackend.Repositories;

public class UserRepository: Repository<User>,IUserRepository
{
    public UserRepository(LibraryDatabaseContext context) : base(context) { }
    public async Task<List<User>> GetAllUsers()
    {
        return await GetAll().ToListAsync();
    }

    public async Task<User?> GetUserById(int id)
    {
        return await GetAll().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await GetAll().FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<User?> AddUser(User newUser)
    {
        return await AddAsync(newUser);
    }

    public async Task<User?> UpdateUser(User updateUser)
    {
        return await UpdateAsync(updateUser);
    }

    public async Task<User?> RemoveUser(User userToRemove)
    {
        return await RemoveAsync(userToRemove);
    }

    public async Task<User?> SignIn(User user)
    {
        return await GetAll().FirstOrDefaultAsync(x => x.Email == user.Email && x.Password == user.Password);
    }
}