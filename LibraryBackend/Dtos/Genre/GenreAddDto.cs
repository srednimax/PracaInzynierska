using System.ComponentModel.DataAnnotations;

namespace LibraryBackend.Dtos.Genre;

public class GenreAddDto
{
    [Required]
    public string? Name { get; set; }
}