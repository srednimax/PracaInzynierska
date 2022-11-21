using LibraryDatabase.Models;

namespace LibraryBackend.Repositories.Interfaces;

public interface IGenreRepository
{
    public Task<List<Genre>> GetAllGenres();
    public Task<Genre?> GetGenreById(int id);
    public Task<Genre?> GetGenByName(string name);
    public Task<Genre?> AddGenre(Genre newGenre);
    public Task<Genre?> UpdateGenre(Genre updateGenre);
    public Task<Genre?> RemoveGenre(Genre genreToRemove);
    public Task<bool> CheckIfNotExist(List<Genre> genres);
}