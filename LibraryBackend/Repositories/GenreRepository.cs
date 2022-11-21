using LibraryBackend.Repositories.Interfaces;
using LibraryDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryBackend.Repositories;

public class GenreRepository : Repository<Genre>, IGenreRepository
{
    public GenreRepository(LibraryDatabaseContext context) : base(context)
    {
    }

    public async Task<List<Genre>> GetAllGenres()
    {
        return await GetAll().ToListAsync();
    }

    public async Task<Genre?> GetGenreById(int id)
    {
        return await GetAll().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Genre?> GetGenByName(string name)
    {
        return await GetAll().FirstOrDefaultAsync(x => x.Name == name);
    }

    public async Task<Genre?> AddGenre(Genre newGenre)
    {
        return await AddAsync(newGenre);
    }

    public async Task<Genre?> UpdateGenre(Genre updateGenre)
    {
        return await UpdateAsync(updateGenre);
    }

    public async Task<Genre?> RemoveGenre(Genre genreToRemove)
    {
        return await RemoveAsync(genreToRemove);
    }

    public async Task<bool> CheckIfExist(List<Genre> genres)
    {
        var gen = await GetAll().ToListAsync();
        return !genres.Except(gen).Any();
    }
}