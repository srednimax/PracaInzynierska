using LibraryDatabase.Models;

namespace LibraryBackend.Repositories.Interfaces;

public interface IGenreRepository
{
    public Task<Genre?> GetGenreById(int id);
    public Task<Genre?> GetGenByName(string name);
    public Task<Genre?> AddGenre(Genre newUser);
    public Task<Genre?> UpdateGenre(Genre updateUser);
    public Task<Genre?> RemoveGenre(Genre userToRemove);
}