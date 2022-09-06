using LibraryBackend.Repositories.Interfaces;
using LibraryDatabase.Models;

namespace LibraryBackend.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly LibraryDatabaseContext _libraryDatabaseContext;

    public Repository(LibraryDatabaseContext context)
    {
        _libraryDatabaseContext = context;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _libraryDatabaseContext.AddAsync(entity);
        await _libraryDatabaseContext.SaveChangesAsync();
        return entity;
    }

    public IQueryable<TEntity> GetAll()
    {
        return _libraryDatabaseContext.Set<TEntity>();
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _libraryDatabaseContext.Update(entity);
        await _libraryDatabaseContext.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> RemoveAsync(TEntity entity)
    {
        _libraryDatabaseContext.Remove(entity);
        await _libraryDatabaseContext.SaveChangesAsync();
        return entity;
    }

    public async Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entities)
    {
        _libraryDatabaseContext.UpdateRange(entities);
        await _libraryDatabaseContext.SaveChangesAsync();
        return entities;
    }

    public async Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities)
    {
        await _libraryDatabaseContext.AddRangeAsync(entities);
        await _libraryDatabaseContext.SaveChangesAsync();
        return entities;
    }
}