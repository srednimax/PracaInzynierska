using AutoMapper;
using LibraryBackend.Dtos.Genre;
using LibraryBackend.Repositories.Interfaces;
using LibraryBackend.Services.Interfaces;
using LibraryDatabase.Models;

namespace LibraryBackend.Services;

public class GenreService : IGenreService
{
    private readonly IGenreRepository _genreRepository;
    private readonly IMapper _mapper;

    public GenreService(IGenreRepository genreRepository, IMapper mapper)
    {
        _genreRepository = genreRepository;
        _mapper = mapper;
    }
    public async Task<ServiceResult<List<GenreDto>>> GetAllGenres()
    {
        return new ServiceResult<List<GenreDto>>()
        {
            Body = _mapper.Map<List<GenreDto>>(await _genreRepository.GetAllGenres()),
            Status = 200
        };
    }

    public async Task<ServiceResult<GenreDto>> AddGenre(GenreAddDto genreAddDto)
    {
        var checkIfExist = await _genreRepository.GetGenByName(genreAddDto.Name);

        if (checkIfExist is not null)
            return new ServiceResult<GenreDto>() { Status = 500, Message = "The genre already exist" };

        var genre = _mapper.Map<Genre>(genreAddDto);

        return new ServiceResult<GenreDto>()
            { Status = 200, Body = _mapper.Map<GenreDto>(await _genreRepository.AddGenre(genre)) };
    }

    public async Task<ServiceResult<GenreDto>> UpdateGenre(GenreUpdateDto genreUpdateDto)
    {
        var genre = await _genreRepository.GetGenreById(genreUpdateDto.Id);

        if (genre is null)
            return new ServiceResult<GenreDto>() { Status = 404 };

        var checkIfExist = await _genreRepository.GetGenByName(genreUpdateDto.Name);

        if (checkIfExist is not null)
            return new ServiceResult<GenreDto>() { Status = 500, Message = "The genre already exist" };

        genre.Name = genreUpdateDto.Name;

        return new ServiceResult<GenreDto>()
            { Status = 200, Body = _mapper.Map<GenreDto>(await _genreRepository.UpdateGenre(genre)) };
    }

    public async Task<ServiceResult<GenreDto>> RemoveGenre(int id)
    {
        var genre = await _genreRepository.GetGenreById(id);

        if (genre is null)
            return new ServiceResult<GenreDto>() { Status = 404 };

        return new ServiceResult<GenreDto>()
            { Status = 200, Body = _mapper.Map<GenreDto>(await _genreRepository.RemoveGenre(genre)) };
    }
}