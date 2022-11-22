using LibraryBackend.Dtos.Genre;

namespace LibraryBackend.Services.Interfaces;

public interface IGenreService
{
    public Task<ServiceResult<List<GenreDto>>> GetAllGenres();
    public Task<ServiceResult<GenreDto>> AddGenre(GenreAddDto genreAddDto);
    public Task<ServiceResult<GenreDto>> UpdateGenre(GenreUpdateDto genreUpdateDto);
    public Task<ServiceResult<GenreDto>> RemoveGenre(int id);
}